using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using WaiterPhoneApp.Models;
using Xamarin.Forms;

namespace WaiterPhoneApp.Database.DatabaseContexts
{
    public class LocalRestaurantDatabaseContext : BaseContext
    {
        public DbSet<Product> Products { get; private set; }
        public DbSet<Group> Groups { get; private set; }
        public DbSet<Subgroup> Subgroups { get; private set; }
        public DbSet<Department> Departments { get; private set; }
        public DbSet<RestaurantUser> Users { get; private set; }
        public DbSet<Role> Roles { get; private set; }

        private const string _databaseName = "restaurant.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databasePath = string.Empty;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    SQLitePCL.Batteries_V2.Init();
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", _databaseName);
                    break;
                case Device.Android:
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), _databaseName);
                    break;
                default:
                    throw new NotImplementedException("Platform not supported.");
            }

            optionsBuilder.UseSqlite($"Filename={databasePath}");
        }
    }
}
