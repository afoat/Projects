namespace Foat.Collections.Tests
{
    using Foat.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AVLTreeTests : IBinarySearchTreeTests<AVLTree<int>>
    {
        protected override IBinarySearchTree<int> InitEmptyTree()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Count = 0;
            return tree;
        }

        protected override IBinarySearchTree<int> InitFiveNodesLeftFull()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Root = new AVLNode<int>(50);
            tree.Root.Right = new AVLNode<int>(75);
            tree.Root.Left = new AVLNode<int>(25);
            tree.Root.Left.Left = new AVLNode<int>(12);
            tree.Root.Left.Right = new AVLNode<int>(32);
            tree.Count = 5;

            return tree;
        }

        protected override IBinarySearchTree<int> InitFourNodesLeftLeft()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Root = new AVLNode<int>(50);
            tree.Root.Right = new AVLNode<int>(75);
            tree.Root.Left = new AVLNode<int>(25);
            tree.Root.Left.Left = new AVLNode<int>(12);
            tree.Count = 4;

            return tree;
        }

        protected override IBinarySearchTree<int> InitFourNodesLeftRight()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Root = new AVLNode<int>(50);
            tree.Root.Right = new AVLNode<int>(75);
            tree.Root.Left = new AVLNode<int>(25);
            tree.Root.Left.Right = new AVLNode<int>(32);
            tree.Count = 4;

            return tree;
        }

        protected override IBinarySearchTree<int> InitFourNodesRightLeft()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Root = new AVLNode<int>(50);
            tree.Root.Left = new AVLNode<int>(25);
            tree.Root.Right = new AVLNode<int>(75);
            tree.Root.Right.Left = new AVLNode<int>(63);
            tree.Count = 4;

            return tree;
        }

        protected override IBinarySearchTree<int> InitFourNodesRightRight()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Root = new AVLNode<int>(50);
            tree.Root.Left = new AVLNode<int>(25);
            tree.Root.Right = new AVLNode<int>(75);
            tree.Root.Right.Right = new AVLNode<int>(100);
            tree.Count = 4;

            return tree;
        }

        protected override IBinarySearchTree<int> InitRootLeft()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Root = new AVLNode<int>(50);
            tree.Root.Left = new AVLNode<int>(25);
            tree.Count = 2;

            return tree;
        }

        protected override IBinarySearchTree<int> InitRootOnly()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Root = new AVLNode<int>(50);
            tree.Count = 1;

            return tree;
        }

        protected override IBinarySearchTree<int> InitRootRight()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Root = new AVLNode<int>(50);
            tree.Root.Right = new AVLNode<int>(75);
            tree.Count = 2;

            return tree;
        }

        protected override IBinarySearchTree<int> InitThreeNodesFull()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Root = new AVLNode<int>(50);
            tree.Root.Left = new AVLNode<int>(25);
            tree.Root.Right = new AVLNode<int>(75);
            tree.Count = 3;

            return tree;
        }

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

        protected override IBinarySearchTree<int> InitBadTree()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Root = new AVLNode<int>(50);
            tree.Root.Left = new AVLNode<int>(75);
            tree.Root.Right = new AVLNode<int>(25);
            tree.Count = 3;

            return tree;
        }

        protected IBinarySearchTree<int> InitBadTreeNotBalanced()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Root = new AVLNode<int>(50);
            tree.Root.Left = new AVLNode<int>(25);
            tree.Root.Left.Left = new AVLNode<int>(12);
            tree.Count = 3;

            return tree;
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\AvlTree")]
        [ExpectedException(typeof(InvalidTreeException))]
        public virtual void AssertValidTree_NotBalanced()
        {
            IBinarySearchTree<int> tree = this.InitBadTreeNotBalanced();
            tree.AssertValidTree();
        }
    }
}
