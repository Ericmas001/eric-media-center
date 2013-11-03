namespace EMCCommon.Windows.Forms
{
    partial class SelectSupportedForm
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
            this.btnUseSome = new VIBlend.WinForms.Controls.vButton();
            this.btnUseAll = new VIBlend.WinForms.Controls.vButton();
            this.grpWebsites = new System.Windows.Forms.GroupBox();
            this.chkModel = new System.Windows.Forms.CheckBox();
            this.grpWebsites.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUseSome
            // 
            this.btnUseSome.AllowAnimations = true;
            this.btnUseSome.BackColor = System.Drawing.Color.Transparent;
            this.btnUseSome.Enabled = false;
            this.btnUseSome.Location = new System.Drawing.Point(6, 48);
            this.btnUseSome.Name = "btnUseSome";
            this.btnUseSome.RoundedCornersMask = ((byte)(15));
            this.btnUseSome.Size = new System.Drawing.Size(246, 30);
            this.btnUseSome.TabIndex = 0;
            this.btnUseSome.Text = "Search thru those websites";
            this.btnUseSome.UseVisualStyleBackColor = false;
            this.btnUseSome.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.METROBLUE;
            this.btnUseSome.Click += new System.EventHandler(this.btnUseSome_Click);
            // 
            // btnUseAll
            // 
            this.btnUseAll.AllowAnimations = true;
            this.btnUseAll.BackColor = System.Drawing.Color.Transparent;
            this.btnUseAll.Location = new System.Drawing.Point(12, 12);
            this.btnUseAll.Name = "btnUseAll";
            this.btnUseAll.RoundedCornersMask = ((byte)(15));
            this.btnUseAll.Size = new System.Drawing.Size(258, 30);
            this.btnUseAll.TabIndex = 1;
            this.btnUseAll.Text = "Search thru all websites";
            this.btnUseAll.UseVisualStyleBackColor = false;
            this.btnUseAll.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.METROGREEN;
            this.btnUseAll.Click += new System.EventHandler(this.btnUseAll_Click);
            // 
            // grpWebsites
            // 
            this.grpWebsites.Controls.Add(this.chkModel);
            this.grpWebsites.Controls.Add(this.btnUseSome);
            this.grpWebsites.Location = new System.Drawing.Point(12, 48);
            this.grpWebsites.Name = "grpWebsites";
            this.grpWebsites.Size = new System.Drawing.Size(258, 90);
            this.grpWebsites.TabIndex = 2;
            this.grpWebsites.TabStop = false;
            this.grpWebsites.Text = "Supported Websites";
            // 
            // chkModel
            // 
            this.chkModel.AutoSize = true;
            this.chkModel.Location = new System.Drawing.Point(6, 21);
            this.chkModel.Name = "chkModel";
            this.chkModel.Size = new System.Drawing.Size(90, 21);
            this.chkModel.TabIndex = 0;
            this.chkModel.Text = "chkModel";
            this.chkModel.UseVisualStyleBackColor = true;
            // 
            // SelectSupportedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(282, 153);
            this.Controls.Add(this.grpWebsites);
            this.Controls.Add(this.btnUseAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SelectSupportedForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Website";
            this.grpWebsites.ResumeLayout(false);
            this.grpWebsites.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private VIBlend.WinForms.Controls.vButton btnUseSome;
        private VIBlend.WinForms.Controls.vButton btnUseAll;
        private System.Windows.Forms.GroupBox grpWebsites;
        private System.Windows.Forms.CheckBox chkModel;
    }
}