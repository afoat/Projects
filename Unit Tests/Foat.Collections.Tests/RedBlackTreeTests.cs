namespace Foat.Collections.Tests
{
    using Foat.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class RedBlackTreeTests : IBinarySearchTreeTests<RedBlackTree<int>>
    {
        private const RedBlackTree<int>.Node.Colour RedColour = RedBlackTree<int>.Node.Colour.Red;
        private const RedBlackTree<int>.Node.Colour BlackColour = RedBlackTree<int>.Node.Colour.Black;

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

            tree.Root = new RedBlackTree<int>.Node(50) { NodeColour = BlackColour };
            tree.Root.Right = new RedBlackTree<int>.Node(75) { NodeColour = BlackColour };
            tree.Root.Left = new RedBlackTree<int>.Node(25) { NodeColour = BlackColour };
            tree.Root.Left.Left = new RedBlackTree<int>.Node(12) { NodeColour = RedColour };
            tree.Root.Left.Right = new RedBlackTree<int>.Node(32) { NodeColour = RedColour };
            tree.Count = 5;

            return tree;
        }

        protected override IBinarySearchTree<int> InitFourNodesLeftLeft()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Root = new RedBlackTree<int>.Node(50) { NodeColour = BlackColour };
            tree.Root.Right = new RedBlackTree<int>.Node(75) { NodeColour = BlackColour };
            tree.Root.Left = new RedBlackTree<int>.Node(25) { NodeColour = BlackColour };
            tree.Root.Left.Left = new RedBlackTree<int>.Node(12) { NodeColour = RedColour };
            tree.Count = 4;

            return tree;
        }

        protected override IBinarySearchTree<int> InitFourNodesLeftRight()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Root = new RedBlackTree<int>.Node(50) { NodeColour = BlackColour };
            tree.Root.Right = new RedBlackTree<int>.Node(75) { NodeColour = BlackColour };
            tree.Root.Left = new RedBlackTree<int>.Node(25) { NodeColour = BlackColour };
            tree.Root.Left.Right = new RedBlackTree<int>.Node(32) { NodeColour = RedColour };
            tree.Count = 4;

            return tree;
        }

        protected override IBinarySearchTree<int> InitFourNodesRightLeft()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Root = new RedBlackTree<int>.Node(50) { NodeColour = BlackColour };
            tree.Root.Left = new RedBlackTree<int>.Node(25) { NodeColour = BlackColour };
            tree.Root.Right = new RedBlackTree<int>.Node(75) { NodeColour = BlackColour };
            tree.Root.Right.Left = new RedBlackTree<int>.Node(63) { NodeColour = RedColour };
            tree.Count = 4;

            return tree;
        }

        protected override IBinarySearchTree<int> InitFourNodesRightRight()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Root = new RedBlackTree<int>.Node(50) { NodeColour = BlackColour };
            tree.Root.Left = new RedBlackTree<int>.Node(25) { NodeColour = BlackColour };
            tree.Root.Right = new RedBlackTree<int>.Node(75) { NodeColour = BlackColour };
            tree.Root.Right.Right = new RedBlackTree<int>.Node(100) { NodeColour = RedColour };
            tree.Count = 4;

            return tree;
        }

        protected override IBinarySearchTree<int> InitRootLeft()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Root = new RedBlackTree<int>.Node(50) { NodeColour = BlackColour };
            tree.Root.Left = new RedBlackTree<int>.Node(25) { NodeColour = RedColour };
            tree.Count = 2;

            return tree;
        }

        protected override IBinarySearchTree<int> InitRootOnly()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Root = new RedBlackTree<int>.Node(50) { NodeColour = BlackColour };
            tree.Count = 1;

            return tree;
        }

        protected override IBinarySearchTree<int> InitRootRight()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Root = new RedBlackTree<int>.Node(50) { NodeColour = BlackColour };
            tree.Root.Right = new RedBlackTree<int>.Node(75) { NodeColour = RedColour };
            tree.Count = 2;

            return tree;
        }

        protected override IBinarySearchTree<int> InitThreeNodesFull()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Root = new RedBlackTree<int>.Node(50) { NodeColour = BlackColour };
            tree.Root.Left = new RedBlackTree<int>.Node(25) { NodeColour = RedColour };
            tree.Root.Right = new RedBlackTree<int>.Node(75) { NodeColour = RedColour };
            tree.Count = 3;

            return tree;
        }

        protected override IBinarySearchTree<int> InitBadTree()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Root = new RedBlackTree<int>.Node(50) { NodeColour = BlackColour };
            tree.Root.Left = new RedBlackTree<int>.Node(75) { NodeColour = RedColour };
            tree.Root.Right = new RedBlackTree<int>.Node(25) { NodeColour = RedColour };
            tree.Count = 3;

            return tree;
        }

        protected virtual RedBlackTree<int> InitLeftUnbalancedRedSibling()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();

            tree.Root = new RedBlackTree<int>.Node(50) { NodeColour = BlackColour };
            tree.Root.Left = new RedBlackTree<int>.Node(25) { NodeColour = RedColour };
            tree.Root.Right = new RedBlackTree<int>.Node(75) { NodeColour = BlackColour };
            tree.Root.Left.Left = new RedBlackTree<int>.Node(12) { NodeColour = BlackColour };
            tree.Root.Left.Right = new RedBlackTree<int>.Node(32) { NodeColour = BlackColour };
            tree.Root.Left.Left.Left = new RedBlackTree<int>.Node(7) { NodeColour = RedColour };
            tree.Root.Left.Left.Right = new RedBlackTree<int>.Node(15) { NodeColour = RedColour };
            tree.Count = 7;

            return tree;
        }

        protected virtual RedBlackTree<int> InitLeftUnbalancedDifferentRoot()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            
            tree.Root = new RedBlackTree<int>.Node(50) { NodeColour = BlackColour };
            tree.Root.Left = new RedBlackTree<int>.Node(30) { NodeColour = RedColour };
            tree.Root.Right = new RedBlackTree<int>.Node(75) { NodeColour = BlackColour };
            tree.Root.Left.Left = new RedBlackTree<int>.Node(25) { NodeColour = BlackColour };
            tree.Root.Left.Right = new RedBlackTree<int>.Node(32) { NodeColour = BlackColour };
            tree.Root.Left.Right.Right = new RedBlackTree<int>.Node(35) { NodeColour = RedColour };
            tree.Count = 6;

            return tree;
        }

        protected virtual RedBlackTree<int> InitRightUnbalancedRedSibling()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            
            tree.Root = new RedBlackTree<int>.Node(50) { NodeColour = BlackColour };
            tree.Root.Left = new RedBlackTree<int>.Node(25) { NodeColour = BlackColour };
            tree.Root.Right = new RedBlackTree<int>.Node(75) { NodeColour = RedColour };
            tree.Root.Right.Left = new RedBlackTree<int>.Node(62) { NodeColour = BlackColour };
            tree.Root.Right.Right = new RedBlackTree<int>.Node(100) { NodeColour = BlackColour };
            tree.Root.Right.Right.Left = new RedBlackTree<int>.Node(80) { NodeColour = RedColour };
            tree.Root.Right.Right.Right = new RedBlackTree<int>.Node(110) { NodeColour = RedColour };
            tree.Count = 7;

            return tree;
        }

        protected virtual RedBlackTree<int> InitRightUnbalancedDifferentRoot()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();

            tree.Root = new RedBlackTree<int>.Node(50) { NodeColour = BlackColour };
            tree.Root.Left = new RedBlackTree<int>.Node(25) { NodeColour = BlackColour };
            tree.Root.Right = new RedBlackTree<int>.Node(75) { NodeColour = RedColour };
            tree.Root.Right.Left = new RedBlackTree<int>.Node(62) { NodeColour = BlackColour };
            tree.Root.Right.Right = new RedBlackTree<int>.Node(100) { NodeColour = BlackColour };
            tree.Root.Right.Left.Left = new RedBlackTree<int>.Node(60) { NodeColour = RedColour };
            tree.Root.Right.Left.Right = new RedBlackTree<int>.Node(65) { NodeColour = RedColour };
            tree.Count = 7;

            return tree;
        }

        protected virtual RedBlackTree<int> InitBadTreeTwoRedsLeft()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Root = new RedBlackTree<int>.Node(50) { NodeColour = RedColour };
            tree.Root.Left = new RedBlackTree<int>.Node(25) { NodeColour = RedColour };

            return tree;
        }

        protected virtual RedBlackTree<int> InitBadTreeTwoRedsRight()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Root = new RedBlackTree<int>.Node(50) { NodeColour = RedColour };
            tree.Root.Right = new RedBlackTree<int>.Node(75) { NodeColour = RedColour };

            return tree;
        }

        protected virtual RedBlackTree<int> InitBadTreeDifferentNumberOfRedsInSubtrees()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Root = new RedBlackTree<int>.Node(50) { NodeColour = BlackColour };
            tree.Root.Left = new RedBlackTree<int>.Node(25) { NodeColour = BlackColour };
            tree.Root.Right = new RedBlackTree<int>.Node(75) { NodeColour = RedColour };

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

            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.NodeColour);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Insert_IntoRootOnly_Smaller_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitRootOnly();
            tree.Insert(25);

            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(RedColour, tree.Root.Left.NodeColour);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Insert_IntoRootOnly_Larger_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitRootOnly();
            tree.Insert(75);


            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(RedColour, tree.Root.Right.NodeColour);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Insert_ThirdNode_IntoRootLeft_AtRootRight_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitRootLeft();
            tree.Insert(75);
            
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(RedColour, tree.Root.Left.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(RedColour, tree.Root.Right.NodeColour);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Insert_ThirdNode_IntoRootLeft_AtRootLeftLeft_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitRootLeft();
            tree.Insert(12);

            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(RedColour, tree.Root.Left.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(RedColour, tree.Root.Right.NodeColour);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public virtual void Insert_ThirdNode_IntoRootLeft_AtRootLeftRight_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitRootLeft();
            tree.Insert(32);

            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(RedColour, tree.Root.Left.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(RedColour, tree.Root.Right.NodeColour);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public  void Insert_ThirdNode_IntoRootRight_AtRootRightRight_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitRootRight();
            tree.Insert(100);

            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(RedColour, tree.Root.Left.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(RedColour, tree.Root.Right.NodeColour);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public virtual void Insert_ThirdNode_IntoRootRight_AtRootRightLeft_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitRootRight();
            tree.Insert(62);

            Assert.AreEqual<int>(3, tree.Count);

            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(RedColour, tree.Root.Left.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(RedColour, tree.Root.Right.NodeColour);
        }

        #endregion

        #region Delete

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_RootLeft_Root_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitRootLeft();
            Assert.IsTrue(tree.Delete(50));

            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.NodeColour);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_RootLeft_Left_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitRootLeft();
            Assert.IsTrue(tree.Delete(25));

            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.NodeColour);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_RootRight_Root_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitRootRight();
            Assert.IsTrue(tree.Delete(50));

            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.NodeColour);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_RootRight_Right_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitRootRight();
            Assert.IsTrue(tree.Delete(75));

            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.NodeColour);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_ThreeNodesFull_Root_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitThreeNodesFull();
            Assert.IsTrue(tree.Delete(50));

            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(RedColour, tree.Root.Right.NodeColour);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_FiveNodesLeftFull_NonRootWithFullChildren_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitFiveNodesLeftFull();
            Assert.IsTrue(tree.Delete(25));

            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.Left.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.Right.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(RedColour, tree.Root.Left.Right.NodeColour);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_ThreeNodesFull_LeftLeaf_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitThreeNodesFull();
            Assert.IsTrue(tree.Delete(25));

            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(RedColour, tree.Root.Right.NodeColour);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_ThreeNodesFull_RightLeaf_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitThreeNodesFull();
            Assert.IsTrue(tree.Delete(75));

            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(RedColour, tree.Root.Left.NodeColour);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_FourNodesLeftLeft_HasParentAndChild_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitFourNodesLeftLeft();
            Assert.IsTrue(tree.Delete(25));

            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.Left.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.Right.NodeColour);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_FourNodesLeftRight_HasParentAndChild_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitFourNodesLeftRight();
            Assert.IsTrue(tree.Delete(25));

            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.Left.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.Right.NodeColour);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_FourNodesRightLeft_HasParentAndChild_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitFourNodesRightLeft();
            Assert.IsTrue(tree.Delete(75));

            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.Left.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.Right.NodeColour);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public void Delete_FourNodesRightRight_HasParentAndChild_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitFourNodesRightRight();
            Assert.IsTrue(tree.Delete(75));

            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.Left.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.Right.NodeColour);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void Delete_LeftUnbalanced_Complicated1_CheckColours()
        {
            RedBlackTree<int> tree = (RedBlackTree<int>)this.InitLeftUnbalancedRedSibling();
            Assert.IsTrue(tree.Delete(75));

            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.Left.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.Right.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(RedColour, tree.Root.Left.Left.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(RedColour, tree.Root.Left.Right.NodeColour);
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

            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.Left.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(RedColour, tree.Root.Right.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.Right.Left.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.Right.Right.NodeColour);
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

            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.Left.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.Right.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(RedColour, tree.Root.Left.Right.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(RedColour, tree.Root.Right.Left.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(RedColour, tree.Root.Right.Right.NodeColour);
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

            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(RedColour, tree.Root.Left.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.Right.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.Left.Right.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(BlackColour, tree.Root.Left.Left.NodeColour);
            Assert.AreEqual<RedBlackTree<int>.Node.Colour>(RedColour, tree.Root.Left.Left.Right.NodeColour);
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
