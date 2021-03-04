using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaiterPhoneApp.Database.LocalDatabase.DatabaseContext;
using WaiterPhoneApp.Models;

namespace WaiterPhoneApp.LocalDatabase.LocalDbEntities.LocalDbEntities
{
    public class LocalGenericEntity<T, U> 
        where T: BaseModel
        where U: RestaurantDatabaseContext
    {
        protected RestaurantDatabaseContext CreateContext()
        {
            RestaurantDatabaseContext restaurantDatabaseContext = (U)Activator.CreateInstance(typeof(U));
            restaurantDatabaseContext.Database.EnsureCreated();
            restaurantDatabaseContext.Database.Migrate();

            return restaurantDatabaseContext;
        }

        public async Task<T> SelectByIdAsync(int id)
        {
            using (var context = CreateContext())
            {
                return await context.Set<T>().FindAsync(id);
            }    
        }

        public async Task<IReadOnlyList<T>> SelectAllAsReadOnlyAsync()
        {
            using (var context = CreateContext())
            {
                return await context.Set<T>().AsNoTracking().ToListAsync();
            }       
        }

        public async Task<List<T>> SelectAllAsReadWriteAsync()
        {
            using (var context = CreateContext())
            {
                return await context.Set<T>().ToListAsync();
            }
        }

        public async Task InsertAsync(T entity)
        {
            using (var context = CreateContext())
            {
                bool newEntity = context.Set<T>().Any(e => e.Equals(entity));

                if (newEntity)
                {
                    await context.Set<T>().AddAsync(entity);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task UpdateAsync(T entity)
        {
            using (var context = CreateContext())
            {
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
            } 
        }

        public async Task DeleteAsync(T entity)
        {
            using (var context = CreateContext())
            {
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
            }     
        }
    }
}
