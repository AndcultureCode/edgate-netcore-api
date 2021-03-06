﻿namespace AndcultureCode.EdGateClient.Models
{
    public class EdGateClientOptions
    {
        /// <summary>
        /// Base Url for api requests. Defaults to "https://api.edgate.com/"
        /// </summary>
        public string EdGateApiBaseUrl { get; set; }

        /// <summary>
        /// Public api key generated by EdGate. http://correlation.edgate.com/api/docs/authentication
        /// </summary>
        public string EdGatePublicKey { get; set; }

        /// <summary>
        /// Private api key generated by EdGate. http://correlation.edgate.com/api/docs/authentication
        /// </summary>
        public string EdGatePrivateKey { get; set; }
    }
}
