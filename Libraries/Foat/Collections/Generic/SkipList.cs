namespace Foat.Collections.Generic
{
    using Foat;
    using System;

    /// <summary>
    /// A skiplist that can associate a key with a value. Insert, lookup, and delete all happen in O(log n)
    /// </summary>
    public sealed partial class SkipList<TKey, TValue> 
        where TKey : IComparable<TKey>
    {
        #region Constructors

        /// <summary>
        /// Creates an instance of the SkipList class
        /// </summary>
        public SkipList(): this(new Foat.Random((int)DateTime.Now.Ticks))
        {
        }

        /// <summary>
        /// Creates an instance of the SkipList class
        /// </summary>
        internal SkipList(IRandom random)
        {
            if (random == null)
            {
                this.Random = new Foat.Random((int)DateTime.Now.Ticks);
            }
            else
            {
                this.Random = random;
            }

            InitParameters();
        }

        /// <summary>
        /// Initializes the private and public members of the class
        /// </summary>
        private void InitParameters()
        {

            this.Count = 0;
            this.Levels = 1;
            this.Head = new SkipListNode<TKey, TValue>(32, default(TKey), default(TValue));
        }

        #endregion

        #region Properties

        private IRandom Random;
        internal SkipListNode<TKey, TValue> Head { get; set; }

        /// <summary>
        /// Returns the number of items in the skip list
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Returns the maximum allowed level of a node. This number is based off of the Count of the skip list.
        /// </summary>
        public int MaxLevels
        {
            get
            {
                if (this.Count == 0)
                    return 1;
                else
                    return Math.Min((int)Math.Log(this.Count, 2) + 1, 32);
            }
        }

        /// <summary>
        /// Returns the height of node with the most levels within the skip list.
        /// </summary>
        public int Levels { get; set; }

        #endregion

        #region Insert

        private int RandomNumber()
        {
            return this.Random.Next();
        }

        /// <summary>
        /// Calculates a random level. Used when creating a new skip list node
        /// </summary>
        /// <returns>A random number between 1 and MaxLevel</returns>
        private int RandomLevel()
        {
            int level = 1;
            int maxLevels = this.MaxLevels;
            while (this.RandomNumber() % 2 == 0 && level < maxLevels)
                ++level;

            return level;
        }

        /// <summary>
        /// Creates a new SkipListNode with a level that is smaller than or equal to the MaxLevel of the skip list.
        /// </summary>
        private SkipListNode<TKey, TValue> CreateSkipListNode(TKey key, TValue value)
        {
            return new SkipListNode<TKey, TValue>(this.RandomLevel(), key, value);
        }

        /// <summary>
        /// Inserts a new key value pair into the skip list.
        /// </summary>
        public void Insert(TKey key, TValue value)
        {
            this.Insert(this.CreateSkipListNode(key, value));
        }

        /// <summary>
        /// Inserts the given node into the skip list.
        /// </summary>
        private void Insert(SkipListNode<TKey, TValue> node)
        {
            SkipListNode<TKey, TValue>[] previousNodes = new SkipListNode<TKey, TValue>[this.MaxLevels];
            SkipListNode<TKey, TValue> previous = this.Head;

            // find the insertion point, making use of the highest / most sparse levels first
            for (int level = this.Levels-1; level >= 0; --level)
            {
                while (previous.Next[level] != null && previous.Next[level].Key.CompareTo(node.Key) < 0)
                    previous = previous.Next[level];

                if (level <= node.Levels)
                    previousNodes[level] = previous;
            }

            // Increase the skip list's level if necessary
            while (this.Levels < node.Levels)
            {
                ++this.Levels;
                previousNodes[this.Levels-1] = this.Head;
            }

            // Update all of the levels in the skip list to point to the new node
            for (int curLevel = 0; curLevel < node.Levels; ++curLevel)
            {
                node.Next[curLevel] = previousNodes[curLevel].Next[curLevel];
                previousNodes[curLevel].Next[curLevel] = node;
            }

            ++this.Count;
        }

        #endregion

        #region Contains

        /// <summary>
        /// Returns true if the value has been found in the skip list.
        /// </summary>
        public bool ContainsKey(TKey key)
        {
            if (this.Find(key) != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Finds the node with the given value within the skip list.
        /// </summary>
        /// <returns>The node with the given value, or null if no node exists.</returns>
        private SkipListNode<TKey, TValue> Find(TKey key)
        {
            SkipListNode<TKey, TValue> current = this.Head;
            for (int level = this.Levels - 1; level >= 0; --level)
            {
                while (current.Next[level] != null && current.Next[level].Key.CompareTo(key) <= 0)
                    current = current.Next[level];
            }

            if (current != null && current.Key != null && current.Key.CompareTo(key) == 0)
                return current;
            else
                return null;
        }

        #endregion

        #region GetValue

        public TValue GetValue(TKey key)
        {
            SkipListNode<TKey, TValue> result = this.Find(key);

            if (result != null)
            {
                return result.Value;
            }
            else
            {
                throw new ValueNotFoundException();
            }
        }

        #endregion

        #region Delete

        /// <summary>
        /// Deletes the item with the given value from the skip list.
        /// </summary>
        /// <param name="key">The value to delete from the skip list</param>
        /// <returns>True if the value was deleted, false if it could not be found</returns>
        public bool Delete(TKey key)
        {
            bool deleted = false;
            SkipListNode<TKey, TValue>[] previousNodes = new SkipListNode<TKey, TValue>[this.Levels];
            SkipListNode<TKey, TValue> node = this.Head;

            for (int level = this.Levels - 1; level >= 0; --level)
            {
                while (node.Next[level] != null && node.Next[level].Key.CompareTo(key) < 0)
                    node = node.Next[level];

                if (node.Next[level] != null)
                    previousNodes[level] = node;
            }

            node = node.Next[0];

            if (node != null &&node.Key.CompareTo(key) == 0)
            {
                for (int level = 0; level < node.Levels; ++level)
                {
                    deleted = true;
                    SkipListNode<TKey, TValue> toDelete = previousNodes[level].Next[level];
                    previousNodes[level].Next[level] = toDelete.Next[level];
                    toDelete.Next[level] = null;
                }

                --this.Count;
            }

            return deleted;
        }

        #endregion

    }
}
