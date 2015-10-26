namespace Foat.Collections.Generic
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A byte based trie node. Uses bytes as the letters in the trie instead of
    /// characters like a normal trie. This allows us to store a wider range of data
    /// in the trie.
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    internal sealed partial class DataTrieNode<TValue>
    {
        #region Properties

        /// <summary>
        /// The value stored in this node of the trie default(TValue) if there is no object stored in this node.
        /// </summary>
        public TValue Value { get; private set; }

        /// <summary>
        /// An array of subnodes used to navigate through the trie.
        /// </summary>
        private DataTrieNode<TValue>[] Data;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates an instance of the DataTrieNode class
        /// </summary>
        /// <param name="alphabetSize">The maximum number of letters in the alphabet</param>
        public DataTrieNode(int alphabetSize)
        {
            this.Data = new DataTrieNode<TValue>[alphabetSize];
        }

        #endregion

        #region Insert

        /// <summary>
        /// Inserts the key (which is a byte[]) into the trie and associates it with the given value.
        /// </summary>
        /// <param name="key">The key to add to the trie</param>
        /// <param name="value">The value to associate with the key</param>
        /// <param name="alphabetIndexTable">The index table used to map letters to indexes and back</param>
        internal void Insert(byte[] key, TValue value, DataTrieAlphabetIndexTable alphabetIndexTable)
        {
            DataTrieNode<TValue> currentTrieNodeLevel = this;
            DataTrieNode<TValue> subTrieNode;

            foreach (byte b in key)
            {
                int byteIndex = alphabetIndexTable.GetIndex(b);
                if (currentTrieNodeLevel.Data[byteIndex] == null) // new item - make a new DataTrieNode
                {
                    subTrieNode = new DataTrieNode<TValue>(alphabetIndexTable.Count);
                    currentTrieNodeLevel.Data[byteIndex] = subTrieNode;
                }
                else // Existing item - follow it further
                {
                    subTrieNode = currentTrieNodeLevel.Data[byteIndex];
                }

                currentTrieNodeLevel = subTrieNode;
            }

            currentTrieNodeLevel.Value = value;
        }

        #endregion

        #region Contains

        /// <summary>
        /// Returns true if the given key (which is a byte[]) is found in the trie
        /// </summary>
        /// <param name="key">The key that you want to check the trie for</param>
        /// <param name="alphabetIndexTable">The index table used to map letters to indexes and back</param>
        /// <returns></returns>
        public bool Contains(byte[] key, DataTrieAlphabetIndexTable alphabetIndexTable)
        {
            bool contains = true;
            DataTrieNode<TValue> currentTrieNodeLevel = this;
            foreach (byte b in key)
            {
                int byteIndex = alphabetIndexTable.GetIndex(b);

                if (currentTrieNodeLevel.Data[byteIndex] != null)
                {
                    currentTrieNodeLevel = currentTrieNodeLevel.Data[byteIndex];
                }
                else
                {
                    contains = false;
                    break;
                }
            }

            return contains && !currentTrieNodeLevel.Value.Equals(default(TValue));
        }

        #endregion
    }
}
