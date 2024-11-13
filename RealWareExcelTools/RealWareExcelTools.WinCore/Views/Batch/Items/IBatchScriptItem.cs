using System;

namespace RealWareExcelTools.WinCore.Views.Batch.Items
{
    public interface IBatchScriptItem
    {
        event EventHandler ScriptChangedEvent;

        BatchScriptMappingInfo GetBatchInfo();

        bool IsValid();
    }
}
