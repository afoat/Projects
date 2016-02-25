namespace Foat
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
