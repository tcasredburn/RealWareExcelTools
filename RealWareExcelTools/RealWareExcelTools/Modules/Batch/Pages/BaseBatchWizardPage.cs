using RealWareExcelTools.Modules.Batch.Models;
using System.Windows.Forms;

namespace RealWareExcelTools.Modules.Batch.Pages
{
    public partial class BaseBatchWizardPage : DevExpress.XtraEditors.XtraUserControl
    {
        public virtual bool AllowPrevious { get; set; } = true;

        public BatchWizardContext Context { get; private set; }

        public BaseBatchWizardPage()
        {
        }

        public virtual void InitializePage(BatchWizardContext context)
        {
            this.Context = context;

            Dock = DockStyle.Fill;
            BringToFront();
        }

        public virtual void RefreshPage()
            => Context.BatchWizardController.RefreshPage();

        public virtual bool OnValidatePage() => true;
    }
}
