using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace EncryptionTree
{
    public class FileHash : CryptTreeItem
    {
        private HashingAgent agent;

        public HashAlType Algorithm { get; set; }

        public int SaltSize { get; set; }

        public int WorkFactor { get; set; }

        public string FileName { get; set; }

        /// <summary>
        /// Returns the Text output of the node.
        /// </summary>
        public override string Text
        {
            get { throw new NotImplementedException(); }
        }

        
        public FileHash(string title, string filename, HashAlType algorithm, int saltGen) : base()
        {
            Title = title;
            FileName = filename;
            Algorithm = algorithm;
            if (algorithm == HashAlType.BCrypt)
                WorkFactor = saltGen;
            else
                SaltSize = saltGen;
            // TODO generate file hash and set to Value
        }

        public bool checkHash(string filename)
        {
            throw new System.NotImplementedException();
        }

        public override XmlNode createXmlNode()
        {
            throw new NotImplementedException();
        }
    }
}
