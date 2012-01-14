namespace EricMediaCenter
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTest = new VIBlend.WinForms.Controls.vToggleButton();
            this.btnSettings = new VIBlend.WinForms.Controls.vToggleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.btnTest);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(161, 352);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // btnTest
            // 
            this.btnTest.AllowAnimations = true;
            this.btnTest.BackColor = System.Drawing.Color.Transparent;
            this.btnTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTest.Location = new System.Drawing.Point(3, 3);
            this.btnTest.Name = "btnTest";
            this.btnTest.RoundedCornersMask = ((byte)(15));
            this.btnTest.Size = new System.Drawing.Size(136, 60);
            this.btnTest.StyleKey = "ToggleButton";
            this.btnTest.TabIndex = 7;
            this.btnTest.Text = "TEST";
            this.btnTest.Toggle = System.Windows.Forms.CheckState.Unchecked;
            this.btnTest.UseVisualStyleBackColor = false;
            this.btnTest.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2010BLUE;
            this.btnTest.ToggleStateChanged += new System.EventHandler(this.btnMenu_ToggleStateChanged);
            this.btnTest.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.AllowAnimations = true;
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.Image = global::EricMediaCenter.Properties.Resources.Control_Panel;
            this.btnSettings.Location = new System.Drawing.Point(15, 370);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.RoundedCornersMask = ((byte)(15));
            this.btnSettings.Size = new System.Drawing.Size(136, 60);
            this.btnSettings.StyleKey = "ToggleButton";
            this.btnSettings.TabIndex = 12;
            this.btnSettings.Text = "Settings";
            this.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSettings.Toggle = System.Windows.Forms.CheckState.Unchecked;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2010BLACK;
            this.btnSettings.ToggleStateChanged += new System.EventHandler(this.btnMenu_ToggleStateChanged);
            this.btnSettings.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(179, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(631, 418);
            this.panel1.TabIndex = 13;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 442);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private VIBlend.WinForms.Controls.vToggleButton btnSettings;
        private VIBlend.WinForms.Controls.vToggleButton btnTest;
        private System.Windows.Forms.Panel panel1;
    }
}

