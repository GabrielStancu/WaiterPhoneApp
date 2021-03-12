using System;
using WaiterPhoneApp.Helpers.Exceptions;
using WaiterPhoneApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WaiterPhoneApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignupPage : ContentPage
    {
        SignupViewModel viewModel;
        public SignupPage()
        {
            InitializeComponent();
            viewModel = new SignupViewModel();
            this.BindingContext = viewModel;
        }

        private async void OnSignUpClicked(object sender, EventArgs e)
        {
            try
            {
                bool userRegistered = await viewModel.RegisterUser();
                if(userRegistered)
                {
                    await DisplayAlert("Success", "User successfully registered!", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "All fields must be completed!", "OK");
                }
            }
            catch (UserAlreadyRegisteredException ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}