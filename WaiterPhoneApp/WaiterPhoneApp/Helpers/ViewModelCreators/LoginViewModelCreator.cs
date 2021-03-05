using WaiterPhoneApp.Database.DatabaseContexts;
using WaiterPhoneApp.Database.DatabaseHelpers;
using WaiterPhoneApp.Helpers.ParametersHelpers;
using WaiterPhoneApp.ViewModels;

namespace WaiterPhoneApp.Helpers.ViewModelCreators
{
    public class LoginViewModelCreator
    {
        public LoginViewModel CreateLoginViewModel()
        {
            var loader = new LoginPageParametersLoader();

            string userNickname = loader.Nickname.Value;
            string department = loader.Department.Value;
            string isUserStored = loader.RememberUser.Value;

            if (isUserStored.Equals(string.Empty))
            {
                new ParametersSaver().SetParameter(ParameterValue.RememberUser, false.ToString());
                loader.RememberUser.Value = false.ToString();
            }

            return CheckNecessaryParams(loader, userNickname, department);
        }

        private LoginViewModel CheckNecessaryParams(LoginPageParametersLoader loader, string userNickname, string department)
        {
            bool storedUser = bool.Parse(loader.RememberUser.Value);
            string connectionString = new OnlineConnectionStringBuilder()
                    .Build(loader.ServerName.Value, loader.DatabaseName.Value, loader.DbUser.Value, loader.DbPassword.Value);

            if (!userNickname.Equals(string.Empty) && !department.Equals(string.Empty) &&
                !connectionString.Equals(string.Empty))
            {
                //if user is stored, retrieve password as well and store it in viewmodel
                OnlineRestaurantDatabaseContext.SetConnectionString(connectionString);
                return new LoginViewModel(userNickname, department, storedUser);
            }

            return null;
        }
    }
}
