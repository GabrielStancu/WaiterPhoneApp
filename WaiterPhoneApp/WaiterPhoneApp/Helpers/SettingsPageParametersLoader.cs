using System;
using System.Collections.Generic;
using System.Text;

namespace WaiterPhoneApp.Helpers
{
    public class SettingsPageParametersLoader : ParametersLoader
    {
        public AppParameter Nickname { get; private set; }
        public AppParameter Department { get; private set; }
        public AppParameter ServerName { get; private set; }
        public AppParameter DatabaseName { get; private set; }
        public AppParameter DbUser { get; private set; }
        public AppParameter DbPassword { get; private set; }
        public AppParameter LoadAtStartup { get; private set; }

        public SettingsPageParametersLoader()
        {
            LoadParameters();
        }

        private void LoadParameters()
        {
            Nickname =
                new AppParameter(ParameterValue.Nickname.ToString(), GetParameter(ParameterValue.Nickname));
            Department =
                new AppParameter(ParameterValue.CurrentDepartment.ToString(), GetParameter(ParameterValue.CurrentDepartment));
            ServerName =
                new AppParameter(ParameterValue.OnlineDatabaseServer.ToString(), GetParameter(ParameterValue.OnlineDatabaseServer));
            DatabaseName =
                new AppParameter(ParameterValue.OnlineDatabaseDatabase.ToString(), GetParameter(ParameterValue.OnlineDatabaseDatabase));
            DbUser =
                new AppParameter(ParameterValue.OnlineDatabaseUser.ToString(), GetParameter(ParameterValue.OnlineDatabaseUser));
            DbPassword =
                new AppParameter(ParameterValue.OnlineDatabasePassword.ToString(), GetParameter(ParameterValue.OnlineDatabasePassword));
            LoadAtStartup =
                new AppParameter(ParameterValue.LoadFromOnlineDatabase.ToString(), GetParameter(ParameterValue.LoadFromOnlineDatabase));
        }
    }
}
