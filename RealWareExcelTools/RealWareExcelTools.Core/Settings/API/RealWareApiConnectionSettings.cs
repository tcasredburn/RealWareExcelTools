namespace RealWareExcelTools.Core.Settings.API
{
    public class RealWareApiConnectionSettings
    {
        public string Url { get; set; }
        public string RealWareUserName { get; set; }
        public string Token { get; set; }
        public bool ConnectOnExcelStartup { get; set; }
    }
}
