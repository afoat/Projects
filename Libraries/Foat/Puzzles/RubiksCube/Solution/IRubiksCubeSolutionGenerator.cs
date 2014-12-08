namespace Foat.Puzzles.RubiksCube.Solution
{
    using System.Collections.Generic;

    /// <summary>
    /// An IRubiksCubeSolutionGenerator can find a solution to any random RubiksCube.
    /// </summary>
    public interface IRubiksCubeSolutionGenerator
    {
        /// <summary>
        /// Returns a queue of moves that would need to be performed on a RubiksCube in order to solve it.
        /// </summary>
        /// <param name="rubiksCube">The RubiksCube for which we want to find a solution.</param>
        /// <returns></returns>
        IEnumerable<Move> FindSolution(RubiksCube rubiksCube);
    }
}
