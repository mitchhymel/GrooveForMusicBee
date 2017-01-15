using GrooveDesktopUserTokenManager;
using GrooveForMusicBee;
using Microsoft.Groove.Api.Client;
using Microsoft.Groove.Api.DataContract;
using Microsoft.Groove.Api.DataContract.CollectionEdit;
using Mono.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GrooveForMusicBee.SyncProgressWindow;
using static MusicBeePlugin.Plugin;

namespace GrooveForMusicBee
{
    public partial class SyncPlaylistsWindow : Form
    {
        private bool _loggedIn = false;
        private MusicBeeApiInterface _mbApiInterface;
        private IGrooveClient _client;
        private SyncHelper _syncHelper;
        private SyncProgressWindow _syncProgressWindow = null;

        public SyncPlaylistsWindow(MusicBeeApiInterface mbApiInterface)
        {
            InitializeComponent();

            OutputTextBox.AppendText(Environment.NewLine);

            _mbApiInterface = mbApiInterface;
            ApplyMusicBeeTheme();
        }

        private void ApplyMusicBeeTheme()
        {
            foreach (Control control in this.Controls)
            {
                control.ForeColor = Color.FromArgb(_mbApiInterface.Setting_GetSkinElementColour(
                    MusicBeePlugin.Plugin.SkinElement.SkinInputPanel,
                    MusicBeePlugin.Plugin.ElementState.ElementStateDefault,
                    MusicBeePlugin.Plugin.ElementComponent.ComponentForeground));
                control.BackColor = Color.FromArgb(_mbApiInterface.Setting_GetSkinElementColour(
                    MusicBeePlugin.Plugin.SkinElement.SkinInputControl,
                    MusicBeePlugin.Plugin.ElementState.ElementStateDefault,
                    MusicBeePlugin.Plugin.ElementComponent.ComponentBackground));

                if (control.Controls.Count > 0)
                {
                    foreach (Control child in control.Controls)
                    {
                        child.ForeColor = Color.FromArgb(_mbApiInterface.Setting_GetSkinElementColour(
                            MusicBeePlugin.Plugin.SkinElement.SkinInputPanel,
                            MusicBeePlugin.Plugin.ElementState.ElementStateDefault,
                            MusicBeePlugin.Plugin.ElementComponent.ComponentForeground));
                        child.BackColor = Color.FromArgb(_mbApiInterface.Setting_GetSkinElementColour(
                            MusicBeePlugin.Plugin.SkinElement.SkinInputControl,
                            MusicBeePlugin.Plugin.ElementState.ElementStateDefault,
                            MusicBeePlugin.Plugin.ElementComponent.ComponentBackground));
                    }
                }
            }

            this.ForeColor = Color.FromArgb(_mbApiInterface.Setting_GetSkinElementColour(
                MusicBeePlugin.Plugin.SkinElement.SkinInputPanel,
                MusicBeePlugin.Plugin.ElementState.ElementStateDefault,
                MusicBeePlugin.Plugin.ElementComponent.ComponentForeground));
            this.BackColor = Color.FromArgb(_mbApiInterface.Setting_GetSkinElementColour(
                MusicBeePlugin.Plugin.SkinElement.SkinInputControl,
                MusicBeePlugin.Plugin.ElementState.ElementStateDefault,
                MusicBeePlugin.Plugin.ElementComponent.ComponentBackground));
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            UserTokenManager manager = new UserTokenManager();
            try
            {
                bool loginSuccess = await manager.LoginAsync();
                if (loginSuccess)
                {
                    _client = GrooveClientFactory.CreateGrooveClient(Secret.CLIENTID, Secret.CLIENTSECRET, manager);
                    WriteOutputLine("Successfully logged in.");
                    OnLoginSuccess();
                }
                else
                {
                    WriteOutputLine("Error while logging in");
                }
            }
            catch (ConfigurationErrorsException ex)
            {
                WriteOutputLine("Could not save refresh token. Please run as admin to allow saving of refresh token, or you will have to manually authenticate with every request.");
            }
        }

        private async void OnLoginSuccess()
        {
            _loggedIn = true;

            // Get local music bee playlists
            GetLocalPlaylists();

            // Attempt to get Groove playlists
            GetGroovePlaylists();

            // _collection = await GetAllTracks();
        }

