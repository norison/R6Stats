using Newtonsoft.Json;

namespace R6Stats.Contracts.Models
{
    internal class SeasonDefinition
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("background")]
        public string Background { get; set; }
    }
}
