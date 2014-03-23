using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace EncryptionTree
{
    public class CryptFile : CryptTreeItem
    {
        private EncryptionAgent agent;

        /// <summary>
        /// Returns the Text output of the node.
        /// </summary>
        public override string Text
        {
            get { throw new NotImplementedException(); }
        }
        public CryptFile(string title, string filename, CryptAlgorithm algorithm, string key) : base()
        {
            throw new System.NotImplementedException();
        }
    
        public CryptAlgorithm Algorithm
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public FileStream decrypt(string key)
        {
            throw new System.NotImplementedException();
        }

        public override XmlNode createXmlNode()
        {
            throw new NotImplementedException();
        }
    }
}
