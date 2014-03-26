using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EncryptionTree;
using System.Xml;

namespace EncryptionTreeUnitTests
{
    [TestClass]
    public class KeyTests
    {
        [TestMethod]
        public void Key_Constructor_Generate()
        {
            // arrange
            string title = "Key Title";
            string password = "Password";
            int length = 20;
            NodeType expectedType = NodeType.Key;

            // act
            Key key = new Key(title, password, length);

            // assert
            Assert.AreEqual(title, key.Title, "The title is not correct.");
            Assert.AreEqual(expectedType, NodeType.Key, "The type is different.");
            string expectedTextStart = "Key Title: Key " + (char)0x2013 + " Value: ";
            Assert.IsTrue(key.Text.StartsWith(expectedTextStart), "The text had an incorrect beginning.");
            Assert.AreEqual(key.decryptKey().Length, length, "The key was the incorrect length.");
            Assert.AreEqual(key.Length, length, "The length was incorrect.");
        }
        [TestMethod]
        public void Key_Constructor_Premade()
        {
            // arrange
            string title = "Key Title";
            string password = "Password";
            string premadeKey = "This is a key";
            NodeType expectedType = NodeType.Key;

            // act
            Key key = new Key(title, password, premadeKey);

            // assert
            Assert.AreEqual(title, key.Title, "The title is not correct.");
            Assert.AreEqual(expectedType, NodeType.Key, "The type is different.");
            string expectedTextStart = "Key Title: Key " + (char)0x2013 + " Value: ";
            Assert.IsTrue(key.Text.StartsWith(expectedTextStart), "The text had an incorrect beginning.");
            Assert.AreEqual(key.decryptKey(), premadeKey, "The length was incorrect.");
            Assert.AreEqual(key.Length, premadeKey.Length, "The length was incorrect.");
        }
        [TestMethod]
        public void Key_AddCrypt_File_CountIncremented()
        {
            // arrange
            Key key = new Key("Title", "Password", 25);
            int initialCount = key.Count;
            CryptFile crypt = new CryptFile("Title", "filename", CryptAlgorithm.AES, key.decryptKey());

            // act
            key.addCrypt(crypt);
            int finalCount = key.Count;

            // assert
            Assert.IsTrue((finalCount > initialCount), "The final count was not greater than the initial count");
        }
        [TestMethod]
        public void Key_AddCrypt_Text_CountIncremented()
        {
            // arrange
            Key key = new Key("Title", "Password", 25);
            int initialCount = key.Count;
            CryptText crypt = new CryptText("Title", "This is text to encrypt", CryptAlgorithm.AES,
                key.decryptKey());

            // act
            key.addCrypt(crypt);
            int finalCount = key.Count;

            // assert
            Assert.IsTrue((finalCount > initialCount), "The final count was not greater than the initial count");
        }
        [TestMethod]
        public void Key_CreateXmlNode()
        {
            // arrange
            Key key = new Key("Title", "Password", 25);

            // act
            XmlNode node = key.createXmlNode();

            // assert
            // TODO assert Key_CreateXmlNode
        }
    }
}
