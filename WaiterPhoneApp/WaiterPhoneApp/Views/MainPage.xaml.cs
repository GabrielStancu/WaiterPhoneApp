using System;
using WaiterPhoneApp.Database.Entities;
using WaiterPhoneApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WaiterPhoneApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    // This whole mess will be deleted. For now, it serves testing purposes
    public partial class MainPage : TabbedPage
    {
        private RestaurantUser _user;
        public MainPage(RestaurantUser user)
        {
            _user = user;
            InitializeComponent();
        }

        private async void OnSelectUserClicked(object sender, EventArgs e)
        {
            UserEntity userEntity = new UserEntity();
            _user = await userEntity.SelectUserWithLoginInformation("Gabi", "gabi");
            UserLabel.Text = _user.Nickname;
        }

        private async void OnUpdateNicknameClicked(object sender, EventArgs e)
        {
            _user.Nickname = NicknameEntry.Text;
            await new UserEntity().UpdateAsync(_user);
            await DisplayAlert("Done", "Nickname changed!", "OK");
        }
    }
}