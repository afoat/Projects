using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Foat.Collections.Generic;

namespace Foat.Collections.Tests
{
    [TestClass]
    public class HeapUnitTests
    {
        #region Setup

        public Heap<int> InitMaxHeapWithOneItem()
        {
            Heap<int> heap = new Heap<int>(HeapType.Max, 10);

            heap.List.Add(50);

            return heap;
        }

        public Heap<int> InitMinHeapWithOneItem()
        {
            Heap<int> heap = new Heap<int>(HeapType.Min, 10);

            heap.List.Add(50);

            return heap;
        }

        public Heap<int> InitMaxHeapWithFourItems_SecondLastLarger()
        {
            Heap<int> heap = new Heap<int>(HeapType.Max, 10);

            heap.List.Add(50);
            heap.List.Add(40);
            heap.List.Add(30);
            heap.List.Add(20);

            return heap;
        }

        public Heap<int> InitMaxHeapWithFourItems_LastLarger()
        {
            Heap<int> heap = new Heap<int>(HeapType.Max, 10);

            heap.List.Add(50);
            heap.List.Add(40);
            heap.List.Add(20);
            heap.List.Add(30);

            return heap;
        }

        public Heap<int> InitMinHeapWithFourItems_SecondLastSmaller()
        {
            Heap<int> heap = new Heap<int>(HeapType.Min, 10);

            heap.List.Add(50);
            heap.List.Add(70);
            heap.List.Add(60);
            heap.List.Add(80);

            return heap;
        }

        public Heap<int> InitMinHeapWithFourItems_LastSmaller()
        {
            Heap<int> heap = new Heap<int>(HeapType.Min, 10);

            heap.List.Add(50);
            heap.List.Add(60);
            heap.List.Add(70);
            heap.List.Add(80);

            return heap;
        }

        #endregion

