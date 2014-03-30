using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionTree
{
    /// <summary>
    /// A basic exception that simply distinguishes itself from the standard exception.
    /// </summary>
    public class BadSaltGenException : Exception
    {
        /// <summary>
        /// Empty constructor.
        /// </summary>
        public BadSaltGenException()
        {

        }

        /// <summary>
        /// Sets the exception's message.
        /// </summary>
        /// <param name="message">The message to set.</param>
        public BadSaltGenException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Sets the message and inner exception.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner Exception.</param>
        public BadSaltGenException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
