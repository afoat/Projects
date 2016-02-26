namespace Foat.Collections.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Foat.Collections.Generic;

    [TestClass]
    public class SmallIntArrayTests
    {
        #region Setup

        private SmallIntArray Init2BitIntWithOneTwoThree()
        {
            SmallIntArray array = new SmallIntArray(2, 3);
            array.Array = new byte[] { 57, 0 };
            return array;
        }

        private SmallIntArray Init5BitIntWithOnesTwosThrees()
        {
            SmallIntArray array = new SmallIntArray(5, 3);
            array.Array = new byte[] { 203, 14 };
            return array;
        }

        #endregion

        #region Construction

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SmallIntArray")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_Default_TooBig()
        {
            SmallIntArray array = new SmallIntArray(8, 10);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SmallIntArray")]
        public void Constructor_Default_CheckLength()
        {
            SmallIntArray array = new SmallIntArray(4, 10);
            Assert.AreEqual<int>(10, array.Length);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SmallIntArray")]
        public void Constructor_Default_CheckBitsPerInt()
        {
            SmallIntArray array = new SmallIntArray(4, 10);
            Assert.AreEqual<int>(4, array.BitsPerInt);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SmallIntArray")]
        public void Constructor_Copy_CheckLength()
        {
            SmallIntArray array1 = new SmallIntArray(4, 10);
            SmallIntArray array2 = new SmallIntArray(array1);

            Assert.AreEqual<int>(10, array2.Length);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SmallIntArray")]
        public void Constructor_Copy_CheckBitsPerInt()
        {
            SmallIntArray array1 = new SmallIntArray(4, 10);
            SmallIntArray array2 = new SmallIntArray(array1);

            Assert.AreEqual<int>(4, array2.BitsPerInt);
        }

        #endregion

        #region Reading From Array

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SmallIntArray")]
        public void ReadingFromArray_Success()
        {
            SmallIntArray array = Init2BitIntWithOneTwoThree();
            Assert.AreEqual<int>(1, array[0]);
            Assert.AreEqual<int>(2, array[1]);
            Assert.AreEqual<int>(3, array[2]);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SmallIntArray")]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ReadingFromArray_OutOfBoundsTooSmall()
        {
            SmallIntArray array = Init2BitIntWithOneTwoThree();
            int i = array[-1];
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SmallIntArray")]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ReadingFromArray_OutOfBoundsTooLarge()
        {
            SmallIntArray array = Init2BitIntWithOneTwoThree();
            int i = array[3];
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SmallIntArray")]
        public void ReadingFromArray_OnBorder_Success()
        {
            SmallIntArray array = Init5BitIntWithOnesTwosThrees();
            Assert.AreEqual<int>(22, array[1]);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SmallIntArray")]
        public void ReadingFromArray_TwiceToTestCache_Success()
        {
            SmallIntArray array = Init5BitIntWithOnesTwosThrees();
            Assert.AreEqual<int>(11, array[0]);
            Assert.AreEqual<int>(11, array[0]);
        }

        #endregion

        #region Writing To Array

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SmallIntArray")]
        public void WritingToArray_Success()
        {
            SmallIntArray array = new SmallIntArray(2, 3);
            array[0] = 1;
            array[1] = 2;
            array[2] = 3;

            Assert.AreEqual<int>(57, array.Array[0]);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SmallIntArray")]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void WritingToArray_OutOfBounds_TooSmall()
        {
            SmallIntArray array = new SmallIntArray(2, 3);
            array[-1] = 1;
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SmallIntArray")]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void WritingToArray_OutOfBounds_TooLarge()
        {
            SmallIntArray array = new SmallIntArray(2, 3);
            array[3] = 1;
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SmallIntArray")]
        public void WritingToArray_OnBorder_Success()
        {
            SmallIntArray array = new SmallIntArray(5, 3);
            array[0] = 11;
            array[1] = 22;
            array[2] = 3;

            Assert.AreEqual<int>(203, array.Array[0]);
            Assert.AreEqual<int>(14, array.Array[1]);
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SmallIntArray")]
        public void WritingToArray_TwiceToTestCache_Success()
        {
            SmallIntArray array = new SmallIntArray(5, 3);
            array[0] = 11;

            Assert.AreEqual<int>(11, array.Array[0]);

            array[0] = 11;

            Assert.AreEqual<int>(11, array.Array[0]);
        }

        #endregion

        #region Equals

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SmallIntArray")]
        public void Equals_Null()
        {
            SmallIntArray array1 = Init5BitIntWithOnesTwosThrees();
            SmallIntArray array2 = null;

            Assert.IsFalse(array1.Equals(array2));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SmallIntArray")]
        public void Equals_DiffLength()
        {
            SmallIntArray array1 = new SmallIntArray(3, 5);
            SmallIntArray array2 = new SmallIntArray(3, 6);

            Assert.IsFalse(array1.Equals(array2));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SmallIntArray")]
        public void Equals_DiffBitsPerInt()
        {
            SmallIntArray array1 = Init2BitIntWithOneTwoThree();
            SmallIntArray array2 = Init5BitIntWithOnesTwosThrees();

            Assert.IsFalse(array1.Equals(array2));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SmallIntArray")]
        public void Equals_True()
        {
            SmallIntArray array1 = Init5BitIntWithOnesTwosThrees();
            SmallIntArray array2 = Init5BitIntWithOnesTwosThrees();

            Assert.IsTrue(array1.Equals(array2));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SmallIntArray")]
        public void Equals_False()
        {
            SmallIntArray array1 = Init5BitIntWithOnesTwosThrees();
            SmallIntArray array2 = Init5BitIntWithOnesTwosThrees();
            array2[1] = 5;

            Assert.IsFalse(array1.Equals(array2));
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\SmallIntArray")]
        public void Equals_Generic()
        {
            SmallIntArray array1 = Init5BitIntWithOnesTwosThrees();
            SmallIntArray array2 = Init5BitIntWithOnesTwosThrees();
            array2[1] = 5;

            Assert.IsFalse(((object)array1).Equals(array2));
        }

        #endregion
    }
}
