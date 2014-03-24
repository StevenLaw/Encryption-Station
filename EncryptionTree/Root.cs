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
        /// The password needs to be accessible in order to decrypt the keys.
        /// </summary>
        private string password;

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

        /// <summary>
        /// Creates the root node with the title and the hashed password in the Value property.
        /// </summary>
        /// <param name="title">The root node's title.</param>
        /// <param name="password">The password used to encrypt the keys.</param>
        public Root(string title, string password) : base()
        {
            Title = title;
            BCryptAgent bca = new BCryptAgent();
            string salt = bca.generateSalt(12);
            Value = bca.createHash(password, salt);
            Type = NodeType.Root;
            this.password = password;
        }

        /// <summary>
        /// Changes the password that is being used to encrypt keys.
        /// </summary>
        /// <param name="newPassword">The password to change to.</param>
        /// <remarks>Assumes that the password has been checked first otherwise it will fail on unencrypting 
        /// the child nodes for re-encryption.</remarks>
        public void changePassword(string newPassword)
        {
            BCryptAgent bca = new BCryptAgent();
            // TODO re-encrypt child crypt items
            string salt = bca.generateSalt(12);
            Value = bca.createHash(newPassword, salt);
            
        }

        /// <summary>
        /// Adds a <see cref="Key"/> node.
        /// </summary>
        /// <param name="key">The key node to add.</param>
        public void addKey(Key key)
        {
            Children.Add(key);
        }

        /// <summary>
        /// Adds a <see cref="Hash"/> node.
        /// </summary>
        /// <param name="hash">The node to add.</param>
        public void addHash(Hash hash)
        {
            Children.Add(hash);
        }

        /// <summary>
        /// Adds a <see cref="FileHash"/> node.
        /// </summary>
        /// <param name="hash">The node to add.</param>
        public void addHash(FileHash hash)
        {
            Children.Add(hash);
        }

        /// <summary>
        /// Checks if the provided password matches the stored one.
        /// </summary>
        /// <param name="password">The password to check.</param>
        /// <returns>True if the password matches false if it doesn't.</returns>
        public bool checkPassword(string password)
        {
            BCryptAgent bca = new BCryptAgent();
            return bca.checkHash(password, Value);
        }

        /// <summary>
        /// Creates the <see cref="XmlNode"/> for this node including the child nodes.
        /// </summary>
        /// <returns>The <see cref="XmlNode"/> that was created.</returns>
        public override XmlNode createXmlNode()
        {
            throw new NotImplementedException();
        }
    }
}
