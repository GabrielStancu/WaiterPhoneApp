using Xamarin.Essentials;

namespace WaiterPhoneApp.Helpers.ParametersHelpers
{
    public class ParametersLoader
    {
        public string GetParameter(ParameterValue parameter)
        {
            if (Preferences.ContainsKey(parameter.ToString()))
            {
                return Preferences.Get(parameter.ToString(), string.Empty);
            }

            return string.Empty;
        }
    }
}
