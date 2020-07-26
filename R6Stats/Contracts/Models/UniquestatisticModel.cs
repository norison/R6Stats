using Newtonsoft.Json;

namespace R6Stats.Contracts.Models
{
    internal class UniquestatisticModel
    {
        [JsonProperty("pvp")]
        public StatisticModel PvpModel { get; set; }

        [JsonProperty("pve")]
        public StatisticModel PveModel { get; set; }
    }
}
