using DevExpress.Data.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.Services;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraWizard;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RealWareExcelTools.Core;
using RealWareExcelTools.Core.Modules.RealWareApiAssistant;
using RealWareExcelTools.Modules.Batch.Controller;
using System;
using System.IO;

namespace RealWareExcelTools.Modules.Batch.Pages
{
    /// <summary>
    /// This script is used to validate and create the RealWareApiAssistant script.
    /// </summary>
    public partial class CreateScriptPage : BaseBatchWizardPage, IRealWareBatchWizardPage, ILogger
    {
        public string PageTitle => "Generate Script";

        public string PageDescription => "View and evaluate RealWare Api Assistant script.";

        string tempFilePath;
        FileSystemWatcher fileWatcher;
        IOverlaySplashScreenHandle generateScriptHandle;

        public CreateScriptPage()
        {
            InitializeComponent();

            errorStatusStrip.Visible = false;

            txtScriptLog.ReplaceService<ISyntaxHighlightService>(new Services.CustomSyntaxHighlightService(txtScriptLog.Document));
            txtScriptLog.Document.DefaultCharacterProperties.FontName = "Courier New";

            clearConsole();
        }

        public void OnRefreshPage(Direction? direction = null)
        {
            if (direction == Direction.Forward)
            {
                errorStatusStrip.Visible = false;
                tempFilePath = null;
                cleanupWatcher();

                generateRealWareApiAssistantScript();
            }
        }

        private void generateRealWareApiAssistantScript()
        {
            generateScriptHandle = WinCore.Helpers.Progress.CreateProgressPanel(txtScriptLog);

            clearConsole();

            BatchRealWareScriptGenerator controller = 
                new BatchRealWareScriptGenerator(Context.ApiSettings.GetRealWareApiConnection(), this);

            var script = controller.GenerateScript(Context.Script, Context.BatchScriptDirectory);

            SetScript(script);

            StopLoading();

            RefreshPage();
        }

        /// <summary>
        /// Stops the loading of the txtScriptLog.
        /// </summary>
        public void StopLoading()
        {
            WinCore.Helpers.Progress.CloseProgressPanel(generateScriptHandle);
            generateScriptHandle = null;
        }

        public void SetScript(ApiScript apiScript)
        {
            errorStatusStrip.Visible = false;
            try
            {
                txtScriptLog.Text = Newtonsoft.Json.JsonConvert.SerializeObject(apiScript, Newtonsoft.Json.Formatting.Indented);
            }
            catch
            {
                errorStatusStrip.Visible = true;
            }
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

            // Cleanup
            cleanupWatcher();
        }

        private void btnEditScript_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            if (tempFilePath == null)
            {
                tempFilePath = System.IO.Path.GetTempFileName() + ".json";

                // Create the script file
                try
                {
                    System.IO.File.WriteAllText(tempFilePath, txtScriptLog.Text);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"Error creating script: {ex.Message}", "Error",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    return;
                }
            }

            // Open the script file
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = tempFilePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error opening script: {ex.Message}", "Error",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            // Cancel if already watching file
            if (fileWatcher != null)
                return;

            // Create file watcher and start monitoring
            fileWatcher = new FileSystemWatcher
            {
                Path = System.IO.Path.GetDirectoryName(tempFilePath),
                Filter = System.IO.Path.GetFileName(tempFilePath),
                NotifyFilter = NotifyFilters.LastWrite
            };

            fileWatcher.Changed += (s, ev) =>
            {
                if (ev.ChangeType == WatcherChangeTypes.Changed)
                {
                    txtScriptLog.Invoke(new Action(() =>
                    {
                        updateScriptFromTempFile(tempFilePath);
                    }));
                }
            };

            fileWatcher.EnableRaisingEvents = true;
        }

        private void updateScriptFromTempFile(string tempFilePath)
        {
            errorStatusStrip.Visible = false;
            try
            {
                txtScriptLog.Text = System.IO.File.ReadAllText(tempFilePath);
            }
            catch
            {
                return;
            }

            if(!isJsonValid(txtScriptLog.Text))
                errorStatusStrip.Visible = true;
        }

        private bool isJsonValid(string jsonString)
        {
            try
            {
                JObject.Parse(jsonString);
                return true;
            }
            catch (JsonReaderException)
            {
                return false;
            }
        }

        private void cleanupWatcher()
        {
            if (fileWatcher == null)
                return;

            fileWatcher.EnableRaisingEvents = false;
            fileWatcher.Dispose();
            fileWatcher = null;
        }
    }
}
