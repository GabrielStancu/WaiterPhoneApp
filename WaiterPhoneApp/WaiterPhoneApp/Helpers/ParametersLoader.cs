using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace WaiterPhoneApp.Helpers
{
    public static class ParametersLoader
    {
        public readonly static Dictionary<string, string> ParameterNames = new Dictionary<string, string>()
        {
            ["LoadFromExternalDatabaseAtStartup"] = "False",
            ["OnlineDatabaseConnectionString"] = "localhost",
            ["RememberUser"] = "False",
            ["CurrentUserName"] = "",
            ["CurrentPassword"] = ""
        };

        public static List<AppParameter> LoadParameters()
        {
            List<AppParameter> parameters = new List<AppParameter>();

            foreach (var key in ParameterNames.Keys)
            {
                var defaultValue = ParameterNames[key];
                
                if(!Preferences.ContainsKey(key))
                {
                    Preferences.Set(key, defaultValue);
                }

                var paramValue = Preferences.Get(key, defaultValue);

                parameters.Add(new AppParameter(key, paramValue, defaultValue));
            }

            return parameters;
        }
    }
}
