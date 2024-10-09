using DevExpress.XtraEditors;
using RealWareExcelTools.Modules.Batch.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealWareExcelTools.Modules.Batch.Pages
{
    public partial class BaseBatchWizardPage : DevExpress.XtraEditors.XtraUserControl
    {
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
    }
}
