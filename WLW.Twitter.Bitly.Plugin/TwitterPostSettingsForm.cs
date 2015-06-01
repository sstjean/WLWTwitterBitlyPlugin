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
    public partial class TwitterPostSettingsForm : Form
    {
        public string PostTemplate { get; set; }


        public TwitterPostSettingsForm()
        {
            InitializeComponent();
            this.MacroListTextBox.Text = "Blog post title            " + WLWPluginSettings.TITLEMACRO + "\r\n" + 
                                         "Blog URL                    " + WLWPluginSettings.URLMACRO;
            this.StartPosition = FormStartPosition.CenterParent;

        }

        private void TwitterPostSettingsForm_Load(object sender, EventArgs e)
        {
            this.PostTemplateTextBox.Text = PostTemplate;

        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            PostTemplate = this.PostTemplateTextBox.Text;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PostTemplateTextBox_TextChanged(object sender, EventArgs e)
        {
            PluginHelpers.TweetTemplate template = PluginHelpers.ConstructTweetFormat(PostTemplateTextBox.Text);
            string example = string.Format(template.formatString, "My Blog Title", "http://bit.ly/abc123");
            ExampleTweetLabel.Text = example;
        }


    }
}
