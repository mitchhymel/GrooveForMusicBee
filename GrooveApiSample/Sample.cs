using Microsoft.Groove.Api.Client;
using Microsoft.Groove.Api.DataContract;
using Microsoft.Identity.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private IGrooveClient groove;

        public Sample()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestAPI();
        }

        private async void TestAPI()
        {
            string clientId = Secret.CLIENTID;
            string clientSecret = Secret.CLIENTSECRET;
            string clientSecretEnc = System.Uri.EscapeDataString(clientSecret);
            UserTokenManager manager = new UserTokenManager();
            IGrooveClient client = GrooveClientFactory.CreateGrooveClient(Secret.CLIENTID, Secret.CLIENTSECRET, manager);

            bool success = await manager.LoginAsync();

            var responseToo = await client.BrowseAsync(MediaNamespace.music, ContentSource.Collection, ItemType.Playlists);
            if (responseToo.Error != null)
            {
                textBox1.AppendText(responseToo.Error.Description);
            }
            else
            {
                Playlist first = responseToo.Playlists.Items.First();
                textBox1.AppendText($"{first.Name} : {first.TrackCount}");
            }
        }

        private async void GetDevToken()
        {
            string authUrl = "https://login.live.com/accesstoken.srf";
            var client = new HttpClient();
            string requestBody = String.Format("grant_type=client_credentials&client_id={0}&client_secret={1}&scope=app.music.xboxlive.com", Secret.CLIENTID, Secret.CLIENTSECRET);
            HttpContent content = new StringContent(requestBody, System.Text.Encoding.UTF8, "application/x-www-form-urlencoded");
            var response = await client.PostAsync(authUrl, content);
            var responseString = await response.Content.ReadAsStringAsync();
            textBox1.AppendText(responseString);
        }
    }
}
