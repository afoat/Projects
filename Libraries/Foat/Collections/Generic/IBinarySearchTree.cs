namespace Foat.Collections.Generic
{
    using System;
    using System.Collections.Generic;

    public interface IBinarySearchTree<T> where T : IComparable<T>
    {
        /// <summary>
        /// The number of values in the tree
        /// </summary>
        int Count       { get; }

        /// <summary>
        /// The height of the tree
        /// </summary>
        int Height      { get; }

        /// <summary>
        /// The balance of the tree.  Balance = Root.Left.Height - Root.Right.Height
        /// </summary>
        int Balance     { get; }

        /// <summary>
        /// Iterates through the values in the tree using the in order algorithm. This will return the values from lowest to highest
        /// </summary>
        IEnumerable<T> InOrderIterator      { get; }

        /// <summary>
        /// Iterates through the values in the tree using the post order algorithm. Parent nodes will be visited after their childen
        /// </summary>
        IEnumerable<T> PostOrderIterator    { get; }

        /// <summary>
        /// Iterates through the values in the tree using the pre order algorithm. Parent nodes will be visited before their childen
        /// </summary>
        IEnumerable<T> PreOrderIterator     { get; }

        /// <summary>
        /// Inserts the value in to the correct position in the tree
        /// 
        /// Throws a ArgumentException if the value already exists in the tree
        /// </summary>
        /// <param name="value">The data to be inserted</param>
        void Insert(T value);

        /// <summary>
        /// Inserts the value in to the correct position in the tree if it doesn't already exist
        /// </summary>
        /// <param name="value">The data to be inserted</param>
        /// <returns>True if the item was inserted, False if it already exists</returns>
        bool InsertIfNotDuplicate(T value);

        /// <summary>
        /// Returns true if the binary search tree contains the given value
        /// </summary>
        /// <param name="value">The value of the item to search for</param>
        /// <returns>True if the binary search tree contains the given value, false otherwise</returns>
        bool Contains(T value);

        /// <summary>
        /// Finds the item with the given value and returns it
        /// </summary>
        /// <param name="value">The value of the item we want to find</param>
        /// <returns>The item that matches the given value, or default(T) if it can't be found</returns>
        T Find(T value);

        /// <summary>
        /// Removes the item with the specified value from the list
        /// </summary>
        /// <param name="value">The value of the item that should be removed</param>
        bool Delete(T value);

        /// <summary>
        /// Returns the depth of the item with the given value in the tree. The depth of the root is 0
        /// </summary>
        /// <param name="value">The value of the item whose depth you want</param>
        /// <returns>The depth of the item with the given value</returns>
        int Depth(T value);

        /// <summary>
        /// Verifies that the tree is valid and throws an exception if it isn't
        /// </summary>
        void AssertValidTree();
    }
}
