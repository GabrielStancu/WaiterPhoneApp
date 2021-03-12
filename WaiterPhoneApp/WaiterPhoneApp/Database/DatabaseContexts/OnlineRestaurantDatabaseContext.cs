using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using WaiterPhoneApp.Models;
using Group = WaiterPhoneApp.Models.Group;

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
            _connectionString = connectionString;
        }

        public static bool IsConnectionStringSet()
        {
            string connectionStringRegex = "Data Source=(.*?);Initial Catalog=(.*?);User ID=(.*?);Password=(.*?)$";
            Match match = Regex.Match(_connectionString, connectionStringRegex);
            string server = match.Groups[1].Value;
            string database = match.Groups[2].Value;
            string user = match.Groups[3].Value;
            string password = match.Groups[4].Value;

            if (server.Equals(string.Empty) || database.Equals(string.Empty) ||
                user.Equals(string.Empty) || password.Equals(string.Empty))
            {
                return false;
            }

            return true;
        }
    }
}
