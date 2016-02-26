namespace Foat.Collections.Generic
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    public sealed partial class BinarySearchTree<T> where T : IComparable<T>
    {
        internal sealed class Node
        {
            /// <summary>
            /// Creates a new instance of a Foat.Collections.Generic.AVLNode<T>
            /// </summary>
            /// <param name="value">The data value that this node will contain</param>
            internal Node(T value)
            {
                this.Value = value;
            }

            #region Properties

            internal T Value { get; set; }

            internal Node Left { get; set; }
            internal Node Right { get; set; }


            /// <summary>
            /// Returns true if this node has no neighbours
            /// </summary>
            internal bool IsLeaf
            {
                get
                {
                    return (this.Left == null && this.Right == null);
                }
            }

            /// <summary>
            /// The height of the node.
            /// 
            /// O(log n)
            /// </summary>
            internal int Height
            {
                get
                {
                    Queue<Node> nodes = new Queue<Node>();
                    nodes.Enqueue(this);

                    int height = -1;
                    int nodesAtCurrentLevel;

                    Node current;
                    while (nodes.Count > 0)
                    {
                        nodesAtCurrentLevel = nodes.Count;
                        for (int i = 0; i < nodesAtCurrentLevel; ++i)
                        {
                            if (i == 0)
                                ++height;

                            current = nodes.Dequeue();

                            if (current.Left != null)
                                nodes.Enqueue(current.Left);

                            if (current.Right != null)
                                nodes.Enqueue(current.Right);
                        }
                    }

                    return height;
                }
            }

            /// <summary>
            /// The balance of the node. Node.Balance = Node.Left.Height - Node.Right.Height
            /// 
            /// O(log n) when one or more heights below this one aren't cached
            /// O(1) otherwise
            /// </summary>
            internal int Balance
            {
                get
                {
                    int balance;
                    if (this.IsLeaf)
                        balance = 0;
                    else if (this.Right == null)
                        balance = this.Left.Height + 1;
                    else if (this.Left == null)
                        balance = -1 - this.Right.Height;
                    else
                        balance = this.Left.Height - this.Right.Height;
                    return balance;
                }
            }

            internal Node InOrderPredecessor
            {
                get
                {
                    Node previous = null;
                    Node current = this.Left;
                    while (current != null)
                    {
                        previous = current;
                        current = current.Right;
                    }

                    return previous;
                }
            }

            #endregion

            #region Methods

            [ExcludeFromCodeCoverage]
            public override string ToString()
            {
                string format = "{0}; Left={1}; Right={2}";

                string left;
                if (this.Left == null)
                    left = "null";
                else
                    left = this.Left.Value.ToString();

                string right;
                if (this.Right == null)
                    right = "null";
                else
                    right = this.Right.Value.ToString();

                return string.Format(format, this.Value.ToString(), left, right);
            }

            #endregion
        }
    }
}