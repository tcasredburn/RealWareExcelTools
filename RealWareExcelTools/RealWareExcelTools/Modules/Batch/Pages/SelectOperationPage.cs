using RealWareExcelTools.Modules.Batch.Models;
using System;
using System.Linq;
using RealWareExcelTools.Core.Extensions;
using DevExpress.XtraWizard;
using DevExpress.XtraLayout;

namespace RealWareExcelTools.Modules.Batch.Pages
{
    public partial class SelectOperationPage : BaseBatchWizardPage, IRealWareBatchWizardPage
    {
        public string PageTitle => "Operation";

        public string PageDescription => "Specify basic settings for inserting, updating, or deleting data.";

        public SelectOperationPage() : base()
        {
            InitializeComponent();

            // Init events
            cmbBatchAction.SelectedIndexChanged += (s, e) => refreshIdColumns();
            batchIdSelectionControl1.OnSetValueEvent += refreshSetValueVisibility;
            batchIdSelectionControl2.OnSetValueEvent += refreshSetValueVisibility;
            batchIdSelectionControl3.OnSetValueEvent += refreshSetValueVisibility;
        }

        public void OnSavePage()
        {
            Context.Script.Action = getActionFromDropdown();
        }

        public void OnRefreshPage(Direction? direction = null)
        {
            refreshSpreadsheetDropdown();
            refreshApiOperationDropdown();
            refreshIdColumns();
        }

        private void refreshApiOperationDropdown()
        {
            var items = Enum.GetNames(typeof(ApiOperation))
                .Select(x => (ApiOperation)Enum.Parse(typeof(ApiOperation), x))
                .Select(x => x.GetDisplayName())
                .Select(x => string.Format(x, Context.Script.Module.ToString().ToLower()));

            cmbBatchAction.Properties.Items.Clear();
            cmbBatchAction.Properties.Items.AddRange(items.ToList());
            cmbBatchAction.SelectedIndex = 0;
        }

        private void refreshIdColumns()
        {
            var action = getActionFromDropdown();

            switch (Context.Script.Module)
            {
                case BatchModule.Account:
                    batchIdSelectionControl1.SetIdColumn(IdValueType.AccountNo);
                    batchIdSelectionControl2.SetIdColumn(IdValueType.TaxYear);
                    batchIdSelectionControl3.SetIdColumn(IdValueType.None);
                    break;
                case BatchModule.Appeal:
                    if (action == ApiOperation.POST)
                    {
                        batchIdSelectionControl1.SetIdColumn(IdValueType.TaxYear);
                        batchIdSelectionControl2.SetIdColumn(IdValueType.None);
                    }
                    else
                    {
                        batchIdSelectionControl1.SetIdColumn(IdValueType.AppealNo);
                        batchIdSelectionControl2.SetIdColumn(IdValueType.TaxYear);
                    }
                    batchIdSelectionControl3.SetIdColumn(IdValueType.None);
                    break;
                case BatchModule.Sale:
                    batchIdSelectionControl1.SetIdColumn(IdValueType.ReceptionNo);
                    batchIdSelectionControl2.SetIdColumn(IdValueType.None);
                    batchIdSelectionControl3.SetIdColumn(IdValueType.None);
                    break;
                case BatchModule.Permit:
                    if (action == ApiOperation.POST)
                    {
                        batchIdSelectionControl1.SetIdColumn(IdValueType.TaxYear);
                        batchIdSelectionControl2.SetIdColumn(IdValueType.None);
                    }
                    else
                    {
                        batchIdSelectionControl1.SetIdColumn(IdValueType.PermitNo);
                        batchIdSelectionControl2.SetIdColumn(IdValueType.TaxYear);
                    }
                    batchIdSelectionControl3.SetIdColumn(IdValueType.None);
                    break;
                case BatchModule.Improvement:
                    batchIdSelectionControl1.SetIdColumn(IdValueType.AccountNo);
                    if (action == ApiOperation.POST)
                    {
                        batchIdSelectionControl2.SetIdColumn(IdValueType.TaxYear);
                        batchIdSelectionControl3.SetIdColumn(IdValueType.None);
                    }
                    else
                    {
                        batchIdSelectionControl2.SetIdColumn(IdValueType.ImpNo);
                        batchIdSelectionControl3.SetIdColumn(IdValueType.TaxYear);
                    }
                    break;
                default:
                    throw new NotImplementedException("Batch Module Type has not been implemented for action dropdown.");
            }
        }

        private void refreshSpreadsheetDropdown()
        {
            cmbExcelSpreadsheet.Properties.Items.Clear();
            cmbExcelSpreadsheet.Properties.Items.AddRange(Context.ExcelController.GetSheetNames().ToArray());
            if (cmbExcelSpreadsheet.SelectedIndex == -1)
                cmbExcelSpreadsheet.SelectedIndex = 0;
        }

        private void refreshSetValueVisibility(object sender, IdValueType e)
        {
            var isVisible = !(e == IdValueType.None);

            if (sender == batchIdSelectionControl1)
                setBatchIdSelectionControlVisibility(layoutControlItemId1, isVisible);
            else if (sender == batchIdSelectionControl2)
                setBatchIdSelectionControlVisibility(layoutControlItemId2, isVisible);
            else if (sender == batchIdSelectionControl3)
                setBatchIdSelectionControlVisibility(layoutControlItemId3, isVisible);
        }

        private void setBatchIdSelectionControlVisibility(LayoutControlItem item, bool isVisible)
            => item.Visibility = isVisible 
                ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always 
                : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

        private ApiOperation getActionFromDropdown()
            => (ApiOperation)cmbBatchAction.SelectedIndex;


    }
}
