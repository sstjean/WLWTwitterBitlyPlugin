using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WLW.Twitter.Bitly.Plugin.TwitterConfig;

namespace WLW.Twitter.Bitly.Plugin
{
    public partial class SettingsForm : Form
    {
        WLWPluginSettings wlw_settings;
        TwitterSettings t_settings;


        public SettingsForm(WLWPluginSettings settings) : this()
        {

            wlw_settings = settings;

            this.t_settings = new TwitterSettings();
            this.t_settings.AccessSecret = wlw_settings.TwitterAccessSecretOption;
            this.t_settings.AccessToken = wlw_settings.TwitterAccessTokenOption;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
        }


        //
        //
        //   Twitter Configuration Methods
        //
        //

        private void SaveTwitterAccessInfo(TwitterSettings ts)
        {
            this.wlw_settings.TwitterAccessSecretOption = ts.AccessSecret;
            this.wlw_settings.TwitterAccessTokenOption = ts.AccessToken;
        }


        private void AuthorizeTwitterButton_Click(object sender, EventArgs e)
        {
            string statusMsg = string.Empty;
            IWin32Window dialogOwner = sender as IWin32Window;

            bool itWorked = PerformTwitterAuthorization(dialogOwner);

            if (itWorked)
            {
                statusMsg = "The WLW Twitter and Bitly Plugin was successfully authorized.\n\n" +
                              "You will not have to do this again unless you revoke\n" +
                              "access for this plugin on Twitter.com.";

                SaveTwitterAccessInfo(this.t_settings);
                MessageBox.Show(this, statusMsg, "Authorize Plugin at Twitter");
            }

        }

        private bool PerformTwitterAuthorization(IWin32Window dialogOwner)
        {
            OAuth.Manager oauth = new OAuth.Manager(TwitterSettings.TWITTER_CONSUMER_KEY, TwitterSettings.TWITTER_CONSUMER_SECRET);

            var dlg = new OAuth.TwitterOauthForm(oauth);

            dlg.ShowDialog(dialogOwner);

            if (dlg.DialogResult == DialogResult.OK)
            {
                dlg.StoreTokens(this.t_settings);
            }

            dlg.Dispose();


            if (!this.t_settings.Completed)
            {
                MessageBox.Show("You must grant approval for this plugin with Twitter\n" +
                                "before it can tweet your blog posts.",
                                "Authorize Plugin at Twitter",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }



        //
        //
        //     Bitly Configuration Methods
        //
        //

        private void AuthorizeBitlyButton_Click(object sender, EventArgs e)
        {
            string statusMsg = string.Empty;
            IWin32Window dialogOwner = sender as IWin32Window;

            bool itWorked = PerformBitlyAuthorization(dialogOwner);

            if (itWorked)
            {
                statusMsg = "The WLW Twitter and Bitly Plugin was successfully authorized.";

                SaveTwitterAccessInfo(this.t_settings);
                MessageBox.Show(this, statusMsg, "Authorize Plugin at Bitly");
            }
        }

        private bool PerformBitlyAuthorization(IWin32Window dialogOwner)
        {
            var redirectUri = "http://howstevegotburnedtoday.com/wp-empty.php";
            var clientId = "e45f8037dcfc96336d3979ef3f4d8c905e7d8d01";
            var clientSecret = "d6af409cf64a873810fe8b2a17585d8c1f36e01a";
            bool success = false;

            BitlyOAuthForm authForm = new BitlyOAuthForm();
            authForm.ClientId = clientId;
            authForm.ClientSecret = clientSecret;
            authForm.RedirectUri = redirectUri;

            DialogResult result = authForm.ShowDialog(dialogOwner);

            if (result == DialogResult.OK)
            {
                this.wlw_settings.BitlyAccessTokenOption = authForm.BitlyAccessToken;
                this.wlw_settings.BitlyUserOption = authForm.BitlyUser;
                success = true;
            }
            else
            {
                MessageBox.Show("You must grant approval for this plugin with Bitly\n" +
                 "before it can shorten the URL of you blog posts.",
                 "Authorize Plugin at Bitly",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Exclamation);

                success = false;
            }
            authForm.Dispose();

            return success;
        }

        private void ConfigureTwitterPostTemplate_Click(object sender, EventArgs e)
        {
            IWin32Window dialogOwner = sender as IWin32Window;

            TwitterPostSettingsForm settingsForm = new TwitterPostSettingsForm();
            settingsForm.PostTemplate = wlw_settings.TwitterPostFormat;

            DialogResult result = settingsForm.ShowDialog(dialogOwner);

            if (result == DialogResult.OK)
            {
                wlw_settings.TwitterPostFormat = settingsForm.PostTemplate;
                string statusMsg = "The Twitter post template was saved.";

                MessageBox.Show(this, statusMsg, "Configure Twitter Post Template");
            }

            settingsForm.Dispose();
        }



    }
}
