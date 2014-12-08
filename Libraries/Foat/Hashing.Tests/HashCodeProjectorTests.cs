namespace Foat.Hashing.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HashCodeProjectorTests
    {
        [TestMethod]
        [TestCategory(@"Foat\Hashing\HashCodeProjector")]
        public void ProjectFirstHalfSetSecondHalfNot()
        {
            uint hash = 0xAAAA0000;

            Assert.AreEqual<int>(0xAAAA, HashCodeProjector.Project((int)hash, 16));
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\HashCodeProjector")]
        public void ProjectFirstHalfNotSetSecondHalfSet()
        {
            uint hash = 0x0000AAAA;

            Assert.AreEqual<int>(0xAAAA, HashCodeProjector.Project((int)hash, 16));
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\HashCodeProjector")]
        public void ProjectBothHalvesDifferent1()
        {
            uint hash = 0xAAAA5555;

            Assert.AreEqual<int>(UInt16.MaxValue, HashCodeProjector.Project((int)hash, 16));
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\HashCodeProjector")]
        public void ProjectBothHalvesDifferent2()
        {
            uint hash = 0x5555AAAA;

            Assert.AreEqual<int>(UInt16.MaxValue, HashCodeProjector.Project((int)hash, 16));
        }
    }
}
