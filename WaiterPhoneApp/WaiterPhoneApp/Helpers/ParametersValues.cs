using System.ComponentModel;

namespace WaiterPhoneApp.Helpers
{
    public enum ParameterValue
    {
        [Description("LoadFromOnlineDatabase")]
        LoadFromOnlineDatabase,
        [Description("OnlineDatabaseServer")]
        OnlineDatabaseServer,
        [Description("OnlineDatabaseDatabase")]
        OnlineDatabaseDatabase,
        [Description("OnlineDatabaseUser")]
        OnlineDatabaseUser,
        [Description("OnlineDatabasePassword")]
        OnlineDatabasePassword,
        [Description("RememberUser")]
        RememberUser,
        [Description("CurrentUserName")]
        CurrentUserName,
        [Description("CurrentPassword")]
        CurrentPassword,
        [Description("Nickname")]
        Nickname,
        [Description("CurrentDepartment")]
        CurrentDepartment
    }
}
