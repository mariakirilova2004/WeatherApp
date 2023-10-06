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
        public WeatherPageViewModel vm { get; set; }
        public Days6WeatherPage()
        {
            InitializeComponent();

            vm = new WeatherPageViewModel();
            this.BindingContext = vm;
            vm.SearchBar.SetBinding(SearchBar.TextProperty, new Binding("Text", BindingMode.TwoWay, source:this));

        }

        protected override void OnAppearing()
        {
            if (this.BindingContext == null) return;
        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var result = await vm.WeatherAPI.GetWeatherDataAsync(SearchBar.Text, "metric");

            if(result != null)
            {
                vm.Days10Weather.TransformWeatherToDisplay(result);

                CollectionView.ItemsSource = vm.Days10Weather.ListDayWeatherViewModel;
            }
        }
    }
}