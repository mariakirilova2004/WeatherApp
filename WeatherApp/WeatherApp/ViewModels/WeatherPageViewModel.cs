using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.ViewModels
{
    public class WeatherPageViewModel 
    {
        public IWeatherAPI WeatherAPI { get; set; }

        public DisplayCurrentWeatherViewModel CurrentWeather { get; set; } = new DisplayCurrentWeatherViewModel();

        public WeatherPageViewModel()
        {
            WeatherAPI = new WeatherAPI();
        }
    }
}