        private async void GetLocalPlaylists()
        {
            _mbApiInterface.Playlist_QueryPlaylists();
            string playlist = _mbApiInterface.Playlist_QueryGetNextPlaylist();
            while (playlist != null)
            {
                string playlistName = _mbApiInterface.Playlist_GetName(playlist);
                MusicBeePlaylist mbPlaylist = new MusicBeePlaylist(playlistName, playlist);
                LocalPlaylistCheckListBox.Items.Add(mbPlaylist, false);
                playlist = _mbApiInterface.Playlist_QueryGetNextPlaylist();
            }
        }

        private async void GetGroovePlaylists()
        {
            ContentResponse playlistResponse = await _client.BrowseAsync(MediaNamespace.music, ContentSource.Collection, ItemType.Playlists);
            if (playlistResponse.Playlists != null)
            {
                GroovePlaylistCheckListBox.Items.Clear();
                List<Playlist> playlists = playlistResponse.Playlists.Items.OrderBy(p => p.Name).ToList();
                playlists.ForEach(p => GroovePlaylistCheckListBox.Items.Add(p, false));
            }

            SyncButton.Enabled = true;
        }

        private async Task<List<Track>> GetAllTracks()
        {
            List<Track> collection = new List<Track>();

            bool keepLooping = true;
            string continuationToken = null;
            do
            {
                ContentResponse response = await _client.BrowseContinuationAsync(MediaNamespace.music, ContentSource.Collection, ItemType.Tracks, continuationToken);
                if (response.Error == null || response.Error.ErrorCode == Enum.GetName(typeof(ErrorCode), ErrorCode.COLLECTION_INVALID_DATA))
                {
                    collection.AddRange(response.Tracks.Items);
                    continuationToken = response.Tracks.ContinuationToken;
                    keepLooping = continuationToken != null;
                }
                else
                {
                    WriteOutputLine($"Error: {response.Error.Description}");
                    keepLooping = false;
                }
            } while (keepLooping);

            return collection;
        }

        public void WriteOutputLine(string text)
        {
            OutputTextBox.AppendText(text + Environment.NewLine);
        }

        private void GroovePlaylistCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool newValue = GroovePlaylistCheckBox.Checked;
            for (int i = 0; i < GroovePlaylistCheckListBox.Items.Count; i++)
            {
                GroovePlaylistCheckListBox.SetItemChecked(i, newValue);
            }
        }

        private void LocalPlaylistCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool newValue = LocalPlaylistCheckBox.Checked;
            for (int i = 0; i < LocalPlaylistCheckListBox.Items.Count; i++)
            {
                LocalPlaylistCheckListBox.SetItemChecked(i, newValue);
            }
        }

        private async void SyncButton_Click(object sender, EventArgs e)
        {
            if (_loggedIn)
            {
                if (ToGrooveRadioButton.Checked)
                {
                    SyncToGroove();
                }
                else
                {
                    SyncFromGroove();
                }
            }
            else
            {
                WriteOutputLine("Log in to sync.");
            }
        }

        private async void SyncToGroove()
        {
            List<Playlist> groovePlaylists = GroovePlaylistCheckListBox.Items.Cast<Playlist>().ToList();
            List<MusicBeePlaylist> playlistsToSync = LocalPlaylistCheckListBox.CheckedItems.Cast<MusicBeePlaylist>().ToList();

            this._syncProgressWindow = new SyncProgressWindow(_client, _mbApiInterface, SyncDirection.LocalToGroove, playlistsToSync, groovePlaylists);
            var dialogResult = this._syncProgressWindow.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                WriteOutputLine("Sync completed successfully!");
                GetGroovePlaylists();
            }
            else if (dialogResult == DialogResult.No)
            {
                foreach (PlaylistActionResponse response in _syncProgressWindow.ErrorResponses)
                {
                    WriteOutputLine($"Failed to sync '{response.PlaylistActionResult.Name}' with error '{response.Error.Description}'");
                }
            }
            else
            {
                WriteOutputLine("Something went wrong...");
            }
        }

        private async void SyncFromGroove()
        {

        }
    }
}
