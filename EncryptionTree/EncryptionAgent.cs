using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EncryptionTree
{
    /// <summary>
    /// This interface's purpose is to allow the use of multiple encryption methods.
    /// </summary>
    public interface EncryptionAgent
    {
        /// <summary>
        /// Method to encrypt the clearText.
        /// </summary>
        /// <param name="clearText">Text to be encrypted</param>
        /// <returns>The encrypted string</returns>
        string encrypt(string clearText);

        /// <summary>
        /// Method to Decrypt the cipherText.
        /// </summary>
        /// <param name="cipherText">Text to be decrypted</param>
        /// <returns>The clearText</returns>
        string decrypt(string cipherText);
    }
}
