using System;

namespace WLW.Twitter.Bitly.Plugin
{
    public partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.OkButton = new System.Windows.Forms.Button();
            this.ConfigureTwitterPostTemplateButton = new System.Windows.Forms.Button();
            this.AuthorizeBitlyButton = new System.Windows.Forms.Button();
            this.AuthorizeTwitterButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(186, 331);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(131, 68);
            this.OkButton.TabIndex = 16;
            this.OkButton.Text = "Done";
            this.OkButton.UseVisualStyleBackColor = true;
            // 
            // ConfigureTwitterPostTemplateButton
            // 
            this.ConfigureTwitterPostTemplateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfigureTwitterPostTemplateButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ConfigureTwitterPostTemplateButton.Location = new System.Drawing.Point(18, 111);
            this.ConfigureTwitterPostTemplateButton.Name = "ConfigureTwitterPostTemplateButton";
            this.ConfigureTwitterPostTemplateButton.Padding = new System.Windows.Forms.Padding(30, 0, 30, 0);
            this.ConfigureTwitterPostTemplateButton.Size = new System.Drawing.Size(467, 75);
            this.ConfigureTwitterPostTemplateButton.TabIndex = 17;
            this.ConfigureTwitterPostTemplateButton.Text = "Configure the Twitter post template";
            this.ConfigureTwitterPostTemplateButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ConfigureTwitterPostTemplateButton.UseVisualStyleBackColor = true;
            this.ConfigureTwitterPostTemplateButton.Click += new System.EventHandler(this.ConfigureTwitterPostTemplate_Click);
            // 
            // AuthorizeBitlyButton
            // 
            this.AuthorizeBitlyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuthorizeBitlyButton.Image = global::WLW.Twitter.Bitly.Plugin.Properties.Resources.pufferfish_small_75px;
            this.AuthorizeBitlyButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AuthorizeBitlyButton.Location = new System.Drawing.Point(18, 219);
            this.AuthorizeBitlyButton.Name = "AuthorizeBitlyButton";
            this.AuthorizeBitlyButton.Padding = new System.Windows.Forms.Padding(30, 0, 30, 0);
            this.AuthorizeBitlyButton.Size = new System.Drawing.Size(467, 75);
            this.AuthorizeBitlyButton.TabIndex = 15;
            this.AuthorizeBitlyButton.Text = "Authorize Plugin at Bitly";
            this.AuthorizeBitlyButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AuthorizeBitlyButton.UseVisualStyleBackColor = true;
            this.AuthorizeBitlyButton.Click += new System.EventHandler(this.AuthorizeBitlyButton_Click);
            // 
            // AuthorizeTwitterButton
            // 
            this.AuthorizeTwitterButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AuthorizeTwitterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuthorizeTwitterButton.Image = global::WLW.Twitter.Bitly.Plugin.Properties.Resources.Twitter_Icon_small_75px;
            this.AuthorizeTwitterButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AuthorizeTwitterButton.Location = new System.Drawing.Point(18, 30);
            this.AuthorizeTwitterButton.Name = "AuthorizeTwitterButton";
            this.AuthorizeTwitterButton.Padding = new System.Windows.Forms.Padding(30, 0, 30, 0);
            this.AuthorizeTwitterButton.Size = new System.Drawing.Size(467, 75);
            this.AuthorizeTwitterButton.TabIndex = 14;
            this.AuthorizeTwitterButton.Text = "Authorize Plugin at Twitter";
            this.AuthorizeTwitterButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AuthorizeTwitterButton.UseVisualStyleBackColor = true;
            this.AuthorizeTwitterButton.Click += new System.EventHandler(this.AuthorizeTwitterButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 411);
            this.Controls.Add(this.ConfigureTwitterPostTemplateButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.AuthorizeBitlyButton);
            this.Controls.Add(this.AuthorizeTwitterButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "Twitter and Bitly Post Plugin";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AuthorizeTwitterButton;
        private System.Windows.Forms.Button AuthorizeBitlyButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button ConfigureTwitterPostTemplateButton;
    }
}