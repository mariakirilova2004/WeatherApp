using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface IWeatherAPI
    {
        Task<OneCallAPI> GetOneCallAPIAsync(string q, string units);
    }
}
