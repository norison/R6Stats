using Newtonsoft.Json;
using R6Stats.Constants;
using R6Stats.Contracts.Requests;
using R6Stats.Contracts.Responses;
using R6Stats.Exceptions;
using R6Stats.Extensions;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace R6Stats
{
    internal class ApiManager : IApiManager
    {
        #region Private Fields

        private readonly IRestClient _restClient;

        #endregion

        #region Constructor

        public ApiManager(IRestClient restClient)
        {
            _restClient = restClient;
        }

        #endregion

        #region Public Static Methods

        public static void EnsureSuccessfulResponse(IRestResponse response)
        {
            if (response.IsSuccessful())
                return;

            if (response.ResponseStatus != ResponseStatus.Completed) throw RestException.CreateException(response);
            var error = JsonConvert.DeserializeObject<ErrorResponse>(response.Content);
            throw RestException.CreateException(response, error.Message);
        }

        #endregion

        #region Private Static Methods

        private static ICollection<KeyValuePair<string, string>> GetLoginHeaders(string token, string ubiAppId)
        {
            return new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Authorization", "Basic " + token),
                new KeyValuePair<string, string>("Ubi-AppId", ubiAppId),
                new KeyValuePair<string, string>("Content-Type", "application/json")
            };
        }

        private static ICollection<KeyValuePair<string, string>> GetCommonHeaders(string ticket, string ubiAppId, string sessionId)
        {
            return new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Authorization", "Ubi_v1 t=" + ticket),
                new KeyValuePair<string, string>("Ubi-AppId", ubiAppId),
                new KeyValuePair<string, string>("Ubi-SessionId", sessionId)
            };
        }

        #endregion

        #region Public Methods

        public async Task<LoginResponse> GetLoginResponseAsync(LoginRequest loginRequest)
        {
            var token = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{loginRequest.Email}:{loginRequest.Password}"));

            var request = new RestRequest(ApiRoutes.Sessions, Method.POST);
            request.AddHeaders(GetLoginHeaders(token, loginRequest.UbiAppId));

            return await ExecuteRequestAsync<LoginResponse>(request);
        }

        public async Task<ProfilesResponse> GetProfilesResponseAsync(ProfilesRequest profilesRequest)
        {
            var request = new RestRequest(ApiRoutes.Profiles, Method.GET);
            request.AddHeaders(GetCommonHeaders(profilesRequest.Ticket, profilesRequest.UbiAppId, profilesRequest.SessionId));
            request.AddParameter("nameOnPlatform", string.Join(",", profilesRequest.Names), ParameterType.QueryString);
            request.AddParameter("platformType", profilesRequest.Platform);

            return await ExecuteRequestAsync<ProfilesResponse>(request);
        }

        public async Task<ProgressionsResponse> GetProgressionsResponseAsync(ProgressionsRequest progressionsRequest)
        {
            var spaceId = progressionsRequest.Platform.ToSpaceIdValue();
            var url = progressionsRequest.Platform.ToUrlValue();
            var route = string.Format(ApiRoutes.Progressions, spaceId, url);

            var request = new RestRequest(route, Method.GET);
            request.AddHeaders(GetCommonHeaders(progressionsRequest.Ticket, progressionsRequest.UbiAppId, progressionsRequest.SessionId));
            request.AddParameter("profile_ids", string.Join(",", progressionsRequest.ProfileIds));

            return await ExecuteRequestAsync<ProgressionsResponse>(request);
        }

        public async Task<RanksResponse> GetRanksResponseAsync(RanksRequest ranksRequest)
        {
            var regionId = ranksRequest.Region.ToStringValue();
            var spaceId = ranksRequest.Platform.ToSpaceIdValue();
            var url = ranksRequest.Platform.ToUrlValue();
            var route = string.Format(ApiRoutes.Ranks, spaceId, url);

            var request = new RestRequest(route, Method.GET);
            request.AddHeaders(GetCommonHeaders(ranksRequest.Ticket, ranksRequest.UbiAppId, ranksRequest.SessionId));
            request.AddParameter("board_id", ranksRequest.BoardId);
            request.AddParameter("profile_ids", string.Join(",", ranksRequest.Profileids));
            request.AddParameter("region_id", regionId);
            request.AddParameter("season_id", ranksRequest.SeasonId);

            return await ExecuteRequestAsync<RanksResponse>(request);
        }

        #endregion

        #region Private Methods

        private async Task<T> ExecuteRequestAsync<T>(IRestRequest request)
        {
            var response = await _restClient.ExecuteAsync<T>(request);
            EnsureSuccessfulResponse(response);
            return response.Data;
        }

        #endregion
    }
}
