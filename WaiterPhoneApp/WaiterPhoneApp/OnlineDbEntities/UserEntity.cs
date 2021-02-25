using System.Data.SqlClient;
using System.Threading.Tasks;
using WaiterPhoneApp.Mappers;
using WaiterPhoneApp.Models;

namespace WaiterPhoneApp.OnlineDbEntities
{
    public class UserEntity : OnlineGenericEntity<User>
    {
        public async Task<User> SelectUserWithLoginInformation(string username, string password)
        {
            using(var sqlConnection = EstablishSqlConnection())
            {
                string cmdText = $"SELECT * FROM Users WHERE username = '{username}' AND password = '{password}'";
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = cmdText,
                    Connection = sqlConnection
                };

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (reader.Read())
                    {
                        EntityMapper<User> mapper = new EntityMapper<User>();
                        User mappedUser = await mapper.Map(reader);

                        return mappedUser;
                    }

                    return null;
                }
            }
        }
    }
}
