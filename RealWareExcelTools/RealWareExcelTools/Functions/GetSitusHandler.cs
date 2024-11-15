using RealWare.Core.Database.Adapters.Table;
using System;
using System.Data.SqlClient;

namespace RealWareExcelTools.Functions
{
    internal class GetSitusHandler : RWHandler
    {
        private readonly string _accountNo;
        private readonly string _taxYear;
        private readonly string _connectionString;

        public GetSitusHandler(string accountNo)
        {
            _accountNo = accountNo;

            if(RWHandler.AddinSettings == null)
                ReadSettingsFromFile();

            _taxYear = AddinSettings?.GeneralSettings?.GetTaxYear();
            _connectionString = AddinSettings?.RealWareDbConnectionSettings?.ConnectionString;
        }

        public string GetResult()
        {
            if(_connectionString == null)
            {
                return "ERR: INVALID SETTINGS";
            }

            try
            {
                var connection = new SqlConnection(_connectionString);
                var adapter = new AcctPropertyAddressAdapter(connection);

                var result = adapter.GetByAccountNo(_accountNo, _taxYear);

                if(result == null)
                {
                    return "ERR: NO DATA";
                }

                return result.GetFormattedAddress();
            }
            catch (Exception ex)
            {
                return $"ERR:{ex.Message}";
            }
        }
    }
}
