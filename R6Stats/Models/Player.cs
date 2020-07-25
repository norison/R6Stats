using System.Collections.Generic;
using Newtonsoft.Json;

namespace R6Stats.Models
{
    public class Player
    {
        [JsonProperty("profileId")]
        public string ProfileId { get; internal set; }

        [JsonProperty("userId")]
        public string UserId { get; internal set; }

        [JsonProperty("platformType")]
        public string PlatformType { get; internal set; }

        [JsonProperty("idOnPlatform")]
        public string IdOnPlatform { get; internal set; }

        [JsonProperty("nameOnPlatform")]
        public string NameOnPlatform { get; internal set; }

        public List<Operator> Operators { get; internal set; }
    }
}
