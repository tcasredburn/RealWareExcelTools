using RealWareExcelTools.WinCore.Models.Batch;

namespace RealWareExcelTools.WinCore.Views.Batch.Items
{
    public class BatchScriptMappingInfo
    {
        public string RealWarePath { get; set; }

        public string RealWareColumnName { get; set; }

        public string DataSourceName { get; set; }

        public DataSourceType DataSourceType { get; set; }
    }
}
