namespace Foat.Puzzles.RubiksCube.Solution
{
    using Foat.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    /// <summary>
    /// This class stores a key value pair where the key is a rubiks cube and the value
    /// is a byte representing the number of turns a cube is away from the solution
    /// </summary>
    public class RubiksCubeDepthDatabase : IEnumerable<KeyValuePair<RubiksCube, byte>>
    {
        //Im keeping some other potential databases around and easily accessible so I can
        //compare them. Plain old dictionary seems to take the less memory and is most suitable
        //when machine only has 8gigs of ram

        //private SkipList<RubiksCube, byte> Database;
        private Dictionary<RubiksCube, byte> Database;
        //private ConcurrentDictionary<RubiksCube, byte> Database;
        //private DataTrie<RubiksCube, byte> Database;

        public int Count { get { return this.Database.Count; } }

        public IEnumerable<RubiksCube> Keys
        {
            get
            {
                foreach (KeyValuePair<RubiksCube, byte> item in this.Database)
                {
                    yield return item.Key;
                }
            }
        }

        public RubiksCubeDepthDatabase(int capacity, int numberOfThreads)
        {
            byte[] alphabet = GetAlphabet();
            //this.Database = new DataTrie<RubiksCube, byte>(alphabet, bytes=>new RubiksCube(bytes));
            this.Database = new Dictionary<RubiksCube, byte>(capacity);
            //this.Database = new ConcurrentDictionary<RubiksCube, byte>(numberOfThreads, capacity);
            //this.Database = new SkipList<RubiksCube, byte>();
        }

        private static byte[] GetAlphabet()
        {
            byte[] alphabet = new byte[Position.NumPositions];
            for (int i = 0; i < Position.NumPositions; ++i)
            {
                alphabet[i] = (byte)i;
            }
            return alphabet;
        }

        public void Insert(RubiksCube cube, byte depth)
        {
            //this.Database.Insert(cube, depth);
            this.Database.Add(cube, depth);
            //this.Database.TryAdd(cube, depth);
        }

        public bool Contains(RubiksCube cube)
        {
            //return this.Database.Contains(cube);
            return this.Database.ContainsKey(cube);
        }

        public IEnumerator<KeyValuePair<RubiksCube, byte>> GetEnumerator()
        {
            foreach (var item in this.Database)
                yield return item;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
