using RealWareExcelTools.Controller;
using RealWareExcelTools.Core.Settings.API;
using RealWareExcelTools.Core.Settings.Plugins;

namespace RealWareExcelTools.Modules.Batch.Models
{
    public class BatchWizardContext
    {
        public readonly BatchConfigurationScript Script;

        public readonly ExcelController ExcelController;
        public readonly RealWareApiConnectionSettings ApiSettings;
        public readonly BatchWizardSettings Settings;

        public BatchWizardContext(ExcelController controller, RealWareApiConnectionSettings apiSettings,
            BatchWizardSettings settings)
        {
            Script = new BatchConfigurationScript();

            ExcelController = controller;
            ApiSettings = apiSettings;
            Settings = settings;
        }
    }
}
