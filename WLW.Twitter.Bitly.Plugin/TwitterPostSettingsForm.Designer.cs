namespace WLW.Twitter.Bitly.Plugin
{
    partial class TwitterPostSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TwitterPostSettingsForm));
            this.PostTemplateTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MacroListTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ExampleTweetLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PostTemplateTextBox
            // 
            this.PostTemplateTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PostTemplateTextBox.Location = new System.Drawing.Point(36, 58);
            this.PostTemplateTextBox.Name = "PostTemplateTextBox";
            this.PostTemplateTextBox.Size = new System.Drawing.Size(435, 30);
            this.PostTemplateTextBox.TabIndex = 0;
            this.PostTemplateTextBox.TextChanged += new System.EventHandler(this.PostTemplateTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Twitter post template";
            // 
            // MacroListTextBox
            // 
            this.MacroListTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MacroListTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MacroListTextBox.Location = new System.Drawing.Point(38, 175);
            this.MacroListTextBox.Multiline = true;
            this.MacroListTextBox.Name = "MacroListTextBox";
            this.MacroListTextBox.ReadOnly = true;
            this.MacroListTextBox.Size = new System.Drawing.Size(275, 60);
            this.MacroListTextBox.TabIndex = 2;
            this.MacroListTextBox.TabStop = false;
            this.MacroListTextBox.Text = "Blog post title            <title>\r\nBlog URL                    <url>";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Macros";
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(189, 257);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(131, 54);
            this.OkButton.TabIndex = 4;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(347, 257);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(131, 54);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ExampleTweetLabel
            // 
            this.ExampleTweetLabel.AutoSize = true;
            this.ExampleTweetLabel.ForeColor = System.Drawing.Color.DimGray;
            this.ExampleTweetLabel.Location = new System.Drawing.Point(89, 95);
            this.ExampleTweetLabel.Name = "ExampleTweetLabel";
            this.ExampleTweetLabel.Size = new System.Drawing.Size(283, 20);
            this.ExampleTweetLabel.TabIndex = 6;
            this.ExampleTweetLabel.Text = "[Blog] My Blog Title - http://bit.ly/abc123";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Result:";
            // 
            // TwitterPostSettingsForm
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 323);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ExampleTweetLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.MacroListTextBox);
            this.Controls.Add(this.PostTemplateTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TwitterPostSettingsForm";
            this.Text = "Twitter Post Settings";
            this.Load += new System.EventHandler(this.TwitterPostSettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PostTemplateTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MacroListTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label ExampleTweetLabel;
        private System.Windows.Forms.Label label3;
    }
}