using System;
using System.Windows.Forms;
using WindowsLive.Writer.Api;
using WLW.Twitter.Bitly.Plugin.TwitterConfig;

namespace WLW.Twitter.Bitly.Plugin
{
    [WriterPlugin("CFD5B2E8-ADB0-4BB5-9140-AD28D3CC7CDB", "Twitter and Bitly Plugin",
        Description = "Post a message to Twitter after publishing your blog post.\n\n" +
                        "The Tweet format is configurable and can include the Title " + 
                        "and URL of your blog post automatically.",
        HasEditableOptions = true,
        Name = "Twitter and Bitly Plugin",
        PublisherUrl = "http://www.howstevegotburnedtoday.com",
        ImagePath = "Graphics.plug-16x16.png")]
    public class WLWTwitterBitlyPlugin : PublishNotificationHook
    {

        WLWPluginSettings m_defaultsettings;


        public override void Initialize(IProperties pluginOptions)
        {
            base.Initialize(pluginOptions);
            m_defaultsettings = new WLWPluginSettings(pluginOptions);
        }

        public override void OnPostPublish(IWin32Window dialogOwner, IProperties properties, IPublishingContext publishingContext, bool publish)
        {
            try
            {
                if (String.IsNullOrEmpty(m_defaultsettings.TwitterAccessTokenOption) ||
                    String.IsNullOrEmpty(m_defaultsettings.TwitterAccessSecretOption))
                {
                    MessageBox.Show(dialogOwner,
                                    "The Twitter and Bitly Plugin for Windows Live Writer\n" +
                                    "is turned on but does not have authorization to Tweet\n" +
                                    "on your behalf.\n\n" +
                                    "Please go to the Settings page and authorize the plugin.",
                                    "Cannot post to Twitter",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }
                else
                {

                    var bitly = CreateBitlyHelper();
                    string shortURL = string.Empty;
                    bool urlShortened = false;

                    try
                    {
                        shortURL = bitly.Shorten(publishingContext.PostInfo.Permalink);
                        urlShortened = true;
                    }
                    catch (System.Net.WebException ex)
                    {
                        shortURL = publishingContext.PostInfo.Permalink;
                        urlShortened = false;
                    }
                    var msg = FormatTweet(m_defaultsettings.TwitterPostFormat, publishingContext.PostInfo.Title, shortURL);

                    TweetPostReviewForm review = new TweetPostReviewForm(msg, urlShortened);

                    DialogResult sendTweet = review.ShowDialog(dialogOwner);

                    msg = review.Tweet;
                    review.Dispose();

                    if (sendTweet == DialogResult.OK)
                    {
                        var twitter = CreateTinyTwitter();
                        twitter.UpdateStatus(msg);
                    }
                }
            }
            catch (System.Net.WebException webEx)
            {
                if (webEx.Message.Contains("(401) Unauthorized"))
                {
                    MessageBox.Show(dialogOwner,
                                    "The Twitter and Bitly Plugin for Windows Live Writer\n" +
                                    "is turned on but does not have authorization to Tweet\n" +
                                    "on your behalf.\n\n" +
                                    "Please go to the Settings page and authorize the plugin.",
                                    "No Authorizaiton for Twitter and Bitly plugin",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show(dialogOwner,
                        "Twitter returned an error.\n" +
                         "Your tweet couldn't be posted.\n\n" +
                         "Message from Twitter:\n " + webEx.Message,
                         "Twitter returned an error",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(dialogOwner,
                    "Message: " + ex.Message + "\n\n" + "Stack trace:\n" + ex.StackTrace,
                    "Twitter and Bitly Plugin - An unhandled error occurred",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            finally
            {
                base.OnPostPublish(dialogOwner, properties, publishingContext, publish);
            }
        }



        public override void EditOptions(IWin32Window dialogOwner)
        {
            SettingsForm op = new SettingsForm(m_defaultsettings);
            var result = op.ShowDialog(dialogOwner);

        }


        //Support methods

        public string FormatTweet(string postTemplate, string postTitle, string url)
        {
            string msg = string.Empty;
            string clippedTitle = postTitle;

            PluginHelpers.TweetTemplate t = PluginHelpers.ConstructTweetFormat(postTemplate);

            if (t.HasTitle)
            {
                int remainingCharsForTitle = 140 - t.UsedTweetSpace - url.Length;
                clippedTitle = ClipTitle(remainingCharsForTitle, postTitle);
            }

            if (t.OnlyHasUrl)
            {
                msg = string.Format(t.formatString, url);
            }
            else
            {
                msg = string.Format(t.formatString, clippedTitle, url);
            }

            return msg;
        }


        public string ClipTitle(int maxLength, string title)
        {
            string clippedTitle = title.Length <= maxLength ? title : title.Substring(0, maxLength - 3) + "...";
            return clippedTitle;
        }

        private TinyTwitter CreateTinyTwitter()
        {
            var oauth = new OAuthInfo();
            oauth.ConsumerKey = TwitterSettings.TWITTER_CONSUMER_KEY;
            oauth.ConsumerSecret = TwitterSettings.TWITTER_CONSUMER_SECRET;
            oauth.AccessToken = m_defaultsettings.TwitterAccessTokenOption;
            oauth.AccessSecret = m_defaultsettings.TwitterAccessSecretOption;

            var twitter = new TinyTwitter(oauth);

            return twitter;
        }

        private BitlyHelper CreateBitlyHelper()
        {
            var bitly = new BitlyHelper(m_defaultsettings.BitlyUserOption, m_defaultsettings.BitlyAccessTokenOption);

            return bitly;
        }

    }


}


