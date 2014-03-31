using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EncryptionTree;
using System.IO;

namespace EncryptionTreeUnitTests
{
    [TestClass]
    public class EncryptionAgentTests
    {   
        //Aes Agent tests
        [TestMethod]
        public void AesAgent_TextEncryptionDecryption()
        {
            // arrange
            string key = "This is a key";
            EncryptionAgent agent = new AesAgent(key);
            string clearText = "This is text to be encrypted";

            // act
            string cipherText = agent.encrypt(clearText);
            string deciphered = agent.decrypt(cipherText);

            // assert
            Assert.AreEqual(clearText, deciphered, "The deciphered text did not match the initial text.");
        }
        [TestMethod]
        public void AesAgent_FileEncryptionDecryption()
        {
            // arrange
            string key = "This is a key";
            EncryptionAgent agent = new AesAgent(key);
            string clearTextFile = 
                "D:/Working folder/Code/Csharp/Encryption-Station/EncryptionTreeUnitTests/TestFiles/DxDiagAesTest.txt";

            // act
            agent.encryptFile(clearTextFile);
            agent.decryptFile(clearTextFile + ".enc");

            // assert
            Assert.IsTrue(FileEquals(clearTextFile, clearTextFile + ".dec"), 
                "The input file and the output file did not match.");
        }

        //Des Agent tests
        [TestMethod]
        public void DesAgent_TextEncryptionDecryption()
        {
            // arrange
            string key = "This is a key";
            EncryptionAgent agent = new DesAgent(key);
            string clearText = "This is text to be encrypted";

            // act
            string cipherText = agent.encrypt(clearText);
            string deciphered = agent.decrypt(cipherText);

            // assert
            Assert.AreEqual(clearText, deciphered, "The deciphered text did not match the initial text.");
        }
        [TestMethod]
        public void DesAgent_FileEncryptionDecryption()
        {
            // arrange
            string key = "This is a key";
            EncryptionAgent agent = new DesAgent(key);
            string clearTextFile = 
                "D:/Working folder/Code/Csharp/Encryption-Station/EncryptionTreeUnitTests/TestFiles/DxDiagDesTest.txt";

            // act
            agent.encryptFile(clearTextFile);
            agent.decryptFile(clearTextFile + ".enc");

            // assert
            Assert.IsTrue(FileEquals(clearTextFile, clearTextFile + ".dec"),
                "The input file and the output file did not match.");
        }

        /// <summary>
        /// Tests the equality of two files.
        /// </summary>
        /// <param name="path1">The path1.</param>
        /// <param name="path2">The path2.</param>
        /// <returns></returns>
        static bool FileEquals(string path1, string path2)
        {
            byte[] file1 = File.ReadAllBytes(path1);
            byte[] file2 = File.ReadAllBytes(path2);
            if (file1.Length == file2.Length)
            {
                for (int i = 0; i < file1.Length; i++)
                {
                    if (file1[i] != file2[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
