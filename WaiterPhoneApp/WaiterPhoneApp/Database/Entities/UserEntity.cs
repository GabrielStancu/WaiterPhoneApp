using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WaiterPhoneApp.Database.DatabaseContexts;
using WaiterPhoneApp.Helpers.Exceptions;
using WaiterPhoneApp.Models;

namespace WaiterPhoneApp.Database.Entities
{
    public class UserEntity : GenericEntity<RestaurantUser, OnlineRestaurantDatabaseContext>
    {
        public async Task<RestaurantUser> SelectUserWithLoginInformation(string username, string password)
        {
            try 
            {
                using var context = CreateContext();
                return await
                    Task.Run(() => context.Set<RestaurantUser>()
                        .Where(u => u.Username.Equals(username, StringComparison.Ordinal) 
                                && u.Password.Equals(password, StringComparison.Ordinal))
                        .Include(u => u.Department)
                        .Include(u => u.Role)
                        .FirstOrDefault() ??
                    throw new WrongUserCredentialsException());
            }
            catch(SqlException)
            {
                throw new BadConnectionStringException();
            }
            
        }
    }
}
