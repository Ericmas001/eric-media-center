namespace WatchSeriesAppPlugin.Panels.Navigation
{
    partial class TVEpisodeNavPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstLinks = new System.Windows.Forms.ListBox();
            this.lstWebsites = new System.Windows.Forms.ListBox();
            this.lblEpisodeTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstLinks
            // 
            this.lstLinks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstLinks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLinks.FormattingEnabled = true;
            this.lstLinks.HorizontalScrollbar = true;
            this.lstLinks.IntegralHeight = false;
            this.lstLinks.ItemHeight = 20;
            this.lstLinks.Location = new System.Drawing.Point(162, 65);
            this.lstLinks.Name = "lstLinks";
            this.lstLinks.Size = new System.Drawing.Size(263, 350);
            this.lstLinks.TabIndex = 10;
            // 
            // lstWebsites
            // 
            this.lstWebsites.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstWebsites.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstWebsites.FormattingEnabled = true;
            this.lstWebsites.IntegralHeight = false;
            this.lstWebsites.ItemHeight = 20;
            this.lstWebsites.Location = new System.Drawing.Point(6, 65);
            this.lstWebsites.Name = "lstWebsites";
            this.lstWebsites.Size = new System.Drawing.Size(150, 350);
            this.lstWebsites.TabIndex = 16;
            this.lstWebsites.SelectedIndexChanged += new System.EventHandler(this.lstWebsites_SelectedIndexChanged);
            // 
            // lblEpisodeTitle
            // 
            this.lblEpisodeTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEpisodeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEpisodeTitle.Location = new System.Drawing.Point(42, 37);
            this.lblEpisodeTitle.Name = "lblEpisodeTitle";
            this.lblEpisodeTitle.Size = new System.Drawing.Size(345, 22);
            this.lblEpisodeTitle.TabIndex = 17;
            this.lblEpisodeTitle.Text = "TVEpisode Title";
            this.lblEpisodeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TVEpisodeNavPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblEpisodeTitle);
            this.Controls.Add(this.lstWebsites);
            this.Controls.Add(this.lstLinks);
            this.Name = "TVEpisodeNavPanel";
            this.Size = new System.Drawing.Size(428, 425);
            this.Controls.SetChildIndex(this.lstLinks, 0);
            this.Controls.SetChildIndex(this.lstWebsites, 0);
            this.Controls.SetChildIndex(this.lblEpisodeTitle, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstLinks;
        private System.Windows.Forms.ListBox lstWebsites;
        private System.Windows.Forms.Label lblEpisodeTitle;
    }
}
