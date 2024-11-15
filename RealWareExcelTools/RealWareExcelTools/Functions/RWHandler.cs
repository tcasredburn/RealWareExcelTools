using RealWareExcelTools.Core.Settings;

namespace RealWareExcelTools.Functions
{
    internal class RWHandler
    {
        internal static AddinSettings AddinSettings;

        public void ReadSettingsFromFile()
        {
            AddinSettings = AddinSettingsIO.ReadSettingsFromFile();
        }
    }
}
