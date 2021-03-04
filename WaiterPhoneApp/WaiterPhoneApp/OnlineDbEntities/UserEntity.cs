using System.Data.SqlClient;
using System.Threading.Tasks;
using WaiterPhoneApp.Exceptions;
using WaiterPhoneApp.Mappers;
using WaiterPhoneApp.Models;

namespace WaiterPhoneApp.OnlineDbEntities
{
    public class UserEntity : OnlineGenericEntity<User>
    {
        public async Task<User> SelectUserWithLoginInformation(string username, string password)
        {
            using var sqlConnection = EstablishSqlConnection();
            if (sqlConnection is null)
            {
                throw new BadConnectionStringException();
            }

            string cmdText = $"SELECT * FROM Users WHERE username = '{username}' COLLATE SQL_Latin1_General_CP1_CS_AS " +
                $"AND password = '{password}' COLLATE SQL_Latin1_General_CP1_CS_AS";
            SqlCommand cmd = new SqlCommand()
            {
                CommandText = cmdText,
                Connection = sqlConnection
            };

            using var reader = await cmd.ExecuteReaderAsync();
            if (reader.Read())
            {
                EntityMapper<User> mapper = new EntityMapper<User>();
                User mappedUser = await mapper.Map(reader);

                return mappedUser;
            }

            throw new WrongUserCredentialsException();
        }
    }
}
