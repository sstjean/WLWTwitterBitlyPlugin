using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WLW.Twitter.Bitly.Plugin
{
    public partial class TweetPostReviewForm : Form
    {
        private int tweetLength;
        private string tweet;

        public bool URLShortened { get; set; }

        public string Tweet
        {
            get
            {
                return tweet;
            }

            set
            {
                tweet = value;

            }
        }



        public TweetPostReviewForm(string tweet, bool urlShortened)
        {
            InitializeComponent();
            Tweet = tweet;
            URLShortened = urlShortened;
            this.StartPosition = FormStartPosition.CenterParent;

        }


        private void TweetToPostTextBox_TextChanged(object sender, EventArgs e)
        {
            Tweet = TweetToPostTextBox.Text;
            UpdateTweetLength();
        }


        private void UpdateTweetLength()
        {
            tweetLength = Tweet.Length;
            TweetLengthLabel.Text = String.Format("{0} characters", tweetLength);

            if (tweetLength > 140)
            {
                TweetLengthLabel.ForeColor = Color.Red;
            }
            else
            {
                TweetLengthLabel.ForeColor = Color.Black;

            }

            PostTweetButton.Enabled = TweetLengthLabel.ForeColor == Color.Black;
        }

        private void TweetPostReviewForm_Load(object sender, EventArgs e)
        {
            TweetToPostTextBox.Text = Tweet;
            TweetToPostTextBox.Select(0, 0);
            URLNotShortenedLabel.Visible = !URLShortened;
        }

        private void PostTweetButton_Click(object sender, EventArgs e)
        {

        }

    }
}
