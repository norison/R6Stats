using RestSharp;
using System.Net;

namespace R6Stats.Extensions
{
    internal static class RestSharpExtensions
    {
        public static bool IsScuccessStatusCode(this HttpStatusCode responseCode)
        {
            var numericResponse = (int)responseCode;

            const int statusCodeOk = (int)HttpStatusCode.OK;

            const int statusCodeBadRequest = (int)HttpStatusCode.BadRequest;

            return numericResponse >= statusCodeOk &&
                   numericResponse < statusCodeBadRequest;
        }

        public static bool IsSuccessful(this IRestResponse response)
        {
            return response.StatusCode.IsScuccessStatusCode() &&
                   response.ResponseStatus == ResponseStatus.Completed;
        }
    }
}
