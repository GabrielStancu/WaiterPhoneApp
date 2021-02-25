using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WaiterPhoneApp.Helpers
{
    public enum ParameterValue
    {
        [Description("LoadFromOnlineDatabase")]
        LoadFromOnlineDatabase,
        [Description("OnlineDatabaseConnectionString")]
        OnlineDatabaseConnectionString,
        [Description("RememberUser")]
        RememberUser,
        [Description("CurrentUserName")]
        CurrentUserName,
        [Description("CurrentPassword")]
        CurrentPassword,
        [Description("CurrentDepartment")]
        CurrentDepartment
    }
}
