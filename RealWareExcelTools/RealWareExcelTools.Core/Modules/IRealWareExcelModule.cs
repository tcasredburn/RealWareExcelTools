using RealWareExcelTools.Core.Settings;

namespace RealWareExcelTools.Core.Modules
{
    public interface IRealWareExcelModule
    {
        void OnStart();
        void OnStop();
        void OnRefreshSettings(AddinSettings addinSettings);
    }
}
