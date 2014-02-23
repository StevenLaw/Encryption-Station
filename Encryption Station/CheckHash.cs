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
    public partial class CheckHash : Form
    {
        private TreeItem hash;
        public CheckHash()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the hash item.
        /// </summary>
        /// <param name="hash">The hash item to check</param>
        public void setHash(TreeItem hash)
        {
            this.hash = hash;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            HashingAgent agent;
            switch (hash.Algorithm)
            {
                case "SHA1":
                case "SHA256":
                case "SHA384":
                case "SHA512":
                    agent = new ShaAgent(hash.Algorithm);
                    break;
                case "MD5":
                    agent = new MD5Agent();
                    break;
                default: //Default is BCrypt
                    agent = new BCryptAgent();
                    break;
            };
            if (agent.checkHash(textTxt.Text, hash.Value))
                MessageBox.Show("The text and the hashed value match.");
            else
                MessageBox.Show("The text does not match the hashed value.");
            Close();
        }
    }
}
