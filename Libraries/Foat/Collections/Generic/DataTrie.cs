namespace Foat.Collections.Generic
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A trie that stores objects instead of characters. Objects must support the IData interface which
    /// allows the trie to get a representation of the object as a byte[]. The bytes are used as the letters
    /// in the trie.
    /// 
    /// This implementation isn't so efficient in a sparse dictionary (one with lots of letters, but not a lot of keys).
    /// </summary>
    /// <typeparam name="TWord">The type of the key that will be used as an index into the trie.</typeparam>
    /// <typeparam name="TValue">The type of data that we want to associate with the key.</typeparam>
    public sealed partial class DataTrie<TWord, TValue>
        where TWord : IData
    {
        #region Properties

        /// <summary>
        /// The number of keys in the trie
        /// </summary>
        public int Count { get; private set; }
        
        /// <summary>
        /// The head node of the trie
        /// </summary>
        private DataTrieNode<TValue> Head { get; set; }

        /// <summary>
        /// Can convert the letters/bytes in this alphabet to a 0..N-1 based index and back
        /// </summary>
        private DataTrieAlphabetIndexTable AlphabetIndexTable;

        /// <summary>
        /// A constructor that can take a byte array and returns an object that matches the original key
        /// </summary>
        private Func<byte[], TWord> Constructor;

        /// <summary>
        /// An enumeration of all of the keys this trie
        /// </summary>
        public IEnumerable<TWord> Keys
        {
            get
            {
                foreach (KeyValuePair<byte[], TValue> item in this.Head.GetEnumerator(this.AlphabetIndexTable))
                {
                    yield return this.Constructor(item.Key);
                }
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs an instance of a DataTrie
        /// </summary>
        /// <param name="alphabet">The valid letters that we could see in the trie</param>
        /// <param name="constructor">A delegate that can re-construct the keys when we are extracting them from the trie.</param>
        public DataTrie(IEnumerable<byte> alphabet, Func<byte[], TWord> constructor)
        {
            if (alphabet == null)
                throw new ArgumentNullException("alphabet");


            this.Count = 0;
            this.Constructor = constructor;
            this.AlphabetIndexTable = new DataTrieAlphabetIndexTable(alphabet);
            this.Head = new DataTrieNode<TValue>(this.AlphabetIndexTable.Count);
        }

        #endregion

        #region Insert 

        /// <summary>
        /// Inserts the key into the trie and associates the value with that key,
        /// </summary>
        public void Insert(TWord key, TValue value)
        {
            this.Head.Insert(key.GetBytes(), value, this.AlphabetIndexTable);
            this.Count += 1;
        }

        #endregion

        #region Contains

        /// <summary>
        /// Returns true of the key was found in the trie.
        /// </summary>
        public bool Contains(TWord key)
        {
            return this.Head.Contains(key.GetBytes(), this.AlphabetIndexTable);
        }

        #endregion

    }
}
