namespace Foat
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Convert
    {
        public static Int32 FromFactorialBaseToInt32(byte[] permutation)
        {
            if (permutation == null)
                throw new ArgumentNullException("permutation");

            int currentFactorial = 1;
            int result = 0;
            for (int n = 0; n < permutation.Length; ++n)
            {
                currentFactorial = currentFactorial * (n + 1);
                result = result + permutation[n] * currentFactorial;
            }

            return result;
        }
    }
}
