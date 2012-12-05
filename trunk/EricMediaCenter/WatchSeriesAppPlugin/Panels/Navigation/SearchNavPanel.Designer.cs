namespace WatchSeriesAppPlugin.Panels.Navigation
{
    partial class SearchNavPanel
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
            this.lstResults = new System.Windows.Forms.ListBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new VIBlend.WinForms.Controls.vButton();
            this.btnGenres = new VIBlend.WinForms.Controls.vButton();
            this.btnLetters = new VIBlend.WinForms.Controls.vButton();
            this.lstChoices = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstResults
            // 
            this.lstResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstResults.FormattingEnabled = true;
            this.lstResults.IntegralHeight = false;
            this.lstResults.ItemHeight = 20;
            this.lstResults.Location = new System.Drawing.Point(129, 72);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(296, 244);
            this.lstResults.TabIndex = 10;
            this.lstResults.DoubleClick += new System.EventHandler(this.lstResults_DoubleClick);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(129, 40);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(218, 26);
            this.txtSearch.TabIndex = 11;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.AllowAnimations = true;
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(353, 41);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.RoundedCornersMask = ((byte)(15));
            this.btnSearch.Size = new System.Drawing.Size(72, 25);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.METROBLUE;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnGenres
            // 
            this.btnGenres.AllowAnimations = true;
            this.btnGenres.BackColor = System.Drawing.Color.Transparent;
            this.btnGenres.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenres.Location = new System.Drawing.Point(6, 97);
            this.btnGenres.Name = "btnGenres";
            this.btnGenres.RoundedCornersMask = ((byte)(15));
            this.btnGenres.Size = new System.Drawing.Size(117, 19);
            this.btnGenres.TabIndex = 13;
            this.btnGenres.Text = "By Genre";
            this.btnGenres.UseVisualStyleBackColor = false;
            this.btnGenres.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.METROGREEN;
            this.btnGenres.Click += new System.EventHandler(this.btnGenres_Click);
            // 
            // btnLetters
            // 
            this.btnLetters.AllowAnimations = true;
            this.btnLetters.BackColor = System.Drawing.Color.Transparent;
            this.btnLetters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLetters.Location = new System.Drawing.Point(6, 72);
            this.btnLetters.Name = "btnLetters";
            this.btnLetters.RoundedCornersMask = ((byte)(15));
            this.btnLetters.Size = new System.Drawing.Size(117, 19);
            this.btnLetters.TabIndex = 15;
            this.btnLetters.Text = "By Letter";
            this.btnLetters.UseVisualStyleBackColor = false;
            this.btnLetters.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.METROGREEN;
            this.btnLetters.Click += new System.EventHandler(this.btnLetters_Click);
            // 
            // lstChoices
            // 
            this.lstChoices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstChoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstChoices.FormattingEnabled = true;
            this.lstChoices.IntegralHeight = false;
            this.lstChoices.ItemHeight = 20;
            this.lstChoices.Location = new System.Drawing.Point(6, 122);
            this.lstChoices.Name = "lstChoices";
            this.lstChoices.Size = new System.Drawing.Size(117, 194);
            this.lstChoices.TabIndex = 16;
            this.lstChoices.SelectedIndexChanged += new System.EventHandler(this.lstChoices_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Search:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SearchNavPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstChoices);
            this.Controls.Add(this.btnLetters);
            this.Controls.Add(this.btnGenres);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lstResults);
            this.Name = "SearchNavPanel";
            this.Size = new System.Drawing.Size(428, 319);
            this.Controls.SetChildIndex(this.lstResults, 0);
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.btnGenres, 0);
            this.Controls.SetChildIndex(this.btnLetters, 0);
            this.Controls.SetChildIndex(this.lstChoices, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstResults;
        private System.Windows.Forms.TextBox txtSearch;
        private VIBlend.WinForms.Controls.vButton btnSearch;
        private VIBlend.WinForms.Controls.vButton btnGenres;
        private VIBlend.WinForms.Controls.vButton btnLetters;
        private System.Windows.Forms.ListBox lstChoices;
        private System.Windows.Forms.Label label1;
    }
}
