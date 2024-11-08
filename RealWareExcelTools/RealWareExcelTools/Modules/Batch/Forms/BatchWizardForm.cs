using DevExpress.XtraWizard;
using RealWareExcelTools.Modules.Batch.Models;
using System;
using RealWareExcelTools.Modules.Batch.Pages;
using System.Collections.Generic;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using RealWareExcelTools.Modules.Batch.Controller;
using DevExpress.XtraBars;

namespace RealWareExcelTools.Modules.Batch.Forms
{
    public partial class BatchWizardForm : DevExpress.XtraEditors.XtraForm, IBatchWizardController
    {
        private readonly IRealWareBatchWizardPage[] WizardPages =
            new IRealWareBatchWizardPage[]
            {
                new PreValidationPage(),
                new SelectModulePage(),
                new SelectOperationPage(),
                //new SelectScriptPage(),
                new SetBatchValuesPage(),
                new ProcessingScriptPage()
            };


        private readonly BatchWizardContext _context;
        private readonly Dictionary<BaseWizardPage, IRealWareBatchWizardPage> _wizardPageDictionary;

        public BatchWizardForm(BatchWizardContext context)
        {
            _context = context;
            _context.SetController(this);
            _wizardPageDictionary = new Dictionary<BaseWizardPage, IRealWareBatchWizardPage>();

            // Init controls
            InitializeComponent();

            // Load all the pages 
            initializeWizardPages();
            
            // Init events
            wizardControl1.SelectedPageChanging += selectedPageChanging;
            wizardControl1.SelectedPageChanged += selectedPageChanged;
        }

        private void initializeWizardPages()
        {
            wizardControl1.Pages.Clear();

            wizardControl1.Pages.Add(pageWelcome);

            foreach (var page in WizardPages)
            {
                var wizardPage = new WizardPage()
                {
                    Name = page.GetType().Name,
                    Text = page.PageTitle,
                    DescriptionText = page.PageDescription
                };

                _wizardPageDictionary.Add(wizardPage, page);

                wizardPage.Controls.Add(page as XtraUserControl);
                wizardControl1.Pages.Add(wizardPage);

                page.InitializePage(_context);
            }

            wizardControl1.Pages.Add(completionWizardPage1);
        }

        private void BatchWizardForm_Load(object sender, EventArgs e)
        {
            if (_context.Settings.SkipFirstPage)
            {
                chkSkipFirstPage.Checked = true;
                wizardControl1.SelectedPageIndex = 1;
            }
            else
                wizardControl1.SelectedPageIndex = 0;
        }

        private void selectedPageChanging(object sender, WizardPageChangingEventArgs e)
        {
            if (e.Direction == Direction.Forward && e.PrevPage != null)
            {
                if (_wizardPageDictionary.TryGetValue(e.PrevPage, out IRealWareBatchWizardPage page))
                    page.OnSavePage();
            }
        }

        private void selectedPageChanged(object sender, WizardPageChangedEventArgs e)
        {
            if(_wizardPageDictionary.TryGetValue(e.Page, out IRealWareBatchWizardPage page))
                page.OnRefreshPage(e.Direction);
        }

        private void chkSkipFirstPage_CheckedChanged(object sender, EventArgs e)
            => _context.Settings.SkipFirstPage = chkSkipFirstPage.Checked;

        public void RefreshPage()
        {
            if(wizardControl1.SelectedPage != null 
                && _wizardPageDictionary.TryGetValue(wizardControl1.SelectedPage, out IRealWareBatchWizardPage page))
            {
                wizardControl1.SelectedPage.AllowNext = page.IsPageValid;
                page.OnRefreshPage();
            }
        }
    }
}