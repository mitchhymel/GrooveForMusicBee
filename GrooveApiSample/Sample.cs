using GrooveDesktopUserTokenManager;
using GrooveForMusicBee;
using Microsoft.Groove.Api.Client;
using Microsoft.Groove.Api.DataContract;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrooveApiSample
{
    public partial class Sample : Form
    {
        private IGrooveClient _client;
        private List<Track> _tracks;
        private List<Playlist> _playlists;
        private string sessionId;

        public Sample()
        {
            InitializeComponent();
            sessionId = Guid.NewGuid().ToString();
        }

        private void Sample_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1150, 775);
        }

        private string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(JsonConvert.SerializeObject(obj, Formatting.Indented))
                    .Replace("\\n", Environment.NewLine)
                    .Replace("\\r", "")
                    .Replace("\\\"", "\"")
                    .TrimStart(new char[] { '\"' })
                    .TrimEnd(new char[] { '\"' });
        }

        private void onSelectedItemChange(object sender, EventArgs e)
        {
            if (sender is ListBox)
            {
                ListBox box = (ListBox)sender;
                OutputTextBox.Text = Serialize(box.SelectedItem);
            }
        }

        private void EnableButtons()
        {
            GetPlaylistsButton.Enabled = true;

            GetTracksButton.Enabled = true;
            GetStreamButton.Enabled = true;
            GetAlbumsButton.Enabled = true;
        }

        #region Click events


        private async void LoginButton_Click(object sender, EventArgs e)
        {
            UserTokenManager manager = new UserTokenManager();

            bool success = await manager.LoginAsync();
            if (success)
            {
                _client = GrooveClientFactory.CreateGrooveClient(Secret.CLIENTID, Secret.CLIENTSECRET, manager);
                EnableButtons();
            }
            else
            {
                // show error that login had a failure
                OutputTextBox.Text = "Login failure";
            }
        }

        #region Tracks
        private async void GetTracksButton_Click(object sender, EventArgs e)
        {
            ContentResponse response = await _client.BrowseAsync(MediaNamespace.music, ContentSource.Collection, ItemType.Tracks, maxItems: 100);
            _tracks = response.Tracks.Items;
            TrackListBox.Items.Clear();
            _tracks.ForEach(t => TrackListBox.Items.Add(t));
        }

        private async void GetStreamButton_Click(object sender, EventArgs e)
        {
            Track track = (Track)TrackListBox.SelectedItem;
            if (track != null)
            {
                StreamResponse response = await _client.StreamAsync(track.Id, sessionId);
                OutputTextBox.Text = response.Error == null ? response.Url : response.Error.Description;
            }
        }

        private async void GetAlbumsButton_Click(object sender, EventArgs e)
        {
            Track track = (Track)TrackListBox.SelectedItem;
            if (track != null)
            {
                ContentResponse response = await _client.LookupAsync(track.Id);
                OutputTextBox.Text = Serialize(response);
            }
        }

        #endregion

        #region Playlists

        private async void OnPlaylistSelected(object sender, EventArgs e)
        {
            Playlist playlist = (Playlist)PlaylistListBox.SelectedItem;
            if (playlist != null)
            {
                ContentResponse response = await _client.LookupAsync(playlist.Id);
                OutputTextBox.Text = Serialize(response);
                PlaylistTrackListBox.Items.Clear();
                response.Playlists.Items.First().Tracks.Items.ForEach(t => PlaylistTrackListBox.Items.Add(t));
            }
        }

        private async void GetPlaylistsButton_Click(object sender, EventArgs e)
        {
            ContentResponse response = await _client.BrowseAsync(MediaNamespace.music, ContentSource.Collection, ItemType.Playlists);
            _playlists = response.Playlists.Items;
            _playlists.ForEach(p => PlaylistListBox.Items.Add(p));
        }

        private async void OnPlaylistEntrySelected(object sender, EventArgs e)
        {
            Track track = (Track)PlaylistTrackListBox.SelectedItem;
            if (track != null)
            {
                OutputTextBox.Text = Serialize(track);
                ArtistArtPictureBox.Load(track.GetImageUrl(ArtistArtPictureBox.Size.Width, ArtistArtPictureBox.Size.Height));
                StreamResponse stream = await _client.StreamAsync(track.Id, sessionId);
                StreamTextBox.Text = Serialize(stream);
            }
        }

        #endregion

        #endregion
    }
}
