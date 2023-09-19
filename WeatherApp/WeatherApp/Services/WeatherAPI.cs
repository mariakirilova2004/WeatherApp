using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using Xamarin.Essentials;

namespace WeatherApp.Services
{
    public class WeatherAPI : IWeatherAPI
    {
        
        public async Task<OneCallAPI> GetOneCallAPIAsync(string q, string units)
        {
            string OPENWEATHERMAP_API_KEY = await SecureStorage.GetAsync("openWeatherMapApiKey");
            string BASE_URL = "https://api.openweathermap.org/data/2.5/weather?q={0}&units={1}&appid={2}";
            OneCallAPI weather = new OneCallAPI();
            string url = String.Format(BASE_URL,q, units, OPENWEATHERMAP_API_KEY);
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var posts = JsonConvert.DeserializeObject<OneCallAPI>(content);
                weather = posts;
            }
            return weather;
        }
    }
}
