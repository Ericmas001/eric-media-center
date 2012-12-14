namespace EricMediaCenter.Panels
{
    partial class SettingsNavPanel
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
            this.lstMenu = new System.Windows.Forms.ListBox();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lstMenu
            // 
            this.lstMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstMenu.FormattingEnabled = true;
            this.lstMenu.IntegralHeight = false;
            this.lstMenu.Location = new System.Drawing.Point(3, 3);
            this.lstMenu.Name = "lstMenu";
            this.lstMenu.Size = new System.Drawing.Size(120, 299);
            this.lstMenu.TabIndex = 0;
            this.lstMenu.SelectedIndexChanged += new System.EventHandler(this.lstMenu_SelectedIndexChanged);
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.Location = new System.Drawing.Point(129, 3);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(508, 299);
            this.pnlContent.TabIndex = 1;
            // 
            // SettingsNavPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.lstMenu);
            this.Name = "SettingsNavPanel";
            this.Size = new System.Drawing.Size(640, 307);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstMenu;
        private System.Windows.Forms.Panel pnlContent;
    }
}
