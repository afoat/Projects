using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Foat.Collections.Generic;
using Microsoft.QualityTools.Testing.Fakes;
using System.Collections;

namespace Foat.Collections.Tests
{
    [TestClass]
    public class SkipListTests
    {
        #region Setup

        private SkipList<int, int> Init2HighListContains3(IRandom random)
        {
            SkipList<int, int> skipList = new SkipList<int, int>(random) { Count = 3, Levels = 2 };

            SkipListNode<int, int> node1 = new SkipListNode<int, int>(1, 50, 50);
            SkipListNode<int, int> node2 = new SkipListNode<int, int>(1, 100, 100);
            SkipListNode<int, int> node3 = new SkipListNode<int, int>(2, 200, 200);


            node1.Next[0] = node2;
            node2.Next[0] = node3;

            skipList.Head.Next[0] = node1;
            skipList.Head.Next[1] = node3;

            return skipList;
        }

        private SkipList<int, int> Init2HighListContains4(IRandom random)
        {
            SkipList<int, int> skipList = new SkipList<int, int>(random) { Count = 4, Levels = 2 };

            SkipListNode<int, int> node1 = new SkipListNode<int, int>(1, 50, 50);
            SkipListNode<int, int> node2 = new SkipListNode<int, int>(1, 100, 100);
            SkipListNode<int, int> node3 = new SkipListNode<int, int>(2, 200, 200);
            SkipListNode<int, int> node4 = new SkipListNode<int, int>(1, 300, 200);


            node1.Next[0] = node2;
            node2.Next[0] = node3;
            node3.Next[0] = node4;

            skipList.Head.Next[0] = node1;
            skipList.Head.Next[1] = node3;

            return skipList;
        }

        #endregion

