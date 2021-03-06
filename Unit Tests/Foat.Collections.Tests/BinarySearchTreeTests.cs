﻿namespace Foat.Collections.Tests
{
    using Foat.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Diagnostics.CodeAnalysis;

    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BinarySearchTreeTests : IBinarySearchTreeTests<BinarySearchTree<int>>
    {
        protected override IBinarySearchTree<int> InitEmptyTree()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Count = 0;
            return tree;
        }

        protected override IBinarySearchTree<int> InitFiveNodesLeftFull()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Root = new BinarySearchTree<int>.Node(50);
            tree.Root.Right = new BinarySearchTree<int>.Node(75);
            tree.Root.Left = new BinarySearchTree<int>.Node(25);
            tree.Root.Left.Left = new BinarySearchTree<int>.Node(12);
            tree.Root.Left.Right = new BinarySearchTree<int>.Node(32);
            tree.Count = 5;

            return tree;
        }

        protected override IBinarySearchTree<int> InitFourNodesLeftLeft()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Root = new BinarySearchTree<int>.Node(50);
            tree.Root.Right = new BinarySearchTree<int>.Node(75);
            tree.Root.Left = new BinarySearchTree<int>.Node(25);
            tree.Root.Left.Left = new BinarySearchTree<int>.Node(12);
            tree.Count = 4;

            return tree;
        }

        protected override IBinarySearchTree<int> InitFourNodesLeftRight()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Root = new BinarySearchTree<int>.Node(50);
            tree.Root.Right = new BinarySearchTree<int>.Node(75);
            tree.Root.Left = new BinarySearchTree<int>.Node(25);
            tree.Root.Left.Right = new BinarySearchTree<int>.Node(32);
            tree.Count = 4;

            return tree;
        }

        protected override IBinarySearchTree<int> InitFourNodesRightLeft()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Root = new BinarySearchTree<int>.Node(50);
            tree.Root.Left = new BinarySearchTree<int>.Node(25);
            tree.Root.Right = new BinarySearchTree<int>.Node(75);
            tree.Root.Right.Left = new BinarySearchTree<int>.Node(63);
            tree.Count = 4;

            return tree;
        }

        protected override IBinarySearchTree<int> InitFourNodesRightRight()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Root = new BinarySearchTree<int>.Node(50);
            tree.Root.Left = new BinarySearchTree<int>.Node(25);
            tree.Root.Right = new BinarySearchTree<int>.Node(75);
            tree.Root.Right.Right = new BinarySearchTree<int>.Node(100);
            tree.Count = 4;

            return tree;
        }

        protected override IBinarySearchTree<int> InitRootLeft()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Root = new BinarySearchTree<int>.Node(50);
            tree.Root.Left = new BinarySearchTree<int>.Node(25);
            tree.Count = 2;

            return tree;
        }

        protected override IBinarySearchTree<int> InitRootOnly()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Root = new BinarySearchTree<int>.Node(50);
            tree.Count = 1;

            return tree;
        }

        protected override IBinarySearchTree<int> InitRootRight()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Root = new BinarySearchTree<int>.Node(50);
            tree.Root.Right = new BinarySearchTree<int>.Node(75);
            tree.Count = 2;

            return tree;
        }

        protected override IBinarySearchTree<int> InitThreeNodesFull()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Root = new BinarySearchTree<int>.Node(50);
            tree.Root.Left = new BinarySearchTree<int>.Node(25);
            tree.Root.Right = new BinarySearchTree<int>.Node(75);
            tree.Count = 3;

            return tree;
        }

        protected override IBinarySearchTree<int> InitBadTree()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Root = new BinarySearchTree<int>.Node(50);
            tree.Root.Left = new BinarySearchTree<int>.Node(75);
            tree.Root.Right = new BinarySearchTree<int>.Node(25);
            tree.Count = 3;

            return tree;
        }
    }
}
