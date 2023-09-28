using WeatherApp.Models;
using WeatherApp.Services;
using WeatherApp.Services.Location;

namespace WeatherApp.ViewModels
{
    public class WeatherPageViewModel 
    {
        public IWeatherAPI WeatherAPI { get; set; }
        public ILocationService LocationService { get; set; }

        public CurrentWeatherViewModel CurrentWeather { get; set; } = new CurrentWeatherViewModel();
        public Days10WeatherViewModel Days10Weather { get; set; } = new Days10WeatherViewModel();

        public WeatherPageViewModel()
        {
            WeatherAPI = new WeatherAPI();
            LocationService = new LocationService();    
        }
    }
}