        #region Construction

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\Heap")]
        public void Constructor_Default_CheckCount()
        {
            Heap<int> heap = new Heap<int>();
            Assert.AreEqual<int>(0, heap.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\Heap")]
        public void Constructor_Default_CheckType()
        {
            Heap<int> heap = new Heap<int>();
            Assert.AreEqual<HeapType>(HeapType.Max, heap.Type);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\Heap")]
        public void Constructor_MaxHeap_CheckCount()
        {
            Heap<int> heap = new Heap<int>(HeapType.Max);
            Assert.AreEqual<int>(0, heap.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\Heap")]
        public void Constructor_MaxHeap_CheckType()
        {
            Heap<int> heap = new Heap<int>(HeapType.Max);
            Assert.AreEqual<HeapType>(HeapType.Max, heap.Type);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\Heap")]
        public void Constructor_MinHeap_CheckCount()
        {
            Heap<int> heap = new Heap<int>(HeapType.Min);
            Assert.AreEqual<int>(0, heap.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\Heap")]
        public void Constructor_MinHeap_CheckType()
        {
            Heap<int> heap = new Heap<int>(HeapType.Min);
            Assert.AreEqual<HeapType>(HeapType.Min, heap.Type);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\Heap")]
        public void Constructor_MinHeapCapacity_CheckCount()
        {
            Heap<int> heap = new Heap<int>(HeapType.Min, 10);
            Assert.AreEqual<int>(0, heap.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\Heap")]
        public void Constructor_MinHeapCapacity_CheckType()
        {
            Heap<int> heap = new Heap<int>(HeapType.Min, 10);
            Assert.AreEqual<HeapType>(HeapType.Min, heap.Type);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\Heap")]
        public void Constructor_MaxHeapCapacity_CheckCount()
        {
            Heap<int> heap = new Heap<int>(HeapType.Max, 10);
            Assert.AreEqual<int>(0, heap.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\Heap")]
        public void Constructor_MaxHeapCapacity_CheckType()
        {
            Heap<int> heap = new Heap<int>(HeapType.Max, 10);
            Assert.AreEqual<HeapType>(HeapType.Max, heap.Type);
        }

        #endregion

        #region Insert

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\Heap")]
        public void Insert_IntoEmpty_CheckCount()
        {
            Heap<int> heap = new Heap<int>();
            heap.Insert(50);
            Assert.AreEqual<int>(1, heap.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\Heap")]
        public void Insert_IntoEmpty_CheckPeek()
        {
            Heap<int> heap = new Heap<int>();
            heap.Insert(50);
            Assert.AreEqual<int>(50, heap.Peek());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\Heap")]
        public void Insert_Smaller_IntoMax_CheckCount()
        {
            Heap<int> heap = InitMaxHeapWithOneItem();
            heap.Insert(10);
            Assert.AreEqual<int>(2, heap.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\Heap")]
        public void Insert_Smaller_IntoMax_CheckPeek()
        {
            Heap<int> heap = InitMaxHeapWithOneItem();
            heap.Insert(10);
            Assert.AreEqual<int>(50, heap.Peek());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\Heap")]
        public void Insert_Larger_IntoMax_CheckCount()
        {
            Heap<int> heap = InitMaxHeapWithOneItem();
            heap.Insert(100);
            Assert.AreEqual<int>(2, heap.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\Heap")]
        public void Insert_Larger_IntoMax_CheckPeek()
        {
            Heap<int> heap = InitMaxHeapWithOneItem();
            heap.Insert(100);
            Assert.AreEqual<int>(100, heap.Peek());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\Heap")]
        public void Insert_Smaller_IntoMin_CheckCount()
        {
            Heap<int> heap = InitMinHeapWithOneItem();
            heap.Insert(10);
            Assert.AreEqual<int>(2, heap.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\Heap")]
        public void Insert_Smaller_IntoMin_CheckPeek()
        {
            Heap<int> heap = InitMinHeapWithOneItem();
            heap.Insert(10);
            Assert.AreEqual<int>(10, heap.Peek());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\Heap")]
        public void Insert_Larger_IntoMin_CheckCount()
        {
            Heap<int> heap = InitMinHeapWithOneItem();
            heap.Insert(100);
            Assert.AreEqual<int>(2, heap.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\Heap")]
        public void Insert_Larger_IntoMin_CheckPeek()
        {
            Heap<int> heap = InitMinHeapWithOneItem();
            heap.Insert(100);
            Assert.AreEqual<int>(50, heap.Peek());
        }

        #endregion

        #region Peek

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\Heap")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Peek_Empty()
        {
            Heap<int> heap = new Heap<int>();
            heap.Peek();
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\Heap")]
        public void Peek_Min_Success()
        {
            Heap<int> heap = InitMinHeapWithFourItems_SecondLastSmaller();
            Assert.AreEqual<int>(50, heap.Peek());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\Heap")]
        public void Peek_Max_Success()
        {
            Heap<int> heap = InitMaxHeapWithFourItems_SecondLastLarger();
            Assert.AreEqual<int>(50, heap.Peek());
        }

        #endregion

        #region Delete

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\Heap")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Remove_Empty()
        {
            Heap<int> heap = new Heap<int>();
            heap.Remove();
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\Heap")]
        public void Remove_Only_FromMin_CheckCount()
        {
            Heap<int> heap = InitMinHeapWithOneItem();
            Assert.AreEqual<int>(50, heap.Remove());
            Assert.AreEqual<int>(0, heap.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\Heap")]
        public void Remove_Only_FromMax_CheckCount()
        {
            Heap<int> heap = InitMaxHeapWithOneItem();
            Assert.AreEqual<int>(50, heap.Remove());
            Assert.AreEqual<int>(0, heap.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\Heap")]
        public void Remove_Top_FromMin_FirstSmaller_CheckCount()
        {
            Heap<int> heap = InitMinHeapWithFourItems_SecondLastSmaller();
            Assert.AreEqual<int>(50, heap.Remove());
            Assert.AreEqual<int>(3, heap.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\Heap")]
        public void Remove_Top_FromMin_FirstSmaller_CheckPeek()
        {
            Heap<int> heap = InitMinHeapWithFourItems_SecondLastSmaller();
            Assert.AreEqual<int>(50, heap.Remove());
            Assert.AreEqual<int>(60, heap.Peek());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\Heap")]
        public void Remove_Top_FromMin_LastSmaller_CheckCount()
        {
            Heap<int> heap = InitMinHeapWithFourItems_LastSmaller();
            Assert.AreEqual<int>(50, heap.Remove());
            Assert.AreEqual<int>(3, heap.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\Heap")]
        public void Remove_Top_FromMin_LastSmaller_CheckPeek()
        {
            Heap<int> heap = InitMinHeapWithFourItems_LastSmaller();
            Assert.AreEqual<int>(50, heap.Remove());
            Assert.AreEqual<int>(60, heap.Peek());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\Heap")]
        public void Remove_Top_FromMax_FirstLarger_CheckCount()
        {
            Heap<int> heap = InitMaxHeapWithFourItems_SecondLastLarger();
            Assert.AreEqual<int>(50, heap.Remove());
            Assert.AreEqual<int>(3, heap.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\Heap")]
        public void Remove_Top_FromMax_FirstLarger_CheckPeek()
        {
            Heap<int> heap = InitMaxHeapWithFourItems_SecondLastLarger();
            Assert.AreEqual<int>(50, heap.Remove());
            Assert.AreEqual<int>(40, heap.Peek());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\Heap")]
        public void Remove_Top_FromMax_LastLarger_CheckCount()
        {
            Heap<int> heap = InitMaxHeapWithFourItems_LastLarger();
            Assert.AreEqual<int>(50, heap.Remove());
            Assert.AreEqual<int>(3, heap.Count);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\Heap")]
        public void Remove_Top_FromMax_LastLarger_CheckPeek()
        {
            Heap<int> heap = InitMaxHeapWithFourItems_LastLarger();
            Assert.AreEqual<int>(50, heap.Remove());
            Assert.AreEqual<int>(40, heap.Peek());
        }

        #endregion
    }
}
