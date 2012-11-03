namespace WatchSeriesAppPlugin
{
    partial class NavPanel
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
            this.navBar1 = new WatchSeriesAppPlugin.NavBar();
            this.SuspendLayout();
            // 
            // navBar1
            // 
            this.navBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.navBar1.Location = new System.Drawing.Point(3, 3);
            this.navBar1.Name = "navBar1";
            this.navBar1.Size = new System.Drawing.Size(543, 31);
            this.navBar1.TabIndex = 8;
            // 
            // NavPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.navBar1);
            this.Name = "NavPanel";
            this.Size = new System.Drawing.Size(549, 417);
            this.ResumeLayout(false);

        }

        #endregion

        private NavBar navBar1;

    }
}
