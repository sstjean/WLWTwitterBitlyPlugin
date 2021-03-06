// OAuthForm.cs
// ------------------------------------------------------------------
//
// Pops up an embedded web browser to get user approval for the plugin as
// a twitter app. The normal oath 1.0a steps are:
//
// 1. get a Request Token (GET http://twitter/oauth/request_token)
//
// 2. open a web browser to the authorization page, passing the request token
//    received from the prior step.  The user must then click
//    the approve button.
//
// 3. get a PIN on the response page from that HTML Form.
//
// 4. using that PIN, do a GET http://twitter/oauth/access_token, and
//    get an access token and secret.
//
//
// The user experience imagined and recommended by Twitter requires the
// user to go to a different web page (an external browser).  In the
// base case, Twitter expects the user to manually open the browser
// themselves, and cut/paste the required URL into the address bar.
// Then the user needs to click the :Allow: button and copy/paste the
// PIN back into the Windows form app. Then close the web browser, and
// click the next button in the Windows Forms app, and so on.  This is
// just waaaaay too many context flips.
//
// Using an embedded web browser simplifies the UI flow significantly.
// The user just needs to click the "Allow" button and the rest of that
// nonsense is hidden from him.  There's no need for the user to be
// involved in copy/paste of the initial URL into the external browser
// address bar, or copy/paste of the pin from the html response page,
// back into the windows form to allow the next REST request.  With an
// embedded web browser all that can be automated.
//
// The result is a smoother UI, fewer user instructions, fewer error cases,
// and a better overall experience, while still remaining compliant with
// OAuth 1.0a.
//
//
// Author     : Dino
// Created    : Tue Dec 14 15:21:59 2010
// Last Saved : <2010-December-16 11:26:24>
//
// ------------------------------------------------------------------
//
// Copyright (c) 2010 by Dino Chiesa
// All rights reserved!
//
// ------------------------------------------------------------------

using System;

namespace WLW.Twitter.Bitly.Plugin.OAuth
{
    using System;
    using System.Windows.Forms;
    using System.Reflection;
    using WLW.Twitter.Bitly.Plugin;
    using RE=System.Text.RegularExpressions;

    class TwitterOauthForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.WebBrowser web1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblInstructions;

        private string _instructions1 =
              "Click the Next button to open a web page on Twitter.com. It will allow you to approve\n" +
              "this plugin as a Twitter app. This is the only time you will have\n" +
              "to do this.";

        private string _instructions2 =
              "Something has gone wrong while trying to approve this Plugin.\n" +
              "You'll need to try again.";

        private global::WLW.Twitter.Bitly.Plugin.OAuth.Manager _oauth;

        public TwitterOauthForm(global::WLW.Twitter.Bitly.Plugin.OAuth.Manager oauth)
        {
            InitializeComponent();
            _oauth= oauth;

            this.StartPosition = FormStartPosition.CenterParent;

            GetRequestToken();
        }

        public void StoreTokens(IOAuthSettings s)
        {
            s.AccessToken = this._oauth["token"];
            s.AccessSecret = this._oauth["token_secret"];
        }

