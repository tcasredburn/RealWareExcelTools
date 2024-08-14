using Microsoft.Office.Core;
using RealWareExcelTools.Controller;
using RealWareExcelTools.Core.Modules;
using RealWareExcelTools.Core.Settings;
using System;
using System.Windows.Forms;
using TCA.Framework.RealWare.Api;
using TCA.Framework.RealWare.Api.Model;

namespace RealWareExcelTools
{
    public partial class ThisAddIn
    {
        public RealWareApiConnection RealWareApiConnection { get; private set; }
        public ExcelController ExcelController { get; private set; }
        public AddinSettings Settings { get; private set; }

        private IRealWareExcelModule[] modules;

        internal void SaveSettings(AddinSettings addinSettings)
        {
            this.Settings = addinSettings;

            AddinSettingsIO.WriteSettingsToFile(Settings);

            // Refresh all modules
            foreach (var module in modules)
                module.OnRefreshSettings(addinSettings);
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            ExcelController = new ExcelController(this);

            Settings = AddinSettingsIO.ReadSettingsFromFile();

            modules = SetupModules.GetModules(this, Settings);

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

        public void SetRealWareApiConnection(RealWareApiConnection realWareApiConnection)
            => this.RealWareApiConnection = realWareApiConnection;

        public RealWareApi GetRealWareApi()
            => new RealWareApi(RealWareApiConnection);

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
