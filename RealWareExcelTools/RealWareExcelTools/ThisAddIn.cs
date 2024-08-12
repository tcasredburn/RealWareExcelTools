using Microsoft.Office.Core;
using RealWareExcelTools.Core.Modules;
using RealWareExcelTools.Core.Settings;
using System;
using System.Windows.Forms;

namespace RealWareExcelTools
{
    public partial class ThisAddIn
    {
        private IRealWareExcelModule[] modules;
        public AddinSettings settings { get; private set; }

        internal void SaveSettings(AddinSettings addinSettings)
        {
            this.settings = addinSettings;

            // Start all modules
            foreach (var module in modules)
                module.OnRefreshSettings(addinSettings);
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            settings = AddinSettingsIO.ReadSettingsFromFile();

            modules = SetupModules.GetModules(this, settings);

            // Start all modules
            foreach (var module in modules)
                module.OnStart();
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Stop all modules
            foreach (var module in modules)
                module.OnStop();
        }

        protected override IRibbonExtensibility CreateRibbonExtensibilityObject()
            => new Ribbon.RealWareRibbon(this);

        public Microsoft.Office.Tools.CustomTaskPane CreateTab(string tabName, UserControl tabControl)
            => this.CustomTaskPanes.Add(tabControl, tabName);

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        

        #endregion
    }
}
