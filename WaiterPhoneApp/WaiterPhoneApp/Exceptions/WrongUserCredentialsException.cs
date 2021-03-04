using System;

namespace WaiterPhoneApp.Exceptions
{
    public class WrongUserCredentialsException : Exception
    {
        public WrongUserCredentialsException() : base("The user and password provided are not correct!")
        {
        }
    }
}
