using RealWareExcelTools.Core.Settings;

namespace RealWareExcelTools.WinCore.Views.Settings
{
    public interface ISettingsView
    {
        string OnSaveErrorMessage { get; }

        void OnLoadSettings(AddinSettings settings);

        bool OnSaveSettings(ref AddinSettings settings);
    }
}
