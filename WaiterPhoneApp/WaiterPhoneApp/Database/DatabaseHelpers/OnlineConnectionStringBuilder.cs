using System.Data.SqlClient;

namespace WaiterPhoneApp.Database.DatabaseHelpers
{
    public class OnlineConnectionStringBuilder
    {
        public string Build(string server, string database, string user, string password)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = server ?? string.Empty,
                InitialCatalog = database ?? string.Empty,
                UserID = user ?? string.Empty,
                Password = password ?? string.Empty
            };

            return builder.ConnectionString;
        }
    }
}
