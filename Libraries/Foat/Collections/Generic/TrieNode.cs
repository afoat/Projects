namespace Foat.Collections.Generic
{
    using System;
    using System.Collections.Generic;

    internal sealed partial class TrieNode<TKey, TValue>
        where TKey : IEquatable<TKey>
    {
        #region Properties

        public TValue Value { get; private set; }

        internal Dictionary<TKey, TrieNode<TKey, TValue>> Alphabet { get; private set; }

        #endregion

        #region Constructors

        public TrieNode(int alphabetSize)
        {
            this.Alphabet = new Dictionary<TKey, TrieNode<TKey, TValue>>(alphabetSize);
        }

        #endregion

        #region Insert

        internal void Insert(TKey[] key, TValue value)
        {
            TrieNode<TKey, TValue> currentTrieNodeLevel = this;
            TrieNode<TKey, TValue> subTrieNode;

            foreach (TKey keyPart in key)
            {
                if (!currentTrieNodeLevel.Alphabet.ContainsKey(keyPart))
                {
                    subTrieNode = new TrieNode<TKey, TValue>(this.Alphabet.Count);
                    currentTrieNodeLevel.Alphabet[keyPart] = subTrieNode;
                }
                else
                {
                    subTrieNode = currentTrieNodeLevel.Alphabet[keyPart];
                }

                currentTrieNodeLevel = subTrieNode;
            }

            currentTrieNodeLevel.Value = value;
        }

        #endregion

        #region Contains

        public bool Contains(TKey[] key)
        {
            bool contains = true;
            TrieNode<TKey, TValue> currentTrieNodeLevel = this;
            foreach (TKey keyPart in key)
            {
                TrieNode<TKey, TValue> subTrieNode;
                if (currentTrieNodeLevel.Alphabet.TryGetValue(keyPart, out subTrieNode))
                {
                    subTrieNode = currentTrieNodeLevel.Alphabet[keyPart];
                    currentTrieNodeLevel = subTrieNode;
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
