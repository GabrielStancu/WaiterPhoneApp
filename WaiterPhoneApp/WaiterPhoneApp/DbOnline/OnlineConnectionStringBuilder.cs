using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace WaiterPhoneApp.Helpers
{
    public class OnlineConnectionStringBuilder
    {
        public string Build(string server, string database, string user, string password)
        {
            if (server == null || database == null || user == null || password == null)
            {
                return string.Empty;
            }

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                InitialCatalog = server,
                DataSource = database,
                UserID = user,
                Password = password
            };

            return builder.ConnectionString;
        }
    }
}
