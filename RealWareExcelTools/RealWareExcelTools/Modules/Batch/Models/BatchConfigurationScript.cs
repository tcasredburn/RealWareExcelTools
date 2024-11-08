namespace RealWareExcelTools.Modules.Batch.Models
{
    public class BatchConfigurationScript
    {
        public BatchModule Module { get; set; }
        public ApiOperation Action { get; set; }
        public string SpreadsheetName { get; set; }

        public string IdValue1 { get; set; }
        public bool IsIdValue1Static { get; set; }
        public IdValueType IdValue1Type { get; set; }

        public string IdValue2 { get; set; }
        public bool IsIdValue2Static { get; set; }
        public IdValueType IdValue2Type { get; set; }

        public string IdValue3 { get; set; }
        public bool IsIdValue3Static { get; set; }
        public IdValueType IdValue3Type { get; set; }

        public bool IsNewScript { get; set; }
        public string ScriptName { get; set; }
    }
}
