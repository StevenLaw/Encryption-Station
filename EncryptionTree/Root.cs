using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace EncryptionTree
{
    public class Root : CryptTreeItem
    {
        /// <summary>
        /// Returns the Text output of the node.
        /// </summary>
        public override string Text
        {
            get 
            {
                return Title + " File";
            }
        }

        public Root(string title, string password) : base()
        {
            Title = title;
            BCryptAgent bca = new BCryptAgent();
            string salt = bca.generateSalt(12);
            Value = bca.createHash(password, salt);
            Type = NodeType.Root;
        }

        public void changePassword(string newPassword)
        {
            BCryptAgent bca = new BCryptAgent();
            string salt = bca.generateSalt(12);
            Value = bca.createHash(newPassword, salt);
            
        }

        public void addKey(Key key)
        {
            Children.Add(key);
        }

        public void addHash(Hash hash)
        {
            Children.Add(hash);
        }

        public void addHash(FileHash hash)
        {
            Children.Add(hash);
        }

        public bool checkPassword(string password)
        {
            BCryptAgent bca = new BCryptAgent();
            return bca.checkHash(password, Value);
        }

        public override XmlNode createXmlNode()
        {
            throw new NotImplementedException();
        }
    }
}
