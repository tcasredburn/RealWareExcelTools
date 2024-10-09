using DevExpress.XtraWizard;

namespace RealWareExcelTools.Modules.Batch.Pages
{
    public partial class ProcessingScriptPage : BaseBatchWizardPage, IRealWareBatchWizardPage
    {
        public string PageTitle => "Processing";

        public string PageDescription => "View process and logging for the script.";

        public ProcessingScriptPage()
        {
            InitializeComponent();
        }

        public void OnSavePage()
        {

        }

        public void OnRefreshPage(Direction? direction = null)
        {

        }
    }
}
