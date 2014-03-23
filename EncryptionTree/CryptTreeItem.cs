using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EncryptionTree
{
    public abstract class CryptTreeItem : IEnumerable<CryptTreeItem>
    {
        private int index = 0;
    
        public List<CryptTreeItem> Children { get; set; }

        public NodeType Type { get; set; }

        public string Title { get; set; }

        public string Value { get; set; }

        public abstract string Text { get; }

        public string createXmlString()
        {
            throw new System.NotImplementedException();
        }

        public CryptTreeItem next()
        {
            if (index < Children.Count - 1)
                index++;
            else
                index = 0;
            return Children[index];
        }

        public CryptTreeItem previous()
        {
            if (index > 0)
                index--;
            else
                index = Children.Count - 1;
            return Children[index];
        }

        public CryptTreeItem current()
        {
            return Children[index];
        }

        public int currentIndex()
        {
            return index;
        }

        public CryptTreeItem this[int Index]
        {
            get { return Children[index]; }
            set { Children.Insert(index, value); }
        }

        public IEnumerator<CryptTreeItem> GetEnumerator()
        {
            return Children.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void move(int oldIndex, int newIndex)
        {
            throw new System.NotImplementedException();
        }
    }
}
