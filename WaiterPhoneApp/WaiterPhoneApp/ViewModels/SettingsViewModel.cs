using System.Collections.Generic;
using System.Linq;
using WaiterPhoneApp.Helpers;
using WaiterPhoneApp.Models;

namespace WaiterPhoneApp.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public string Nickname { get; set; }
        public List<Department> Departments { get; set; }
        public Department CrtDepartment { get; set; }
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string DbUser { get; set; }
        public string DbPassword { get; set; }
        public bool LoadAtStartup { get; set; }

        public SettingsViewModel()
        {
            LoadDepartments();
            LoadSavedParameters();        
        }

        private void LoadSavedParameters()
        {
            SettingsPageParametersLoader loader = new SettingsPageParametersLoader();
            Nickname = loader.Nickname?.Value;
            CrtDepartment = SelectCurrentDepartment(loader);
            ServerName = loader.ServerName?.Value;
            DatabaseName = loader.DatabaseName?.Value;
            DbUser = loader.DbUser?.Value;
            DbPassword = loader.DbPassword?.Value;

            string loadAtStartup = loader.LoadAtStartup?.Value;
            LoadAtStartup = bool.Parse(loadAtStartup is null ? false.ToString() : loadAtStartup);
        }

        private void LoadDepartments()
        {
            //TODO: de luat din baza de date 
            Departments = new List<Department>()
            {
                new Department()
                {
                    Id = 1, 
                    Name = "Hotel's Restaurant"
                }, 
                new Department()
                {
                    Id = 2, 
                    Name = "Main Restaurant"
                },
                new Department()
                {
                    Id = 3, 
                    Name = "Fast Food Restaurant"
                }
            };
        }

        private Department SelectCurrentDepartment(SettingsPageParametersLoader loader)
        {
            string departmentName = loader.Department?.Value;

            if(departmentName is null)
            {
                return null;
            }

            return Departments.Where(d => d.Name.Equals(departmentName)).First();
        }
    }
}
