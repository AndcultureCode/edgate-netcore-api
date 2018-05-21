using AndcultureCode.EdGateClient.Models;
using RestSharp;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace AndcultureCode.EdGateClient.Extensions
{
    public static class RestRequestExtensions
    {
        public static void SetAuthorization(this RestRequest request, EdGateClientOptions options)
        {
            var encoding  = Encoding.ASCII;
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();

            // Add required query params
            request.AddQueryParameter("publicKey", options.EdGatePublicKey);
            request.AddQueryParameter("timestamp", timestamp);

            // Create HMACSHA256 object
            var keyBytes = encoding.GetBytes(options.EdGatePrivateKey);
            var hmac     = new HMACSHA256(keyBytes);

            // Generate hash and add it to the header
            var paramString = String.Join("&", request.Parameters
                .Where(p => p.Type == ParameterType.QueryString)
                .Select(p => $"{p.Name}={HttpUtility.UrlEncode(p.Value.ToString())}"));
            var hashBytes   = hmac.ComputeHash(encoding.GetBytes(paramString));
            var hash        = BitConverter.ToString(hashBytes).Replace("-", string.Empty).ToLower();

            request.AddHeader("X-Hash", hash);
        }
    }
}
