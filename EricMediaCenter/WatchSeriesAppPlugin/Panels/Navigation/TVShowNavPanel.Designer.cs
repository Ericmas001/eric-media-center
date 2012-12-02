namespace WatchSeriesAppPlugin.Panels.Navigation
{
    partial class TVShowNavPanel
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
            this.components = new System.ComponentModel.Container();
            this.lstEpisodes = new System.Windows.Forms.ListBox();
            this.cmsEpisodes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setAsViewedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAsNotViewedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lstSeasons = new System.Windows.Forms.ListBox();
            this.lblShowTitle = new System.Windows.Forms.Label();
            this.btnFav = new System.Windows.Forms.PictureBox();
            this.lblLastViewed = new System.Windows.Forms.Label();
            this.cmsEpisodes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnFav)).BeginInit();
            this.SuspendLayout();
            // 
            // lstEpisodes
            // 
            this.lstEpisodes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstEpisodes.ContextMenuStrip = this.cmsEpisodes;
            this.lstEpisodes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstEpisodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstEpisodes.FormattingEnabled = true;
            this.lstEpisodes.HorizontalScrollbar = true;
            this.lstEpisodes.IntegralHeight = false;
            this.lstEpisodes.ItemHeight = 20;
            this.lstEpisodes.Location = new System.Drawing.Point(162, 89);
            this.lstEpisodes.Name = "lstEpisodes";
            this.lstEpisodes.Size = new System.Drawing.Size(263, 326);
            this.lstEpisodes.TabIndex = 10;
            this.lstEpisodes.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstEpisodes_DrawItem);
            this.lstEpisodes.DoubleClick += new System.EventHandler(this.lstEpisodes_DoubleClick);
            this.lstEpisodes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstEpisodes_MouseDown);
            // 
            // cmsEpisodes
            // 
            this.cmsEpisodes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setAsViewedToolStripMenuItem,
            this.setAsNotViewedToolStripMenuItem});
            this.cmsEpisodes.Name = "cmsEpisodes";
            this.cmsEpisodes.Size = new System.Drawing.Size(169, 48);
            this.cmsEpisodes.Opening += new System.ComponentModel.CancelEventHandler(this.cmsEpisodes_Opening);
            // 
            // setAsViewedToolStripMenuItem
            // 
            this.setAsViewedToolStripMenuItem.Name = "setAsViewedToolStripMenuItem";
            this.setAsViewedToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.setAsViewedToolStripMenuItem.Text = "Set as Viewed";
            this.setAsViewedToolStripMenuItem.Click += new System.EventHandler(this.setAsViewedToolStripMenuItem_Click);
            // 
            // setAsNotViewedToolStripMenuItem
            // 
            this.setAsNotViewedToolStripMenuItem.Name = "setAsNotViewedToolStripMenuItem";
            this.setAsNotViewedToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.setAsNotViewedToolStripMenuItem.Text = "Set as Not Viewed";
            this.setAsNotViewedToolStripMenuItem.Click += new System.EventHandler(this.setAsNotViewedToolStripMenuItem_Click);
            // 
            // lstSeasons
            // 
            this.lstSeasons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstSeasons.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstSeasons.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSeasons.FormattingEnabled = true;
            this.lstSeasons.IntegralHeight = false;
            this.lstSeasons.ItemHeight = 20;
            this.lstSeasons.Location = new System.Drawing.Point(6, 89);
            this.lstSeasons.Name = "lstSeasons";
            this.lstSeasons.Size = new System.Drawing.Size(150, 326);
            this.lstSeasons.TabIndex = 16;
            this.lstSeasons.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstSeasons_DrawItem);
            this.lstSeasons.SelectedIndexChanged += new System.EventHandler(this.lstSeasons_SelectedIndexChanged);
            // 
            // lblShowTitle
            // 
            this.lblShowTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShowTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowTitle.Location = new System.Drawing.Point(42, 37);
            this.lblShowTitle.Name = "lblShowTitle";
            this.lblShowTitle.Size = new System.Drawing.Size(345, 22);
            this.lblShowTitle.TabIndex = 17;
            this.lblShowTitle.Text = "TVShow Title";
            this.lblShowTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFav
            // 
            this.btnFav.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFav.BackgroundImage = global::WatchSeriesAppPlugin.Properties.Resources.favorite_add;
            this.btnFav.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFav.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFav.Location = new System.Drawing.Point(393, 36);
            this.btnFav.Name = "btnFav";
            this.btnFav.Size = new System.Drawing.Size(25, 25);
            this.btnFav.TabIndex = 18;
            this.btnFav.TabStop = false;
            this.btnFav.Click += new System.EventHandler(this.btnFav_Click);
            // 
            // lblLastViewed
            // 
            this.lblLastViewed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastViewed.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblLastViewed.Location = new System.Drawing.Point(3, 64);
            this.lblLastViewed.Name = "lblLastViewed";
            this.lblLastViewed.Size = new System.Drawing.Size(422, 18);
            this.lblLastViewed.TabIndex = 19;
            this.lblLastViewed.Text = "Last Viewed: S01E01";
            this.lblLastViewed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TVShowNavPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblLastViewed);
            this.Controls.Add(this.btnFav);
            this.Controls.Add(this.lblShowTitle);
            this.Controls.Add(this.lstSeasons);
            this.Controls.Add(this.lstEpisodes);
            this.Name = "TVShowNavPanel";
            this.Size = new System.Drawing.Size(428, 425);
            this.Controls.SetChildIndex(this.lstEpisodes, 0);
            this.Controls.SetChildIndex(this.lstSeasons, 0);
            this.Controls.SetChildIndex(this.lblShowTitle, 0);
            this.Controls.SetChildIndex(this.btnFav, 0);
            this.Controls.SetChildIndex(this.lblLastViewed, 0);
            this.cmsEpisodes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnFav)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstEpisodes;
        private System.Windows.Forms.ListBox lstSeasons;
        private System.Windows.Forms.Label lblShowTitle;
        private System.Windows.Forms.PictureBox btnFav;
        private System.Windows.Forms.Label lblLastViewed;
        private System.Windows.Forms.ContextMenuStrip cmsEpisodes;
        private System.Windows.Forms.ToolStripMenuItem setAsViewedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setAsNotViewedToolStripMenuItem;
    }
}
