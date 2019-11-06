using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Kronos.WFD.Client
{
    public class AuthenticationResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("id_token")]
        public string IdToken { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("token_type")]
        public string Type { get; set; }

        public IEnumerable<string> Scopes
        {
            get
            {
                return Scope.Split(' ');
            }
        }
    }
}
