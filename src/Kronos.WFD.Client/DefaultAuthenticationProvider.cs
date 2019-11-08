using Kronos.WFD.Authentication;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Kronos.WFD.Client
{
    public class DefaultAuthenticationProvider : IAuthenticationProvider
    {
        private readonly string _clientSecret;

        private readonly string _password;

        public string ClientId { get; private set; }

        public string AppKey { get; private set; }

        public string TenantName { get; private set; }

        public string Username { get; set; }

        public DefaultAuthenticationProvider(string clientId, string clientSecret, string appKey, string tenantName, string username, string password)
        {
            _clientSecret = clientSecret;
            _password = password;
            ClientId = clientId;
            AppKey = appKey;
            TenantName = tenantName;
            Username = username;
        }

        public Task AuthenticateRequestAsync(HttpRequestMessage request)
        {
            var tokenUrl = $"https://{TenantName}.mykronos.com/api/authentication/access_token";

            var nameValueCollection = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", Username),
                new KeyValuePair<string, string>("password", _password),
                new KeyValuePair<string, string>("client_id", ClientId),
                new KeyValuePair<string, string>("client_secret", _clientSecret),
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("auth_chain", "OAuthLdapService")
            };

            var tokenRequest = new HttpRequestMessage(HttpMethod.Post, tokenUrl)
            {
                Content = new FormUrlEncodedContent(nameValueCollection),
            };
            tokenRequest.Headers.Add("appkey", AppKey);

            using (var httpClient = new HttpClient())
            {
                var responseMessage = httpClient.SendAsync(tokenRequest).Result;
                var responseBody = responseMessage.Content.ReadAsStringAsync().Result;

                if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var authenticationResponse = JsonConvert.DeserializeObject<AuthenticationResponse>(responseBody);
                    request.Headers.Add("Authorization", string.Format("{0} {1}", authenticationResponse.Type, authenticationResponse.AccessToken));
                }
            }

            request.Headers.Add("appkey", AppKey);
            return Task.FromResult(0);
        }
    }
}
