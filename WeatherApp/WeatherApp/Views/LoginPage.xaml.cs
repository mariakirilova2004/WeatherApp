using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new RegisterLoginPageViewModel();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var model = this.BindingContext as RegisterLoginPageViewModel;

            SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation);
            var table = connection.Table<User>();
            var user = table.FirstOrDefault(v => v.Email == email.Text);
            if (user == null || user.Password != password.Text)
            {
                model.IsVisible = true;
                model.Message = "Invalid Log in!";
                return;
            }
            connection.Close();
            App.LoggedInUser = user.Email;
            App.Current.MainPage = new MainPage();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            App.Current.MainPage = new RegisterPage();
        }
    }
}