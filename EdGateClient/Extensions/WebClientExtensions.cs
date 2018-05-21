using RestSharp;
using RestSharp.Serializers;

namespace AndcultureCode.EdGateClient.Extensions
{
    public static class WebClientExtensions
    {
        public static RestRequest BuildRequest(this RestClient webClient, string resource, Method method)
        {
            var request            = new RestRequest(resource, method);
            request.JsonSerializer = new NewtonsoftJsonSerializer();

            return request;
        }
    }
}
