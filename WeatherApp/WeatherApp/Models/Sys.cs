// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
using Newtonsoft.Json;

public class Sys
{
    [JsonProperty("pod")]
    public string Pod { get; set; }
}

