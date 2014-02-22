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
    public partial class AddKey : Form
    {
        private string key;
        private string password;

        public AddKey()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Set the password used to encrypt the key.
        /// </summary>
        /// <param name="password">The password.</param>
        public void setPassword(string password)
        {
            this.password = password;
        }

        /// <summary>
        /// Returns the generated key.
        /// </summary>
        /// <returns>The generated Key</returns>
        public TreeItem getKeyItem()
        {
            return new TreeItem()
            {
                Title = titleTxt.Text,
                Length = valueTxt.Text.Length,
                Value = key,
                Type = NodeType.Key
            };
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (!valueTxt.Text.Equals(""))
            {
                AesAgent aes = new AesAgent(password);
                key = aes.encrypt(valueTxt.Text);
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please input a value for the key", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
