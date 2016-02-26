namespace Foat.Collections.Generic
{
    using Foat.Hashing;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// This class is designed to hold ints that are 7 bits or smaller
    /// in a byte array without wasting any space.
    /// 
    /// The smallest type available in C# is a byte (8 bits). For example, if you have
    /// a large number of 5 bit integers, you will be wasting 3 bits of memory
    /// per int. In the case of 5 bit integers the first item in the array takes up
    /// bits 0-4 of the first array entry. The second item takes up bits 5-7 of the first
    /// byte in the real array and the first two bits of the second byte.
    /// 
    /// Kind of slow, but useful if you need to store LOTS of information.
    /// </summary>
    public sealed class SmallIntArray
    {
        /// <summary>
        /// Specifies the size of the integers this array will store.
        /// </summary>
        public byte BitsPerInt { get; private set; }
        /// <summary>
        /// Returns the number integers with a size of BitsPerInt that this
        /// array can store
        /// </summary>
        public int Length { get; private set; }

        internal byte[] Array { get; set; }
        
        public byte this[int i]
        {
            get
            {
                if (i < 0 || i > this.Length - 1)
                {
                    throw new ArgumentOutOfRangeException();
                }

                unchecked
                {
                    int startBucket;
                    int endBucket;
                    int startPosition;
                    int endPosition;

                    InitializeStartAndEnd(i, out startBucket, out endBucket, out startPosition, out endPosition);
                    
                    if (startBucket == endBucket)
                    {
                        return (byte)((this.Array[startBucket] & CreateGetMask(startPosition, endPosition)) >> startPosition);
                    }
                    else
                    {
                        byte lowerBits = (byte)(this.Array[startBucket] >> startPosition);
                        return (byte)(((this.Array[endBucket] & CreateGetMask(0, endPosition)) << 8 - startPosition) + lowerBits);
                    }
                }
            }

            set
            {
                if (i < 0 || i > this.Length - 1)
                {
                    throw new IndexOutOfRangeException();
                }

                unchecked
                {
                    int startBucket;
                    int endBucket;
                    int startPosition;
                    int endPosition;

                    InitializeStartAndEnd(i, out startBucket, out endBucket, out startPosition, out endPosition);

                    if (startBucket == endBucket)
                    {
                        this.Array[startBucket] &= CreateSetMask(startPosition, endPosition);
                        value <<= startPosition;
                        this.Array[startBucket] += value;
                    }
                    else
                    {
                        this.Array[startBucket] &= CreateSetMask(startPosition, 7);
                        this.Array[startBucket] += (byte)(value << startPosition);
                        this.Array[endBucket] &= CreateSetMask(0, endPosition);
                        this.Array[endBucket] += (byte)(value >> (8 - startPosition));
                    }
                }
            }
        }

        /// <summary>
        /// Does some math to find out where the desired number starts and ends
        /// </summary>
        private void InitializeStartAndEnd(int i, out int startBucket, out int endBucket, out int startPosition, out int endPosition)
        {
            int startBit = (i * BitsPerInt);
            int endBit = startBit + BitsPerInt - 1;
            startBucket = startBit / 8;
            endBucket = endBit / 8;
            startPosition = startBit % 8;
            endPosition = endBit % 8;
        }

        [ExcludeFromCodeCoverage]
        private SmallIntArray()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Constructs an instance of a SmallIntArray
        /// </summary>
        /// <param name="bitsPerInt">The number of bits that each int will contain.</param>
        /// <param name="capacity">The number ints that this array will be able to hold.</param>
        public SmallIntArray(byte bitsPerInt, int capacity)
        {
            if (bitsPerInt > 7)
            {
                throw new ArgumentOutOfRangeException("bitsPerInt must be smaller than 8.");
            }

            this.BitsPerInt = bitsPerInt;

            this.Array = new byte[(bitsPerInt * capacity / 8) + 1];
            this.Length = capacity;
        }

        public SmallIntArray(SmallIntArray toCopy)
        {
            this.BitsPerInt = toCopy.BitsPerInt;
            this.Length = toCopy.Length;
            this.Array = new byte[toCopy.Array.Length];
            toCopy.Array.CopyTo(this.Array, 0);
        }

        /// <summary>
        /// A cache to remember the masks that we need to get and set the data in the array
        /// </summary>
        private static Dictionary<KeyValuePair<int, int>, byte> MaskCache = new Dictionary<KeyValuePair<int, int>, byte>();

        private static byte CreateGetMask(int startPosition, int endPosition)
        {
            unchecked
            {
                KeyValuePair<int, int> key = new KeyValuePair<int, int>(startPosition, endPosition);
                byte result = 0;
                if (MaskCache.ContainsKey(key))
                {
                    result = MaskCache[key];
                }
                else
                {
                    byte mask = 0;

                    for (int i = startPosition; i <= endPosition; ++i)
                    {
                        mask <<= 1;
                        mask += 1;
                    }

                    result = (byte)(mask << startPosition);

                    MaskCache[key] = result;
                }

                return result;
            }
        }

        private static byte CreateSetMask(int startPosition, int endPosition)
        {
            return (byte)~CreateGetMask(startPosition, endPosition);
        }

        [ExcludeFromCodeCoverage]
        public override int GetHashCode()
        {
            FnvHash hash = new FnvHash();
            return hash.ComputeHash(this.BitsPerInt, this.Array);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as SmallIntArray);
        }

        public bool Equals(SmallIntArray otherArray)
        {
            if (otherArray == null)
            {
                return false;
            }
            else if (this.Array.Length != otherArray.Array.Length)
            {
                return false;
            }
            else if (this.BitsPerInt != otherArray.BitsPerInt)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < this.Array.Length; ++i)
                {
                    if (this.Array[i] != otherArray.Array[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
