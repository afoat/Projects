namespace Foat.Permutations
{
    using System;
    using System.Text;

    /// <summary>
    /// A class capable of ranking and unranking a permutation of N integers that are all in the range of
    /// 0 ... N - 1.
    /// 
    /// http://webhome.cs.uvic.ca/~ruskey/Publications/RankPerm/RankPerm.html
    /// </summary>
    public static class Permutation
    {

        #region Helper Functions

        private static byte[] BuildIdentity(byte size)
        {
            byte[] identity = new byte[size];
            for (byte i = 0; i < size; ++i)
            {
                identity[i] = i;
            }

            return identity;
        }
        
        private static byte[] BuildInverted(byte[] permutation)
        {
            byte size = (byte)permutation.Length;
            byte[] inverted = new byte[size];
            for (byte i = 0; i < size; ++i)
            {
                inverted[permutation[i]] = i;
            }

            return inverted;
        }

        private static void Swap(byte[] permutation, int i, int j)
        {
            byte temp = permutation[i];
            permutation[i] = permutation[j];
            permutation[j] = temp;
        }

        #endregion

        /// <summary>
        /// Can generate the permutation with the desired rank
        /// </summary>
        /// <param name="size">The number of integers in the permutation you want to generate</param>
        /// <param name="rank">The rank of the permutation you want to generate</param>
        public static byte[] Unrank(byte size, int rank)
        {
            byte[] permutation = BuildIdentity(size);
            return UnrankInner(size, rank, permutation);
        }

        private static byte[] UnrankInner(byte n, int rank, byte[] permutation)
        {
            if (n > 0)
            {
                byte nMinus1 = (byte)(n - 1);
                Swap(permutation, nMinus1, rank % n);
                permutation = UnrankInner(nMinus1, rank / n, permutation);
            }

            return permutation;
        }

        /// <summary>
        /// Can generate a rank based on the permutation that is passed in
        /// </summary>
        public static byte Rank(byte[] permutation)
        {
            byte[] inverted = BuildInverted(permutation);

            return RankInner((byte)permutation.Length, permutation, inverted);
        }

        private static byte RankInner(byte n, byte[] permutation, byte[] inverted)
        {
            if (n == 1)
            {
                return 0;
            }

            byte nMinus1 = (byte)(n - 1);
            byte temp = permutation[n - 1];
            Swap(permutation, nMinus1, inverted[nMinus1]);
            Swap(inverted, temp, nMinus1);
            return (byte)(temp + n * RankInner(nMinus1, permutation, inverted));
        }

        public static string Format(byte[] permutation)
        {
            if (permutation == null)
                throw new ArgumentNullException("permutation");

            StringBuilder sb = new StringBuilder(permutation.Length * 2 + 3);

            sb.Append("{ ");

            foreach (byte b in permutation)
            {
                sb.Append(b);
                sb.Append(" ");
            }

            sb.Append("}");

            return sb.ToString();
        }
    }
}
