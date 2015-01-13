namespace Foat.Puzzles.Solutions
{
    using System;

    /// <summary>
    /// A puzzle has moves that when applied to the puzzle will yield a new state of that puzzle.
    /// </summary>
    /// <typeparam name="TPuzzle"></typeparam>
    public interface IPuzzle<TPuzzle> where TPuzzle : IPuzzle<TPuzzle>, IEquatable<TPuzzle>
    {
        /// <summary>
        /// Finds all of the current valid moves for a puzzle.
        /// </summary>
        Move<TPuzzle>[] GetValidMoves();

        Move<TPuzzle>[] GetAllMoves();

        TPuzzle ApplyMask(TPuzzle mask);
    }
}
