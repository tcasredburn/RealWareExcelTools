﻿using RealWareExcelTools.Core.Settings.API;
using RealWareExcelTools.Core.Settings.Database;
using RealWareExcelTools.Core.Settings.General;
using RealWareExcelTools.Core.Settings.Plugins;

namespace RealWareExcelTools.Core.Settings
{
    /// <summary>
    /// Contains all configuration settings for the excel addin.
    /// </summary>
    public class AddinSettings
    {
        public GeneralSettings GeneralSettings { get; set; } = new GeneralSettings();
        public BatchWizardSettings BatchWizardSettings { get; set; } = new BatchWizardSettings();
        public RealWareApiConnectionSettings RealWareApiConnectionSettings { get; set; } = new RealWareApiConnectionSettings();
        public RealWareDbConnectionSettings RealWareDbConnectionSettings { get; set; } = new RealWareDbConnectionSettings();
    }
}
