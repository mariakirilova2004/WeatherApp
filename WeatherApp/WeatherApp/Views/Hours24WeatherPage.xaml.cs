using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.ViewModels;
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

        protected async override void OnAppearing()
        {

            if (this.BindingContext == null) return;

            var vm = this.BindingContext as WeatherPageViewModel;

            //vm.SearchCommand = new Command(vm.SearchComm);
            var result = await vm.WeatherAPI.GetWeatherDataAsync("Blagoevgrad", "metric");

            vm.CurrentWeather.TransformWeatherToDisplay(result);
            CollectionView.ItemsSource = vm.CurrentWeather.ListHourWeatherViewModel;
        }
    }
}