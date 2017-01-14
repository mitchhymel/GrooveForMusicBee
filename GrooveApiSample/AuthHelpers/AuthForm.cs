using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrooveApiSample
{
    public partial class AuthForm : Form
    {
        private readonly string startUrl;
        private readonly string endUrl;
        public AuthResult authResult;

        public AuthForm(string startUrl, string endUrl)
        {
            this.startUrl = startUrl;
            this.endUrl = endUrl;
            InitializeComponent();
        }

        private void LiveAuthForm_Load(object sender, EventArgs e)
        {
            this.webBrowser.Navigated += WebBrowser_Navigated;
            this.webBrowser.Navigate(this.startUrl);
        }

        private void WebBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (this.webBrowser != null && !this.webBrowser.IsDisposed && this.webBrowser.Url.AbsoluteUri.StartsWith(this.endUrl))
            {
                this.authResult = new AuthResult(this.webBrowser.Url);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
