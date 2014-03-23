using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EncryptionTree;
using System.Xml;

namespace EncryptionTreeUnitTests
{
    [TestClass]
    public class RootTests
    {
        [TestMethod]
        public void Root_Constructor_SetValues()
        {
            // arrange
            string title = "Filename";
            NodeType expectedType = NodeType.Root;

            // act
            Root root = new Root(title, "Random");

            // assert
            Assert.AreEqual(title, root.Title, false, "The title is not correct.");
            Assert.AreEqual(expectedType, root.Type, "The type is different.");
            string expectedText = "Filename File";
            Assert.AreEqual(expectedText, root.Text, "The text was output incorrectly");
        }
        [TestMethod]
        public void Root_changePassword_ValidPassword() 
        {
            // arrange
            string originalPassword = "Password";
            Root root = new Root("Title", originalPassword);
            string newPassword = "NewPassword";

            // act
            root.changePassword(newPassword);

            // assert
            bool result = root.checkPassword(newPassword);
            Assert.IsTrue(result, "The password did not match.");
        }
        [TestMethod]
        public void Root_checkPassword_ValidPassword() 
        {
            // arrange
            string originalPassword = "Password";
            Root root = new Root("Title", originalPassword);

            // act
            bool result = root.checkPassword(originalPassword);

            // assert
            Assert.IsTrue(result, "The password did not match.");
        }
        [TestMethod]
        public void Root_checkPassword_InvalidPassword()
        {
            // arrange
            Root root = new Root("Title", "Password");
            string incorrectPassword = "Incorrect";

            // act
            bool result = root.checkPassword(incorrectPassword);

            // assert
            Assert.IsFalse(result, "There was a false positive with the password checking.");
        }
        [TestMethod]
        public void Root_addKey_CountIncremented() 
        {
            // arrange
            Root root = new Root("Title", "Password");
            int initialCount = root.Count;
            Key key = new Key("Title", "Password", 24);
            
            // act
            root.addKey(key);
            int finalCount = root.Count;

            // assert
            Assert.IsTrue((finalCount > initialCount), "The final count was not greater than the initial count.");
        }
        [TestMethod]
        public void Root_addHash_Text_CountIncremented()
        {
            // arrange
            Root root = new Root("Title", "Password");
            int initialCount = root.Count;
            Hash hash = new Hash("Title", "Password", HashAlType.MD5, 20);

            // act
            root.addHash(hash);
            int finalCount = root.Count;

            // assert
            Assert.IsTrue((finalCount > initialCount), "The final count was not greater than the initial count.");
        }
        [TestMethod]
        public void Root_addHash_File_CountIncremented()
        {
            // arrange
            Root root = new Root("Title", "Password");
            int initialCount = root.Count;
            FileHash hash = new FileHash("Title", "password.text", HashAlType.MD5, 20);

            // act
            root.addHash(hash);
            int finalCount = root.Count;

            // assert
            Assert.IsTrue((finalCount > initialCount), "The final count was not greater than the initial count.");
        }
        [TestMethod]
        public void root_CreateXmlNode()
        {
            // arrange
            Root root = new Root("Title", "Password");

            // act
            XmlNode node = root.createXmlNode();

            // assert 
            // TODO assert Root_createXmlNode
        }
    }
}
