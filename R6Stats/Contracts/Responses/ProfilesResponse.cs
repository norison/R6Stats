using Newtonsoft.Json;
using R6Stats.Contracts.Models;

namespace R6Stats.Contracts.Responses
{
    internal class ProfilesResponse
    {
        [JsonProperty("profiles")]
        public ProfileModel[] Profiles { get; set; }
    }
}
