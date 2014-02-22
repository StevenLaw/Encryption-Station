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
    public class TreeItem
    {
        public string Title { get; set; }
        public string Algorithm { get; set; }
        public int WorkFactor { get; set; }
        public int Length { get; set; }
        public int SaltSize { get; set; }
        public string Value { get; set; }
        public NodeType Type { get; set; }
        public string Text { 
            get
            {
                string text = "";
                if (Title != null && !Title.Equals(""))
                    text += Title + ": ";
                switch (Type)
                {
                    case NodeType.Root:
                        text += "File";
                        break;
                    case NodeType.Key:
                        text += "Key";
                        break;
                    case NodeType.Hash:
                        text += "Hash";
                        break;
                    case NodeType.Cipher:
                        text += "Cipher";
                        break;
                }
                if (Algorithm != null && !Algorithm.Equals(""))
                    text += " Algorithm: " + Algorithm;
                if (WorkFactor != 0)
                    text += " Work Factor: " + WorkFactor;
                if (Length != 0)
                    text += " Length: " + Length.ToString();
                if (Value != null && !Value.Equals(""))
                {
                    if (Type.Equals(NodeType.Cipher) || Type.Equals(NodeType.Key))
                        text += " Encrypted";
                    text += " Value: " + Value;
                }
                return text;
                } 
            }
    }
}
