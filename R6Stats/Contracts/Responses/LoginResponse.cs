using System;

namespace R6Stats.Contracts.Responses
{
    internal class LoginResponse
    {
        public string PlatformType { get; set; }
        public string Ticket { get; set; }
        public string ProfileId { get; set; }
        public string UserId { get; set; }
        public string NameOnPlatform { get; set; }
        public string Environment { get; set; }
        public DateTime Expiration { get; set; }
        public string SpaceId { get; set; }
        public string ClientIp { get; set; }
        public string ClientIpCountry { get; set; }
        public DateTime ServerTime { get; set; }
        public string SessionId { get; set; }
        public string SessionKey { get; set; }
        public string RememberMeTicket { get; set; }
    }
}
