namespace Foat.Collections
{
    using System;

    public struct BitMask
    {
        internal UInt32 Data { get; private set; }
        
        private const int MaxShift = 31;
        
        public bool IsBitSet(int i)
        {
            return ((Data << (MaxShift - i)) >> MaxShift) != 0;
        }

        public void SetBit(int i, bool value)
        {
            UInt32 newValue = (UInt32)1 << i;
            if (value)
            {
                this.Data |= newValue;
            }
            else
            {
                newValue ^= UInt32.MaxValue;
                this.Data &= newValue;
            }
        }

        public void SetAll(bool value)
        {
            if (value)
            {
                this.Data = UInt32.MaxValue;
            }
            else
            {
                this.Data = 0;
            }
        }

        public static BitMask operator &(BitMask x, BitMask y)
        {
            return new BitMask() {Data = x.Data & y.Data };
        }

        public override int GetHashCode()
        {
            return this.Data.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.Equals((BitMask)obj);
        }

        public bool Equals(BitMask other)
        {
            return this.Data == other.Data;
        }
    }
}
