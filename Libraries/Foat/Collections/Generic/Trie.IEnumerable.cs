namespace Foat.Collections.Generic
{
    using System;
    using System.Collections.Generic;

    public sealed partial class Trie<TKey, TValue> : IEnumerable<KeyValuePair<TKey[], TValue>>
        where TKey : IEquatable<TKey>
    {

        public IEnumerator<KeyValuePair<TKey[], TValue>> GetEnumerator()
        {
            if (this.Head != null)
            {
                foreach (KeyValuePair<TKey[], TValue> keyValuePair in this.Head)
                    yield return keyValuePair;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
