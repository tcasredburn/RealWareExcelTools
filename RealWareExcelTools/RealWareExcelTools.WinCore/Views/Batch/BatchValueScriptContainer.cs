using DevExpress.XtraEditors;
using RealWareExcelTools.WinCore.Views.Batch.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealWareExcelTools.WinCore.Views.Batch
{
    public partial class BatchValueScriptContainer : DevExpress.XtraEditors.XtraUserControl
    {
        public event EventHandler DeleteScriptEvent;

        public readonly IBatchScriptItem BatchItem;

        public BatchValueScriptContainer()
        {
            InitializeComponent();
        }

        public BatchValueScriptContainer(IBatchScriptItem batchItem) : this()
        {
            this.BatchItem = batchItem;

            var control = batchItem as Control;
            scriptContainer.Controls.Add(control);
            control.Dock = DockStyle.Fill;
        }

        private void btnDelete_Click(object sender, EventArgs e)
            => DeleteScriptEvent?.Invoke(this, EventArgs.Empty);
    }
}
