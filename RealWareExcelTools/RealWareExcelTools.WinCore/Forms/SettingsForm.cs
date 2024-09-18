using DevExpress.XtraEditors;
using RealWareExcelTools.Core.Settings;
using System;
using System.Windows.Forms;

namespace RealWareExcelTools.WinCore.Forms
{
    public partial class SettingsForm : DevExpress.XtraEditors.XtraForm
    {
        public AddinSettings GetSettings() => settings;

        private AddinSettings settings;
        private Views.Settings.SettingsMainView mainView;

        public SettingsForm(AddinSettings settings = null)
        {
            this.settings = settings;

            if(this.settings == null)
                this.settings = new AddinSettings();

            InitializeComponent();
        }

        private void SettingsForm_Shown(object sender, EventArgs e)
        {
            var loadingHandle = Helpers.Progress.CreateProgressPanel(moduleContainer);

            mainView = new Views.Settings.SettingsMainView();
            mainView.OnLoadSettings(settings);
            mainView.Dock = DockStyle.Fill;
            moduleContainer.Controls.Add(mainView);

            Helpers.Progress.CloseProgressPanel(loadingHandle);
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            if (!mainView.OnSaveSettings(ref settings))
            {
                ErrorMessage.ShowErrorMessage(mainView.OnSaveErrorMessage, "Failed to Save Settings");
            }
            else
                this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}