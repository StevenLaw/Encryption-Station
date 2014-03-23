using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EncryptionTree;

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

        }
        [TestMethod]
        public void Root_changePassword_InvalidPassword() 
        {

        }
        [TestMethod]
        public void Root_checkPassword_ValidPassword() 
        {

        }
        [TestMethod]
        public void Root_addKey_CountIncremented() 
        {

        }
        [TestMethod]
        public void Root_addHash_Text_CountIncremented()
        {

        }
        [TestMethod]
        public void Root_addHash_File_CountIncremented()
        {

        }
    }
}
