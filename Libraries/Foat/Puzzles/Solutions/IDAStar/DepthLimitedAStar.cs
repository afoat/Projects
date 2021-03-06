﻿namespace Foat.Puzzles.Solutions.IDAStar
{
    using Foat.Puzzles.Solutions.Heuristics;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A helper class that encppssulates the logic to perform the Depth Limited A* Search. This is used by the IDAStar algorithm and
    /// by the individual tasks when ParallelIDAStar is in use.
    /// </summary>
    /// <typeparam name="TPuzzle"></typeparam>
    internal sealed class DepthLimitedAStar<TPuzzle> where TPuzzle : IPuzzle<TPuzzle>, IEquatable<TPuzzle>
    {
        /// <summary>
        /// Once the search has completed this will contain the solution if one was found.
        /// </summary>
        internal Stack<Move<TPuzzle>> Solution { get; private set; }

        /// <summary>
        /// The number of nodes that were fully expanded in this instance of the search.
        /// </summary>
        internal long NumberOfExpandedNodes { get; private set; }

        internal readonly TPuzzle _solutionState;

        /// <summary>
        /// Stores the solved puzzle so that we can know when we reach the goal.
        /// </summary>
        internal TPuzzle SolutionState
        {
            get
            {
                return _solutionState;
            }
        }

        /// <summary>
        /// The heuristic function used to estimate the number of moves necessary to reach the solution.
        /// </summary>
        internal IHeuristic<TPuzzle> Heuristic { get; private set; }

        /// <summary>
        /// Initializes a new instance of the DepthLimitedAStar class and prepares it to find solutions to randomized instances of a puzzle.
        /// </summary>
        /// <param name="heuristic">An admissible heuristic used to estimate the length of the solution.</param>
        /// <param name="solutionState">The state of the puzzle that we will be searching for.</param>
        internal DepthLimitedAStar(IHeuristic<TPuzzle> heuristic, TPuzzle solutionState)
        {
            if (heuristic == null)
                throw new ArgumentNullException("heuristic");

            if (solutionState == null)
                throw new ArgumentNullException("solution");

            _solutionState = solutionState;
            this.Heuristic = heuristic;
            this.Reset();
        }

        /// <summary>
        /// Does a depth first search for the solved puzzle state. The search will cease after it reaches a certain depth regardless
        /// of whether or not a solution was found.
        /// </summary>
        /// <param name="puzzleState">Current state of the puzzle while we are finding a solution.</param>
        /// <param name="maxDepth">Determines how deep we will search for a solution in the tree.</param>
        /// <param name="solution">The solution that has been found.</param>
        /// <returns></returns>
        internal int DepthLimitedDFS(PuzzleState<TPuzzle> puzzleState, int maxDepth)
        {
            int currentHeuristic = GetEstimatedDepth(puzzleState);
            if (currentHeuristic > maxDepth)
            {
                return currentHeuristic;
            }

            this.NumberOfExpandedNodes++;

            if (puzzleState.PuzzleInstance.Equals(this.SolutionState))
            {
                this.Solution = new Stack<Move<TPuzzle>>();
                return 0;
            }

            int newMaxDepth = int.MaxValue;

            PuzzleState<TPuzzle>[] puzzlesToExamine = PuzzleStateExpander<TPuzzle>.GetPuzzleStatesToExamine(puzzleState, maxDepth);
            for (int i = 0; i < puzzlesToExamine.Length; i++)
            {
                int results = DepthLimitedDFS(puzzlesToExamine[i], maxDepth);
                if (results == 0)
                {
                    this.Solution.Push(puzzlesToExamine[i].LastMove);
                    return results;
                }
                else if (results < newMaxDepth)
                {
                    newMaxDepth = results;
                }
            }

            return newMaxDepth;
        }

        internal void Reset()
        {
            this.NumberOfExpandedNodes = 0;
            this.Solution = null;
        }

        /// <summary>
        /// Calculates the estimated solution depth of a puzzle state.
        /// </summary>
        /// <returns>The estimated depth = Actual Depth of Puzzle State + EstimatedSolutionLength for that Puzzle State.</returns>
        private int GetEstimatedDepth(PuzzleState<TPuzzle> puzzleState)
        {
            return puzzleState.Depth + this.Heuristic.GetMinimumEstimatedSolutionLength(puzzleState.PuzzleInstance);
        }
    }
}
