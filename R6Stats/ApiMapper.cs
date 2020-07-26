using R6Stats.Contracts.Responses;
using R6Stats.Entities;

namespace R6Stats
{
    internal static class ApiMapper
    {
        public static Player GetMappedPlayer(Profile profile)
        {
            return new Player
            {
                UserId = profile.UserId,
                Platform = profile.Platform,
                Username = profile.NameOnPlatform
            };
        }

        public static Progression GetMappedProgresstion(PlayerProfiles profile)
        {
            return new Progression
            {
                Xp = profile.Xp,
                ProfileId = profile.ProfileId,
                LootboxProbability = profile.LootboxProbability,
                Level = profile.Level
            };
        }

        public static Rank GetMappedRank(RankContract rankContract)
        {
            return new Rank
            {
                Name = RankContract.RankNames[rankContract.RankId],
                IconUrl = RankContract.RankIcons[rankContract.RankId],
                MaxMmr = rankContract.MaxMmr,
                Mmr = rankContract.Mmr,
                Wins = rankContract.Wins,
                Losses = rankContract.Losses,
                Abandons = rankContract.Abandons,
                RankId = rankContract.RankId,
                SeasonId = rankContract.SeasonId,
                MaxRank = rankContract.MaxRank,
                NextRankMmr = rankContract.NextRankMmr,
                PreviousRankMmr = rankContract.PreviousRankMmr,
                Region = rankContract.Region,
                SkillMean = rankContract.SkillMean,
                SkillStDev = rankContract.SkillStDev
            };
        }
    }
}
