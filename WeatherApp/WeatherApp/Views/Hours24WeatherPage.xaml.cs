using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Hours24WeatherPage : ContentPage
    {
        public Hours24WeatherPage()
        {
            InitializeComponent();
            this.BindingContext = new WeatherPageViewModel();
        }

        protected override void OnAppearing()
        {

            if (this.BindingContext == null) return;

            var vm = this.BindingContext as WeatherPageViewModel;
        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;

            var vm = this.BindingContext as WeatherPageViewModel;

            var metrics = await SecureStorage.GetAsync("metrics");

            var result = await vm.WeatherAPI.GetWeatherDataAsync(searchBar.Text, metrics);

            if (result != null)
            {
                vm.CurrentWeather.TransformWeatherToDisplay(result);

                CollectionView.ItemsSource = vm.CurrentWeather.ListHourWeatherViewModel;
            }
        }
    }
}