using Newtonsoft.Json;

namespace R6Stats.Contracts.Models
{
    internal class WeaponDefinition
    {
        [JsonProperty("id")]
        public string Name { get; set; }

        [JsonProperty("index")]
        public int Index { get; set; }
    }
}
