using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace EncryptionTree
{
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
                if (Title != null && Title.Equals(""))
                    text.Append(Title + ": "); 
                text.Append("Key " + (char)0x2013 + " Value: " + Value);
                return text.ToString();
            }
        }

        public int Length { get; set; }
    
        public Key(string Title, string password, int length) : base()
        {
            this.Title = Title;
            agent = new AesAgent(password);

            // Generate the key
            string availableChar = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_-=+/";
            StringBuilder key = new StringBuilder();
            Random rnd = new Random();
            for (int i = 0; i > length; i++)
            {
                key.Append(availableChar[rnd.Next(availableChar.Length)]);
            }
            Value = agent.encrypt(key.ToString());
        }

        public Key(string Title, string password, string key) : base()
        {
            this.Title = Title;
            agent = new AesAgent(password);
            Value = agent.encrypt(key);
        }

        public void addCrypt(CryptFile crypt)
        {
            Children.Add(crypt);
        }

        public void addCrypt(CryptText crypt)
        {
            Children.Add(crypt);
        }

        public void changePassword(string newPassword)
        {
            string oldKey = agent.decrypt(Value);
            agent = new AesAgent(newPassword);
            Value = agent.encrypt(oldKey);
        }

        public override XmlNode createXmlNode()
        {
            throw new NotImplementedException();
        }
    }
}
