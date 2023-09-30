using System;
using System.Collections.Generic;
using System.Linq;
using WeatherApp.ViewModels;
using static System.Net.WebRequestMethods;

namespace WeatherApp.Models
{
    public sealed class DayWeatherViewModel : ViewModel
    {
        private string _MinTemp;
        public string MinTemp 
        {
            get { return _MinTemp; }
            set { this.SetProperty(ref _MinTemp, value); }
        }

        private string _MaxTemp;
        public string MaxTemp 
        {
            get { return _MaxTemp; }
            set { this.SetProperty(ref _MaxTemp, value); }
        }

        private string _CurrentDayFormatted;
        public string CurrentDayFormatted
        {
            get { return _CurrentDayFormatted; }
            set { this.SetProperty(ref _CurrentDayFormatted, value); }
        }

        private string _weatherState;
        public string WeatherState 
        {
            get { return _weatherState; }
            set { this.SetProperty(ref _weatherState, value); }
        }

        private string _icon;
        public string Icon 
        {
            get { return _icon; }
            set { this.SetProperty(ref _icon, value); }
        }

        public void TransformWeatherToDisplay(List list)
        {
            this.MinTemp = Math.Round(list.Main.TempMin).ToString();

            this.MinTemp = Math.Round(list.Main.TempMax).ToString();

            this.CurrentDayFormatted = DateTime.Parse(list.DtTxt).Day.ToString() 
                + " " + DateTime.Parse(list.DtTxt).DayOfWeek.ToString();

            this.WeatherState = list.Weather[0].Description;

            this.Icon = "https://openweathermap.org/img/wn/" + list.Weather[0].Icon + "@2x.png";
        }

        public DayWeatherViewModel(List list)
        {
            TransformWeatherToDisplay(list);
        }
    }
}
