using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WaiterPhoneApp.Database.Entities;
using WaiterPhoneApp.Helpers.Exceptions;
using WaiterPhoneApp.Models;

namespace WaiterPhoneApp.ViewModels
{
    public class SignupViewModel : BaseViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public string RepeatedPassword { get; set; }
        public Department CurrentDepartment { get; set; }
        public ObservableCollection<Department> Departments {get; set;}
        public List<Role> Roles { get; set; }
        
        public SignupViewModel()
        {
            Departments = new ObservableCollection<Department>();
            LoadDepartments();
            LoadRoles();
        }

        public async Task<bool> RegisterUser()
        {
            if (!AllFieldsCompleted())
            {
                return false;
            }

            var userEntity = new UserEntity();
            bool userAlreadyRegistered = await userEntity.CheckAlreadyRegisteredUser(Username);
            if(userAlreadyRegistered)
            {
                throw new UserAlreadyRegisteredException();
            }

            var user = new RestaurantUser()
            {
                FirstName = FirstName,
                LastName = LastName,
                Username = Username,
                Nickname = Nickname,
                Password = Password,
                DepartmentId = CurrentDepartment.Id,
                RoleId = Roles[Roles.Count - 1].Id
            };

            await userEntity.RegisterUser(user);

            return true;
        }

        private async void LoadDepartments()
        {
            try
            {
                var dbDepartments = await new DepartmentEntity().SelectAllDepartments();
                dbDepartments.ForEach(d => Departments.Add(d));
            }
            catch (SqlException)
            {
                //throw new BadConnectionStringException();
            }
        }

        private async void LoadRoles()
        {
            try
            {
                Roles = await new RoleEntity().SelectAllRoles();
            }
            catch (SqlException)
            {
                //throw new BadConnectionStringException();
            }
        }

        public bool AllFieldsCompleted()
        {
            if (IsNotCompletedField(FirstName) || IsNotCompletedField(LastName) ||
                IsNotCompletedField(Username) || IsNotCompletedField(Nickname) ||
                IsNotCompletedField(Password) || IsNotCompletedField(RepeatedPassword) ||
                CurrentDepartment is null)
            {
                return false;
            }

            return true;
        }

        private bool IsNotCompletedField(string field)
        {
            if (field is null)
            {
                return true;
            }

            return field.Equals(string.Empty);
        }
    }
}
