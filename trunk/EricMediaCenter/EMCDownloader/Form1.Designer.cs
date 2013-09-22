namespace EMCDownloader
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.downloadList1 = new EricUtility.Windows.Forms.Downloader.DownloadList();
            this.SuspendLayout();
            // 
            // downloadList1
            // 
            this.downloadList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.downloadList1.Location = new System.Drawing.Point(0, 0);
            this.downloadList1.Margin = new System.Windows.Forms.Padding(4);
            this.downloadList1.Name = "downloadList1";
            this.downloadList1.Size = new System.Drawing.Size(966, 442);
            this.downloadList1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 442);
            this.Controls.Add(this.downloadList1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EMC Downloader";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private EricUtility.Windows.Forms.Downloader.DownloadList downloadList1;
    }
}

