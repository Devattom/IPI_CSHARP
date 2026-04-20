using Newtonsoft.Json;

namespace Optimiser.Class;

public class JsonImageUrls
{
    [JsonProperty("images")]
    public List<string> Images { get; set; }
}