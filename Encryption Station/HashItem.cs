using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Encryption_Station
{
    /// <summary>
    /// This class allows the dialogs to set multiple values for the hash item 
    /// in the file
    /// </summary>
    class HashItem
    {
        public string Title { get; set; }
        public string Algorithm { get; set; }
        public string Value { get; set; }
        public int WorkFactor { get; set; }
    }
}
