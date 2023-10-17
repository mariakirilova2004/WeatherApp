using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services.Weather
{
    public class WeatherAPI : ILanguageService
    {
        private const string ApiKey = "86555c34d70146249e4f3f8f93d470d2";
        private const string BaseUrlGetWeather = "https://api.openweathermap.org/data/2.5/forecast?q={0}&units={1}&appid={2}";
        private const string BaseUrlGetCities = "https://api.openweathermap.org/geo/1.0/direct?limit={0}&appid={1}&q={2}";

        public HttpClient HttpClient { get; set; } = new HttpClient();

        public async Task<Root> GetWeatherDataAsync(string city, string units)
        {
            if (units == null) units = "metric";
            var url = string.Format(BaseUrlGetWeather, city, units, ApiKey);
            var response = await HttpClient.GetStringAsync(url);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<Root>(response);
            }

            return null;
        }

        public async Task<Suggestion> GetCityNames(string city)
        {
            var url = string.Format(BaseUrlGetCities, 4, ApiKey, city);
            var response = await HttpClient.GetStringAsync(url);

            if (!string.IsNullOrEmpty(response))
            {
                Suggestion sg = new Suggestion();
                sg.ListCities = JsonConvert.DeserializeObject<List<SuggestionCity>>(response);
                sg.ListCities = sg.ListCities.Where(s => s.Name == city).Take(1).ToList();
                return sg;
            }

            return null;
        }
    }
}
