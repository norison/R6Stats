using R6Stats.Contracts.Models;
using System.Collections.Generic;

namespace R6Stats.Contracts.Responses
{
    internal class OperatorsResponse
    {
        public IDictionary<string, IList<OperatorModel>> OperatorModels { get; set; }
        public Dictionary<string, OperatorDefinition> OperatorDefinitions { get; set; }
    }
}
