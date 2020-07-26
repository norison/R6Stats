using Newtonsoft.Json;
using R6Stats.Converters;
using R6Stats.Enums;

namespace R6Stats.Contracts
{
    internal class OperatorDefinitionContract
    {
        [JsonProperty("id")]
        public string Id { get; internal set; }

        [JsonProperty("category")]
        [JsonConverter(typeof(OperatorCategoryConverter))]
        public EOperatorCategory Category { get; internal set; }

        [JsonProperty("index")]
        public string Index { get; internal set; }

        [JsonProperty("figure")]
        public FigureContract FigureContract { get; internal set; }

        [JsonProperty("mask")]
        public string Mask { get; internal set; }

        [JsonProperty("badge")]
        public string Badge { get; internal set; }

        [JsonProperty("uniqueStatistic")]
        public UniquestatisticContract UniqueStatistic { get; internal set; }
    }

    internal class FigureContract
    {
        [JsonProperty("small")]
        public string Small { get; internal set; }

        [JsonProperty("large")]
        public string Large { get; internal set; }
    }

    internal class UniquestatisticContract
    {
        [JsonProperty("pvp")]
        public PvpContract PvpContract { get; internal set; }

        [JsonProperty("pve")]
        public PveContract PveContract { get; internal set; }
    }

    internal class PvpContract
    {
        [JsonProperty("statisticId")]
        public string StatisticId { get; internal set; }
    }

    internal class PveContract
    {
        [JsonProperty("statisticId")]
        public string StatisticId { get; internal set; }
    }
}
