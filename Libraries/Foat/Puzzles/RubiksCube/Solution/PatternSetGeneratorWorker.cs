namespace Foat.Puzzles.RubiksCube.Solution
{
    using Foat.Puzzles.RubiksCube;
    using Foat.Puzzles.Solutions;
    using System;
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
        public RubiksCubeDepthDatabase PatternDatabase { get; private set; }

        /// <summary>
        /// A queue containing all of the RubiksCubes that we have not yet examined (by applying all twists/moves to them).
        /// </summary>
        public PuzzleStateQueue CubesToExamine { get; private set; }

        /// <summary>
        /// The current maximum number of moves found in the PatternSet so far.
        /// </summary>
        public int CurrentMaxDepth { get; private set; }

        public PatternSetGeneratorWorker(RubiksCubeDepthDatabase patternDatabase, PuzzleStateQueue cubesToExamine, int groupSize, int maxDepth)
        {
            this.MaxDepth = maxDepth;
            this.GroupSize = groupSize;

            this.PatternDatabase = patternDatabase;
            this.CubesToExamine = cubesToExamine;
            this.CurrentMaxDepth = 0;
        }

        public void Work()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int updateFlag = 0;
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

                        lock (this.PatternDatabase)
                        {
                            if (!this.PatternDatabase.Contains(rubiksCube) && newDepth <= this.MaxDepth)
                            {
                                while (!this.CubesToExamine.TryEnqueue(new PuzzleState<RubiksCube>(move, newDepth, rubiksCube))) { }
                                this.PatternDatabase.Insert(rubiksCube, newDepth);
                            }
                        }

                        updateFlag = (updateFlag + 1) % 300000;
                        if (updateFlag == 0)
                        {
                            Trace.WriteLine(string.Format("Confirmed found: {0:N0} To Examine: {1:N0} Current Max Depth: {2}. Total Time: {3}", this.PatternDatabase.Count, this.CubesToExamine.Count, this.CurrentMaxDepth, sw.ElapsedMilliseconds));
                        }
                    }
                }
            }
        }
    }
}
