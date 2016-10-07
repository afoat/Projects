namespace Foat.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class ConvertTests
    {
        [TestMethod]
        [TestCategory("Foat\\Convert")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FromFactorialBaseToInt32_Null()
        {
            Foat.Convert.FromFactorialBaseToInt32(null);
        }

        [TestMethod]
        [TestCategory("Foat\\Convert")]
        public void FromFactorialBaseToInt32_Test1()
        {
            Assert.AreEqual(4, Foat.Convert.FromFactorialBaseToInt32(new byte[] { 2, 1, 0 }));
        }

        [TestMethod]
        [TestCategory("Foat\\Convert")]
        public void FromFactorialBaseToInt32_Test2()
        {
            Assert.AreEqual(14, Foat.Convert.FromFactorialBaseToInt32(new byte[] { 0, 1, 2 }));
        }
    }
}
