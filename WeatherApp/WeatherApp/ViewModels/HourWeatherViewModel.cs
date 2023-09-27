using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Models;

namespace WeatherApp.ViewModels
{
    public sealed class HourWeatherViewModel : ViewModel
    {
        private string _Temp;
        public string Temp
        {
            get { return _Temp; }
            set { this.SetProperty(ref _Temp, value); }
        }

        private string _Time;
        public string Time
        {
            get { return _Time; }
            set { this.SetProperty(ref _Time, value); }
        }

        private string _Icon;
        public string Icon
        {
            get { return _Icon; }
            set { this.SetProperty(ref _Icon, value); }
        }


        private int _Index;
        public int Index
        {
            get { return _Index; }
            set { this.SetProperty(ref _Index, value); }
        }

        private void TransformWeatherToDisplay(List list)
        {
            this.Temp = Math.Round(list.Main.Temp).ToString();

            this.Time = DateTime.Parse(list.DtTxt).TimeOfDay.Hours.ToString() + ":00";

            this.Icon = "https://openweathermap.org/img/wn/" + list.Weather[0].Icon + "@2x.png";
        }

        public HourWeatherViewModel(List list)
        {
            TransformWeatherToDisplay(list);
        }
    }
}
