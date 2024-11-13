using DevExpress.Utils.Extensions;
using DevExpress.XtraWizard;
using RealWareExcelTools.Modules.Batch.Models;
using RealWareExcelTools.Modules.Batch.Providers;
using RealWareExcelTools.WinCore.Models.Batch;
using RealWareExcelTools.WinCore.Views.Batch;
using RealWareExcelTools.WinCore.Views.Batch.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RealWareExcelTools.Modules.Batch.Pages
{
    public partial class SetBatchValuesPage : BaseBatchWizardPage, IRealWareBatchWizardPage
    {
        public string PageTitle => "Batch Values";

        public string PageDescription => "Specify which fields you will be inserting or updating.";

        private BatchValueBuilder builder;
        private BatchModule? current_module;

        public SetBatchValuesPage()
        {
            InitializeComponent();
        }

        public void OnSavePage()
        {
            Context.Script.MappingInfo = getMappingInfoList();
        }

        private List<BatchScriptMappingInfo> getMappingInfoList()
        {
            var result = new List<BatchScriptMappingInfo>();

            builder.GetBatchValueItems().ForEach(x =>
            {
                result.Add(x.GetBatchInfo());
            });

            return result;
        }

        protected override void OnFirstLoad()
        {
            Context.DataProvider = new RealWareDataProvider(
                Context.ApiSettings.GetRealWareApiConnection(), 
                Context.DbSettings.ConnectionString, 
                DateTime.Now.Year.ToString());
        }

        public void OnRefreshPage(Direction? direction = null)
        {
            if(direction == Direction.Forward)
            {
                // Load the batch values
                loadScriptValueEditor(Context.Script.Module);
            }

            var items = builder.GetBatchValueItems();
            if (items.Length == 0 || items.Any(x=>!x.IsValid()))
            {
                IsPageValid = false;
            }
            else
            {
                IsPageValid = true;
            }
        }

        private void loadScriptValueEditor(BatchModule module)
        {
            if(current_module == module)
                return;

            current_module = module;

            if(builder != null)
            {
                builder.ScriptChangedEvent -= builder_ScriptChangedEvent;
                builder.Dispose();
            }

            Controls.Clear();

            builder = new BatchValueBuilder(Context.DataProvider, Context.ExcelController);
            builder.InitializeAddScriptDropdown(Context.BarManager, getValueScript(module));

            Controls.Add(builder);

            builder.Dock = System.Windows.Forms.DockStyle.Fill;

            builder.ScriptChangedEvent += builder_ScriptChangedEvent;
        }

        private List<ChangeValueScriptInfo> getValueScript(BatchModule module)
        {
            switch(module)
            {
                case BatchModule.Account:
                    return ChangeValueScriptInfoList.GetAccountScriptList();
                case BatchModule.Improvement:
                    return ChangeValueScriptInfoList.GetImprovementScriptList();
                case BatchModule.Sale:
                    return ChangeValueScriptInfoList.GetSaleScriptList();
            }

            return new List<ChangeValueScriptInfo>();
        }

        private void builder_ScriptChangedEvent(object sender, bool? isValid)
        {
            RefreshPage();
        }
    }
}
