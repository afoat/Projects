namespace Foat.Collections.Tests
{
    using Foat.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    [TestClass]
    [ExcludeFromCodeCoverage]
    public abstract class IBinarySearchTreeTests<T> where T : IBinarySearchTree<int>, new()
    {
        #region Setup
        
        protected abstract IBinarySearchTree<int> InitEmptyTree();
        protected abstract IBinarySearchTree<int> InitRootOnly();
        protected abstract IBinarySearchTree<int> InitRootLeft();
        protected abstract IBinarySearchTree<int> InitRootRight();
        protected abstract IBinarySearchTree<int> InitThreeNodesFull();
        protected abstract IBinarySearchTree<int> InitFourNodesLeftLeft();
        protected abstract IBinarySearchTree<int> InitFourNodesLeftRight();
        protected abstract IBinarySearchTree<int> InitFourNodesRightLeft();
        protected abstract IBinarySearchTree<int> InitFourNodesRightRight();
        protected abstract IBinarySearchTree<int> InitFiveNodesLeftFull();
        protected abstract IBinarySearchTree<int> InitBadTree();
        
        #endregion
                
        #region IBinarySearchTree.Insert

        #region Empty Tree

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Insert_IntoEmpty_CheckCount()
        {
            IBinarySearchTree<int> tree = this.InitEmptyTree();
            tree.Insert(50);

            Assert.AreEqual<int>(1, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Insert_IntoEmpty_CheckHeight()
        {
            IBinarySearchTree<int> tree = this.InitEmptyTree();
            tree.Insert(50);

            Assert.AreEqual<int>(0, tree.Height);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Insert_IntoEmpty_CheckBalance()
        {
            IBinarySearchTree<int> tree = this.InitEmptyTree();
            tree.Insert(50);

            Assert.AreEqual<int>(0, tree.Balance);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Insert_IntoEmpty_Contains_True()
        {
            IBinarySearchTree<int> tree = this.InitEmptyTree();
            tree.Insert(50);

            Assert.IsTrue(tree.Contains(50));
        }

        #endregion

        #region Root Only

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Insert_IntoRootOnly_Smaller_CheckCount()
        {
            IBinarySearchTree<int> tree = this.InitRootOnly();
            tree.Insert(25);

            Assert.AreEqual<int>(2, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Insert_IntoRootOnly_Smaller_CheckHeight()
        {
            IBinarySearchTree<int> tree = this.InitRootOnly();
            tree.Insert(25);

            Assert.AreEqual<int>(1, tree.Height);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Insert_IntoRootOnly_Smaller_CheckBalance()
        {
            IBinarySearchTree<int> tree = this.InitRootOnly();
            tree.Insert(25);

            Assert.AreEqual<int>(1, tree.Balance);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Insert_IntoRootOnly_Smaller_CheckContains()
        {
            IBinarySearchTree<int> tree = this.InitRootOnly();
            tree.Insert(25);
            Assert.IsTrue(tree.Contains(25));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Insert_IntoRootOnly_Larger_CheckCount()
        {
            IBinarySearchTree<int> tree = this.InitRootOnly();
            tree.Insert(75);

            Assert.AreEqual<int>(2, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Insert_IntoRootOnly_Larger_CheckBalance()
        {
            IBinarySearchTree<int> tree = this.InitRootOnly();
            tree.Insert(75);

            Assert.AreEqual<int>(-1, tree.Balance);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Insert_IntoRootOnly_Larger_CheckHeight()
        {
            IBinarySearchTree<int> tree = this.InitRootOnly();
            tree.Insert(75);

            Assert.AreEqual<int>(1, tree.Height);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Insert_IntoRootOnly_Larger_CheckContains()
        {
            IBinarySearchTree<int> tree = this.InitRootOnly();
            tree.Insert(75);
            Assert.IsTrue(tree.Contains(75));
        }

        #endregion

        #region Root Left

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Insert_ThirdNode_IntoRootLeft_AtRootRight_CheckCount()
        {
            IBinarySearchTree<int> tree = this.InitRootLeft();
            tree.Insert(75);

            Assert.AreEqual<int>(3, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Insert_ThirdNode_IntoRootLeft_AtRootRight_CheckHeight()
        {
            IBinarySearchTree<int> tree = this.InitRootLeft();
            tree.Insert(75);

            Assert.AreEqual<int>(1, tree.Height);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Insert_ThirdNode_IntoRootLeft_AtRootRight_CheckBalance()
        {
            IBinarySearchTree<int> tree = this.InitRootLeft();
            tree.Insert(75);

            Assert.AreEqual<int>(0, tree.Balance);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Insert_ThirdNode_IntoRootLeft_AtRootRight_CheckContains()
        {
            IBinarySearchTree<int> tree = this.InitRootLeft();
            tree.Insert(75);
            Assert.IsTrue(tree.Contains(75));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Insert_ThirdNode_IntoRootLeft_AtRootLeftLeft_CheckCount()
        {
            IBinarySearchTree<int> tree = this.InitRootLeft();
            tree.Insert(12);

            Assert.AreEqual<int>(3, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Insert_ThirdNode_IntoRootLeft_AtRootLeftLeft_CheckHeight()
        {
            IBinarySearchTree<int> tree = this.InitRootLeft();
            tree.Insert(12);

            Assert.AreEqual<int>(GetExpected_Insert_ThirdNode_IntoRootLeft_AtRootLeftLeft_CheckHeight(), tree.Height);
        }

        protected virtual int GetExpected_Insert_ThirdNode_IntoRootLeft_AtRootLeftLeft_CheckHeight()
        {
            return 2;
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Insert_ThirdNode_IntoRootLeft_AtRootLeftLeft_CheckBalance()
        {
            IBinarySearchTree<int> tree = this.InitRootLeft();
            tree.Insert(12);

            Assert.AreEqual<int>(GetExpected_Insert_ThirdNode_IntoRootLeft_AtRootLeftLeft_CheckBalance(), tree.Balance);
        }

        protected virtual int GetExpected_Insert_ThirdNode_IntoRootLeft_AtRootLeftLeft_CheckBalance()
        {
            return 2;
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Insert_ThirdNode_IntoRootLeft_AtRootLeftLeft_CheckContains()
        {
            IBinarySearchTree<int> tree = this.InitRootLeft();
            tree.Insert(12);
            Assert.IsTrue(tree.Contains(12));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Insert_ThirdNode_IntoRootLeft_AtRootLeftRight_CheckCount()
        {
            IBinarySearchTree<int> tree = this.InitRootLeft();
            tree.Insert(32);

            Assert.AreEqual<int>(3, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Insert_ThirdNode_IntoRootLeft_AtRootLeftRight_CheckHeight()
        {
            IBinarySearchTree<int> tree = this.InitRootLeft();
            tree.Insert(32);

            Assert.AreEqual<int>(GetExpected_Insert_ThirdNode_IntoRootLeft_AtRootLeftRight_CheckHeight(), tree.Height);
        }

        protected virtual int GetExpected_Insert_ThirdNode_IntoRootLeft_AtRootLeftRight_CheckHeight()
        {
            return 2;
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Insert_ThirdNode_IntoRootLeft_AtRootLeftRight_CheckBalance()
        {
            IBinarySearchTree<int> tree = this.InitRootLeft();
            tree.Insert(32);

            Assert.AreEqual<int>(GetExpected_Insert_ThirdNode_IntoRootLeft_AtRootLeftRight_CheckBalance(), tree.Balance);
        }

        protected virtual int GetExpected_Insert_ThirdNode_IntoRootLeft_AtRootLeftRight_CheckBalance()
        {
            return 2;
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Insert_ThirdNode_IntoRootLeft_AtRootLeftRight_CheckContains()
        {
            IBinarySearchTree<int> tree = this.InitRootLeft();
            tree.Insert(32);
            Assert.IsTrue(tree.Contains(32));
        }

        #endregion

        #region Root Right

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Insert_ThirdNode_IntoRootRight_AtRootRightRight_CheckCount()
        {
            IBinarySearchTree<int> tree = this.InitRootRight();
            tree.Insert(100);

            Assert.AreEqual<int>(3, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Insert_ThirdNode_IntoRootRight_AtRootRightRight_CheckHeight()
        {
            IBinarySearchTree<int> tree = this.InitRootRight();
            tree.Insert(100);

            Assert.AreEqual<int>(GetExpected_Insert_ThirdNode_IntoRootRight_AtRootRightRight_CheckHeight(), tree.Height);
        }

        protected virtual int GetExpected_Insert_ThirdNode_IntoRootRight_AtRootRightRight_CheckHeight()
        {
            return 2;
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Insert_ThirdNode_IntoRootRight_AtRootRightRight_CheckBalance()
        {
            IBinarySearchTree<int> tree = this.InitRootRight();
            tree.Insert(100);

            Assert.AreEqual<int>(GetExpected_Insert_ThirdNode_IntoRootRight_AtRootRightRight_CheckBalance(), tree.Balance);
        }

        protected virtual int GetExpected_Insert_ThirdNode_IntoRootRight_AtRootRightRight_CheckBalance()
        {
            return -2;
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Insert_ThirdNode_IntoRootRight_AtRootRightRight_CheckContains()
        {
            IBinarySearchTree<int> tree = this.InitRootRight();
            tree.Insert(100);
            Assert.IsTrue(tree.Contains(100));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Insert_ThirdNode_IntoRootRight_AtRootRightLeft_CheckCount()
        {
            IBinarySearchTree<int> tree = this.InitRootRight();
            tree.Insert(62);

            Assert.AreEqual<int>(3, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Insert_ThirdNode_IntoRootRight_AtRootRightLeft_CheckHeight()
        {
            IBinarySearchTree<int> tree = this.InitRootRight();
            tree.Insert(62);

            Assert.AreEqual<int>(GetExpected_Insert_ThirdNode_IntoRootRight_AtRootRightLeft_CheckHeight(), tree.Height);
        }

        protected virtual int GetExpected_Insert_ThirdNode_IntoRootRight_AtRootRightLeft_CheckHeight()
        {
            return 2;
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Insert_ThirdNode_IntoRootRight_AtRootRightLeft_CheckBalance()
        {
            IBinarySearchTree<int> tree = this.InitRootRight();
            tree.Insert(62);

            Assert.AreEqual<int>(GetExpected_Insert_ThirdNode_IntoRootRight_AtRootRightLeft_CheckBalance(), tree.Balance);
        }

        protected virtual int GetExpected_Insert_ThirdNode_IntoRootRight_AtRootRightLeft_CheckBalance()
        {
            return -2;
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Insert_ThirdNode_IntoRootRight_AtRootRightLeft_CheckContains()
        {
            IBinarySearchTree<int> tree = this.InitRootRight();
            tree.Insert(62);
            Assert.IsTrue(tree.Contains(62));
        }

        #endregion

        #region Insert Duplicate

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        [ExpectedException(typeof(ArgumentException))]
        public virtual void Insert_DuplicateAtRoot_OfThreeNodesFull()
        {
            IBinarySearchTree<int> tree = this.InitThreeNodesFull();
            tree.Insert(50);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        [ExpectedException(typeof(ArgumentException))]
        public virtual void Insert_DuplicateInMiddle_OfFourNodesLeftLeft()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesLeftLeft();
            tree.Insert(25);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        [ExpectedException(typeof(ArgumentException))]
        public virtual void Insert_DuplicateInMiddle_OfFourNodesLeftRight()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesLeftRight();
            tree.Insert(25);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        [ExpectedException(typeof(ArgumentException))]
        public virtual void Insert_DuplicateInMiddle_OfFourNodesRightLeft()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesRightLeft();
            tree.Insert(75);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        [ExpectedException(typeof(ArgumentException))]
        public virtual void Insert_DuplicateInMiddle_OfFourNodesRightRight()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesRightRight();
            tree.Insert(75);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        [ExpectedException(typeof(ArgumentException))]
        public virtual void Insert_DuplicateAsLeaf_OfFourNodesLeftLeft()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesLeftLeft();
            tree.Insert(25);
        }

        #endregion

        #region InsertIfNotDuplicate

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void InsertIfNotDuplicate_Failed_CheckCount()
        {
            IBinarySearchTree<int> tree = this.InitRootOnly();
            Assert.IsFalse(tree.InsertIfNotDuplicate(50));
            Assert.AreEqual<int>(1, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void InsertIfNotDuplicate_AtRoot_CheckCount()
        {
            IBinarySearchTree<int> tree = this.InitEmptyTree();
            Assert.IsTrue(tree.InsertIfNotDuplicate(50));
            Assert.AreEqual<int>(1, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void InsertIfNotDuplicate_AtRoot_CheckContains()
        {
            IBinarySearchTree<int> tree = this.InitEmptyTree();
            Assert.IsTrue(tree.InsertIfNotDuplicate(50));
            Assert.IsTrue(tree.Contains(50));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void InsertIfNotDuplicate_AtLeftLeaf_CheckCount()
        {
            IBinarySearchTree<int> tree = this.InitRootOnly();
            Assert.IsTrue(tree.InsertIfNotDuplicate(25));
            Assert.AreEqual<int>(2, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void InsertIfNotDuplicate_AtLeftLeaf_CheckContains()
        {
            IBinarySearchTree<int> tree = this.InitRootOnly();
            Assert.IsTrue(tree.InsertIfNotDuplicate(25));
            Assert.IsTrue(tree.Contains(25));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void InsertIfNotDuplicate_AtRightLeaf_CheckCount()
        {
            IBinarySearchTree<int> tree = this.InitRootOnly();
            Assert.IsTrue(tree.InsertIfNotDuplicate(75));
            Assert.AreEqual<int>(2, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void InsertIfNotDuplicate_AtRightLeaf_CheckContains()
        {
            IBinarySearchTree<int> tree = this.InitRootOnly();
            Assert.IsTrue(tree.InsertIfNotDuplicate(75));
            Assert.IsTrue(tree.Contains(75));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void InsertIfNotDuplicate_AfterLeft_CheckCount()
        {
            IBinarySearchTree<int> tree = this.InitThreeNodesFull();
            Assert.IsTrue(tree.InsertIfNotDuplicate(12));
            Assert.AreEqual<int>(4, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void InsertIfNotDuplicate_AfterLeft_CheckContains()
        {
            IBinarySearchTree<int> tree = this.InitThreeNodesFull();
            Assert.IsTrue(tree.InsertIfNotDuplicate(12));
            Assert.IsTrue(tree.Contains(12));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void InsertIfNotDuplicate_AfterRight_CheckCount()
        {
            IBinarySearchTree<int> tree = this.InitThreeNodesFull();
            Assert.IsTrue(tree.InsertIfNotDuplicate(100));
            Assert.AreEqual<int>(4, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void InsertIfNotDuplicate_AfterRight_CheckContains()
        {
            IBinarySearchTree<int> tree = this.InitThreeNodesFull();
            Assert.IsTrue(tree.InsertIfNotDuplicate(100));
            Assert.IsTrue(tree.Contains(100));
        }

        #endregion

        #endregion

        #region IBinarySearchTree.Height

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Height_Empty()
        {
            IBinarySearchTree<int> tree = this.InitEmptyTree();
            Assert.AreEqual<int>(-1, tree.Height);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Height_RootOnly()
        {
            IBinarySearchTree<int> tree = this.InitRootOnly();
            Assert.AreEqual<int>(0, tree.Height);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Height_RootLeft()
        {
            IBinarySearchTree<int> tree = this.InitRootLeft();
            Assert.AreEqual<int>(1, tree.Height);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Height_RootRight()
        {
            IBinarySearchTree<int> tree = this.InitRootRight();
            Assert.AreEqual<int>(1, tree.Height);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Height_ThreeNodesFull()
        {
            IBinarySearchTree<int> tree = this.InitThreeNodesFull();
            Assert.AreEqual<int>(1, tree.Height);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Height_FourNodesLeftLeft()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesLeftLeft();
            Assert.AreEqual<int>(2, tree.Height);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Height_FourNodesLeftRight()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesLeftRight();
            Assert.AreEqual<int>(2, tree.Height);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Height_FourNodesRightLeft()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesRightLeft();
            Assert.AreEqual<int>(2, tree.Height);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Height_FourNodesRightRight()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesRightRight();
            Assert.AreEqual<int>(2, tree.Height);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Height_FiveNodesLeftFull()
        {
            IBinarySearchTree<int> tree = this.InitFiveNodesLeftFull();
            Assert.AreEqual<int>(2, tree.Height);
        }

        #endregion

        #region IBinarySearchTree.Balance

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Balance_Empty()
        {
            IBinarySearchTree<int> tree = this.InitEmptyTree();
            Assert.AreEqual<int>(0, tree.Balance);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Balance_RootOnly()
        {
            IBinarySearchTree<int> tree = this.InitRootOnly();
            Assert.AreEqual<int>(0, tree.Balance);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Balance_RootLeft()
        {
            IBinarySearchTree<int> tree = this.InitRootLeft();
            Assert.AreEqual<int>(1, tree.Balance);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Balance_RootRight()
        {
            IBinarySearchTree<int> tree = this.InitRootRight();
            Assert.AreEqual<int>(-1, tree.Balance);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Balance_ThreeNodesFull()
        {
            IBinarySearchTree<int> tree = this.InitThreeNodesFull();
            Assert.AreEqual<int>(0, tree.Balance);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Balance_FourNodesLeftLeft()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesLeftLeft();
            Assert.AreEqual<int>(1, tree.Balance);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Balance_FourNodesLeftRight()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesLeftRight();
            Assert.AreEqual<int>(1, tree.Balance);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Balance_FourNodesRightLeft()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesRightLeft();
            Assert.AreEqual<int>(-1, tree.Balance);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Balance_FourNodesRightRight()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesRightRight();
            Assert.AreEqual<int>(-1, tree.Balance);
        }

        #endregion

        #region IBinarySearchTree.Count

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Count_Empty()
        {
            IBinarySearchTree<int> tree = this.InitEmptyTree();
            Assert.AreEqual<int>(0, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Count_RootOnly()
        {
            IBinarySearchTree<int> tree = this.InitRootOnly();
            Assert.AreEqual<int>(1, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Count_RootLeft()
        {
            IBinarySearchTree<int> tree = this.InitRootLeft();
            Assert.AreEqual<int>(2, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Count_RootRight()
        {
            IBinarySearchTree<int> tree = this.InitRootRight();
            Assert.AreEqual<int>(2, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Count_ThreeNodesFull()
        {
            IBinarySearchTree<int> tree = this.InitThreeNodesFull();
            Assert.AreEqual<int>(3, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Count_FourNodesLeftLeft()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesLeftLeft();
            Assert.AreEqual<int>(4, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Count_FourNodesLeftRight()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesLeftRight();
            Assert.AreEqual<int>(4, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Count_FourNodesRightLeft()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesRightLeft();
            Assert.AreEqual<int>(4, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Count_FourNodesRightRight()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesRightRight();
            Assert.AreEqual<int>(4, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Count_FiveNodesLeftFull()
        {
            IBinarySearchTree<int> tree = this.InitFiveNodesLeftFull();
            Assert.AreEqual<int>(5, tree.Count);
        }

        #endregion

        #region IBinarySearchTree.InOrderIterator

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void InOrderIterator_Empty()
        {
            IBinarySearchTree<int> tree = this.InitEmptyTree();
            IEnumerator<int> enumerator = tree.InOrderIterator.GetEnumerator();
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void InOrderIterator_RootOnly()
        {
            IBinarySearchTree<int> tree = this.InitRootOnly();
            IEnumerator<int> enumerator = tree.InOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void InOrderIterator_RootLeft()
        {
            IBinarySearchTree<int> tree = this.InitRootLeft();
            IEnumerator<int> enumerator = tree.InOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void InOrderIterator_RootRight()
        {
            IBinarySearchTree<int> tree = this.InitRootRight();
            IEnumerator<int> enumerator = tree.InOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void InOrderIterator_ThreeNodesFull()
        {
            IBinarySearchTree<int> tree = this.InitThreeNodesFull();
            IEnumerator<int> enumerator = tree.InOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void InOrderIterator_FourNodesLeftLeft()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesLeftLeft();
            IEnumerator<int> enumerator = tree.InOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(12, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void InOrderIterator_FourNodesLeftRight()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesLeftRight();
            IEnumerator<int> enumerator = tree.InOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(32, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void InOrderIterator_FourNodesRightLeft()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesRightLeft();
            IEnumerator<int> enumerator = tree.InOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(63, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void InOrderIterator_FourNodesRightRight()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesRightRight();
            IEnumerator<int> enumerator = tree.InOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(100, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void InOrderIterator_FiveNodesLeftFull()
        {
            IBinarySearchTree<int> tree = this.InitFiveNodesLeftFull();
            IEnumerator<int> enumerator = tree.InOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(12, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(32, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        #endregion

        #region IBinarySearchTree.PostOrderIterator

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void PostOrderIterator_Empty()
        {
            IBinarySearchTree<int> tree = this.InitEmptyTree();
            IEnumerator<int> enumerator = tree.PostOrderIterator.GetEnumerator();
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void PostOrderIterator_RootOnly()
        {
            IBinarySearchTree<int> tree = this.InitRootOnly();
            IEnumerator<int> enumerator = tree.PostOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void PostOrderIterator_RootLeft()
        {
            IBinarySearchTree<int> tree = this.InitRootLeft();
            IEnumerator<int> enumerator = tree.PostOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void PostOrderIterator_RootRight()
        {
            IBinarySearchTree<int> tree = this.InitRootRight();
            IEnumerator<int> enumerator = tree.PostOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void PostOrderIterator_ThreeNodesFull()
        {
            IBinarySearchTree<int> tree = this.InitThreeNodesFull();
            IEnumerator<int> enumerator = tree.PostOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void PostOrderIterator_FourNodesLeftLeft()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesLeftLeft();
            IEnumerator<int> enumerator = tree.PostOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(12, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void PostOrderIterator_FourNodesLeftRight()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesLeftRight();
            IEnumerator<int> enumerator = tree.PostOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(32, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void PostOrderIterator_FourNodesRightLeft()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesRightLeft();
            IEnumerator<int> enumerator = tree.PostOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(63, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void PostOrderIterator_FourNodesRightRight()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesRightRight();
            IEnumerator<int> enumerator = tree.PostOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(100, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void PostOrderIterator_FiveNodesLeftFull()
        {
            IBinarySearchTree<int> tree = this.InitFiveNodesLeftFull();
            IEnumerator<int> enumerator = tree.PostOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(12, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(32, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        #endregion

        #region IBinarySearchTree.PreOrderIterator

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void PreOrderIterator_Empty()
        {
            IBinarySearchTree<int> tree = this.InitEmptyTree();
            IEnumerator<int> enumerator = tree.PreOrderIterator.GetEnumerator();
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void PreOrderIterator_RootOnly()
        {
            IBinarySearchTree<int> tree = this.InitRootOnly();
            IEnumerator<int> enumerator = tree.PreOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void PreOrderIterator_RootLeft()
        {
            IBinarySearchTree<int> tree = this.InitRootLeft();
            IEnumerator<int> enumerator = tree.PreOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void PreOrderIterator_RootRight()
        {
            IBinarySearchTree<int> tree = this.InitRootRight();
            IEnumerator<int> enumerator = tree.PreOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void PreOrderIterator_ThreeNodesFull()
        {
            IBinarySearchTree<int> tree = this.InitThreeNodesFull();
            IEnumerator<int> enumerator = tree.PreOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void PreOrderIterator_FourNodesLeftLeft()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesLeftLeft();
            IEnumerator<int> enumerator = tree.PreOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(12, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void PreOrderIterator_FourNodesLeftRight()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesLeftRight();
            IEnumerator<int> enumerator = tree.PreOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(32, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void PreOrderIterator_FourNodesRightLeft()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesRightLeft();
            IEnumerator<int> enumerator = tree.PreOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(63, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void PreOrderIterator_FourNodesRightRight()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesRightRight();
            IEnumerator<int> enumerator = tree.PreOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(100, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void PreOrderIterator_FiveNodesLeftFull()
        {
            IBinarySearchTree<int> tree = this.InitFiveNodesLeftFull();
            IEnumerator<int> enumerator = tree.PreOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(12, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(32, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        #endregion

        #region IBinarySearchTree.Contains
        
        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Contains_EmptyTree()
        {
            IBinarySearchTree<int> tree = this.InitEmptyTree();
            Assert.IsFalse(tree.Contains(50));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Contains_RootOnly_NotFound()
        {
            IBinarySearchTree<int> tree = this.InitRootOnly();
            Assert.IsFalse(tree.Contains(60));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Contains_RootOnly_Found()
        {
            IBinarySearchTree<int> tree = this.InitRootOnly();
            Assert.IsTrue(tree.Contains(50));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Contains_RootLeft_FoundLeaf()
        {
            IBinarySearchTree<int> tree = this.InitRootLeft();
            Assert.IsTrue(tree.Contains(25));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Contains_RootRight_FoundLeaf()
        {
            IBinarySearchTree<int> tree = this.InitRootRight();
            Assert.IsTrue(tree.Contains(75));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Contains_ThreeNodesFull_FoundLeftLeaf()
        {
            IBinarySearchTree<int> tree = this.InitThreeNodesFull();
            Assert.IsTrue(tree.Contains(25));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Contains_ThreeNodesFull_FoundRightLeaf()
        {
            IBinarySearchTree<int> tree = this.InitThreeNodesFull();
            Assert.IsTrue(tree.Contains(75));
        }
        
        #endregion

        #region IBinarySearchTree.Find

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Find_EmptyTree()
        {
            IBinarySearchTree<int> tree = this.InitEmptyTree();
            Assert.AreEqual<int>(0, tree.Find(50));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Find_RootOnly_NotFound()
        {
            IBinarySearchTree<int> tree = this.InitRootOnly();
            Assert.AreEqual<int>(0, tree.Find(60));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Find_RootOnly_Found()
        {
            IBinarySearchTree<int> tree = this.InitRootOnly();
            Assert.AreEqual<int>(50, tree.Find(50));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Find_RootLeft_FoundLeaf()
        {
            IBinarySearchTree<int> tree = this.InitRootLeft();
            Assert.AreEqual<int>(25, tree.Find(25));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Find_RootRight_FoundLeaf()
        {
            IBinarySearchTree<int> tree = this.InitRootRight();
            Assert.AreEqual<int>(75, tree.Find(75));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Find_ThreeNodesFull_FoundLeftLeaf()
        {
            IBinarySearchTree<int> tree = this.InitThreeNodesFull();
            Assert.AreEqual<int>(25, tree.Find(25));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Find_ThreeNodesFull_FoundRightLeaf()
        {
            IBinarySearchTree<int> tree = this.InitThreeNodesFull();
            Assert.AreEqual(75, tree.Find(75));
        }
        
        #endregion

        #region ICollection

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Add_CheckCount()
        {
            ICollection<int> tree = (ICollection<int>)this.InitEmptyTree();
            
            tree.Add(50);
            Assert.AreEqual<int>(1, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Clear_CheckCount()
        {
            ICollection<int> tree = (ICollection<int>)this.InitFourNodesLeftLeft();

            tree.Clear();
            Assert.AreEqual<int>(0, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Clear_Contains_Fails()
        {
            ICollection<int> tree = (ICollection<int>)this.InitFourNodesLeftLeft();

            tree.Clear();
            Assert.IsFalse( tree.Contains(50));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Contains_Succeeds()
        {
            ICollection<int> tree = (ICollection<int>)this.InitFourNodesLeftLeft();

            Assert.IsTrue(tree.Contains(50));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Contains_Fails()
        {
            ICollection<int> tree = (ICollection<int>)this.InitFourNodesLeftLeft();

            Assert.IsFalse(tree.Contains(11));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void CopyTo_Succeeds()
        {
            ICollection<int> tree = (ICollection<int>)this.InitFourNodesLeftLeft();

            int[] values = new int[tree.Count];
            tree.CopyTo(values, 0);

            Assert.AreEqual(12, values[0]);
            Assert.AreEqual(25, values[1]);
            Assert.AreEqual(50, values[2]);
            Assert.AreEqual(75, values[3]);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void IsReadOnly()
        {
            ICollection<int> tree = (ICollection<int>)this.InitFourNodesLeftLeft();
            Assert.IsFalse(tree.IsReadOnly);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Remove_Fails()
        {
            ICollection<int> tree = (ICollection<int>)this.InitEmptyTree();
            Assert.IsFalse(tree.Remove(50));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Remove_Succeeds_CheckCount()
        {
            ICollection<int> tree = (ICollection<int>)this.InitRootOnly();
            Assert.IsTrue(tree.Remove(50));
            Assert.AreEqual(0, tree.Count);
        }

        #endregion

        #region IEnumerable

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void GetEnumeratorGeneric()
        {
            IEnumerable<int> tree = (IEnumerable<int>)this.InitThreeNodesFull();
            IEnumerator<int> enumerator = tree.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual(50, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual(75, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void GetEnumerator()
        {
            IEnumerable tree = (IEnumerable)this.InitThreeNodesFull();
            IEnumerator enumerator = tree.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual(50, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual(75, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        #endregion

        #region BinarySearchTree.Delete

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_EmptyTree()
        {
            IBinarySearchTree<int> tree = this.InitEmptyTree();
            Assert.IsFalse(tree.Delete(50));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_RootOnly_NotFound()
        {
            IBinarySearchTree<int> tree = this.InitRootOnly();
            Assert.IsFalse(tree.Delete(60));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_RootOnly_Found_CheckCount()
        {
            IBinarySearchTree<int> tree = this.InitRootOnly();
            Assert.IsTrue(tree.Delete(50));
            Assert.AreEqual<int>(0, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_RootOnly_Found_CheckHeight()
        {
            IBinarySearchTree<int> tree = this.InitRootOnly();
            Assert.IsTrue(tree.Delete(50));
            Assert.AreEqual<int>(-1, tree.Height);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_RootOnly_Found_CheckBalance()
        {
            IBinarySearchTree<int> tree = this.InitRootOnly();
            Assert.IsTrue(tree.Delete(50));
            Assert.AreEqual<int>(0, tree.Balance);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_RootOnly_Found_CheckContains()
        {
            IBinarySearchTree<int> tree = this.InitRootOnly();
            Assert.IsTrue(tree.Delete(50));
            Assert.IsFalse(tree.Contains(50));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_RootLeft_NotFound1()
        {
            IBinarySearchTree<int> tree = this.InitRootLeft();
            Assert.IsFalse(tree.Delete(10));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_RootLeft_NotFound2()
        {
            IBinarySearchTree<int> tree = this.InitRootLeft();
            Assert.IsFalse(tree.Delete(30));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_RootLeft_NotFound3()
        {
            IBinarySearchTree<int> tree = this.InitRootLeft();
            Assert.IsFalse(tree.Delete(75));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_RootRight_NotFound1()
        {
            IBinarySearchTree<int> tree = this.InitRootRight();
            Assert.IsFalse(tree.Delete(25));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_RootRight_NotFound2()
        {
            IBinarySearchTree<int> tree = this.InitRootRight();
            Assert.IsFalse(tree.Delete(60));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_RootRight_NotFound3()
        {
            IBinarySearchTree<int> tree = this.InitRootRight();
            Assert.IsFalse(tree.Delete(100));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_RootLeft_Root_CheckCount()
        {
            IBinarySearchTree<int> tree = this.InitRootLeft();
            Assert.IsTrue(tree.Delete(50));

            Assert.AreEqual<int>(1, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_RootLeft_Root_CheckHeight()
        {
            IBinarySearchTree<int> tree = this.InitRootLeft();
            Assert.IsTrue(tree.Delete(50));

            Assert.AreEqual<int>(0, tree.Height);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_RootLeft_Root_CheckBalance()
        {
            IBinarySearchTree<int> tree = this.InitRootLeft();
            Assert.IsTrue(tree.Delete(50));

            Assert.AreEqual<int>(0, tree.Balance);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_RootLeft_Root_CheckContains()
        {
            IBinarySearchTree<int> tree = this.InitRootLeft();
            Assert.IsTrue(tree.Delete(50));
            Assert.IsFalse(tree.Contains(50));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_RootRight_Root_CheckCount()
        {
            IBinarySearchTree<int> tree = this.InitRootRight();
            Assert.IsTrue( tree.Delete(50));

            Assert.AreEqual<int>(1, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_RootRight_Root_CheckHeight()
        {
            IBinarySearchTree<int> tree = this.InitRootRight();
            Assert.IsTrue(tree.Delete(50));

            Assert.AreEqual<int>(0, tree.Height);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_RootRight_Root_CheckBalance()
        {
            IBinarySearchTree<int> tree = this.InitRootRight();
            Assert.IsTrue(tree.Delete(50));

            Assert.AreEqual<int>(0, tree.Balance);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_RootRight_Root_CheckContains()
        {
            IBinarySearchTree<int> tree = this.InitRootRight();
            Assert.IsTrue(tree.Delete(50));
            Assert.IsFalse(tree.Contains(50));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_ThreeNodesFull_Root_CheckCount()
        {
            IBinarySearchTree<int> tree = this.InitThreeNodesFull();
            Assert.IsTrue(tree.Delete(50));

            Assert.AreEqual<int>(2, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_ThreeNodesFull_Root_CheckHeight()
        {
            IBinarySearchTree<int> tree = this.InitThreeNodesFull();
            Assert.IsTrue(tree.Delete(50));

            Assert.AreEqual<int>(1, tree.Height);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_ThreeNodesFull_Root_CheckBalance()
        {
            IBinarySearchTree<int> tree = this.InitThreeNodesFull();
            Assert.IsTrue(tree.Delete(50));

            Assert.AreEqual<int>(-1, tree.Balance);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_ThreeNodesFull_Root_CheckContains()
        {
            IBinarySearchTree<int> tree = this.InitThreeNodesFull();
            Assert.IsTrue(tree.Delete(50));
            Assert.IsFalse(tree.Contains(50));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_FiveNodesLeftFull_NonRootWithFullChildren_CheckCount()
        {
            IBinarySearchTree<int> tree = this.InitFiveNodesLeftFull();
            Assert.IsTrue(tree.Delete(25));

            Assert.AreEqual<int>(4, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_FiveNodesLeftFull_NonRootWithFullChildren_CheckHeight()
        {
            IBinarySearchTree<int> tree = this.InitFiveNodesLeftFull();
            Assert.IsTrue(tree.Delete(25));

            Assert.AreEqual<int>(2, tree.Height);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_FiveNodesLeftFull_NonRootWithFullChildren_CheckBalance()
        {
            IBinarySearchTree<int> tree = this.InitFiveNodesLeftFull();
            Assert.IsTrue(tree.Delete(25));

            Assert.AreEqual<int>(1, tree.Balance);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_FiveNodesLeftFull_NonRootWithFullChildren_CheckContains()
        {
            IBinarySearchTree<int> tree = this.InitFiveNodesLeftFull();
            Assert.IsTrue(tree.Delete(25));
            Assert.IsFalse(tree.Contains(25));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_RootLeft_Leaf_CheckCount()
        {
            IBinarySearchTree<int> tree = this.InitRootLeft();
            Assert.IsTrue(tree.Delete(25));
            Assert.AreEqual<int>(1, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_RootLeft_Leaf_CheckHeight()
        {
            IBinarySearchTree<int> tree = this.InitRootLeft();
            Assert.IsTrue(tree.Delete(25));
            Assert.AreEqual<int>(0, tree.Height);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_RootLeft_Leaf_CheckBalance()
        {
            IBinarySearchTree<int> tree = this.InitRootLeft();
            Assert.IsTrue(tree.Delete(25));

            Assert.AreEqual<int>(0, tree.Balance);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_RootLeft_Leaf_CheckContains()
        {
            IBinarySearchTree<int> tree = this.InitRootLeft();
            Assert.IsTrue(tree.Delete(25));
            Assert.IsFalse(tree.Contains(25));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_RootRight_Leaf_CheckCount()
        {
            IBinarySearchTree<int> tree = this.InitRootRight();
            Assert.IsTrue(tree.Delete(75));

            Assert.AreEqual<int>(1, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_RootRight_Leaf_CheckHeight()
        {
            IBinarySearchTree<int> tree = this.InitRootRight();
            Assert.IsTrue(tree.Delete(75));

            Assert.AreEqual<int>(0, tree.Height);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_RootRight_Leaf_CheckBalance()
        {
            IBinarySearchTree<int> tree = this.InitRootRight();
            Assert.IsTrue(tree.Delete(75));

            Assert.AreEqual<int>(0, tree.Balance);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_RootRight_Leaf_CheckContains()
        {
            IBinarySearchTree<int> tree = this.InitRootRight();
            Assert.IsTrue(tree.Delete(75));
            Assert.IsFalse(tree.Contains(75));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_ThreeNodesFull_LeftLeaf_CheckCount()
        {
            IBinarySearchTree<int> tree = this.InitThreeNodesFull();
            Assert.IsTrue(tree.Delete(25));

            Assert.AreEqual<int>(2, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_ThreeNodesFull_LeftLeaf_CheckHeight()
        {
            IBinarySearchTree<int> tree = this.InitThreeNodesFull();
            Assert.IsTrue(tree.Delete(25));

            Assert.AreEqual<int>(1, tree.Height);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_ThreeNodesFull_LeftLeaf_CheckBalance()
        {
            IBinarySearchTree<int> tree = this.InitThreeNodesFull();
            Assert.IsTrue(tree.Delete(25));

            Assert.AreEqual<int>(-1, tree.Balance);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_ThreeNodesFull_LeftLeaf_CheckContains()
        {
            IBinarySearchTree<int> tree = this.InitThreeNodesFull();
            Assert.IsTrue(tree.Delete(25));
            Assert.IsFalse(tree.Contains(25));
        }
        
        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_ThreeNodesFull_RightLeaf_CheckCount()
        {
            IBinarySearchTree<int> tree = this.InitThreeNodesFull();
            Assert.IsTrue(tree.Delete(75));

            Assert.AreEqual<int>(2, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_ThreeNodesFull_RightLeaf_CheckHeight()
        {
            IBinarySearchTree<int> tree = this.InitThreeNodesFull();
            Assert.IsTrue(tree.Delete(75));

            Assert.AreEqual<int>(1, tree.Height);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_ThreeNodesFull_RightLeaf_CheckBalance()
        {
            IBinarySearchTree<int> tree = this.InitThreeNodesFull();
            Assert.IsTrue(tree.Delete(75));

            Assert.AreEqual<int>(1, tree.Balance);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_ThreeNodesFull_RightLeaf_CheckContains()
        {
            IBinarySearchTree<int> tree = this.InitThreeNodesFull();
            Assert.IsTrue(tree.Delete(75));
            Assert.IsFalse(tree.Contains(75));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_FourNodesLeftLeft_HasParentAndChild_CheckCount()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesLeftLeft();
            Assert.IsTrue(tree.Delete(25));

            Assert.AreEqual<int>(3, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_FourNodesLeftLeft_HasParentAndChild_CheckHeight()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesLeftLeft();
            Assert.IsTrue(tree.Delete(25));

            Assert.AreEqual<int>(1, tree.Height);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_FourNodesLeftLeft_HasParentAndChild_CheckBalance()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesLeftLeft();
            Assert.IsTrue(tree.Delete(25));

            Assert.AreEqual<int>(0, tree.Balance);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_FourNodesLeftLeft_HasParentAndChild_CheckContains()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesLeftLeft();
            Assert.IsTrue(tree.Delete(25));
            Assert.IsFalse(tree.Contains(25));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_FourNodesLeftLeft_Right_CheckCount()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesLeftLeft();
            Assert.IsTrue(tree.Delete(75));

            Assert.AreEqual<int>(3, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_FourNodesLeftLeft_Right_CheckHeight()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesLeftLeft();
            Assert.IsTrue(tree.Delete(75));

            Assert.AreEqual<int>(GetExpected_Delete_FourNodesLeftLeft_Right_CheckHeight(), tree.Height);
        }

        protected virtual int GetExpected_Delete_FourNodesLeftLeft_Right_CheckHeight()
        {
            return 2;
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_FourNodesLeftLeft_Right_CheckBalance()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesLeftLeft();
            Assert.IsTrue(tree.Delete(75));

            Assert.AreEqual<int>(GetExpected_Delete_FourNodesLeftLeft_Right_CheckBalance(), tree.Balance);
        }

        protected virtual int GetExpected_Delete_FourNodesLeftLeft_Right_CheckBalance()
        {
            return 2;
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_FourNodesLeftLeft_Right_CheckContains()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesLeftLeft();
            Assert.IsTrue(tree.Delete(75));
            Assert.IsFalse(tree.Contains(75));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_FourNodesLeftRight_Right_CheckCount()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesLeftRight();
            Assert.IsTrue(tree.Delete(75));

            Assert.AreEqual<int>(3, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_FourNodesLeftRight_Right_CheckHeight()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesLeftRight();
            Assert.IsTrue(tree.Delete(75));

            Assert.AreEqual<int>(GetExpected_Delete_FourNodesLeftRight_Right_CheckHeight(), tree.Height);
        }

        protected virtual int GetExpected_Delete_FourNodesLeftRight_Right_CheckHeight()
        {
            return 2;
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_FourNodesLeftRight_Right_CheckBalance()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesLeftLeft();
            Assert.IsTrue(tree.Delete(75));

            Assert.AreEqual<int>(GetExpected_Delete_FourNodesLeftRight_Right_CheckBalance(), tree.Balance);
        }

        protected virtual int GetExpected_Delete_FourNodesLeftRight_Right_CheckBalance()
        {
            return 2;
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_FourNodesLeftRight_Right_CheckContains()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesLeftLeft();
            Assert.IsTrue(tree.Delete(75));
            Assert.IsFalse(tree.Contains(75));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_FourNodesRightRight_Left_CheckCount()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesRightRight();
            Assert.IsTrue(tree.Delete(25));

            Assert.AreEqual<int>(3, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_FourNodesRightRight_Left_CheckHeight()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesRightRight();
            Assert.IsTrue(tree.Delete(25));

            Assert.AreEqual<int>(GetExpected_Delete_FourNodesRightRight_Left_CheckHeight(), tree.Height);
        }

        protected virtual int GetExpected_Delete_FourNodesRightRight_Left_CheckHeight()
        {
            return 2;
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_FourNodesRightRight_Left_CheckBalance()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesRightRight();
            Assert.IsTrue(tree.Delete(25));

            Assert.AreEqual<int>(GetExpected_Delete_FourNodesRightRight_Left_CheckBalance(), tree.Balance);
        }

        protected virtual int GetExpected_Delete_FourNodesRightRight_Left_CheckBalance()
        {
            return -2;
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_FourNodesRightRight_Left_CheckContains()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesRightRight();
            Assert.IsTrue(tree.Delete(25));
            Assert.IsFalse(tree.Contains(25));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_FourNodesRightLeft_Left_CheckCount()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesRightLeft();
            Assert.IsTrue(tree.Delete(25));

            Assert.AreEqual<int>(3, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_FourNodesRightLeft_Left_CheckHeight()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesRightLeft();
            Assert.IsTrue(tree.Delete(25));

            Assert.AreEqual<int>(GetExpected_Delete_FourNodesRightLeft_Left_CheckHeight(), tree.Height);
        }

        protected virtual int GetExpected_Delete_FourNodesRightLeft_Left_CheckHeight()
        {
            return 2;
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_FourNodesRightLeft_Left_CheckBalance()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesRightLeft();
            Assert.IsTrue(tree.Delete(25));

            Assert.AreEqual<int>(GetExpected_Delete_FourNodesRightLeft_Left_CheckBalance(), tree.Balance);
        }

        protected virtual int GetExpected_Delete_FourNodesRightLeft_Left_CheckBalance()
        {
            return -2;
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_FourNodesRightLeft_Left_CheckContains()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesRightLeft();
            Assert.IsTrue(tree.Delete(25));
            Assert.IsFalse(tree.Contains(25));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_FourNodesLeftRight_HasParentAndChild_CheckCount()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesLeftRight();
            Assert.IsTrue(tree.Delete(25));

            Assert.AreEqual<int>(3, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_FourNodesLeftRight_HasParentAndChild_CheckHeight()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesLeftRight();
            Assert.IsTrue(tree.Delete(25));

            Assert.AreEqual<int>(1, tree.Height);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_FourNodesLeftRight_HasParentAndChild_CheckBalance()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesLeftRight();
            Assert.IsTrue(tree.Delete(25));

            Assert.AreEqual<int>(0, tree.Balance);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_FourNodesLeftRight_HasParentAndChild_CheckContains()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesLeftRight();
            Assert.IsTrue(tree.Delete(25));
            Assert.IsFalse(tree.Contains(25));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_FourNodesRightLeft_HasParentAndChild_CheckCount()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesRightLeft();
            Assert.IsTrue(tree.Delete(75));

            Assert.AreEqual<int>(3, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_FourNodesRightLeft_HasParentAndChild_CheckHeight()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesRightLeft();
            Assert.IsTrue(tree.Delete(75));

            Assert.AreEqual<int>(1, tree.Height);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_FourNodesRightLeft_HasParentAndChild_CheckBalance()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesRightLeft();
            Assert.IsTrue(tree.Delete(75));

            Assert.AreEqual<int>(0, tree.Balance);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_FourNodesRightLeft_HasParentAndChild_CheckContains()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesRightLeft();
            Assert.IsTrue(tree.Delete(75));
            Assert.IsFalse(tree.Contains(75));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_FourNodesRightRight_HasParentAndChild_CheckCount()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesRightRight();
            Assert.IsTrue(tree.Delete(75));

            Assert.AreEqual<int>(3, tree.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_FourNodesRightRight_HasParentAndChild_CheckHeight()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesRightRight();
            Assert.IsTrue(tree.Delete(75));

            Assert.AreEqual<int>(1, tree.Height);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_FourNodesRightRight_HasParentAndChild_CheckBalance()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesRightRight();
            Assert.IsTrue(tree.Delete(75));

            Assert.AreEqual<int>(0, tree.Balance);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Delete_FourNodesRightRight_HasParentAndChild_CheckContains()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesRightRight();
            Assert.IsTrue(tree.Delete(75));
            Assert.IsFalse(tree.Contains(75));
        }

        #endregion

        #region BinarySearchTree.Depth

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        [ExpectedException(typeof(ValueNotFoundException))]
        public virtual void Depth_Empty()
        {
            IBinarySearchTree<int> tree = this.InitEmptyTree();
            tree.Depth(50);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Depth_RootOnly()
        {
            IBinarySearchTree<int> tree = this.InitRootOnly();
            Assert.AreEqual<int>(0, tree.Depth(50));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        [ExpectedException(typeof(ValueNotFoundException))]
        public virtual void Depth_RootOnly_NotFound1()
        {
            IBinarySearchTree<int> tree = this.InitRootOnly();
            tree.Depth(25);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        [ExpectedException(typeof(ValueNotFoundException))]
        public virtual void Depth_RootOnly_NotFound2()
        {
            IBinarySearchTree<int> tree = this.InitRootOnly();
            tree.Depth(75);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Depth_RootLeft1()
        {
            IBinarySearchTree<int> tree = this.InitRootLeft();
            Assert.AreEqual<int>(0, tree.Depth(50));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Depth_RootLeft2()
        {
            IBinarySearchTree<int> tree = this.InitRootLeft();
            Assert.AreEqual<int>(1, tree.Depth(25));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Depth_RootRight1()
        {
            IBinarySearchTree<int> tree = this.InitRootRight();
            Assert.AreEqual<int>(0, tree.Depth(50));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Depth_RootRight2()
        {
            IBinarySearchTree<int> tree = this.InitRootRight();
            Assert.AreEqual<int>(1, tree.Depth(75));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Depth_ThreeNodesFull1()
        {
            IBinarySearchTree<int> tree = this.InitThreeNodesFull();
            Assert.AreEqual<int>(0, tree.Depth(50));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Depth_ThreeNodesFull2()
        {
            IBinarySearchTree<int> tree = this.InitThreeNodesFull();
            Assert.AreEqual<int>(1, tree.Depth(25));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Depth_ThreeNodesFull3()
        {
            IBinarySearchTree<int> tree = this.InitThreeNodesFull();
            Assert.AreEqual<int>(1, tree.Depth(75));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Depth_FourNodesLeftLeft()
        {
            IBinarySearchTree<int> tree = InitFourNodesLeftLeft();
            Assert.AreEqual<int>(2, tree.Depth(12));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Depth_FourNodesLeftRight()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesLeftRight();
            Assert.AreEqual<int>(2, tree.Depth(32));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Depth_FourNodesRightLeft()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesRightLeft();
            Assert.AreEqual<int>(2, tree.Depth(63));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Depth_FourNodesRightRight()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesRightRight();
            Assert.AreEqual<int>(2, tree.Depth(100));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void Depth_FiveNodesLeftFull()
        {
            IBinarySearchTree<int> tree = this.InitFiveNodesLeftFull();
            Assert.AreEqual<int>(2, tree.Depth(32));
        }

        #endregion

        #region BinarySearchTree.AssertTree

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void AssertValidTree_Empty()
        {
            IBinarySearchTree<int> tree = this.InitEmptyTree();
            tree.AssertValidTree();
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void AssertValidTree_RootOnly()
        {
            IBinarySearchTree<int> tree = this.InitRootOnly();
            tree.AssertValidTree();
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void AssertValidTree_RootLeft()
        {
            IBinarySearchTree<int> tree = this.InitRootLeft();
            tree.AssertValidTree();
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void AssertValidTree_RootRight()
        {
            IBinarySearchTree<int> tree = this.InitRootRight();
            tree.AssertValidTree();
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void AssertValidTree_ThreeNodesFull()
        {
            IBinarySearchTree<int> tree = this.InitThreeNodesFull();
            tree.AssertValidTree();
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void AssertValidTree_FourNodesLeftLeft()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesLeftLeft();
            tree.AssertValidTree();
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void AssertValidTree_FourNodesLeftRight()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesLeftRight();
            tree.AssertValidTree();
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void AssertValidTree_FourNodesRightLeft()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesRightLeft();
            tree.AssertValidTree();
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void AssertValidTree_FourNodesRightRight()
        {
            IBinarySearchTree<int> tree = this.InitFourNodesRightRight();
            tree.AssertValidTree();
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        public virtual void AssertValidTree_FiveNodesLeftFull()
        {
            IBinarySearchTree<int> tree = this.InitFiveNodesLeftFull();
            tree.AssertValidTree();
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\IBinarySearchTree")]
        [ExpectedException(typeof(InvalidTreeException))]
        public virtual void AssertValidTree_BadTree()
        {
            IBinarySearchTree<int> tree = this.InitBadTree();
            tree.AssertValidTree();
        }

        #endregion
    }
}
