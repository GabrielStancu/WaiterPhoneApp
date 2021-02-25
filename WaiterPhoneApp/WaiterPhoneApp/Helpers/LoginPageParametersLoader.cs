using System;
using System.Collections.Generic;
using System.Text;

namespace WaiterPhoneApp.Helpers
{
    public class LoginPageParametersLoader : ParametersLoader
    {
        public List<AppParameter> LoadParameters()
        {
            AppParameter username =
                new AppParameter(ParameterValue.CurrentUserName.ToString(), GetParameter(ParameterValue.CurrentUserName));
            AppParameter department =
                new AppParameter(ParameterValue.CurrentDepartment.ToString(), GetParameter(ParameterValue.CurrentDepartment));

            return new List<AppParameter>()
            {
                username,
                department
            };
        }
    }
}
