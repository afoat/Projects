namespace Foat.Collections.Generic
{
    using System;
    using System.Collections.Generic;

    public sealed partial class BinarySearchTree<T> : ICollection<T> where T : IComparable<T>
    {
        public void Add(T item)
        {
            this.Insert(item);
        }

        public bool Contains(T item)
        {
            return this.FindNode(item) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            return this.Delete(item);
        }

        public void Clear()
        {
            this.Root = null;
            this.Count = 0;
        }
    }
}
