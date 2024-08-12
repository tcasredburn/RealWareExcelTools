using System;
using System.Windows.Forms;

namespace RealWareExcelTools.WinCore.Forms
{
    public partial class SettingsForm : DevExpress.XtraEditors.XtraForm
    {
        public SettingsForm()
        {
            InitializeComponent();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}