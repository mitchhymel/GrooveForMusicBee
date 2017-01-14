using GrooveDesktopUserTokenManager;
using GrooveForMusicBee;
using Microsoft.Groove.Api.Client;
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
    public partial class SyncPlaylistsWindow : Form
    {
        private MusicBeeApiInterface _mbApiInterface;
        private IGrooveClient _client;

        public SyncPlaylistsWindow(MusicBeeApiInterface mbApiInterface)
        {
            InitializeComponent();
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
            bool loginSuccess = await manager.LoginAsync();
            if (loginSuccess)
            {
                _client = GrooveClientFactory.CreateGrooveClient(Secret.CLIENTID, Secret.CLIENTSECRET, manager);

                WriteOutputLine("\nSuccessfully logged in.");
            }
            else
            {
                WriteOutputLine("\nError while logging in");
            }
        }

        private void WriteOutputLine(string text)
        {
            OutputTextBox.AppendText(text + Environment.NewLine);
        }
    }
}
