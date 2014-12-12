namespace Foat.Puzzles.Solutions.IDAStar
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A helper class for the ParallelIDAStar algorithm. Contains information used to intialize the
    /// search on a new thread and also to store the results of the thread once it finishes.
    /// </summary>
    internal class IDAStarTask<TPuzzle> where TPuzzle : IPuzzle<TPuzzle>, IEquatable<TPuzzle>
    {
        /// <summary>
        /// A flag indicating whether or not a solution was found.
        /// </summary>
        internal bool SolutionFound { get; set; }

        /// <summary>
        /// A randomized copy of the puzzle that we want to find a solution for.
        /// </summary>
        internal PuzzleState<TPuzzle> MixedPuzzleState { get; private set; }

        /// <summary>
        /// Once the search finishes, this will contain an ordered list of moves that can be applied to the MixedPuzzleState in order to reach the goal state.
        /// </summary>
        internal Stack<Move<TPuzzle>> Solution { get; set; }

        /// <summary>
        /// If no solution was found in the task, this value will contain the next suggested value for the MaxDepth.
        /// </summary>
        internal int NextMaxDepth { get; set; }

        /// <summary>
        /// After a successful search this will contain the number of nodes that were fully expanded by the algorithm.
        /// </summary>
        internal long NumberOfExpandedNodes { get; set; }

        internal IDAStarTask(PuzzleState<TPuzzle> mixedPuzzleState)
        {
            this.MixedPuzzleState = mixedPuzzleState;

            this.Solution = new Stack<Move<TPuzzle>>();
        }

    }
}
