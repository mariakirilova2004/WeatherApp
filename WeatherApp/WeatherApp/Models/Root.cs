using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Models
{
    public class Root
    {

        [JsonProperty("list")]
        public List<List> List { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }
    }
}
