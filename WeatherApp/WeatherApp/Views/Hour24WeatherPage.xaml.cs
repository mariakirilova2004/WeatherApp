using WeatherApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Hour24WeatherPage : ContentPage
	{
		public Hour24WeatherPage()
		{
            InitializeComponent();

            this.BindingContext = new WeatherPageViewModel();
        }

        protected async override void OnAppearing()
        {
            if (this.BindingContext == null) return;

            var vm = this.BindingContext as WeatherPageViewModel;

            var result = await vm.WeatherAPI.GetWeatherDataAsync("Blagoevgrad", "metric");

            vm.Hour24Weather.TransformWeatherToDisplay(result);

            ListView.ItemsSource = vm.Hour24Weather.ListHourWeatherViewModel;
        }
    }
}