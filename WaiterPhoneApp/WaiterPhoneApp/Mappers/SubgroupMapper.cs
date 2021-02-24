using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WaiterPhoneApp.DatabaseContext;
using WaiterPhoneApp.LocalDbEntities;
using WaiterPhoneApp.Models;

namespace WaiterPhoneApp.Mappers
{
    public class SubgroupMapper : EntityMapper<Subgroup>
    {
        public async new Task<Subgroup> Map(SqlDataReader reader)
        {
            await Task.Run(async () =>
            {
                Subgroup subgroup = new Subgroup()
                {
                    Id = Int32.Parse(reader["Id"].ToString()),
                    Name = reader["Name"].ToString(),
                    DepartmentId = Int32.Parse(reader["DepartmentId"].ToString()),
                    GroupId = Int32.Parse(reader["GroupId"].ToString()),
                };

                subgroup.Department = await new LocalGenericEntity<Department, RestaurantDatabaseContext>().SelectByIdAsync(subgroup.DepartmentId);
                subgroup.Group = await new LocalGenericEntity<Group, RestaurantDatabaseContext>().SelectByIdAsync(subgroup.GroupId);

                return subgroup;
            });

            return null;
        }
    }
}
