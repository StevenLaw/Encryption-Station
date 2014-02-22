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

        /// <summary>
        /// Create a new file
        /// </summary>
        private void newFile()
        {
            NewFile newFile = new NewFile();
            DialogResult result = newFile.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                //Enable the TreeView
                itemTree.Enabled = true;
                //genKeyButton.Enabled = true;
                itemTree.Nodes.Clear();

                //Set the name of the document and add to tree
                TreeItem item = new TreeItem()
                {
                    Title = newFile.getTitle(),
                    Type = NodeType.Root
                };
                TreeNode node = new TreeNode(item.Text);
                node.Tag = item;
                itemTree.Nodes.Add(node);
                //Set changed to true to indicate that the file has changed
                changed = true;
            }
        }

        private void addHash()
        {
            AddHash addHash = new AddHash();
            DialogResult result = addHash.ShowDialog();
        }

        /// <summary>
        /// Add custom key.
        /// </summary>
        private void addKey()
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
                AddKey addKey = new AddKey();
                addKey.setPassword(password);
                DialogResult result = addKey.ShowDialog();
                if (result.Equals(DialogResult.OK))
                {
                    //Add the key to the tree view
                    TreeItem key = addKey.getKeyItem();
                    TreeNode node = new TreeNode(key.Text, 1, 1);
                    node.Tag = key;
                    itemTree.SelectedNode.Nodes.Add(node);
                    //Set changed to true to indicate that the file has changed
                    changed = true;
                    itemTree.SelectedNode.Expand();
                }
            }
        }
        
        /// <summary>
        /// Generate a random key.
        /// </summary>
        private void generateKey()
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
                genKey.setPassword(password);
                DialogResult result = genKey.ShowDialog();
                if (result.Equals(DialogResult.OK))
                {
                    //Add the key to the tree view
                    TreeItem key = genKey.getKeyItem();
                    TreeNode node = new TreeNode(key.Text, 1, 1);
                    node.Tag = key;
                    itemTree.SelectedNode.Nodes.Add(node);
                    //Set changed to true to indicate that the file has changed
                    changed = true;
                    itemTree.SelectedNode.Expand();
                }
            }
        }

        /// <summary>
        /// Add an encrypted value
        /// </summary>
        private void addCrypt()
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
                AddEncrypted addEnc = new AddEncrypted();
                //Get key
                TreeItem key = (TreeItem)itemTree.SelectedNode.Tag;
                AesAgent agent = new AesAgent(password);
                //Decrypt key
                string clearKey = agent.decrypt(key.Value);
                //Set key
                addEnc.setKey(clearKey);
                DialogResult result = addEnc.ShowDialog();
                if (result.Equals(DialogResult.OK))
                {
                    //Add the Encrypted item to the tree view
                    TreeItem cipher = addEnc.getCipher();
                    TreeNode node = new TreeNode(cipher.Text, 1, 1);
                    node.Tag = cipher;
                    itemTree.SelectedNode.Nodes.Add(node);
                    //Set changed to true to indicate that the file has changed
                    changed = true;
                    itemTree.SelectedNode.Expand();
                }
            }
        }

        /// <summary>
        /// Change which buttons are enabled depending on which tree node is selectec
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itemTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (itemTree.SelectedNode != null)
            {
                genKeyButton.Enabled = true;
                addHashButton.Enabled = true;
                TreeItem item = (TreeItem)itemTree.SelectedNode.Tag;
                switch (item.Type)
                {
                    case NodeType.Root:
                        genKeyButton.Enabled = true;
                        generateKeyToolStripMenuItem.Enabled = true;
                        addKeyButton.Enabled = true;
                        addEncryptedToolStripMenuItem.Enabled = true;
                        addHashButton.Enabled = true;
                        addHashToolStripMenuItem.Enabled = true;
                        addCryptButton.Enabled = false;
                        addEncryptedToolStripMenuItem.Enabled = false;
                        break;
                    case NodeType.Key:
                        genKeyButton.Enabled = false;
                        generateKeyToolStripMenuItem.Enabled = false;
                        addKeyButton.Enabled = false;
                        addEncryptedToolStripMenuItem.Enabled = false;
                        addHashButton.Enabled = false;
                        addHashToolStripMenuItem.Enabled = false;
                        addCryptButton.Enabled = true;
                        addEncryptedToolStripMenuItem.Enabled = true;
                        break;
                    default:
                        genKeyButton.Enabled = false;
                        generateKeyToolStripMenuItem.Enabled = false;
                        addKeyButton.Enabled = false;
                        addEncryptedToolStripMenuItem.Enabled = false;
                        addHashButton.Enabled = false;
                        addHashToolStripMenuItem.Enabled = false;
                        addCryptButton.Enabled = false;
                        addEncryptedToolStripMenuItem.Enabled = false;
                        break;
                }
            }
            else
            {
                genKeyButton.Enabled = false;
                generateKeyToolStripMenuItem.Enabled = false;
                addKeyButton.Enabled = false;
                addEncryptedToolStripMenuItem.Enabled = false;
                addHashButton.Enabled = false; ;
                addHashToolStripMenuItem.Enabled = false;
                addCryptButton.Enabled = false;
                addEncryptedToolStripMenuItem.Enabled = false;
            }
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
            addCrypt();
        }

        private void addHashButton_Click(object sender, EventArgs e)
        {
            addHash();
        }

        private void genKeyButton_Click(object sender, EventArgs e)
        {
            generateKey();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newFile();
        }

        private void addKeyButton_Click(object sender, EventArgs e)
        {
            addKey();
        }

        private void setPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetPassword setPass = new SetPassword();
            DialogResult passResult = setPass.ShowDialog();
            if (passResult.Equals(DialogResult.OK))
            {
                password = setPass.getPassword();
            }
        }

        private void addHashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addHash();
        }

        private void addKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addKey();
        }

        private void generateKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generateKey();
        }

        private void addEncryptedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addCrypt();
        }
    }
}
