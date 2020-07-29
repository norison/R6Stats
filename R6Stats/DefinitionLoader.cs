using Newtonsoft.Json;
using R6Stats.Constants;
using R6Stats.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace R6Stats
{
    internal class DefinitionLoader : IDefinitionLoader
    {
        #region Private Fields

        private IDictionary<string, OperatorDefinition> _operatorDefinitions;
        private IDictionary<string, WeaponDefinition> _weaponDefinitions;
        private SeasonDefinitions _seasonDefinitions;

        #endregion

        #region Properties

        public string OperatorDefinitionsUrl { get; private set; } = ApiRoutes.RainbowSixBaseUrl + "assets/data/operators.d72ec5b825.json";
        public string SeasonDefinitionsUrl { get; private set; } = ApiRoutes.RainbowSixBaseUrl + "assets/data/seasons.3a4769b878.json";
        public string WeaponDefinitionsUrl { get; private set; } = ApiRoutes.RainbowSixBaseUrl + "assets/data/weapons.8a9b3d9e7d.json";

        #endregion

        #region Public Methods

        public async Task UpdateApiEndpointsAsync()
        {
            const string mainSearch = "<script src=\"assets/scripts/main.";
            const string endSearch = ".js\"></script>";
            const string json = ".json";

            string FindBetween(string str, string start, string end)
            {
                var startPos = str.IndexOf(start, StringComparison.Ordinal) + start.Length;
                var endPos = str.IndexOf(end, startPos, StringComparison.Ordinal);

                return str[startPos..endPos];
            }

            using var wc = new WebClient();
            var html = await wc.DownloadStringTaskAsync(ApiRoutes.RainbowSixBaseUrl);
            var mainUrl = ApiRoutes.RainbowSixBaseUrl + "assets/scripts/main." + FindBetween(html, mainSearch, endSearch) + ".js";
            var mainJs = await wc.DownloadStringTaskAsync(mainUrl);

            OperatorDefinitionsUrl = ApiRoutes.RainbowSixBaseUrl + "assets/data/operators." + FindBetween(mainJs, "assets/data/operators.", json) + json;
            WeaponDefinitionsUrl = ApiRoutes.RainbowSixBaseUrl + "assets/data/weapons." + FindBetween(mainJs, "assets/data/weapons.", json) + json;
            SeasonDefinitionsUrl = ApiRoutes.RainbowSixBaseUrl + "assets/data/seasons." + FindBetween(mainJs, "assets/data/seasons.", json) + json;
        }

        public async Task<IDictionary<string, OperatorDefinition>> GetOperatorDefinitionsAsync()
        {
            if (_operatorDefinitions == null)
            {
                using var wc = new WebClient();
                var json = await wc.DownloadStringTaskAsync(OperatorDefinitionsUrl);
                _operatorDefinitions = JsonConvert.DeserializeObject<IDictionary<string, OperatorDefinition>>(json);
            }

            return _operatorDefinitions;
        }

        public async Task<IDictionary<string, WeaponDefinition>> GetWeaponDefinitionsAsync()
        {
            if (_weaponDefinitions == null)
            {
                using var wc = new WebClient();
                var json = await wc.DownloadStringTaskAsync(WeaponDefinitionsUrl);
                _weaponDefinitions = JsonConvert.DeserializeObject<IDictionary<string, WeaponDefinition>>(json);
            }

            return _weaponDefinitions;
        }

        public async Task<SeasonDefinitions> GetSeasonDefinitionsAsync()
        {
            if (_seasonDefinitions == null)
            {
                using var wc = new WebClient();
                var json = await wc.DownloadStringTaskAsync(SeasonDefinitionsUrl);
                _seasonDefinitions = JsonConvert.DeserializeObject<SeasonDefinitions>(json);
            }

            return _seasonDefinitions;
        }

        #endregion
    }
}
