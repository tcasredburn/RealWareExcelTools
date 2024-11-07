using System;

namespace RealWareExcelTools.WinCore.Forms
{
    public partial class DbConnectionStringBuilder : DevExpress.XtraEditors.XtraForm
    {
        public DbConnectionStringBuilder()
        {
            InitializeComponent();
        }

        private void chkIntegratedSecurity_CheckedChanged(object sender, EventArgs e)
        {
            grpSqlLoginSecurity.Enabled = !chkIntegratedSecurity.Checked;
        }
    }
}