namespace Foat.Puzzles.Solutions
{
    /// <summary>
    /// A heuristic is capable of estimating the cost of finding a solution. For our purposes, the heuristics
    /// are meant to be admissible. That means that the heuristic never overestimates the cost of the solution.
    /// It is optimistic and should return a value smaller than the actual cost.
    /// </summary>
    /// <typeparam name="TPuzzle"></typeparam>
    public interface IHeuristic<TPuzzle>
    {
        /// <summary>
        /// Calculates the estimated length or cost of the solution.
        /// </summary>
        /// <param name="puzzleInstance">The puzzle for which we want to find an estimate for.</param>
        int GetMinimumEstimatedSolutionLength(TPuzzle puzzleInstance);
    }
}
