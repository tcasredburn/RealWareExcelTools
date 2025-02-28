using RealWare.Core.Database.Adapters.Table;
using System.Data.SqlClient;
using System;
using RealWare.Core.Database.Models.Encompass.Table;

namespace RealWareExcelTools.Functions
{
    internal class GetSchoolDistrictHandler : RWHandler
    {
        private readonly string _accountNo;
        private readonly string _taxYear;
        private readonly string _connectionString;

        private AcctDto lastLoadedAccount;

        public GetSchoolDistrictHandler(string accountNo)
        {
            _accountNo = accountNo;

            if (RWHandler.AddinSettings == null)
                ReadSettingsFromFile();

            _taxYear = AddinSettings?.GeneralSettings?.GetTaxYear();
            _connectionString = AddinSettings?.RealWareDbConnectionSettings?.ConnectionString;
        }

        public string GetResult()
        {
            if (_connectionString == null)
            {
                return "ERR: INVALID SETTINGS";
            }

            try
            {
                if(lastLoadedAccount?.AccountNo == _accountNo)
                {
                    return lastLoadedAccount.DefaultTaxDistrict;
                }

                var connection = new SqlConnection(_connectionString);
                var adapter = new AcctAdapter(connection);

                var result = adapter.GetByAccountNo(_accountNo, _taxYear);
                lastLoadedAccount = result;

                if (result == null)
                {
                    return "ERR: NO DATA";
                }

                return result.DefaultTaxDistrict;
            }
            catch (Exception ex)
            {
                return $"ERR:{ex.Message}";
            }
        }
    }
}
