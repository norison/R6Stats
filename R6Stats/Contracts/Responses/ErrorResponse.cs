using System;

namespace R6Stats.Contracts.Responses
{
    internal class ErrorResponse
    {
        public string ErrorCode { get; set; }
        public string Message { get; set; }
        public int HttpCode { get; set; }
        public string ErrorContext { get; set; }
        public string MoreInfo { get; set; }
        public DateTime TransactionTime { get; set; }
        public string TransactionId { get; set; }
        public string Environment { get; set; }
    }
}
