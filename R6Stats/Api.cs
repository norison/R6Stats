using R6Stats.Constants;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System;

namespace R6Stats
{
    public static class Api
    {
        public static IR6ApiClient GetInitializedClient(Settings settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            var restClient = new RestClient(ApiRoutes.UbiServicesBaseUrl);
            restClient.UseNewtonsoftJson();
            restClient.RemoteCertificateValidationCallback = (sender, certificate, chain, errors) => true;

            var definitionsLoader = new DefinitionLoader();

            var apiManager = new ApiManager(restClient, definitionsLoader);

            return new R6ApiClient(apiManager, settings);
        }
    }
}
