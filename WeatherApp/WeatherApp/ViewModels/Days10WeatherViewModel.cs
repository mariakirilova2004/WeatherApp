using System;
using System.Collections.Generic;
using System.Linq;
using WeatherApp.Services.Location;
using WeatherApp.ViewModels;
using static System.Net.WebRequestMethods;

namespace WeatherApp.Models
{
    public sealed class Days10WeatherViewModel : ViewModel
    {
        private List<DayWeatherViewModel> _ListDayWeatherViewModel;
        public List<DayWeatherViewModel> ListDayWeatherViewModel // List of DayWeatherViewModel
        {
            get { return _ListDayWeatherViewModel; }
            set { this.SetProperty(ref _ListDayWeatherViewModel, value); }
        }

        public void TransformWeatherToDisplay(Root root)
        {
            this.ListDayWeatherViewModel = root.List.Select(l => new DayWeatherViewModel(l)).ToList();
        }
    }
}
