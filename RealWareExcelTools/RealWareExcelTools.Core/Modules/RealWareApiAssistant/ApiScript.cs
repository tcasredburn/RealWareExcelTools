using System;
using System.Collections.Generic;
using System.Text;

namespace RealWareExcelTools.Core.Modules.RealWareApiAssistant
{
    public class ApiScript
    {
        public RealWareApiSettings ApiSettings { get; set; }
        public string ExcelFile { get; set; }
        public List<RealWareApiId> IdColumns { get; set; }
        public List<RealWareApiValue> ValueChanges { get; set; }
        public List<RealWareApiValue> ValueInserts { get; set; }
        public string ApiOperation { get; set; }
        public string Method { get; set; }
        public string CustomLogFileLocation { get; set; }
        public bool SkipConfirmations { get; set; }
        public bool SkipWarningPrompts { get; set; }
        public bool RetryImmediatelyAfterBadRequest { get; set; }
        public int ExcelFileRowUpdateCount { get; set; } = 5000;
        public bool ForceExcelNULLValues { get; set; } = true;
        //public ApiExportJsonToFileSettings ExportJsonSettings { get; set; }
        public int Threads { get; set; } = 1;
        public int RetryCount { get; set; } = 3;
        public int RetryWaitTimeInMs { get; set; } = 5000;
    }
}
