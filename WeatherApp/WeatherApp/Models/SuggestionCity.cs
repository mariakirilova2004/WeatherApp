using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace WeatherApp.Models
{
    public class SuggestionCity
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("lat")]
        public double Lat;

        [JsonProperty("lon")]
        public double Lon;

        [JsonProperty("country")]
        public string Country;

        [JsonProperty("state")]
        public string State;
    }
}