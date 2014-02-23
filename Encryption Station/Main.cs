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
            if (result.Equals(DialogResult.OK))
            {
                //Add the key to the tree view
                TreeItem hash = addHash.getHashItem();
                TreeNode node = new TreeNode(hash.Text, 2, 2);
                node.Tag = hash;
                itemTree.SelectedNode.Nodes.Add(node);
                //Set changed to true to indicate that the file has changed
                changed = true;
                itemTree.SelectedNode.Expand();
            }
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
                    TreeNode node = new TreeNode(cipher.Text, 3, 3);
                    node.Tag = cipher;
                    itemTree.SelectedNode.Nodes.Add(node);
                    //Set changed to true to indicate that the file has changed
                    changed = true;
                    itemTree.SelectedNode.Expand();
                }
            }
        }


        /// <summary>
        /// Checks if the hash matches a given value or views the unencrypted value of a key or encrypted 
        /// item.
        /// </summary>
        private void viewCheck()
        {
            if (itemTree.SelectedNode != null)
            {
                TreeItem item = (TreeItem)itemTree.SelectedNode.Tag;
                switch (item.Type)
                {
                    case NodeType.Key:
                        //The node is a key so use password directly
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
                            EncryptionAgent agent;
                            switch (item.Algorithm)
                            {
                                default:
                                    agent = new AesAgent(password);
                                    break;
                            }
                            string clearText = agent.decrypt(item.Value);
                            DialogResult result = MessageBox.Show(clearText + 
                                "\nWould you like to copy to the clipboard?", "Decrypted Key", 
                                MessageBoxButtons.YesNo);
                            if (result.Equals(DialogResult.Yes))
                            {
                                Clipboard.SetText(clearText);
                            }
                        }
                        break;
                    case NodeType.Cipher:
                        //The node is a password so decrypt the key and use that
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
                            AesAgent aes = new AesAgent(password);
                            //Get the parent item
                            TreeItem keyItem = (TreeItem)itemTree.SelectedNode.Parent.Tag;
                            string key = aes.decrypt(keyItem.Value);
                            EncryptionAgent agent;
                            switch (item.Algorithm)
                            {
                                default:
                                    agent = new AesAgent(key);
                                    break;
                            }
                            string clearText = agent.decrypt(item.Value);
                            DialogResult result = MessageBox.Show(clearText +
                                "\nWould you like to copy to the clipboard?",
                                "Decrypted Value", MessageBoxButtons.YesNo);
                            if (result.Equals(DialogResult.Yes))
                            {
                                Clipboard.SetText(clearText);
                            }
                        }
                        break;
                    case NodeType.Hash:
                        CheckHash chkHash = new CheckHash();
                        chkHash.setHash(item);
                        chkHash.Show();
                        break;
                }
            }
        }

        private void delete()
        {
            if (itemTree.SelectedNode != null)
            {
                TreeItem item = (TreeItem)itemTree.SelectedNode.Tag;
                int nodes = 1 + itemTree.SelectedNode.Nodes.Count;
                DialogResult result = DialogResult.No;
                if (nodes == 1)
                    result = MessageBox.Show("Do you want to delete this item?", "Deleting Item", 
                        MessageBoxButtons.YesNo);
                else if (nodes > 1)
                    result = MessageBox.Show("Do you want to delete these " + nodes + " items?", 
                        "Deleting items", MessageBoxButtons.YesNo);
                if (result.Equals(DialogResult.Yes))
                    itemTree.SelectedNode.Remove();
            }
        }

        /// <summary>
        /// Handles the AfterSelect event of the itemTree control.  Controls which controls are active.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TreeViewEventArgs"/> instance containing the event data.</param>
        private void itemTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (itemTree.SelectedNode != null)
            {
                //View delete menu items
                viewToolStripMenuItem.Enabled = true;
                deleteToolStripMenuItem.Enabled = true;
                //Move menu items
                moveUpToolStripMenuItem.Enabled = true;
                moveDownToolStripMenuItem.Enabled = true;
                TreeItem item = (TreeItem)itemTree.SelectedNode.Tag;
                switch (item.Type)
                {
                    case NodeType.Root:
                        //Gen add buttons
                        genKeyButton.Enabled = true;
                        addKeyButton.Enabled = true;
                        addHashButton.Enabled = true;
                        addCryptButton.Enabled = false;
                        //Gen add menu items
                        generateKeyToolStripMenuItem.Enabled = true;
                        addKeyToolStripMenuItem.Enabled = true;
                        addHashToolStripMenuItem.Enabled = true;
                        addEncryptedToolStripMenuItem.Enabled = false;
                        //View delete menu items
                        viewToolStripMenuItem.Enabled = false;
                        deleteToolStripMenuItem.Enabled = false;
                        break;
                    case NodeType.Key:
                        //Gen add buttons
                        genKeyButton.Enabled = false;
                        addKeyButton.Enabled = false;
                        addHashButton.Enabled = false;
                        addCryptButton.Enabled = true;
                        //Gen add menu items
                        generateKeyToolStripMenuItem.Enabled = false;
                        addKeyToolStripMenuItem.Enabled = true;
                        addHashToolStripMenuItem.Enabled = false;
                        addEncryptedToolStripMenuItem.Enabled = true;
                        break;
                    case NodeType.Cipher:
                        //Gen add buttons
                        genKeyButton.Enabled = false;
                        addKeyButton.Enabled = false;
                        addHashButton.Enabled = false;
                        addCryptButton.Enabled = false;
                        //Gen add menu items
                        generateKeyToolStripMenuItem.Enabled = false;
                        addKeyToolStripMenuItem.Enabled = false;
                        addHashToolStripMenuItem.Enabled = false;
                        addEncryptedToolStripMenuItem.Enabled = false;
                        break;
                    case NodeType.Hash:
                        //Gen add buttons
                        genKeyButton.Enabled = false;
                        addKeyButton.Enabled = false;
                        addHashButton.Enabled = false;
                        addCryptButton.Enabled = false;
                        //Gen add menu items
                        generateKeyToolStripMenuItem.Enabled = false;
                        addKeyToolStripMenuItem.Enabled = false;
                        addHashToolStripMenuItem.Enabled = false;
                        addEncryptedToolStripMenuItem.Enabled = false;
                        break;
                    default:
                        //Gen add buttons
                        genKeyButton.Enabled = false;
                        addKeyButton.Enabled = false;
                        addHashButton.Enabled = false;
                        addCryptButton.Enabled = false;
                        //Gen add menu items
                        generateKeyToolStripMenuItem.Enabled = false;
                        addKeyToolStripMenuItem.Enabled = false;
                        addHashToolStripMenuItem.Enabled = false;
                        addEncryptedToolStripMenuItem.Enabled = false;
                        break;
                }
            }
            else
            {
                //View delete menu items
                viewToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
                //Move menu items
                moveUpToolStripMenuItem.Enabled = false;
                moveDownToolStripMenuItem.Enabled = false;
                //Gen add buttons
                genKeyButton.Enabled = false;
                addKeyButton.Enabled = false;
                addHashButton.Enabled = false;
                addCryptButton.Enabled = false;
                //Gen add menu items
                generateKeyToolStripMenuItem.Enabled = false;
                addKeyToolStripMenuItem.Enabled = false;
                addHashToolStripMenuItem.Enabled = false;
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

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewCheck();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delete();
        }
    }
}
