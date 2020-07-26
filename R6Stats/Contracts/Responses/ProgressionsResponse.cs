using Newtonsoft.Json;
using R6Stats.Contracts.Models;

namespace R6Stats.Contracts.Responses
{
    internal class ProgressionsResponse
    {
        [JsonProperty("player_profiles")]
        public ProgressionModel[] PlayerProfiles { get; set; }
    }
}
