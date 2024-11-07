namespace RealWareExcelTools.Core.Providers
{
    public interface IScriptDataProvider
    {
        IDataProvider DataProvider { get; }
        IExcelProvider ExcelProvider { get; }
    }
}
