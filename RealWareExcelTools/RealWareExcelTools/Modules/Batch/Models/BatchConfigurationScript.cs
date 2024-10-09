namespace RealWareExcelTools.Modules.Batch.Models
{
    public class BatchConfigurationScript
    {
        public BatchModule Module { get; set; }
        public ApiOperation Action { get; set; }

        public bool IsNewScript { get; set; }
        public string ScriptName { get; set; }
    }
}
