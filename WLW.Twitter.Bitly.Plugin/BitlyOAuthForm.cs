using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using RE = System.Text.RegularExpressions;

namespace WLW.Twitter.Bitly.Plugin
{
    public partial class BitlyOAuthForm : Form
    {

        private const string ACCESS_TOKEN = "accessToken";
        private const string LOGIN = "login";
        private const string API_KEY = "apiKey";

        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectUri { get; set; }

        public string BitlyUser {
            get
            {
                return bitlyAccessData[LOGIN];
            }
        }
        public string BitlyAccessToken
        {
            get
            {
                return bitlyAccessData[ACCESS_TOKEN];
            }  
        }

        public string BitlyAPIKey
        {
            get
            {
                return bitlyAccessData[API_KEY];
            }
        }
        string uri = "https://bitly.com/oauth/authorize";
        Dictionary<string, string> bitlyAccessData;


        BitlyOAuthForm f;
        Cursor cursor;

        public BitlyOAuthForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void BitlyOAuthForm_Load(object sender, EventArgs e)
        {
            f = this;

            var authorizeUri = new StringBuilder(uri);
            authorizeUri.AppendFormat("?client_id={0}&", ClientId);
            authorizeUri.AppendFormat("redirect_uri={0}", RedirectUri);
            webBrowser1.Navigate(authorizeUri.ToString());


            this.Visible = true;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            cursor = f.Cursor;
            f.Cursor = System.Windows.Forms.Cursors.WaitCursor;

            var url2 = webBrowser1.Url.ToString();

            // It's possible there will be multiple pages in the flow.
            if (url2.StartsWith(uri))
            {
                // The login page has been displayed completely
                f.Cursor = cursor;
                return;
            }

            if (url2.StartsWith(RedirectUri))
            {
                webBrowser1.Visible = false;

                if (url2.Contains("?code="))
                {
                    //The user has clicked Allow so we need to grab the auth code
                    var divMarker = "code=";  //"<div id=\"oauth_pin\">";
                    var index = url2.LastIndexOf(divMarker) +
                    divMarker.Length;
                    var authCode = url2.Substring(index);

                    this.bitlyAccessData = GetBitlyAccessInfo(authCode);
                    f.DialogResult = DialogResult.OK;
                }
                else
                {
                    //The user has clicked Deny 
                    f.DialogResult = DialogResult.Cancel;
                }
                f.Close();
            }
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            f.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            f.Update();
        }

        // The embedded browser can navigate through HTTP 302
        // redirects, download images, and so on. The display will
        // initially be blank while it is waiting for downloads and
        // redirects. Also, after the user clicks "Login", there's a
        // delay.  In those cases we want the wait cursor. Only turn
        // it off if the status text is "Done."

        private void webBrowser1_StatusTextChanged(object sender, EventArgs e)
        {
            var t = webBrowser1.StatusText;
            if (t == "Done")
                f.Cursor = cursor;
            else if (!String.IsNullOrEmpty(t))
            {
                f.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            }
        }

        private Dictionary<string, string> GetBitlyAccessInfo(string bitlyAccessCode)
        {
            string token = string.Empty;
            Dictionary<string, string> bitlyAuth = new Dictionary<string,string>();

            var requestUri = new StringBuilder("https://api-ssl.bitly.com/oauth/access_token");
            requestUri.AppendFormat("?client_id={0}&", ClientId);
            requestUri.AppendFormat("client_secret={0}&", ClientSecret);
            requestUri.AppendFormat("code={0}&", bitlyAccessCode);
            requestUri.AppendFormat("redirect_uri={0}", RedirectUri);


            var request = (HttpWebRequest)WebRequest.Create(requestUri.ToString());
            request.Method = WebRequestMethods.Http.Post;
            
            var response = request.GetResponse();
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var accessToken = reader.ReadToEnd();

                var parts = accessToken.Split('&');
                bitlyAuth[ACCESS_TOKEN] = parts[0].Substring(parts[0].IndexOf('=') + 1);
                bitlyAuth[LOGIN] = parts[1].Substring(parts[1].IndexOf('=') + 1);
                bitlyAuth[API_KEY] = parts[2].Substring(parts[2].IndexOf('=') + 1);
            }

            return bitlyAuth;
        }




    }
}
