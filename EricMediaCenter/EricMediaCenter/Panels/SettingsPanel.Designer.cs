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
            ((System.ComponentModel.ISupportInitialize)(this.dgvVideoParser)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVideoParser
            // 
            this.dgvVideoParser.AllowUserToAddRows = false;
            this.dgvVideoParser.AllowUserToDeleteRows = false;
            this.dgvVideoParser.AllowUserToResizeRows = false;
            this.dgvVideoParser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVideoParser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVideoParser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colDesc,
            this.colMyVersion,
            this.colNewVersion,
            this.colDownload});
            this.dgvVideoParser.Dock = System.Windows.Forms.DockStyle.Fill;
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
            // SettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvVideoParser);
            this.Name = "SettingsPanel";
            this.Size = new System.Drawing.Size(640, 150);
            this.Load += new System.EventHandler(this.SettingsPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVideoParser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVideoParser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMyVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNewVersion;
        private System.Windows.Forms.DataGridViewLinkColumn colDownload;
    }
}
