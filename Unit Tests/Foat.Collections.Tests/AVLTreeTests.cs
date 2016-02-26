namespace Foat.Collections.Tests
{
    using Foat.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AVLTreeTests : IBinarySearchTreeTests<AVLTree<int>>
    {
        #region Setup

        protected override IBinarySearchTree<int> InitEmptyTree()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Count = 0;
            return tree;
        }

        protected override IBinarySearchTree<int> InitFiveNodesLeftFull()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Root = new AVLTree<int>.Node(50);
            tree.Root.Right = new AVLTree<int>.Node(75);
            tree.Root.Left = new AVLTree<int>.Node(25);
            tree.Root.Left.Left = new AVLTree<int>.Node(12);
            tree.Root.Left.Right = new AVLTree<int>.Node(32);
            tree.Count = 5;

            return tree;
        }

        protected override IBinarySearchTree<int> InitFourNodesLeftLeft()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Root = new AVLTree<int>.Node(50);
            tree.Root.Right = new AVLTree<int>.Node(75);
            tree.Root.Left = new AVLTree<int>.Node(25);
            tree.Root.Left.Left = new AVLTree<int>.Node(12);
            tree.Count = 4;

            return tree;
        }

        protected override IBinarySearchTree<int> InitFourNodesLeftRight()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Root = new AVLTree<int>.Node(50);
            tree.Root.Right = new AVLTree<int>.Node(75);
            tree.Root.Left = new AVLTree<int>.Node(25);
            tree.Root.Left.Right = new AVLTree<int>.Node(32);
            tree.Count = 4;

            return tree;
        }

        protected override IBinarySearchTree<int> InitFourNodesRightLeft()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Root = new AVLTree<int>.Node(50);
            tree.Root.Left = new AVLTree<int>.Node(25);
            tree.Root.Right = new AVLTree<int>.Node(75);
            tree.Root.Right.Left = new AVLTree<int>.Node(63);
            tree.Count = 4;

            return tree;
        }

        protected override IBinarySearchTree<int> InitFourNodesRightRight()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Root = new AVLTree<int>.Node(50);
            tree.Root.Left = new AVLTree<int>.Node(25);
            tree.Root.Right = new AVLTree<int>.Node(75);
            tree.Root.Right.Right = new AVLTree<int>.Node(100);
            tree.Count = 4;

            return tree;
        }

        protected override IBinarySearchTree<int> InitRootLeft()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Root = new AVLTree<int>.Node(50);
            tree.Root.Left = new AVLTree<int>.Node(25);
            tree.Count = 2;

            return tree;
        }

        protected override IBinarySearchTree<int> InitRootOnly()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Root = new AVLTree<int>.Node(50);
            tree.Count = 1;

            return tree;
        }

        protected override IBinarySearchTree<int> InitRootRight()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Root = new AVLTree<int>.Node(50);
            tree.Root.Right = new AVLTree<int>.Node(75);
            tree.Count = 2;

            return tree;
        }

        protected override IBinarySearchTree<int> InitThreeNodesFull()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Root = new AVLTree<int>.Node(50);
            tree.Root.Left = new AVLTree<int>.Node(25);
            tree.Root.Right = new AVLTree<int>.Node(75);
            tree.Count = 3;

            return tree;
        }

        protected override IBinarySearchTree<int> InitBadTree()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Root = new AVLTree<int>.Node(50);
            tree.Root.Left = new AVLTree<int>.Node(75);
            tree.Root.Right = new AVLTree<int>.Node(25);
            tree.Count = 3;

            return tree;
        }

        protected IBinarySearchTree<int> InitBadTreeNotBalancedLeft()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Root = new AVLTree<int>.Node(50);
            tree.Root.Left = new AVLTree<int>.Node(25);
            tree.Root.Left.Left = new AVLTree<int>.Node(12);
            tree.Count = 3;

            return tree;
        }

        protected IBinarySearchTree<int> InitBadTreeNotBalancedRight()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Root = new AVLTree<int>.Node(50);
            tree.Root.Right = new AVLTree<int>.Node(75);
            tree.Root.Right.Right = new AVLTree<int>.Node(100);
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

        protected override int GetExpected_Delete_FourNodesLeftLeft_Right_CheckBalance()
        {
            return 0;
        }

        protected override int GetExpected_Delete_FourNodesLeftLeft_Right_CheckHeight()
        {
            return 1;
        }

        protected override int GetExpected_Delete_FourNodesLeftRight_Right_CheckBalance()
        {
            return 0;
        }

        protected override int GetExpected_Delete_FourNodesLeftRight_Right_CheckHeight()
        {
            return 1;
        }

        protected override int GetExpected_Delete_FourNodesRightRight_Left_CheckBalance()
        {
            return 0;
        }

        protected override int GetExpected_Delete_FourNodesRightRight_Left_CheckHeight()
        {
            return 1;
        }

        protected override int GetExpected_Delete_FourNodesRightLeft_Left_CheckBalance()
        {
            return 0;
        }

        protected override int GetExpected_Delete_FourNodesRightLeft_Left_CheckHeight()
        {
            return 1;
        }

        #endregion

        #region AssertValidTree

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\AvlTree")]
        [ExpectedException(typeof(InvalidTreeException))]
        public virtual void AssertValidTree_NotBalanced_Left()
        {
            IBinarySearchTree<int> tree = this.InitBadTreeNotBalancedLeft();
            tree.AssertValidTree();
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\AvlTree")]
        [ExpectedException(typeof(InvalidTreeException))]
        public virtual void AssertValidTree_NotBalanced_Right()
        {
            IBinarySearchTree<int> tree = this.InitBadTreeNotBalancedRight();
            tree.AssertValidTree();
        }

        #endregion
    }
}
