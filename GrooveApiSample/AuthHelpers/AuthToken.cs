using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GrooveApiSample
{
    [DataContract]
    public class AuthToken
    {
        [DataMember(Name = "token_type")]
        public string TokenType { get; set; }
        [DataMember(Name = "expires_in")]
        public int ExpiresIn { get; set; }
        [DataMember(Name = "scope")]
        public string Scope { get; set; }
        [DataMember(Name = "access_token")]
        public string Token { get; set; }
        [DataMember(Name = "refresh_token")]
        public string RefreshToken { get; set; }
        [DataMember(Name = "user_id")]
        public string UserId { get; set; }
        public DateTime ExpirationDate { get; set; }

        public bool IsExpired()
        {
            return System.DateTime.Now > ExpirationDate;
        }
    }
}
