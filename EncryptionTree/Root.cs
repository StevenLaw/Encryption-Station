using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EncryptionTree
{
    public class Root : CryptTreeItem
    {
        public string Password
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public bool changePassword(string oldPassword, string newPassword)
        {
            throw new System.NotImplementedException();
        }

        public void addKey(Key key)
        {
            throw new System.NotImplementedException();
        }

        public void addHash(Hash hash)
        {
            throw new System.NotImplementedException();
        }

        public void addHash(FileHash hash)
        {
            throw new System.NotImplementedException();
        }

        public override string Text
        {
            get { throw new NotImplementedException(); }
        }
    }
}
