using System;
using WaiterPhoneApp.Helpers;
using WaiterPhoneApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WaiterPhoneApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        readonly SettingsViewModel model;
        public SettingsPage()
        {
            InitializeComponent();
            model = new SettingsViewModel();
            this.BindingContext = model;
        }

        private async void OnSaveButtonClick(object sender, EventArgs e)
        {
            new ParametersSaver().SaveModelSettings(model);
            await this.Navigation.PopAsync();
        }
    }
}