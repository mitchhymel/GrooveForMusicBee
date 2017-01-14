using Microsoft.Groove.Api.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Mono.Web;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Configuration;
using System.Reflection;

namespace GrooveDesktopUserTokenManager
{
    public class UserTokenManager : IUserTokenManager
    {
        private const string OfflineAccessScope = "offline_access";
        private const string GrooveApiScope = "MicrosoftMediaServices.GrooveApiAccess";
        private const string RefreshTokenSettingsKey = "ida:mb_GrooveForMusicBeeRefreshToken";
        private const string TokenUri = "https://login.live.com/oauth20_authorize.srf";
        private const string DesktopRedirectUri = "https://login.live.com/oauth20_desktop.srf";
        private const string ClientId = "d4382ba0-6a33-4a49-82b6-aa4a99f7126b";

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
            if (AuthToken == null || AuthToken.IsExpired())
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
            if (AuthToken == null || AuthToken.IsExpired() || forceRefresh)
            {
                AuthToken = await GetUserTokenAsync();
            }

            UserIsSignedIn = AuthToken != null;

            return $"Bearer {AuthToken.Token}" ;
        }

        /// <summary>
        /// Helper function to get a user token
        /// </summary>
        /// <returns></returns>
        private async Task<AuthToken> GetUserTokenAsync()
        {
            AuthToken result = null;

            // Try to read Auth token from settings
            string refreshToken = null;
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            if (configuration.AppSettings.Settings.AllKeys.Contains(RefreshTokenSettingsKey))
            {
                refreshToken = configuration.AppSettings.Settings[RefreshTokenSettingsKey].Value;
            }

            if (!String.IsNullOrEmpty(refreshToken))
            {
                // use refresh token to get auth token
                result = await GetTokenFromRefreshToken(refreshToken);
            }
            else
            {
                // get auth token from user auth
                result = await GetTokenFromUserPrompt();
            }

            return result;
        }

        private async Task<AuthToken> GetTokenFromUserPrompt()
        {
            AuthToken result = null;
            // get auth token from user auth
            string scopes = $"{GrooveApiScope} {OfflineAccessScope}";
            string redirectUri = HttpUtility.UrlEncode(DesktopRedirectUri);
            string startUrl = $"{TokenUri}?client_id={ClientId}&scope={scopes}&response_type=code&redirect_uri={redirectUri}";
            string endUrl = DesktopRedirectUri;
            this._authForm = new AuthForm(startUrl, endUrl);
            var dialogResult = this._authForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                AuthResult authResult = this._authForm.authResult;
                CleanupAuthForm();
                result = await ExchangeCodeForToken(authResult.AuthorizeCode);

                // save to configuration
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
                if (!configuration.AppSettings.Settings.AllKeys.Contains(RefreshTokenSettingsKey))
                {
                    configuration.AppSettings.Settings.Add(RefreshTokenSettingsKey, "");
                }
                configuration.AppSettings.Settings[RefreshTokenSettingsKey].Value = result.RefreshToken;
                configuration.Save();
                ConfigurationManager.RefreshSection("appSettings");
            }
            else
            {
                result = null;
            }

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


        private async Task<AuthToken> GetTokenFromRefreshToken(string refreshToken)
        {
            string body = $"client_id={ClientId}&redirect_uri={HttpUtility.UrlEncode(DesktopRedirectUri)}&refresh_token={refreshToken}&grant_type=refresh_token";
            return await PerformPostAsync(body);
        }

        /// <summary>
        /// Helper function to obtain a Groove API user token after obtaining a code from auth
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private async Task<AuthToken> ExchangeCodeForToken(string code)
        {
            string body = $"client_id={ClientId}&redirect_uri={HttpUtility.UrlEncode(DesktopRedirectUri)}&code={code}&grant_type=authorization_code";
            return await PerformPostAsync(body);
        }

        private async Task<AuthToken> PerformPostAsync(string body)
        {
            string tokenUrl = "https://login.live.com/oauth20_token.srf";
            string redirectUri = HttpUtility.UrlEncode("https://login.live.com/oauth20_desktop.srf");

            HttpClient client = new HttpClient();
            HttpContent content = new StringContent(body, System.Text.Encoding.UTF8, "application/x-www-form-urlencoded");
            HttpResponseMessage postResponse = await client.PostAsync(tokenUrl, content);
            string result = await postResponse.Content.ReadAsStringAsync();
            AuthToken tokenResult = JsonConvert.DeserializeObject<AuthToken>(result);
            tokenResult.ExpirationDate = new DateTime(System.DateTime.Now.Ticks + tokenResult.ExpiresIn);

            return tokenResult;
        }
    }
}
