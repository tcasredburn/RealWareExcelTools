using DevExpress.XtraBars;
using RealWareExcelTools.Controller;
using RealWareExcelTools.Core.Providers;
using RealWareExcelTools.Core.Settings.API;
using RealWareExcelTools.Core.Settings.Database;
using RealWareExcelTools.Core.Settings.Plugins;
using RealWareExcelTools.Modules.Batch.Controller;
using RealWareExcelTools.Modules.Batch.Forms;
using System.IO;

namespace RealWareExcelTools.Modules.Batch.Models
{
    public class BatchWizardContext
    {
        public IBatchWizardController BatchWizardController { get; private set; }
        public IDataProvider DataProvider { get; internal set; }
        public BarManager BarManager { get; private set; }

        public readonly BatchConfigurationScript Script;
        public readonly ScriptFileController File;


        public readonly ExcelController ExcelController;
        public readonly RealWareApiConnectionSettings ApiSettings;
        public readonly RealWareDbConnectionSettings DbSettings;
        public readonly BatchWizardSettings Settings;

        public readonly string BatchScriptDirectory;

        public BatchWizardContext(ExcelController controller, RealWareApiConnectionSettings apiSettings,
            BatchWizardSettings settings, RealWareDbConnectionSettings dbSettings, string excelFileName)
        {
            Script = new BatchConfigurationScript()
            {
                ExcelFilePath = excelFileName
            };
            File = new ScriptFileController(settings.ScriptsDirectory);

            BatchScriptDirectory = Path.GetDirectoryName(excelFileName);

            ExcelController = controller;
            ApiSettings = apiSettings;
            Settings = settings;
            DbSettings = dbSettings;
        }

        public void SetController(BatchWizardForm controller)
        {
            BatchWizardController = controller;

            BarManager = new BarManager();
            BarManager.Form = controller;
        }
    }
}
