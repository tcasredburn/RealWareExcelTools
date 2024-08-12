using DevExpress.XtraPrinting.Native;
using DevExpress.XtraPrinting.Native.WebClientUIControl;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCA.Framework.RealWare.Api;
using TCA.Framework.RealWare.Api.Model.Dto;

namespace RealWareExcelTools.WinCore.Forms
{
    public partial class ListBuilderForm : DevExpress.XtraEditors.XtraForm
    {
        public ListBuilderQueryItemDto SelectedListBuilderItem => listBuilderQueryGrid1.SelectedListBuilderItem;

        public DataTable Result;

        private readonly RealWareApi _api;

        public ListBuilderForm()
        {
            InitializeComponent();

            Shown += async (s, e) =>
            {
                var queries = GetListBuilderQueriesAsync();
                listBuilderQueryGrid1.OnLoad(await queries);
            };
        }

        public ListBuilderForm(RealWareApi api) : this()
        {
            _api = api;
        }

        public async Task<List<ListBuilderQueryItemDto>> GetListBuilderQueriesAsync()
        {
            return await _api.GetListBuilderSearchesAsync().ConfigureAwait(false);
        }

        private void btnImport_Click(object sender, System.EventArgs e)
        {
            // Execute the query
            var results = _api.GetListBuilderQueryResults(
                SelectedListBuilderItem.QueryID, 
                new List<ListBuilderQueryParameterDto>());///////////////////////////TODO!!!!!!!

            Result = combineListBuilderResultsAsDatatable(results);
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