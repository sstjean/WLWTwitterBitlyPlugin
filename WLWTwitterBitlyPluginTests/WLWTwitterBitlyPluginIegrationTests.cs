using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WLW.Twitter.Bitly.Plugin;
using WindowsLive.Writer.Api;
using WLWTwitterBitlyPluginTests.Mocks;
using WLW.Twitter.Bitly.Plugin.TwitterConfig;
using System.Windows.Forms;

namespace WLW.Twitter.Bitly.Plugin.Tests
{

    [TestClass]
    public class WLWTwitterBitlyPluginTests
    {



        //Post data
        private string longURL = "http://howstevegotburnedtoday.com/2015/05/19/moved-to-wordpess-on-azure-paas-and-azure-sql/";
 


        [TestMethod, 
            TestCategory("ManualTestHarness")]
        public void TweetPostReviewForm_UpdateTweetTest()
        {
            string startTweet = "[Blog] Something new to tell everyone - http://bit.ly/4js93pks";
            string endTweet = string.Empty;

            TweetPostReviewForm frm = new TweetPostReviewForm(startTweet, true);

            DialogResult result =  frm.ShowDialog();
            endTweet = frm.Tweet;
            frm.Dispose();

            Assert.AreEqual(DialogResult.OK, result);
            Assert.AreNotEqual(endTweet, startTweet);
        }

         [TestMethod,
            TestCategory("ManualTestHarness")]
        public void BitlyOUathForm_AuthorizeTest()
        {
            var redirectUri = "http://howstevegotburnedtoday.com/wp-empty.php";
            var clientId = "e45f8037dcfc96336d3979ef3f4d8c905e7d8d01";
            var clientSecret = "d6af409cf64a873810fe8b2a17585d8c1f36e01a";

            BitlyOAuthForm authForm = new BitlyOAuthForm();
            authForm.ClientId = clientId;
            authForm.ClientSecret = clientSecret;
            authForm.RedirectUri = redirectUri;

            DialogResult result = authForm.ShowDialog();
            var accessToken = authForm.BitlyAccessToken;
            var bitlyUser = authForm.BitlyUser;

            Assert.AreEqual(DialogResult.OK, result);
            Assert.IsFalse(String.IsNullOrEmpty(accessToken));
            Assert.IsFalse(string.IsNullOrEmpty(bitlyUser));
        }


         [TestMethod,
           TestCategory("ManualTestHarness")]
         public void TwitterPostSettingsForm_PostTemplateTest()
         {
             string twitterPostFormat = "[Blog] " + WLWPluginSettings.TITLEMACRO + " - " + WLWPluginSettings.URLMACRO;

             TwitterPostSettingsForm settingsForm = new TwitterPostSettingsForm();
             settingsForm.PostTemplate = twitterPostFormat;

             DialogResult result = settingsForm.ShowDialog();
             string updatedFormat = settingsForm.PostTemplate;
             settingsForm.Dispose();

             Assert.AreEqual(DialogResult.OK, result, "The form did not return Ok");
             Assert.AreNotEqual(twitterPostFormat, updatedFormat);
         }



//===================================================================================================

        // Helper methods

        private MockProperties GetEmptyMockProperties()
        {
            return new MockProperties();
        }

        private MockProperties GetLoadedMockProperties()
        {
            MockProperties m = GetEmptyMockProperties();
            m.SetString("TWITTERACCESSTOKEN", "abc123");
            m.SetString("TWITTERACCESSSECRET", "dummystring-with-numbers21342345");
            m.SetString("BITLYACCESSTOKEN", "another-dummy-string-1234879353");
            m.SetString("BITLYUSERTOKEN", "sstjean");

            return m;
        }

    }
}
