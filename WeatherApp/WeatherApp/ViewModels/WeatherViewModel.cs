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
        public IWeatherAPI WeatherAPI { get; set; }

        public WeatherViewModel()
        {
            WeatherAPI = new WeatherAPI();
            Task.Run(APIAsync);
        }

        private IList<List> _weatherList;
        public IList<List> WeatherList
        {
            get
            {
                if (_weatherList == null)
                    _weatherList = new ObservableCollection<List>();
                return _weatherList;
            }
            set
            {
                _weatherList = value;
            }
        }

        private async Task APIAsync()
        {
            try
            {
                var weather = await this.WeatherAPI.GetWeatherDataAsync("Istanbul", "metric");
                WeatherList = weather.List;
            }
            catch (Exception)
            {

            }
            //    var weather = await WeatherAPI.GetFiveDaysAsync("Istanbul");
        }
    }
}
