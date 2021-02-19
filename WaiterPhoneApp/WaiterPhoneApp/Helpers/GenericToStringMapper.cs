using System;
using System.Collections.Generic;
using System.Text;
using WaiterPhoneApp.Models;

namespace WaiterPhoneApp.Helpers
{
    public class GenericToStringMapper<T> where T:BaseModel
    {
        public string Map()
        {
            return typeof(T).Name;
        }
    }
}
