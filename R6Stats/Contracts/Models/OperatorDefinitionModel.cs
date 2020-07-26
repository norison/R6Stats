using Newtonsoft.Json;
using R6Stats.Converters;
using R6Stats.Enums;

namespace R6Stats.Contracts.Models
{
    internal class OperatorDefinitionModel
    {
        [JsonProperty("id")]
        public string Id { get; internal set; }

        [JsonConverter(typeof(OperatorCategoryConverter))]
        [JsonProperty("category")]
        public EOperatorCategory Category { get; internal set; }

        [JsonProperty("index")]
        public string Index { get; internal set; }

        [JsonProperty("figure")]
        public FigureModel FigureModel { get; internal set; }

        [JsonProperty("mask")]
        public string Mask { get; internal set; }

        [JsonProperty("badge")]
        public string Badge { get; internal set; }

        public UniquestatisticModel UniquestatisticModel { get; internal set; }
    }
}
