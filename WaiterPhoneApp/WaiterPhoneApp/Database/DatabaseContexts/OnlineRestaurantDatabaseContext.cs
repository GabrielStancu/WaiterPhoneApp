using Microsoft.EntityFrameworkCore;
using WaiterPhoneApp.Models;

namespace WaiterPhoneApp.Database.DatabaseContexts
{
    public class OnlineRestaurantDatabaseContext : BaseContext
    {
        public DbSet<Product> Products { get; private set; }
        public DbSet<Group> Groups { get; private set; }
        public DbSet<Subgroup> Subgroups { get; private set; }
        public DbSet<Department> Departments { get; private set; }
        public DbSet<RestaurantUser> RestaurantUsers { get; private set; }
        public DbSet<Role> Roles { get; private set; }

        private static string _connectionString = "";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public static void SetConnectionString(string connectionString)
        {
            if (_connectionString.Equals(string.Empty))
            {
                _connectionString = connectionString;
            }
        }
    }
}
