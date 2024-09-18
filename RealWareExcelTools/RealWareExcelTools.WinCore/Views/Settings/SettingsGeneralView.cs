using RealWareExcelTools.Core.Settings;
using System;

namespace RealWareExcelTools.WinCore.Views.Settings
{
    public partial class SettingsGeneralView : DevExpress.XtraEditors.XtraUserControl, ISettingsView
    {
        public string OnSaveErrorMessage { get; private set; }

        public SettingsGeneralView()
        {
            InitializeComponent();

            cmbDefaultTaxYearType.SelectedValueChanged += (s, e) => RefreshView();
        }
        public void OnLoadSettings(AddinSettings settings)
        {
            cmbDefaultTaxYearType.Text = settings.GeneralSettings.DefaultTaxYearType;
            txtDefaultTaxYearValue.Text = settings.GeneralSettings.GetTaxYear();
            RefreshView();
        }

        public bool OnSaveSettings(ref AddinSettings settings)
        {
            if (string.IsNullOrEmpty(txtDefaultTaxYearValue.Text))
            {
                OnSaveErrorMessage = "Tax Year value cannot be blank.";
                return false;
            }

            settings.GeneralSettings = new Core.Settings.General.GeneralSettings
            {
                DefaultTaxYearType = cmbDefaultTaxYearType.Text,
                DefaultTaxYearValue = txtDefaultTaxYearValue.Text
            };

            return true;
        }

        public void RefreshView()
        {
            if(cmbDefaultTaxYearType.Text == "Current Year")
            {
                txtDefaultTaxYearValue.Enabled = false;
                txtDefaultTaxYearValue.Text = DateTime.Now.Year.ToString();
            }
            else
            {
                txtDefaultTaxYearValue.Enabled = true;
            }
        }
    }
}
