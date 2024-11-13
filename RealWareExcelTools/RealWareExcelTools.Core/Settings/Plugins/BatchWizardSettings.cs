using System.IO;
using System;

namespace RealWareExcelTools.Core.Settings.Plugins
{
    /// <summary>
    /// Settings for the batch wizard.
    /// </summary>
    public class BatchWizardSettings
    {
        /// <summary>
        /// If true, the first informational page on the wizard will be skipped.
        /// </summary>
        public bool SkipFirstPage { get; set; } = false;

        /// <summary>
        /// Base directory for saved wizard scripts for easily loading them back up.
        /// </summary>
        public string ScriptsDirectory { get; set; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Scripts");

        /// <summary>
        /// Path to the RealWare API Assistant executable.
        /// </summary>
        public string RealWareApiAssistantExePath { get; set; } = "\\\\asprint\\Public\\Apps\\TCA Realware Api Assistant\\RealwareApiAssistant.exe";
    }
}
