using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WaiterPhoneApp.Database.DatabaseContexts;
using WaiterPhoneApp.Models;

namespace WaiterPhoneApp.Database.Entities
{
    public class DepartmentEntity : GenericEntity<Department, OnlineRestaurantDatabaseContext>
    {
        public async Task<List<Department>> SelectAllDepartments()
        {
            using var context = CreateContext();
            return await context.Departments.ToListAsync();
        }
    }
}
