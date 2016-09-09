using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Foat.Tests
{
    [TestClass]
    public class CombinatoricsTests
    {
        [TestMethod]
        [TestCategory("Foat\\Combinatorics")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Factorial_Negative()
        {
            Combinatorics.Factorial(-1);
        }

        [TestMethod]
        [TestCategory("Foat\\Combinatorics")]
        public void Factorial_0()
        {
            Assert.AreEqual(1, Combinatorics.Factorial(0));
        }

        [TestMethod]
        [TestCategory("Foat\\Combinatorics")]
        public void Factorial_1()
        {
            Assert.AreEqual(1, Combinatorics.Factorial(1));
        }
        
        [TestMethod]
        [TestCategory("Foat\\Combinatorics")]
        public void Factorial_2()
        {
            Assert.AreEqual(2, Combinatorics.Factorial(2));
        }

        [TestMethod]
        [TestCategory("Foat\\Combinatorics")]
        public void Factorial_3()
        {
            Assert.AreEqual(6, Combinatorics.Factorial(3));
        }

        [TestMethod]
        [TestCategory("Foat\\Combinatorics")]
        public void Factorial_12()
        {
            Assert.AreEqual(479001600, Combinatorics.Factorial(12));
        }

        [TestMethod]
        [TestCategory("Foat\\Combinatorics")]
        public void Factorial_13()
        {
            Assert.AreEqual(6227020800, Combinatorics.Factorial(13));
        }
    }
}
