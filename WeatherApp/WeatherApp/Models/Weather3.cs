using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Models
{
    public class Weather3
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
        public string icon_url => string.Format("{0}{1}{2}", "https://openweathermap.org/img/wn/", icon, "@4x.png");
    }
}
