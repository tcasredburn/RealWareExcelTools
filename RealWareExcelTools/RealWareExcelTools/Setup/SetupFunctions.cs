namespace RealWareExcelTools
{
    public static class SetupFunctions
    {
        // General
        public static string REVERSESTRING(string input) => new Functions.ReverseStringHandler(input).GetResult();

        // RealWare
        public static string RWGETSITUS(string input) => new Functions.GetSitusHandler(input).GetResult();
    }
}
