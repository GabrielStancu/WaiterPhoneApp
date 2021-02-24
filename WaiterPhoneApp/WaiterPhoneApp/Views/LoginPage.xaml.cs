using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            LoginViewModel = new LoginViewModel("Gabi", "Hotel's Restaurant"); //for the moment
            BindingContext = LoginViewModel;
        }
    }
}