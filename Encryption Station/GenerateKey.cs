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
    public partial class GenerateKey : Form
    {
        private string key;

        public GenerateKey()
        {
            
            InitializeComponent();
        }

        /// <summary>
        /// Returns the generated key.
        /// </summary>
        /// <returns>The generated Key</returns>
        public string getKey()
        {
            return key;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
