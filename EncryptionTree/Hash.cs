using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace EncryptionTree
{
    public class Hash : CryptTreeItem
    {
        private HashingAgent agent;

        public HashAlType Algorithm { get; set; }

        public int SaltSize { get; set; }

        public int WorkFactor { get; set; }

        /// <summary>
        /// Returns the Text output of the node.
        /// </summary>
        public override string Text
        {
            get { throw new NotImplementedException(); }
        }

        public Hash(string title, string clearText, HashAlType algorithm, int saltGen) : base()
        {
            Title = title;
            Algorithm = algorithm;
            if (algorithm == HashAlType.BCrypt)
                WorkFactor = saltGen;
            else
                SaltSize = saltGen;

            // TODO Generate hash and set to Value
        }

        public bool checkHash(string clearText)
        {
            throw new System.NotImplementedException();
        }



        public override XmlNode createXmlNode()
        {
            throw new NotImplementedException();
        }
    }
}
