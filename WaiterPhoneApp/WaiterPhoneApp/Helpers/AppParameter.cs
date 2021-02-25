using System;
using System.Collections.Generic;
using System.Text;

namespace WaiterPhoneApp.Helpers
{
    public class AppParameter
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public AppParameter(string key, string value)
            => (Key, Value) = (key, value);
    }
}
