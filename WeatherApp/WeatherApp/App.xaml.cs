using System;
using System.Globalization;
using System.Threading;
using WeatherApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp
{
    public partial class App : Application
    {
        public static string DatabaseLocation { get; set; }

        public static string LoggedInUser { get; set; }
        public App()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InstalledUICulture;
            InitializeComponent();
            MainPage = new MainPage();
        }

        public App(string databaseLocation)
        {
            DatabaseLocation = databaseLocation;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InstalledUICulture;
            InitializeComponent();
            MainPage = new RegisterPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
