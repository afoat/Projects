namespace Foat.Puzzles.Solutions
{
    using System;

    /// <summary>
    /// Contains a puzzle and some information relevant to the current state of the puzzle.
    /// </summary>
    public class PuzzleState<TPuzzle> where TPuzzle : IPuzzle<TPuzzle>, IEquatable<TPuzzle>
    {
        /// <summary>
        /// The most recent move that was most recently applied in order to arrive at this puzzle.
        /// </summary>
        public Move<TPuzzle> LastMove { get; private set; }

        /// <summary>
        /// The number of moves that have been applied to this puzzle state since we started looking for a solution.
        /// </summary>
        public byte Depth { get; private set; }

        /// <summary>
        /// The instance of the puzzle that applies to this state information.
        /// </summary>
        public TPuzzle PuzzleInstance { get; private set; }

        public PuzzleState(byte depth, TPuzzle puzzleInstance)
        {
            this.LastMove = null;
            this.Depth = depth;
            this.PuzzleInstance = puzzleInstance;
        }

        public PuzzleState(Move<TPuzzle> move, byte depth, TPuzzle puzzleInstance)
        {
            this.LastMove = move;
            this.Depth = depth;
            this.PuzzleInstance = puzzleInstance;
        }
    }
}
