using Microsoft.Office.Core;
using RealWare.Core.API;
using RealWare.Core.API.Connection;
using RealWareExcelTools.Controller;
using RealWareExcelTools.Core.Modules;
using RealWareExcelTools.Core.Settings;
using System.Windows.Forms;

namespace RealWareExcelTools
{
    public partial class ThisAddIn
    {
        public RealWareApiConnection RealWareApiConnection { get; private set; }
        public ExcelController ExcelController { get; private set; }
        public AddinSettings Settings { get; private set; }

        private IRealWareExcelModule[] modules;

        internal void SaveSettings()
        {
            AddinSettingsIO.WriteSettingsToFile(Settings);

            // Refresh all modules
            foreach (var module in modules)
                module.OnRefreshSettings(Settings);
        }

        internal void SaveSettings(AddinSettings addinSettings)
        {
            this.Settings = addinSettings;
            SaveSettings();
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            ExcelController = new ExcelController(this);

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
        {
            //Settings must load before the ribbon is created
            Settings = AddinSettingsIO.ReadSettingsFromFile();

            // Return the RealWare ribbon
            return new Ribbon.RealWareRibbon(this);
        }

        public Microsoft.Office.Tools.CustomTaskPane CreateTab(string tabName, UserControl tabControl)
            => this.CustomTaskPanes.Add(tabControl, tabName);

        public void SetRealWareApiConnection(RealWareApiConnection realWareApiConnection)
            => this.RealWareApiConnection = realWareApiConnection;

        public RealWareApi GetRealWareApi()
            => new RealWareApi(RealWareApiConnection);

        public bool HasModule<T>()
        {
            foreach(var module in modules)
                if(module is T)
                    return true;
            return false;
        }

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
