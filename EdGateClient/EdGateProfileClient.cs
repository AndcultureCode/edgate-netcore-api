using AndcultureCode.EdGateClient.Extensions;
using AndcultureCode.EdGateClient.Interfaces;
using AndcultureCode.EdGateClient.Models;
using AndcultureCode.EdGateClient.Models.Profile;
using RestSharp;
using System;

namespace AndcultureCode.EdGateClient
{
    public class EdGateProfileClient : IEdGateProfileClient
    {
        #region Constants

        const string GET_PROFILE = "profile";


        #endregion

        #region Properties

        EdGateClientOptions Options   { get; set; }
        RestClient          WebClient { get; set; }

        #endregion

        #region Constructor

        internal EdGateProfileClient(EdGateClientOptions options, RestClient webClient)
        {
            Options   = options;
            WebClient = webClient;
        }

        #endregion

        #region IEdGateProfileClient Implementation

        public Profile GetProfile()
        {
            var request = BuildRequest(GET_PROFILE, Method.GET);
            SetAuthorization(request);

            var response = WebClient.Execute<Profile>(request);

            if (response.ResponseStatus == ResponseStatus.Completed && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Data;
            }

            if (!string.IsNullOrWhiteSpace(response.ErrorMessage))
            {
                throw new Exception(response.ErrorMessage);
            }

            if (!string.IsNullOrWhiteSpace(response.StatusDescription) && !string.IsNullOrWhiteSpace(response.Content))
            {
                throw new Exception($"{response.StatusDescription} || {response.Content}");
            }

            return null;
        }

        #endregion

        #region Private Methods


        RestRequest BuildRequest(string resource, Method method) => WebClient.BuildRequest(resource, method);
        void        SetAuthorization(RestRequest request)        => request.SetAuthorization(Options);

        #endregion
    }
}
