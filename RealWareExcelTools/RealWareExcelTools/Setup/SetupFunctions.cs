using ExcelDna.Integration;

namespace RealWareExcelTools
{
    public static class SetupFunctions
    {
        // General
        public static string REVERSESTRING(string input) => new Functions.ReverseStringHandler(input).GetResult();

        // RealWare
        public static string RWGETSITUS(string input) => new Functions.GetSitusHandler(input).GetResult();

        [ExcelFunction(Description = "Gets the Default School District from RealWare for the specified account and tax year.")] 
        public static string RWGETSCHOOLDISTRICT(string input) => new Functions.GetSchoolDistrictHandler(input).GetResult();
    }
}
