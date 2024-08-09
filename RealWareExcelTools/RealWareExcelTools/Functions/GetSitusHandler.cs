using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealWareExcelTools.Functions
{
    internal class GetSitusHandler
    {
        private readonly string _accountNo;

        public GetSitusHandler(string accountNo)
        {
            _accountNo = accountNo;
        }

        public string GetResult()
        {
    //        try
    //        {
    //                string url = "http://aspa0201/Production/EncompassAPI/";
    //#if DEBUG
    //                url = "http://aspa0201/Test/EncompassAPI/";
    //#endif

    //                var filePath = LoginToRealWareHelper.GetCredentialsFilePath();
    //                var credentials = LoginToRealWareHelper.GetApiCredentialsFromFile(filePath);
    //                var userName = credentials.UserName;
    //                var connection = new RealWareApiConnection(url, credentials.Token);
    //                var api = new RealWareApi(connection);
    //                var result = api.GetRealAccount(account, DateTime.Now.Year.ToString());
    //                return result.Account.PropertyAddresses.FirstOrDefault()?.ToString();
    //            }
    //            catch (Exception ex)
    //            {
    //                return $"ERR:{ex.Message}";
    //            }
    //        }


            return "TODO: " + _accountNo + " - Situs";
        }
    }
}
