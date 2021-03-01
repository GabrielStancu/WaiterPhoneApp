using WaiterPhoneApp.ViewModels;

namespace WaiterPhoneApp.Helpers
{
    public class LoginViewModelCreator
    {
        public LoginViewModel CreateLoginViewModel()
        {
            var loader = new LoginPageParametersLoader();

            string userNickname = loader.Nickname.Value;
            string department = loader.Department.Value;
            string isUserStored = loader.RememberUser.Value;

            if (isUserStored is null)
            {
                new ParametersSaver().SetParameter(ParameterValue.RememberUser, false.ToString());
                loader.RememberUser.Value = false.ToString();
            }
            bool storedUser = bool.Parse(loader.RememberUser.Value);
            string connectionString = new OnlineConnectionStringBuilder()
                    .Build(loader.ServerName.Value, loader.DatabaseName.Value, loader.DbUser.Value, loader.DbPassword.Value);

            if (userNickname != null && !userNickname.Equals(string.Empty) && 
                department != null && !department.Equals(string.Empty) &&
                !connectionString.Equals(string.Empty))
            {
                //if user is stored, retrieve password as well and store it in viewmodel
                OnlineSqlConnection.SetConnectionString(connectionString);
                return new LoginViewModel(userNickname, department, storedUser);
            }

            return null;
        }
    }
}
