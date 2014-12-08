namespace Foat.Hashing
{
    /// <summary>
    /// A helper class that projects a 32 bit hash into a small bit space through the use of folding bits and Xor-ing the results.
    /// </summary>
    public static class HashCodeProjector
    {
        /// <summary>
        /// Folds the bits of fullValue in on itself until it fits within the numberOfBitsDesired. Folded bits are Xored together to yield the results.
        /// </summary>
        /// <param name="fullHash"></param>
        /// <param name="numberOfBitsDesired"></param>
        /// <returns></returns>
        public static int Project(int fullHash, int numberOfBitsDesired)
        {
            if (numberOfBitsDesired < 0)
                throw new System.ArgumentOutOfRangeException("numberOfBitsDesired");

            unchecked
            {
                uint unsignedValue = (uint)fullHash;
                uint projectionMask = (uint)((1 << numberOfBitsDesired) - 1);
                uint projectedValue = 0;

                do
                {
                    projectedValue ^= projectionMask & unsignedValue;
                    unsignedValue >>= numberOfBitsDesired;
                } while (unsignedValue != 0);

                return (int)projectedValue;
            }
        }
    }
}
