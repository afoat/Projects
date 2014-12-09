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
    public class IDAStar<TPuzzle> : IPuzzleSolution<TPuzzle> where TPuzzle : IPuzzle<TPuzzle>
    {
        /// <summary>
        /// Stores the solved puzzle so that we can know when we reach the goal.
        /// </summary>
        protected readonly TPuzzle SolutionState;

        /// <summary>
        /// The heuristic function used to estimate the number of moves necessary to reach the solution.
        /// </summary>
        protected IHeuristic<TPuzzle> Heuristic { get; set; }

        public IDAStar(IHeuristic<TPuzzle> heuristic, TPuzzle solutionInstance)
        {
            if (heuristic == null)
                throw new ArgumentNullException("heuristic");

            this.SolutionState = solutionInstance;
            this.Heuristic = heuristic;
        }

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

            while (!found)
            {
                Trace.WriteLine(string.Format("IDA* - Bound = {0:N0}", maxDepth));
                if (DepthLimitedDFS(new PuzzleState<TPuzzle>(0, puzzleInstance), maxDepth, solution))
                {
                    found = true;
                }

                ++maxDepth;
            }

            return solution;
        }

        /// <summary>
        /// Does a depth first search for the solved puzzle state. The search will cease after it reaches a certain depth regardless
        /// of whether or not a solution was found.
        /// </summary>
        /// <param name="puzzleState">Current state of the puzzle while we are finding a solution.</param>
        /// <param name="maxDepth">Determines how deep we will search for a solution in the tree.</param>
        /// <param name="solution">The solution that has been found.</param>
        /// <returns></returns>
        internal bool DepthLimitedDFS(PuzzleState<TPuzzle> puzzleState, int maxDepth, Stack<Move<TPuzzle>> solution)
        {
            if (puzzleState.PuzzleInstance.Equals(this.SolutionState))
            {
                return true;
            }

            IEnumerable<PuzzleState<TPuzzle>> orderedPuzzlesToExamine = GetPuzzleStatesToExamine(puzzleState, maxDepth);

            foreach (PuzzleState<TPuzzle> newPuzzleState in orderedPuzzlesToExamine)
            {
                if (DepthLimitedDFS(newPuzzleState, maxDepth, solution))
                {
                    solution.Push(newPuzzleState.LastMove);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Each puzzle N moves that can be applied to it. This method will retrive a list of puzzle states
        /// resulting from applying each move to the puzzle. The puzzles returned are ordered such that the
        /// one with the shortest estimated solution is first. Any puzzle state with an estimated solution
        /// distance that is too large will not be returned.
        /// </summary>
        /// <param name="puzzleInstance">The puzzle that we will be examining.</param>
        /// <param name="maxDepth">The maximum estimated solution length that we are willing to accept.</param>
        /// <returns>A list of puzzle states that all have an estimated solution distance smaller than the
        /// specified max. The list is sorted by estimated solution distance.</returns>
        private IEnumerable<PuzzleState<TPuzzle>> GetPuzzleStatesToExamine(PuzzleState<TPuzzle> puzzleInstance, int maxDepth)
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
                moves = puzzleInstance.LastMove.GetValidNextMoves();
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

        /// <summary>
        /// Calculates the estimated solution depth of a puzzle state.
        /// </summary>
        /// <returns>The estimated depth = Actual Depth of Puzzle State + EstimatedSolutionLength for that Puzzle State.</returns>
        private byte GetEstimatedDepth(PuzzleState<TPuzzle> puzzleInstance)
        {
            return (byte)(puzzleInstance.Depth + this.Heuristic.GetMinimumEstimatedSolutionLength(puzzleInstance.PuzzleInstance));
        }
    }
}
