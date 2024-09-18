using RealWareExcelTools.Core.Settings.API;
using RealWareExcelTools.Core.Settings.General;
using System;

namespace RealWareExcelTools.Core.Settings
{
    /// <summary>
    /// Contains all configuration settings for the excel addin.
    /// </summary>
    public class AddinSettings
    {
        public GeneralSettings GeneralSettings { get; set; } = new GeneralSettings();
        public RealWareApiConnectionSettings RealWareApiConnectionSettings { get; set; } = new RealWareApiConnectionSettings();
    }
}
