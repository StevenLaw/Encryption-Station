using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EncryptionTree;

namespace EncryptionTreeUnitTests
{
    [TestClass]
    public class HashTests
    {
        [TestMethod]
        public void Hash_Constructor_BCrypt()
        {
            // arrange
            string title = "Hash Title";
            string clearText = "This text to hash.";
            HashAlType algorithm = HashAlType.BCrypt;
            int saltGen = 8;

            // act
            Hash hash = new Hash(title, clearText, algorithm, saltGen);

            // assert
            Assert.AreEqual(title, hash.Title, "The title was not correct.");
            Assert.AreEqual(algorithm, hash.Algorithm, "The algorithm was not correct.");
            Assert.AreEqual(saltGen, hash.WorkFactor, "The workfactor was not correct.");
            string expectedTextStart = title + ": " + "Hash " + (char)0x2013 + " " + "Work Factor: " +
                saltGen + " " + (char)0x2013 + " " + "Value: ";
            Assert.IsTrue(hash.Text.StartsWith(expectedTextStart), "The text started incorrectly.");
        }
        [TestMethod]
        public void Hash_Constructor_MD5()
        {
            // arrange
            string title = "Hash Title";
            string clearText = "This text to hash.";
            HashAlType algorithm = HashAlType.MD5;
            int saltGen = 8;

            // act
            Hash hash = new Hash(title, clearText, algorithm, saltGen);

            // assert
            Assert.AreEqual(title, hash.Title, "The title was not correct.");
            Assert.AreEqual(algorithm, hash.Algorithm, "The algorithm was not correct.");
            Assert.AreEqual(saltGen, hash.SaltSize, "The workfactor was not correct.");
            string expectedTextStart = title + ": " + "Hash " + (char)0x2013 + " " + "Salt Size: " +
                saltGen + " " + (char)0x2013 + " " + "Value: ";
            Assert.IsTrue(hash.Text.StartsWith(expectedTextStart), "The text started incorrectly.");
        }
        [TestMethod]
        public void Hash_Constructor_SHA()
        {
            // arrange
            string title = "Hash Title";
            string clearText = "This text to hash.";
            HashAlType algorithm = HashAlType.SHA1;
            int saltGen = 8;

            // act
            Hash hash = new Hash(title, clearText, algorithm, saltGen);

            // assert
            Assert.AreEqual(title, hash.Title, "The title was not correct.");
            Assert.AreEqual(algorithm, hash.Algorithm, "The algorithm was not correct.");
            Assert.AreEqual(saltGen, hash.SaltSize, "The workfactor was not correct.");
            string expectedTextStart = title + ": " + "Hash " + (char)0x2013 + " " + "Salt Size: " +
                saltGen + " " + (char)0x2013 + " " + "Value: ";
            Assert.IsTrue(hash.Text.StartsWith(expectedTextStart), "The text started incorrectly.");
        }
        [TestMethod]
        public void Hash_Constructor_SHA_SaltSize0()
        {
            // arrange
            string title = "Hash Title";
            string clearText = "This text to hash.";
            HashAlType algorithm = HashAlType.SHA1;
            int saltGen = 0;

            // act
            Hash hash = new Hash(title, clearText, algorithm, saltGen);

            // assert
            Assert.AreEqual(title, hash.Title, "The title was not correct.");
            Assert.AreEqual(algorithm, hash.Algorithm, "The algorithm was not correct.");
            Assert.AreEqual(saltGen, hash.SaltSize, "The workfactor was not correct.");
            string expectedTextStart = title + ": " + "Hash " + (char)0x2013 + " " + "Value: ";
            Assert.IsTrue(hash.Text.StartsWith(expectedTextStart), "The text started incorrectly.");
        }
        [TestMethod]
        [ExpectedException(typeof(BadSaltGenException))]
        public void Hash_Constructor_BCrypt_WorkFactorTooLow()
        {
            // arrange
            string title = "Hash Title";
            string clearText = "This text to hash.";
            HashAlType algorithm = HashAlType.BCrypt;
            int saltGen = 3;

            // act
            Hash hash = new Hash(title, clearText, algorithm, saltGen);

            // assert is handled by expected exception
        }
        [TestMethod]
        [ExpectedException(typeof(BadSaltGenException))]
        public void Hash_Constructor_BCrypt_WorkFactorTooHigh()
        {
            // arrange
            string title = "Hash Title";
            string clearText = "This text to hash.";
            HashAlType algorithm = HashAlType.BCrypt;
            int saltGen = 32;

            // act
            Hash hash = new Hash(title, clearText, algorithm, saltGen);

            // assert is handled by expected exception
        }
        [TestMethod]
        [ExpectedException(typeof(BadSaltGenException))]
        public void Hash_Constructor_Sha_SaltSizeNegative()
        {
            // arrange
            string title = "Hash Title";
            string clearText = "This text to hash.";
            HashAlType algorithm = HashAlType.SHA1;
            int saltGen = -3;

            // act
            Hash hash = new Hash(title, clearText, algorithm, saltGen);

            // assert is handled by expected exception
        } 
        [TestMethod]
        public void Hash_checkHash_BCrypt()
        {
            // arrange
            string title = "Hash Title";
            string clearText = "This text to hash.";
            HashAlType algorithm = HashAlType.BCrypt;
            int saltGen = 8;

            // act
            Hash hash = new Hash(title, clearText, algorithm, saltGen);

            // assert
            Assert.IsTrue(hash.checkHash(clearText), "The hash check failed");
        }
        [TestMethod]
        public void Hash_checkHash_MD5()
        {
            // arrange
            string title = "Hash Title";
            string clearText = "This text to hash.";
            HashAlType algorithm = HashAlType.MD5;
            int saltGen = 8;

            // act
            Hash hash = new Hash(title, clearText, algorithm, saltGen);

            // assert
            Assert.IsTrue(hash.checkHash(clearText), "The hash check failed");
        }
        [TestMethod]
        public void Hash_checkHash_SHA()
        {
            // arrange
            string title = "Hash Title";
            string clearText = "This text to hash.";
            HashAlType algorithm = HashAlType.SHA1;
            int saltGen = 8;

            // act
            Hash hash = new Hash(title, clearText, algorithm, saltGen);

            // assert
            Assert.IsTrue(hash.checkHash(clearText), "The hash check failed");
        }
        [TestMethod]
        public void Hash_checkHash_BCrypt_False()
        {
            // arrange
            string title = "Hash Title";
            string clearText = "This text to hash.";
            HashAlType algorithm = HashAlType.BCrypt;
            int saltGen = 8;

            // act
            Hash hash = new Hash(title, clearText, algorithm, saltGen);

            // assert
            string badText = "This text is not the same";
            Assert.IsFalse(hash.checkHash(badText), "The hash check failed");
        }
        [TestMethod]
        public void Hash_checkHash_MD5_False()
        {
            // arrange
            string title = "Hash Title";
            string clearText = "This text to hash.";
            HashAlType algorithm = HashAlType.MD5;
            int saltGen = 8;

            // act
            Hash hash = new Hash(title, clearText, algorithm, saltGen);

            // assert
            string badText = "This text is not the same";
            Assert.IsFalse(hash.checkHash(badText), "The hash check failed");
        }
        [TestMethod]
        public void Hash_checkHash_SHA_False()
        {
            // arrange
            string title = "Hash Title";
            string clearText = "This text to hash.";
            HashAlType algorithm = HashAlType.SHA1;
            int saltGen = 8;

            // act
            Hash hash = new Hash(title, clearText, algorithm, saltGen);

            // assert
            string badText = "This text is not the same";
            Assert.IsFalse(hash.checkHash(badText), "The hash check failed");
        }
    }
}
