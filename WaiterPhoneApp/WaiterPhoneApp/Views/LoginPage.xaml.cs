using System;
using System.Collections.Generic;
using System.Linq;
using WaiterPhoneApp.Helpers;
using WaiterPhoneApp.Models;
using WaiterPhoneApp.OnlineDbEntities;
using WaiterPhoneApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WaiterPhoneApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginViewModel LoginViewModel { get; set; }
        public LoginPage()
        {
            InitializeComponent();
            SetBindingContext();
        }

        private async void SetBindingContext()
        {
            try
            {
                var loader = new LoginPageParametersLoader();
                List<AppParameter> appParameters = loader.LoadParameters();

                string user = appParameters
                    .Where(p => p.Key.Equals(ParameterValue.CurrentUserName.ToString())).FirstOrDefault().Value;

                string department = appParameters
                    .Where(p => p.Key.Equals(ParameterValue.CurrentDepartment.ToString())).FirstOrDefault().Value;


                LoginViewModel = new LoginViewModel(user, department);
                BindingContext = LoginViewModel;
            }
            catch(NullReferenceException)
            {
                await DisplayAlert("Parameters error", "One of the paramaters was not set, you will be redirected to the parameters page", "OK");
            }
        }

        private async void OnSettingsButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }

        private async void OnLoginButtonClick(object sender, EventArgs e)
        {
            UserEntity userEntity = new UserEntity();
            User user = await userEntity.SelectUserWithLoginInformation(UsernameEntry.Text, PasswordEntry.Text);

            if(user is null)
            {
                await DisplayAlert("Login failed", "The username or the password provided is incorrect.", "OK");
                UsernameEntry.Text = string.Empty;
                PasswordEntry.Text = string.Empty;
            }
            else
            {
                await Navigation.PushAsync(new MainPage());
            } 
        }

        private async void OnSignupButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignupPage());
        }

        private void OnRememberUserCheckboxCheck(object sender, CheckedChangedEventArgs e)
        {
            ParametersLoader loader = new ParametersLoader();
            loader.SetParameter(ParameterValue.RememberUser, e.Value.ToString());
        }
    }
}