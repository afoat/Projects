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
        private Dictionary<RubiksCube, byte> Database;
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
            this.Database = new Dictionary<RubiksCube, byte>(capacity);
        }

        public void Insert(RubiksCube cube, byte depth)
        {
            this.Database.Add(cube, depth);
        }

        public bool Contains(RubiksCube cube)
        {
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
