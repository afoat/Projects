namespace Foat.Hashing.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FnvHashTests
    {
        [TestMethod]
        [TestCategory(@"Foat\Hashing\FnvHash")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ComputeHashByteArrayNull()
        {
            new FnvHash().ComputeHash(null);
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\FnvHash")]
        public void ComputeHashByteArrayZeroLength()
        {
            Assert.AreEqual<uint>(FnvHash.OffsetBasis, (uint)new FnvHash().ComputeHash(new byte[] { }));
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\FnvHash")]
        public void ComputeHashByteArrayLengthIsOne()
        {
            Assert.AreEqual<int>(67918732, new FnvHash().ComputeHash(new byte[] { 1 }));
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\FnvHash")]
        public void ComputeHashByteArrayLengthIsLargerThanOne()
        {
            Assert.AreEqual<int>(1722597017, new FnvHash().ComputeHash(new byte[] { 1, 12, 35 }));
        }




        [TestMethod]
        [TestCategory(@"Foat\Hashing\FnvHash")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ComputeHashWithHashNull()
        {
            new FnvHash().ComputeHash(0, null);
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\FnvHash")]
        public void ComputeHashWithHashZeroLength()
        {
            Assert.AreEqual<uint>(0, (uint)new FnvHash().ComputeHash(0, new byte[] { }));
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\FnvHash")]
        public void ComputeHashWithHashZeroLengthDifferentHash()
        {
            Assert.AreEqual<int>(5, new FnvHash().ComputeHash(5, new byte[] { }));
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\FnvHash")]
        public void ComputeHashWithHashLengthIsOne()
        {
            Assert.AreEqual<int>(16777619, new FnvHash().ComputeHash(0, new byte[] { 1 }));
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\FnvHash")]
        public void ComputeHashWithHashLengthIsLargerThanOne()
        {
            Assert.AreEqual<int>(671392810, new FnvHash().ComputeHash(0, new byte[] { 1, 12, 35 }));
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\FnvHash")]
        public void ComputeHashWithHashLengthIsLargerThanOneDifferentHash()
        {
            Assert.AreEqual<int>(1451050841, new FnvHash().ComputeHash(5, new byte[] { 1, 12, 35 }));
        }
    }
}
