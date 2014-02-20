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
    public partial class Main : Form
    {
        private string password;
        private bool changed; // Keeps track of whether or not the file has changed.

        public Main()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.Show();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addCryptButton_Click(object sender, EventArgs e)
        {
            AddEncrypted addEnc = new AddEncrypted();
            DialogResult result = addEnc.ShowDialog();
        }

        private void addHashButton_Click(object sender, EventArgs e)
        {
            AddHash addHash = new AddHash();
            DialogResult result = addHash.ShowDialog();
        }

        private void genKeyButton_Click(object sender, EventArgs e)
        {
            if (password == null)
            {
                SetPassword setPass = new SetPassword();
                DialogResult passResult = setPass.ShowDialog();
                if (passResult.Equals(DialogResult.OK))
                {
                    password = setPass.getPassword();
                }
            }
            if (password != null)
            {
                GenerateKey genKey = new GenerateKey();
                DialogResult result = genKey.ShowDialog();
                if (result.Equals(DialogResult.OK))
                {
                    //Add the key to the tree view
                    string key = genKey.getKey();
                }
            }
        }
    }
}
