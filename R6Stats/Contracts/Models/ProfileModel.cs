using Newtonsoft.Json;
using R6Stats.Converters;
using R6Stats.Enums;

namespace R6Stats.Contracts.Models
{
    internal class ProfileModel
    {
        [JsonProperty("ProfileId")]
        public string ProfileId { get; set; }

        [JsonProperty("UserId")]
        public string UserId { get; set; }

        [JsonConverter(typeof(PlatformTypeConverter))]
        [JsonProperty("PlatformType")]
        public EPlatform Platform { get; set; }

        [JsonProperty("IdOnPlatform")]
        public string IdOnPlatform { get; set; }

        [JsonProperty("NameOnPlatform")]
        public string NameOnPlatform { get; set; }
    }
}
