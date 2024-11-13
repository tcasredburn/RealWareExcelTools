using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.Services;
using DevExpress.XtraWizard;
using RealWareExcelTools.Core;
using RealWareExcelTools.Core.Modules.RealWareApiAssistant;
using RealWareExcelTools.Modules.Batch.Controller;
using System;

namespace RealWareExcelTools.Modules.Batch.Pages
{
    /// <summary>
    /// This script is used to validate and create the RealWareApiAssistant script.
    /// </summary>
    public partial class ProcessingScriptPage : BaseBatchWizardPage, IRealWareBatchWizardPage, ILogger
    {
        public string PageTitle => "Processing";

        public string PageDescription => "View process and logging for the script.";

        public ProcessingScriptPage()
        {
            InitializeComponent();

            txtScriptLog.ReplaceService<ISyntaxHighlightService>(new Services.CustomSyntaxHighlightService(txtScriptLog.Document));
            txtScriptLog.Document.DefaultCharacterProperties.FontName = "Courier New";

            clearConsole();
        }

        public void OnRefreshPage(Direction? direction = null)
        {
            if(direction == Direction.Forward)
            {
                generateRealWareApiAssistantScript();
            }
        }

        private void generateRealWareApiAssistantScript()
        {
            clearConsole();

            BatchRealWareScriptGenerator controller = 
                new BatchRealWareScriptGenerator(Context.ApiSettings.GetRealWareApiConnection(), this);

            var script = controller.GenerateScript(Context.Script, Context.BatchScriptDirectory);

            SetScript(script);
        }

        public void SetScript(ApiScript apiScript)
        {
            txtScriptLog.Text = Newtonsoft.Json.JsonConvert.SerializeObject(apiScript, Newtonsoft.Json.Formatting.Indented);
        }

        public void LogInfo(string message)
            => writeLine(message);

        public void LogError(string message, Exception exception = null)
            => writeLine($"[ERROR] {message}");

        private void writeLine(string message)
        {
            txtScriptLog.Text += message + Environment.NewLine;
            txtScriptLog.Document.CaretPosition = txtScriptLog.Document.Range.End;
            txtScriptLog.ScrollToCaret();
        }

        private void clearConsole()
        {
            txtScriptLog.Text = string.Empty;
        }

        public void OnSavePage() 
        { 
            // Save the script to a file
            if(String.IsNullOrWhiteSpace(Context.Script.ScriptName))
            {
                Context.Script.ScriptName = $"script_{Context.Script.Module}_{Context.Script.Action}.json";
            }
            
            // Script
            try
            {
                string fullPath = Context.BatchScriptDirectory + "\\" + Context.Script.ScriptName;
                System.IO.File.WriteAllText(fullPath, txtScriptLog.Text);
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Error saving script: {ex.Message}", "Error", 
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
    }
}
