using System.Collections.Generic;

namespace RealWareExcelTools.Core.Providers
{
    public interface IExcelProvider
    {
        List<string> GetValidColumnNames(List<string> removeList = null);
    }
}
