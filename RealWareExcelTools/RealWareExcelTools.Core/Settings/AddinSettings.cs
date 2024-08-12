using RealWareExcelTools.Core.Settings.API;
using System;

namespace RealWareExcelTools.Core.Settings
{
    /// <summary>
    /// Contains all configuration settings for the excel addin.
    /// </summary>
    public class AddinSettings
    {
        public RealWareApiConnectionSettings RealWareApiConnectionSettings { get; set; } = new RealWareApiConnectionSettings();
    }
}
