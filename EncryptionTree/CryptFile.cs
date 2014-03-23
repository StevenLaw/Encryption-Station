using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EncryptionTree
{
    public class CryptFile : CryptTreeItem
    {
        public CryptFile(string title, string filename, CryptAlgorithm algorithm, string key)
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

        public FileStream decrypt(string key)
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
