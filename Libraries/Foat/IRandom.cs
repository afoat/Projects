namespace Foat
{
    /// <summary>
    /// An interface for a random number generator. Useful when you will want to shim the
    /// random number generator during a unit test.
    /// </summary>
    public interface IRandom
    {
        int Next();
        int Next(int maxValue);
        int Next(int minValue, int maxValue);
        double NextDouble();
        void NextBytes(byte[] buffer);
    }
}
