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
        public AddHash()
        {
            InitializeComponent();
        }

        public TreeItem getHashItem()
        {
            return new TreeItem
            {
                Algorithm = algorithmCmb.SelectedItem.ToString(),
                Title = titleTxt.Text,
                Value = textTxt.Text,
                WorkFactor = (int)workFactorNmb.Value
            };
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
