using System;
using System.Net;
using System.Text;
using R6Stats.Extensions;
using RestSharp;

namespace R6Stats.Exceptions
{
    public class RestException : Exception
    {
        #region Properties

        public HttpStatusCode HttpStatusCode { get; }
        public string RequestResource { get; }
        public string Content { get; }

        #endregion

        #region Constructor

        public RestException(HttpStatusCode httpStatusCode, string requestResource, string content, string message, Exception innerException) : base(message, innerException)
        {
            HttpStatusCode = httpStatusCode;
            RequestResource = requestResource;
            Content = content;
        }

        #endregion

        #region Public Methods

        public static RestException CreateException(IRestResponse response, string errorMessage = null)
        {
            var messageBuilder = new StringBuilder();

            messageBuilder.Append($"Resource: '{response.Request.Resource}', ");

            if (!response.StatusCode.IsScuccessStatusCode())
                messageBuilder.Append($"Status code: '{response.StatusDescription}', ");

            messageBuilder.Append(errorMessage == null
                ? $"Error Message: '{response.ErrorMessage}'"
                : $"Error Message: '{errorMessage}'");

            var innerException = response.ErrorException;

            return new RestException(response.StatusCode, response.Request.Resource, response.Content, messageBuilder.ToString(), innerException);
        }

        #endregion
    }
}
