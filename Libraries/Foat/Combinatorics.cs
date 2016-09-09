namespace Foat
{
    using System;

    public static class Combinatorics
    {
        private static int[] _PrecomputedFactorials = new int[] { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800, 39916800, 479001600 };
        public static long Factorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException("n", "Cannot compute factorial of a negative number");
            }

            if (n < _PrecomputedFactorials.Length)
            {
                return _PrecomputedFactorials[n];
            }
            else
            {
                long result = _PrecomputedFactorials[_PrecomputedFactorials.Length - 1];

                for (int i = _PrecomputedFactorials.Length; i <= n; i++)
                {
                    result = result * i;
                }

                return result;
            }
        }
    }
}
