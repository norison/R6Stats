using R6Stats.Contracts.Requests;
using R6Stats.Contracts.Responses;
using System.Threading.Tasks;

namespace R6Stats
{
    internal interface IApiManager
    {
        Task<LoginResponse> GetLoginResponseAsync(LoginRequest loginRequest);
        Task<ProfilesResponse> GetProfilesResponseAsync(ProfilesRequest profilesRequest);
        Task<ProgressionsResponse> GetProgressionsResponseAsync(ProgressionsRequest progressionsRequest);
        Task<RanksResponse> GetRanksResponseAsync(RanksRequest ranksRequest);
        Task<OperatorsResponse> GetOperatorsResponseAsync(OperatorsRequest operatorsRequest);
    }
}
