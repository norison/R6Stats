using R6Stats.Contracts.Models;
using R6Stats.Entities;

namespace R6Stats
{
    internal static class ApiMapper
    {
        public static Player GetMappedPlayer(ProfileModel profileModel)
        {
            return new Player
            {
                UserId = profileModel.UserId,
                Platform = profileModel.Platform,
                Username = profileModel.NameOnPlatform
            };
        }

        public static Progression GetMappedProgresstion(ProgressionModel profile)
        {
            return new Progression
            {
                Xp = profile.Xp,
                ProfileId = profile.ProfileId,
                LootboxProbability = profile.LootboxProbability,
                Level = profile.Level
            };
        }

        public static Rank GetMappedRank(RankModel rankModel)
        {
            return new Rank
            {
                Name = RankModel.RankNames[rankModel.RankId],
                IconUrl = RankModel.RankIcons[rankModel.RankId],
                MaxMmr = rankModel.MaxMmr,
                Mmr = rankModel.Mmr,
                Wins = rankModel.Wins,
                Losses = rankModel.Losses,
                Abandons = rankModel.Abandons,
                RankId = rankModel.RankId,
                SeasonId = rankModel.SeasonId,
                MaxRank = rankModel.MaxRank,
                NextRankMmr = rankModel.NextRankMmr,
                PreviousRankMmr = rankModel.PreviousRankMmr,
                Region = rankModel.Region,
                SkillMean = rankModel.SkillMean,
                SkillStDev = rankModel.SkillStDev
            };
        }

        public static Operator GetMappedOperator(OperatorModel operatorModel)
        {
            var opDef = operatorModel.OperatorDefinition;
            var kd = (double)operatorModel.Kills / operatorModel.Deaths;
            var wl = (double) operatorModel.Wins / operatorModel.Wins + operatorModel.Losses * 100;

            return new Operator
            {
                Name = opDef.Id,
                Kd = kd,
                Wl = wl,
                Wins = operatorModel.Wins,
                Losses = operatorModel.Losses,
                Kills = operatorModel.Kills,
                Deaths = operatorModel.Deaths,
                Headshots = operatorModel.Headshots,
                Melees = operatorModel.Melees,
                Dbno = operatorModel.Dbno,
                Xp = operatorModel.Xp,
                TimePlayed = operatorModel.TimePlayed,
                BadgeUrl = opDef.Badge,
                MaskUrl = opDef.Mask,
                SmallFigureUrl = opDef.FigureModel.Small,
                LargeFigureUrl = opDef.FigureModel.Large,
                OperatorCategory = opDef.Category
            };
        }
    }
}
