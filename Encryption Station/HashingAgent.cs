using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Encryption_Station
{
    /// <summary>
    /// This interface allows the use of multiple different hashing algorithms to be used with the same 
    /// methods.
    /// </summary>
    interface HashingAgent
    {
        /// <summary>
        /// Generate the salt with either the length or the work factor.
        /// </summary>
        /// <param name="value">The value to generate the salt with.</param>
        /// <returns>The generated salt.</returns>
        string generateSalt(int value);

        /// <summary>
        /// Creates the hash with no salt.
        /// </summary>
        /// <param name="clearText">The clear text.</param>
        /// <returns>The hashed string</returns>
        string createHash(string clearText);

        /// <summary>
        /// Creates the hash.
        /// </summary>
        /// <param name="clearText">The clear text.</param>
        /// <param name="salt">The salt.</param>
        /// <returns>The hashed and salted string.</returns>
        string createHash(string clearText, string salt);

        /// <summary>
        /// Checks the hash.
        /// </summary>
        /// <param name="clearText">The clear text.</param>
        /// <param name="hash">The hash.</param>
        /// <returns>True if the clear text and the hash match.</returns>
        bool checkHash(string clearText, string hash);
    }
}
