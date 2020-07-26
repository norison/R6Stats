using Newtonsoft.Json;

namespace R6Stats.Contracts.Models
{
    internal class StatisticModel
    {
        [JsonProperty("statisticId")]
        public string StatisticId { get; set; }
    }
}
