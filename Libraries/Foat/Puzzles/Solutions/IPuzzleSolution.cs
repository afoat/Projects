namespace Foat.Puzzles.Solutions
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents an algorithm, or other similar class capable of finding a solution to a particular puzzle.
    /// </summary>
    public interface IPuzzleSolution<TPuzzle> where TPuzzle : IPuzzle<TPuzzle>, IEquatable<TPuzzle>
    {
        /// <summary>
        /// Attempts to find a solution for an instance of the puzzle and will return an 
        /// orderd list of moves that must be performed in order to solve the puzzle.
        /// </summary>
        /// <param name="puzzleInstance">The randomized puzzle that will be solved.</param>
        IEnumerable<Move<TPuzzle>> Solve(TPuzzle puzzleInstance);

        /// <summary>
        /// Returns a small statistic indicating roughly how many puzzle states were expanded while finding a solution.
        /// </summary
        /// <returns></returns>
        long GetNumberOfExpandedNodes();
    }
}
