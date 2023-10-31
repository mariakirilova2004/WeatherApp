using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Services.User;
using WeatherApp.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            this.BindingContext = new RegisterLoginPageViewModel();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var model = this.BindingContext as RegisterLoginPageViewModel;
            IUserValidatorService userValidatorService = new UserValidatorService();

            User user = new User()
            {
                Email = email.Text,
                Password = password1.Text
            };

            SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation);
            int rows = 0;
            if (userValidatorService.DoesEmailExists(user.Email))
            {
                model.IsVisible = true;
                model.Message = "This email is already used!";
                return;
            }
            if (userValidatorService.IsValidEmail(user.Email))
            {
                if(userValidatorService.IsValidPassword(user.Password))
                {
                    model.IsVisible = true;
                    model.Message = "Password should be at least 8 characters and has at least one digit!";
                    return;
                }
                else if(password1.ToString() != password2.ToString())
                {
                    model.IsVisible = true;
                    model.Message = "Invalid confirm password!";
                    return;
                }
                else rows = connection.Insert(user);
            }
            else
            {
                model.IsVisible = true;
                model.Message = "Email should be valid!";
                return;
            }
            connection.Close();

            if (rows > 0)
            {
                App.Current.MainPage = new LoginPage();
            }
            else
            {
                model.IsVisible = true;
                model.Message = "Try Again";
            }
;        }
        private void Button_Clicked_1(object sender, EventArgs e)
        {
            App.Current.MainPage = new LoginPage();
        }
    }
}