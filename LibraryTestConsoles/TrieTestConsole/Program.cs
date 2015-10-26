namespace TrieTestConsole
{
    using Foat.Collections.Generic;
    using Foat.Puzzles.RubiksCube;
    using Foat.Puzzles.RubiksCube.Solution;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            List<byte> alphabet = new List<byte>(
                new byte[] 
                { 
                    1,
                    2,
                    3,
                    4,
                    5
                }
                );

            DataTrie<Data, bool> trie = new DataTrie<Data, bool>(alphabet, bytes => new Data(bytes));

            Data word1 = new Data(new byte[] { 1, 1, 1 });
            Data word2 = new Data(new byte[] { 1, 1, 2 });
            Data word3 = new Data(new byte[] { 1, 1, 3 });
            Data word4 = new Data(new byte[] { 1, 1, 4 });
            Data word5 = new Data(new byte[] { 1, 2, 1 });
            Data word6 = new Data(new byte[] { 1, 2, 2 });
            Data word7 = new Data(new byte[] { 1, 2, 2, 5 });
            Data word8 = new Data(new byte[] { 1, 2, 2,  });

            trie.Insert(word1, true);
            trie.Insert(word2, true);
            trie.Insert(word3, true);
            trie.Insert(word4, true);
            trie.Insert(word5, true);
            trie.Insert(word6, true);
            trie.Insert(word7, true);
            trie.Insert(word8, true);

            foreach (KeyValuePair<Data, bool> data in trie)
            {
                Console.WriteLine("Key {0} Value {1}", data.Key.ToString(), data.Value.ToString());
            }

            if (trie.Contains(word1))
                Console.WriteLine("{0} was found", word1.ToString());
            else
                Console.WriteLine("{0} was not found", word1.ToString());

            if (trie.Contains(word8))
                Console.WriteLine("{0} was found", word8.ToString());
            else
                Console.WriteLine("{0} was not found", word8.ToString());

            if (trie.Contains(word5))
                Console.WriteLine("{0} was found", word5.ToString());
            else
                Console.WriteLine("{0} was not found", word5.ToString());

            Data word9 = new Data(new byte[] { 3, 1, 4, 2 });
            if (trie.Contains(word9))
                Console.WriteLine("{0} was found", word9.ToString());
            else
                Console.WriteLine("{0} was not found", word9.ToString());

            Data word10 = new Data(new byte[] { 1, 2, 2, 4 });
            if (trie.Contains(word10))
                Console.WriteLine("{0} was found", word10.ToString());
            else
                Console.WriteLine("{0} was not found", word10.ToString());
        }
    }
}
