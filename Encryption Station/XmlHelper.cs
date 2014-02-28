using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Encryption_Station
{
    /// <summary>
    /// Simplifies the reading and writing of nodes between <see cref="TreeView"/> and an Xml file.
    /// </summary>
    class XmlHelper
    {
        public string Filename { get; private set; }
        private XmlDocument document;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlHelper"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        public XmlHelper(string filename)
        {
            Filename = filename;
            document = new XmlDocument();
            XmlDeclaration dec = document.CreateXmlDeclaration("1.0", null, null);
            document.AppendChild(dec);
        }

        /// <summary>
        /// Creates the file and writes it to the file name that was set in the constructor.
        /// </summary>
        /// <param name="root">The root.</param>
        public void createFile(TreeNode root)
        {
            TreeItem rootItem = (TreeItem)root.Tag;
            XmlElement element = document.CreateElement("Root");
            element.SetAttribute("Title", rootItem.Title);
            if (rootItem.Password != null)
                element.SetAttribute("Password", rootItem.Password);
            document.AppendChild(element);
            foreach (TreeNode n in root.Nodes)
            {
                addNode(n, element);
            }
            document.Save(Filename);
        }

        /// <summary>
        /// Adds the nodes recursively to the parent element.  The root is done seperately because it has 
        /// to be added to the document and not an <see cref="XmlElement"/>.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="parent">The parent.</param>
        private void addNode(TreeNode node, XmlElement parent){
            XmlElement element = addValues((TreeItem)node.Tag);
            parent.AppendChild(element);
            foreach (TreeNode n in node.Nodes)
            {
                addNode(n, element);
            }
        }

        /// <summary>
        /// Adds the values from the tree item to an <see cref="XmlElement"/> and returns it.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The <see cref="XmlElement"/> that contains the values.</returns>
        /// <exception cref="System.Exception">Bad node type.</exception>
        private XmlElement addValues(TreeItem item)
        {
            XmlElement node;
            switch (item.Type)
            {
                case NodeType.Key:
                    node = document.CreateElement("Key");
                    break;
                case NodeType.Cipher:
                    node = document.CreateElement("Cipher");
                    break;
                case NodeType.Hash:
                    node = document.CreateElement("Hash");
                    break;
                default:
                    throw new Exception("Bad node type.");
            }
            
            node.SetAttribute("Value", item.Value);
            if (item.Title != null)
                node.SetAttribute("Title", item.Title);
            if (item.Algorithm != null)
                node.SetAttribute("Algorithm", item.Algorithm);
            if (item.WorkFactor != 0)
                node.SetAttribute("WorkFactor", item.WorkFactor.ToString());
            if (item.SaltSize != 0)
                node.SetAttribute("SaltSize", item.SaltSize.ToString());
            if (item.Length != 0)
                node.SetAttribute("Length", item.Length.ToString());
            return node;
        }

        /// <summary>
        /// Loads the file.
        /// </summary>
        /// <returns>An Xml document containing the file contents.</returns>
        /// <remarks>I really wanted to load the TreeView in here but I couldn't find a separate view model 
        /// for the TreeView</remarks>
        public XmlDocument loadFile()
        {
            document = new XmlDocument();
            document.Load(Filename);
            return document;
        }

        /// <summary>
        /// Extracts the values from the node's atributes and inserts them into a <see cref="TreeItem"/>.
        /// </summary>
        /// <param name="node">The node to extract from.</param>
        /// <returns>The treeItem</returns>
        public TreeItem extractValues(XmlNode node)
        {
            TreeItem item = new TreeItem();
            if (node.Attributes["Title"] != null)
                item.Title = node.Attributes["Title"].Value;
            if (node.Attributes["Value"] != null)
                item.Value = node.Attributes["Value"].Value;
            if (node.Attributes["Algorithm"] != null)
                item.Algorithm = node.Attributes["Algorithm"].Value;
            if (node.Attributes["WorkFactor"] != null)
                item.WorkFactor = Convert.ToInt32(node.Attributes["WorkFactor"].Value);
            if (node.Attributes["SaltSize"] != null)
                item.SaltSize = Convert.ToInt32(node.Attributes["SaltSize"].Value);
            if (node.Attributes["Length"] != null)
                item.Length = Convert.ToInt32(node.Attributes["Length"].Value);
            if (node.Attributes["Password"] != null)
                item.Algorithm = node.Attributes["Password"].Value;
            switch(node.Name)
            {
                case ("Root"):
                    item.Type = NodeType.Root;
                    break;
                case ("Key"):
                    item.Type = NodeType.Key;
                    break;
                case ("Hash"):
                    item.Type = NodeType.Hash;
                    break;
                case ("Cipher"):
                    item.Type = NodeType.Cipher;
                    break;
            }
            return item;
        }
    }
}
