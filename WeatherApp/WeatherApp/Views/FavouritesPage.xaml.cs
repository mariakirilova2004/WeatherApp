using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavouritesPage : ContentPage
    {
        public WeatherPageViewModel vm { get; set; }
        public FavouritesPage()
        {
            InitializeComponent();

            vm = new WeatherPageViewModel();
            this.BindingContext = vm;
            //vm.SearchBar.SetBinding(Xamarin.Forms.SearchBar.TextProperty, new Binding("Text", BindingMode.TwoWay));

        }

        protected async override void OnAppearing()
        {

            try
            {
                if (this.BindingContext == null) return;

                var vm = this.BindingContext as WeatherPageViewModel;

                var res = await vm.Favourites.GetFavouritesNameAsync();

                var metrics = await SecureStorage.GetAsync("metrics");

                List<Root> result = new List<Root>();

                foreach (var favourite in res)
                {
                    if(favourite != "") result.Add(await vm.WeatherAPI.GetWeatherDataAsync(favourite, metrics));
                }

                vm.Favourites.TransformWeatherToDisplay(result);

                ListView.ItemsSource = vm.Favourites.ListFavouritesWeatherViewModel;
            }
            catch (Exception ex)
            {
                await Navigation.PushAsync(new ErrorPage());
            }
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {

        }
    }
}