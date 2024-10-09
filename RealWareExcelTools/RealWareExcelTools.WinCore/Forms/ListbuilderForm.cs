using DevExpress.XtraEditors;
using Newtonsoft.Json;
using RealWare.Core.API;
using RealWare.Core.API.Models;
using RealWareExcelTools.Core.Settings;
using RealWareExcelTools.Core.Settings.General;
using RealWareExcelTools.WinCore.Views.ListBuilder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading;

namespace RealWareExcelTools.WinCore.Forms
{
    /// <summary>
    /// Form for selecting a list builder query and executing it.
    /// The results are returned as a DataTable.
    /// </summary>
    public partial class ListBuilderForm : DevExpress.XtraEditors.XtraForm
    {
        public RWListBuilderQueryItem SelectedListBuilderItem => listBuilderQueryGrid1.SelectedListBuilderItem;
        public RWListBuilderQueryItem HasParamaters => listBuilderQueryGrid1.SelectedListBuilderItem;

        /// <summary>
        /// The results of the query.
        /// </summary>
        public DataTable Result { get; private set; }

        private readonly RealWareApi _api;
        private CancellationTokenSource _cancellationTokenSource;
        private readonly GeneralSettings _settings;

        /// <summary>
        /// Design Time Only constructor.
        /// </summary>
        public ListBuilderForm()
        {
            InitializeComponent();

            // Default to off
            btnImport.Enabled = false;
            importProgressPanel.Visible = false;

            // Events
            this.Shown += listBuilderForm_Shown;
            listBuilderQueryGrid1.ParametersRequestEvent += listBuilderQueryGrid1_ParametersRequestEvent;
            listBuilderQueryGrid1.DataChangeEvent += (s, e) => refreshImportButton();
            this.FormClosing += listBuilderForm_FormClosing;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="api"></param>
        public ListBuilderForm(RealWareApi api, GeneralSettings settings) : this()
        {
            _api = api;
            _settings = settings;

            listBuilderQueryGrid1.SetDefaultTaxYear(settings.GetTaxYear());
        }

        private async void listBuilderForm_Shown(object sender, System.EventArgs e)
        {
            if (_api == null)
                throw new System.Exception("RealWare API is not set. You are probably not using the correct constructor.");

            // Get the listbuilder queries from the api
            var queries = _api.GetListBuilderSearchesAsync().ConfigureAwait(false);

            try
            {
                // Load the listbuilder queries to the grid
                var result = await queries;
                listBuilderQueryGrid1.OnLoad(result);
            }
            catch(Exception ex)
            {
                listBuilderQueryGrid1.OnLoad(new List<RWListBuilderQueryItem>());
                ErrorMessage.ShowErrorMessage(ErrorMessageType.ListBuilder_FailedToLoadQueries, ex.Message);
            }

            
        }

        private async void listBuilderQueryGrid1_ParametersRequestEvent(object sender, RWListBuilderQueryItem e)
        {
            btnImport.Enabled = false;

            // Cancel the previous request if any
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();

            try
            {
                var parameters = await _api.GetListBuilderSearchParametersAsync(e.QueryID, _cancellationTokenSource.Token);

                // Ensure that no other request has been initiated since this one started
                if (!_cancellationTokenSource.Token.IsCancellationRequested)
                {
                    listBuilderQueryGrid1.LoadParameters(parameters);
                }
            }
            catch (System.OperationCanceledException)
            {
                // Task was canceled, so just exit
                return;
            }
            catch (System.Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

            refreshImportButton();
        }

        private async void btnImport_Click(object sender, System.EventArgs e)
        {
            btnImport.Enabled = false;
            importProgressPanel.Visible = true;

            // Execute the query
            var results = _api.GetListBuilderQueryResultsAsync(
                SelectedListBuilderItem.QueryID,
                listBuilderQueryGrid1.GetParameters());

            // Set the result object
            try
            {
                Result = combineListBuilderResultsAsDatatable(await results);
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (System.Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            finally
            {
                importProgressPanel.Visible = false;
                btnImport.Enabled = true;
            }
        }

        private DataTable combineListBuilderResultsAsDatatable2(List<object> listbuilderResults)
        {
            if (listbuilderResults == null || listbuilderResults.Count == 0)
                return null;

            // Combine all objects into a single JSON array string
            var combinedJson = "[" + string.Join(",", listbuilderResults.Select(item => item.ToString())) + "]";

            // Deserialize the combined JSON string into a DataTable
            var table = JsonConvert.DeserializeObject<DataTable>(combinedJson);

            // Set all columns to allow null values
            foreach (DataColumn column in table.Columns)
                column.AllowDBNull = true;

            return table;
        }

        private void refreshImportButton()
        {
            btnImport.Enabled = SelectedListBuilderItem != null;
        }

        private void listBuilderForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            _cancellationTokenSource?.Cancel();
            listBuilderQueryGrid1.OnCloseCleanup();
        }






        private DataTable combineListBuilderResultsAsDatatable(List<object> listbuilderResults)
        {
            if (listbuilderResults == null)
                return null;

            if (listbuilderResults.Count == 0)
                return null;

            var json = "[" + listbuilderResults.First().ToString() + "]";
            var table = JsonConvert.DeserializeObject<DataTable>(json);

            table.Rows.Clear();

            foreach (DataColumn column in table.Columns)
                column.AllowDBNull = true;

            for (int i = 0; i < listbuilderResults.Count; i++)
            {
                // Note: There is probably a much faster to do this using json serializer,
                //       this solution works for now though.
                //
                var json2 = "[" + listbuilderResults[i].ToString() + "]";
                var table2 = JsonConvert.DeserializeObject<DataTable>(json2);
                table.ImportRow(table2.Rows[0]);
            }

            return table;
        }
    }
}