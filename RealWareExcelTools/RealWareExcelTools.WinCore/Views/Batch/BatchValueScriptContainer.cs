using RealWareExcelTools.WinCore.Views.Batch.Items;
using System;
using System.Windows.Forms;

namespace RealWareExcelTools.WinCore.Views.Batch
{
    public partial class BatchValueScriptContainer : DevExpress.XtraEditors.XtraUserControl
    {
        public event EventHandler DeleteScriptEvent;

        public readonly IBatchScriptItem BatchItem;

        public event EventHandler<bool> ValidateEvent;

        public BatchValueScriptContainer()
        {
            InitializeComponent();
        }

        public BatchValueScriptContainer(IBatchScriptItem batchItem) : this()
        {
            this.BatchItem = batchItem;

            batchItem.ScriptChangedEvent += (s, e) =>
            {
                ValidateEvent?.Invoke(this, batchItem.IsValid());
            };

            var control = batchItem as Control;
            scriptContainer.Controls.Add(control);
            control.Dock = DockStyle.Fill;
        }

        private void btnDelete_Click(object sender, EventArgs e)
            => DeleteScriptEvent?.Invoke(this, EventArgs.Empty);
    }
}
