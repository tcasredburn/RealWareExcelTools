using RealWareExcelTools.Core.Providers;
using RealWareExcelTools.WinCore.Views.Batch;
using RealWareExcelTools.WinCore.Views.Batch.Items;

namespace RealWareExcelTools.WinCore.Factory
{
    public class BatchValueScriptFactory
    {
        public static BatchValueScriptContainer Create(string name, bool isApi, IScriptDataProvider dataProvider)
        {
            return new BatchValueScriptContainer(new SinglePathBatch(name, isApi, dataProvider));
        }
    }
}
