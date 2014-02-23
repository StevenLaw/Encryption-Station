using System;
using System.Windows.Forms;

namespace Encryption_Station
{
    public partial class GenerateKey : Form
    {
        private string key;
        private string password;

        public GenerateKey()
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
                Algorithm = "Aes",
                Length = (int)lengthNUD.Value,
                Value = key,
                Type = NodeType.Key
            };
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            // Generate the key
            string availableChar ="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_-=+/";
            key = "";
            Random rnd = new Random();
            for (int i = 0; i < lengthNUD.Value; i++) 
            {
                key += availableChar[rnd.Next(availableChar.Length)];
            }
            AesAgent aes = new AesAgent(password);
            key = aes.encrypt(key);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
