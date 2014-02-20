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

        private void addHashButton_Click(object sender, EventArgs e)
        {

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
