using RealWareExcelTools.Core.Settings;
using System.Runtime.InteropServices;

namespace RealWareExcelTools.WinCore.Views.Settings
{
    public partial class SettingsRealWareConnectionView : DevExpress.XtraEditors.XtraUserControl, ISettingsView
    {
        public string OnSaveErrorMessage { get; private set; }

        public SettingsRealWareConnectionView()
        {
            InitializeComponent();

            txtRealWareDbConnectionString.ButtonClick += txtRealWareDbConnectionString_ButtonClick;
        }

        public void OnLoadSettings(AddinSettings settings)
        {
            txtRealWareApiUrl.EditValue = settings.RealWareApiConnectionSettings.Url;
            chkConnectToApiOnStartup.IsOn = settings.RealWareApiConnectionSettings.ConnectOnExcelStartup;
            txtRealWareDbConnectionString.Text = settings.RealWareDbConnectionSettings.ConnectionString;
        }

        public bool OnSaveSettings(ref AddinSettings settings)
        {
            string apiValue = (string)txtRealWareApiUrl.EditValue;

            if(string.IsNullOrEmpty(apiValue))
            {
                OnSaveErrorMessage = "RealWare Api URL cannot be blank.";
                return false;
            }

            if(!apiValue.Contains("http") || !apiValue.Contains("://"))
            {
                OnSaveErrorMessage = "RealWare Api URL is in an incorrect format.\r\n\r\n" +
                    "Reason: Missing http:// and/or https:// prefix.";
                return false;
            }

            settings.RealWareApiConnectionSettings = new Core.Settings.API.RealWareApiConnectionSettings
            {
                Url = apiValue,
                ConnectOnExcelStartup = chkConnectToApiOnStartup.IsOn
            };

            settings.RealWareDbConnectionSettings = new Core.Settings.Database.RealWareDbConnectionSettings
            {
                ConnectionString = txtRealWareDbConnectionString.Text
            };

            return true;
        }

        private void txtRealWareDbConnectionString_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var frm = new Forms.DbConnectionStringBuilder(txtRealWareDbConnectionString.Text);
            if(frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtRealWareDbConnectionString.Text = frm.ConnectionString;
            }
        }

        private void btnTestDatabaseConnection_Click(object sender, System.EventArgs e)
        {
            Forms.DbConnectionStringBuilder.TestConnectionToDatabase(txtRealWareDbConnectionString.Text);
        }
    }
}
