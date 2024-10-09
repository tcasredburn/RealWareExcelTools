using System.Collections.Generic;

namespace RealWareExcelTools.Modules.Batch.Models
{
    public class BatchScript
    {
        public string Name { get; set; }
        public List<BatchScriptMapping> Mappings { get; set; } = new List<BatchScriptMapping>();
    }
}
