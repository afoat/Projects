namespace Foat.Hashing
{
    /// <summary>
    /// Provides a common set of methods used by all normal hash functions in the Foat.Hashing library.
    /// </summary>
    public interface IHashFunction32Bit 
    {
        /// <summary>
        /// Computes the hash of the given byte array.
        /// </summary>
        /// <param name="array">The array of bites to be hashed.</param>
        /// <returns>a 32 bit hash of the byte array</returns>
        int ComputeHash(byte[] array);

        /// <summary>
        /// Computes the hash of the given byte array only this time it uses hash as the starting point.
        /// 
        /// Can be useful to combine the byte array with a previous hash or to randomize the hash produced by this algorithm.
        /// </summary>
        /// <param name="hash">The previous hash we want to combine with the array into a final hash. Can also be used as a seed to randomize the results of this method.</param>
        /// <param name="array">The array of bites to be hashed.</param>
        /// <returns>a 32 bit hash that was formed by combining the byte array with the included hash value.</returns>
        int ComputeHash(int hash, byte[] array);
    }
}
