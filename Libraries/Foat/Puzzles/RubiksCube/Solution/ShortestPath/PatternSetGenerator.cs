namespace Foat.Puzzles.RubiksCube.Solution.ShortestPath
{
    using Foat.Hashing;
    using Foat.Puzzles.RubiksCube;
    using System.Collections.Concurrent;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    
    /// <summary>
    /// This class generates a PatternSet that contains every cube that can possibly be reached by twisting a cube defined by an initial Pattern.
    /// </summary>
    public static class PatternSetGenerator
    {
        #region Static Methods

        /// <summary>
        /// Generates the entire PatternSet using the given Pattern as a starting point.
        /// </summary>
        /// <param name="pattern">The initial pattern in the set.</param>
        /// <param name="numberOfThreads">The number of threads to use while generating the pattern set.</param>
        public static PatternSet Generate(Pattern pattern, int numberOfThreads)
        {
            ConcurrentDictionary<RubiksCube, byte> patternSetDictionary = GeneratePatternSetDictionary(pattern, numberOfThreads);
            MinimalPerfectHash<FnvHash> mph = GetMinimalPerfectHashForPatternSet(patternSetDictionary);

            Trace.WriteLine("Finished generating minimal perfect hash.");
            Trace.WriteLine("Creating new Pattern Set.");

            return new PatternSet(patternSetDictionary, mph, pattern);
        }

        /// <summary>
        /// Generates a minimal perfect hash for every cube in the PatternSet. This is a hash that can map any cube in the set
        /// to an index in the range of 0 ... N - 1 where N is the number of cubes in the entire set. Useful for constant time
        /// lookups of any cube in the set.
        /// </summary>
        /// <param name="database"></param>
        /// <returns></returns>
        private static MinimalPerfectHash<FnvHash> GetMinimalPerfectHashForPatternSet(ConcurrentDictionary<RubiksCube, byte> database)
        {
            MinimalPerfectHash<FnvHash> mph = new MinimalPerfectHash<FnvHash>();
            mph.Generate(database.Keys);
            return mph;
        }

        /// <summary>
        /// Generates a dictionary that maps RubiksCubes to the minimum number of moves it will take to solve that cube.
        /// </summary>
        /// <param name="pattern">The initial pattern that will be used to generate every other RubiksCube in the PatternSet.</param>
        /// <param name="numberOfThreads">The number of threads to use while generating the pattern set dictionary.</param>
        /// <returns></returns>
        private static ConcurrentDictionary<RubiksCube, byte> GeneratePatternSetDictionary(Pattern pattern, int numberOfThreads)
        {
            ConcurrentDictionary<RubiksCube, byte> patternDatabase = new ConcurrentDictionary<RubiksCube, byte>(numberOfThreads, pattern.GroupSize);
            ConcurrentQueue<RotatedCube> cubesToExamine = new ConcurrentQueue<RotatedCube>();

            SetInitalState(pattern, patternDatabase, cubesToExamine);

            PatternSetGeneratorWorker[] workers = new PatternSetGeneratorWorker[numberOfThreads];
            Task[] tasks = new Task[numberOfThreads];


            for (int i = 0; i < numberOfThreads; ++i)
            {
                Trace.WriteLine(string.Format("Creating Worker {0:N0}.", i));
                tasks[i] = Task.Factory.StartNew(() =>
                {
                    new PatternSetGeneratorWorker(
                        patternDatabase, 
                        cubesToExamine, 
                        pattern.GroupSize, 
                        pattern.MaxDepth
                        ).Work();
                });

                if (i == 0)
                {
                    // Give the first thread an opportunity to fill up the queue of cubes
                    // so the other threads have something to work on when they start.
                    Thread.SpinWait(50000000);
                }
            }

            Task.WaitAll(tasks);

            int maxDepth = patternDatabase.Values.Max();

            Trace.WriteLine(string.Format("Found a set of {0:N0} Rubik's Cubes,  Longest solution is {1:N0}.", patternDatabase.Count, maxDepth));

            return patternDatabase;
        }

        /// <summary>
        /// Initializes the PatternSetGenerator to run.
        private static void SetInitalState(Pattern pattern, ConcurrentDictionary<RubiksCube, byte> patternDatabase, ConcurrentQueue<RotatedCube> cubesToExamine)
        {
            RubiksCube newCube = new RubiksCube().ApplyMask(pattern.Mask);
            cubesToExamine.Enqueue(new RotatedCube(null, 0, newCube));
            patternDatabase[newCube] = 0;
        }

        #endregion
    }
}