using System.Data.SqlClient;

namespace WaiterPhoneApp.Database.OnlineDatabase.DbOnline
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
                DataSource = server,
                InitialCatalog = database,
                UserID = user,
                Password = password
            };

            return builder.ConnectionString;
        }
    }
}
