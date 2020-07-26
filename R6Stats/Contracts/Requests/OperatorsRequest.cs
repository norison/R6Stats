using System.Collections.Generic;
using R6Stats.Enums;

namespace R6Stats.Contracts.Requests
{
    internal class OperatorsRequest : CommonRequest
    {
        public IEnumerable<string> ProfileIds { get; set; }
        public EPlatform Platform { get; set; }
        public EOperatorStatisticsType StatisticsType { get; set; }
    }
}
