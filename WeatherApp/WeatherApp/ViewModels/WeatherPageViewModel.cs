using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.ViewModels
{
    public class WeatherPageViewModel 
    {
        public IWeatherAPI WeatherAPI { get; set; }

        public Hour24WeatherViewModel Hour24Weather { get; set; } = new Hour24WeatherViewModel();

        public WeatherPageViewModel()
        {
            WeatherAPI = new WeatherAPI();
        }
    }
}
