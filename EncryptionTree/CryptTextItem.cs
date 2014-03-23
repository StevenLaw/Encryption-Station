using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace EncryptionTree
{
    public class CryptText : CryptTreeItem
    {
        private EncryptionAgent agent;

        public CryptAlgorithm Algorithm { get; set; }

        /// <summary>
        /// Returns the Text output of the node.
        /// </summary>
        public override string Text
        {
            get { throw new NotImplementedException(); }
        }
        public CryptText(string title, string clearText, CryptAlgorithm algorithm, string key) : base()
        {
            throw new System.NotImplementedException();
        }

        public string decrypt(string key)
        {
            throw new System.NotImplementedException();
        }

        public override XmlNode createXmlNode()
        {
            throw new NotImplementedException();
        }
    }
}
