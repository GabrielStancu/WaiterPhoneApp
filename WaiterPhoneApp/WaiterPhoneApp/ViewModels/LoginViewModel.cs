using System;
using System.Collections.Generic;
using System.Text;

namespace WaiterPhoneApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public string Username { get; set; }
        public string UserDepartment { get; set; }
        public string CurrentDate { get; set; }

        public LoginViewModel(string username, string department)
        {
            Username = username;
            UserDepartment = department;
            CurrentDate = DateTime.Today.ToString("dd.MM.yyyy");
        }
    }
}
