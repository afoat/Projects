﻿namespace Foat.Collections.Generic
{
    using System;
    using System.Collections.Generic;

    public sealed partial class RedBlackTree<T> : IBinarySearchTree<T> where T : IComparable<T>
    {
        #region Constructors

        public RedBlackTree()
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
        /// Throws a ValueNotFoundException if the node was not found
        /// </summary>
        /// <param name="root">The root of the tree to search</param>
        /// <param name="value">The value of the node whose depth should be returned</param>
        /// <returns></returns>
        private static int Depth(Node root, T value)
        {
            if (root == null)
                throw new ValueNotFoundException(Resources.Errors.DepthNodeNotFound);

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
        /// Inserts the given value into the tree and ensures that the tree is rebalanced according to the red-black tree rules
        /// 
        /// Throws a ArgumentException if the value already exists in the tree
        /// 
        /// O(log n)
        /// </summary>
        public void Insert(T value)
        {
            this.Root = this.Insert(this.Root, new Node(value));

            if (this.Root.NodeColour == Node.Colour.Red)
                this.Root.NodeColour = Node.Colour.Black;
        }

        /// <summary>
        /// Inserts the given value into the tree if it doesn't already exist and ensures that the tree is rebalanced
        /// according to the red-black tree rules
        /// </summary>
        /// <param name="value">The value we want to insert into the tree</param>
        /// <returns>True if the value was inserted, and false if it already exists in the tree</returns>
        public bool InsertIfNotDuplicate(T value)
        {
            bool success;
            Node newRoot = this.InsertIfNotDuplicate(this.Root, new Node(value), out success);
            if (success)
            {
                this.Root = newRoot;

                if (this.Root.NodeColour == Node.Colour.Red)
                    this.Root.NodeColour = Node.Colour.Black;
            }

            return success;
        }
        
        /// <summary>
        /// Inserts the given node underneath the given root according to the BinarySearchTree algorithm and then
        /// rebalances the tree according to the red-black tree rules
        /// </summary>
        /// <param name="root">The root node of the tree</param>
        /// <param name="node">The node to insert</param>
        /// <returns>The new root of the tree as it may have changed</returns>
        private Node Insert(Node root, Node node)
        {
            int compareResult;
            if (root == null)
            {
                root = node;
                ++this.Count;
            }
            else
            {
                root.ResetHeight();
                compareResult = root.Value.CompareTo(node.Value);
                if (compareResult > 0)
                    root.Left = Insert(root.Left, node);
                else if (compareResult < 0)
                    root.Right = Insert(root.Right, node);
                else
                    throw new ArgumentException(Resources.Errors.InsertDuplicate);
            }

            compareResult = root.Value.CompareTo(node.Value);
            if (compareResult > 0)
                root = Insert_Case1_LeftTwoRedChidren(root as Node);
            else if (compareResult < 0)
                root = Insert_Case1_RightTwoRedChidren(root as Node);

            return root;
        }

        /// <summary>
        /// Inserts the given node underneath the given root according to the BinarySearchTree algorithm and then
        /// rebalances the tree according to the red-black tree rules
        /// </summary>
        /// <param name="root">The root node of the tree</param>
        /// <param name="node">The node to insert</param>
        /// <returns>The new root of the tree as it may have changed</returns>
        private Node InsertIfNotDuplicate(Node root, Node node, out bool success)
        {
            int compareResult;
            if (root == null)
            {
                success = true;
                root = node;
                ++this.Count;
            }
            else
            {
                root.ResetHeight();
                compareResult = root.Value.CompareTo(node.Value);
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

            compareResult = root.Value.CompareTo(node.Value);
            if (compareResult > 0)
                root = Insert_Case1_LeftTwoRedChidren(root as Node);
            else if (compareResult < 0)
                root = Insert_Case1_RightTwoRedChidren(root as Node);

            return root;
        }

        /// <summary>
        /// Deals with the case where after inserting a node to the left, a node has two red children. If this case is not matched we move on to case 2
        /// </summary>
        private Node Insert_Case1_LeftTwoRedChidren(Node root)
        {
            if (IsNodeRed(root.Left) && (IsNodeRed(root.Left.Left) || IsNodeRed(root.Left.Right)))
            {
                if (IsNodeRed(root.Right))
                    MoveBlackDown(root);
                else
                {
                    root = Insert_Case2_TwoLeftReds(root);
                }
            }

            return root;
        }

        /// <summary>
        /// Deals with the case where after inserting a node to the right, a node has two red children. If this case is not matched we move on to case 2
        /// </summary>
        private Node Insert_Case1_RightTwoRedChidren(Node root)
        {
            if (IsNodeRed(root.Right) && (IsNodeRed(root.Right.Right) || IsNodeRed(root.Right.Left)))
            {
                if (IsNodeRed(root.Left))
                    MoveBlackDown(root);
                else
                {
                    root = Insert_Case2_TwoRightReds(root);
                }
            }

            return root;
        }

        /// <summary>
        /// Deals with the case where after an insert to the left we have two red nodes as left sub-children of each-other
        /// </summary>
        private Node Insert_Case2_TwoLeftReds(Node root)
        {
            if (IsNodeRed(root.Left.Left))
            {
                root = root.RotateRight();
            }
            else if (IsNodeRed(root.Left.Right))
            {
                root = Insert_Case3_LeftRightReds(root);
            }

            return root;
        }

        /// <summary>
        /// Deals with the case where after an insert to the right we have two red nodes as right sub-children of each-other
        /// </summary>
        private Node Insert_Case2_TwoRightReds(Node root)
        {
            if (IsNodeRed(root.Right.Right))
            {
                root = root.RotateLeft();
            }
            else if (IsNodeRed(root.Right.Left))
            {
                root = Insert_Case3_RightLeftReds(root);
            }

            return root;
        }

        /// <summary>
        /// Deals with the case where after inserting a node to the right we have a red node as a right sub-child of its parent and has another red node as a left subchild.
        /// </summary>
        private Node Insert_Case3_RightLeftReds(Node root)
        {
            root.Right = root.Right.RotateRight();
            root = root.RotateLeft();

            return root;
        }

        /// <summary>
        /// Deals with the case where after inserting a node to the left we have a red node as a left sub-child of its parent and has another red node as a right subchild.
        /// </summary>
        private Node Insert_Case3_LeftRightReds(Node root)
        {
            root.Left = root.Left.RotateLeft();
            root = root.RotateRight();

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
                if (this.Root == null)
                    result = false;
                else
                {
                    bool done = false;
                    this.Root = this.Delete(this.Root, value, ref done);

                    if (this.Root != null)
                        this.Root.NodeColour = Node.Colour.Black;
                }
            }
            catch (ValueNotFoundException)
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Deletes the given value from the tree at the given root and ensures red-black tree properties are maintained ny recolouring nodes and rotations
        /// </summary>
        /// <param name="root">The root node of the tree</param>
        /// <param name="value">The value to delete</param>
        /// <param name="done">A flag determining if more rebalancing and recolouring is necessary</param>
        /// <returns>The new root of the tree as it may have changed</returns>
        private Node Delete(Node root, T value, ref bool done)
        {
            int compareResult = root.Value.CompareTo(value);
            if (compareResult == 0)
            {
                // Node has two children, replace with in order predecessor and then recursively delete predecessor
                if (root.Left != null && root.Right != null)
                {
                    compareResult = 1;
                    root.Value = root.InOrderPredecessor.Value;
                    value = root.Value;
                    root.ResetHeight();
                }
                // Node only has left child
                else if (root.Left != null)
                {
                    --this.Count;
                    root.Left.ResetHeight();
                    if (IsNodeRed(root.Left)) // node to delete is black but has red child that can be recoloured
                    {
                        root.Left.NodeColour = Node.Colour.Black;
                        done = true;
                    }

                    root = root.Left;
                }
                // Node only has Right child
                else if (root.Right != null)
                {
                    --this.Count;
                    root.Right.ResetHeight();
                    if (IsNodeRed(root.Right)) // node to delete is black but has red child that can be recoloured
                    {
                        root.Right.NodeColour = Node.Colour.Black;
                        done = true;
                    }

                    root = root.Right;
                }
                else // deleting leaf - done if red
                {
                    --this.Count;
                    done = IsNodeRed(root);
                    root = null;
                }
            }

            if (compareResult > 0)
            {
                if (root.Left != null)
                {
                    root.Left = Delete(root.Left, value, ref done);
                    if (!done)
                        root = this.DeleteRebalanceLeft(root, ref done);
                }
                else
                    throw new ValueNotFoundException();
            }
            else if (compareResult < 0)
            {
                if (root.Right != null)
                {
                    root.Right = Delete(root.Right, value, ref done);
                    if (!done)
                        root = this.DeleteRebalanceRight(root, ref done);
                }
                else
                    throw new ValueNotFoundException();
            }

            return root;
        }

        /// <summary>
        /// Rebalances the root after a black node was deleted in the right sub-tree
        /// </summary>
        /// <param name="root"></param>
        /// <param name="done"></param>
        /// <returns></returns>
        private Node DeleteRebalanceRight(Node root, ref bool done)
        {
            Node parent = root;
            Node sibling = root.Left;

            // Rotation to reduce the red sibling case to the easier to handle black sibling case
            if (IsNodeRed(sibling))
            {
                root = root.RotateRight();
                sibling = parent.Left;
            }

            if (sibling != null)
            {
                if (!IsNodeRed(sibling.Left) && !IsNodeRed(sibling.Right))
                {
                    if (IsNodeRed(parent))
                        done = true;

                    parent.NodeColour = Node.Colour.Black;
                    sibling.NodeColour = Node.Colour.Red;
                }
                else
                {
                    Node.Colour colour = parent.NodeColour;
                    bool sameRoot = root == parent;

                    if (IsNodeRed(sibling.Left))
                        parent = parent.RotateRight();
                    else
                    {
                        parent.Left = parent.Left.RotateLeft();
                        parent = parent.RotateRight();
                    }

                    parent.NodeColour = colour;
                    parent.Left.NodeColour = Node.Colour.Black;
                    parent.Right.NodeColour = Node.Colour.Black;

                    if (sameRoot)
                        root = parent;
                    else
                        root.Right = parent;

                    done = true;
                }
            }

            return root;
        }

        private Node DeleteRebalanceLeft(Node root, ref bool done)
        {
            // Rotation to reduce the red sibling case to the easier to handle black sibling case
            Node parent = root;
            Node sibling = root.Right;

            if (IsNodeRed(sibling))
            {
                root = root.RotateLeft();
                sibling = parent.Right;
            }

            if (sibling != null)
            {
                if (!IsNodeRed(sibling.Left) && !IsNodeRed(sibling.Right))
                {
                    if (IsNodeRed(parent))
                    {
                        done = true;
                    }

                    parent.NodeColour = Node.Colour.Black;
                    sibling.NodeColour = Node.Colour.Red;
                }
                else
                {
                    Node.Colour colour = parent.NodeColour;
                    bool sameRoot = root == parent;

                    if (IsNodeRed(sibling.Right))
                        parent = parent.RotateLeft();
                    else
                    {
                        parent.Right = parent.Right.RotateRight();
                        parent = parent.RotateLeft();
                    }

                    parent.NodeColour = colour;
                    parent.Left.NodeColour = Node.Colour.Black;
                    parent.Right.NodeColour = Node.Colour.Black;

                    if (sameRoot)
                        root = parent;
                    else
                        root.Left = parent;

                    done = true;
                }
            }

            return root;
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
            Node node = this.FindNode(value);

            if (node == null)
                return default(T);
            else
                return node.Value;
        }

        /// <summary>
        /// Finds the node with the given value and returns it. Returns null if it isnt found
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private Node FindNode(T item)
        {
            Node current = this.Root;
            while (current != null)
            {
                int compareResult = current.Value.CompareTo(item);
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

        #region Helper Methods

        /// <summary>
        /// Returns true if the node is red. Returns false if the node is black or null.
        /// </summary>
        private static bool IsNodeRed(Node node)
        {
            return (node != null && node.NodeColour == Node.Colour.Red);
        }

        /// <summary>
        /// Moves a black root node down to it's two children and colours the root red
        /// </summary>
        /// <param name="root"></param>
        private static void MoveBlackDown(Node root)
        {
            root.NodeColour = Node.Colour.Red;
            root.Left.NodeColour = Node.Colour.Black;
            root.Right.NodeColour = Node.Colour.Black;
        }

        private static void AssertValidTree(Node root, out int numBlack)
        {
            if (root == null)
            {
                numBlack = 0;
            }
            else
            {
                if (IsNodeRed(root))
                {
                    if (IsNodeRed(root.Left) || IsNodeRed(root.Right))
                        throw new InvalidTreeException();
                }

                int leftBlack;
                int rightBlack;

                AssertValidTree(root.Left, out leftBlack);
                AssertValidTree(root.Right, out rightBlack);

                if (leftBlack != rightBlack)
                    throw new InvalidTreeException();

                if (IsNodeRed(root))
                    numBlack = leftBlack;
                else
                    numBlack = leftBlack + 1;
            }
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

                    previousNode = node;
                }
            }

            int numBlack;

            AssertValidTree(this.Root as Node, out  numBlack);
        }

        #endregion
    }
}