        #region Insert

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void Constructor_CheckCount()
        {
            SkipList<int, int> skipList = new SkipList<int, int>();
            Assert.AreEqual<int>(0, skipList.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void Constructor_CheckLevels()
        {
            SkipList<int, int> skipList = new SkipList<int, int>();
            Assert.AreEqual<int>(1, skipList.Levels);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void Constructor_CheckMaxLevels()
        {
            SkipList<int, int> skipList = new SkipList<int, int>();
            Assert.AreEqual<int>(1, skipList.MaxLevels);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void Insert_IntoEmpty_CheckCount()
        {
            IRandom random = new Foat.Fakes.StubIRandom()
            {
                Next = () => { return 1; }
            };

            SkipList<int, int> skipList = new SkipList<int, int>(random);
            skipList.Insert(50, 50);

            Assert.AreEqual(1, skipList.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void Insert_IntoEmpty_CheckLevels()
        {
            IRandom random = new Foat.Fakes.StubIRandom()
            {
                Next = () => { return 1; }
            };

            SkipList<int, int> skipList = new SkipList<int, int>(random);
            skipList.Insert(50, 50);

            Assert.AreEqual(1, skipList.Levels);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void Insert_IntoEmpty_CheckMaxLevels()
        {
            IRandom random = new Foat.Fakes.StubIRandom()
            {
                Next = () => { return 1; }
            };

            SkipList<int, int> skipList = new SkipList<int, int>(random);
            skipList.Insert(50, 50);

            Assert.AreEqual(1, skipList.MaxLevels);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void Insert_IntoEmpty_ContainsKey()
        {
            IRandom random = new Foat.Fakes.StubIRandom()
            {
                Next = () => { return 1; }
            };

            SkipList<int, int> skipList = new SkipList<int, int>(random);
            skipList.Insert(50, 50);
            Assert.IsTrue(skipList.ContainsKey(50));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void Insert_SkipSome_CheckCount()
        {
            IRandom random = new Foat.Fakes.StubIRandom()
            {
                Next = () => { return 1; }
            };

            SkipList<int, int> skipList = Init2HighListContains3(random);

            skipList.Insert(300, 300);

            Assert.AreEqual(4, skipList.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void Insert_SkipSome_CheckLevels()
        {
            IRandom random = new Foat.Fakes.StubIRandom()
            {
                Next = () => { return 1; }
            };

            SkipList<int, int> skipList = Init2HighListContains3(random);

            skipList.Insert(300, 300);

            Assert.AreEqual(2, skipList.Levels);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void Insert_SkipSome_CheckMaxLevels()
        {
            IRandom random = new Foat.Fakes.StubIRandom()
            {
                Next = () => { return 1; }
            };

            SkipList<int, int> skipList = Init2HighListContains3(random);

            skipList.Insert(300, 300);

            Assert.AreEqual(3, skipList.MaxLevels);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void Insert_SkipSome_ContainsKey()
        {
            IRandom random = new Foat.Fakes.StubIRandom()
            {
                Next = () => { return 1; }
            };

            SkipList<int, int> skipList = Init2HighListContains3(random);

            skipList.Insert(300, 300);
            Assert.IsTrue(skipList.ContainsKey(300));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void Insert_Taller_CheckCount()
        {
            IRandom random = new Foat.Fakes.StubIRandom()
            {
                Next = () => { return 2; }
            };

            SkipList<int, int> skipList = Init2HighListContains4(random);

            skipList.Insert(400, 400);

            Assert.AreEqual(5, skipList.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void Insert_Taller_CheckLevels()
        {
            IRandom random = new Foat.Fakes.StubIRandom()
            {
                Next = () => { return 2; }
            };

            SkipList<int, int> skipList = Init2HighListContains4(random);

            skipList.Insert(400, 400);

            Assert.AreEqual(3, skipList.Levels);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void Insert_Taller_CheckMaxLevels()
        {
            IRandom random = new Foat.Fakes.StubIRandom()
            {
                Next = () => { return 2; }
            };

            SkipList<int, int> skipList = Init2HighListContains4(random);

            skipList.Insert(400, 400);

            Assert.AreEqual(3, skipList.MaxLevels);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void Insert_Taller_ContainsKey()
        {
            IRandom random = new Foat.Fakes.StubIRandom()
            {
                Next = () => { return 2; }
            };

            SkipList<int, int> skipList = Init2HighListContains4(random);

            skipList.Insert(400, 400);

            Assert.IsTrue(skipList.ContainsKey(400));
        }

        #endregion

        #region ContainsKey

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void ContainsKey_Start()
        {
            SkipList<int, int> skipList = Init2HighListContains4(null);
            Assert.IsTrue(skipList.ContainsKey(50));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void ContainsKey_SecondNodeFirstLevel()
        {
            SkipList<int, int> skipList = Init2HighListContains4(null);
            Assert.IsTrue(skipList.ContainsKey(100));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void ContainsKey_FirstNodeSecondLevel()
        {
            SkipList<int, int> skipList = Init2HighListContains4(null);
            Assert.IsTrue(skipList.ContainsKey(200));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void ContainsKey_LastNodeFirstLevel_AfterSecondLevel()
        {
            SkipList<int, int> skipList = Init2HighListContains4(null);
            Assert.IsTrue(skipList.ContainsKey(300));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void ContainsKey_Before_Start_Fail()
        {
            SkipList<int, int> skipList = Init2HighListContains4(null);
            Assert.IsFalse(skipList.ContainsKey(10));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void ContainsKey_Middle_Fail()
        {
            SkipList<int, int> skipList = Init2HighListContains4(null);
            Assert.IsFalse(skipList.ContainsKey(250));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void ContainsKey_End_Fail()
        {
            SkipList<int, int> skipList = Init2HighListContains4(null);
            Assert.IsFalse(skipList.ContainsKey(500));
        }

        #endregion

        #region GetValue

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void GetValue_Start()
        {
            SkipList<int, int> skipList = Init2HighListContains4(null);
            Assert.AreEqual(50, skipList.GetValue(50));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void GetValue_SecondNodeFirstLevel()
        {
            SkipList<int, int> skipList = Init2HighListContains4(null);
            Assert.AreEqual(100, skipList.GetValue(100));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void GetValue_FirstNodeSecondLevel()
        {
            SkipList<int, int> skipList = Init2HighListContains4(null);
            Assert.AreEqual(200, skipList.GetValue(200));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void GetValue_LastNodeFirstLevel_AfterSecondLevel()
        {
            SkipList<int, int> skipList = Init2HighListContains4(null);
            skipList.GetValue(300);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        [ExpectedException(typeof(ValueNotFoundException))]
        public void GetValue_Before_Start_Fail()
        {
            SkipList<int, int> skipList = Init2HighListContains4(null);
            skipList.GetValue(10);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        [ExpectedException(typeof(ValueNotFoundException))]
        public void GetValue_Middle_Fail()
        {
            SkipList<int, int> skipList = Init2HighListContains4(null);
            skipList.GetValue(250);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        [ExpectedException(typeof(ValueNotFoundException))]
        public void GetValue_End_Fail()
        {
            SkipList<int, int> skipList = Init2HighListContains4(null);
            skipList.GetValue(500);
        }

        #endregion

        #region Delete

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void Delete_FromEmpty()
        {
            SkipList<int, int> skipList = new SkipList<int, int>();
            Assert.IsFalse(skipList.Delete(50));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void Delete_Start_Level1_CheckCount()
        {
            SkipList<int, int> skipList = Init2HighListContains4(null);
            Assert.IsTrue(skipList.Delete(50));
            Assert.AreEqual(3, skipList.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void Delete_Start_Level1_CheckLevels()
        {
            SkipList<int, int> skipList = Init2HighListContains4(null);
            Assert.IsTrue(skipList.Delete(50));
            Assert.AreEqual(2, skipList.Levels);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void Delete_Start_Level1_CheckMaxLevels()
        {
            SkipList<int, int> skipList = Init2HighListContains4(null);
            Assert.IsTrue(skipList.Delete(50));
            Assert.AreEqual(2, skipList.MaxLevels);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void Delete_Start_Level1_ContainsKey_False()
        {
            SkipList<int, int> skipList = Init2HighListContains4(null);
            Assert.IsTrue(skipList.Delete(50));
            Assert.IsFalse(skipList.ContainsKey(50));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void Delete_Middle_Level1_CheckCount()
        {
            SkipList<int, int> skipList = Init2HighListContains4(null);
            Assert.IsTrue(skipList.Delete(100));
            Assert.AreEqual(3, skipList.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void Delete_Middle_Level1_CheckLevels()
        {
            SkipList<int, int> skipList = Init2HighListContains4(null);
            Assert.IsTrue(skipList.Delete(100));
            Assert.AreEqual(2, skipList.Levels);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void Delete_Middle_Level1_CheckMaxLevels()
        {
            SkipList<int, int> skipList = Init2HighListContains4(null);
            Assert.IsTrue(skipList.Delete(100));
            Assert.AreEqual(2, skipList.MaxLevels);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void Delete_Middle_Level1_ContainsKey_False()
        {
            SkipList<int, int> skipList = Init2HighListContains4(null);
            Assert.IsTrue(skipList.Delete(100));
            Assert.IsFalse(skipList.ContainsKey(100));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void Delete_End_Level1_CheckCount()
        {
            SkipList<int, int> skipList = Init2HighListContains4(null);
            Assert.IsTrue(skipList.Delete(300));
            Assert.AreEqual(3, skipList.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void Delete_End_Level1_CheckLevels()
        {
            SkipList<int, int> skipList = Init2HighListContains4(null);
            Assert.IsTrue(skipList.Delete(300));
            Assert.AreEqual(2, skipList.Levels);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void Delete_End_Level1_CheckMaxLevels()
        {
            SkipList<int, int> skipList = Init2HighListContains4(null);
            Assert.IsTrue(skipList.Delete(300));
            Assert.AreEqual(2, skipList.MaxLevels);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void Delete_End_Level1_ContainsKey_False()
        {
            SkipList<int, int> skipList = Init2HighListContains4(null);
            Assert.IsTrue(skipList.Delete(300));
            Assert.IsFalse(skipList.ContainsKey(300));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void Delete_Start_Level2_CheckCount()
        {
            SkipList<int, int> skipList = Init2HighListContains4(null);
            Assert.IsTrue(skipList.Delete(200));
            Assert.AreEqual<int>(3, skipList.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void Delete_Start_Level2_CheckLevels()
        {
            SkipList<int, int> skipList = Init2HighListContains4(null);
            Assert.IsTrue(skipList.Delete(200));
            Assert.AreEqual<int>(2, skipList.Levels);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void Delete_Start_Level2_CheckMaxLevels()
        {
            SkipList<int, int> skipList = Init2HighListContains4(null);
            Assert.IsTrue(skipList.Delete(200));
            Assert.AreEqual<int>(2, skipList.MaxLevels);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SkipList")]
        public void Delete_Start_Level2_ContainsKey_False()
        {
            SkipList<int, int> skipList = Init2HighListContains4(null);
            Assert.IsTrue(skipList.Delete(200));
            Assert.IsFalse(skipList.ContainsKey(200));
        }

        #endregion

    }
}
