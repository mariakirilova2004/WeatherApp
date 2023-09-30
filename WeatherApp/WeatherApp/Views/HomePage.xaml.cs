using WeatherApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage()
		{
            InitializeComponent();

            this.BindingContext = new WeatherPageViewModel();
        }

        protected async override void OnAppearing()
        {
            if (this.BindingContext == null) return;

            var vm = this.BindingContext as WeatherPageViewModel;

            var locationcoord = await vm.LocationService.GetCurrentLocationCoordinatesAsync();

            var name = await vm.LocationService.GetCurrentLocationNameAsync(double.Parse(locationcoord.Latitude.ToString()), double.Parse(locationcoord.Longitude.ToString()));

            var result = await vm.WeatherAPI.GetWeatherDataAsync(name.AdminArea.ToString(), "metric");

            vm.CurrentWeather.TransformWeatherToDisplay(result);

            CollectionView.ItemsSource = vm.CurrentWeather.ListHourWeatherViewModel;
        }
    }
}