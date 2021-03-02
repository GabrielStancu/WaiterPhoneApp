using System;
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
        LoginViewModel model;
        private bool _configuredUser = false;
        public LoginPage()
        {
            InitializeComponent();
            //SetBindingContext();
            //we should check if all the data is taken from online db on startup here...
        }

        protected async override void OnAppearing()
        {
            SetBindingContext();
            if (!_configuredUser)
            {
                await DisplayAlert("Parameter error", "One of the parameters is not set. You will be redirected to parameters page.", "OK");
                await Navigation.PushAsync(new SettingsPage());
            }
            else if (this.model.StoredUser)
            {
                this.UsernameEntry.Text = model.Username;
                this.PasswordEntry.Text =
                    new ParametersLoader().GetParameter(ParameterValue.CurrentPassword);
            }
        }

        private void SetBindingContext()
        {
            LoginViewModelCreator creator = new LoginViewModelCreator();
            model = creator.CreateLoginViewModel();

            if(model != null)
            {
                this.BindingContext = model;
                _configuredUser = true;
                ShowControls(true);
            }
            else
            {
                _configuredUser = false;
                ShowControls(false);
            }
        }

        private async void OnSettingsButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }

        private async void OnLoginButtonClick(object sender, EventArgs e)
        {
            UserEntity userEntity = new UserEntity();
            User user = await userEntity.SelectUserWithLoginInformation(UsernameEntry.Text, PasswordEntry.Text); //make it case sensitive...
            //wrap this up in internet connection check
            //see if database responds 
            //if connected to internet and database responds (good connection string), proceed next

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
            new ParametersSaver().SetParameter(ParameterValue.RememberUser, e.Value.ToString());
        }

        private void ShowControls(bool visibility)
        {
            UserLabel.IsVisible = visibility;
            DepartmentLabel.IsVisible = visibility;
            DateLabel.IsVisible = visibility;
            SettingsButton.IsVisible = visibility;

            UserValueLabel.IsVisible = visibility;
            DepartmentValueLabel.IsVisible = visibility;
        }
    }
}