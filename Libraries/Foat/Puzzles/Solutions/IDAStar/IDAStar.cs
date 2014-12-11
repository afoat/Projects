namespace Foat.Puzzles.Solutions.IDAStar
{
    using Foat.Puzzles.Solutions;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

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

        public ulong NumberOfExpandedNodes { get; protected set; }

        /// <summary>
        /// Stores the solved puzzle so that we can know when we reach the goal.
        /// </summary>
        protected readonly TPuzzle SolutionState;

        /// <summary>
        /// The heuristic function used to estimate the number of moves necessary to reach the solution.
        /// </summary>
        protected IHeuristic<TPuzzle> Heuristic { get; set; }

        #endregion

        #region Construction

        public IDAStar(IHeuristic<TPuzzle> heuristic, TPuzzle solution)
        {
            if (heuristic == null)
                throw new ArgumentNullException("heuristic");

            if (solution == null)
                throw new ArgumentNullException("solution");

            this.SolutionState = solution;
            this.Heuristic = heuristic;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Finds the smallest list of moves possible, that when applied to a puzzle will leave it in the solved state.
        /// </summary>
        /// <param name="puzzleInstance">A randomized puzzle</param>
        /// <returns>Null if no solution is found, otherwise it returns an enum of move IDs that will solve the puzzle.</returns>
        public virtual IEnumerable<Move<TPuzzle>> FindSolution(TPuzzle puzzleInstance)
        {
            if (puzzleInstance == null)
                throw new ArgumentNullException("puzzleInstance");

            Stack<Move<TPuzzle>> solution = new Stack<Move<TPuzzle>>();

            bool found = false;
            int maxDepth = this.Heuristic.GetMinimumEstimatedSolutionLength(puzzleInstance);
            ulong expandedNodes = 0;
            long time = 0;

            while (!found)
            {
                Trace.WriteLine(string.Format(Logging.IDAStarDepthUpdate, maxDepth, time));
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                found = DepthLimitedDFS(new PuzzleState<TPuzzle>(0, puzzleInstance), maxDepth, solution, ref expandedNodes);
                stopwatch.Stop();
                time = stopwatch.ElapsedMilliseconds;
                ++maxDepth;
            }

            this.NumberOfExpandedNodes = expandedNodes;

            return solution;
        }

        public ulong GetNumberOfExpandedNodes()
        {
            return this.NumberOfExpandedNodes;
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Does a depth first search for the solved puzzle state. The search will cease after it reaches a certain depth regardless
        /// of whether or not a solution was found.
        /// </summary>
        /// <param name="puzzleState">Current state of the puzzle while we are finding a solution.</param>
        /// <param name="maxDepth">Determines how deep we will search for a solution in the tree.</param>
        /// <param name="solution">The solution that has been found.</param>
        /// <returns></returns>
        protected bool DepthLimitedDFS(PuzzleState<TPuzzle> puzzleState, int maxDepth, Stack<Move<TPuzzle>> solution, ref ulong expandedNodes)
        {
            if (puzzleState.PuzzleInstance.Equals(this.SolutionState))
            {
                return true;
            }

            IEnumerable<PuzzleState<TPuzzle>> orderedPuzzlesToExamine = GetPuzzleStatesToExamine(puzzleState, maxDepth);

            expandedNodes++;
            foreach (PuzzleState<TPuzzle> newPuzzleState in orderedPuzzlesToExamine)
            {
                if (DepthLimitedDFS(newPuzzleState, maxDepth, solution, ref expandedNodes))
                {
                    solution.Push(newPuzzleState.LastMove);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Each puzzle has N moves that can be applied to it. This method will retrive a list of puzzle states
        /// resulting from applying each move to the puzzle. The puzzles returned are ordered such that the
        /// one with the shortest estimated solution is first. Any puzzle state with an estimated solution
        /// distance that is too large will not be returned.
        /// </summary>
        /// <param name="puzzleInstance">The puzzle that we will be examining.</param>
        /// <param name="maxDepth">The maximum estimated solution length that we are willing to accept.</param>
        /// <returns>A list of puzzle states that all have an estimated solution distance smaller than the
        /// specified max. The list is sorted by estimated solution distance.</returns>
        protected IEnumerable<PuzzleState<TPuzzle>> GetPuzzleStatesToExamine(PuzzleState<TPuzzle> puzzleInstance, int maxDepth)
        {
            // Not all moves are valid depending on the previous move.
            // e.g. If I perform one move, it makes no senses to try the exact opposite of that move
            // Pruning the tree like this makes it quite a bit more efficient.
            IEnumerable<Move<TPuzzle>> moves;
            if (puzzleInstance.LastMove == null)
            {
                moves = puzzleInstance.PuzzleInstance.GetValidMoves();
            }
            else
            {
                moves = puzzleInstance.LastMove.GetValidNextMoves(puzzleInstance.PuzzleInstance);
            }

            // Get the estimated solution depth of the puzzle that results from each possible move
            // Filter out the ones that have an estimate that is larger than maxDepth
            // And sort them in ascending order by EstimatedDepth
            return moves.Select(move => new PuzzleState<TPuzzle>(move, (byte)(puzzleInstance.Depth + 1), move.MovePuzzle(puzzleInstance.PuzzleInstance)))
                        .Select(newPuzzleState => new { PuzzleState = newPuzzleState, EstimatedDepth = GetEstimatedDepth(newPuzzleState) })
                        .Where(newPuzzleState => newPuzzleState.EstimatedDepth <= maxDepth)
                        .OrderBy(newPuzzleState => newPuzzleState.EstimatedDepth)
                        .Select(newPuzzleState => newPuzzleState.PuzzleState);
        }

        protected IEnumerable<PuzzleState<TPuzzle>> GetPuzzleStatesToExamine(PuzzleState<TPuzzle> puzzleInstance)
        {
            return GetPuzzleStatesToExamine(puzzleInstance, int.MaxValue);
        }

        /// <summary>
        /// Calculates the estimated solution depth of a puzzle state.
        /// </summary>
        /// <returns>The estimated depth = Actual Depth of Puzzle State + EstimatedSolutionLength for that Puzzle State.</returns>
        protected int GetEstimatedDepth(PuzzleState<TPuzzle> puzzleInstance)
        {
            return puzzleInstance.Depth + this.Heuristic.GetMinimumEstimatedSolutionLength(puzzleInstance.PuzzleInstance);
        }

        #endregion


    }
}
