using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WaiterPhoneApp.LocalDbEntities;
using WaiterPhoneApp.Models;

namespace WaiterPhoneApp.Helpers
{
    public class GenericToEntityMapper<T> where T : BaseModel
    {
        public async Task<BaseModel> Map(SqlDataReader reader)
        {
            if (typeof(T) == typeof(Department))
            {
                return MapToDepartment(reader);
            }    
            else if (typeof(T) == typeof(Role))
            {
                return MapToRole(reader);
            }
            else if (typeof(T) == typeof(Group))
            {
                return await MapToGroup(reader);
            }
            else if (typeof(T) == typeof(Subgroup))
            {
                return await MapToSubgroup(reader);
            }
            else if (typeof(T) == typeof(User))
            {
                return await MapToUser(reader);
            }
            else if (typeof(T) == typeof(Product))
            {
                return await MapToProduct(reader);
            }

            throw new NotImplementedException("The type you are trying to map is not supported.");
        }

        private Department MapToDepartment(SqlDataReader reader)
        {
            Department department = new Department();

            department.Id = Int32.Parse(reader["Id"].ToString());
            department.Name = reader["Name"].ToString();

            return department;
        }

        private Role MapToRole(SqlDataReader reader)
        {
            Role role = new Role()
            {
                Id = Int32.Parse(reader["Id"].ToString()),
                Name = reader["Name"].ToString()
            };

            return role;
        }

        private async Task<Group> MapToGroup(SqlDataReader reader)
        {
            Group group = new Group()
            {
                Id = Int32.Parse(reader["Id"].ToString()),
                Name = reader["Name"].ToString(),
                DepartmentId = Int32.Parse(reader["DepartmentId"].ToString()),
            };

            group.Department = await new LocalGenericEntity<Department, RestaurantDatabaseContext>().SelectByIdAsync(group.DepartmentId);

            return group;
        }

        private async Task<Subgroup> MapToSubgroup(SqlDataReader reader)
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
        }

        private async Task<User> MapToUser(SqlDataReader reader)
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
        }

        private async Task<Product> MapToProduct(SqlDataReader reader)
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
        }
    }
}
