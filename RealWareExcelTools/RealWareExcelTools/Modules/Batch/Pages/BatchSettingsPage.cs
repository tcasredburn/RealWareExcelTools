using DevExpress.XtraWizard;
using System;

namespace RealWareExcelTools.Modules.Batch.Pages
{
    public partial class BatchSettingsPage : BaseBatchWizardPage, IRealWareBatchWizardPage
    {
        public string PageTitle => "Batch Settings";

        public string PageDescription => "Configure retry and thread settings.";

        public BatchSettingsPage()
        {
            InitializeComponent();
        }

        public void OnSavePage()
        {
            Context.Script.ThreadCount = trackBarThreads.Value;
            Context.Script.RetryCount = trackBarRetryCount.Value;
            Context.Script.RetryDelay = Convert.ToInt32(spinRetryDelay.Value * 1000);
        }

        public void OnRefreshPage(Direction? direction = null)
        {

        }
    }
}
