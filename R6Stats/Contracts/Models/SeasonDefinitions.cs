using Newtonsoft.Json;
using System.Collections.Generic;

namespace R6Stats.Contracts.Models
{
    internal class SeasonDefinitions
    {
        [JsonProperty("latestSeason")]
        public int LatestSeason { get; set; }

        [JsonProperty("seasons")]
        public Dictionary<int, SeasonDefinition> Seasons { get; set; }
    }
}
