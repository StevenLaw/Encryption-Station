using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Encryption_Station
{
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
        }

        public void createFile(TreeNode root)
        {
            TreeItem rootItem = (TreeItem)root.Tag;
            XmlElement element = document.CreateElement("Root");
            element.InnerText = rootItem.Value;
            foreach (TreeNode n in root.Nodes)
            {
                addNode(n, element);
            }
        }

        private void addNode(TreeNode node, XmlElement parent){
            XmlElement element = addValues((TreeItem)node.Tag);
            parent.AppendChild(element);
            foreach (TreeNode n in node.Nodes)
            {
                addNode(n, element);
            }
        }

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
            
            node.InnerText = item.Value;
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
    }
}
