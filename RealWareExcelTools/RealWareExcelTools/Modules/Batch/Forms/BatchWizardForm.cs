using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealWareExcelTools.Modules.Batch.Forms
{
    public partial class BatchWizardForm : DevExpress.XtraEditors.XtraForm
    {
        public BatchWizardForm()
        {
            InitializeComponent();
        }

        private void BatchWizardForm_Load(object sender, EventArgs e)
        {
            //TODO: Load the batch layout settings for skipping the first page and other settings
            //TODO: Skip the first page if checked
        }
    }
}