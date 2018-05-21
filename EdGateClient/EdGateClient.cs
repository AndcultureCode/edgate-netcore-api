using AndcultureCode.EdGateClient.Interfaces;
using AndcultureCode.EdGateClient.Models;
using RestSharp;
using System;

namespace AndcultureCode.EdGateClient
{
    public class EdGateClient : IEdGateClient
    {
        #region Constants

        protected const string BASE_URL = "https://api.edgate.com/";

        #endregion

        #region Properties

        EdGateClientOptions Options { get; set; }
        RestClient WebClient { get; set; }

        public IEdGateProfileClient    Profile   { get; set; }
        public IEdGateStandardsClient  Standards { get; set; }

        #endregion

        #region Constructor

        public EdGateClient(EdGateClientOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options), "No options provided for EdGate client");
            }

            if (string.IsNullOrWhiteSpace(options.EdGatePrivateKey))
            {
                throw new Exception("No private api key provided for EdGate client");
            }

            if (string.IsNullOrWhiteSpace(options.EdGatePublicKey))
            {
                throw new Exception("No public api key provided for EdGate client");
            }

            Options = options;
            if (string.IsNullOrWhiteSpace(Options.EdGateApiBaseUrl))
            {
                Options.EdGateApiBaseUrl = BASE_URL;
            }

            WebClient = new RestClient(options.EdGateApiBaseUrl);

            Profile   = new EdGateProfileClient(Options, WebClient);
            Standards = new EdGateStandardsClient(Options, WebClient);
        }

        #endregion
    }
}
