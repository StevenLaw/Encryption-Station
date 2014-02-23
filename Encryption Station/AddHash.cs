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
    public partial class AddHash : Form
    {
        private string hash;
        public AddHash()
        {
            InitializeComponent();
        }

        public TreeItem getHashItem()
        {
            if (algorithmCmb.SelectedItem.ToString().Equals("BCrypt"))
            {
                return new TreeItem
                {
                    Algorithm = algorithmCmb.SelectedItem.ToString(),
                    Title = titleTxt.Text,
                    Value = hash,
                    WorkFactor = (int)workFactorNmb.Value,
                    Type = NodeType.Hash
                };
            }
            else
                return new TreeItem
                {
                    Algorithm = algorithmCmb.SelectedItem.ToString(),
                    Title = titleTxt.Text,
                    Value = hash,
                    SaltSize = (int)saltSizeNmb.Value,
                    Type = NodeType.Hash
                };
        }

        private void AddHash_Load(object sender, EventArgs e)
        {
            algorithmCmb.SelectedIndex = 0;
        }

        private void algorithmCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (algorithmCmb.SelectedItem.ToString().Equals("BCrypt"))
            {
                workFactorNmb.Enabled = true;
                workLabel.Enabled = true;
                saltSizeNmb.Enabled = false;
                saltSizeLabel.Enabled = false;
            }
            else
            {
                workFactorNmb.Enabled = false;
                workLabel.Enabled = false;
                saltSizeNmb.Enabled = true;
                saltSizeLabel.Enabled = true;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            HashingAgent agent;
            int saltVal = 0;
            string algorithm = algorithmCmb.SelectedItem.ToString();
            switch (algorithm)
            {
                case "SHA1":
                case "SHA256":
                case "SHA384":
                case "SHA512":
                    agent = new ShaAgent(algorithm);
                    saltVal = (int)saltSizeNmb.Value;
                    break;
                case "MD5":
                    agent = new MD5Agent();
                    saltVal = (int)saltSizeNmb.Value;
                    break;
                default: //Default is BCrypt
                    agent = new BCryptAgent();
                    saltVal = (int)workFactorNmb.Value;
                    break;
            };
            if (saltVal != 0)
            {
                string salt = agent.generateSalt(saltVal);
                hash = agent.createHash(textTxt.Text, salt);
            }
            else
            {
                hash = agent.createHash(textTxt.Text);
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
