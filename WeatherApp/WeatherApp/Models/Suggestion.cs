using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WeatherApp.Models
{
    public class Suggestion
    {
        public List<SuggestionCity> ListCities { get; set; }
    }
}
