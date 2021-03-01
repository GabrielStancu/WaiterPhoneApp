using Xamarin.Essentials;

namespace WaiterPhoneApp.Helpers
{
    public class ParametersLoader
    {
        public string GetParameter(ParameterValue parameter)
        {
            if (Preferences.ContainsKey(parameter.ToString()))
            {
                return Preferences.Get(parameter.ToString(), string.Empty);
            }

            return null;
        }
    }
}
