namespace EMCTv.Windows.Forms
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new VIBlend.WinForms.Controls.vButton();
            this.tvSearch = new System.Windows.Forms.TreeView();
            this.ctxtSearch = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openInBrowserToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addToFavoritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tvEpisode = new System.Windows.Forms.TreeView();
            this.ctxtEpisode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.openInBrowserToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.setAsLastViewedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tvLink = new System.Windows.Forms.TreeView();
            this.ctxtLinks = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.openInBrowserToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnRefreshHard = new VIBlend.WinForms.Controls.vButton();
            this.btnRefresh = new VIBlend.WinForms.Controls.vButton();
            this.lstFavs = new System.Windows.Forms.ListBox();
            this.ctxtFavs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openInBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFromFavoritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAddFavorites = new VIBlend.WinForms.Controls.vButton();
            this.btnDelFavorites = new VIBlend.WinForms.Controls.vButton();
            this.lblShow = new System.Windows.Forms.Label();
            this.btnLastViewed = new VIBlend.WinForms.Controls.vButton();
            this.lblEpisode = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLoadAll = new VIBlend.WinForms.Controls.vButton();
            this.btnDebug = new VIBlend.WinForms.Controls.vButton();
            this.btnSupported = new VIBlend.WinForms.Controls.vButton();
            this.ctxtSearch.SuspendLayout();
            this.ctxtEpisode.SuspendLayout();
            this.ctxtLinks.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.ctxtFavs.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(6, 6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(184, 32);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.AllowAnimations = true;
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.Location = new System.Drawing.Point(196, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.RoundedCornersMask = ((byte)(15));
            this.btnSearch.Size = new System.Drawing.Size(113, 30);
            this.btnSearch.TabIndex = 1;
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
            this.tvSearch.Location = new System.Drawing.Point(6, 42);
            this.tvSearch.Name = "tvSearch";
            this.tvSearch.Size = new System.Drawing.Size(332, 328);
            this.tvSearch.TabIndex = 2;
            this.tvSearch.DoubleClick += new System.EventHandler(this.tvSearch_DoubleClick);
            this.tvSearch.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvSearch_MouseDown);
            // 
            // ctxtSearch
            // 
            this.ctxtSearch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem1,
            this.openInBrowserToolStripMenuItem1,
            this.addToFavoritesToolStripMenuItem});
            this.ctxtSearch.Name = "ctxtSearch";
            this.ctxtSearch.Size = new System.Drawing.Size(188, 76);
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
            // addToFavoritesToolStripMenuItem
            // 
            this.addToFavoritesToolStripMenuItem.Name = "addToFavoritesToolStripMenuItem";
            this.addToFavoritesToolStripMenuItem.Size = new System.Drawing.Size(187, 24);
            this.addToFavoritesToolStripMenuItem.Text = "Add to Favorites";
            this.addToFavoritesToolStripMenuItem.Click += new System.EventHandler(this.addToFavoritesToolStripMenuItem_Click);
            // 
            // tvEpisode
            // 
            this.tvEpisode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvEpisode.ContextMenuStrip = this.ctxtEpisode;
            this.tvEpisode.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvEpisode.HideSelection = false;
            this.tvEpisode.Location = new System.Drawing.Point(370, 87);
            this.tvEpisode.Name = "tvEpisode";
            this.tvEpisode.Size = new System.Drawing.Size(373, 309);
            this.tvEpisode.TabIndex = 2;
            this.tvEpisode.DoubleClick += new System.EventHandler(this.tvEpisode_DoubleClick);
            this.tvEpisode.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvEpisode_MouseDown);
            // 
            // ctxtEpisode
            // 
            this.ctxtEpisode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem2,
            this.openInBrowserToolStripMenuItem3,
            this.setAsLastViewedToolStripMenuItem});
            this.ctxtEpisode.Name = "ctxtEpisode";
            this.ctxtEpisode.Size = new System.Drawing.Size(201, 76);
            this.ctxtEpisode.Opening += new System.ComponentModel.CancelEventHandler(this.ctxtEpisode_Opening);
            // 
            // openToolStripMenuItem2
            // 
            this.openToolStripMenuItem2.Name = "openToolStripMenuItem2";
            this.openToolStripMenuItem2.Size = new System.Drawing.Size(200, 24);
            this.openToolStripMenuItem2.Text = "Open";
            this.openToolStripMenuItem2.Click += new System.EventHandler(this.tvEpisode_DoubleClick);
            // 
            // openInBrowserToolStripMenuItem3
            // 
            this.openInBrowserToolStripMenuItem3.Name = "openInBrowserToolStripMenuItem3";
            this.openInBrowserToolStripMenuItem3.Size = new System.Drawing.Size(200, 24);
            this.openInBrowserToolStripMenuItem3.Text = "Open In Browser";
            this.openInBrowserToolStripMenuItem3.Click += new System.EventHandler(this.openInBrowserToolStripMenuItem3_Click);
            // 
            // setAsLastViewedToolStripMenuItem
            // 
            this.setAsLastViewedToolStripMenuItem.Name = "setAsLastViewedToolStripMenuItem";
            this.setAsLastViewedToolStripMenuItem.Size = new System.Drawing.Size(200, 24);
            this.setAsLastViewedToolStripMenuItem.Text = "Set as Last Viewed";
            this.setAsLastViewedToolStripMenuItem.Click += new System.EventHandler(this.setAsLastViewedToolStripMenuItem_Click);
            // 
            // tvLink
            // 
            this.tvLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvLink.ContextMenuStrip = this.ctxtLinks;
            this.tvLink.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvLink.HideSelection = false;
            this.tvLink.Location = new System.Drawing.Point(749, 87);
            this.tvLink.Name = "tvLink";
            this.tvLink.Size = new System.Drawing.Size(373, 339);
            this.tvLink.TabIndex = 3;
            this.tvLink.DoubleClick += new System.EventHandler(this.tvLink_DoubleClick);
            this.tvLink.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvLink_MouseDown);
            // 
            // ctxtLinks
            // 
            this.ctxtLinks.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem3,
            this.openInBrowserToolStripMenuItem2});
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
            // openInBrowserToolStripMenuItem2
            // 
            this.openInBrowserToolStripMenuItem2.Name = "openInBrowserToolStripMenuItem2";
            this.openInBrowserToolStripMenuItem2.Size = new System.Drawing.Size(187, 24);
            this.openInBrowserToolStripMenuItem2.Text = "Open In Browser";
            this.openInBrowserToolStripMenuItem2.Click += new System.EventHandler(this.openInBrowserToolStripMenuItem2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(352, 414);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnRefreshHard);
            this.tabPage1.Controls.Add(this.btnRefresh);
            this.tabPage1.Controls.Add(this.lstFavs);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(344, 376);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Favorites";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnRefreshHard
            // 
            this.btnRefreshHard.AllowAnimations = true;
            this.btnRefreshHard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshHard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnRefreshHard.Location = new System.Drawing.Point(198, 6);
            this.btnRefreshHard.Name = "btnRefreshHard";
            this.btnRefreshHard.RoundedCornersMask = ((byte)(15));
            this.btnRefreshHard.Size = new System.Drawing.Size(140, 29);
            this.btnRefreshHard.TabIndex = 2;
            this.btnRefreshHard.Text = "Refresh Hard";
            this.btnRefreshHard.UseVisualStyleBackColor = false;
            this.btnRefreshHard.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.METROBLUE;
            this.btnRefreshHard.Click += new System.EventHandler(this.btnRefreshHard_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.AllowAnimations = true;
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRefresh.Location = new System.Drawing.Point(6, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.RoundedCornersMask = ((byte)(15));
            this.btnRefresh.Size = new System.Drawing.Size(186, 29);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.METROGREEN;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lstFavs
            // 
            this.lstFavs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFavs.ContextMenuStrip = this.ctxtFavs;
            this.lstFavs.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstFavs.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFavs.FormattingEnabled = true;
            this.lstFavs.IntegralHeight = false;
            this.lstFavs.ItemHeight = 25;
            this.lstFavs.Location = new System.Drawing.Point(6, 41);
            this.lstFavs.Name = "lstFavs";
            this.lstFavs.Size = new System.Drawing.Size(332, 329);
            this.lstFavs.TabIndex = 0;
            this.lstFavs.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstFavs_DrawItem);
            this.lstFavs.DoubleClick += new System.EventHandler(this.lstFavs_DoubleClick);
            this.lstFavs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstFavs_MouseDown);
            // 
            // ctxtFavs
            // 
            this.ctxtFavs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.openInBrowserToolStripMenuItem,
            this.removeFromFavoritesToolStripMenuItem});
            this.ctxtFavs.Name = "ctxtFavs";
            this.ctxtFavs.Size = new System.Drawing.Size(234, 76);
            this.ctxtFavs.Opening += new System.ComponentModel.CancelEventHandler(this.ctxtFavs_Opening);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(233, 24);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.lstFavs_DoubleClick);
            // 
            // openInBrowserToolStripMenuItem
            // 
            this.openInBrowserToolStripMenuItem.Name = "openInBrowserToolStripMenuItem";
            this.openInBrowserToolStripMenuItem.Size = new System.Drawing.Size(233, 24);
            this.openInBrowserToolStripMenuItem.Text = "Open In Browser";
            this.openInBrowserToolStripMenuItem.Click += new System.EventHandler(this.openInBrowserToolStripMenuItem_Click);
            // 
            // removeFromFavoritesToolStripMenuItem
            // 
            this.removeFromFavoritesToolStripMenuItem.Name = "removeFromFavoritesToolStripMenuItem";
            this.removeFromFavoritesToolStripMenuItem.Size = new System.Drawing.Size(233, 24);
            this.removeFromFavoritesToolStripMenuItem.Text = "Remove From Favorites";
            this.removeFromFavoritesToolStripMenuItem.Click += new System.EventHandler(this.removeFromFavoritesToolStripMenuItem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnSupported);
            this.tabPage2.Controls.Add(this.txtSearch);
            this.tabPage2.Controls.Add(this.btnSearch);
            this.tabPage2.Controls.Add(this.tvSearch);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(344, 376);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Search";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnAddFavorites
            // 
            this.btnAddFavorites.AllowAnimations = true;
            this.btnAddFavorites.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFavorites.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAddFavorites.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnAddFavorites.Location = new System.Drawing.Point(370, 52);
            this.btnAddFavorites.Name = "btnAddFavorites";
            this.btnAddFavorites.RoundedCornersMask = ((byte)(15));
            this.btnAddFavorites.Size = new System.Drawing.Size(187, 29);
            this.btnAddFavorites.TabIndex = 10;
            this.btnAddFavorites.Text = "+ Favorites";
            this.btnAddFavorites.UseVisualStyleBackColor = false;
            this.btnAddFavorites.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.METROGREEN;
            this.btnAddFavorites.Click += new System.EventHandler(this.btnAddFavorites_Click);
            // 
            // btnDelFavorites
            // 
            this.btnDelFavorites.AllowAnimations = true;
            this.btnDelFavorites.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelFavorites.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnDelFavorites.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnDelFavorites.Location = new System.Drawing.Point(563, 53);
            this.btnDelFavorites.Name = "btnDelFavorites";
            this.btnDelFavorites.RoundedCornersMask = ((byte)(15));
            this.btnDelFavorites.Size = new System.Drawing.Size(180, 29);
            this.btnDelFavorites.TabIndex = 11;
            this.btnDelFavorites.Text = "- Favorites";
            this.btnDelFavorites.UseVisualStyleBackColor = false;
            this.btnDelFavorites.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.METROORANGE;
            this.btnDelFavorites.Click += new System.EventHandler(this.btnDelFavorites_Click);
            // 
            // lblShow
            // 
            this.lblShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShow.Location = new System.Drawing.Point(367, 9);
            this.lblShow.Name = "lblShow";
            this.lblShow.Size = new System.Drawing.Size(376, 39);
            this.lblShow.TabIndex = 12;
            this.lblShow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLastViewed
            // 
            this.btnLastViewed.AllowAnimations = true;
            this.btnLastViewed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLastViewed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnLastViewed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnLastViewed.Location = new System.Drawing.Point(749, 53);
            this.btnLastViewed.Name = "btnLastViewed";
            this.btnLastViewed.RoundedCornersMask = ((byte)(15));
            this.btnLastViewed.Size = new System.Drawing.Size(373, 29);
            this.btnLastViewed.TabIndex = 13;
            this.btnLastViewed.Text = "Set as last viewed";
            this.btnLastViewed.UseVisualStyleBackColor = false;
            this.btnLastViewed.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.METROGREEN;
            this.btnLastViewed.Click += new System.EventHandler(this.btnLastViewed_Click);
            // 
            // lblEpisode
            // 
            this.lblEpisode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEpisode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEpisode.Location = new System.Drawing.Point(815, 9);
            this.lblEpisode.Name = "lblEpisode";
            this.lblEpisode.Size = new System.Drawing.Size(254, 39);
            this.lblEpisode.TabIndex = 14;
            this.lblEpisode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // btnLoadAll
            // 
            this.btnLoadAll.AllowAnimations = true;
            this.btnLoadAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLoadAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnLoadAll.Location = new System.Drawing.Point(370, 397);
            this.btnLoadAll.Name = "btnLoadAll";
            this.btnLoadAll.RoundedCornersMask = ((byte)(15));
            this.btnLoadAll.Size = new System.Drawing.Size(373, 29);
            this.btnLoadAll.TabIndex = 15;
            this.btnLoadAll.Text = "Load All";
            this.btnLoadAll.UseVisualStyleBackColor = false;
            this.btnLoadAll.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.METROBLUE;
            this.btnLoadAll.Click += new System.EventHandler(this.btnLoadAll_Click);
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
            this.btnDebug.TabIndex = 20;
            this.btnDebug.UseVisualStyleBackColor = false;
            this.btnDebug.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.METROORANGE;
            this.btnDebug.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // btnSupported
            // 
            this.btnSupported.AllowAnimations = true;
            this.btnSupported.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSupported.BackColor = System.Drawing.Color.Transparent;
            this.btnSupported.Location = new System.Drawing.Point(315, 8);
            this.btnSupported.Name = "btnSupported";
            this.btnSupported.RoundedCornersMask = ((byte)(15));
            this.btnSupported.Size = new System.Drawing.Size(23, 30);
            this.btnSupported.TabIndex = 3;
            this.btnSupported.Text = "‡";
            this.btnSupported.UseVisualStyleBackColor = true;
            this.btnSupported.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.METROBLUE;
            this.btnSupported.Click += new System.EventHandler(this.btnSupported_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1134, 433);
            this.Controls.Add(this.btnDebug);
            this.Controls.Add(this.btnLoadAll);
            this.Controls.Add(this.lblEpisode);
            this.Controls.Add(this.btnLastViewed);
            this.Controls.Add(this.lblShow);
            this.Controls.Add(this.btnDelFavorites);
            this.Controls.Add(this.btnAddFavorites);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tvLink);
            this.Controls.Add(this.tvEpisode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1152, 480);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EMC Tv";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ctxtSearch.ResumeLayout(false);
            this.ctxtEpisode.ResumeLayout(false);
            this.ctxtLinks.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ctxtFavs.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private VIBlend.WinForms.Controls.vButton btnSearch;
        private System.Windows.Forms.TreeView tvSearch;
        private System.Windows.Forms.TreeView tvEpisode;
        private System.Windows.Forms.TreeView tvLink;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox lstFavs;
        private VIBlend.WinForms.Controls.vButton btnRefreshHard;
        private VIBlend.WinForms.Controls.vButton btnRefresh;
        private VIBlend.WinForms.Controls.vButton btnAddFavorites;
        private VIBlend.WinForms.Controls.vButton btnDelFavorites;
        private System.Windows.Forms.Label lblShow;
        private VIBlend.WinForms.Controls.vButton btnLastViewed;
        private System.Windows.Forms.Label lblEpisode;
        private VIBlend.WinForms.Controls.vButton btnLoadAll;
        private System.Windows.Forms.ContextMenuStrip ctxtFavs;
        private System.Windows.Forms.ToolStripMenuItem openInBrowserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFromFavoritesToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ctxtSearch;
        private System.Windows.Forms.ToolStripMenuItem openInBrowserToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addToFavoritesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ctxtEpisode;
        private System.Windows.Forms.ContextMenuStrip ctxtLinks;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem setAsLastViewedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openInBrowserToolStripMenuItem2;
        private VIBlend.WinForms.Controls.vButton btnDebug;
        private System.Windows.Forms.ToolStripMenuItem openInBrowserToolStripMenuItem3;
        private VIBlend.WinForms.Controls.vButton btnSupported;
    }
}

