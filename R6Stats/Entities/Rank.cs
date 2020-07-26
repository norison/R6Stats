using R6Stats.Enums;

namespace R6Stats.Entities
{
    public class Rank
    {
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public float MaxMmr { get; internal set; }
        public float Mmr { get; internal set; }
        public int Wins { get; internal set; }
        public int Losses { get; internal set; }
        public int Abandons { get; internal set; }
        public int RankId { get; internal set; }
        public int SeasonId { get; internal set; }
        public float MaxRank { get; internal set; }
        public float NextRankMmr { get; internal set; }
        public float PreviousRankMmr { get; internal set; }
        public ERegion Region { get; internal set; }
        public float SkillMean { get; internal set; }
        public float SkillStDev { get; internal set; }

        internal Rank() { }
    }
}
