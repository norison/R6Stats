using Newtonsoft.Json;
using R6Stats.Converters;
using R6Stats.Enums;
using System.Collections.Generic;

namespace R6Stats.Contracts.Responses
{
    internal class RanksResponse
    {
        [JsonProperty("players")]
        public Dictionary<string, RankContract> RankContracts { get; set; }

    }

    public class RankContract
    {
        public static List<string> RankNames = new List<string>
        {
            "Unranked",
            "Copper 5",   "Copper 4",   "Copper 3",   "Copper 2",   "Copper 1",
            "Bronze 5",   "Bronze 4",   "Bronze 3",   "Bronze 2",   "Bronze 1",
            "Silver 5",   "Silver 4",   "Silver 3",   "Silver 2",   "Silver 1",
            "Gold 3",     "Gold 2",     "Gold 1",
            "Platinum 3", "Platinum 2", "Platinum 1",
            "Diamond",
            "Champion"
        };

        public static List<string> RankIcons = new List<string>
        {
            //unranked
                "https://i.imgur.com/sB11BIz.png",  // unranked
            
            //copper
                "https://i.imgur.com/0J0jSWB.jpg",  // copper 1
                "https://i.imgur.com/eI11lah.jpg",  // copper 2
                "https://i.imgur.com/6CxJoMn.jpg",  // copper 3
                "https://i.imgur.com/ehILQ3i.jpg",  // copper 4
                "https://i.imgur.com/B8NCTyX.png",  // copper 5

            //bronze
                "https://i.imgur.com/hmPhPBj.jpg",  // bronze 1
                "https://i.imgur.com/9AORiNm.jpg",  // bronze 2
                "https://i.imgur.com/QD5LYD7.jpg",  // bronze 3
                "https://i.imgur.com/42AC7RD.jpg",  // bronze 4
                "https://i.imgur.com/TIWCRyO.png",  // bronze 5

            //silver
                "https://i.imgur.com/KmFpkNc.jpg",  // silver 1
                "https://i.imgur.com/EswGcx1.jpg",  // silver 2
                "https://i.imgur.com/m8GToyF.jpg",  // silver 3
                "https://i.imgur.com/D36ZfuR.jpg",  // silver 4
                "https://i.imgur.com/PY2p17k.png",  // silver 5

            //gold
                "https://i.imgur.com/ffDmiPk.jpg",  // gold 1
                "https://i.imgur.com/ELbGMc7.jpg",  // gold 2
                "https://i.imgur.com/B0s1o1h.jpg",  // gold 3,
                "https://i.imgur.com/6Qg6aaH.jpg",  // gold 4

            //platinum
                "https://i.imgur.com/qDYwmah.png",  // plat 1
                "https://i.imgur.com/CYMO3Er.png",  // plat 2
                "https://i.imgur.com/tmcWQ6I.png",  // plat 3

            //diamond
                "https://i.imgur.com/37tSxXm.png",  // diamond

            //champion
                "https://i.imgur.com/VlnwLGk.png"   // champion
        };

        [JsonProperty("max_mmr")]
        public float MaxMmr { get; internal set; }

        [JsonProperty("mmr")]
        public float Mmr { get; internal set; }

        [JsonProperty("wins")]
        public int Wins { get; internal set; }

        [JsonProperty("losses")]
        public int Losses { get; internal set; }

        [JsonProperty("abandons")]
        public int Abandons { get; internal set; }

        [JsonProperty("rank")]
        public int RankId { get; internal set; }

        [JsonProperty("season")]
        public int SeasonId { get; internal set; }

        [JsonProperty("max_rank")]
        public float MaxRank { get; internal set; }

        [JsonProperty("next_rank_mmr")]
        public float NextRankMmr { get; internal set; }

        [JsonProperty("previous_rank_mmr")]
        public float PreviousRankMmr { get; internal set; }

        [JsonConverter(typeof(RegionConverter))]
        [JsonProperty("region")]
        public ERegion Region { get; internal set; }

        [JsonProperty("skill_mean")]
        public float SkillMean { get; internal set; }

        [JsonProperty("skill_stdev")]
        public float SkillStDev { get; internal set; }
    }

}
