namespace Foat.Collections.Generic
{

    internal sealed class SkipListNode<TKey, TValue>
    {
        internal SkipListNode(int levels, TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
            this.Next = new SkipListNode<TKey, TValue>[levels];
        }

        #region Properties

        internal TKey Key { get; set; }
        internal TValue Value { get; set; }
        internal SkipListNode<TKey, TValue>[] Next { get; set; }
        internal int Levels { get { return this.Next.Length; } }

        #endregion
    }
}
