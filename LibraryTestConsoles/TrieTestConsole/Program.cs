namespace TrieTestConsole
{
    using Foat.Collections.Generic;
    using Foat.Puzzles.RubiksCube;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            Trie<char, bool> t = new Trie<char,bool>(char.MaxValue);

            t.Insert(new char[] { 'P', 'o', 's', 't' }, true);
            t.Insert(new char[] { 'P', 'o', 't' }, true);
            t.Insert(new char[] { 'P', 'o', 't', 's' }, true);

            string[] toFind = {"Post", "Pots", "Pot", "Posit", "Pool", "Pad", "Bed"};

            foreach (string word in toFind)
            {
                Console.WriteLine("{0}: {1}", word, t.Contains(word.ToArray()).ToString());
            }

            foreach (var keyValuePair in t)
            {
                Console.WriteLine("Trie Contains: {0}", new string(keyValuePair.Key));
            }

            Trie<byte, byte> rubiksTrie = new Trie<byte, byte>(50);
            rubiksTrie.Insert(RubiksCubeFactory.CreateEdgeGroup1MaskCube().GetBytes(), 1);
            rubiksTrie.Insert(RubiksCubeFactory.CreateEdgeGroup2MaskCube().GetBytes(), 2);
            rubiksTrie.Insert(RubiksCubeFactory.CreateEdgeGroup3MaskCube().GetBytes(), 3);

            foreach (var data in rubiksTrie)
            {
                RubiksCube cube = new RubiksCube(data.Key);
                Console.WriteLine("Trie Contains: {0}", cube.ToString());
            }
        }
    }
}
