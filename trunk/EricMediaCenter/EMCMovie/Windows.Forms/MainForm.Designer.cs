namespace EMCMovie.Windows.Forms
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ctxtSearch = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openInBrowserToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tvLink = new System.Windows.Forms.TreeView();
            this.ctxtLinks = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.openInBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMovie = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new VIBlend.WinForms.Controls.vButton();
            this.tvSearch = new System.Windows.Forms.TreeView();
            this.btnDebug = new VIBlend.WinForms.Controls.vButton();
            this.ctxtSearch.SuspendLayout();
            this.ctxtLinks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ctxtSearch
            // 
            this.ctxtSearch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem1,
            this.openInBrowserToolStripMenuItem1});
            this.ctxtSearch.Name = "ctxtSearch";
            this.ctxtSearch.Size = new System.Drawing.Size(188, 52);
            this.ctxtSearch.Opening += new System.ComponentModel.CancelEventHandler(this.ctxtSearch_Opening);
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(187, 24);
            this.openToolStripMenuItem1.Text = "Open";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.tvSearch_DoubleClick);
            // 
            // openInBrowserToolStripMenuItem1
            // 
            this.openInBrowserToolStripMenuItem1.Name = "openInBrowserToolStripMenuItem1";
            this.openInBrowserToolStripMenuItem1.Size = new System.Drawing.Size(187, 24);
            this.openInBrowserToolStripMenuItem1.Text = "Open In Browser";
            this.openInBrowserToolStripMenuItem1.Click += new System.EventHandler(this.openInBrowserToolStripMenuItem1_Click);
            // 
            // tvLink
            // 
            this.tvLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvLink.ContextMenuStrip = this.ctxtLinks;
            this.tvLink.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvLink.HideSelection = false;
            this.tvLink.Location = new System.Drawing.Point(562, 54);
            this.tvLink.Name = "tvLink";
            this.tvLink.Size = new System.Drawing.Size(560, 372);
            this.tvLink.TabIndex = 3;
            this.tvLink.DoubleClick += new System.EventHandler(this.tvLink_DoubleClick);
            this.tvLink.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvLink_MouseDown);
            // 
            // ctxtLinks
            // 
            this.ctxtLinks.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem3,
            this.openInBrowserToolStripMenuItem});
            this.ctxtLinks.Name = "ctxtLinks";
            this.ctxtLinks.Size = new System.Drawing.Size(188, 52);
            this.ctxtLinks.Opening += new System.ComponentModel.CancelEventHandler(this.ctxtLinks_Opening);
            // 
            // openToolStripMenuItem3
            // 
            this.openToolStripMenuItem3.Name = "openToolStripMenuItem3";
            this.openToolStripMenuItem3.Size = new System.Drawing.Size(187, 24);
            this.openToolStripMenuItem3.Text = "Open";
            this.openToolStripMenuItem3.Click += new System.EventHandler(this.tvLink_DoubleClick);
            // 
            // openInBrowserToolStripMenuItem
            // 
            this.openInBrowserToolStripMenuItem.Name = "openInBrowserToolStripMenuItem";
            this.openInBrowserToolStripMenuItem.Size = new System.Drawing.Size(187, 24);
            this.openInBrowserToolStripMenuItem.Text = "Open In Browser";
            this.openInBrowserToolStripMenuItem.Click += new System.EventHandler(this.openInBrowserToolStripMenuItem_Click);
            // 
            // lblMovie
            // 
            this.lblMovie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMovie.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovie.Location = new System.Drawing.Point(630, 9);
            this.lblMovie.Name = "lblMovie";
            this.lblMovie.Size = new System.Drawing.Size(439, 39);
            this.lblMovie.TabIndex = 14;
            this.lblMovie.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1075, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 48);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(12, 14);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(441, 32);
            this.txtSearch.TabIndex = 16;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.AllowAnimations = true;
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSearch.Location = new System.Drawing.Point(459, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.RoundedCornersMask = ((byte)(15));
            this.btnSearch.Size = new System.Drawing.Size(97, 30);
            this.btnSearch.TabIndex = 17;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.METROGREEN;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tvSearch
            // 
            this.tvSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvSearch.ContextMenuStrip = this.ctxtSearch;
            this.tvSearch.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvSearch.HideSelection = false;
            this.tvSearch.Location = new System.Drawing.Point(12, 54);
            this.tvSearch.Name = "tvSearch";
            this.tvSearch.Size = new System.Drawing.Size(544, 372);
            this.tvSearch.TabIndex = 18;
            this.tvSearch.DoubleClick += new System.EventHandler(this.tvSearch_DoubleClick);
            this.tvSearch.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvSearch_MouseDown);
            // 
            // btnDebug
            // 
            this.btnDebug.AllowAnimations = true;
            this.btnDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDebug.BackColor = System.Drawing.Color.Transparent;
            this.btnDebug.Location = new System.Drawing.Point(1123, 0);
            this.btnDebug.Name = "btnDebug";
            this.btnDebug.RoundedCornersMask = ((byte)(15));
            this.btnDebug.Size = new System.Drawing.Size(11, 10);
            this.btnDebug.TabIndex = 19;
            this.btnDebug.UseVisualStyleBackColor = false;
            this.btnDebug.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.METROORANGE;
            this.btnDebug.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1134, 433);
            this.Controls.Add(this.btnDebug);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tvSearch);
            this.Controls.Add(this.lblMovie);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tvLink);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1152, 480);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EMC Movie";
            this.ctxtSearch.ResumeLayout(false);
            this.ctxtLinks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvLink;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblMovie;
        private System.Windows.Forms.ContextMenuStrip ctxtSearch;
        private System.Windows.Forms.ToolStripMenuItem openInBrowserToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip ctxtLinks;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem3;
        private System.Windows.Forms.TextBox txtSearch;
        private VIBlend.WinForms.Controls.vButton btnSearch;
        private System.Windows.Forms.TreeView tvSearch;
        private System.Windows.Forms.ToolStripMenuItem openInBrowserToolStripMenuItem;
        private VIBlend.WinForms.Controls.vButton btnDebug;
    }
}

