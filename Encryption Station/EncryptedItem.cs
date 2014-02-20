using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Encryption_Station
{
    /// <summary>
    /// This class allows the dialogs to set multiple values for the encrypted item 
    /// in the file
    /// </summary>
    public class EncryptedItem
    {
        public string Title { get; set; }
        public string Algorithm { get; set; }
        public string CipherText { get; set; }
    }
}
