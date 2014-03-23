using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace EncryptionTree
{
    class ShaAgent : HashingAgent
    {
        private int hashSize;
        private HashAlgorithm hashAl;

        /// <summary>
        /// Initializes agent new instance of the <see cref="ShaAgent"/> class.  Sets the HashAlgorithm to use 
        /// as well as the hash size in bits.
        /// </summary>
        /// <param name="algorithm">The algorithm.</param>
        public ShaAgent(string algorithm)
        {
            switch (algorithm.ToUpper())
            {
                case "SHA1":
                    hashAl = new SHA1Managed();
                    hashSize = 160;
                    break;
                case "SHA256":
                    hashAl = new SHA256Managed();
                    hashSize = 256;
                    break;
                case "SHA384":
                    hashAl = new SHA384Managed();
                    hashSize = 384;
                    break;
                default: //Default is SHA512
                    hashAl = new SHA512Managed();
                    hashSize = 512;
                    break;
            }
        }

        /// <summary>
        /// Generate the salt with either the length or the work factor.
        /// </summary>
        /// <param name="value">The value to generate the salt with.</param>
        /// <returns>
        /// The generated salt.
        /// </returns>
        public string generateSalt(int value)
        {
            if (value > 0)
            {
                byte[] salt = new byte[value];
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                rng.GetNonZeroBytes(salt);
                return Convert.ToBase64String(salt);
            }
            else
                return "";
        }

        /// <summary>
        /// Creates the hash with no salt.
        /// </summary>
        /// <param name="clearText">The clear text.</param>
        /// <returns>
        /// The hashed string
        /// </returns>
        public string createHash(string clearText)
        {
            byte[] clearBytes = Encoding.UTF8.GetBytes(clearText);
            byte[] hashBytes = hashAl.ComputeHash(clearBytes);
            return Convert.ToBase64String(hashBytes);
        }

        /// <summary>
        /// Creates the hash.
        /// </summary>
        /// <param name="clearText">The clear text.</param>
        /// <param name="salt">The salt.</param>
        /// <returns>
        /// The hashed and salted string.
        /// </returns>
        public string createHash(string clearText, string salt)
        {
            // convert clear text to bytes
            byte[] clearBytes = Encoding.UTF8.GetBytes(clearText);
            //Convert salt to bytes
            byte[] saltBytes = Convert.FromBase64String(salt);
            //Allocate bytes for combination
            byte[] clearSaltBytes = new byte[clearBytes.Length + saltBytes.Length];
            //Append salt to clea bytes
            for (int i = 0; i < clearBytes.Length; i++)
                clearSaltBytes[i] = clearBytes[i];
            for (int i = 0; i < saltBytes.Length; i++)
                clearSaltBytes[clearBytes.Length + i] = saltBytes[i];

            byte[] hashBytes = hashAl.ComputeHash(clearSaltBytes);
            //Allocate space for salt
            byte[] hashSaltBytes = new byte[hashBytes.Length + saltBytes.Length];
            //Copy hash
            for (int i = 0; i < hashBytes.Length; i++)
                hashSaltBytes[i] = hashBytes[i];
            //Append salt
            for (int i = 0; i < saltBytes.Length; i++)
                hashSaltBytes[hashBytes.Length + i] = saltBytes[i];
            return Convert.ToBase64String(hashSaltBytes);
        }

        /// <summary>
        /// Checks the hash.
        /// </summary>
        /// <param name="clearText">The clear text.</param>
        /// <param name="hash">The hash.</param>
        /// <returns>
        /// True if the clear text and the hash match.
        /// </returns>
        public bool checkHash(string clearText, string hash)
        {
            byte[] hashWithSaltBytes = Convert.FromBase64String(hash);
            int hashInBytes = hashSize / 8;
            if (hashWithSaltBytes.Length < hashInBytes)
                return false;
            string expectedHashString;
            if (hashWithSaltBytes.Length == hashInBytes ){
                expectedHashString = createHash(clearText);
            }
            else {
                byte[] saltBytes = new byte[hashWithSaltBytes.Length - hashInBytes];
                //transfer salt from end of hash to has
                for (int i = 0; i < saltBytes.Length; i++)
                    saltBytes[i] = hashWithSaltBytes[hashInBytes + i];
                expectedHashString = createHash(clearText, Convert.ToBase64String(saltBytes));
            }
            return expectedHashString.Equals(hash);
        }
    }
}
