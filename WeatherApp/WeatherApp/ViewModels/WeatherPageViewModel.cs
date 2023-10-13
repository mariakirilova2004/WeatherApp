using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.Models;
using WeatherApp.Services;
using WeatherApp.Services.Location;
using WeatherApp.Services.Weather;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    public class WeatherPageViewModel 
    {
        public SearchBar SearchBar { get; set; }
        public ILanguageService WeatherAPI { get; set; }
        public ILocationService LocationService { get; set; }
        public HomePageViewModel CurrentWeather { get; set; } = new HomePageViewModel();
        public Days6WeatherPageViewModel Days6Weather { get; set; } = new Days6WeatherPageViewModel();
        public FavouritesPageViewModel Favourites { get; set; } = new FavouritesPageViewModel();

        public WeatherPageViewModel()
        {
            this.WeatherAPI = new WeatherAPI();
            this.LocationService = new LocationService();
            this.SearchBar = new SearchBar();
        }
    }
}
