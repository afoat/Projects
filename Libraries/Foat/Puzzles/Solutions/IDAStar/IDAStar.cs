namespace Foat.Puzzles.Solutions.IDAStar
{
    using Foat.Puzzles.Solutions;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// An algorithm for finding a shortest length solution to any IPuzzle
    /// 
    /// IDAStar Stands for Iterative Depth A*. The A* algorithm uses a depth first search with a heuristic
    /// to help decide which order to perform the puzzle moves in. The iterative depth version does multiple
    /// iterations of the A* algorithm using a different bound on the depth of the solution tree each time.
    /// This ensures that we still find a solution of minimum length but keeps us from traversing too far
    /// down the wrong branch of the tree which would waste time and memory.
    /// </summary>
    public class IDAStar<TPuzzle> : IPuzzleSolution<TPuzzle> where TPuzzle : IPuzzle<TPuzzle>, IEquatable<TPuzzle>
    {
        #region Properties

        /// <summary>
        /// The number of nodes that were fully expanded in the final iteration of the search.
        /// </summary>
        public long NumberOfExpandedNodes { get; protected set; }

        internal readonly TPuzzle _solutionState;

        /// <summary>
        /// Stores the solved puzzle so that we can know when we reach the goal.
        /// </summary>
        public TPuzzle SolutionState
        {
            get
            {
                return _solutionState;
            }
        }

        /// <summary>
        /// An admissible heuristic function used to estimate the number of moves necessary to reach the solution.
        /// </summary>
        protected IHeuristic<TPuzzle> Heuristic { get; set; }

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the IDAStar class and prepares it to find solutions to randomized instances of a puzzle.
        /// </summary>
        /// <param name="heuristic">An admissible heuristic used to estimate the length of the solution.</param>
        /// <param name="solutionState">The state of the puzzle that we will be searching for.</param>
        public IDAStar(IHeuristic<TPuzzle> heuristic, TPuzzle solution)
        {
            if (heuristic == null)
                throw new ArgumentNullException("heuristic");

            if (solution == null)
                throw new ArgumentNullException("solution");

            _solutionState = solution;
            this.Heuristic = heuristic;

            this.Heuristic.RegisterSolution(this.SolutionState);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Finds the smallest list of moves possible, that when applied to a puzzle will leave it in the solved state.
        /// </summary>
        /// <param name="puzzleInstance">A randomized puzzle</param>
        /// <returns>Null if no solution is found, otherwise it returns an enum of move IDs that will solve the puzzle.</returns>
        public virtual IEnumerable<Move<TPuzzle>> Solve(TPuzzle puzzleInstance)
        {
            if (puzzleInstance == null)
                throw new ArgumentNullException("puzzleInstance");

            int maxDepth = this.Heuristic.GetMinimumEstimatedSolutionLength(puzzleInstance);

            IEnumerable<Move<TPuzzle>> solution = null;

            DepthLimitedAStar<TPuzzle> depthLimitedSearch = new DepthLimitedAStar<TPuzzle>(this.Heuristic, this.SolutionState);
            while (solution == null && maxDepth != 0)
            {
                Trace.WriteLine(string.Format(Logging.IDAStarDepthUpdate, maxDepth));

                depthLimitedSearch.Reset();

                maxDepth = depthLimitedSearch.DepthLimitedDFS(new PuzzleState<TPuzzle>(0, puzzleInstance), maxDepth);

                if (maxDepth == 0)
                {
                    solution = depthLimitedSearch.Solution;
                    this.NumberOfExpandedNodes = depthLimitedSearch.NumberOfExpandedNodes;
                }
            }

            return solution;
        }

        /// <summary>
        /// Returns the number of nodes that were fully expanded in the final iteration of the search.
        /// </summary>
        public long GetNumberOfExpandedNodes()
        {
            return this.NumberOfExpandedNodes;
        }

        #endregion
    }
}
