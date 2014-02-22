using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Encryption_Station
{
    interface HashingAgent
    {
        string generateSalt(int value);
        string createHash(string clearText);
        string createHash(string clearText, string salt);
        bool checkHash(string clearText, string hash);
    }
}
