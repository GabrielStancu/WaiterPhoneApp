using System;

namespace WaiterPhoneApp.Exceptions
{
    public class BadConnectionStringException : Exception
    {
        public BadConnectionStringException() : base("The connection string is not correctly configured!")
        {
        }
    }
}
