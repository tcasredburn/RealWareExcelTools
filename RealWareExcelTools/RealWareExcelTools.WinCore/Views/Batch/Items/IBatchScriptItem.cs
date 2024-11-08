using System;

namespace RealWareExcelTools.WinCore.Views.Batch.Items
{
    public interface IBatchScriptItem
    {
        event EventHandler ScriptChangedEvent;

        bool IsValid();
    }
}
