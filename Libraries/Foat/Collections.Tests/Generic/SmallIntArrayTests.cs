namespace Foat.Collections.Generic.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SmallIntArrayTests
    {
        private const string Category = @"Foat\Collections\SmallIntArray";

        [TestMethod]
        [TestCategory(Category)]
        public void CreateSetMask_IEquals0()
        {
            uint value = SmallIntArray.CreateSetMask(0, 4);

            Assert.AreEqual<uint>(224, value);
        }

        [TestMethod]
        [TestCategory(Category)]
        public void CreateSetMask_IEquals1()
        {
            uint value = SmallIntArray.CreateSetMask(1, 5);

            Assert.AreEqual<uint>(193, value);
        }

        [TestMethod]
        [TestCategory(Category)]
        public void CreateSetMask_IEquals2()
        {
            uint value = SmallIntArray.CreateSetMask(2, 6);

            Assert.AreEqual<uint>(131, value);
        }

        [TestMethod]
        [TestCategory(Category)]
        public void CreateSetMask_IEquals3()
        {
            uint value = SmallIntArray.CreateSetMask(3, 7);

            Assert.AreEqual<uint>(7, value);
        }

        [TestMethod]
        [TestCategory(Category)]
        public void CreateGetMask_IEquals0()
        {
            uint value = SmallIntArray.CreateGetMask(0, 4);

            Assert.AreEqual<uint>(31, value);
        }

        [TestMethod]
        [TestCategory(Category)]
        public void CreateGetMask_IEquals1()
        {
            uint value = SmallIntArray.CreateGetMask(1, 5);

            Assert.AreEqual<uint>(62, value);
        }

        [TestMethod]
        [TestCategory(Category)]
        public void CreateGetMask_IEquals2()
        {
            uint value = SmallIntArray.CreateGetMask(2, 6);

            Assert.AreEqual<uint>(124, value);
        }

        [TestMethod]
        [TestCategory(Category)]
        public void CreateGetMask_IEquals3()
        {
            uint value = SmallIntArray.CreateGetMask(3, 7);

            Assert.AreEqual<uint>(248, value);
        }

        [TestMethod]
        [TestCategory(Category)]
        public void SetValue_OverNothing_AllOneBucketAt0()
        {
            SmallIntArray array = new SmallIntArray(5, 8);
            array[0] = 31;

            Assert.AreEqual<int>(31, array.Array[0]);
        }

        [TestMethod]
        [TestCategory(Category)]
        public void SetValue_OverNothing_AcrossBucketsAt1()
        {
            SmallIntArray array = new SmallIntArray(5, 8);
            array[1] = 31;

            Assert.AreEqual<int>(224, array.Array[0]);
            Assert.AreEqual<int>(3, array.Array[1]);
        }

        [TestMethod]
        [TestCategory(Category)]
        public void SetValue_OverNothing_AllOneBucketAt2()
        {
            SmallIntArray array = new SmallIntArray(5, 8);
            array[2] = 31;

            Assert.AreEqual<int>(124, array.Array[1]);
        }

        [TestMethod]
        [TestCategory(Category)]
        public void SetValue_OverNothing_AcrossBucketsAt3()
        {
            SmallIntArray array = new SmallIntArray(5, 8);
            array[3] = 31;

            Assert.AreEqual<int>(128, array.Array[1]);
            Assert.AreEqual<int>(15, array.Array[2]);
        }

        [TestMethod]
        [TestCategory(Category)]
        public void SetValue_OverNothing_AcrossBucketsAt4()
        {
            SmallIntArray array = new SmallIntArray(5, 8);
            array[4] = 31;

            Assert.AreEqual<int>(240, array.Array[2]);
            Assert.AreEqual<int>(1, array.Array[3]);
        }

        [TestMethod]
        [TestCategory(Category)]
        public void SetValue_OverNothing_AllOneBucketAt5()
        {
            SmallIntArray array = new SmallIntArray(5, 8);
            array[5] = 31;

            Assert.AreEqual<int>(62, array.Array[3]);
        }

        [TestMethod]
        [TestCategory(Category)]
        public void SetValue_OverNothing_AcrossBucketsAt6()
        {
            SmallIntArray array = new SmallIntArray(5, 8);
            array[6] = 31;

            Assert.AreEqual<int>(192, array.Array[3]);
            Assert.AreEqual<int>(7, array.Array[4]);
        }

        [TestMethod]
        [TestCategory(Category)]
        public void SetValue_OverNothing_AllOneBucketAt7()
        {
            SmallIntArray array = new SmallIntArray(5, 8);
            array[7] = 31;

            Assert.AreEqual<int>(248, array.Array[4]);
        }

        [TestMethod]
        [TestCategory(Category)]
        public void SetValue_OverSomething_AllOneBucketAt0()
        {
            SmallIntArray array = new SmallIntArray(5, 8) { Array = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF } };
            array[0] = 0;

            Assert.AreEqual<int>(224, array.Array[0]);
        }

        [TestMethod]
        [TestCategory(Category)]
        public void SetValue_OverSomething_AcrossBucketsAt1()
        {
            SmallIntArray array = new SmallIntArray(5, 8) { Array = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF } };
            array[1] = 0;

            Assert.AreEqual<int>(31, array.Array[0]);
            Assert.AreEqual<int>(252, array.Array[1]);
        }

        [TestMethod]
        [TestCategory(Category)]
        public void SetValue_OverSomething_AllOneBucketAt2()
        {
            SmallIntArray array = new SmallIntArray(5, 8) { Array = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF } };
            array[2] = 0;

            Assert.AreEqual<int>(131, array.Array[1]);
        }

        [TestMethod]
        [TestCategory(Category)]
        public void SetValue_OverSomething_AcrossBucketsAt3()
        {
            SmallIntArray array = new SmallIntArray(5, 8) { Array = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF } };
            array[3] = 0;

            Assert.AreEqual<int>(127, array.Array[1]);
            Assert.AreEqual<int>(240, array.Array[2]);
        }

        [TestMethod]
        [TestCategory(Category)]
        public void SetValue_OverSomething_AcrossBucketsAt4()
        {
            SmallIntArray array = new SmallIntArray(5, 8) { Array = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF } };
            array[4] = 0;

            Assert.AreEqual<int>(15, array.Array[2]);
            Assert.AreEqual<int>(254, array.Array[3]);
        }

        [TestMethod]
        [TestCategory(Category)]
        public void SetValue_OverSomething_AllOneBucketAt5()
        {
            SmallIntArray array = new SmallIntArray(5, 8) { Array = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF } };
            array[5] = 0;

            Assert.AreEqual<int>(193, array.Array[3]);
        }

        [TestMethod]
        [TestCategory(Category)]
        public void SetValue_OverSomething_AcrossBucketsAt6()
        {
            SmallIntArray array = new SmallIntArray(5, 8) { Array = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF } };
            array[6] = 0;

            Assert.AreEqual<int>(63, array.Array[3]);
            Assert.AreEqual<int>(248, array.Array[4]);
        }

        [TestMethod]
        [TestCategory(Category)]
        public void SetValue_OverSomething_AllOneBucketAt7()
        {
            SmallIntArray array = new SmallIntArray(5, 8) { Array = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF } };
            array[7] = 0;

            Assert.AreEqual<int>(7, array.Array[4]);
        }

        [TestMethod]
        [TestCategory(Category)]
        public void GetValue_AllOneBucketAt0()
        {
            SmallIntArray array = new SmallIntArray(5, 8) { Array = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF } };

            Assert.AreEqual<int>(31, array[0]);
        }

        [TestMethod]
        [TestCategory(Category)]
        public void GetValue_AcrossBucketsAt1()
        {
            SmallIntArray array = new SmallIntArray(5, 8) { Array = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF } };

            Assert.AreEqual<int>(31, array[1]);
        }

        [TestMethod]
        [TestCategory(Category)]
        public void GetValue_AllOneBucketAt2()
        {
            SmallIntArray array = new SmallIntArray(5, 8) { Array = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF } };

            Assert.AreEqual<int>(31, array[2]);
        }

        [TestMethod]
        [TestCategory(Category)]
        public void GetValue_AcrossBucketsAt3()
        {
            SmallIntArray array = new SmallIntArray(5, 8) { Array = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF } };

            Assert.AreEqual<int>(31, array[3]);
        }

        [TestMethod]
        [TestCategory(Category)]
        public void GetValue_AcrossBucketsAt4()
        {
            SmallIntArray array = new SmallIntArray(5, 8) { Array = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF } };

            Assert.AreEqual<int>(31, array[4]);
        }

        [TestMethod]
        [TestCategory(Category)]
        public void GetValue_AllOneBucketAt5()
        {
            SmallIntArray array = new SmallIntArray(5, 8) { Array = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF } };

            Assert.AreEqual<int>(31, array[5]);
        }

        [TestMethod]
        [TestCategory(Category)]
        public void GetValue_AcrossBucketsAt6()
        {
            SmallIntArray array = new SmallIntArray(5, 8) { Array = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF } };

            Assert.AreEqual<int>(31, array[6]);
        }

        [TestMethod]
        [TestCategory(Category)]
        public void GetValue_AllOneBucketAt7()
        {
            SmallIntArray array = new SmallIntArray(5, 8) { Array = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF } };

            Assert.AreEqual<int>(31, array[7]);
        }
    }
}
