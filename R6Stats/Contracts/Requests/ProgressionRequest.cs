using System.Collections.Generic;
using R6Stats.Enums;

namespace R6Stats.Contracts.Requests
{
    internal class ProgressionsRequest : CommonRequest
    {
        public IEnumerable<string> ProfileIds { get; set; }
        public EPlatform Platform { get; set; }
    }
}
