using DevExpress.XtraEditors;
using DevExpress.XtraWizard;
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
    public partial class SelectModulePage : BaseBatchWizardPage, IRealWareBatchWizardPage
    {
        public string PageTitle => "Select Module";

        public string PageDescription => "Select the module type you want to batch.";

        public SelectModulePage() : base()
        {
            InitializeComponent();
        }

        public void OnSavePage()
        {
            Context.Script.Module = (BatchModule)grpModuleType.SelectedIndex;
        }

        public void OnRefreshPage(Direction? direction = null)
        {
            grpModuleType.SelectedIndex = (int)Context.Script.Module;
        }
    }
}
