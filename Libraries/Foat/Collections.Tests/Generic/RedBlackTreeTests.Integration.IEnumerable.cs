﻿namespace Foat.Collections.Generic.Tests
{
    using System.Collections;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class RedBlackTreeTests
    {
        #region IEnumerable

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void GetEnumerator_FiveNodesLeftFull()
        {
            IEnumerable ienumerable = (IEnumerable)FiveNodesLeftFull;

            IEnumerator enumerator = ienumerable.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<object>(12, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<object>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<object>(32, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<object>(50, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<object>(75, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("Foat\\Collections\\Generic\\RedBlackTree")]
        public void GetEnumeratorGeneric_FiveNodesLeftFull()
        {
            IEnumerable<int> ienumerable = (IEnumerable<int>)FiveNodesLeftFull;

            IEnumerator<int> enumerator = ienumerable.GetEnumerator();

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
    }
}
