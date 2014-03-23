using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace EncryptionTree
{
    public abstract class CryptTreeItem : IEnumerable<CryptTreeItem>
    {
        /// <summary>
        /// The current location in the top rank of this node.
        /// </summary>
        private int index = 0;
    
        /// <summary>
        /// The node's childeren;
        /// </summary>
        public List<CryptTreeItem> Children { get; set; }

        /// <summary>
        /// What type of node the object is.
        /// </summary>
        public NodeType Type { get; set; }

        /// <summary>
        /// The node's title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The node's title.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>In the <see cref="Root"/> this will be the hashed password.</item>
        /// <item>The <see cref="Key"/> will use this for the encrypted value of the key.</item>
        /// <item>The <see cref="Hash"/> and <see cref="FileHash"/> will use it for the hashed value of the object.</item>
        /// <item>The <see cref="CryptText"/> will insert the encrypted text here.</item>
        /// <item>The <see cref="CryptFile"/> will put the filename of the encrypted file here. Take the 
        /// original filename add .enc to the extention.</item>
        /// </list>
        /// </remarks>
        public string Value { get; set; }

        /// <summary>
        /// Returns the Text output of the node.
        /// </summary>
        public abstract string Text { get; }

        /// <summary>
        /// Makes retrieving the count closer to the item's name.
        /// </summary>
        public int Count
        {
            get
            {
                return Children.Count;
            }
        }

        /// <summary>
        /// Generic empty constructor creates the list.
        /// </summary>
        public CryptTreeItem()
        {
            Children = new List<CryptTreeItem>();
        }

        /// <summary>
        /// Generates an xml string for the node.
        /// </summary>
        /// <returns>The xms string for that node and its children.</returns>
        public abstract XmlNode createXmlNode();

        /// <summary>
        /// Moves to the next item in the top level of its children and returns it.
        /// </summary>
        /// <returns>The next child in its top level.</returns>
        public CryptTreeItem next()
        {
            if (index < Children.Count - 1)
                index++;
            else
                index = 0;
            return Children[index];
        }

        /// <summary>
        /// Moves to the previous item in the top level of its children and returns it.
        /// </summary>
        /// <returns>The previous child in its top level.</returns>
        public CryptTreeItem previous()
        {
            if (index > 0)
                index--;
            else
                index = Children.Count - 1;
            return Children[index];
        }

        /// <summary>
        /// Returns the current child.
        /// </summary>
        /// <returns>The current child.</returns>
        public CryptTreeItem current()
        {
            return Children[index];
        }

        /// <summary>
        /// Returns the current index.
        /// </summary>
        /// <returns>The current index.</returns>
        public int currentIndex()
        {
            return index;
        }

        /// <summary>
        /// Gets or sets the child at the index in the top level.
        /// </summary>
        /// <param name="index">The index of the child to be gotten or set.</param>
        /// <returns>The child at that index.</returns>
        public CryptTreeItem this[int index]
        {
            get { return Children[index]; }
            set { Children.Insert(index, value); }
        }

        /// <summary>
        /// Moves the item at the old index to the new index.
        /// </summary>
        /// <param name="oldIndex">The original position of the item.</param>
        /// <param name="newIndex">The new position of the item.</param>
        /// <remarks>Not yet implemented</remarks>
        public void move(int oldIndex, int newIndex)
        {
            // TODO Implement move.
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Removes the item at the specified index.
        /// </summary>
        /// <param name="index"></param>
        public void remove(int index)
        {
            // TODO Implement remove.
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Returns the generic enumerator.
        /// </summary>
        /// <returns>The generic enumerator.</returns>
        public IEnumerator<CryptTreeItem> GetEnumerator()
        {
            return Children.GetEnumerator();
        }

        /// <summary>
        /// Returns the non-generic enumerator.
        /// </summary>
        /// <returns>The non-generic enumerator.1</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
