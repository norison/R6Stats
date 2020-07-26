using Newtonsoft.Json;

namespace R6Stats.Contracts.Models
{
    internal class FigureModel
    {
        [JsonProperty("small")]
        public string Small { get; internal set; }

        [JsonProperty("large")]
        public string Large { get; internal set; }
    }
}
