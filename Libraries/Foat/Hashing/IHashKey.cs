namespace Foat.Hashing
{
    /// <summary>
    /// Interface that supports a method of getting an array of bytes that represent a key.
    /// </summary>
    public interface IHashKey
    {
        /// <summary>
        /// Gets an array of bytes that represent a key.
        /// </summary>
        /// <returns></returns>
        byte[] GetBytes();
    }
}