        private void InitializeComponent()
        {
            // pop Twitter's OAuth authentication web page here
            var f = this;
            var cursor = f.Cursor;
            f.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            string authzUrlStub =
                OAuthConstants.URL_AUTHORIZE
                .Substring(0, OAuthConstants.URL_AUTHORIZE.LastIndexOf('?'));
            f.SuspendLayout();

            // event handlers
            WebBrowserDocumentCompletedEventHandler docCompleted = (sender, e) => {
                var url2 = web1.Url.ToString();

                // It's possible there will be multiple pages in the flow.
                if (url2.StartsWith(OAuthConstants.URL_AUTHORIZE))
                {
                    // The login page has been displayed completely
                    f.Cursor = cursor;
                    return;
                }

                if (url2==authzUrlStub)
                {
                    // the user has clicked the "allow" or "deny" button
                    if (web1.DocumentText.Contains("you've denied"))
                    {
                        // deny
                        web1.Visible = false;
                        _oauth["token"] = ""; // forget the request token
                        _oauth["token_secret"] = ""; // forget the secret
                        f.DialogResult = DialogResult.Cancel;
                        f.Close();
                        // The caller is responsible for popping a
                        // notification - like a MessageBox saying "you
                        // need to authorize Cropper in order to
                        // upload".
                    }

                    // workitem 15917
                    if (web1.DocumentText.Contains("You've granted access"))
                    {
                        var divMarker = "<CODE>";  //"<div id=\"oauth_pin\">";
                        var index = web1.DocumentText.LastIndexOf(divMarker) +
                        divMarker.Length;
                        var snip = web1.DocumentText.Substring(index);
                        var pin = RE.Regex.Replace(snip,"(?s)[^0-9]*([0-9]+).*", "$1").Trim();
                        web1.Visible = false; // all done with the web UI
                        GetAccessToken(pin);
                    }
                }
            };

            WebBrowserNavigatingEventHandler navigating = (sender,e) => {
                f.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                f.Update();
            };

            // The embedded browser can navigate through HTTP 302
            // redirects, download images, and so on. The display will
            // initially be blank while it is waiting for downloads and
            // redirects. Also, after the user clicks "Login", there's a
            // delay.  In those cases we want the wait cursor. Only turn
            // it off if the status text is "Done."
            EventHandler statusChanged = (sender,e) => {
                var t = web1.StatusText;
                if (t == "Done")
                    f.Cursor = cursor;
                else if (!String.IsNullOrEmpty(t))
                {
                    f.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                }
            };

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TwitterOauthForm));

            web1 =  new System.Windows.Forms.WebBrowser();
            btnCancel = new System.Windows.Forms.Button();
            lblInstructions = new System.Windows.Forms.Label();
            //
            // web1
            //
            web1.Location = new System.Drawing.Point(4, 86);
            web1.Name = "web1";
            web1.DocumentCompleted += docCompleted;
            web1.Navigating += navigating;
            web1.StatusTextChanged += statusChanged;
            web1.Dock = DockStyle.Fill;
            //
            // lblInstructions
            //
            lblInstructions.Text = _instructions1;
            lblInstructions.ForeColor = System.Drawing.Color.Red;
            lblInstructions.AutoSize = true;
            lblInstructions.Visible = false;
            lblInstructions.Size = new System.Drawing.Size(576, 46);
            lblInstructions.Location = new System.Drawing.Point(4, 6);
            //
            // btnCancel
            //
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(368, 94);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(68, 23);
            btnCancel.TabIndex = 71;
            btnCancel.Visible = false;
            btnCancel.Text = "&Close";
            btnCancel.UseVisualStyleBackColor = true;
            //
            // Form
            //
            f.Controls.Add(web1);
            f.Controls.Add(lblInstructions);
            f.Controls.Add(btnCancel);
            f.Name = "Authorize";
            f.Text = "Authorize the Twitter-Bitly Plugin...";
            //f.Icon = global::Cropper.SendToTwitPicUgh.Properties.Resources.icon;
            // size to accommodate the twitter confirmation dialog
            f.MinimumSize = new System.Drawing.Size(820, 474);
            f.MaximumSize = new System.Drawing.Size(820, 474);
            f.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            f.ResumeLayout(false);
        }


        private void GetRequestToken()
        {
            Cursor cursor = this.Cursor;
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.Update(); // show the wait cursor while sending request out...

            var response =
                this._oauth.AcquireRequestToken(OAuthConstants.URL_REQUEST_TOKEN, "POST");

            if (!String.IsNullOrEmpty(response["oauth_token"]))
            {
                var uriString = OAuthConstants.URL_AUTHORIZE + response["oauth_token"];
                web1.Url = new Uri(uriString);
            }
            else
            {
                web1.Visible = false;
                lblInstructions.Visible = true;
                lblInstructions.Text = _instructions2;
                btnCancel.Visible = true;
            }

            this.Cursor = cursor;
        }


        private void GetAccessToken(string pin)
        {
            Cursor cursor = this.Cursor;
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            var response =
                this._oauth.AcquireAccessToken(OAuthConstants.URL_ACCESS_TOKEN,
                                               "POST",
                                               pin);

            if (!String.IsNullOrEmpty(response["oauth_token"]))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                web1.Visible = false;
                this.lblInstructions.Text = _instructions2;
                lblInstructions.Visible = true;
                btnCancel.Visible = true;
            }

            this.Cursor = cursor;
        }
    }
}