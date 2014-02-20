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
        public AddEncrypted()
        {
            InitializeComponent();
        }

        public EncryptedItem getEncryptedItem()
        {
            return new EncryptedItem()
            {
                Algorithm = algorithmCmb.SelectedValue.ToString(),
                CipherText = textTxt.Text, 
                Title = titleTxt.Text
            };
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
