using DevExpress.XtraWizard;
using RealWare.Core.API;
using System.Linq;
using System.Threading.Tasks;

namespace RealWareExcelTools.Modules.Batch.Pages
{
    public partial class PreValidationPage : BaseBatchWizardPage, IRealWareBatchWizardPage
    {
        public string PageTitle => "Setup Validation";

        public string PageDescription => "Validates setup to ensure connections and database appear correct.";

        private bool isSetupValid = false;

        public PreValidationPage()
        {
            InitializeComponent();
        }

        public void OnSavePage()
        {

        }

        public async void OnRefreshPage(Direction? direction = null)
        {
            if(direction == Direction.Forward)
            {
                // Validate setup
                await validateAll();
            }
        }

        public override bool OnValidatePage()
        {
            return isSetupValid;
        }

        private async Task validateAll()
        {
            var apiTask = validateApiConnection(progressBarControl1);
            var dbTask = validateDbConnection(progressBarControl2);
            var excelTask = Task.Run(() => validateExcelSheet(progressBarControl3));

            var result = await Task.WhenAll(apiTask, dbTask, excelTask);
            isSetupValid = result.All(x => x); // If all pass, set to true

            RefreshPage();
        }

        private async Task<bool> validateApiConnection(WinCore.Views.Processing.ProgressBarControl control)
        {
            control.SetToLoading("Validating API Connection...");

            var connection = Context.ApiSettings.GetRealWareApiConnection();
            
            var api = new RealWareApi(connection);

            var result = await api.PingAsync();

            if (result != null)
            {
                control.SetToSuccess("API Connection", "Realware API connection is successful.");
                return true;
            }
            else
            {
                control.SetToError("API Connection", "Realware API connection failed.");
                return false;
            }
        }

        private async Task<bool> validateDbConnection(WinCore.Views.Processing.ProgressBarControl control)
        {
            control.SetToLoading("Validating Database Connection...");

            try
            {
                using(var conn = Context.DbSettings.GetRealWareDbConnection())
                {
                    await conn.OpenAsync();
                }
                control.SetToSuccess("Database Connection", "Realware database connection is successful.");
                return true;
            }
            catch
            {
                control.SetToError("Database Connection", "Realware database connection failed.");
                return false;
            }
        }

        private bool validateExcelSheet(WinCore.Views.Processing.ProgressBarControl control)
        {
            control.SetToLoading("Validating Excel Requirements...");

            var sheetName = Context.ExcelController.GetSelectedSheetName();

            if(string.IsNullOrEmpty(sheetName))
            {
                control.SetToError("Excel Sheet", "No sheet selected.");
                return false;
            }

            if(Context.ExcelController.GetSheetColumnNames(sheetName).Count < 1)
            {
                control.SetToError("Excel Sheet", "Sheet must have at least 1 columns.");
                return false;
            }

            control.SetToSuccess("Excel Requirements", 
                "Excel sheet is valid.\r\n" +
                "Excel sheet has atleast 1 column.");
            return true;
        }
    }
}
