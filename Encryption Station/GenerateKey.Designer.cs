namespace Encryption_Station
{
    partial class GenerateKey
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
            this.lengthNUD = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.charactersChk = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.lengthNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // lengthNUD
            // 
            this.lengthNUD.Location = new System.Drawing.Point(116, 12);
            this.lengthNUD.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.lengthNUD.Name = "lengthNUD";
            this.lengthNUD.Size = new System.Drawing.Size(120, 20);
            this.lengthNUD.TabIndex = 0;
            this.lengthNUD.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Length";
            // 
            // charactersChk
            // 
            this.charactersChk.BackColor = System.Drawing.SystemColors.Menu;
            this.charactersChk.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.charactersChk.FormattingEnabled = true;
            this.charactersChk.Items.AddRange(new object[] {
            "Uppercase (A-Z)",
            "Lowercase (a-z)",
            "Numbers (0-9)",
            "@",
            "%",
            "+",
            "\\",
            "/",
            "\'",
            "!",
            "#",
            "$",
            "^",
            "?",
            ":",
            ",",
            "~",
            "-",
            "_"});
            this.charactersChk.Location = new System.Drawing.Point(116, 38);
            this.charactersChk.Name = "charactersChk";
            this.charactersChk.Size = new System.Drawing.Size(215, 60);
            this.charactersChk.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Characters Allowed";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(256, 108);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(175, 108);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // GenerateKey
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(343, 147);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.charactersChk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lengthNUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GenerateKey";
            this.Text = "Generate Key";
            ((System.ComponentModel.ISupportInitialize)(this.lengthNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown lengthNUD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox charactersChk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;

    }
}