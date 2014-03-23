using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace EncryptionTree
{
    public sealed class AesAgent : EncryptionAgent
    {
        private const int keySize = 32;
        private const int IVSize = 16;

        private string key;

        /// <summary>
        /// Initializes the class with the key
        /// </summary>
        /// <param name="key">The key to be used for encryption and decryption</param>
        public AesAgent(string key)
        {
            this.key = key;
        }

        /// <summary>
        /// Encrypts the clear text using AES with encryptionKey as the key.
        /// </summary>
        /// <param name="clearText">The text to be encrypted.</param>
        /// <returns>The encrypted text.</returns>
        public string encrypt(string clearText)
        {
            Byte[] clearBytes = Encoding.UTF8.GetBytes(clearText);
            string result;
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key, new Byte[] {0x49, 0x76, 0x61, 
                    0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
                encryptor.Key = pdb.GetBytes(keySize);
                encryptor.IV = pdb.GetBytes(IVSize);
                using (MemoryStream ms = new MemoryStream()) {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)) {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    result = Convert.ToBase64String(ms.ToArray());
                }
            }
            return result;
        }

        /// <summary>
        /// Decrypts the cipher text using AES with encryptionKey as the key.
        /// </summary>
        /// <param name="cipherText">The cipher text to be decrypted</param>
        /// <returns>The clear text.</returns>
        public string decrypt(string cipherText)
        {
            Byte[] cipherBytes = Convert.FromBase64String(cipherText);
            string result;
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key, new Byte[] {0x49, 0x76, 0x61, 
                    0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
                encryptor.Key = pdb.GetBytes(keySize);
                encryptor.IV = pdb.GetBytes(IVSize);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    result = Encoding.UTF8.GetString(ms.ToArray());
                }
            }
            return result;
        }
    }
}
