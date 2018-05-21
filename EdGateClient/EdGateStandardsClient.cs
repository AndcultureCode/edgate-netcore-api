using AndcultureCode.EdGateClient.Extensions;
using AndcultureCode.EdGateClient.Interfaces;
using AndcultureCode.EdGateClient.Models;
using AndcultureCode.EdGateClient.Models.Standards;
using EdGateClient.Models.Standards;
using RestSharp;
using System;
using System.Collections.Generic;

namespace AndcultureCode.EdGateClient
{
    public class EdGateStandardsClient : IEdGateStandardsClient
    {
        #region Constants

        const string EXPORT_STANDARDS            = "standards/export/{standardsSetId}";
        const string EXPORT_STANDARDS_BY_SUBJECT = "standards/export/{standardsSetId}/{subject}";
        const string GET_LIST_STANDARDSSETS      = "standards";
        const string GET_LIST_STANDARDS_BYSET    = "standards/list/{standardsSetId}";
        const string GET_STANDARD                = "standards/{standardId}";


        #endregion

        #region Properties

        EdGateClientOptions Options     { get; set; }
        RestClient          WebClient   { get; set; }

        #endregion

        #region Constructor

        internal EdGateStandardsClient(EdGateClientOptions options, RestClient webClient)
        {
            Options   = options;
            WebClient = webClient;
        }

        #endregion

        #region IEdGateStandardsClient Implementation

        public List<Standard> ExportStandards(string standardsSetId, string subject = "")
        {
            var request = BuildRequest(EXPORT_STANDARDS, Method.GET);
            request.AddParameter("standardsSetId", standardsSetId, ParameterType.UrlSegment);
            if (!string.IsNullOrWhiteSpace(subject))
            {
                request.Resource = EXPORT_STANDARDS_BY_SUBJECT;
                request.AddParameter("subject", subject, ParameterType.UrlSegment);
            }
            SetAuthorization(request);

            var response = WebClient.Execute<List<Standard>>(request);

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

        public List<StandardsSet> GetStandardsSets()
        {
            var request = BuildRequest(GET_LIST_STANDARDSSETS, Method.GET);
            SetAuthorization(request);

            var response = WebClient.Execute<List<StandardsSet>>(request);

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

        public List<Standard> GetStandardsBySet(string standardsSetId, string subject, string grade, bool correlate)
        {
            var request = BuildRequest(GET_LIST_STANDARDS_BYSET, Method.GET);
            request.AddParameter("standardsSetId", standardsSetId, ParameterType.UrlSegment);
            request.AddParameter("subject", subject, ParameterType.QueryString);
            request.AddParameter("grade", grade, ParameterType.QueryString);
            request.AddParameter("correlate", correlate.ToString().ToLower(), ParameterType.QueryString);
            SetAuthorization(request);

            var response = WebClient.Execute<List<Standard>>(request);

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

        public Standard GetStandard(string standardId)
        {
            var request = BuildRequest(GET_STANDARD, Method.GET);
            request.AddParameter("standardId", standardId, ParameterType.UrlSegment);
            SetAuthorization(request);

            var response = WebClient.Execute<Standard>(request);

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
