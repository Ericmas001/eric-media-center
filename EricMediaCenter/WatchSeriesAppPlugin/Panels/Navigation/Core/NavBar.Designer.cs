namespace WatchSeriesAppPlugin.Panels.Navigation.Core
{
    partial class NavBar
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCurrent = new VIBlend.WinForms.Controls.vButton();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnCurrent);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(597, 31);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnCurrent
            // 
            this.btnCurrent.AllowAnimations = true;
            this.btnCurrent.BackColor = System.Drawing.Color.Transparent;
            this.btnCurrent.Location = new System.Drawing.Point(3, 3);
            this.btnCurrent.Name = "btnCurrent";
            this.btnCurrent.RoundedCornersMask = ((byte)(15));
            this.btnCurrent.Size = new System.Drawing.Size(23, 23);
            this.btnCurrent.TabIndex = 0;
            this.btnCurrent.Text = "a";
            this.btnCurrent.UseVisualStyleBackColor = false;
            this.btnCurrent.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2010BLUE;
            // 
            // NavBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "NavBar";
            this.Size = new System.Drawing.Size(597, 31);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private VIBlend.WinForms.Controls.vButton btnCurrent;
    }
}
