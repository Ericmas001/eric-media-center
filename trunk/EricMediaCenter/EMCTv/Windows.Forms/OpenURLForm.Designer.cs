namespace EMCTv.Windows.Forms
{
    partial class OpenURLForm
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
            this.btnDwldBrowser = new VIBlend.WinForms.Controls.vButton();
            this.btnDwldClipboard = new VIBlend.WinForms.Controls.vButton();
            this.btnStreamBrowser = new VIBlend.WinForms.Controls.vButton();
            this.SuspendLayout();
            // 
            // btnDwldBrowser
            // 
            this.btnDwldBrowser.AllowAnimations = true;
            this.btnDwldBrowser.BackColor = System.Drawing.Color.Transparent;
            this.btnDwldBrowser.Location = new System.Drawing.Point(12, 12);
            this.btnDwldBrowser.Name = "btnDwldBrowser";
            this.btnDwldBrowser.RoundedCornersMask = ((byte)(15));
            this.btnDwldBrowser.Size = new System.Drawing.Size(258, 30);
            this.btnDwldBrowser.TabIndex = 0;
            this.btnDwldBrowser.Text = "Open Download URL in browser";
            this.btnDwldBrowser.UseVisualStyleBackColor = false;
            this.btnDwldBrowser.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.METROBLUE;
            this.btnDwldBrowser.Click += new System.EventHandler(this.btnDwldBrowser_Click);
            // 
            // btnDwldClipboard
            // 
            this.btnDwldClipboard.AllowAnimations = true;
            this.btnDwldClipboard.BackColor = System.Drawing.Color.Transparent;
            this.btnDwldClipboard.Location = new System.Drawing.Point(12, 48);
            this.btnDwldClipboard.Name = "btnDwldClipboard";
            this.btnDwldClipboard.RoundedCornersMask = ((byte)(15));
            this.btnDwldClipboard.Size = new System.Drawing.Size(258, 30);
            this.btnDwldClipboard.TabIndex = 1;
            this.btnDwldClipboard.Text = "Copy Download URL to Clipboard";
            this.btnDwldClipboard.UseVisualStyleBackColor = false;
            this.btnDwldClipboard.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.METROGREEN;
            this.btnDwldClipboard.Click += new System.EventHandler(this.btnDwldClipboard_Click);
            // 
            // btnStreamBrowser
            // 
            this.btnStreamBrowser.AllowAnimations = true;
            this.btnStreamBrowser.BackColor = System.Drawing.Color.Transparent;
            this.btnStreamBrowser.Location = new System.Drawing.Point(12, 84);
            this.btnStreamBrowser.Name = "btnStreamBrowser";
            this.btnStreamBrowser.RoundedCornersMask = ((byte)(15));
            this.btnStreamBrowser.Size = new System.Drawing.Size(258, 30);
            this.btnStreamBrowser.TabIndex = 2;
            this.btnStreamBrowser.Text = "Open Streaming URL in browser";
            this.btnStreamBrowser.UseVisualStyleBackColor = false;
            this.btnStreamBrowser.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.METROORANGE;
            this.btnStreamBrowser.Click += new System.EventHandler(this.btnStreamBrowser_Click);
            // 
            // OpenURLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(282, 124);
            this.Controls.Add(this.btnStreamBrowser);
            this.Controls.Add(this.btnDwldClipboard);
            this.Controls.Add(this.btnDwldBrowser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OpenURLForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "What do you want to do ...";
            this.ResumeLayout(false);

        }

        #endregion

        private VIBlend.WinForms.Controls.vButton btnDwldBrowser;
        private VIBlend.WinForms.Controls.vButton btnDwldClipboard;
        private VIBlend.WinForms.Controls.vButton btnStreamBrowser;
    }
}