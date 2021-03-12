using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaiterPhoneApp.Database.DatabaseContexts;
using WaiterPhoneApp.Models;

namespace WaiterPhoneApp.Database.Entities
{
    public class GenericEntity<T, U>
        where T: BaseModel
        where U: BaseContext
    {
        protected U CreateContext()
        {
            U restaurantDatabaseContext = (U)Activator.CreateInstance(typeof(U));
            restaurantDatabaseContext.Database.EnsureCreated();
            restaurantDatabaseContext.Database.Migrate();

            return restaurantDatabaseContext;
        }

        public async Task<T> SelectByIdAsync(int id)
        {
            using var context = CreateContext();
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> SelectAllAsync()
        {
            using var context = CreateContext();
            return await context.Set<T>().ToListAsync();
        }

        public async Task InsertAsync(T entity)
        {
            using var context = CreateContext();
            bool alreadyStored = context.Set<T>().Any(e => e.Equals(entity));

            if (!alreadyStored)
            {
                await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(T entity)
        {
            using var context = CreateContext();
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            using var context = CreateContext();
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
