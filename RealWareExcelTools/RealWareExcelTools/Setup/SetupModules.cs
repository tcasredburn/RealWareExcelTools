using RealWareExcelTools.Core.Modules;
using RealWareExcelTools.Core.Settings;
using RealWareExcelTools.Modules;

namespace RealWareExcelTools
{
    public static class SetupModules
    {
        public static IRealWareExcelModule[] GetModules(ThisAddIn addIn, AddinSettings settings)
        {
            return new IRealWareExcelModule[]
            {
                new AccountSelectionModule(addIn),
            };
        }
    }

    
}
