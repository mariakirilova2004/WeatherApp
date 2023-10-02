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
    public partial class Days6WeatherPage : ContentPage
    {
        public Days6WeatherPage()
        {
            InitializeComponent();
            this.BindingContext = new WeatherPageViewModel();
        }

        protected override void OnAppearing()
        {

            if (this.BindingContext == null) return;
        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;

            var vm = this.BindingContext as WeatherPageViewModel;

            var result = await vm.WeatherAPI.GetWeatherDataAsync(searchBar.Text, "metric");

            if(result != null)
            {
                vm.Days10Weather.TransformWeatherToDisplay(result);

                CollectionView.ItemsSource = vm.Days10Weather.ListDayWeatherViewModel;
            }
        }
    }
}