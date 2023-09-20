// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
using Newtonsoft.Json;
using System.Collections.Generic;

public class List
{
    [JsonProperty("dt")]
    public int Dt { get; set; }

    [JsonProperty("main")]
    public Main Main { get; set; }

    [JsonProperty("weather")]
    public List<Weather> Weather { get; set; }

    [JsonProperty("clouds")]
    public Clouds Clouds { get; set; }

    [JsonProperty("wind")]
    public Wind Wind { get; set; }

    [JsonProperty("visibility")]
    public int Visibility { get; set; }

    [JsonProperty("pop")]
    public int Pop { get; set; }

    [JsonProperty("sys")]
    public Sys Sys { get; set; }

    [JsonProperty("dt_txt")]
    public string DtTxt { get; set; }
}

