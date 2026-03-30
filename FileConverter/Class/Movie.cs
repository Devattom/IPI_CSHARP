using Newtonsoft.Json;

namespace FileConverter.Class;

public class Movie
{
    [JsonProperty("title")]
    public string Title { get; set; }
    
    [JsonProperty("release_year")]
    public string ReleaseYear { get; set; }
    
    [JsonProperty("producer")]
    public string Producer { get; set; }
}