using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeatherApp.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        void OnUpdateLangugeClicked(object sender, System.EventArgs e)
        {
            if (picker.SelectedItem != null)
            {
                var language = CultureInfo.GetCultures(CultureTypes.NeutralCultures)
                                          .ToList()
                                          .First(element => element.EnglishName
                                          .Contains(picker.SelectedItem.ToString()));
                Thread.CurrentThread.CurrentUICulture = language;
                AppResources_bg.Culture = language;
            }

            App.Current.MainPage = new MainPage();
        }
    }
}