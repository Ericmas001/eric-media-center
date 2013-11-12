namespace EMCCommon.Windows.Forms
{
    partial class GlobalSettingsForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtWsCustom = new System.Windows.Forms.TextBox();
            this.rdWsCustom = new System.Windows.Forms.RadioButton();
            this.rdWsDebug = new System.Windows.Forms.RadioButton();
            this.rdWsNormal = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEMCDfolder = new VIBlend.WinForms.Controls.vButton();
            this.btnEMCDpath = new VIBlend.WinForms.Controls.vButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEMCDfolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEMCDpath = new System.Windows.Forms.TextBox();
            this.fbdEMCDfolder = new System.Windows.Forms.FolderBrowserDialog();
            this.ofdEMCDpath = new System.Windows.Forms.OpenFileDialog();
            this.btnSave = new VIBlend.WinForms.Controls.vButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtWsCustom);
            this.groupBox1.Controls.Add(this.rdWsCustom);
            this.groupBox1.Controls.Add(this.rdWsDebug);
            this.groupBox1.Controls.Add(this.rdWsNormal);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(654, 106);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "WebService";
            // 
            // txtWsCustom
            // 
            this.txtWsCustom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWsCustom.Enabled = false;
            this.txtWsCustom.Location = new System.Drawing.Point(96, 75);
            this.txtWsCustom.Name = "txtWsCustom";
            this.txtWsCustom.Size = new System.Drawing.Size(543, 22);
            this.txtWsCustom.TabIndex = 1;
            // 
            // rdWsCustom
            // 
            this.rdWsCustom.AutoSize = true;
            this.rdWsCustom.Location = new System.Drawing.Point(6, 76);
            this.rdWsCustom.Name = "rdWsCustom";
            this.rdWsCustom.Size = new System.Drawing.Size(84, 21);
            this.rdWsCustom.TabIndex = 2;
            this.rdWsCustom.Text = "Custom: ";
            this.rdWsCustom.UseVisualStyleBackColor = true;
            this.rdWsCustom.CheckedChanged += new System.EventHandler(this.rdWsCustom_CheckedChanged);
            // 
            // rdWsDebug
            // 
            this.rdWsDebug.AutoSize = true;
            this.rdWsDebug.Location = new System.Drawing.Point(6, 49);
            this.rdWsDebug.Name = "rdWsDebug";
            this.rdWsDebug.Size = new System.Drawing.Size(79, 21);
            this.rdWsDebug.TabIndex = 1;
            this.rdWsDebug.Text = "Debug: ";
            this.rdWsDebug.UseVisualStyleBackColor = true;
            // 
            // rdWsNormal
            // 
            this.rdWsNormal.AutoSize = true;
            this.rdWsNormal.Checked = true;
            this.rdWsNormal.Location = new System.Drawing.Point(6, 21);
            this.rdWsNormal.Name = "rdWsNormal";
            this.rdWsNormal.Size = new System.Drawing.Size(187, 21);
            this.rdWsNormal.TabIndex = 0;
            this.rdWsNormal.TabStop = true;
            this.rdWsNormal.Text = "Normal (Recommended):";
            this.rdWsNormal.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEMCDfolder);
            this.groupBox2.Controls.Add(this.btnEMCDpath);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtEMCDfolder);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtEMCDpath);
            this.groupBox2.Location = new System.Drawing.Point(12, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(654, 83);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "EMC Downloader";
            // 
            // btnEMCDfolder
            // 
            this.btnEMCDfolder.AllowAnimations = true;
            this.btnEMCDfolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEMCDfolder.BackColor = System.Drawing.Color.Transparent;
            this.btnEMCDfolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnEMCDfolder.Location = new System.Drawing.Point(631, 49);
            this.btnEMCDfolder.Name = "btnEMCDfolder";
            this.btnEMCDfolder.RoundedCornersMask = ((byte)(15));
            this.btnEMCDfolder.Size = new System.Drawing.Size(18, 22);
            this.btnEMCDfolder.TabIndex = 23;
            this.btnEMCDfolder.Text = ">";
            this.btnEMCDfolder.UseVisualStyleBackColor = true;
            this.btnEMCDfolder.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.METROBLUE;
            this.btnEMCDfolder.Click += new System.EventHandler(this.btnEMCDfolder_Click);
            // 
            // btnEMCDpath
            // 
            this.btnEMCDpath.AllowAnimations = true;
            this.btnEMCDpath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEMCDpath.BackColor = System.Drawing.Color.Transparent;
            this.btnEMCDpath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnEMCDpath.Location = new System.Drawing.Point(631, 21);
            this.btnEMCDpath.Name = "btnEMCDpath";
            this.btnEMCDpath.RoundedCornersMask = ((byte)(15));
            this.btnEMCDpath.Size = new System.Drawing.Size(18, 22);
            this.btnEMCDpath.TabIndex = 22;
            this.btnEMCDpath.Text = ">";
            this.btnEMCDpath.UseVisualStyleBackColor = true;
            this.btnEMCDpath.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.METROBLUE;
            this.btnEMCDpath.Click += new System.EventHandler(this.btnEMCDpath_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Download Folder:";
            // 
            // txtEMCDfolder
            // 
            this.txtEMCDfolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEMCDfolder.Location = new System.Drawing.Point(130, 49);
            this.txtEMCDfolder.Name = "txtEMCDfolder";
            this.txtEMCDfolder.ReadOnly = true;
            this.txtEMCDfolder.Size = new System.Drawing.Size(495, 22);
            this.txtEMCDfolder.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Application Path:";
            // 
            // txtEMCDpath
            // 
            this.txtEMCDpath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEMCDpath.Location = new System.Drawing.Point(130, 21);
            this.txtEMCDpath.Name = "txtEMCDpath";
            this.txtEMCDpath.ReadOnly = true;
            this.txtEMCDpath.Size = new System.Drawing.Size(495, 22);
            this.txtEMCDpath.TabIndex = 1;
            // 
            // fbdEMCDfolder
            // 
            this.fbdEMCDfolder.RootFolder = System.Environment.SpecialFolder.MyDocuments;
            // 
            // ofdEMCDpath
            // 
            this.ofdEMCDpath.FileName = "EMCDownloader.exe";
            this.ofdEMCDpath.Filter = "EMCDownloader.exe|EMCDownloader.exe|Exe File|*.exe|All files|*.*";
            // 
            // btnSave
            // 
            this.btnSave.AllowAnimations = true;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSave.Location = new System.Drawing.Point(262, 213);
            this.btnSave.Name = "btnSave";
            this.btnSave.RoundedCornersMask = ((byte)(15));
            this.btnSave.Size = new System.Drawing.Size(193, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save Settings";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.METROGREEN;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // GlobalSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 248);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GlobalSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtWsCustom;
        private System.Windows.Forms.RadioButton rdWsCustom;
        private System.Windows.Forms.RadioButton rdWsDebug;
        private System.Windows.Forms.RadioButton rdWsNormal;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtEMCDpath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEMCDfolder;
        private System.Windows.Forms.Label label1;
        private VIBlend.WinForms.Controls.vButton btnEMCDfolder;
        private VIBlend.WinForms.Controls.vButton btnEMCDpath;
        private System.Windows.Forms.FolderBrowserDialog fbdEMCDfolder;
        private System.Windows.Forms.OpenFileDialog ofdEMCDpath;
        private VIBlend.WinForms.Controls.vButton btnSave;
    }
}