using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WaiterPhoneApp.DatabaseContext;
using WaiterPhoneApp.LocalDbEntities;
using WaiterPhoneApp.Models;

namespace WaiterPhoneApp.Mappers
{
    public class ProductMapper : EntityMapper<Product>
    {
        public async Task<Product> Map(SqlDataReader reader)
        {
            await Task.Run(async () =>
            {
                Product product = new Product()
                {
                    Id = Int32.Parse(reader["Id"].ToString()),
                    Name = reader["Name"].ToString(),
                    DepartmentId = Int32.Parse(reader["DepartmentId"].ToString()),
                    GroupId = Int32.Parse(reader["GroupId"].ToString()),
                    SubgroupId = Int32.Parse(reader["SubgroupId"].ToString()),
                };

                product.Department = await new LocalGenericEntity<Department, RestaurantDatabaseContext>().SelectByIdAsync(product.DepartmentId);
                product.Group = await new LocalGenericEntity<Group, RestaurantDatabaseContext>().SelectByIdAsync(product.GroupId);
                product.Subgroup = await new LocalGenericEntity<Subgroup, RestaurantDatabaseContext>().SelectByIdAsync(product.SubgroupId);

                return product;
            });

            return null;
        }
    }
}
