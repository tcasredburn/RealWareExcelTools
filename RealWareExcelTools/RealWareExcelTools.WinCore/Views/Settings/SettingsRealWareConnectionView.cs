using RealWareExcelTools.Core.Settings;

namespace RealWareExcelTools.WinCore.Views.Settings
{
    public partial class SettingsRealWareConnectionView : DevExpress.XtraEditors.XtraUserControl, ISettingsView
    {
        public string OnSaveErrorMessage { get; private set; }

        public SettingsRealWareConnectionView()
        {
            InitializeComponent();
        }

        public void OnLoadSettings(AddinSettings settings)
        {
            txtRealWareApiUrl.EditValue = settings.RealWareApiConnectionSettings.Url;
            chkConnectToApiOnStartup.IsOn = settings.RealWareApiConnectionSettings.ConnectOnExcelStartup;
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

            return true;
        }
    }
}
