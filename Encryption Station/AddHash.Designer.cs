namespace Encryption_Station
{
    partial class AddHash
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.workLabel = new System.Windows.Forms.Label();
            this.algorithmCmb = new System.Windows.Forms.ComboBox();
            this.textTxt = new System.Windows.Forms.TextBox();
            this.workFactorNmb = new System.Windows.Forms.NumericUpDown();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.titleTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.saltSizeLabel = new System.Windows.Forms.Label();
            this.saltSizeNmb = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.workFactorNmb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saltSizeNmb)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Algorithm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Text";
            // 
            // workLabel
            // 
            this.workLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.workLabel.AutoSize = true;
            this.workLabel.Enabled = false;
            this.workLabel.Location = new System.Drawing.Point(146, 282);
            this.workLabel.Name = "workLabel";
            this.workLabel.Size = new System.Drawing.Size(66, 13);
            this.workLabel.TabIndex = 2;
            this.workLabel.Text = "Work Factor";
            // 
            // algorithmCmb
            // 
            this.algorithmCmb.FormattingEnabled = true;
            this.algorithmCmb.Items.AddRange(new object[] {
            "SHA1",
            "SHA256",
            "SHA384",
            "SHA512",
            "MD5",
            "BCrypt"});
            this.algorithmCmb.Location = new System.Drawing.Point(84, 9);
            this.algorithmCmb.Name = "algorithmCmb";
            this.algorithmCmb.Size = new System.Drawing.Size(121, 21);
            this.algorithmCmb.TabIndex = 3;
            this.algorithmCmb.SelectedIndexChanged += new System.EventHandler(this.algorithmCmb_SelectedIndexChanged);
            // 
            // textTxt
            // 
            this.textTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textTxt.Location = new System.Drawing.Point(84, 62);
            this.textTxt.Multiline = true;
            this.textTxt.Name = "textTxt";
            this.textTxt.Size = new System.Drawing.Size(438, 209);
            this.textTxt.TabIndex = 4;
            // 
            // workFactorNmb
            // 
            this.workFactorNmb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.workFactorNmb.Enabled = false;
            this.workFactorNmb.Location = new System.Drawing.Point(218, 280);
            this.workFactorNmb.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.workFactorNmb.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.workFactorNmb.Name = "workFactorNmb";
            this.workFactorNmb.Size = new System.Drawing.Size(35, 20);
            this.workFactorNmb.TabIndex = 5;
            this.workFactorNmb.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(447, 277);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(366, 277);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // titleTxt
            // 
            this.titleTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleTxt.Location = new System.Drawing.Point(84, 36);
            this.titleTxt.Name = "titleTxt";
            this.titleTxt.Size = new System.Drawing.Size(438, 20);
            this.titleTxt.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Title";
            // 
            // saltSizeLabel
            // 
            this.saltSizeLabel.AutoSize = true;
            this.saltSizeLabel.Location = new System.Drawing.Point(12, 282);
            this.saltSizeLabel.Name = "saltSizeLabel";
            this.saltSizeLabel.Size = new System.Drawing.Size(48, 13);
            this.saltSizeLabel.TabIndex = 10;
            this.saltSizeLabel.Text = "Salt Size";
            // 
            // saltSizeNmb
            // 
            this.saltSizeNmb.Location = new System.Drawing.Point(85, 280);
            this.saltSizeNmb.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.saltSizeNmb.Name = "saltSizeNmb";
            this.saltSizeNmb.Size = new System.Drawing.Size(55, 20);
            this.saltSizeNmb.TabIndex = 11;
            // 
            // AddHash
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(534, 312);
            this.Controls.Add(this.saltSizeNmb);
            this.Controls.Add(this.saltSizeLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.titleTxt);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.workFactorNmb);
            this.Controls.Add(this.textTxt);
            this.Controls.Add(this.algorithmCmb);
            this.Controls.Add(this.workLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(395, 150);
            this.Name = "AddHash";
            this.Text = "Add Hash";
            this.Load += new System.EventHandler(this.AddHash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.workFactorNmb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saltSizeNmb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label workLabel;
        private System.Windows.Forms.ComboBox algorithmCmb;
        private System.Windows.Forms.TextBox textTxt;
        private System.Windows.Forms.NumericUpDown workFactorNmb;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox titleTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label saltSizeLabel;
        private System.Windows.Forms.NumericUpDown saltSizeNmb;
    }
}