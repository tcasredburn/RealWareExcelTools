using RealWareExcelTools.Controller;
using RealWareExcelTools.Core.Settings.API;
using RealWareExcelTools.Core.Settings.Plugins;
using RealWareExcelTools.Modules.Batch.Controller;

namespace RealWareExcelTools.Modules.Batch.Models
{
    public class BatchWizardContext
    {
        public readonly BatchConfigurationScript Script;
        public readonly ScriptFileController File;


        public readonly ExcelController ExcelController;
        public readonly RealWareApiConnectionSettings ApiSettings;
        public readonly BatchWizardSettings Settings;

        public BatchWizardContext(ExcelController controller, RealWareApiConnectionSettings apiSettings,
            BatchWizardSettings settings)
        {
            Script = new BatchConfigurationScript();
            File = new ScriptFileController(settings.ScriptsDirectory);

            ExcelController = controller;
            ApiSettings = apiSettings;
            Settings = settings;
        }
    }
}
