namespace Foat.Puzzles.RubiksCube.Solution
{
    using Foat.Hashing;
    using Foat.Puzzles.RubiksCube;
    using Foat.Puzzles.Solutions;
    using Foat.Collections.Generic.MMF;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
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
            MinimalPerfectHash<FnvHash> mph = GetMinimalPerfectHashForPatternSet(patternSetDictionary.Keys);

            return new PatternSet(patternSetDictionary, mph, pattern);
        }

        /// <summary>
        /// Generates a minimal perfect hash for every cube in the PatternSet. This is a hash that can map any cube in the set
        /// to an index in the range of 0 ... N - 1 where N is the number of cubes in the entire set. Useful for constant time
        /// lookups of any cube in the set.
        /// </summary>
        /// <param name="database"></param>
        /// <returns></returns>
        private static MinimalPerfectHash<FnvHash> GetMinimalPerfectHashForPatternSet(IEnumerable<RubiksCube> cubes)
        {
            MinimalPerfectHash<FnvHash> mph = new MinimalPerfectHash<FnvHash>();
            mph.Generate(cubes.Select(cube=>cube.GetBytes()));
                       
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

            RubiksCube newMaskedCube = new RubiksCube().ApplyMask(pattern.Mask);
            PuzzleState<RubiksCube> puzzleState = new PuzzleState<RubiksCube>(0, newMaskedCube);
            PuzzleStateQueue cubesToExamine = new PuzzleStateQueue(puzzleState.GetNumBytes(), 50000000, 100000);
            SetInitalState(puzzleState, patternDatabase, cubesToExamine);

            PatternSetGeneratorWorker[] workers = new PatternSetGeneratorWorker[numberOfThreads];
            Task[] tasks = new Task[numberOfThreads];


            for (int i = 0; i < numberOfThreads; ++i)
            {
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

            return patternDatabase;
        }

        /// <summary>
        /// Initializes the PatternSetGenerator to run.
        private static void SetInitalState(PuzzleState<RubiksCube> puzzleState, ConcurrentDictionary<RubiksCube, byte> patternDatabase, PuzzleStateQueue cubesToExamine)
        {
            cubesToExamine.TryEnqueue(puzzleState);
            patternDatabase.AddOrUpdate(puzzleState.PuzzleInstance, 0, (cube, currentDepth)=>Math.Min(currentDepth, (byte)0));
        }

        #endregion
    }
}