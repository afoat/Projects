using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Foat.Collections.Test
{
    [TestClass]
    public class BitMaskTests
    {
        [TestMethod]
        [TestCategory("Foat\\BitMask")]
        public void SetAll_False()
        {
            BitMask mask = new BitMask();
            mask.SetAll(true);

            Assert.AreEqual<UInt32>(UInt32.MaxValue, mask.Data);
        }

        [TestMethod]
        [TestCategory("Foat\\BitMask")]
        public void SetAll_True()
        {
            BitMask mask = new BitMask();
            mask.SetAll(false);

            Assert.AreEqual<UInt32>(0, mask.Data);
        }

        [TestMethod]
        [TestCategory("Foat\\BitMask")]
        public void IsBitSet_False()
        {
            BitMask mask = new BitMask();
            mask.SetAll(false);

            for (int i = 0; i < 32; ++i)
            {
                Assert.IsFalse(mask.IsBitSet(i));
            }
        }

        [TestMethod]
        [TestCategory("Foat\\BitMask")]
        public void IsBitSet_True()
        {
            BitMask mask = new BitMask();
            mask.SetAll(true);

            for (int i = 0; i < 32; ++i)
            {
                Assert.IsTrue(mask.IsBitSet(i));
            }
        }

        [TestMethod]
        [TestCategory("Foat\\BitMask")]
        public void BitwiseAnd_AllTrueWithAllFalse()
        {
            BitMask mask1 = new BitMask();
            mask1.SetAll(true);

            BitMask mask2 = new BitMask();
            mask2.SetAll(false);

            Assert.AreEqual<UInt32>(0, (mask1 & mask2).Data);

            mask1 &= mask2;
            Assert.AreEqual<UInt32>(0, (mask1).Data);
        }

        [TestMethod]
        [TestCategory("Foat\\BitMask")]
        public void BitwiseAnd_AllFalseWithAllTrue()
        {
            BitMask mask1 = new BitMask();
            mask1.SetAll(false);

            BitMask mask2 = new BitMask();
            mask2.SetAll(true);

            Assert.AreEqual<UInt32>(0, (mask1 & mask2).Data);

            mask1 &= mask2;
            Assert.AreEqual<UInt32>(0, (mask1).Data);
        }

        [TestMethod]
        [TestCategory("Foat\\BitMask")]
        public void BitwiseAnd_AllTrueWithAllTrue()
        {
            BitMask mask1 = new BitMask();
            mask1.SetAll(true);

            BitMask mask2 = new BitMask();
            mask2.SetAll(true);

            Assert.AreEqual<UInt32>(UInt32.MaxValue, (mask1 & mask2).Data);

            mask1 &= mask2;
            Assert.AreEqual<UInt32>(UInt32.MaxValue, (mask1).Data);
        }

        [TestMethod]
        [TestCategory("Foat\\BitMask")]
        public void SetBit_FirstBit_False()
        {
            BitMask mask = new BitMask();
            mask.SetAll(true);

            mask.SetBit(0, false);

            Assert.AreEqual<UInt32>(UInt32.MaxValue - 1, mask.Data);
        }

        [TestMethod]
        [TestCategory("Foat\\BitMask")]
        public void SetBit_MiddleBit_False()
        {
            BitMask mask = new BitMask();
            mask.SetAll(true);

            mask.SetBit(5, false);

            Assert.AreEqual<UInt32>(UInt32.MaxValue - 32, mask.Data);
        }

        [TestMethod]
        [TestCategory("Foat\\BitMask")]
        public void SetBit_LastBit_False()
        {
            BitMask mask = new BitMask();
            mask.SetAll(true);

            mask.SetBit(31, false);

            Assert.AreEqual<UInt32>(UInt32.MaxValue - 2147483648, mask.Data);
        }

        [TestMethod]
        [TestCategory("Foat\\BitMask")]
        public void SetBit_FirstBit_True()
        {
            BitMask mask = new BitMask();
            mask.SetAll(false);

            mask.SetBit(0, true);

            Assert.AreEqual<UInt32>(1, mask.Data);
        }

        [TestMethod]
        [TestCategory("Foat\\BitMask")]
        public void SetBit_MiddleBit_True()
        {
            BitMask mask = new BitMask();
            mask.SetAll(false);

            mask.SetBit(5, true);

            Assert.AreEqual<UInt32>(32, mask.Data);
        }

        [TestMethod]
        [TestCategory("Foat\\BitMask")]
        public void SetBit_LastBit_True()
        {
            BitMask mask = new BitMask();
            mask.SetAll(false);

            mask.SetBit(31, true);

            Assert.AreEqual<UInt32>(2147483648, mask.Data);
        }

        [TestMethod]
        [TestCategory("Foat\\BitMask")]
        public void Equals_Self()
        {
            BitMask mask = new BitMask();
            mask.SetAll(true);
            mask.SetBit(4, false);

            Assert.IsTrue(mask.Equals(mask));
        }

        [TestMethod]
        [TestCategory("Foat\\BitMask")]
        public void Equals_Same()
        {
            BitMask mask1 = new BitMask();
            mask1.SetAll(true);
            mask1.SetBit(4, false);

            BitMask mask2 = new BitMask();
            mask2.SetAll(true);
            mask2.SetBit(4, false);

            Assert.IsTrue(mask1.Equals(mask2));
        }

        [TestMethod]
        [TestCategory("Foat\\BitMask")]
        public void Equals_Different1()
        {
            BitMask mask1 = new BitMask();
            mask1.SetAll(true);
            mask1.SetBit(4, false);

            BitMask mask2 = new BitMask();
            mask2.SetAll(true);

            Assert.IsFalse(mask1.Equals(mask2));
        }

        [TestMethod]
        [TestCategory("Foat\\BitMask")]
        public void Equals_Different2()
        {
            BitMask mask1 = new BitMask();
            mask1.SetAll(true);
            mask1.SetBit(4, false);

            BitMask mask2 = new BitMask();
            mask2.SetAll(false);

            Assert.IsFalse(mask1.Equals(mask2));
        }


    }
}
