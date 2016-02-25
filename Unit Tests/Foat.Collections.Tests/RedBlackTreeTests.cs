namespace Foat.Collections.Tests
{
    using Foat.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class RedBlackTreeTests : IBinarySearchTreeTests<RedBlackTree<int>>
    {
        #region Setup

        protected override IBinarySearchTree<int> InitEmptyTree()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Count = 0;
            return tree;
        }

        protected override IBinarySearchTree<int> InitFiveNodesLeftFull()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();

            tree.Root = new RedBlackNode<int>(50) { IsRed = false };
            tree.Root.Right = new RedBlackNode<int>(75) { IsRed = false };
            tree.Root.Left = new RedBlackNode<int>(25) { IsRed = false };
            tree.Root.Left.Left = new RedBlackNode<int>(12) { IsRed = true };
            tree.Root.Left.Right = new RedBlackNode<int>(32) { IsRed = true };
            tree.Count = 5;

            return tree;
        }

        protected override IBinarySearchTree<int> InitFourNodesLeftLeft()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Root = new RedBlackNode<int>(50) { IsRed = false };
            tree.Root.Right = new RedBlackNode<int>(75) { IsRed = false };
            tree.Root.Left = new RedBlackNode<int>(25) { IsRed = false };
            tree.Root.Left.Left = new RedBlackNode<int>(12) { IsRed = true };
            tree.Count = 4;

            return tree;
        }

        protected override IBinarySearchTree<int> InitFourNodesLeftRight()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Root = new RedBlackNode<int>(50) { IsRed = false };
            tree.Root.Right = new RedBlackNode<int>(75) { IsRed = false };
            tree.Root.Left = new RedBlackNode<int>(25) { IsRed = false };
            tree.Root.Left.Right = new RedBlackNode<int>(32) { IsRed = true };
            tree.Count = 4;

            return tree;
        }

        protected override IBinarySearchTree<int> InitFourNodesRightLeft()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Root = new RedBlackNode<int>(50) { IsRed = false };
            tree.Root.Left = new RedBlackNode<int>(25) { IsRed = false };
            tree.Root.Right = new RedBlackNode<int>(75) { IsRed = false };
            tree.Root.Right.Left = new RedBlackNode<int>(63) { IsRed = true };
            tree.Count = 4;

            return tree;
        }

        protected override IBinarySearchTree<int> InitFourNodesRightRight()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Root = new RedBlackNode<int>(50) { IsRed = false };
            tree.Root.Left = new RedBlackNode<int>(25) { IsRed = false };
            tree.Root.Right = new RedBlackNode<int>(75) { IsRed = false };
            tree.Root.Right.Right = new RedBlackNode<int>(100) { IsRed = true };
            tree.Count = 4;

            return tree;
        }

        protected override IBinarySearchTree<int> InitRootLeft()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Root = new RedBlackNode<int>(50) { IsRed = false };
            tree.Root.Left = new RedBlackNode<int>(25) { IsRed = true };
            tree.Count = 2;

            return tree;
        }

        protected override IBinarySearchTree<int> InitRootOnly()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Root = new RedBlackNode<int>(50) { IsRed = false };
            tree.Count = 1;

            return tree;
        }

        protected override IBinarySearchTree<int> InitRootRight()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Root = new RedBlackNode<int>(50) { IsRed = false };
            tree.Root.Right = new RedBlackNode<int>(75) { IsRed = true };
            tree.Count = 2;

            return tree;
        }

        protected override IBinarySearchTree<int> InitThreeNodesFull()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Root = new RedBlackNode<int>(50) { IsRed = false };
            tree.Root.Left = new RedBlackNode<int>(25) { IsRed = true };
            tree.Root.Right = new RedBlackNode<int>(75) { IsRed = true };
            tree.Count = 3;

            return tree;
        }

        protected override IBinarySearchTree<int> InitBadTree()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Root = new RedBlackNode<int>(50) { IsRed = false };
            tree.Root.Left = new RedBlackNode<int>(75) { IsRed = true };
            tree.Root.Right = new RedBlackNode<int>(25) { IsRed = true };
            tree.Count = 3;

            return tree;
        }

        #endregion

        #region Expected Values

        protected override int GetExpected_Insert_ThirdNode_IntoRootLeft_AtRootLeftLeft_CheckBalance()
        {
            return 0;
        }

        protected override int GetExpected_Insert_ThirdNode_IntoRootLeft_AtRootLeftLeft_CheckHeight()
        {
            return 1;
        }

        protected override int GetExpected_Insert_ThirdNode_IntoRootLeft_AtRootLeftRight_CheckBalance()
        {
            return 0;
        }

        protected override int GetExpected_Insert_ThirdNode_IntoRootLeft_AtRootLeftRight_CheckHeight()
        {
            return 1;
        }

        protected override int GetExpected_Insert_ThirdNode_IntoRootRight_AtRootRightRight_CheckBalance()
        {
            return 0;
        }

        protected override int GetExpected_Insert_ThirdNode_IntoRootRight_AtRootRightRight_CheckHeight()
        {
            return 1;
        }

        protected override int GetExpected_Insert_ThirdNode_IntoRootRight_AtRootRightLeft_CheckBalance()
        {
            return 0;
        }

        protected override int GetExpected_Insert_ThirdNode_IntoRootRight_AtRootRightLeft_CheckHeight()
        {
            return 1;
        }

        #endregion

        #region IBinarySearchTree.Insert


        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Insert_IntoEmpty_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitEmptyTree();
            tree.Insert(50);

            Assert.IsFalse(tree.Root.IsRed);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public void Insert_IntoRootOnly_Smaller_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitRootOnly();
            tree.Insert(25);

            Assert.IsFalse(tree.Root.IsRed);
            Assert.IsTrue(tree.Root.Left.IsRed);
        }

        #endregion
    }
}
