using System;
using System.Linq;
using System.Collections.Generic;

namespace RealWareExcelTools.WinCore.Forms
{
    public partial class DbConnectionStringBuilder : DevExpress.XtraEditors.XtraForm
    {
        const int SQL_TIMEOUT_SECONDS_FOR_TEST = 4;

        public string ConnectionString { get; private set; }

        public DbConnectionStringBuilder(string connectionString = null)
        {
            InitializeComponent();

            if(!string.IsNullOrEmpty(connectionString))
                deserializeConnectionString(connectionString);

            refreshSqlLoginVisibility();
        }

        private void deserializeConnectionString(string connectionString)
        {
            Dictionary<string, string> connStringParts = connectionString
                .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(t => t.Split(new char[] { '=' }, 2))
                .Where(t => t.Length == 2) // Only include entries with both key and value
                .ToDictionary(t => t[0].Trim(), t => t[1].Trim(), StringComparer.InvariantCultureIgnoreCase);

            txtServer.Text = connStringParts.ContainsKey("Data Source") ? connStringParts["Data Source"] : string.Empty;
            txtDatabase.Text = connStringParts.ContainsKey("Initial Catalog") ? connStringParts["Initial Catalog"] : string.Empty;
            chkIntegratedSecurity.Checked = connStringParts.ContainsKey("Integrated Security")
                && connStringParts["Integrated Security"].Equals("True", StringComparison.InvariantCultureIgnoreCase);
            txtLogin.Text = connStringParts.ContainsKey("User ID") ? connStringParts["User ID"] : string.Empty;
            txtPassword.Text = connStringParts.ContainsKey("Password") ? connStringParts["Password"] : string.Empty;
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            saveConnectionString();
            TestConnectionToDatabase(ConnectionString);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            saveConnectionString();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void saveConnectionString()
        {
           ConnectionString = $"Data Source={txtServer.Text};Initial Catalog={txtDatabase.Text};";
            if(chkIntegratedSecurity.Checked)
                ConnectionString += "Integrated Security=True;";
            else
                ConnectionString += $"User ID={txtLogin.Text};Password={txtPassword.Text};";
        }

        private void chkIntegratedSecurity_CheckedChanged(object sender, EventArgs e)
            => refreshSqlLoginVisibility();

        private void refreshSqlLoginVisibility()
            => grpSqlLoginSecurity.Enabled = !chkIntegratedSecurity.Checked;

        public static bool TestConnectionToDatabase(string connectionString)
        {
            var quickConnectionString = connectionString + $"Connection Timeout={SQL_TIMEOUT_SECONDS_FOR_TEST};";

            try
            {
                using (var conn = new System.Data.SqlClient.SqlConnection(quickConnectionString))
                {
                    conn.Open();
                    DevExpress.XtraEditors.XtraMessageBox.Show("Connection successful.", "Success",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
                return true;
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show($"Connection failed.\r\n\r\n{ex.Message}", "Error",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return false;
        }
    }
}