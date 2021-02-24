using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WaiterPhoneApp.Models;

namespace WaiterPhoneApp.Mappers
{
    public class RoleMapper : EntityMapper<Role>
    {
        public async new Task<Role> Map(SqlDataReader reader)
        {
            await Task.Run(() =>
            {
                Role role = new Role()
                {
                    Id = Int32.Parse(reader["Id"].ToString()),
                    Name = reader["Name"].ToString()
                };

                return role;
            });

            return null;
        }
    }
}
