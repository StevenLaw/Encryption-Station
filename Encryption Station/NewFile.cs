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
    public partial class NewFile : Form
    {
        public NewFile()
        {
            InitializeComponent();
        }

        public string getTitle()
        {
            return titleTxt.Text;
        } 

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
