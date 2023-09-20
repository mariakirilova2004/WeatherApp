// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
using Newtonsoft.Json;

public class Clouds
{
    [JsonProperty("all")]
    public int All { get; set; }
}

