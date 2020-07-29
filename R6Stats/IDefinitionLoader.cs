using System.Collections.Generic;
using System.Threading.Tasks;
using R6Stats.Contracts.Models;

namespace R6Stats
{
    internal interface IDefinitionLoader
    {
        Task UpdateApiEndpointsAsync();
        Task<IDictionary<string, OperatorDefinition>> GetOperatorDefinitionsAsync();
        Task<IDictionary<string, WeaponDefinition>> GetWeaponDefinitionsAsync();
        Task<SeasonDefinitions> GetSeasonDefinitionsAsync();
    }
}
