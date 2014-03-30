using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace EncryptionTree
{
    /// <summary>
    /// Represents a hashed text value.
    /// </summary>
    public class Hash : CryptTreeItem
    {
        private HashingAgent agent;

        /// <summary>
        /// Indicates what type of algorithm is being used.
        /// </summary>
        public HashAlType Algorithm { get; set; }

        /// <summary>
        /// The size of the salt that is being used.
        /// </summary>
        /// <remarks>
        /// Not relevant when using the BCrypt algorithm.
        /// </remarks>
        public int SaltSize { get; set; }

        /// <summary>
        /// The work factor used if it is a BCrypt hash.
        /// </summary>
        /// <remarks>
        /// This could be stored in the salt size property but I felt that it works better here.
        /// </remarks>
        public int WorkFactor { get; set; }

        /// <summary>
        /// Returns the Text output of the node.
        /// </summary>
        public override string Text
        {
            get 
            {
                StringBuilder text = new StringBuilder();
                if (Title != null && !Title.Equals(""))
                    text.Append(Title + ": ");
                text.Append("Hash " + (char)0x2013 + " ");
                if (Algorithm == HashAlType.BCrypt)
                    text.Append("Work Factor: " + WorkFactor + " " + (char)0x2013 + " ");
                else if (SaltSize > 0)
                    text.Append("Salt Size: " + SaltSize + " " + (char)0x2013 + " ");
                text.Append("Value: " + Value);
                return text.ToString();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Hash" /> object.
        /// </summary>
        /// <param name="title">The title of the hash.</param>
        /// <param name="clearText">The text to hash.</param>
        /// <param name="algorithm">The algorithm to use.</param>
        /// <param name="saltGen">The number used to generate the salt.  If it is BCrypt then it is the work
        /// factor otherwise it is the size of the salt.</param>
        /// <exception cref="BadSaltGenException">
        /// The salt generation value was less than zero.
        /// or
        /// BCrypt requires a work factor between 4 and 31.
        /// </exception>
        public Hash(string title, string clearText, HashAlType algorithm, int saltGen) : base()
        {
            if (saltGen < 0)
                throw new BadSaltGenException("The salt generation value was less than zero.");
            if (algorithm == HashAlType.BCrypt & (saltGen < 4 || saltGen > 31))
                throw new BadSaltGenException("BCrypt requires a work factor between 4 and 31.");

            Title = title;
            Algorithm = algorithm;
            if (algorithm == HashAlType.BCrypt)
                WorkFactor = saltGen;
            else
                SaltSize = saltGen;

            // create the agent based on the algorithm
            switch(algorithm)
            {
                default:
                    agent = new ShaAgent("SHA1");
                    break;
                case HashAlType.BCrypt:
                    agent = new BCryptAgent();
                    break;
                case HashAlType.MD5:
                    agent = new ShaAgent("MD5");
                    break;
                case HashAlType.SHA1:
                    agent = new ShaAgent("SHA1");
                    break;
                case HashAlType.SHA256:
                    agent = new ShaAgent("SHA256");
                    break;
                case HashAlType.SHA384:
                    agent = new ShaAgent("SHA384");
                    break;
                case HashAlType.SHA512:
                    agent = new ShaAgent("SHA512");
                    break;
            }

            string salt;
            if (saltGen > 0)
            {
                salt = agent.generateSalt(saltGen);
                Value = agent.createHash(clearText, salt);
            }
            else
            {
                Value = agent.createHash(clearText);
            }
        }

        /// <summary>
        /// Checks the hash against some text.
        /// </summary>
        /// <param name="clearText">The text to check the hash against.</param>
        /// <returns>True if the hash matches and false otherwise.</returns>
        public bool checkHash(string clearText)
        {
            return agent.checkHash(clearText, Value);
        }

        /// <summary>
        /// Creates an <see cref="XmlNode"/>.
        /// </summary>
        /// <returns>The generated <see cref="XmlNode"/>.</returns>
        public override XmlNode createXmlNode()
        {
            // TODO Implement Hash.CreateXmlNode
            throw new NotImplementedException();
        }
    }
}
