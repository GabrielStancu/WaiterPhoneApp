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

        public void SetParameter(ParameterValue parameter, string value)
        {
            if (Preferences.ContainsKey(parameter.ToString()))
            {
                Preferences.Set(parameter.ToString(), value);
            }
        }
    }
}
