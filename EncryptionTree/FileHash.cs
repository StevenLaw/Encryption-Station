using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EncryptionTree
{
    public class FileHash : CryptTreeItem
    {
        public FileHash(string title, string filename, HashAlType algorithm, int saltGen)
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

        public bool checkHash(string filename)
        {
            throw new System.NotImplementedException();
        }

        public override string Text
        {
            get { throw new NotImplementedException(); }
        }

        private HashingAgent agent;
    }
}
