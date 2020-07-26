using Newtonsoft.Json;

namespace R6Stats.Contracts.Models
{
    internal class ProgressionModel
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
