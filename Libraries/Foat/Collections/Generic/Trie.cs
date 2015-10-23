namespace Foat.Collections.Generic
{
    using System;

    public sealed partial class Trie<TKey, TValue>
        where TKey : IEquatable<TKey>
    {
        #region Properties

        public int Count { get; private set; }
        
        internal TrieNode<TKey, TValue> Head { get; set; }

        #endregion

        #region Constructor

        public Trie(int alphabetSize)
        {
            this.Count = 0;
            this.Head = new TrieNode<TKey, TValue>(alphabetSize);
        }

        #endregion

        #region Insert 

        public void Insert(TKey[] key, TValue value)
        {
            this.Head.Insert(key, value);
            this.Count += 1;
        }

        #endregion

        #region Contains

        public bool Contains(TKey[] key)
        {
            return this.Head.Contains(key);
        }

        #endregion

    }
}
