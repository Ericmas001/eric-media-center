namespace EricMediaCenter.Panels
{
    partial class TestPanel
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOfficialVP = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lblOfficialVP = new System.Windows.Forms.Label();
            this.btnFakeVP001 = new System.Windows.Forms.Button();
            this.lblFakeVP001 = new System.Windows.Forms.Label();
            this.btnFakeVP002 = new System.Windows.Forms.Button();
            this.lblFakeVP002 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(129, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 169);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Try and Parse";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(339, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "TRY";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(12, 136);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(405, 20);
            this.textBox3.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Download URL:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 97);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(405, 20);
            this.textBox2.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Video URL:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "RESULT:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(405, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "URL:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Supported:";
            // 
            // btnOfficialVP
            // 
            this.btnOfficialVP.Location = new System.Drawing.Point(3, 5);
            this.btnOfficialVP.Name = "btnOfficialVP";
            this.btnOfficialVP.Size = new System.Drawing.Size(120, 23);
            this.btnOfficialVP.TabIndex = 7;
            this.btnOfficialVP.Text = "download";
            this.btnOfficialVP.UseVisualStyleBackColor = true;
            this.btnOfficialVP.Visible = false;
            this.btnOfficialVP.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox1.Enabled = false;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(6, 105);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 173);
            this.listBox1.TabIndex = 6;
            // 
            // lblOfficialVP
            // 
            this.lblOfficialVP.AutoSize = true;
            this.lblOfficialVP.Location = new System.Drawing.Point(138, 10);
            this.lblOfficialVP.Name = "lblOfficialVP";
            this.lblOfficialVP.Size = new System.Drawing.Size(89, 13);
            this.lblOfficialVP.TabIndex = 5;
            this.lblOfficialVP.Text = "Loading parser ...";
            // 
            // btnFakeVP001
            // 
            this.btnFakeVP001.Location = new System.Drawing.Point(3, 34);
            this.btnFakeVP001.Name = "btnFakeVP001";
            this.btnFakeVP001.Size = new System.Drawing.Size(120, 23);
            this.btnFakeVP001.TabIndex = 11;
            this.btnFakeVP001.Text = "download";
            this.btnFakeVP001.UseVisualStyleBackColor = true;
            this.btnFakeVP001.Visible = false;
            this.btnFakeVP001.Click += new System.EventHandler(this.btnFakeVP001_Click);
            // 
            // lblFakeVP001
            // 
            this.lblFakeVP001.AutoSize = true;
            this.lblFakeVP001.Location = new System.Drawing.Point(138, 39);
            this.lblFakeVP001.Name = "lblFakeVP001";
            this.lblFakeVP001.Size = new System.Drawing.Size(89, 13);
            this.lblFakeVP001.TabIndex = 10;
            this.lblFakeVP001.Text = "Loading parser ...";
            // 
            // btnFakeVP002
            // 
            this.btnFakeVP002.Location = new System.Drawing.Point(3, 63);
            this.btnFakeVP002.Name = "btnFakeVP002";
            this.btnFakeVP002.Size = new System.Drawing.Size(120, 23);
            this.btnFakeVP002.TabIndex = 13;
            this.btnFakeVP002.Text = "download";
            this.btnFakeVP002.UseVisualStyleBackColor = true;
            this.btnFakeVP002.Visible = false;
            this.btnFakeVP002.Click += new System.EventHandler(this.btnFakeVP002_Click);
            // 
            // lblFakeVP002
            // 
            this.lblFakeVP002.AutoSize = true;
            this.lblFakeVP002.Location = new System.Drawing.Point(138, 68);
            this.lblFakeVP002.Name = "lblFakeVP002";
            this.lblFakeVP002.Size = new System.Drawing.Size(89, 13);
            this.lblFakeVP002.TabIndex = 12;
            this.lblFakeVP002.Text = "Loading parser ...";
            // 
            // TestPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnFakeVP002);
            this.Controls.Add(this.lblFakeVP002);
            this.Controls.Add(this.btnFakeVP001);
            this.Controls.Add(this.lblFakeVP001);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOfficialVP);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lblOfficialVP);
            this.Name = "TestPanel";
            this.Size = new System.Drawing.Size(555, 286);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOfficialVP;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lblOfficialVP;
        private System.Windows.Forms.Button btnFakeVP001;
        private System.Windows.Forms.Label lblFakeVP001;
        private System.Windows.Forms.Button btnFakeVP002;
        private System.Windows.Forms.Label lblFakeVP002;
    }
}
