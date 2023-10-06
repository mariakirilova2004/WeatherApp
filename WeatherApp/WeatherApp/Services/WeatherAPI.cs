using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeatherApp.Services
{
    public class WeatherAPI : ILanguageService
    {
        private const string ApiKey = "86555c34d70146249e4f3f8f93d470d2";
        private const string BaseUrl = "https://api.openweathermap.org/data/2.5/forecast?q={0}&units={1}&appid={2}";

        public HttpClient HttpClient { get; set; } = new HttpClient();

        public async Task<Root> GetWeatherDataAsync(string city, string units)
        {
            try
            {
                var url = string.Format(BaseUrl, city, units, ApiKey);
                var response = await this.HttpClient.GetStringAsync(url);

                if (!string.IsNullOrEmpty(response))
                {
                    return JsonConvert.DeserializeObject<Root>(response);
                }
            }
            catch (Exception)
            {

            }

            return null;
        }       
    }
}
