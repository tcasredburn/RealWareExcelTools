using DevExpress.XtraWizard;
using RealWareExcelTools.Modules.Batch.Models;

namespace RealWareExcelTools.Modules.Batch.Pages
{
    public interface IRealWareBatchWizardPage
    {
        bool IsPageValid { get; }
        bool AllowPrevious { get; set; }

        string PageTitle { get; }
        string PageDescription { get; }

        BatchWizardContext Context { get; }

        void OnSavePage();

        void OnRefreshPage(Direction? direction = null);

        void InitializePage(BatchWizardContext context);
    }
}
