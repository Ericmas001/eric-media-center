namespace EricMediaCenter.Panels
{
    partial class SettingsPanel
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
            this.dgvVideoParser = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMyVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNewVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDownload = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dgvApplication = new System.Windows.Forms.DataGridView();
            this.colPlugin2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDesc2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVersion2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAvailable2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDownload2 = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVideoParser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplication)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVideoParser
            // 
            this.dgvVideoParser.AllowUserToAddRows = false;
            this.dgvVideoParser.AllowUserToDeleteRows = false;
            this.dgvVideoParser.AllowUserToResizeRows = false;
            this.dgvVideoParser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVideoParser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVideoParser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVideoParser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colDesc,
            this.colMyVersion,
            this.colNewVersion,
            this.colDownload});
            this.dgvVideoParser.Location = new System.Drawing.Point(0, 0);
            this.dgvVideoParser.Name = "dgvVideoParser";
            this.dgvVideoParser.RowHeadersVisible = false;
            this.dgvVideoParser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVideoParser.Size = new System.Drawing.Size(640, 150);
            this.dgvVideoParser.TabIndex = 0;
            this.dgvVideoParser.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVideoParser_CellContentClick);
            // 
            // colName
            // 
            this.colName.HeaderText = "Plugin";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colDesc
            // 
            this.colDesc.HeaderText = "Description";
            this.colDesc.Name = "colDesc";
            this.colDesc.ReadOnly = true;
            // 
            // colMyVersion
            // 
            this.colMyVersion.HeaderText = "Version";
            this.colMyVersion.Name = "colMyVersion";
            this.colMyVersion.ReadOnly = true;
            // 
            // colNewVersion
            // 
            this.colNewVersion.HeaderText = "Available";
            this.colNewVersion.Name = "colNewVersion";
            this.colNewVersion.ReadOnly = true;
            // 
            // colDownload
            // 
            this.colDownload.ActiveLinkColor = System.Drawing.Color.Blue;
            this.colDownload.HeaderText = "Download";
            this.colDownload.LinkColor = System.Drawing.Color.Blue;
            this.colDownload.Name = "colDownload";
            this.colDownload.ReadOnly = true;
            this.colDownload.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // dgvApplication
            // 
            this.dgvApplication.AllowUserToAddRows = false;
            this.dgvApplication.AllowUserToDeleteRows = false;
            this.dgvApplication.AllowUserToResizeRows = false;
            this.dgvApplication.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvApplication.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApplication.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplication.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPlugin2,
            this.colDesc2,
            this.colVersion2,
            this.colAvailable2,
            this.colDownload2});
            this.dgvApplication.Location = new System.Drawing.Point(0, 154);
            this.dgvApplication.Name = "dgvApplication";
            this.dgvApplication.RowHeadersVisible = false;
            this.dgvApplication.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApplication.Size = new System.Drawing.Size(640, 150);
            this.dgvApplication.TabIndex = 1;
            this.dgvApplication.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApplication_CellContentClick);
            // 
            // colPlugin2
            // 
            this.colPlugin2.HeaderText = "Plugin";
            this.colPlugin2.Name = "colPlugin2";
            this.colPlugin2.ReadOnly = true;
            // 
            // colDesc2
            // 
            this.colDesc2.HeaderText = "Description";
            this.colDesc2.Name = "colDesc2";
            this.colDesc2.ReadOnly = true;
            // 
            // colVersion2
            // 
            this.colVersion2.HeaderText = "Version";
            this.colVersion2.Name = "colVersion2";
            this.colVersion2.ReadOnly = true;
            // 
            // colAvailable2
            // 
            this.colAvailable2.HeaderText = "Available";
            this.colAvailable2.Name = "colAvailable2";
            this.colAvailable2.ReadOnly = true;
            // 
            // colDownload2
            // 
            this.colDownload2.ActiveLinkColor = System.Drawing.Color.Blue;
            this.colDownload2.HeaderText = "Download";
            this.colDownload2.LinkColor = System.Drawing.Color.Blue;
            this.colDownload2.Name = "colDownload2";
            this.colDownload2.ReadOnly = true;
            this.colDownload2.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // SettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvApplication);
            this.Controls.Add(this.dgvVideoParser);
            this.Name = "SettingsPanel";
            this.Size = new System.Drawing.Size(640, 307);
            this.Load += new System.EventHandler(this.SettingsPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVideoParser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplication)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVideoParser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMyVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNewVersion;
        private System.Windows.Forms.DataGridViewLinkColumn colDownload;
        private System.Windows.Forms.DataGridView dgvApplication;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlugin2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesc2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVersion2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAvailable2;
        private System.Windows.Forms.DataGridViewLinkColumn colDownload2;
    }
}
