using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace EncryptionTree
{
    /// <summary>
    /// Represents an encryption key that is itself encrypted.
    /// </summary>
    public class Key : CryptTreeItem
    {
        private EncryptionAgent agent;

        /// <summary>
        /// Returns the Text output of the node.
        /// </summary>
        public override string Text
        {
            get 
            {
                StringBuilder text = new StringBuilder();
                if (Title != null && !Title.Equals(""))
                    text.Append(Title + ": "); 
                text.Append("Key " + (char)0x2013 + " Value: " + Value);
                return text.ToString();
            }
        }

        /// <summary>
        /// The length of the key in bytes.
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Key"/> class with generated key of the specified 
        /// length.
        /// </summary>
        /// <param name="Title">The title of the key.</param>
        /// <param name="password">The password to encrypt the key with.</param>
        /// <param name="length">The length of the generated key.</param>
        public Key(string Title, string password, int length) : base()
        {
            this.Title = Title;
            agent = new AesAgent(password);

            // Generate the key
            string availableChar = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_-=+/";
            StringBuilder key = new StringBuilder();
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                key.Append(availableChar[rnd.Next(availableChar.Length)]);
            }
            Length = length;
            Value = agent.encrypt(key.ToString());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Key"/> class using a pre-made key.
        /// </summary>
        /// <param name="Title">The title of the key.</param>
        /// <param name="password">The password to encrypt the key with.</param>
        /// <param name="key">The pre-made key.</param>
        public Key(string Title, string password, string key) : base()
        {
            this.Title = Title;
            agent = new AesAgent(password);
            Length = key.Length;
            Value = agent.encrypt(key);
        }

        /// <summary>
        /// Adds a <see cref="CryptFile"/> object to the children.
        /// </summary>
        /// <param name="crypt">The <see cref="Crypt"/> to add.</param>
        public void addCrypt(CryptFile crypt)
        {
            Children.Add(crypt);
        }

        /// <summary>
        /// Adds a <see cref="CryptText"/> object to the children.
        /// </summary>
        /// <param name="crypt">The <see cref="CryptText"/> to add.</param>
        public void addCrypt(CryptText crypt)
        {
            Children.Add(crypt);
        }

        /// <summary>
        /// Changes the password used to encrypt the key.
        /// </summary>
        /// <param name="newPassword">The new password.</param>
        /// <remarks>Needs to be called by the root when that is changing password.</remarks>
        public void changePassword(string newPassword)
        {
            string oldKey = agent.decrypt(Value);
            agent = new AesAgent(newPassword);
            Value = agent.encrypt(oldKey);
        }

        /// <summary>
        /// Decrypts the key.
        /// </summary>
        /// <returns>The decrypted key value.</returns>
        public string decryptKey()
        {
            return agent.decrypt(Value);
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
