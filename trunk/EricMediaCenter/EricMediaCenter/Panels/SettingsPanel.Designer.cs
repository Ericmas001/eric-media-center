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
            this.dgvApplication = new System.Windows.Forms.DataGridView();
            this.colPlugin2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDesc2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVersion2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAvailable2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDownload2 = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplication)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvApplication
            // 
            this.dgvApplication.AllowUserToAddRows = false;
            this.dgvApplication.AllowUserToDeleteRows = false;
            this.dgvApplication.AllowUserToResizeRows = false;
            this.dgvApplication.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApplication.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplication.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPlugin2,
            this.colDesc2,
            this.colVersion2,
            this.colAvailable2,
            this.colDownload2});
            this.dgvApplication.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvApplication.Location = new System.Drawing.Point(0, 0);
            this.dgvApplication.Name = "dgvApplication";
            this.dgvApplication.RowHeadersVisible = false;
            this.dgvApplication.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApplication.Size = new System.Drawing.Size(640, 307);
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
            this.Name = "SettingsPanel";
            this.Size = new System.Drawing.Size(640, 307);
            this.Load += new System.EventHandler(this.SettingsPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplication)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvApplication;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlugin2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesc2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVersion2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAvailable2;
        private System.Windows.Forms.DataGridViewLinkColumn colDownload2;
    }
}
