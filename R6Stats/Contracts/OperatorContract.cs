using System;
using Newtonsoft.Json;

namespace R6Stats.Contracts
{
    internal class OperatorContract
    {
        [JsonProperty("roundwon")]
        public int Wins { get; internal set; }

        [JsonProperty("roundlost")]
        public int Losses { get; internal set; }

        [JsonProperty("kills")]
        public int Kills { get; internal set; }

        [JsonProperty("death")]
        public int Deaths { get; internal set; }

        [JsonProperty("headshot")]
        public int Headshots { get; internal set; }

        [JsonProperty("meleekills")]
        public int Melees { get; internal set; }

        [JsonProperty("dbno")]
        public int Dbno { get; internal set; }

        [JsonProperty("totalxp")]
        public int Xp { get; internal set; }

        [JsonProperty("timeplayed")]
        public TimeSpan TimePlayed { get; internal set; }
    }
}