namespace Foat.Collections.Generic
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public sealed partial class SkipList<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>> where TKey : IComparable<TKey>
    {
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            Node current = this.Head.Next[0];
            while (current != null)
            {
                yield return new KeyValuePair<TKey, TValue>(current.Key, current.Value);
                current = current.Next[0];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
