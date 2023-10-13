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
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
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
            //vm.SearchBar.SetBinding(Xamarin.Forms.SearchBar.TextProperty, new Binding("Text", BindingMode.TwoWay));

        }

        protected override void OnAppearing()
        {
            if (this.BindingContext == null) return;
        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var metrics = await SecureStorage.GetAsync("metrics");
                var result = await vm.WeatherAPI.GetWeatherDataAsync(vm.SearchBar.Text, metrics);
                if (result != null)
                {
                    await vm.Days6Weather.TransformWeatherToDisplay(result);

                    CollectionView.ItemsSource = vm.Days6Weather.ListDayWeatherViewModel;
                }
            }
            catch (Exception ex)
            {
                //await Navigation.PushAsync(new ErrorPage());
            }
        }
        private async void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            try
            {
                await this.vm.Days6Weather.favoritesService.SetFavourites(this.vm.Days6Weather.IsFavorite, this.vm.Days6Weather.Name);
            }
            catch (Exception ex)
            {
                await Navigation.PushAsync(new ErrorPage());
            }
        }
    }
}