using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Encryption_Station
{
    public partial class SetPassword : Form
    {
        public SetPassword()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Returns the password.
        /// </summary>
        /// <returns>The password</returns>
        public string getPassword()
        {
            return passwordTxt.Text;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (confirmTxt.Text.Equals(passwordTxt.Text) && !passwordTxt.Text.Equals(""))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (!confirmTxt.Text.Equals(passwordTxt.Text))
            {
                MessageBox.Show("Passwords do not match.", "Please re-enter your password",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Please enter a password.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
