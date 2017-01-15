using Microsoft.Groove.Api.Client;
using Microsoft.Groove.Api.DataContract;
using Microsoft.Groove.Api.DataContract.CollectionEdit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MusicBeePlugin.Plugin;

namespace GrooveForMusicBee
{
    public partial class SyncProgressWindow : Form
    {
        public enum SyncDirection { LocalToGroove, GrooveToLocal}

        private SyncHelper _syncHelper;
        private SyncDirection _syncDirection;
        private List<MusicBeePlaylist> _musicBeePlaylists;
        private List<Playlist> _groovePlaylists;
        public List<PlaylistActionResponse> ErrorResponses;

        public SyncProgressWindow(IGrooveClient client, MusicBeeApiInterface mbApiInterface, SyncDirection syncDirection, List<MusicBeePlaylist> musicBeePlaylists, List<Playlist> groovePlaylists)
        {
            InitializeComponent();

            _syncHelper = new SyncHelper(client, mbApiInterface, this);
            _syncDirection = syncDirection;
            _musicBeePlaylists = musicBeePlaylists;
            _groovePlaylists = groovePlaylists;
            ErrorResponses = new List<PlaylistActionResponse>();

            ApplyMusicBeeTheme(mbApiInterface);

            StartSync();
        }

        private void ApplyMusicBeeTheme(MusicBeeApiInterface mbApiInterface)
        {
            Color foreColor = Color.FromArgb(mbApiInterface.Setting_GetSkinElementColour(
                    MusicBeePlugin.Plugin.SkinElement.SkinInputPanel,
                    MusicBeePlugin.Plugin.ElementState.ElementStateDefault,
                    MusicBeePlugin.Plugin.ElementComponent.ComponentForeground));
            Color backColor = Color.FromArgb(mbApiInterface.Setting_GetSkinElementColour(
                    MusicBeePlugin.Plugin.SkinElement.SkinInputControl,
                    MusicBeePlugin.Plugin.ElementState.ElementStateDefault,
                    MusicBeePlugin.Plugin.ElementComponent.ComponentBackground));

            foreach (Control control in this.Controls)
            {
                control.ForeColor = foreColor;
                control.BackColor = backColor;

                if (control.Controls.Count > 0)
                {
                    foreach (Control child in control.Controls)
                    {
                        child.ForeColor = foreColor;
                        child.BackColor = backColor;
                    }
                }
            }

            this.ForeColor = foreColor;
            this.BackColor = backColor;
        }

        private async void StartSync()
        {
            if (_syncDirection == SyncDirection.LocalToGroove)
            {
                List<PlaylistActionResponse> responses = await _syncHelper.LocalToGroove(_musicBeePlaylists, _groovePlaylists);
                
                // check for errors
                foreach (PlaylistActionResponse response in responses)
                {
                    if (response.Error != null)
                    {
                        ErrorResponses.Add(response);
                    }
                }

                if (ErrorResponses.Count == 0)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.DialogResult = DialogResult.No;
                }

                this.Close();
            }
            else if (_syncDirection == SyncDirection.GrooveToLocal)
            {

            }
            else
            {
                // something went wrong
            }
        }

        public void UpdatePreparationProgress(int value)
        {
            PreparationProgressBar.Value = value;
        }

        public void UpdateSyncProgress(int value)
        {
            SyncProgressBar.Value = value;
        }

        public void WriteOutputLine(string text)
        {
            OutputTextBox.AppendText(text + Environment.NewLine);
        }

        private void OutputTextBox_TextChanged(object sender, EventArgs e)
        {
            OutputTextBox.SelectionStart = OutputTextBox.Text.Length;
            OutputTextBox.ScrollToCaret();
        }
    }
}
