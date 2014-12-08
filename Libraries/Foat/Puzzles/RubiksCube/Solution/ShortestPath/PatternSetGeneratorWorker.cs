﻿namespace Foat.Puzzles.RubiksCube.Solution.ShortestPath
{
    using Foat.Puzzles.RubiksCube;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;

    /// <summary>
    /// A worker that does the pattern set generation.
    /// </summary>
    internal sealed class PatternSetGeneratorWorker
    {
        public int MaxDepth { get; private set; }

        public int GroupSize { get; private set; }
        
        /// <summary>
        /// A Dictionary used to map RubiksCubes to their solution distance which is shared with multiple PatternSetGeneratorWorkers.
        /// </summary>
        public ConcurrentDictionary<RubiksCube, byte> PatternDatabase { get; private set; }

        /// <summary>
        /// A queue containing all of the RubiksCubes that we have not yet examined (by applying all twists/moves to them).
        /// </summary>
        public ConcurrentQueue<RotatedCube> CubesToExamine { get; private set; }

        /// <summary>
        /// The current maximum number of moves found in the PatternSet so far.
        /// </summary>
        public int CurrentMaxDepth { get; private set; }

        public PatternSetGeneratorWorker(ConcurrentDictionary<RubiksCube, byte> patternDatabase, ConcurrentQueue<RotatedCube> cubesToExamine, int groupSize, int maxDepth)
        {
            this.MaxDepth = maxDepth;
            this.GroupSize = groupSize;

            this.PatternDatabase = patternDatabase;
            this.CubesToExamine = cubesToExamine;
            this.CurrentMaxDepth = 0;
        }

        public void Work()
        {
            Trace.WriteLine(string.Format("Worker {0:N0} Starting.", Thread.CurrentThread.ManagedThreadId));

            int count;
            while (this.CubesToExamine.Count > 0)
            {
                RotatedCube rotatedCube;
                if (this.CubesToExamine.TryDequeue(out rotatedCube))
                {
                    byte newDepth = (byte)(rotatedCube.Depth + 1);
                    this.CurrentMaxDepth = Math.Max(this.CurrentMaxDepth, newDepth);

                    IEnumerable<Move> moves = RubiksCubeController.GetValidMovesBasedOnPreviousMove(rotatedCube.Move);

                    foreach (Move move in moves)
                    {
                        RubiksCube newCube = RubiksCubeController.Rotate(rotatedCube.RubiksCube, move);

                        if (!this.PatternDatabase.ContainsKey(newCube) && newDepth <= this.MaxDepth)
                        {
                            this.CubesToExamine.Enqueue(new RotatedCube(move, newDepth, newCube));
                            lock (this.PatternDatabase)
                            {
                                this.PatternDatabase.AddOrUpdate(newCube, newDepth, (cube, depth) => Math.Min(newDepth, depth));
                                count = PatternDatabase.Count;
                            }
                            
                            Trace.WriteLineIf(count % 100000 == 0, string.Format("W{3:N0} - Cubes: {0:N0} Queue: {1:N0} Max Depth: {2:N0}", count, this.CubesToExamine.Count, this.CurrentMaxDepth, Thread.CurrentThread.ManagedThreadId));
                        }
                    }
                }
            }
            Trace.WriteLine(string.Format("Worker {0:N0} Ending.", Thread.CurrentThread.ManagedThreadId));
        }
    }
}
