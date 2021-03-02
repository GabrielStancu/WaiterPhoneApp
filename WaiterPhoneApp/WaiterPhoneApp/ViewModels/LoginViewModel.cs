using System;

namespace WaiterPhoneApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username;
        public string Username 
        { 
            get => _username; 
            set 
            {
                _username = value;
                SetProperty<string>(ref _username, value);
            }
        }
        private string _userDepartment;
        public string UserDepartment 
        {
            get => _userDepartment; 
            set
            {
                _userDepartment = value;
                SetProperty<string>(ref _userDepartment, value);
            }
        }
        private string _currentDate;
        public string CurrentDate 
        {
            get => _currentDate; 
            set
            {
                _currentDate = value;
                SetProperty<string>(ref _currentDate, value);
            }
        }
        private bool _storedUser;
        public bool StoredUser 
        { 
            get => _storedUser; 
            set
            {
                _storedUser = value;
                SetProperty<bool>(ref _storedUser, value);
            }
        }

        public LoginViewModel(string username, string department, bool storedUser)
        {
            Username = username;
            UserDepartment = department;
            CurrentDate = DateTime.Today.ToString("dd.MM.yyyy");
            StoredUser = storedUser;
        }
    }
}
