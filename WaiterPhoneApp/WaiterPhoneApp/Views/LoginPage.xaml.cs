﻿using System;
using WaiterPhoneApp.Database.DatabaseContexts;
using WaiterPhoneApp.Database.Entities;
using WaiterPhoneApp.Helpers.Exceptions;
using WaiterPhoneApp.Helpers.ParametersHelpers;
using WaiterPhoneApp.Helpers.ViewModelCreators;
using WaiterPhoneApp.Helpers.WifiConnectionHelpers;
using WaiterPhoneApp.Models;
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
            CheckLoadFromDatabaseOnStartup();
        }

        protected async override void OnAppearing()
        {
            SetBindingContext();
            if (!_configuredUser)
            {
                await DisplayAlert("Parameter error", "One of the parameters is not set. You will be redirected to parameters page.", "OK");
                await Navigation.PushAsync(new SettingsPage(OnlineRestaurantDatabaseContext.IsConnectionStringSet()));
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
            model = new LoginViewModelCreator().CreateLoginViewModel();

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
            await Navigation.PushAsync(new SettingsPage(OnlineRestaurantDatabaseContext.IsConnectionStringSet()));
        }

        private async void OnLoginButtonClick(object sender, EventArgs e)
        {
            string networkResponse = WifiConnectionResponseMessageDisplayer.GenerateResponse();

            if(!networkResponse.Equals(string.Empty))
            {
                await DisplayAlert("Connection error", networkResponse, "OK");
                return;
            }

            try
            {
                UserEntity userEntity = new UserEntity();
                RestaurantUser user = await userEntity.SelectUserWithLoginInformation(UsernameEntry.Text, PasswordEntry.Text);
                await Navigation.PushAsync(new MainPage(user));
            }
            catch(BadConnectionStringException ex)
            {
                await DisplayAlert("Bad connection string", ex.Message, "OK");
            }
            catch(WrongUserCredentialsException ex)
            {
                await DisplayAlert("Login failed", ex.Message, "OK");
                UsernameEntry.Text = string.Empty;
                PasswordEntry.Text = string.Empty;
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

        private void CheckLoadFromDatabaseOnStartup()
        {
            //TODO
        }
    }
}