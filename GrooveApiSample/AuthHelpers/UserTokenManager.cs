using Microsoft.Groove.Api.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel;
using System.Net.Http;
using Mono.Web;
using Microsoft.Identity.Client;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace GrooveApiSample
{
    public class UserTokenManager : IUserTokenManager
    {
        private const string OfflineAccessScope = "offline_access";
        private const string GrooveApiScope = "MicrosoftMediaServices.GrooveApiAccess";

        public AuthToken AuthToken { get; private set; }
        public bool UserIsSignedIn { get; private set; }
        private AuthForm _authForm { get; set; }

        public UserTokenManager()
        {
            AuthToken = null;
            _authForm = null;
            UserIsSignedIn = false;
        }

        /// <summary>
        /// Attempts to get a user token for Groove API user access.
        /// Must be called before any Groove API calls that require user token.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> LoginAsync()
        {
            if (AuthToken == null)
            {
                AuthToken = await GetUserTokenAsync();
            }

            UserIsSignedIn = AuthToken != null;
            return UserIsSignedIn;
        }

        /// <summary>
        /// Implementation of IUserTokenManager. Method that Groove API will call to get user token
        /// for calls that require user token.
        /// </summary>
        /// <param name="forceRefresh"></param>
        /// <returns></returns>
        public async Task<string> GetUserAuthorizationHeaderAsync(bool forceRefresh = false)
        {
            if (AuthToken == null)
            {
                AuthToken = await GetUserTokenAsync();
            }

            return $"Bearer {AuthToken.Token}" ;
        }

        /// <summary>
        /// Helper function to get a user token
        /// </summary>
        /// <returns></returns>
        private async Task<AuthToken> GetUserTokenAsync()
        {
            AuthToken result = null;

            if (this._authForm == null)
            {
                string scopes = $"{GrooveApiScope} {OfflineAccessScope}";
                string redirectUri = HttpUtility.UrlEncode("https://login.live.com/oauth20_desktop.srf");
                string startUrl = $"https://login.live.com/oauth20_authorize.srf?client_id={Secret.CLIENTID}&scope={scopes}&response_type=code&redirect_uri={redirectUri}";
                string endUrl = "https://login.live.com/oauth20_desktop.srf";
                this._authForm = new AuthForm(startUrl, endUrl);
                var dialogResult = this._authForm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    AuthResult authResult = this._authForm.authResult;
                    CleanupAuthForm();
                    result = await ExchangeCodeForToken(authResult.AuthorizeCode);
                }
                else
                {
                    result = null;
                }
                
            }
            else
            {
                this._authForm.Focus();
            }

            UserIsSignedIn = result != null;

            return result;
        }

        /// <summary>
        /// Helper function to make sure the auth form is cleaned up after auth is finished
        /// </summary>
        private void CleanupAuthForm()
        {
            if (this._authForm != null)
            {
                this._authForm.Dispose();
                this._authForm = null;
            }
        }

        /// <summary>
        /// Helper function to obtain a Groove API user token after obtaining a code from auth
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private async Task<AuthToken> ExchangeCodeForToken(string code)
        {
            string tokenUrl = "https://login.live.com/oauth20_token.srf";
            string redirectUri = HttpUtility.UrlEncode("https://login.live.com/oauth20_desktop.srf");
            string body = $"client_id={Secret.CLIENTID}&redirect_uri={redirectUri}&code={code}&grant_type=authorization_code";

            HttpClient client = new HttpClient();
            HttpContent content = new StringContent(body, System.Text.Encoding.UTF8, "application/x-www-form-urlencoded");
            HttpResponseMessage postResponse = await client.PostAsync(tokenUrl, content);
            string result = await postResponse.Content.ReadAsStringAsync();
            AuthToken tokenResult = JsonConvert.DeserializeObject<AuthToken>(result);

            return tokenResult;
        }
    }
}
