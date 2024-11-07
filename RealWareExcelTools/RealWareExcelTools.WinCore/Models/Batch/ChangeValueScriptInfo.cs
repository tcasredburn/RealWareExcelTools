using System.Collections.Generic;

namespace RealWareExcelTools.WinCore.Models.Batch
{
    public class ChangeValueScriptInfo
    {
        public string ScriptName { get; set; }
        public string OptionCategory { get; set; }
        public string OptionName { get; set; }
        /// <summary>
        /// Signifies that an API call is not provided for the specific lookup.
        /// </summary>
        public bool IsDatabaseOnly { get; set; }
    }

    public static class ChangeValueScriptInfoList
    {

        public static List<ChangeValueScriptInfo> GetAccountScriptList()
        {
            return new List<ChangeValueScriptInfo>()
            {
                new ChangeValueScriptInfo
                {
                    ScriptName = "Land Economic Area",
                    OptionCategory = "RealAccount",
                    OptionName = "LEA"
                },
                new ChangeValueScriptInfo
                {
                    ScriptName = "Neighborhood",
                    OptionCategory = "TblAcctNbhd",
                    OptionName = "NbhdCode",
                    IsDatabaseOnly = true
                },
                new ChangeValueScriptInfo
                {
                    ScriptName = "Economic Area",
                    OptionCategory = "TlkpEconomicArea",
                    OptionName = "EconomicAreaCode",
                    IsDatabaseOnly = true
                },
                new ChangeValueScriptInfo
                {
                    ScriptName = "Visual Inspection Area",
                    OptionCategory = "TlkpValueArea",
                    OptionName = "ValueAreaCode",
                    IsDatabaseOnly = true
                },
            };
        }

        public static List<ChangeValueScriptInfo> GetImprovementScriptList() 
        {
            return new List<ChangeValueScriptInfo>
            {
                // Improvements
                new ChangeValueScriptInfo
                {
                    ScriptName = "Quality",
                    OptionCategory = "Improvements",
                    OptionName = "ImpsQuality"
                },
                new ChangeValueScriptInfo
                {
                    ScriptName = "Condition",
                    OptionCategory = "Improvements",
                    OptionName = "ImpConditionType"
                },
                new ChangeValueScriptInfo
                {
                    ScriptName = "Exterior Type",
                    OptionCategory = "TlkpImpsExteriorType",            //TODO
                    OptionName = "ImpExterior",
                    IsDatabaseOnly = true
                },
                new ChangeValueScriptInfo
                {
                    ScriptName = "Roof Type",
                    OptionCategory = "TlkpImpsRoofType",                //TODO
                    OptionName = "ImpConditionType",
                    IsDatabaseOnly = true
                },
                new ChangeValueScriptInfo
                {
                    ScriptName = "Roof Cover",
                    OptionCategory = "TlkpImpsResRoofCoverType",        //TODO
                    OptionName = "RoofCover",
                    IsDatabaseOnly = true
                },
            };
        }

        public static List<ChangeValueScriptInfo> GetSaleScriptList()
        {
            return new List<ChangeValueScriptInfo>()
            {
                new ChangeValueScriptInfo
                {
                    ScriptName = "Exclude Code 1",
                    OptionCategory = "Sales",
                    OptionName = "SaleExclude"
                },
                new ChangeValueScriptInfo
                {
                    ScriptName = "Exclude Code 2",
                    OptionCategory = "Sales",
                    OptionName = "SaleExclude"
                }
            };
        }
    }
}
