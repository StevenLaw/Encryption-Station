using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EncryptionTree
{
    public class Key : CryptTreeItem
    {
        public Key(string Title, string password)
        {
            throw new System.NotImplementedException();
        }

        public override string Text
        {
            get { throw new NotImplementedException(); }
        }

        public void addCrypt(CryptFile crypt)
        {
            throw new System.NotImplementedException();
        }

        public void addCrypt(CryptText crypt)
        {
            throw new System.NotImplementedException();
        }
    }
}
