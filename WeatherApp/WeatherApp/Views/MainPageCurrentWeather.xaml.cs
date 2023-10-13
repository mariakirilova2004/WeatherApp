using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageCurrentWeather : ContentPage
    {
        public WeatherPageViewModel vm { get; set; }
        public MainPageCurrentWeather()
        {
            InitializeComponent();
            this.vm = new WeatherPageViewModel();
            this.BindingContext = vm;
        }

        protected async override void OnAppearing()
        {
            try
            {
                if (this.BindingContext == null) return;

                var vm = this.BindingContext as WeatherPageViewModel;

                var locationcoord = await vm.LocationService.GetCurrentLocationCoordinatesAsync();

                var name = await vm.LocationService.GetCurrentLocationNameAsync(double.Parse(locationcoord.Latitude.ToString()), double.Parse(locationcoord.Longitude.ToString()));

                var metrics = await SecureStorage.GetAsync("metrics");

                var result = await vm.WeatherAPI.GetWeatherDataAsync(name.Locality.ToString(), metrics);

                await vm.CurrentWeather.TransformWeatherToDisplay(result);

                CollectionView.ItemsSource = vm.CurrentWeather.ListHourWeatherViewModel;
            }
            catch (Exception ex)
            {
                await Navigation.PushAsync(new ErrorPage());
            }
        }

        private async void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            try
            {
                await this.vm.CurrentWeather.favoritesService.SetFavourites(this.vm.CurrentWeather.IsFavorite, this.vm.CurrentWeather.Name);
            }
            catch (Exception ex)
            {
                await Navigation.PushAsync(new ErrorPage());
            }
        }
    }
}