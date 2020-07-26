using System.Collections.Generic;
using System.Threading.Tasks;
using R6Stats.Entities;
using R6Stats.Enums;

namespace R6Stats
{
    public interface IR6ApiClient
    {
        Task LoginAsync();

        Task<Player> GetPlayerFullStatsAsync(string username, EPlatform platform);
        Task<IEnumerable<Player>> GetPlayersFullStatsAsync(IEnumerable<string> usernames, EPlatform platform);

        Task<Player> GetPlayerAsync(string username, EPlatform platform);
        Task<IEnumerable<Player>> GetPlayersAsync(IEnumerable<string> usernames, EPlatform platform);

        Task<Progression> GetProgressionAsync(string profileId, EPlatform platform);
        Task<IEnumerable<Progression>> GetProgressionsAsync(IEnumerable<string> profileIds, EPlatform platform);

        Task<KeyValuePair<string, Rank>> GetRankAsync(string profileId, ERegion region, EPlatform platform, int season = -1);

        Task<IDictionary<string, Rank>> GetRanksAsync(IEnumerable<string> profileIds, ERegion region, EPlatform platform, int season = -1);

        Task<KeyValuePair<string, IEnumerable<Operator>>> GetOperatorsAsync(string profileId, EPlatform platform, EOperatorStatisticsType statisticsType);

        Task<IDictionary<string, IEnumerable<Operator>>> GetOperatorsAsync(IEnumerable<string> profileIds, EPlatform platform, EOperatorStatisticsType statisticsType);
    }
}
