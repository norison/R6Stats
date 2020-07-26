using Newtonsoft.Json;
using R6Stats.Contracts.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace R6Stats.Helpers
{
    internal static class ApiHelper
    {
        public static async Task<Dictionary<string, OperatorDefinitionModel>> LoadOperatorDefinitionsAsync(string operatorsEndpoint)
        {
            using var wc = new WebClient();
            var json = await wc.DownloadStringTaskAsync(operatorsEndpoint);
            return JsonConvert.DeserializeObject<Dictionary<string, OperatorDefinitionModel>>(json);
        }

        public static IDictionary<string, IList<OperatorModel>> GetOperators(IEnumerable<string> profileIds, IDictionary<string, OperatorDefinitionModel> operatorDefinition, string jsonContent)
        {
            var operatorModels = new Dictionary<string, IList<OperatorModel>>();
            var data = JsonConvert.DeserializeObject<JObject>(jsonContent);

            foreach (var profileId in profileIds)
            {
                var result = data["results"]?[profileId];
                if (result == null) continue;

                foreach (var opDef in operatorDefinition.Values)
                {
                    var location = $":{opDef.Index}:";
                    var values = result.Where(x => x.Path.Contains(location));

                    if (!values.Any()) continue;

                    var opData = '{' + string.Join(",", values.Select(x => "\"" + x.Path.Split(':')[0].Split('_')[1] + "\":" + x.First)) + '}';
                    var model = JsonConvert.DeserializeObject<OperatorModel>(opData);
                    model.OperatorDefinition = opDef;

                    if (operatorModels.ContainsKey(profileId))
                        operatorModels[profileId].Add(model);
                    else
                        operatorModels.Add(profileId, new List<OperatorModel> { model });
                }
            }

            return operatorModels;
        }
    }
}
