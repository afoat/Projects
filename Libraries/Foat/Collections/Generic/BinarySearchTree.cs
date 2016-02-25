namespace Foat.Collections.Generic
{
    using System;
    using System.Collections.Generic;
    using Foat.Collections.Resources;

    /// <summary>
    /// This is an unbalanced binary search implemented using iterative algorithms so as to never encounter a stack overflow.
    /// </summary>
    /// <typeparam name="T">The type that will be stored in the nodes of the tree</typeparam>
    public sealed partial class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable<T>
    {
        /// <summary>
        /// Creates a new instance of a Foat.Collections.Generic.BinarySearchTree<T>
        /// </summary>
        public BinarySearchTree()
        {
            this.Root = null;
            this.Count = 0;
        }

        #region Properties

        /// <summary>
        /// The root of the tree
        /// </summary>
        internal BinarySearchTreeNode<T> Root { get; set; }

        /// <summary>
        /// The number of values stored in this tree
        /// </summary>
        public int Count { get; internal set; }

        /// <summary>
        /// The height of the tree.The height of a tree that has a leaf for a root is 0. The height of an empty tree is -1
        /// 
        /// O(n)
        /// </summary>
        public int Height
        {
            get
            {
                if (this.Root == null)
                    return -1;
                else
                    return this.Root.Height;
            }
        }

        /// <summary>
        /// Balance = Root.Left.Height - Root.Right.Height
        /// 
        /// O(n)
        /// </summary>
        public int Balance
        {
            get
            {
                if (this.Root == null)
                    return 0;
                else
                    return this.Root.Balance;
            }
        }

        #endregion

        #region Depth

        /// <summary>
        /// Returns the length of the path from the root to the node
        /// 
        /// O(log n)
        /// </summary>
        /// <param name="value">The value of the node whose depth we want to find</param>
        /// <returns>The node's depth</returns>
        public int Depth(T value)
        {
            BinarySearchTreeNode<T> current = this.Root;
            int depth = 0;

            while (current != null)
            {
                int compareValue = current.Value.CompareTo(value);
                if (compareValue == 0)
                {
                    break;
                }
                else if (compareValue > 0)
                {
                    current = current.Left;
                }
                else
                    current = current.Right;

                ++depth;
            }

            if (current != null)
                return depth;
            else
                throw new ValueNotFoundException(Errors.DepthNodeNotFound);
        }

        #endregion

        #region Insert

        /// <summary>
        /// Inserts the node in to the tree in order. Throws a ArgumentException if this value already exists in the tree
        /// </summary>
        /// <param name="node">The node to insert</param>
        private void Insert(BinarySearchTreeNode<T> node)
        {
            if (this.Root == null)
            {
                this.Root = node;
            }
            else
            {
                BinarySearchTreeNode<T> current = this.Root;
                while (true)
                {
                    int compareResult = current.Value.CompareTo(node.Value);
                    if (compareResult == 0)
                    {
                        throw new ArgumentException(Errors.InsertDuplicate);
                    }
                    //value is smaller than current.Value
                    else if (compareResult > 0)
                    {
                        if (current.Left != null)
                        {
                            current = current.Left;
                        }
                        else //found leaf - insert here
                        {
                            current.Left = node;
                            break;
                        }
                    }
                    //value is larger than current.Value
                    else
                    {
                        if (current.Right != null)
                        {
                            current = current.Right;
                        }
                        else // found leaf - insert here
                        {
                            current.Right = node;
                            break;
                        }
                    }
                }
            }

            ++this.Count;
        }

        /// <summary>
        /// Inserts the node in to the tree in order if it doesn't already exist
        /// </summary>
        /// <param name="node">The node we want to insert</param>
        /// <returns>True if the node was inserted, false if it already existed</returns>
        internal bool InsertIfNotDuplicate(BinarySearchTreeNode<T> node)
        {
            if (this.Root == null)
            {
                this.Root = node;
            }
            else
            {
                BinarySearchTreeNode<T> current = this.Root;
                while (true)
                {
                    int compareResult = current.Value.CompareTo(node.Value);
                    if (compareResult == 0)
                    {
                        return false;
                    }
                    //value is smaller than current.Value
                    else if (compareResult > 0)
                    {
                        if (current.Left != null)
                        {
                            current = current.Left;
                        }
                        else //found leaf - insert here
                        {
                            current.Left = node;
                            break;
                        }
                    }
                    //value is larger than current.Value
                    else
                    {
                        if (current.Right != null)
                        {
                            current = current.Right;
                        }
                        else // found leaf - insert here
                        {
                            current.Right = node;
                            break;
                        }
                    }
                }
            }

            ++this.Count;
            return true;
        }

        /// <summary>
        /// Inserts the value into the correct spot in the tree. Throws a ArgumentException if the value already exists in the tree
        /// </summary>
        /// <param name="node">The value to insert</param>
        public void Insert(T value)
        {
            var node = new BinarySearchTreeNode<T>(value);
            this.Insert(node);
        }

        /// <summary>
        /// Inserts the value into the correct spot in the tree if it doesn't already exist
        /// </summary>
        /// <param name="value">The value to insert</param>
        /// <returns>True if the value was inserted, false if it already existed</returns>
        public bool InsertIfNotDuplicate(T value)
        {
            var node = new BinarySearchTreeNode<T>(value);
            return this.InsertIfNotDuplicate(node);
        }

        #endregion

        #region Delete

        /// <summary>
        /// Deletes the node that is passed in
        /// </summary>
        /// <param name="node">The node to delete</param>
        /// <param name="parentNode">the parent of the node we are deleting</param>
        internal void DeleteNode(BinarySearchTreeNode<T> node, BinarySearchTreeNode<T> parentNode)
        {
            if (this.Root.Value.CompareTo(node.Value) == 0)
            {
                if (this.Root.IsLeaf)
                {
                    this.Root = null;
                    --this.Count;
                }
                else if (this.Root.Left == null)
                {
                    this.Root = this.Root.Right;
                    --this.Count;
                }
                else if (this.Root.Right == null)
                {
                    this.Root = this.Root.Left;
                    --this.Count;
                }
                else
                {
                    BinarySearchTreeNode<T> swapNode = this.Root.InOrderPredecessor;

                    T tempValue = swapNode.Value;
                    this.Delete(swapNode.Value);
                    this.Root.Value = tempValue;
                }
            }
            else if (node.IsLeaf)
            {
                if (parentNode != null)
                {
                    if (node.Value.CompareTo(parentNode.Value) < 0)
                        parentNode.Left = null;
                    else
                        parentNode.Right = null;
                }

                --this.Count;
            }
            else if (node.Right == null)
            {
                if (parentNode != null)
                {
                    if (node.Value.CompareTo(parentNode.Value) < 0)
                        parentNode.Left = node.Left;
                    else
                        parentNode.Right = node.Left;
                }

                --this.Count;
            }
            else if (node.Left == null)
            {
                if (parentNode != null)
                {
                    if (node.Value.CompareTo(parentNode.Value) < 0)
                        parentNode.Left = node.Right;
                    else
                        parentNode.Right = node.Right;
                }

                --this.Count;
            }
            else // if both children not null
            {
                BinarySearchTreeNode<T> swapNode = node.InOrderPredecessor;

                T tempValue = swapNode.Value;
                this.Delete(swapNode.Value);
                node.Value = tempValue;
            }
        }

        /// <summary>
        /// Deletes the item with the given value from the tree.
        /// 
        /// O(log n)
        /// </summary>
        /// <param name="value">The value to delete from the tree</param>
        /// <returns>True if the value was deleted, false if it could not be found</returns>
        public bool Delete(T value)
        {
            bool result = true;

            BinarySearchTreeNode<T> previous = null;
            BinarySearchTreeNode<T> current = this.Root;

            while (current != null)
            {
                int compareResult = current.Value.CompareTo(value);
                if (compareResult == 0)
                    break;
                else if (compareResult > 0)
                {
                    previous = current;
                    current = current.Left;
                }
                else
                {
                    previous = current;
                    current = current.Right;
                }
            }

            if (current == null)
                result = false;
            else
                this.DeleteNode(current, previous);

            return result;
        }

        #endregion

        #region Find

        /// <summary>
        /// Finds the item with the given value and returns it
        /// </summary>
        /// <param name="value">The value of the item we want to find</param>
        /// <returns>The item that matches the given value, or default(T) if it can't be found</returns>
        public T Find(T value)
        {
            BinarySearchTreeNode<T> node = this.FindNode(value);

            if (node == null)
                return default(T);
            else
                return node.Value;
        }

        /// <summary>
        /// Finds the node matching the given value
        /// </summary>
        /// <param name="value">The value of the node we are looking for</param>
        /// <returns>The node matching the value we were looking for</returns>
        private BinarySearchTreeNode<T> FindNode(T value)
        {
            BinarySearchTreeNode<T> current = this.Root;
            while (current != null)
            {
                int compareResult = current.Value.CompareTo(value);
                if (compareResult == 0)
                    break;
                else if (compareResult > 0)
                    current = current.Left;
                else
                    current = current.Right;
            }

            return current;
        }

        #endregion

        #region Iterators

        /// <summary>
        /// Iterates through the tree using the in order traversal algorithm
        /// 
        /// O(n)
        /// </summary>
        public IEnumerable<T> InOrderIterator
        {
            get
            {
                BinarySearchTreeNode<T> current = this.Root;
                Stack<BinarySearchTreeNode<T>> parentStack = new Stack<BinarySearchTreeNode<T>>();

                while (current != null || parentStack.Count != 0)
                {
                    if (current != null)
                    {
                        parentStack.Push(current);
                        current = current.Left;
                    }
                    else
                    {
                        current = parentStack.Pop();
                        yield return current.Value;
                        current = current.Right;
                    }
                }
            }
        }

        /// <summary>
        /// Iterates through the tree using the in post order traversal algorithm
        /// 
        /// O(n)
        /// </summary>
        public IEnumerable<T> PostOrderIterator
        {
            get
            {
                BinarySearchTreeNode<T> current;
                BinarySearchTreeNode<T> previous = null;
                Stack<BinarySearchTreeNode<T>> nodeStack = new Stack<BinarySearchTreeNode<T>>();

                if (this.Root != null)
                    nodeStack.Push(this.Root);

                while (nodeStack.Count > 0)
                {
                    current = nodeStack.Peek();
                    if (previous == null || previous.Left == current || previous.Right == current)
                    {
                        if (current.Left != null)
                        {
                            nodeStack.Push(current.Left);
                        }
                        else if (current.Right != null)
                        {
                            nodeStack.Push(current.Right);
                        }
                    }
                    else if (current.Left == previous)
                    {
                        if (current.Right != null)
                                nodeStack.Push(current.Right);
                    }
                    else
                    {
                        yield return current.Value;
                        nodeStack.Pop();
                    }

                    previous = current;
                }
            }
        }

        /// <summary>
        /// Iterates through the tree using the in pre order traversal algorithm
        /// 
        /// O(n)
        /// </summary>
        public IEnumerable<T> PreOrderIterator
        {
            get
            {
                Stack<BinarySearchTreeNode<T>> parentStack = new Stack<BinarySearchTreeNode<T>>();

                BinarySearchTreeNode<T> current = this.Root;

                while (parentStack.Count > 0 || current != null)
                {
                    if (current != null)
                    {
                        yield return current.Value;

                        parentStack.Push(current.Right);
                        current = current.Left;
                    }
                    else
                    {
                        current = parentStack.Pop();
                    }
                }
            }
        }

        #endregion

        public void AssertValidTree()
        {
            if (this.Root != null)
            {
                bool first = true;
                T previousValue = default(T);
                foreach (T value in this.InOrderIterator)
                {
                    if (!first && previousValue.CompareTo(value) >= 0)
                        throw new InvalidTreeException();

                    previousValue = value;
                    first = false;
                }
            }
        }
    }
}
