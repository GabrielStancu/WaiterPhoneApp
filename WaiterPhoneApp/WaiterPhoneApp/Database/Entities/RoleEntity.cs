using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WaiterPhoneApp.Database.DatabaseContexts;
using WaiterPhoneApp.Models;

namespace WaiterPhoneApp.Database.Entities
{
    public class RoleEntity : GenericEntity<Role, OnlineRestaurantDatabaseContext>
    {
        public async Task<List<Role>> SelectAllRoles()
        {
            using var context = CreateContext();
            return await context.Roles.ToListAsync();
        }
    }
}
