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

        private IOverlaySplashScreenHandle generateScriptHandle;

        private string tempFilePath;
        private FileSystemWatcher fileWatcher;
        private System.Windows.Forms.Timer fileChangeDebounceTimer;

        private const int FILE_CHANGE_DEBOUNCE_MS = 300;
        private const int FILE_READ_MAX_RETRIES = 8;
        private const int FILE_READ_RETRY_DELAY_MS = 75;

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
            ensureTempFileExistsAndIsCurrent();
            openTempFileInEditor();
            ensureWatcherStarted();
        }

        private void ensureTempFileExistsAndIsCurrent()
        {
            if (!string.IsNullOrWhiteSpace(tempFilePath) && File.Exists(tempFilePath))
                return;

            tempFilePath = Path.Combine(
                Path.GetTempPath(),
                $"RealWareApiAssistant_{Guid.NewGuid():N}.json"
            );

            try
            {
                File.WriteAllText(tempFilePath, txtScriptLog.Text);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error creating script: {ex.Message}", "Error",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                tempFilePath = null;
                return;
            }
        }

        private void openTempFileInEditor()
        {
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
        }

        private void ensureWatcherStarted()
        {
            if (fileWatcher != null)
                return;

            var dir = Path.GetDirectoryName(tempFilePath);
            var name = Path.GetFileName(tempFilePath);

            fileChangeDebounceTimer = new System.Windows.Forms.Timer();
            fileChangeDebounceTimer.Interval = FILE_CHANGE_DEBOUNCE_MS;
            fileChangeDebounceTimer.Tick += (s, e) =>
            {
                fileChangeDebounceTimer.Stop();
                beginUpdateScriptFromTempFile();
            };

            fileWatcher = new FileSystemWatcher
            {
                Path = dir,
                Filter = "*.*", // watch directory; we’ll filter in code
                IncludeSubdirectories = false,
                NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.Size
            };

            FileSystemEventHandler onAny = (s, ev) =>
            {
                if (!isTempFileEvent(ev.FullPath, name))
                    return;

                restartDebounce();
            };

            RenamedEventHandler onRenamed = (s, ev) =>
            {
                // VS Code often writes temp + rename/replace
                if (isTempFileEvent(ev.FullPath, name) || isTempFileEvent(ev.OldFullPath, name))
                    restartDebounce();
            };

            fileWatcher.Changed += onAny;
            fileWatcher.Created += onAny;
            fileWatcher.Deleted += onAny;
            fileWatcher.Renamed += onRenamed;

            fileWatcher.EnableRaisingEvents = true;
        }

        private bool isTempFileEvent(string fullPath, string tempFileName)
        {
            if (string.IsNullOrWhiteSpace(fullPath))
                return false;

            var fileName = Path.GetFileName(fullPath);
            return string.Equals(fileName, tempFileName, StringComparison.OrdinalIgnoreCase);
        }

        private void restartDebounce()
        {
            if (fileChangeDebounceTimer == null)
                return;

            fileChangeDebounceTimer.Stop();
            fileChangeDebounceTimer.Start();
        }

        private void beginUpdateScriptFromTempFile()
        {
            if (string.IsNullOrWhiteSpace(tempFilePath))
                return;

            // Always marshal to UI thread (watcher runs on background thread)
            if (txtScriptLog.InvokeRequired)
            {
                txtScriptLog.BeginInvoke(new Action(beginUpdateScriptFromTempFile));
                return;
            }

            var text = tryReadAllTextStable(tempFilePath);
            if (text == null)
                return;

            txtScriptLog.Text = text;

            errorStatusStrip.Visible = !isJsonValid(txtScriptLog.Text);
        }

        private string tryReadAllTextStable(string path)
        {
            for (int attempt = 0; attempt < FILE_READ_MAX_RETRIES; attempt++)
            {
                try
                {
                    if (!File.Exists(path))
                    {
                        System.Threading.Thread.Sleep(FILE_READ_RETRY_DELAY_MS);
                        continue;
                    }

                    // “Stable” heuristic: read only when size/mtime stop changing
                    var fi1 = new FileInfo(path);
                    var size1 = fi1.Length;
                    var time1 = fi1.LastWriteTimeUtc;

                    var text = File.ReadAllText(path);

                    var fi2 = new FileInfo(path);
                    var size2 = fi2.Length;
                    var time2 = fi2.LastWriteTimeUtc;

                    if (size1 == size2 && time1 == time2)
                        return text;

                    System.Threading.Thread.Sleep(FILE_READ_RETRY_DELAY_MS);
                }
                catch (IOException)
                {
                    System.Threading.Thread.Sleep(FILE_READ_RETRY_DELAY_MS);
                }
                catch (UnauthorizedAccessException)
                {
                    System.Threading.Thread.Sleep(FILE_READ_RETRY_DELAY_MS);
                }
                catch
                {
                    return null;
                }
            }

            return null;
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
            if (fileWatcher != null)
            {
                fileWatcher.EnableRaisingEvents = false;
                fileWatcher.Dispose();
                fileWatcher = null;
            }

            if (fileChangeDebounceTimer != null)
            {
                fileChangeDebounceTimer.Stop();
                fileChangeDebounceTimer.Dispose();
                fileChangeDebounceTimer = null;
            }

            if (!string.IsNullOrWhiteSpace(tempFilePath))
            {
                try
                {
                    if (File.Exists(tempFilePath))
                        File.Delete(tempFilePath);
                }
                catch
                {
                    // ignore
                }

                tempFilePath = null;
            }
        }
    }
}
