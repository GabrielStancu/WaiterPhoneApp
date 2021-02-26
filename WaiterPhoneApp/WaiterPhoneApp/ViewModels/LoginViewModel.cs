using System;

namespace WaiterPhoneApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public string Username { get; set; }
        public string UserDepartment { get; set; }
        public string CurrentDate { get; set; }
        public bool StoredUser { get; set; }

        public LoginViewModel(string username, string department, bool storedUser)
        {
            Username = username;
            UserDepartment = department;
            CurrentDate = DateTime.Today.ToString("dd.MM.yyyy");
            StoredUser = storedUser;
        }
    }
}
