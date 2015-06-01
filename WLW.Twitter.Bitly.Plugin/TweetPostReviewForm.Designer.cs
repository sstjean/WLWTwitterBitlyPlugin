namespace WLW.Twitter.Bitly.Plugin
{
    partial class TweetPostReviewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TweetPostReviewForm));
            this.TweetToPostTextBox = new System.Windows.Forms.TextBox();
            this.PostTweetButton = new System.Windows.Forms.Button();
            this.DoNotPostTweetButton = new System.Windows.Forms.Button();
            this.TweetLengthLabel = new System.Windows.Forms.Label();
            this.TweetLabel = new System.Windows.Forms.Label();
            this.URLNotShortenedLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TweetToPostTextBox
            // 
            this.TweetToPostTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TweetToPostTextBox.Location = new System.Drawing.Point(12, 67);
            this.TweetToPostTextBox.Multiline = true;
            this.TweetToPostTextBox.Name = "TweetToPostTextBox";
            this.TweetToPostTextBox.Size = new System.Drawing.Size(751, 162);
            this.TweetToPostTextBox.TabIndex = 0;
            this.TweetToPostTextBox.TextChanged += new System.EventHandler(this.TweetToPostTextBox_TextChanged);
            // 
            // PostTweetButton
            // 
            this.PostTweetButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.PostTweetButton.Location = new System.Drawing.Point(343, 283);
            this.PostTweetButton.Name = "PostTweetButton";
            this.PostTweetButton.Size = new System.Drawing.Size(214, 54);
            this.PostTweetButton.TabIndex = 1;
            this.PostTweetButton.Text = "Post Tweet";
            this.PostTweetButton.UseVisualStyleBackColor = true;
            this.PostTweetButton.Click += new System.EventHandler(this.PostTweetButton_Click);
            // 
            // DoNotPostTweetButton
            // 
            this.DoNotPostTweetButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DoNotPostTweetButton.Location = new System.Drawing.Point(574, 283);
            this.DoNotPostTweetButton.Name = "DoNotPostTweetButton";
            this.DoNotPostTweetButton.Size = new System.Drawing.Size(189, 54);
            this.DoNotPostTweetButton.TabIndex = 2;
            this.DoNotPostTweetButton.Text = "Do not post Tweet";
            this.DoNotPostTweetButton.UseVisualStyleBackColor = true;
            // 
            // TweetLengthLabel
            // 
            this.TweetLengthLabel.AutoSize = true;
            this.TweetLengthLabel.Location = new System.Drawing.Point(13, 232);
            this.TweetLengthLabel.Name = "TweetLengthLabel";
            this.TweetLengthLabel.Size = new System.Drawing.Size(102, 20);
            this.TweetLengthLabel.TabIndex = 3;
            this.TweetLengthLabel.Text = "xx characters";
            // 
            // TweetLabel
            // 
            this.TweetLabel.AutoSize = true;
            this.TweetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TweetLabel.Location = new System.Drawing.Point(12, 21);
            this.TweetLabel.Name = "TweetLabel";
            this.TweetLabel.Size = new System.Drawing.Size(86, 29);
            this.TweetLabel.TabIndex = 4;
            this.TweetLabel.Text = "Tweet";
            // 
            // URLNotShortenedLabel
            // 
            this.URLNotShortenedLabel.AutoSize = true;
            this.URLNotShortenedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.URLNotShortenedLabel.ForeColor = System.Drawing.Color.Red;
            this.URLNotShortenedLabel.Location = new System.Drawing.Point(228, 232);
            this.URLNotShortenedLabel.Name = "URLNotShortenedLabel";
            this.URLNotShortenedLabel.Size = new System.Drawing.Size(535, 20);
            this.URLNotShortenedLabel.TabIndex = 5;
            this.URLNotShortenedLabel.Text = "The URL could not be shortened at Bitly. Long URL shown above.";
            // 
            // TweetPostReviewForm
            // 
            this.AcceptButton = this.PostTweetButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.DoNotPostTweetButton;
            this.ClientSize = new System.Drawing.Size(775, 349);
            this.Controls.Add(this.URLNotShortenedLabel);
            this.Controls.Add(this.TweetLabel);
            this.Controls.Add(this.TweetLengthLabel);
            this.Controls.Add(this.DoNotPostTweetButton);
            this.Controls.Add(this.PostTweetButton);
            this.Controls.Add(this.TweetToPostTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TweetPostReviewForm";
            this.Text = "Live Writer Twitter and Bitly Plugin";
            this.Load += new System.EventHandler(this.TweetPostReviewForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TweetToPostTextBox;
        private System.Windows.Forms.Button PostTweetButton;
        private System.Windows.Forms.Button DoNotPostTweetButton;
        private System.Windows.Forms.Label TweetLengthLabel;
        private System.Windows.Forms.Label TweetLabel;
        private System.Windows.Forms.Label URLNotShortenedLabel;
    }
}