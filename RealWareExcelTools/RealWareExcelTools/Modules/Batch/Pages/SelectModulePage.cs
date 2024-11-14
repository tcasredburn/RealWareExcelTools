using DevExpress.XtraWizard;
using RealWareExcelTools.Modules.Batch.Models;

namespace RealWareExcelTools.Modules.Batch.Pages
{
    public partial class SelectModulePage : BaseBatchWizardPage, IRealWareBatchWizardPage
    {
        public string PageTitle => "Select Module";

        public string PageDescription => "Select the module type you want to batch.";

        public SelectModulePage() : base()
        {
            InitializeComponent();
            grpModuleType.EditValueChanged += (s, e) =>
            {
                RefreshPage();
            };
        }

        public void OnSavePage()
        {
            Context.Script.Module = (BatchModule)grpModuleType.SelectedIndex;
        }

        public void OnRefreshPage(Direction? direction = null)
        {
            if(direction == Direction.Forward)
                grpModuleType.SelectedIndex = (int)Context.Script.Module;
        }

        public override bool OnValidatePage()
        {
            return grpModuleType.SelectedIndex != -1;
        }
    }
}
