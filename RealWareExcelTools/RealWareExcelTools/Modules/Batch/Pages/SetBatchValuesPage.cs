using DevExpress.XtraWizard;

namespace RealWareExcelTools.Modules.Batch.Pages
{
    public partial class SetBatchValuesPage : BaseBatchWizardPage, IRealWareBatchWizardPage
    {
        public string PageTitle => "Batch Values";

        public string PageDescription => "Specify which fields you will be inserting or updating.";

        public SetBatchValuesPage()
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
