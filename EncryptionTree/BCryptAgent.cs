using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevOne.Security.Cryptography.BCrypt;

namespace EncryptionTree
{
    /// <summary>
    /// Wrapper for BCrypt
    /// </summary>
    class BCryptAgent : HashingAgent
    {
        /// <summary>
        /// Generate the salt using the specified work factor.
        /// </summary>
        /// <param name="value">The work factor to use.</param>
        /// <returns>The generated salt.</returns>
        public string generateSalt(int value)
        {
            return BCryptHelper.GenerateSalt(value);
        }

        /// <summary>
        /// Generates hash with the default work factor.
        /// </summary>
        /// <param name="clearText">The text to hash.</param>
        /// <returns>The hashed value.</returns>
        public string createHash(string clearText)
        {
            string salt = BCryptHelper.GenerateSalt();
            return BCryptHelper.HashPassword(clearText, salt);
        }

        /// <summary>
        /// Create hash using agent salt.
        /// </summary>
        /// <param name="clearText">The text to hash.</param>
        /// <param name="salt">The salt to add to the hash.</param>
        /// <returns>The salted hash.</returns>
        public string createHash(string clearText, string salt)
        {
            return BCryptHelper.HashPassword(clearText, salt);
        }

        /// <summary>
        /// Verify that the hash matches the value.
        /// </summary>
        /// <param name="clearText">The value to check</param>
        /// <param name="hash">The hash to check.</param>
        /// <returns>True if they match false otherwise.</returns>
        public bool checkHash(string clearText, string hash)
        {
            return BCryptHelper.CheckPassword(clearText, hash);
        }
    }
}
