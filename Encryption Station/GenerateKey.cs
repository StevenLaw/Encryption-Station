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
            // Generate the key
            string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lower = "abcdefghijklmnopqrstuvwxyz";
            string digits = "0123456789";
            string availableChar ="";
            if (charactersChk.CheckedItems.Count != 0)
            {
                for (int i = 0; i < charactersChk.CheckedItems.Count; i++)
                {
                    if (charactersChk.CheckedItems[i].ToString().Equals("Uppercase (A-Z)"))
                        availableChar += upper;
                    else if (charactersChk.CheckedItems[i].ToString().Equals("Lowercase (a-z)"))
                        availableChar += lower;
                    else if (charactersChk.CheckedItems[i].ToString().Equals("Numbers (0-9)"))
                        availableChar += digits;
                    else
                        availableChar += charactersChk.CheckedItems[i].ToString();
                }
            }
            if (availableChar.Equals(""))
            {
                MessageBox.Show("Please choose characters to use in the key");
            }
            else
            {
                key = "";
                Random rnd = new Random();
                for (int i = 0; i < lengthNUD.Value; i++) 
                {
                    key += availableChar[rnd.Next(availableChar.Length)];
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
