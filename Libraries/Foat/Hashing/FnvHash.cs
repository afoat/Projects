namespace Foat.Hashing
{
    using System;

    /// <summary>
    /// FnvHash is a fairly good and fast hash that yields good results. This class can hash a byte[] of any length so it can be
    /// made compatible fairly easily with many different types.
    /// 
    /// See this site for details:
    /// http://isthe.com/chongo/tech/comp/fnv/
    /// </summary>
    public sealed class FnvHash : IHashFunction32Bit
    {
        internal const uint OffsetBasis = 2166136261;
        internal const int HashPrime = 16777619;

        /// <summary>
        /// Computes the hash of the given byte array.
        /// </summary>
        /// <param name="array">The array of bites to be hashed.</param>
        /// <returns>a 32 bit hash of the byte array</returns>
        public int ComputeHash(byte[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            unchecked
            {
                return this.ComputeHash((int)OffsetBasis, array);
            }
        }

        /// <summary>
        /// Computes the hash of the given byte array only this time it uses hash as the starting point.
        /// 
        /// Can be useful to combine the byte array with a previous has or to randomize the hash produced by this algorithm.
        /// </summary>
        /// <param name="hash">The previous hash we want to combine with the array into a final hash. Can also be used as a seed to randomize the results of this method.</param>
        /// <param name="array">The array of bites to be hashed.</param>
        /// <returns>a 32 bit hash that was formed by combining the byte array with the included hash value.</returns>
        public int ComputeHash(int hash, byte[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            unchecked
            {
                for (var i = 0; i < array.Length; i++)
                {
                    hash ^= array[i];
                    hash *= HashPrime;
                }

                return hash;
            }
        }
    }
}
