namespace WatchSeriesAppPlugin.Panels.Navigation
{
    partial class UserFavsNavPanel
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
            this.cmsEpisodes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setAsViewedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAsNotViewedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lstNewEpShows = new System.Windows.Forms.ListBox();
            this.lstOtherShows = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnSearch = new VIBlend.WinForms.Controls.vButton();
            this.cmsEpisodes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsEpisodes
            // 
            this.cmsEpisodes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setAsViewedToolStripMenuItem,
            this.setAsNotViewedToolStripMenuItem});
            this.cmsEpisodes.Name = "cmsEpisodes";
            this.cmsEpisodes.Size = new System.Drawing.Size(169, 48);
            // 
            // setAsViewedToolStripMenuItem
            // 
            this.setAsViewedToolStripMenuItem.Name = "setAsViewedToolStripMenuItem";
            this.setAsViewedToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.setAsViewedToolStripMenuItem.Text = "Set as Viewed";
            // 
            // setAsNotViewedToolStripMenuItem
            // 
            this.setAsNotViewedToolStripMenuItem.Name = "setAsNotViewedToolStripMenuItem";
            this.setAsNotViewedToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.setAsNotViewedToolStripMenuItem.Text = "Set as Not Viewed";
            // 
            // lstNewEpShows
            // 
            this.lstNewEpShows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstNewEpShows.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstNewEpShows.FormattingEnabled = true;
            this.lstNewEpShows.IntegralHeight = false;
            this.lstNewEpShows.ItemHeight = 20;
            this.lstNewEpShows.Location = new System.Drawing.Point(0, 0);
            this.lstNewEpShows.Name = "lstNewEpShows";
            this.lstNewEpShows.Size = new System.Drawing.Size(422, 179);
            this.lstNewEpShows.TabIndex = 16;
            this.lstNewEpShows.DoubleClick += new System.EventHandler(this.lstShows_DoubleClick);
            // 
            // lstOtherShows
            // 
            this.lstOtherShows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstOtherShows.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstOtherShows.FormattingEnabled = true;
            this.lstOtherShows.IntegralHeight = false;
            this.lstOtherShows.ItemHeight = 20;
            this.lstOtherShows.Location = new System.Drawing.Point(0, 0);
            this.lstOtherShows.Name = "lstOtherShows";
            this.lstOtherShows.Size = new System.Drawing.Size(422, 175);
            this.lstOtherShows.TabIndex = 17;
            this.lstOtherShows.DoubleClick += new System.EventHandler(this.lstShows_DoubleClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 64);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstNewEpShows);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lstOtherShows);
            this.splitContainer1.Size = new System.Drawing.Size(422, 358);
            this.splitContainer1.SplitterDistance = 179;
            this.splitContainer1.TabIndex = 18;
            // 
            // btnSearch
            // 
            this.btnSearch.AllowAnimations = true;
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(3, 33);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.RoundedCornersMask = ((byte)(15));
            this.btnSearch.Size = new System.Drawing.Size(422, 25);
            this.btnSearch.TabIndex = 19;
            this.btnSearch.Text = "Search for TVShows";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.METROBLUE;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // UserFavsNavPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.splitContainer1);
            this.Name = "UserFavsNavPanel";
            this.Size = new System.Drawing.Size(428, 425);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.cmsEpisodes.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstNewEpShows;
        private System.Windows.Forms.ContextMenuStrip cmsEpisodes;
        private System.Windows.Forms.ToolStripMenuItem setAsViewedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setAsNotViewedToolStripMenuItem;
        private System.Windows.Forms.ListBox lstOtherShows;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private VIBlend.WinForms.Controls.vButton btnSearch;
    }
}
