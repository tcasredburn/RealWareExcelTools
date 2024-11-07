using RealWare.Core.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealWareExcelTools.Core.Providers
{
    public interface IDataProvider
    {
        Dictionary<string, string> GetLookup(string lookupName, bool useCachedValue = true);

        //Task<RWOptionData> GetApiLookupData(string lookupName, string category, bool useCachedValue = true);

        //Task<T> GetDatabaseData<T>(string lookupName, string category, bool useCachedValue = true);
    }
}
