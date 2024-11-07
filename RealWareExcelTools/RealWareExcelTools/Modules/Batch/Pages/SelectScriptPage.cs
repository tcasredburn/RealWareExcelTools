using DevExpress.XtraWizard;
using System;
using System.Data;
using System.Linq;

namespace RealWareExcelTools.Modules.Batch.Pages
{
    public partial class SelectScriptPage : BaseBatchWizardPage, IRealWareBatchWizardPage
    {
        public string PageTitle => "Script";

        public string PageDescription => "Create a new script or continue an existing or previous script.";

        public SelectScriptPage()
        {
            InitializeComponent();

            // Defaults
            grpNewScript.SelectedIndex = 0;

            // Events
            grpNewScript.SelectedIndexChanged += refreshScriptVisibility;
        }

        private void refreshScriptVisibility(object sender, EventArgs e)
        {
            layoutControlItem2.Visibility = getIsNewScript() 
                ? DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                : DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }

        public void OnRefreshPage(Direction? direction = null)
        {
            if (direction == Direction.Forward)
                loadScriptsFromDirectory();
        }

        private void loadScriptsFromDirectory()
        {
            var scripts = Context.File.ReadScriptFileNames(
                Context.Script.Module,
                Context.Script.Action);

            lstScripts.Items.Clear();
            lstScripts.Items.AddRange(
                scripts.ToList()
                .Select(x => new {
                    Name = x.Key,
                    Value = x.Value
                }).ToArray());
            lstScripts.DisplayMember = "Name";
            lstScripts.ValueMember = "Value";
        }

        public void OnSavePage()
        {
            Context.Script.IsNewScript = getIsNewScript();

            if(!Context.Script.IsNewScript)
                Context.Script.ScriptName = lstScripts.SelectedValue.ToString();
        }

        private bool getIsNewScript()
            => (bool)grpNewScript.EditValue;
    }
}
