using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Models
{
    public class OneCallAPI
    {
        public string q { get; set; }
        public string timezone { get; set; }
        public int timezone_offset { get; set; }
        public Current current { get; set; }
        public List<Minutely> minutely { get; set; }
        public List<Hourly> hourly { get; set; }
        public List<Daily> daily { get; set; }
    }
}
