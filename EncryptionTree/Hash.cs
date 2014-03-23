using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EncryptionTree
{
    public class Hash : CryptTreeItem
    {
        public Hash(string title, string clearText, HashAlType algorithm, int saltGen)
        {
            throw new System.NotImplementedException();
        }
    
        public HashAlType Algorithm
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int SaltSize
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int WorkFactor
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public bool checkHash(string clearText)
        {
            throw new System.NotImplementedException();
        }

        public override string Text
        {
            get { throw new NotImplementedException(); }
        }

        private int agent;
    }
}
