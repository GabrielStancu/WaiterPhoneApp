using System;
using WaiterPhoneApp.Helpers.ParametersHelpers;
using WaiterPhoneApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WaiterPhoneApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        SettingsViewModel model;
        public SettingsPage(bool loadDepartments)
        {
            InitializeComponent();
            model = new SettingsViewModel(loadDepartments);
            this.BindingContext = model;
        }

        private async void OnSaveButtonClick(object sender, EventArgs e)
        {
            new ParametersSaver().SaveModelSettings(model);
            await this.Navigation.PopAsync();
        }
    }
}