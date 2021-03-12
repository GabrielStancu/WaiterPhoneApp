using System;

namespace WaiterPhoneApp.Helpers.Exceptions
{
    public class UserAlreadyRegisteredException : Exception
    {
        public UserAlreadyRegisteredException() : base("The user is already registered!")
        {
        }
    }
}
