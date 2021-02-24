using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WaiterPhoneApp.DatabaseContext;
using WaiterPhoneApp.LocalDbEntities;
using WaiterPhoneApp.Models;

namespace WaiterPhoneApp.Mappers
{
    public class GroupMapper : EntityMapper<Group>
    {
        public async new Task<Group> Map(SqlDataReader reader)
        {
            await Task.Run(async () =>
            {
                Group group = new Group()
                {
                    Id = Int32.Parse(reader["Id"].ToString()),
                    Name = reader["Name"].ToString(),
                    DepartmentId = Int32.Parse(reader["DepartmentId"].ToString()),
                };

                group.Department = await new LocalGenericEntity<Department, RestaurantDatabaseContext>().SelectByIdAsync(group.DepartmentId);

                return group;
            });

            return null;
        }
    }
}
