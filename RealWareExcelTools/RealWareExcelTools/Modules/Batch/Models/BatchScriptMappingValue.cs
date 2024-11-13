namespace RealWareExcelTools.Modules.Batch.Models
{ 
    /// <summary>
    /// Object that applies the new value
    /// </summary>
    public class BatchScriptMappingValue
    {
        public string PropertyName { get; set; }
        public string JsonPath { get; set; }
        public object ToValue { get; set; }
    }
}
