using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.ViewModels
{
    public class WeatherViewModel
    {
        public IWeatherAPI weatherAPI { get; set; }

        public WeatherViewModel()
        {
            weatherAPI = new WeatherAPI();
            Task.Run(APIAsync);
        }

        private IList<OneCallAPI> _weatherList;
        public IList<OneCallAPI> WeatherList
        {
            get
            {
                if (_weatherList == null)
                    _weatherList = new ObservableCollection<OneCallAPI>();
                return _weatherList;
            }
            set
            {
                _weatherList = value;
            }
        }

        private async Task APIAsync()
        {
            var weather = await weatherAPI.GetOneCallAPIAsync("Instanbul", "metric");
            //    var weather = await WeatherAPI.GetFiveDaysAsync("Istanbul");
            WeatherList.Add(weather);
        }
    }
}
