using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WaiterPhoneApp.DatabaseContext;
using WaiterPhoneApp.LocalDbEntities;
using WaiterPhoneApp.Models;

namespace WaiterPhoneApp.Mappers
{
    public class UserMapper : EntityMapper<User>
    {
        public async Task<User> Map(SqlDataReader reader)
        {
            await Task.Run(async () =>
            {
                User user = new User()
                {
                    Id = Int32.Parse(reader["Id"].ToString()),
                    Username = reader["Username"].ToString(),
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    Password = reader["Password"].ToString(),
                    DepartmentId = Int32.Parse(reader["DepartmentId"].ToString()),
                    RoleId = Int32.Parse(reader["RoleId"].ToString()),
                };

                user.Department = await new LocalGenericEntity<Department, RestaurantDatabaseContext>().SelectByIdAsync(user.DepartmentId);
                user.Role = await new LocalGenericEntity<Role, RestaurantDatabaseContext>().SelectByIdAsync(user.RoleId);

                return user;
            });

            return null;
        }
    }
}
