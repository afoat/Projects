namespace Foat
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// A wrapper for System.Random that implements the IRandom interface.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Random : IRandom
    {
        private System.Random SystemRandom;

        public Random()
        {
            SystemRandom = new System.Random();
        }

        public Random(int seed)
        {
            SystemRandom = new System.Random(seed);
        }

        public int Next()
        {
            return SystemRandom.Next();
        }

        public int Next(int maxValue)
        {
            return SystemRandom.Next(maxValue);
        }

        public int Next(int minValue, int maxValue)
        {
            return SystemRandom.Next(minValue, maxValue);
        }

        public double NextDouble()
        {
            return SystemRandom.NextDouble();
        }

        public void NextBytes(byte[] buffer)
        {
            SystemRandom.NextBytes(buffer);
        }
    }
}
