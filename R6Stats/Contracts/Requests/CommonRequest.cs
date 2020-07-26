namespace R6Stats.Contracts.Requests
{
    internal class CommonRequest : BaseRequest
    {
        public string Ticket { get; set; }
        public string SessionId { get; set; }
    }
}
