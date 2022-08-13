using Newtonsoft.Json;

namespace TheVault.Models
{
    internal class ConfigJson
    {
        [JsonProperty("ConnectionString")]
        public string? ConnectionString { get; set; }
    }
}
