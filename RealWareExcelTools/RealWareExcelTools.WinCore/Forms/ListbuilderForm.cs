﻿using DevExpress.XtraEditors;
using Newtonsoft.Json;
using RealWare.Core.API;
using RealWare.Core.API.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RealWareExcelTools.WinCore.Forms
{
    public partial class ListBuilderForm : DevExpress.XtraEditors.XtraForm
    {
        public RWListBuilderQueryItem SelectedListBuilderItem => listBuilderQueryGrid1.SelectedListBuilderItem;
        public RWListBuilderQueryItem HasParamaters => listBuilderQueryGrid1.SelectedListBuilderItem;

        public DataTable Result;

        private readonly RealWareApi _api;
        private CancellationTokenSource _cancellationTokenSource;

        public ListBuilderForm()
        {
            InitializeComponent();

            //Default to off
            btnImport.Enabled = false;

            Shown += async (s, e) =>
            {
                var queries = GetListBuilderQueriesAsync();
                listBuilderQueryGrid1.OnLoad(await queries);
            };

            //Events
            listBuilderQueryGrid1.DataChangeEvent += (s, e) => refreshImportButton();
            listBuilderQueryGrid1.ParametersRequestEvent += listBuilderQueryGrid1_ParametersRequestEvent;
        }

        public ListBuilderForm(RealWareApi api) : this()
        {
            _api = api;
        }

        public async Task<List<RWListBuilderQueryItem>> GetListBuilderQueriesAsync()
        {
            return await _api.GetListBuilderSearchesAsync().ConfigureAwait(false);
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

        private void btnImport_Click(object sender, System.EventArgs e)
        {
            // Execute the query
            var results = _api.GetListBuilderQueryResults(
                SelectedListBuilderItem.QueryID, 
                listBuilderQueryGrid1.GetParameters());

            Result = combineListBuilderResultsAsDatatable2(results);
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
    }
}