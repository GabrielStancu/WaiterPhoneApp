using WaiterPhoneApp.ViewModels;
using Xamarin.Essentials;

namespace WaiterPhoneApp.Helpers
{
    public class ParametersSaver
    {
        public void SaveModelSettings(LoginViewModel model)
        {
            //TODO
        }
        public void SaveModelSettings(SettingsViewModel model)
        {
            SetParameter(ParameterValue.Nickname, model.Nickname);
            SetParameter(ParameterValue.CurrentDepartment, model.CrtDepartment.Name);
            SetParameter(ParameterValue.OnlineDatabaseServer, model.ServerName);
            SetParameter(ParameterValue.OnlineDatabaseDatabase, model.DatabaseName);
            SetParameter(ParameterValue.OnlineDatabaseUser, model.DbUser);
            SetParameter(ParameterValue.OnlineDatabasePassword, model.DbPassword);
            SetParameter(ParameterValue.LoadFromOnlineDatabase, model.LoadAtStartup.ToString());
        }

        public void SetParameter(ParameterValue parameter, string value)
        {
            if (value != null)
            {
                Preferences.Set(parameter.ToString(), value);
            }
        }
    }
}
