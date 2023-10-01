using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.Models;
using WeatherApp.Services;
using WeatherApp.Services.Location;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    public class WeatherPageViewModel 
    {
        public ICommand SearchCommand { get; set; }

        public IWeatherAPI WeatherAPI { get; set; }
        public ILocationService LocationService { get; set; }

        public CurrentWeatherViewModel CurrentWeather { get; set; } = new CurrentWeatherViewModel();
        public Days10WeatherViewModel Days10Weather { get; set; } = new Days10WeatherViewModel();

        public WeatherPageViewModel()
        {
            this.WeatherAPI = new WeatherAPI();
            this.LocationService = new LocationService();
        }
    }
}
