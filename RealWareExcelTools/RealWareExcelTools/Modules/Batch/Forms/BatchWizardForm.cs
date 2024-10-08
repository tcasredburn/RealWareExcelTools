using DevExpress.XtraReports.Web.ReportDesigner.DataContracts;
using DevExpress.XtraWizard;
using RealWareExcelTools.Core.Settings.API;
using RealWareExcelTools.Core.Settings.Plugins;
using RealWareExcelTools.Modules.Batch.Models;
using System;
using System.Linq;
using RealWareExcelTools.Core.Extensions;
using DevExpress.Data.Helpers;

namespace RealWareExcelTools.Modules.Batch.Forms
{
    public partial class BatchWizardForm : DevExpress.XtraEditors.XtraForm
    {

        private readonly BatchConfigurationScript _config;
        private readonly BatchWizardSettings _wizardSettings;
        private readonly RealWareApiConnectionSettings _apiSettings;

        public BatchWizardForm(BatchWizardSettings wizardSettings, RealWareApiConnectionSettings apiSettings)
        {
            _config = new BatchConfigurationScript();

            // Set readonly values
            _wizardSettings = wizardSettings;
            _apiSettings = apiSettings;

            // Init controls
            InitializeComponent();

            // Init events
            wizardControl1.SelectedPageChanged += selectedPageChanged;
        }

        private void BatchWizardForm_Load(object sender, EventArgs e)
        {
            if (_wizardSettings.SkipFirstPage)
            {
                chkSkipFirstPage.Checked = true;
                wizardControl1.SelectedPage = pageSelectModule;
            }
            else
                wizardControl1.SelectedPage = pageWelcome;
        }

        private void selectedPageChanged(object sender, WizardPageChangedEventArgs e)
        {
            switch (e?.PrevPage?.Name)
            {
                case nameof(pageWelcome):
                    {

                    }
                    break;
                case nameof(pageSelectModule):
                    {
                        _config.Module = (BatchModule)grpModuleType.SelectedIndex;
                        refreshApiOperationDropdown();
                    }
                    break;
                case nameof(pageSelectOperation):
                    {

                    }
                    break;
            }

            RefreshPage(e.Page.Name);
        }

        private void RefreshPage(string pageName)
        {
            switch(pageName)
            {
                case nameof(pageWelcome):
                    {

                    }
                    break;
                case nameof(pageSelectModule):
                    {
                        grpModuleType.SelectedIndex = (int)_config.Module;
                    }
                    break;
                case nameof(pageSelectOperation):
                    {
                        
                    }
                    break;
            }
        }

        private void refreshApiOperationDropdown()
        {
            var test = Enum.GetNames(typeof(ApiOperation));
            var test2 = test.Select(x => (ApiOperation)Enum.Parse(typeof(ApiOperation), x)).ToList();
            var test3 = test2.Select(x => x.GetDisplayName()).ToList();

            var items = Enum.GetNames(typeof(ApiOperation))
                .Select(x => (ApiOperation)Enum.Parse(typeof(ApiOperation), x))
                .Select(x => x.GetDisplayName())
                .Select(x=>string.Format(x, _config.Module.ToString().ToLower()));

            cmbBatchAction.Properties.Items.Clear();
            cmbBatchAction.Properties.Items.AddRange(items.ToList());
            cmbBatchAction.SelectedText = items.FirstOrDefault();
        }

        private void chkSkipFirstPage_CheckedChanged(object sender, EventArgs e)
            => _wizardSettings.SkipFirstPage = chkSkipFirstPage.Checked;
    }
}