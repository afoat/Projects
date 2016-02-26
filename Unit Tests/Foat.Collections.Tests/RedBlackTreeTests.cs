namespace Foat.Collections.Tests
{
    using Foat.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Diagnostics.CodeAnalysis;

    [TestClass]
    [ExcludeFromCodeCoverage]
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

        protected virtual RedBlackTree<int> InitLeftUnbalancedRedSibling()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();

            tree.Root = new RedBlackNode<int>(50) { IsRed = false };
            tree.Root.Left = new RedBlackNode<int>(25) { IsRed = true };
            tree.Root.Right = new RedBlackNode<int>(75) { IsRed = false };
            tree.Root.Left.Left = new RedBlackNode<int>(12) { IsRed = false };
            tree.Root.Left.Right = new RedBlackNode<int>(32) { IsRed = false };
            tree.Root.Left.Left.Left = new RedBlackNode<int>(7) { IsRed = true };
            tree.Root.Left.Left.Right = new RedBlackNode<int>(15) { IsRed = true };
            tree.Count = 7;

            return tree;
        }

        protected virtual RedBlackTree<int> InitLeftUnbalancedDifferentRoot()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            
            tree.Root = new RedBlackNode<int>(50) { IsRed = false };
            tree.Root.Left = new RedBlackNode<int>(30) { IsRed = true };
            tree.Root.Right = new RedBlackNode<int>(75) { IsRed = false };
            tree.Root.Left.Left = new RedBlackNode<int>(25) { IsRed = false };
            tree.Root.Left.Right = new RedBlackNode<int>(32) { IsRed = false };
            tree.Root.Left.Right.Right = new RedBlackNode<int>(35) { IsRed = true };
            tree.Count = 6;

            return tree;
        }

        protected virtual RedBlackTree<int> InitRightUnbalancedRedSibling()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            
            tree.Root = new RedBlackNode<int>(50) { IsRed = false };
            tree.Root.Left = new RedBlackNode<int>(25) { IsRed = false };
            tree.Root.Right = new RedBlackNode<int>(75) { IsRed = true };
            tree.Root.Right.Left = new RedBlackNode<int>(62) { IsRed = false };
            tree.Root.Right.Right = new RedBlackNode<int>(100) { IsRed = false };
            tree.Root.Right.Right.Left = new RedBlackNode<int>(80) { IsRed = true };
            tree.Root.Right.Right.Right = new RedBlackNode<int>(110) { IsRed = true };
            tree.Count = 7;

            return tree;
        }

        protected virtual RedBlackTree<int> InitRightUnbalancedDifferentRoot()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();

            tree.Root = new RedBlackNode<int>(50) { IsRed = false };
            tree.Root.Left = new RedBlackNode<int>(25) { IsRed = false };
            tree.Root.Right = new RedBlackNode<int>(75) { IsRed = true };
            tree.Root.Right.Left = new RedBlackNode<int>(62) { IsRed = false };
            tree.Root.Right.Right = new RedBlackNode<int>(100) { IsRed = false };
            tree.Root.Right.Left.Left = new RedBlackNode<int>(60) { IsRed = true };
            tree.Root.Right.Left.Right = new RedBlackNode<int>(65) { IsRed = true };
            tree.Count = 7;

            return tree;
        }

        protected virtual RedBlackTree<int> InitBadTreeTwoRedsLeft()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Root = new RedBlackNode<int>(50) { IsRed = true };
            tree.Root.Left = new RedBlackNode<int>(25) { IsRed = true };

            return tree;
        }

        protected virtual RedBlackTree<int> InitBadTreeTwoRedsRight()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Root = new RedBlackNode<int>(50) { IsRed = true };
            tree.Root.Right = new RedBlackNode<int>(75) { IsRed = true };

            return tree;
        }

        protected virtual RedBlackTree<int> InitBadTreeDifferentNumberOfRedsInSubtrees()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Root = new RedBlackNode<int>(50) { IsRed = false };
            tree.Root.Left = new RedBlackNode<int>(25) { IsRed = false };
            tree.Root.Right = new RedBlackNode<int>(75) { IsRed = true };

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

        #region Insert


        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Insert_IntoEmpty_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitEmptyTree();
            tree.Insert(50);

            Assert.IsFalse(tree.Root.IsRed);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Insert_IntoRootOnly_Smaller_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitRootOnly();
            tree.Insert(25);

            Assert.IsFalse(tree.Root.IsRed);
            Assert.IsTrue(tree.Root.Left.IsRed);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Insert_IntoRootOnly_Larger_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitRootOnly();
            tree.Insert(75);


            Assert.IsFalse(tree.Root.IsRed);
            Assert.IsTrue(tree.Root.Right.IsRed);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Insert_ThirdNode_IntoRootLeft_AtRootRight_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitRootLeft();
            tree.Insert(75);
            
            Assert.IsFalse(tree.Root.IsRed);
            Assert.IsTrue(tree.Root.Left.IsRed);
            Assert.IsTrue(tree.Root.Right.IsRed);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Insert_ThirdNode_IntoRootLeft_AtRootLeftLeft_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitRootLeft();
            tree.Insert(12);

            Assert.IsFalse(tree.Root.IsRed);
            Assert.IsTrue(tree.Root.Left.IsRed);
            Assert.IsTrue(tree.Root.Right.IsRed);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public virtual void Insert_ThirdNode_IntoRootLeft_AtRootLeftRight_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitRootLeft();
            tree.Insert(32);

            Assert.IsFalse(tree.Root.IsRed);
            Assert.IsTrue(tree.Root.Left.IsRed);
            Assert.IsTrue(tree.Root.Right.IsRed);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public  void Insert_ThirdNode_IntoRootRight_AtRootRightRight_Insert_ThirdNode_IntoRootLeft_AtRootLeftRight_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitRootRight();
            tree.Insert(100);

            Assert.IsFalse(tree.Root.IsRed);
            Assert.IsTrue(tree.Root.Left.IsRed);
            Assert.IsTrue(tree.Root.Right.IsRed);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public virtual void Insert_ThirdNode_IntoRootRight_AtRootRightLeft_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitRootRight();
            tree.Insert(62);

            Assert.AreEqual<int>(3, tree.Count);

            Assert.IsFalse(tree.Root.IsRed);
            Assert.IsTrue(tree.Root.Left.IsRed);
            Assert.IsTrue(tree.Root.Right.IsRed);
        }

        #endregion

        #region Delete

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_RootLeft_Root_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitRootLeft();
            Assert.IsTrue(tree.Delete(50));

            Assert.IsFalse(tree.Root.IsRed);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_RootLeft_Left_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitRootLeft();
            Assert.IsTrue(tree.Delete(25));

            Assert.IsFalse(tree.Root.IsRed);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_RootRight_Root_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitRootRight();
            Assert.IsTrue(tree.Delete(50));

            Assert.IsFalse(tree.Root.IsRed);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_RootRight_Right_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitRootRight();
            Assert.IsTrue(tree.Delete(75));

            Assert.IsFalse(tree.Root.IsRed);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_ThreeNodesFull_Root_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitThreeNodesFull();
            Assert.IsTrue(tree.Delete(50));

            Assert.IsFalse(tree.Root.IsRed);
            Assert.IsTrue(tree.Root.Right.IsRed);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_FiveNodesLeftFull_NonRootWithFullChildren_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitFiveNodesLeftFull();
            Assert.IsTrue(tree.Delete(25));

            Assert.IsFalse(tree.Root.IsRed);
            Assert.IsFalse(tree.Root.Left.IsRed);
            Assert.IsFalse(tree.Root.Right.IsRed);
            Assert.IsTrue(tree.Root.Left.Right.IsRed);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_ThreeNodesFull_LeftLeaf_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitThreeNodesFull();
            Assert.IsTrue(tree.Delete(25));

            Assert.IsFalse(tree.Root.IsRed);
            Assert.IsTrue(tree.Root.Right.IsRed);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_ThreeNodesFull_RightLeaf_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitThreeNodesFull();
            Assert.IsTrue(tree.Delete(75));

            Assert.IsFalse(tree.Root.IsRed);
            Assert.IsTrue(tree.Root.Left.IsRed);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_FourNodesLeftLeft_HasParentAndChild_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitFourNodesLeftLeft();
            Assert.IsTrue(tree.Delete(25));

            Assert.IsFalse(tree.Root.IsRed);
            Assert.IsFalse(tree.Root.Left.IsRed);
            Assert.IsFalse(tree.Root.Right.IsRed);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_FourNodesLeftRight_HasParentAndChild_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitFourNodesLeftRight();
            Assert.IsTrue(tree.Delete(25));

            Assert.IsFalse(tree.Root.IsRed);
            Assert.IsFalse(tree.Root.Left.IsRed);
            Assert.IsFalse(tree.Root.Right.IsRed);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_FourNodesRightLeft_HasParentAndChild_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitFourNodesRightLeft();
            Assert.IsTrue(tree.Delete(75));

            Assert.IsFalse(tree.Root.IsRed);
            Assert.IsFalse(tree.Root.Left.IsRed);
            Assert.IsFalse(tree.Root.Right.IsRed);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public void Delete_FourNodesRightRight_HasParentAndChild_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitFourNodesRightRight();
            Assert.IsTrue(tree.Delete(75));

            Assert.IsFalse(tree.Root.IsRed);
            Assert.IsFalse(tree.Root.Left.IsRed);
            Assert.IsFalse(tree.Root.Right.IsRed);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_LeftUnbalanced_Complicated1_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitLeftUnbalancedRedSibling();
            Assert.IsTrue(tree.Delete(75));

            Assert.IsFalse(tree.Root.IsRed);
            Assert.IsFalse(tree.Root.Left.IsRed);
            Assert.IsFalse(tree.Root.Right.IsRed);
            Assert.IsTrue(tree.Root.Left.Left.IsRed);
            Assert.IsTrue(tree.Root.Left.Right.IsRed);
            Assert.IsTrue(tree.Root.Right.Left.IsRed);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_LeftUnbalanced_Complicated1_CheckContains()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitLeftUnbalancedRedSibling();
            Assert.IsTrue(tree.Delete(75));
            Assert.IsFalse(tree.Contains(75));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_LeftUnbalanced_Complicated1_CheckCount()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitLeftUnbalancedRedSibling();
            Assert.IsTrue(tree.Delete(75));
            Assert.AreEqual(6, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_LeftUnbalanced_Complicated1_CheckHeight()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitLeftUnbalancedRedSibling();
            Assert.IsTrue(tree.Delete(75));
            Assert.AreEqual(2, tree.Height);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_LeftUnbalanced_Complicated1_CheckBalance()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitLeftUnbalancedRedSibling();
            Assert.IsTrue(tree.Delete(75));
            Assert.AreEqual(0, tree.Balance);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_LeftUnbalanced_DifferentRoot_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitLeftUnbalancedDifferentRoot();
            Assert.IsTrue(tree.Delete(75));

            Assert.IsFalse(tree.Root.IsRed);
            Assert.IsFalse(tree.Root.Left.IsRed);
            Assert.IsTrue(tree.Root.Right.IsRed);
            Assert.IsFalse(tree.Root.Right.Left.IsRed);
            Assert.IsFalse(tree.Root.Right.Right.IsRed);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_LeftUnbalanced_DifferentRoot_CheckContains()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitLeftUnbalancedDifferentRoot();
            Assert.IsTrue(tree.Delete(75));
            Assert.IsFalse(tree.Contains(75));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_LeftUnbalanced_DifferentRoot_CheckCount()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitLeftUnbalancedDifferentRoot();
            Assert.IsTrue(tree.Delete(75));
            Assert.AreEqual(5, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_LeftUnbalanced_DifferentRoot_CheckHeight()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitLeftUnbalancedDifferentRoot();
            Assert.IsTrue(tree.Delete(75));
            Assert.AreEqual(2, tree.Height);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_LeftUnbalanced_DifferentRoot_CheckBalance()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitLeftUnbalancedDifferentRoot();
            Assert.IsTrue(tree.Delete(75));
            Assert.AreEqual(-1, tree.Balance);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_RightUnbalanced_Complicated1_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitRightUnbalancedRedSibling();
            Assert.IsTrue(tree.Delete(25));

            Assert.IsFalse(tree.Root.IsRed);
            Assert.IsFalse(tree.Root.Left.IsRed);
            Assert.IsFalse(tree.Root.Right.IsRed);
            Assert.IsTrue(tree.Root.Left.Right.IsRed);
            Assert.IsTrue(tree.Root.Right.Left.IsRed);
            Assert.IsTrue(tree.Root.Right.Right.IsRed);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_RightUnbalanced_Complicated1_CheckContains()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitRightUnbalancedRedSibling();
            Assert.IsTrue(tree.Delete(25));
            Assert.IsFalse(tree.Contains(25));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_RightUnbalanced_Complicated1_CheckCount()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitRightUnbalancedRedSibling();
            Assert.IsTrue(tree.Delete(25));
            Assert.AreEqual(6, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_RightUnbalanced_Complicated1_CheckHeight()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitRightUnbalancedRedSibling();
            Assert.IsTrue(tree.Delete(25));
            Assert.AreEqual(2, tree.Height);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_RightUnbalanced_Complicated1_CheckBalance()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitRightUnbalancedRedSibling();
            Assert.IsTrue(tree.Delete(25));
            Assert.AreEqual(0, tree.Balance);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_RightUnbalanced_DifferentRoot_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitRightUnbalancedDifferentRoot();
            Assert.IsTrue(tree.Delete(25));

            Assert.IsFalse(tree.Root.IsRed);
            Assert.IsTrue(tree.Root.Left.IsRed);
            Assert.IsFalse(tree.Root.Right.IsRed);
            Assert.IsFalse(tree.Root.Left.Right.IsRed);
            Assert.IsFalse(tree.Root.Left.Left.IsRed);
            Assert.IsTrue(tree.Root.Left.Left.Right.IsRed);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_RightUnbalanced_DifferentRoot_CheckContains()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitRightUnbalancedDifferentRoot();
            Assert.IsTrue(tree.Delete(25));
            Assert.IsFalse(tree.Contains(25));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_RightUnbalanced_DifferentRoot_CheckCount()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitRightUnbalancedDifferentRoot();
            Assert.IsTrue(tree.Delete(25));

            Assert.AreEqual(6, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_RightUnbalanced_DifferentRoot_CheckHeight()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitRightUnbalancedDifferentRoot();
            Assert.IsTrue(tree.Delete(25));

            Assert.AreEqual(3, tree.Height);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_RightUnbalanced_DifferentRoot_CheckBalance()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitRightUnbalancedDifferentRoot();
            Assert.IsTrue(tree.Delete(25));

            Assert.AreEqual(2, tree.Balance);
        }

        #endregion

        #region AssertValidTree

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        [ExpectedException(typeof(InvalidTreeException))]
        public void AssertValidTree_BadTree_TwoRedsLeft()
        {
            RedBlackTree<int> tree = this.InitBadTreeTwoRedsLeft();
            tree.AssertValidTree();
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        [ExpectedException(typeof(InvalidTreeException))]
        public void AssertValidTree_BadTree_TwoRedsRight()
        {
            RedBlackTree<int> tree = this.InitBadTreeTwoRedsRight();
            tree.AssertValidTree();
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        [ExpectedException(typeof(InvalidTreeException))]
        public void AssertValidTree_BadTree_DifferentNumberOfRedsInSubtrees()
        {
            RedBlackTree<int> tree = this.InitBadTreeDifferentNumberOfRedsInSubtrees();
            tree.AssertValidTree();
        }

        #endregion

    }
}
