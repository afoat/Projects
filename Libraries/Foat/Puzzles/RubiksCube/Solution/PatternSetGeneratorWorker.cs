namespace Foat.Puzzles.RubiksCube.Solution
{
    using Foat.Puzzles.RubiksCube;
    using Foat.Puzzles.Solutions;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;

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
        public ConcurrentQueue<PuzzleState<RubiksCube>> CubesToExamine { get; private set; }

        /// <summary>
        /// The current maximum number of moves found in the PatternSet so far.
        /// </summary>
        public int CurrentMaxDepth { get; private set; }
        
        public PatternSetGeneratorWorker(ConcurrentDictionary<RubiksCube, byte> patternDatabase, ConcurrentQueue<PuzzleState<RubiksCube>> cubesToExamine, int groupSize, int maxDepth)
        {
            this.MaxDepth = maxDepth;
            this.GroupSize = groupSize;

            this.PatternDatabase = patternDatabase;
            this.CubesToExamine = cubesToExamine;
            this.CurrentMaxDepth = 0;
        }

        public void Work()
        {
            while (this.CubesToExamine.Count > 0)
            {
                PuzzleState<RubiksCube> puzzleState;
                if (this.CubesToExamine.TryDequeue(out puzzleState))
                {
                    byte newDepth = (byte)(puzzleState.Depth + 1);
                    this.CurrentMaxDepth = Math.Max(this.CurrentMaxDepth, newDepth);

                    IEnumerable<Move<RubiksCube>> moves;
                    if (puzzleState.LastMove == null)
                    {
                        moves = puzzleState.PuzzleInstance.GetValidMoves();
                    }
                    else
                    {
                        moves = puzzleState.LastMove.GetValidNextMoves(puzzleState.PuzzleInstance);
                    }

                    RubiksCube rubiksCube;
                    foreach (Move<RubiksCube> move in moves)
                    {
                        rubiksCube = move.MovePuzzle(puzzleState.PuzzleInstance);

                        if (!this.PatternDatabase.ContainsKey(rubiksCube) && newDepth <= this.MaxDepth)
                        {
                            this.CubesToExamine.Enqueue(new PuzzleState<RubiksCube>(move, newDepth, rubiksCube));
                            lock (this.PatternDatabase)
                            {
                                this.PatternDatabase.AddOrUpdate(rubiksCube, newDepth, (cube, curDepth)=>Math.Min(curDepth, newDepth));

                                if (PatternDatabase.Count % 10000 == 0)
                                {
                                    Trace.WriteLine(string.Format("Found {0:N0} states so far. {1:N0} Cubes to Examine.", this.PatternDatabase.Count, this.CubesToExamine.Count));
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
