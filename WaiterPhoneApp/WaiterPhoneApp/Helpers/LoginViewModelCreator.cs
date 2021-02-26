using WaiterPhoneApp.ViewModels;

namespace WaiterPhoneApp.Helpers
{
    public class LoginViewModelCreator
    {
        public LoginViewModel CreateLoginViewModel()
        {
            var loader = new LoginPageParametersLoader();
            loader.LoadParameters();

            string user = loader.Username.Value;
            string department = loader.Department.Value;
            string isUserStored = loader.StoredUser.Value;

            if (isUserStored is null)
            {
                new ParametersLoader().SetParameter(ParameterValue.RememberUser, false.ToString());
                loader.StoredUser.Value = false.ToString();
            }
            bool storedUser = bool.Parse(loader.StoredUser.Value);
            string connectionString = new OnlineConnectionStringBuilder()
                    .Build(loader.ServerName.Value, loader.DatabaseName.Value, loader.DbUser.Value, loader.DbPassword.Value);

            if (user != null && department != null && !connectionString.Equals(string.Empty))
            {
                //if user is stored, retrieve password as well and store it in viewmodel
                OnlineSqlConnection.SetConnectionString(connectionString);
                return new LoginViewModel(user, department, storedUser);
            }

            return null;
        }
    }
}
