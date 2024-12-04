using RealWare.Core.API;
using RealWare.Core.API.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RealWareExcelTools.Modules.Batch.Providers
{
    public class RealWareDataProvider : Core.Providers.IDataProvider
    {
        public readonly Dictionary<string, Dictionary<string, string>> LookupCache;

        private readonly RealWareApi _api;
        private readonly IDbConnection _db;
        private readonly string _taxYear;

        public RealWareDataProvider(RealWareApiConnection connectionSettings, string databaseConnectionString, string taxYear)
        {
            LookupCache = new Dictionary<string, Dictionary<string, string>>();

            _api = new RealWareApi(connectionSettings);
            _db = new System.Data.SqlClient.SqlConnection(databaseConnectionString);
            _taxYear = taxYear;
        }

        public Dictionary<string, string> GetLookup(string lookupName, bool useCachedValue = true)
        {
            //TODO: This should allow for any custom data provider, not just Tulsa County
            return getDatabaseLookup(lookupName, useCachedValue);

            //if(isApiLookup)
            //    return getApiLookup(lookupName, useCachedValue);
            //else
            //    return getDatabaseLookup(lookupName, useCachedValue);
        } 

        private Dictionary<string, string> getDatabaseLookup(string lookupName, bool useCachedValue)
        {
            var actualLookupName = getLookupName(false, lookupName);

            if (useCachedValue && TryGetCachedValue(actualLookupName, out var cacheResult))
                return cacheResult;

            var result = new Dictionary<string, string>();
            var adapter = new RealWare.Core.Database.Adapters.LookupAdapter(_db);

            switch (lookupName)
            {
                // Account
                case "Economic Area":
                    result = adapter.EconomicArea.GetAllActive().ToDictionary(x => x.EconomicAreaCode, x => x.EconomicAreaDescription);
                    break;
                case "Land Economic Area":
                    result = adapter.LEAType.GetAllActive().ToDictionary(x => x.LEA, x => x.LEADescription);
                    break;
                case "Neighborhood":
                        result = adapter.NbhdAdjustment.GetAllActive(_taxYear).GroupBy(x=>x.NbhdCode)
                            .ToDictionary(g => g.Key, g => g.First().NbhdDescription);
                    break;
                case "Visual Inspection Area":
                        result = adapter.ValueArea.GetAllActive().ToDictionary(x => x.ValueAreaCode, x => x.ValueAreaDescription);
                    break;

                // Improvements
                case "Condition":
                    result = adapter.ImpsConditionType.GetAllActive(_taxYear).ToDictionary(x => x.ImpConditionType, x => x.ImpConditionType);
                    break;
                case "Exterior Type":
                    result = adapter.ImpsExteriorType.GetAllActive(_taxYear).Select(x=>x.ImpExterior)
                        .Distinct().ToDictionary(x => x, x => x);
                    break;
                case "Quality":
                    result = adapter.ImpsQuality.GetAllActive().ToDictionary(x => x.ImpQuality, x => x.ImpQuality);
                    break;
                case "Roof Type":
                    result = adapter.ImpsRoofType.GetAllActive().ToDictionary(x => x.RoofType, x => x.RoofType);
                    break;
                case "Roof Cover":
                    result = adapter.ImpsResRoofCoverType.GetAllActive().Select(x=>x.RoofCover)
                        .Distinct().ToDictionary(x => x, x => x);
                    break;

                // Sales
                case "Exclude Code 1":
                case "Exclude Code 2":
                    result = adapter.SaleExclude.GetAllActive().ToDictionary(x => x.ExcludeCode, x => x.ExcludeDescription);
                    break;
#if TULSA_COUNTY
                case "OTC Exclude Reason":
#endif
                case "SaleOM1":
                    result = adapter.OptionField.GetAllByFieldName("SaleOM1")
                        .Where(x=>x.IsActive).ToDictionary(x => x.FieldValue, x => x.FieldValue);
                    break;
#if TULSA_COUNTY
                case "Verified Method":
#endif
                case "Confirm Method":
                    result = adapter.SaleConfirmMethod.GetAllActive().ToDictionary(x => x.ConfirmMethod, x => x.ConfirmMethod);
                    break;

                default:
                    throw new Exception($"Lookup '{lookupName}' not found.");
            }
            AddResultToCache(lookupName, result);
            return result;
        }

        private bool TryGetCachedValue(string actualLookupName, out Dictionary<string, string> result)
        {
            if (LookupCache.ContainsKey(actualLookupName))
            {
                result = LookupCache[actualLookupName];
                return true;
            }
            result = new Dictionary<string, string>();
            return false;
        }

        private void AddResultToCache(string actualLookupName, Dictionary<string, string> result)
        {
            if (LookupCache.ContainsKey(actualLookupName))
            {
                LookupCache[actualLookupName] = result;
                return;
            }
            LookupCache.Add(actualLookupName, result);
        }

        private string getLookupName(bool isApi, string name) => getLookupPrefix(isApi) + name;

        private string getLookupPrefix(bool isApi) => (isApi ? "api" : "db") + "_";






        //private async Task<Dictionary<string, string>> getApiLookup(string lookupName, bool useCachedValue)
        //{
        //    var actualLookupName = getLookupName(true, lookupName);

        //    if (useCachedValue && TryGetCachedValue(actualLookupName, out var result))
        //        return result;

        //    // Handle naming conventions for specific lookups
        //    switch (lookupName)
        //    {
        //        case "Quality":
        //            //return new List<string> { "Fair", "Average", "Good", "Excellent" }.ToDictionary(x => x, x => x);
        //            return await GetApiLookupData(OptionDataResourceName.Improvements, "ImpConditionType");
        //    }
        //    return new Dictionary<string, string>();
        //}

        //public async Task<Dictionary<string, string>> GetApiLookupData(OptionDataResourceName resourceName, string lookupName)
        //{
        //    var result = new Dictionary<string, string>();

        //    var optionData = await _api.GetOptionDataAsync(resourceName);

        //    foreach (var option in optionData)
        //    {
        //        var data = option.OptionItems.ToDictionary(x => x.OptionItemKey, x => x.OptionItemKey);

        //        if (option.Key == lookupName)
        //            result = data;

        //        AddResultToCache(option.Key, data);
        //    }

        //    return result;
        //}

        //public Task<T> GetDatabaseData<T>(string lookupName)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
