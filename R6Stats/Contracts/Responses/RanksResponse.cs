using Newtonsoft.Json;
using R6Stats.Contracts.Models;
using System.Collections.Generic;

namespace R6Stats.Contracts.Responses
{
    internal class RanksResponse
    {
        [JsonProperty("players")]
        public Dictionary<string, RankModel> RankContracts { get; set; }

    }
}
