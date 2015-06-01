using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WLW.Twitter.Bitly.Plugin;

namespace WLWTwitterBitlyPluginTests
{
    [TestClass]
    public class WLWTwitterBitlyPluginUnitTests
    {

        private string SHORT_BLOG_TITLE = "Title of the blog post";
        private string BITLY_URL = "http://bit.ly/abc123";


        [TestMethod,
        TestCategory("BVT")]
        public void ConstructTweetFormat_AllMacrosUsed_TitleFirst()
        {
            //Arrange
            string expected = "[New Blog] {0} - {1}";
            string template = "[New Blog] " + WLWPluginSettings.TITLEMACRO + " - " + WLWPluginSettings.URLMACRO;

            //Act
            PluginHelpers.TweetTemplate result = PluginHelpers.ConstructTweetFormat(template);

            //Assert
            Assert.AreEqual(expected, result.formatString);
            Assert.IsTrue(result.HasTitle);
            Assert.IsTrue(result.HasUrl);

        }

        [TestMethod,
         TestCategory("BVT")]
        public void ConstructTweetFormat_AllMacrosUsed_URLFirst()
        {
            //Arrange
            string expected = "[New Blog] {1} - {0}";
            string template = "[New Blog] " + WLWPluginSettings.URLMACRO + " - " + WLWPluginSettings.TITLEMACRO;

            //Act
            PluginHelpers.TweetTemplate result = PluginHelpers.ConstructTweetFormat(template);

            //Assert
            Assert.AreEqual(expected, result.formatString);
            Assert.IsTrue(result.HasTitle);
            Assert.IsTrue(result.HasUrl);

        }


        [TestMethod,
         TestCategory("BVT")]
        public void ConstructTweetFormat_OnlyTitleMacrosUsed()
        {
            //Arrange
            string expected = "[New Blog] {0}";
            string template = "[New Blog] " + WLWPluginSettings.TITLEMACRO;

            //Act
            PluginHelpers.TweetTemplate result = PluginHelpers.ConstructTweetFormat(template);

            //Assert
            Assert.AreEqual(expected, result.formatString);
            Assert.IsTrue(result.HasTitle);
            Assert.IsFalse(result.HasUrl);

        }

        [TestMethod,
         TestCategory("BVT")]
        public void ConstructTweetFormat_OnlyUrlMacrosUsed()
        {
            //Arrange
            string expected = "[New Blog] {0}";
            string template = "[New Blog] " + WLWPluginSettings.URLMACRO;

            //Act
            PluginHelpers.TweetTemplate result = PluginHelpers.ConstructTweetFormat(template);

            //Assert
            Assert.AreEqual(expected, result.formatString);
            Assert.IsFalse(result.HasTitle);
            Assert.IsTrue(result.HasUrl);

        }

        // ----------------------------------------------------------------------
        //
        //ClipTitle tests
        //

        [TestMethod,
      TestCategory("BVT")]
        public void ClipTitle_TitleFitsSpace()
        {
            //Arrange
            var plugin = new WLWTwitterBitlyPlugin();
            int remainingSpace = 100;
            string title = "This is a title that is actually around 49 chars.";

            //Act
            string clippedTitle = plugin.ClipTitle(remainingSpace, title);

            //Assert
            Assert.AreEqual(clippedTitle, title, "Title should not have been modified.");
        }

        [TestMethod,
        TestCategory("BVT")]
        public void ClipTitle_TitleFitsSpaceExactly()
        {
            //Arrange
            var plugin = new WLWTwitterBitlyPlugin();
            int remainingSpace = 49;
            string title = "This is a title that is actually around 49 chars.";

            //Act
            string clippedTitle = plugin.ClipTitle(remainingSpace, title);

            //Assert
            Assert.AreEqual(clippedTitle, title, "Title should not have been modified.");
        }

        [TestMethod,
        TestCategory("BVT")]
        public void ClipTitle_TitleDoesNotFitsSpace()
        {
            //Arrange
            var plugin = new WLWTwitterBitlyPlugin();
            int remainingSpace = 30;
            int matchingTitleLength = remainingSpace - 3;
            string title = "This is a title that is actually around 49 chars.";

            //Act
            string clippedTitle = plugin.ClipTitle(remainingSpace, title);

            //Assert
            Assert.AreNotEqual(clippedTitle.Length, title.Length, "Length of titles should be different and are not.");
            Assert.AreEqual(clippedTitle.Substring(0, matchingTitleLength), title.Substring(0, matchingTitleLength), "The titles should match up to the clipping point but they don't.");
        }

        // --------------------------------------------------------------
        //
        //     FormatTweet Tests
        //
        //


        [TestMethod,
        TestCategory("BVT")]
        public void FormatTweet_NoClipping()
        {
            //Arrange
            var plugin = new WLWTwitterBitlyPlugin();
            string template = "[Test Post] <title> - <url>";
            string title = "This title is short enough to fit.";
            PluginHelpers.TweetTemplate formattedTemplate = PluginHelpers.ConstructTweetFormat(template);
            string expected = String.Format(formattedTemplate.formatString, title, this.BITLY_URL);

            //Act
            var formattedMsg = plugin.FormatTweet(template, title, this.BITLY_URL);

            //Assert
            Assert.AreEqual(expected, formattedMsg);
        }

        [TestMethod,
        TestCategory("BVT")]
        public void FormatTweet_NoClippingExactLength()
        {
            //Arrange
            var plugin = new WLWTwitterBitlyPlugin();
            string template = "[Test Post] <title> - <url>";
            string replacedTemplate = "[Test Post] {0} - {1}";

            string title = "This title is quite long.  It would seem like it might not fit and should be truncated but not this time.";
            string expected = String.Format(replacedTemplate, title, this.BITLY_URL);

            //Act
            var formattedMsg = plugin.FormatTweet(template, title, this.BITLY_URL);

            //Assert //100
            Assert.IsTrue(formattedMsg.Length <= 140, "Message length is > 140 chars.  Length: " + formattedMsg.Length);
            Assert.AreEqual(expected, formattedMsg);
        }


        [TestMethod,
        TestCategory("BVT")]
        public void FormatTweet_WithClipping()
        {
            //Arrange
            var plugin = new WLWTwitterBitlyPlugin();
            string template = "<title> - <url>";
            string title = "This title is quite long.  It would seem like it might not fit and should be truncated. That is why we are truncating it.";
            string clippedTitle = "This title is quite long.  It would seem like it might not fit and should be truncated. That is why we are truncat...";
            string expected = String.Format("{0} - {1}", clippedTitle, this.BITLY_URL);

            //Act
            var formattedMsg = plugin.FormatTweet(template, title, this.BITLY_URL);

            //Assert //104
            Assert.IsTrue(formattedMsg.Length == 140, "Message length is > 140 chars.  Length: " + formattedMsg.Length);
            Assert.AreEqual(expected, formattedMsg);
        }

    }
}
