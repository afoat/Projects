namespace Foat.Collections.Generic
{
    using System;

    public sealed partial class SkipList<TKey, TValue> where TKey : IComparable<TKey>
    {
        internal sealed class Node
        {
            internal Node(int levels, TKey key, TValue value)
            {
                this.Key = key;
                this.Value = value;
                this.Next = new Node[levels];
            }

            #region Properties

            internal TKey Key { get; set; }
            internal TValue Value { get; set; }
            internal Node[] Next { get; set; }
            internal int Levels { get { return this.Next.Length; } }

            #endregion
        }
    }
}
