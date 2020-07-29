using R6Stats.Contracts.Requests;
using R6Stats.Entities;
using R6Stats.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace R6Stats
{
    internal class R6ApiClient : IR6ApiClient
    {
        #region Private Fields

        private readonly Settings _settings;
        private readonly IApiManager _apiManager;
        private string _ticket;
        private string _sessionId;

        #endregion

        #region Constructor

        internal R6ApiClient(IApiManager apiManager, Settings settings)
        {
            _apiManager = apiManager;
            _settings = settings;
        }

        #endregion

        #region Public Methods

        public async Task LoginAsync()
        {
            var loginRequest = new LoginRequest
            {
                UbiAppId = _settings.UbiAppId,
                Email = _settings.Email,
                Password = _settings.Password,
                IsRememberMe = true
            };

            var response = await _apiManager.GetLoginResponseAsync(loginRequest);
            _ticket = response.Ticket;
            _sessionId = response.SessionId;
        }


        public async Task<Player> GetPlayerFullStatsAsync(string username, EPlatform platform)
        {
            var player = await GetPlayerAsync(username, platform);

            var progressionTask = GetProgressionAsync(player.UserId, platform);

            await Task.WhenAll(progressionTask);

            player.Progression = progressionTask.Result;

            return player;
        }
        public async Task<IEnumerable<Player>> GetPlayersFullStatsAsync(IEnumerable<string> usernames, EPlatform platform)
        {
            if (usernames == null) throw new ArgumentNullException(nameof(usernames));
            if (!Enum.IsDefined(typeof(EPlatform), platform))
                throw new InvalidEnumArgumentException(nameof(platform), (int)platform, typeof(EPlatform));

            var tasks = usernames.Select(username => GetPlayerFullStatsAsync(username, platform));
            await Task.WhenAll(tasks);

            return tasks.Select(task => task.Result);
        }


        public async Task<Player> GetPlayerAsync(string username, EPlatform platform)
        {
            var players = await GetPlayersAsync(new[] { username }, platform);
            return players.FirstOrDefault();
        }
        public async Task<IEnumerable<Player>> GetPlayersAsync(IEnumerable<string> usernames, EPlatform platform)
        {
            if (usernames == null) throw new ArgumentNullException(nameof(usernames));
            if (!Enum.IsDefined(typeof(EPlatform), platform))
                throw new InvalidEnumArgumentException(nameof(platform), (int)platform, typeof(EPlatform));

            var playersRequest = new ProfilesRequest
            {
                UbiAppId = _settings.UbiAppId,
                Ticket = _ticket,
                SessionId = _sessionId,
                Platform = platform,
                Names = usernames
            };

            var profilesResponse = await _apiManager.GetProfilesResponseAsync(playersRequest);
            return profilesResponse.Profiles.Select(ApiMapper.GetMappedPlayer);
        }


        public async Task<Progression> GetProgressionAsync(string profileId, EPlatform platform)
        {
            var profiles = await GetProgressionsAsync(new[] { profileId }, platform);
            return profiles.FirstOrDefault();
        }
        public async Task<IEnumerable<Progression>> GetProgressionsAsync(IEnumerable<string> profileIds, EPlatform platform)
        {
            if (profileIds == null) throw new ArgumentNullException(nameof(profileIds));
            if (!Enum.IsDefined(typeof(EPlatform), platform))
                throw new InvalidEnumArgumentException(nameof(platform), (int)platform, typeof(EPlatform));

            var progressionRequest = new ProgressionsRequest
            {
                UbiAppId = _settings.UbiAppId,
                Ticket = _ticket,
                SessionId = _sessionId,
                ProfileIds = profileIds,
                Platform = platform
            };

            var progressionsReposne = await _apiManager.GetProgressionsResponseAsync(progressionRequest);
            return progressionsReposne.PlayerProfiles.Select(ApiMapper.GetMappedProgresstion);
        }

        public async Task<KeyValuePair<string, Rank>> GetRankAsync(string profileId, ERegion region, EPlatform platform, int season = -1)
        {
            var ranks = await GetRanksAsync(new[] { profileId }, region, platform, season);
            return ranks.FirstOrDefault();
        }
        public async Task<IDictionary<string, Rank>> GetRanksAsync(IEnumerable<string> profileIds, ERegion region, EPlatform platform, int season = -1)
        {
            var ranksRequest = new RanksRequest
            {
                UbiAppId = _settings.UbiAppId,
                Ticket = _ticket,
                SessionId = _sessionId,
                BoardId = "pvp_ranked",
                Profileids = profileIds,
                Platform = platform,
                Region = region,
                SeasonId = season
            };

            var ranksResponse = await _apiManager.GetRanksResponseAsync(ranksRequest);
            return ranksResponse.RankContracts.ToDictionary(r => r.Key, r => ApiMapper.GetMappedRank(r.Value));
        }

        public async Task<KeyValuePair<string, IEnumerable<Operator>>> GetOperatorsAsync(string profileId, EPlatform platform, EOperatorStatisticsType statisticsType)
        {
            var operators = await GetOperatorsAsync(new[] { profileId }, platform, statisticsType);
            return operators.FirstOrDefault();
        }
        public async Task<IDictionary<string, IEnumerable<Operator>>> GetOperatorsAsync(IEnumerable<string> profileIds, EPlatform platform, EOperatorStatisticsType statisticsType)
        {
            if (profileIds == null) throw new ArgumentNullException(nameof(profileIds));

            if (!Enum.IsDefined(typeof(EPlatform), platform))
                throw new InvalidEnumArgumentException(nameof(platform), (int) platform, typeof(EPlatform));

            if (!Enum.IsDefined(typeof(EOperatorStatisticsType), statisticsType))
                throw new InvalidEnumArgumentException(nameof(statisticsType), (int) statisticsType,
                    typeof(EOperatorStatisticsType));

            var operatorsRequest = new OperatorsRequest
            {
                UbiAppId = _settings.UbiAppId,
                Ticket = _ticket,
                SessionId = _sessionId,
                ProfileIds = profileIds,
                Platform = platform,
                StatisticsType = statisticsType
            };

            var response = await _apiManager.GetOperatorsResponseAsync(operatorsRequest);
            return response.OperatorModels.ToDictionary(o => o.Key, o => o.Value.Select(ApiMapper.GetMappedOperator));
        }

        #endregion
    }
}
