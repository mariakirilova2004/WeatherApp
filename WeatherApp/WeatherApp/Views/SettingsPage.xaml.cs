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
using Xamarin.Essentials;
using WeatherApp.ViewModels;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            this.BindingContext = new SettingsPageViewModel();
        }
        protected override void OnAppearing()
        {
            if (this.BindingContext == null) return;

            var svm = this.BindingContext as SettingsPageViewModel;
            picker1.ItemsSource = svm.LanguageItems;
            picker2.ItemsSource = svm.MetricsItems;
        }

        async void OnUpdateSaveClicked(object sender, System.EventArgs e)
        {
            try
            {
                if (picker1.SelectedItem != null)
                {
                    var language = CultureInfo.GetCultures(CultureTypes.NeutralCultures)
                                              .ToList()
                                              .First(element => element.EnglishName
                                              .Contains(picker1.SelectedItem.ToString()));
                    Thread.CurrentThread.CurrentUICulture = language;
                    AppResources.Culture = language;
                }

                if (picker2.SelectedItem != null)
                {
                    try
                    {
                        if (picker2.SelectedItem.ToString() == "CELSIUS") await SecureStorage.SetAsync("metrics", "metric");
                        if (picker2.SelectedItem.ToString() == "FARENHAIT") await SecureStorage.SetAsync("metrics", "imperial");
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }

                App.Current.MainPage = new MainPage();
            }
            catch (Exception ex)
            {
                await Navigation.PushAsync(new ErrorPage());
            }
        }
    }
}