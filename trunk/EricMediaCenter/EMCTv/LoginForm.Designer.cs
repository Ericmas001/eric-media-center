namespace EMCTv
{
    partial class LoginForm
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
            this.lblUser = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.chkRemember = new System.Windows.Forms.CheckBox();
            this.chkConnect = new System.Windows.Forms.CheckBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(12, 15);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(42, 17);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "User:";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(12, 43);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(43, 17);
            this.lblPass.TabIndex = 1;
            this.lblPass.Text = "Pass:";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(64, 12);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(220, 22);
            this.txtUser.TabIndex = 2;
            this.txtUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUser_KeyDown);
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(64, 40);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '•';
            this.txtPass.Size = new System.Drawing.Size(220, 22);
            this.txtPass.TabIndex = 3;
            this.txtPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPass_KeyDown);
            // 
            // chkRemember
            // 
            this.chkRemember.AutoSize = true;
            this.chkRemember.Location = new System.Drawing.Point(15, 68);
            this.chkRemember.Name = "chkRemember";
            this.chkRemember.Size = new System.Drawing.Size(226, 21);
            this.chkRemember.TabIndex = 4;
            this.chkRemember.Text = "Remember User and Password";
            this.chkRemember.UseVisualStyleBackColor = true;
            this.chkRemember.CheckedChanged += new System.EventHandler(this.chkRemember_CheckedChanged);
            // 
            // chkConnect
            // 
            this.chkConnect.AutoSize = true;
            this.chkConnect.Location = new System.Drawing.Point(15, 95);
            this.chkConnect.Name = "chkConnect";
            this.chkConnect.Size = new System.Drawing.Size(169, 21);
            this.chkConnect.TabIndex = 5;
            this.chkConnect.Text = "Connect Automatically";
            this.chkConnect.UseVisualStyleBackColor = true;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(15, 122);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(269, 26);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Login";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EMCTv.Properties.Resources.wait;
            this.pictureBox1.Location = new System.Drawing.Point(237, 68);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 48);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 156);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.chkConnect);
            this.Controls.Add(this.chkRemember);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.CheckBox chkRemember;
        private System.Windows.Forms.CheckBox chkConnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}