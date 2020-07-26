using R6Stats.Enums;
using System.Collections.Generic;

namespace R6Stats.Contracts.Requests
{
    internal class RanksRequest : CommonRequest
    {
        public string BoardId { get; set; }
        public IEnumerable<string> Profileids { get; set; }
        public EPlatform Platform { get; set; }
        public ERegion Region { get; set; }
        public int SeasonId { get; set; }
    }
}
