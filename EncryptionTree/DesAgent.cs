using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace EncryptionTree
{
    public sealed class DesAgent : EncryptionAgent
    {
        private const int keySize = 32;
        private const int IVSize = 16;

        private string key;

        /// <summary>
        /// Initializes the class with the key
        /// </summary>
        /// <param name="key">The key to be used for encryption and decryption</param>
        public DesAgent(string key)
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
            using (DES encryptor = DES.Create())
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
        /// Encrypts the file using DES with encryptionKey using the key set in the objects creation.
        /// </summary>
        /// <param name="filename">The filename.</param>
        public void encryptFile(string filename)
        {
            using (DES encryptor = DES.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key, new Byte[] {0x49, 0x76, 0x61, 
                        0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
                encryptor.Key = pdb.GetBytes(keySize);
                encryptor.IV = pdb.GetBytes(IVSize);
                using (FileStream fsInput = new FileStream(filename, FileMode.Open, FileAccess.Read),
                    fsEncrypted = new FileStream(filename + ".enc", FileMode.Create, FileAccess.Write))
                {
                    using (CryptoStream cs = new CryptoStream(fsEncrypted, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        byte[] byteArrayinput = new byte[fsInput.Length - 1];
                        fsInput.Read(byteArrayinput, 0, byteArrayinput.Length);
                        cs.Write(byteArrayinput, 0, byteArrayinput.Length);
                        cs.Close();
                    }
                }
            }
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
            using (DES encryptor = DES.Create())
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

        /// <summary>
        /// Decrypts the file using DES with encryptionKey using the key set in the objects creation.
        /// </summary>
        /// <param name="filename">The filename.</param>
        public void decryptFile(string filename)
        {
            using (DES encryptor = DES.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key, new Byte[] {0x49, 0x76, 0x61, 
                        0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
                encryptor.Key = pdb.GetBytes(keySize);
                encryptor.IV = pdb.GetBytes(IVSize);
                using (FileStream fsInput = new FileStream(filename, FileMode.Open, FileAccess.Read),
                    fsDecrypted = new FileStream(filename + ".enc", FileMode.Create, FileAccess.Write))
                {
                    using (CryptoStream cs = new CryptoStream(fsDecrypted, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        byte[] byteArrayinput = new byte[fsInput.Length - 1];
                        fsInput.Read(byteArrayinput, 0, byteArrayinput.Length);
                        cs.Write(byteArrayinput, 0, byteArrayinput.Length);
                        cs.Close();
                    }
                }
            }
        }
    }
}
