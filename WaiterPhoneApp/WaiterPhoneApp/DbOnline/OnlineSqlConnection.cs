using System.Data.SqlClient;

namespace WaiterPhoneApp.Helpers
{
    public class OnlineSqlConnection
    {
        private static string _connectionString = string.Empty;
        private SqlConnection connection;

        public SqlConnection GetSqlConnection()
        {
            if (connection == null)
            {
                connection = new SqlConnection
                {
                    ConnectionString = _connectionString
                };
            }
            return connection;
        }

        public static void SetConnectionString(string connectionString) //de apelat o data la inceput de rulare...
        {
            if(_connectionString.Equals(string.Empty))
            {
                _connectionString = connectionString;
            }    
        }
    }
}
