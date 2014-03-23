using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EncryptionTree
{
    public class CryptText : CryptTreeItem
    {
        public CryptText(string title, string clearText, CryptAlgorithm algorithm, string key)
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

        public string decrypt(string key)
        {
            throw new System.NotImplementedException();
        }

        public override string Text
        {
            get { throw new NotImplementedException(); }
        }

        private EncryptionAgent agent;
    }
}
