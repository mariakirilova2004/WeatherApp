using System;
using static System.Net.WebRequestMethods;

namespace WeatherApp.Models
{
    public sealed class DisplayCurrentWeatherViewModel : ViewModel
    {
        private string _Temp;
        public string Temp // 30
        {
            get { return _Temp; }
            set { this.SetProperty(ref _Temp, value); }
        }

        private string _currentDayFormatted;
        public string CurrentDayFormatted // 02.02.24 Sun
        {
            get { return _currentDayFormatted; }
            set { this.SetProperty(ref _currentDayFormatted, value); }
        }

        private string _name;
        public string Name// Istanbul
        {
            get { return _name; }
            set { this.SetProperty(ref _name, value); }
        }

        private string _metric;
        public string Metric // CELSIUS
        {
            get { return _metric; }
            set { this.SetProperty(ref _metric, value); }
        }

        private string _humidity;
        public string Humidity // 50%
        {
            get { return _humidity; }
            set { this.SetProperty(ref _humidity, value); }
        }

        private string _wind;
        public string Wind // 2.3m/s
        {
            get { return _wind; }
            set { this.SetProperty(ref _wind, value); }
        }

        private string _pressure;
        public string Pressure // 1500hpa
        {
            get { return _pressure; }
            set { this.SetProperty(ref _pressure, value); }
        }

        private string _weatherState;
        public string WeatherState // Cloudy
        {
            get { return _weatherState; }
            set { this.SetProperty(ref _weatherState, value); }
        }

        private string _icon;
        public string Icon // Cloudy Image
        {
            get { return _icon; }
            set { this.SetProperty(ref _icon, value); }
        }

        public void TransformWeatherToDisplay(Root root)
        {
            this.Temp = Math.Round(root.List[0].Main.Temp).ToString();

            this.Name = root.City.Name;

            this.CurrentDayFormatted = DateTime.Parse(root.List[0].DtTxt).Day.ToString() 
                + " " + DateTime.Parse(root.List[0].DtTxt).DayOfWeek.ToString();

            this.Metric = "CELSIUS";

            this.Humidity = root.List[0].Main.Humidity.ToString() + "%";

            this.WeatherState = root.List[0].Weather[0].Description;

            this.Icon = "https://openweathermap.org/img/wn/" + root.List[0].Weather[0].Icon + "@2x.png";

            this.Wind = root.List[0].Wind.Speed.ToString() + "m/s";

            this.Pressure = root.List[0].Main.Pressure.ToString() + "hpa";
        }
    }
}
