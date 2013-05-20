namespace EMCTv
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tvSearch = new System.Windows.Forms.TreeView();
            this.tvEpisode = new System.Windows.Forms.TreeView();
            this.tvLink = new System.Windows.Forms.TreeView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnRefreshHard = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lstFavs = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAddFavorites = new System.Windows.Forms.Button();
            this.btnDelFavorites = new System.Windows.Forms.Button();
            this.lblShow = new System.Windows.Forms.Label();
            this.btnLastViewed = new System.Windows.Forms.Button();
            this.lblEpisode = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(6, 6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(229, 30);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(241, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(97, 30);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tvSearch
            // 
            this.tvSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvSearch.HideSelection = false;
            this.tvSearch.Location = new System.Drawing.Point(6, 42);
            this.tvSearch.Name = "tvSearch";
            this.tvSearch.Size = new System.Drawing.Size(332, 328);
            this.tvSearch.TabIndex = 2;
            this.tvSearch.DoubleClick += new System.EventHandler(this.tvSearch_DoubleClick);
            // 
            // tvEpisode
            // 
            this.tvEpisode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvEpisode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvEpisode.HideSelection = false;
            this.tvEpisode.Location = new System.Drawing.Point(370, 87);
            this.tvEpisode.Name = "tvEpisode";
            this.tvEpisode.Size = new System.Drawing.Size(373, 339);
            this.tvEpisode.TabIndex = 2;
            this.tvEpisode.DoubleClick += new System.EventHandler(this.tvEpisode_DoubleClick);
            // 
            // tvLink
            // 
            this.tvLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvLink.HideSelection = false;
            this.tvLink.Location = new System.Drawing.Point(749, 87);
            this.tvLink.Name = "tvLink";
            this.tvLink.Size = new System.Drawing.Size(373, 339);
            this.tvLink.TabIndex = 3;
            this.tvLink.DoubleClick += new System.EventHandler(this.tvLink_DoubleClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::EMCTv.Properties.Resources.wait;
            this.pictureBox1.Location = new System.Drawing.Point(1075, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 48);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
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
            this.btnRefreshHard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshHard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnRefreshHard.Location = new System.Drawing.Point(198, 6);
            this.btnRefreshHard.Name = "btnRefreshHard";
            this.btnRefreshHard.Size = new System.Drawing.Size(140, 29);
            this.btnRefreshHard.TabIndex = 2;
            this.btnRefreshHard.Text = "Refresh Hard";
            this.btnRefreshHard.UseVisualStyleBackColor = false;
            this.btnRefreshHard.Click += new System.EventHandler(this.btnRefreshHard_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRefresh.Location = new System.Drawing.Point(6, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(186, 29);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lstFavs
            // 
            this.lstFavs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFavs.FormattingEnabled = true;
            this.lstFavs.IntegralHeight = false;
            this.lstFavs.ItemHeight = 25;
            this.lstFavs.Location = new System.Drawing.Point(6, 41);
            this.lstFavs.Name = "lstFavs";
            this.lstFavs.Size = new System.Drawing.Size(332, 329);
            this.lstFavs.TabIndex = 0;
            this.lstFavs.DoubleClick += new System.EventHandler(this.lstFavs_DoubleClick);
            // 
            // tabPage2
            // 
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
            this.btnAddFavorites.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFavorites.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAddFavorites.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnAddFavorites.Location = new System.Drawing.Point(370, 52);
            this.btnAddFavorites.Name = "btnAddFavorites";
            this.btnAddFavorites.Size = new System.Drawing.Size(187, 29);
            this.btnAddFavorites.TabIndex = 10;
            this.btnAddFavorites.Text = "+ Favorites";
            this.btnAddFavorites.UseVisualStyleBackColor = false;
            this.btnAddFavorites.Click += new System.EventHandler(this.btnAddFavorites_Click);
            // 
            // btnDelFavorites
            // 
            this.btnDelFavorites.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelFavorites.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnDelFavorites.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnDelFavorites.Location = new System.Drawing.Point(563, 53);
            this.btnDelFavorites.Name = "btnDelFavorites";
            this.btnDelFavorites.Size = new System.Drawing.Size(180, 29);
            this.btnDelFavorites.TabIndex = 11;
            this.btnDelFavorites.Text = "- Favorites";
            this.btnDelFavorites.UseVisualStyleBackColor = false;
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
            this.btnLastViewed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLastViewed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnLastViewed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnLastViewed.Location = new System.Drawing.Point(749, 53);
            this.btnLastViewed.Name = "btnLastViewed";
            this.btnLastViewed.Size = new System.Drawing.Size(373, 29);
            this.btnLastViewed.TabIndex = 13;
            this.btnLastViewed.Text = "Set as last viewed";
            this.btnLastViewed.UseVisualStyleBackColor = false;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 433);
            this.Controls.Add(this.lblEpisode);
            this.Controls.Add(this.btnLastViewed);
            this.Controls.Add(this.lblShow);
            this.Controls.Add(this.btnDelFavorites);
            this.Controls.Add(this.btnAddFavorites);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tvLink);
            this.Controls.Add(this.tvEpisode);
            this.MinimumSize = new System.Drawing.Size(1152, 480);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EMC Tv";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TreeView tvSearch;
        private System.Windows.Forms.TreeView tvEpisode;
        private System.Windows.Forms.TreeView tvLink;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox lstFavs;
        private System.Windows.Forms.Button btnRefreshHard;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAddFavorites;
        private System.Windows.Forms.Button btnDelFavorites;
        private System.Windows.Forms.Label lblShow;
        private System.Windows.Forms.Button btnLastViewed;
        private System.Windows.Forms.Label lblEpisode;
    }
}

