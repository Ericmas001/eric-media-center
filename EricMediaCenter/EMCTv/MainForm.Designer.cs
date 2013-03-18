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
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(292, 22);
            this.txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(310, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tvSearch
            // 
            this.tvSearch.Location = new System.Drawing.Point(12, 40);
            this.tvSearch.Name = "tvSearch";
            this.tvSearch.Size = new System.Drawing.Size(373, 389);
            this.tvSearch.TabIndex = 2;
            this.tvSearch.DoubleClick += new System.EventHandler(this.tvSearch_DoubleClick);
            // 
            // tvEpisode
            // 
            this.tvEpisode.Location = new System.Drawing.Point(391, 40);
            this.tvEpisode.Name = "tvEpisode";
            this.tvEpisode.Size = new System.Drawing.Size(373, 389);
            this.tvEpisode.TabIndex = 2;
            this.tvEpisode.DoubleClick += new System.EventHandler(this.tvEpisode_DoubleClick);
            // 
            // tvLink
            // 
            this.tvLink.Location = new System.Drawing.Point(770, 40);
            this.tvLink.Name = "tvLink";
            this.tvLink.Size = new System.Drawing.Size(373, 389);
            this.tvLink.TabIndex = 3;
            this.tvLink.DoubleClick += new System.EventHandler(this.tvLink_DoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 436);
            this.Controls.Add(this.tvLink);
            this.Controls.Add(this.tvEpisode);
            this.Controls.Add(this.tvSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "EMC Tv";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TreeView tvSearch;
        private System.Windows.Forms.TreeView tvEpisode;
        private System.Windows.Forms.TreeView tvLink;
    }
}

