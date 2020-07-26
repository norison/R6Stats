using Newtonsoft.Json;

namespace R6Stats.Contracts.Responses
{
    internal class ProgressionsResponse
    {
        [JsonProperty("player_profiles")]
        public PlayerProfiles[] PlayerProfiles { get; set; }
    }

    public class PlayerProfiles
    {
        [JsonProperty("xp")]
        public int Xp { get; set; }

        [JsonProperty("profile_id")]
        public string ProfileId { get; set; }

        [JsonProperty("lootbox_probability")]
        public int LootboxProbability { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }
    }

}
