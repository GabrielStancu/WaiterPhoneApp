using System.Collections.ObjectModel;
using System.Linq;
using WaiterPhoneApp.Helpers;
using WaiterPhoneApp.Models;

namespace WaiterPhoneApp.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private string _nickname;
        public string Nickname 
        {
            get => _nickname;
            set
            {
                _nickname = value;
                SetProperty<string>(ref _nickname, value);
            }
        }
        
        public ObservableCollection<Department> Departments { get; set; }
        private Department _crtDepartment;
        public Department CrtDepartment 
        {
            get => _crtDepartment; 
            set
            {
                _crtDepartment = value;
                SetProperty<Department>(ref _crtDepartment, value);
            }
        }
        private string _serverName;
        public string ServerName 
        {
            get => _serverName; 
            set
            {
                _serverName = value;
                SetProperty<string>(ref _serverName, value);
            }
        }
        private string _databaseName;
        public string DatabaseName 
        {
            get => _databaseName; 
            set
            {
                _databaseName = value;
                SetProperty<string>(ref _databaseName, value);
            }
        }
        private string _dbUser;
        public string DbUser 
        {
            get => _dbUser; 
            set
            {
                _dbUser = value;
                SetProperty<string>(ref _dbUser, value);
            }
        }
        private string _dbPassword;
        public string DbPassword 
        { 
            get => _dbPassword;
            set
            {
                _dbPassword = value;
                SetProperty<string>(ref _dbPassword, value);
            } 
        }
        private bool _loadAtStartup;
        public bool LoadAtStartup 
        {
            get => _loadAtStartup; 
            set
            {
                _loadAtStartup = value;
                SetProperty<bool>(ref _loadAtStartup, value);
            }
        }

        public SettingsViewModel()
        {
            LoadDepartments();
            LoadSavedParameters();        
        }

        private void LoadSavedParameters()
        {
            SettingsPageParametersLoader loader = new SettingsPageParametersLoader();
            Nickname = loader.Nickname.Value;
            CrtDepartment = SelectCurrentDepartment(loader);
            ServerName = loader.ServerName.Value;
            DatabaseName = loader.DatabaseName.Value;
            DbUser = loader.DbUser.Value;
            DbPassword = loader.DbPassword.Value;

            string loadAtStartup = loader.LoadAtStartup.Value;
            LoadAtStartup = bool.Parse(loadAtStartup.Equals(string.Empty) ? false.ToString() : loadAtStartup);
        }

        private void LoadDepartments()
        {
            //TODO: de luat din baza de date 
            Departments = new ObservableCollection<Department>()
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

            if(departmentName.Equals(string.Empty))
            {
                return null;
            }

            return Departments.Where(d => d.Name.Equals(departmentName)).First();
        }
    }
}
