using Newtonsoft.Json;
using R6Stats.Converters;
using R6Stats.Enums;

namespace R6Stats.Models
{
    public class OperatorDefinition
    {
        [JsonProperty("id")]
        public string Id { get; internal set; }

        [JsonProperty("category")]
        [JsonConverter(typeof(OperatorCategoryConverter))]
        public EOperatorCategory Category { get; internal set; }

        [JsonProperty("index")]
        public string Index { get; internal set; }

        [JsonProperty("figure")]
        public Figure Figure { get; internal set; }

        [JsonProperty("mask")]
        public string Mask { get; internal set; }

        [JsonProperty("badge")]
        public string Badge { get; internal set; }

        [JsonProperty("uniqueStatistic")]
        public Uniquestatistic UniqueStatistic { get; internal set; }
    }

    public class Figure
    {
        [JsonProperty("small")]
        public string Small { get; internal set; }

        [JsonProperty("large")]
        public string Large { get; internal set; }
    }

    public class Uniquestatistic
    {
        [JsonProperty("pvp")]
        public Pvp Pvp { get; internal set; }

        [JsonProperty("pve")]
        public Pve Pve { get; internal set; }
    }

    public class Pvp
    {
        [JsonProperty("statisticId")]
        public string StatisticId { get; internal set; }
    }

    public class Pve
    {
        [JsonProperty("statisticId")]
        public string StatisticId { get; internal set; }
    }
}
