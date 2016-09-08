using Foat.Permutations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutationTestConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            for (byte i = 0; i < 24; ++i)
            {
                byte[] permutation = Permutation.Unrank(4, i);
                int rank = Permutation.Rank(permutation);

                //Console.Write(Permutation.Format(permutation));
                //Console.Write(" Rank = ");
                Console.WriteLine(rank);
            }
        }
    }
}
