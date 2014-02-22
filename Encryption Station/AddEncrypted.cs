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
    public partial class AddEncrypted : Form
    {
        private string key;
        private string cipher;

        public AddEncrypted()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Set the key used to encrypt the text.
        /// </summary>
        /// <param name="key">The key.</param>
        public void setKey(string key)
        {
            this.key = key;
        }

        public TreeItem getCipher()
        {
            return new TreeItem()
            {
                Title = titleTxt.Text,
                Algorithm = algorithmCmb.SelectedItem.ToString(),
                Value = cipher,
                Type = NodeType.Cipher
            };
        }

        /// <summary>
        /// Retrieves the encrypted item
        /// </summary>
        /// <returns>The encrypted item</returns>
        public EncryptedItem getEncryptedItem()
        {
            return new EncryptedItem()
            {
                Algorithm = algorithmCmb.SelectedValue.ToString(),
                CipherText = textTxt.Text, 
                Title = titleTxt.Text
            };
        }

        private void AddEncrypted_Load(object sender, EventArgs e)
        {
            algorithmCmb.SelectedIndex = 0;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (textTxt.Text.Equals(""))
            {
                MessageBox.Show("Please enter some text to encrypt", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                EncryptionAgent agent;
                //This chooses alternative agents
                if (algorithmCmb.SelectedItem.ToString().Equals("AES"))
                {
                    agent = new AesAgent(key);
                    cipher = agent.encrypt(textTxt.Text);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else //This code should never execute
                    MessageBox.Show("Please set an algorithm", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }
        }
    }
}
