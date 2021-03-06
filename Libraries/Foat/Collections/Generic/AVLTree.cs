﻿namespace Foat.Collections.Generic
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A balanced binary tree in which the balance of the root node is always >= -1 and <= 1 ensuring that insert delete and find operations happen in exactly log n time
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed partial class AVLTree<T> : IBinarySearchTree<T> where T : IComparable<T>
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of an AVLTree
        /// </summary>
        public AVLTree()
        {
            this.Root = null;
            this.Count = 0;
        }

        #endregion

        #region Properties

        internal Node Root { get; set; }

        /// <summary>
        /// Returns the number of values in the tree
        /// </summary>
        public int Count { get; internal set; }

        /// <summary>
        /// The height of the tree. Returns -1 for an empty tree.
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
        /// Returns the balance of the tree defined as Balance = LeftTree.Height - Right.Height
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
        /// Finds the depth of the item with the given value.
        /// 
        /// Throws a TreeNotRootedException if the tree is empty
        /// Throws a ValueNotFoundException if the node was not found
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Depth(T value)
        {
            return Depth(this.Root, value);
        }

        /// <summary>
        /// Finds the depth of the item with the given value underneath the given root
        /// 
        /// Throws a ValueNotFoundException if the value was not found
        /// </summary>
        /// <param name="root">The root of the tree to search</param>
        /// <param name="value">The value of the item whose depth should be returned</param>
        /// <returns></returns>
        private static int Depth(Node root, T value)
        {
            if (root == null)
                throw new ValueNotFoundException(Resources.Errors.DeleteNodeNotFound);

            int compareResult = root.Value.CompareTo(value);
            int result;

            if (compareResult > 0)
                result = Depth(root.Left, value) + 1;
            else if (compareResult < 0)
                result = Depth(root.Right, value) + 1;
            else
                result = 0;

            return result;
        }

        #endregion

        #region Insert

        /// <summary>
        /// Inserts the given value into the tree.
        /// 
        /// Throws a ArgumentException if the value already exists in the tree
        /// 
        /// O(log n)
        /// </summary>
        /// <param name="value">The value of the item to insert</param>
        public void Insert(T value)
        {
            this.Root = this.Insert(this.Root, new Node(value));
        }

        /// <summary>
        /// Inserts the given value into the tree if it doesn't already exist
        /// </summary>
        /// <param name="value">The value of the item to insert</param>
        /// <returns>True if the item was successfully inserted, false if it already exists in the tree</returns>
        public bool InsertIfNotDuplicate(T value)
        {
            bool success;
            Node newRoot = this.InsertIfNotDuplicate(this.Root, new Node(value), out success);
            if (success)
            {
                this.Root = newRoot;
            }

            return success;
        }

        /// <summary>
        /// Inserts an node with the given value underneath the given root according to the BinarySearchTree
        /// algorithm and then rebalances the tree.
        /// </summary>
        /// <param name="root">The root node of the tree</param>
        /// <param name="node">The node to insert</param>
        /// <returns>The new root of the tree as it may have changed</returns>
        private Node Insert(Node root, Node node)
        {
            if (root == null)
            {
                root = node;
                ++this.Count;
            }
            else
            {
                root.ResetHeight();
                int compareResult = root.Value.CompareTo(node.Value);
                if (compareResult > 0)
                    root.Left = Insert(root.Left, node);
                else if (compareResult < 0)
                    root.Right = Insert(root.Right, node);
                else
                    throw new ArgumentException(Resources.Errors.InsertDuplicate);
            }

            root = RebalanceNode(root);

            return root;
        }

        /// <summary>
        /// Inserts an node with the given value underneath the given root according to the BinarySearchTree
        /// algorithm if it doesn't already exist and then rebalances the tree.
        /// </summary>
        /// <param name="root">The root node of the tree</param>
        /// <param name="node">The node to insert</param>
        /// <param name="success">Out parameter. True if the value was inserted, false if it already existed.</param>
        /// <returns>The new root of the tree as it may have changed</returns>
        private Node InsertIfNotDuplicate(Node root, Node node, out bool success)
        {
            if (root == null)
            {
                success = true;
                root = node;
                ++this.Count;
            }
            else
            {
                root.ResetHeight();
                int compareResult = root.Value.CompareTo(node.Value);
                if (compareResult > 0)
                {
                    success = true;
                    root.Left = InsertIfNotDuplicate(root.Left, node, out success);
                }
                else if (compareResult < 0)
                {
                    success = true;
                    root.Right = InsertIfNotDuplicate(root.Right, node, out success);
                }
                else
                    success = false;
            }

            if (success)
                root = RebalanceNode(root);

            return root;
        }

        #endregion

        #region Delete

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
            try
            {
                if (this.Root != null)
                    this.Root = Delete(this.Root, value);
                else
                    result = false;
            }
            catch (ValueNotFoundException)
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Deletes the given value from the tree at the given root according to the BinarySearchTree algorithm and then
        /// rebalances the tree.
        /// </summary>
        /// <param name="root">The root node of the tree</param>
        /// <param name="value">The value to delete</param>
        /// <returns>The new root of the tree as it may have changed</returns>
        private Node Delete(Node root, T value)
        {
            int compareResults = root.Value.CompareTo(value);
            if (compareResults > 0)
            {

                if (root.Left != null)
                {
                    root.ResetHeight();
                    root.Left = Delete(root.Left, value);
                }
                else
                    throw new ValueNotFoundException();
            }
            else if (compareResults < 0)
            {
                if (root.Right != null)
                {
                    root.ResetHeight();
                    root.Right = Delete(root.Right, value);
                }
                else
                    throw new ValueNotFoundException();
            }
            else
            {
                if (root.Left == null && root.Right == null)
                {
                    --this.Count;
                    root = null;
                }
                else if (root.Right == null)
                {
                    --this.Count;
                    root.Value = root.Left.Value;
                    root.Right = root.Left.Right;
                    root.Left = root.Left.Left;
                    root.ResetHeight();
                }
                else if (root.Left == null)
                {
                    --this.Count;
                    root.Value = root.Right.Value;
                    root.Left = root.Right.Left;
                    root.Right = root.Right.Right;
                    root.ResetHeight();
                }
                else
                {
                    Node predecessor = root.InOrderPredecessor;
                    root.Value = predecessor.Value;
                    root.Left = Delete(root.Left, predecessor.Value);
                    root.ResetHeight();
                }
            }

            if (root != null)
                root = RebalanceNode(root);

            return root;
        }

        #endregion Delete

        #region Find

        /// <summary>
        /// Finds the item with the given value and returns it
        /// </summary>
        /// <param name="value">The value of the item we want to find</param>
        /// <returns>The item that matches the given value, or default(T) if it can't be found</returns>
        public T Find(T value)
        {

            Node node = this.FindNode(value);

            if (node == null)
                return default(T);
            else
                return node.Value;
        }

        /// <summary>
        /// Finds the node with the given value and returns it.
        /// </summary>
        /// <param name="value">The value of the node we want to find</param>
        /// <returns>The AVLNode that coressponds to the given value, or NULL if the value cannot be found</returns>
        private Node FindNode(T value)
        {
            Node current = this.Root;
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

        #region Rebalancing

        /// <summary>
        /// Rebalances a node if necessary
        /// </summary>
        /// <param name="node">The node to rebalance</param>
        /// <returns>True if a rebalancing was performed</returns>
        private static Node RebalanceNode(Node node)
        {
            // if left tree taller
            if (node.Balance > 1)
                return RebalanceLeftSubTree(node);

            // else if right tree taller
            else if (node.Balance < -1)
                return RebalanceRightSubTree(node);

            return node;
        }

        /// <summary>
        /// Performs the rotations necessary to balance a parent
        /// </summary>
        /// <param name="parent">The parent node to rebalance</param>
        private static Node RebalanceRightSubTree(Node parent)
        {
            // Converts a Root -> Right -> Left sub tree
            // Into a Root -> Right -> Right sub tree maintaining order
            // So that we can do the standard rotate
            if (parent.Right.Balance > 0)
                parent.Right = parent.Right.RotateRight();

            return parent.RotateLeft();
        }

        /// <summary>
        /// Performs the rotations necessary to balance a parent
        /// </summary>
        /// <param name="parent">The parent node to rebalance</param>
        private static Node RebalanceLeftSubTree(Node parent)
        {
            // Converts a Root -> Left -> Right sub tree
            // Into a Root -> Left -> Left sub tree maintaining order
            // So that we can do the standard rotate
            if (parent.Left.Balance < 0)
                parent.Left = parent.Left.RotateLeft();

            return parent.RotateRight();
        }

        #endregion

        #region Node Iterators

        private IEnumerable<Node> InOrderNodeIterator
        {
            get
            {
                Node current = this.Root;
                Stack<Node> parentStack = new Stack<Node>();

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
                        yield return current;
                        current = current.Right;
                    }
                }
            }
        }

        private IEnumerable<Node> PostOrderNodeIterator
        {
            get
            {
                Node current;
                Node previous = null;
                Stack<Node> nodeStack = new Stack<Node>();

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
                        yield return current;
                        nodeStack.Pop();
                    }

                    previous = current;
                }
            }
        }

        private IEnumerable<Node> PreOrderNodeIterator
        {
            get
            {
                Stack<Node> parentStack = new Stack<Node>();

                Node current = this.Root;

                while (parentStack.Count > 0 || current != null)
                {
                    if (current != null)
                    {
                        yield return current;

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

        #region Value Iterators

        /// <summary>
        /// Iterates through the tree in order. Visiting the left sub-tree, then the root, then the right sub-tree so that the values are returned in order.
        /// </summary>
        public IEnumerable<T> InOrderIterator
        {
            get
            {
                foreach (Node node in this.InOrderNodeIterator)
                    yield return node.Value;
            }
        }

        /// <summary>
        /// Iterates through the tree in post order. Visiting the left sub-tree, then the right sub-tree, then the root. This is useful if you need to dispose of the entire tree as items will be disposed from the bottom up
        /// </summary>
        public IEnumerable<T> PostOrderIterator
        {
            get
            {
                foreach (Node node in this.PostOrderNodeIterator)
                    yield return node.Value;
            }
        }

        /// <summary>
        /// Iterates through the tree in pre order. Visiting the root, then the left sub-tree, then the right sub-tree. This is useful for algorithms such as the iterative height calculation as it starts at the top and works its way down through the levels
        /// </summary>
        public IEnumerable<T> PreOrderIterator
        {
            get
            {
                foreach (Node node in this.PreOrderNodeIterator)
                    yield return node.Value;
            }
        }

        #endregion

        #region Public Methods

        public void AssertValidTree()
        {
            if (this.Root != null)
            {
                Node previousNode = null;
                foreach (Node node in this.InOrderNodeIterator)
                {
                    if (previousNode != null && previousNode.Value.CompareTo(node.Value) >= 0)
                        throw new InvalidTreeException();

                    node.ResetHeight();
                    if (node.Balance < -1 || node.Balance > 1)
                        throw new InvalidTreeException();

                    previousNode = node;
                }
            }
        }

        #endregion
    }
}
