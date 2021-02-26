namespace WaiterPhoneApp.Helpers
{
    public class LoginPageParametersLoader : ParametersLoader
    {
        public AppParameter Username { get; private set; }
        public AppParameter Department { get; private set; }
        public AppParameter StoredUser { get; private set; }
        public AppParameter ServerName { get; private set; }
        public AppParameter DatabaseName { get; private set; }
        public AppParameter DbUser { get; private set; }
        public AppParameter DbPassword { get; private set; }
        public AppParameter AppPassword { get; private set; }
        public AppParameter LoadFromOnlineDb { get; private set; }

        public void LoadParameters()
        {
            Username =
                new AppParameter(ParameterValue.CurrentUserName.ToString(), GetParameter(ParameterValue.CurrentUserName));
            Department =
                new AppParameter(ParameterValue.CurrentDepartment.ToString(), GetParameter(ParameterValue.CurrentDepartment));
            StoredUser =
                new AppParameter(ParameterValue.RememberUser.ToString(), GetParameter(ParameterValue.RememberUser));
            ServerName =
                new AppParameter(ParameterValue.OnlineDatabaseServer.ToString(), GetParameter(ParameterValue.OnlineDatabaseServer));
            DatabaseName =
                new AppParameter(ParameterValue.OnlineDatabaseDatabase.ToString(), GetParameter(ParameterValue.OnlineDatabaseDatabase));
            DbUser =
                new AppParameter(ParameterValue.OnlineDatabaseUser.ToString(), GetParameter(ParameterValue.OnlineDatabaseUser));
            DbPassword =
                new AppParameter(ParameterValue.OnlineDatabasePassword.ToString(), GetParameter(ParameterValue.OnlineDatabasePassword));
            AppPassword =
                new AppParameter(ParameterValue.CurrentPassword.ToString(), GetParameter(ParameterValue.CurrentPassword));
            LoadFromOnlineDb =
                new AppParameter(ParameterValue.LoadFromOnlineDatabase.ToString(), GetParameter(ParameterValue.LoadFromOnlineDatabase));
        }
    }
}
