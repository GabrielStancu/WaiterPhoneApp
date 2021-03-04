using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WaiterPhoneApp.Database.LocalDatabase.DatabaseContext;
using WaiterPhoneApp.LocalDatabase.LocalDbEntities.LocalDbEntities;
using WaiterPhoneApp.Models;

namespace WaiterPhoneApp.Helpers.Mappers
{
    public class UserMapper : EntityMapper<RestaurantUser>
    {
        public override async Task<RestaurantUser> Map(SqlDataReader reader)
        {
            await Task.Run(async () =>
            {
                RestaurantUser user = new RestaurantUser()
                {
                    Id = Int32.Parse(reader["Id"].ToString()),
                    Username = reader["Username"].ToString(),
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    DepartmentId = Int32.Parse(reader["DepartmentId"].ToString()),
                    RoleId = Int32.Parse(reader["RoleId"].ToString()),
                    Nickname = reader["Nickname"].ToString(),
                };

                user.Department = await new LocalGenericEntity<Department, RestaurantDatabaseContext>().SelectByIdAsync(user.DepartmentId);
                user.Role = await new LocalGenericEntity<Role, RestaurantDatabaseContext>().SelectByIdAsync(user.RoleId);

                return user;
            });

            return null;
        }
    }
}
