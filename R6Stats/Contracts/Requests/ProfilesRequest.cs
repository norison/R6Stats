using System.Collections.Generic;
using R6Stats.Enums;

namespace R6Stats.Contracts.Requests
{
    internal class ProfilesRequest : CommonRequest
    {
        public EPlatform Platform { get; set; }
        public IEnumerable<string> Names { get; set; }
    }
}
