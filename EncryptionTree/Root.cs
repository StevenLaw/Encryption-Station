using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EncryptionTree
{
    public class Root : CryptTreeItem
    {
        private string password;

        public override string Text
        {
            get 
            {
                return Title + " File";
            }
        }

        public Root(string title, string password)
        {
            Title = title;
            BCryptAgent bca = new BCryptAgent();
            string salt = bca.generateSalt(12);
            this.password = bca.createHash(password, salt);
            Type = NodeType.Root;
        }

        public bool changePassword(string newPassword)
        {
            BCryptAgent bca = new BCryptAgent();
            if (bca.checkHash(newPassword, password))
            {
                string salt = bca.generateSalt(12);
                password = bca.createHash(newPassword, salt);
                return true;
            }
            else
                return false;
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
            return bca.checkHash(password, this.password);
        }
    }
}
