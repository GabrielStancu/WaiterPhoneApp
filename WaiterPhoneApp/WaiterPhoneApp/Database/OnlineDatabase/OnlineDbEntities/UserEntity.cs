using System.Data.SqlClient;
using System.Threading.Tasks;
using WaiterPhoneApp.Helpers.Exceptions;
using WaiterPhoneApp.Helpers.Mappers;
using WaiterPhoneApp.Models;

namespace WaiterPhoneApp.Database.OnlineDatabase.OnlineDbEntities
{
    public class UserEntity : OnlineGenericEntity<RestaurantUser>
    {
        public async Task<RestaurantUser> SelectUserWithLoginInformation(string username, string password)
        {
            using var sqlConnection = EstablishSqlConnection();
            if (sqlConnection is null)
            {
                throw new BadConnectionStringException();
            }

            string cmdText = $"SELECT * FROM RestaurantUser WHERE username = '{username}' COLLATE SQL_Latin1_General_CP1_CS_AS " +
                $"AND password = '{password}' COLLATE SQL_Latin1_General_CP1_CS_AS";
            SqlCommand cmd = new SqlCommand()
            {
                CommandText = cmdText,
                Connection = sqlConnection
            };

            using var reader = await cmd.ExecuteReaderAsync();
            if (reader.Read())
            {
                var mapper = new UserMapper();
                RestaurantUser mappedUser = await mapper.Map(reader);

                return mappedUser;
            }

            throw new WrongUserCredentialsException();
        }
    }
}
