using System;
using WeatherApp.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
        public WeatherPageViewModel vm { get; set; }

        public HomePage()
		{
            InitializeComponent();
            this.vm = new WeatherPageViewModel();
            this.BindingContext = vm;
        }

        protected async override void OnAppearing()
        {
            if (this.BindingContext == null) return;

            var vm = this.BindingContext as WeatherPageViewModel;

            var locationcoord = await vm.LocationService.GetCurrentLocationCoordinatesAsync();

            var name = await vm.LocationService.GetCurrentLocationNameAsync(double.Parse(locationcoord.Latitude.ToString()), double.Parse(locationcoord.Longitude.ToString()));

            try
            {
                var metrics = await SecureStorage.GetAsync("metrics");

                var result = await vm.WeatherAPI.GetWeatherDataAsync(name.AdminArea.ToString(), metrics);

                vm.CurrentWeather.TransformWeatherToDisplay(result);

                CollectionView.ItemsSource = vm.CurrentWeather.ListHourWeatherViewModel;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            this.vm.CurrentWeather.SetFavourites();
        }
    }
}