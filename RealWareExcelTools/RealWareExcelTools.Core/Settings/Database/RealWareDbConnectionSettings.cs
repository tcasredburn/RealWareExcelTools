using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace RealWareExcelTools.Core.Settings.Database
{
    public class RealWareDbConnectionSettings
    {
        public string ConnectionString { get; set; }

        public SqlConnection GetRealWareDbConnection()
            => new SqlConnection(ConnectionString);
    }
}
