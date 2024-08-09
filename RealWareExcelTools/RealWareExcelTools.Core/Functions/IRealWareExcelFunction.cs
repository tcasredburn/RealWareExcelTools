namespace RealWareExcelTools.Core.Functions
{
    /// <summary>
    /// Required interface for creating and interacting with RealWare Excel functions.
    /// </summary>
    public interface IRealWareExcelFunction
    {
        /// <summary>
        /// Returns the result of the function.
        /// </summary>
        /// <returns></returns>
        string GetResult();
    }
}
