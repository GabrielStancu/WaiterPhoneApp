using System;
using System.Collections.Generic;
using System.Text;

namespace WaiterPhoneApp.Helpers
{
    public class AppParameter
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string DefaultValue { get; set; }

        public AppParameter(string key, string value, string defaultValue)
            => (Key, Value, DefaultValue) = (key, value, defaultValue);
    }
}
