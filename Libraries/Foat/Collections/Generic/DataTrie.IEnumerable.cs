namespace Foat.Collections.Generic
{
    using System;
    using System.Collections.Generic;

    public sealed partial class DataTrie<TWord, TValue> : IEnumerable<KeyValuePair<TWord, TValue>>
        where TWord : IData
    {
        /// <summary>
        /// Enumerate through the key value pairs stored in this trie.
        /// </summary>
        public IEnumerator<KeyValuePair<TWord, TValue>> GetEnumerator()
        {
            foreach (KeyValuePair<byte[], TValue> item in this.Head.GetEnumerator(this.AlphabetIndexTable))
            {
                yield return new KeyValuePair<TWord, TValue>(this.Constructor(item.Key), item.Value);
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
