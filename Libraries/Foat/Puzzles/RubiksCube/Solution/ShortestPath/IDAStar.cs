namespace Foat.Puzzles.RubiksCube.Solution.ShortestPath
{
    using Foat.Puzzles.RubiksCube;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    /// <summary>
    /// An algorithm for finding a shortest length solution to any random RubiksCube.
    /// 
    /// IDAStar Stands for Iterative Depth A*. The A* algorithm can find the shortest path to a solution.
    /// The iterative depth version does multiple iterations of the A* algorithm using a different bound
    /// on the depth of the solution each time. This ensures that we still find a solution of minimum length
    /// but keeps us from traversing too far down the wrong branch of the tree which would waste memory.
    /// </summary>
    public class IDAStar : IRubiksCubeSolutionGenerator
    {
        protected const byte MaxSolutionDepth = 20;

        /// <summary>
        /// Stores the solved RubiksCube so that we can know when we are finished a puzzle.
        /// </summary>
        protected readonly RubiksCube SolutionState;

        protected SolutionLengthEstimator SolutionLengthEstimator { get; set; }

        public IDAStar(SolutionLengthEstimator solutionLengthEstimator)
        {
            if (solutionLengthEstimator == null)
                throw new ArgumentNullException("solutionLengthEstimator");

            this.SolutionState = new RubiksCube();
            this.SolutionLengthEstimator = solutionLengthEstimator;
        }

        /// <summary>
        /// Finds the smallest list of moves possible, that when applied to a Rubiks Cube will leave it in the solved state.
        /// </summary>
        /// <param name="rubiksCube">A random RubiksCube</param>
        /// <returns>Null if no solution is found, otherwise it returns an enum of moves that will solve the cube.</returns>
        public virtual IEnumerable<Move> FindSolution(RubiksCube rubiksCube)
        {
            if (rubiksCube == null)
                throw new ArgumentNullException("rubiksCube");

            Stack<Move> solution = new Stack<Move>(MaxSolutionDepth);

            bool found = false;
            byte maxDepth = this.SolutionLengthEstimator.GetMinimumEstimatedSolutionLength(rubiksCube);

            while (!found)
            {
                Trace.WriteLine(string.Format("IDA* - Bound = {0:N0}", maxDepth));
                if (DepthLimitedDFS(new RotatedCube(null, 0, rubiksCube), maxDepth, solution))
                {
                    found = true;
                }

                ++maxDepth;
            }

            return solution;
        }

        /// <summary>
        /// Does a depth first search for the solved RubiksCube that will stop after it reaches a certain depth.
        /// </summary>
        /// <param name="rotatedCube">A RotatedCube representing the randomized RubiksCube for which a solution will be found.</param>
        /// <param name="maxDepth">Determines how deep we will search for a solution in the tree.</param>
        /// <param name="solution">The solution that has been found.</param>
        /// <returns></returns>
        internal bool DepthLimitedDFS(RotatedCube rotatedCube, byte maxDepth, Stack<Move> solution)
        {
            if (rotatedCube.RubiksCube.Equals(this.SolutionState))
            {
                return true;
            }

            IEnumerable<RotatedCube> orderedCubesToExamine = GetRotatedCubesToExamine(rotatedCube, maxDepth);

            foreach (RotatedCube newRotatedCube in orderedCubesToExamine)
            {
                if (DepthLimitedDFS(newRotatedCube, maxDepth, solution))
                {
                    solution.Push(newRotatedCube.Move.Value);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Each RubiksCube can have one of 18 different moves (3 moves * 6 sides = 18) that can be applied to it. This method
        /// will retrive a list of these cubes ordered such that the one with the shortest estimated solution is first. Any
        /// RotatedCube with an estimated solution distance that is too large will not be returned.
        /// </summary>
        /// <param name="rotatedCube">The RotatedCube that we will be examining.</param>
        /// <param name="maxDepth">The maximum estimated solution length that we are willing to accept.</param>
        /// <returns>A list of RotatedCubes that all have an estimated solution distance smaller than the specified max. The list is sorted by estimated solution distance.</returns>
        private IEnumerable<RotatedCube> GetRotatedCubesToExamine(RotatedCube rotatedCube, byte maxDepth)
        {
            // Not all moves are valid depending on the previous move.
            // e.g. If I rotate the Top in a CW direction then the following move cannot be
            // either TopCW, TopCCW, or TopHalf as those would just be redundant.
            // Pruning the tree like this makes it quite a bit more efficient.
            IEnumerable<Move> moves = RubiksCubeController.GetValidMovesBasedOnPreviousMove(rotatedCube.Move);

            // Get the estimated depth of the cube that results from each possible move
            // Filter out the ones that have an estimate that is larger than maxDepth
            // And sort them in ascending order by EstimatedDepth
            return moves.Select(move => GetNewRotatedCube(rotatedCube, move))
                        .Select(newRotatedCube => new { RotatedCube = newRotatedCube, EstimatedDepth = GetEstimatedDepth(newRotatedCube) })
                        .Where(rotatedCubeInfo => rotatedCubeInfo.EstimatedDepth <= maxDepth)
                        .OrderBy(rotatedCubeInfo => rotatedCubeInfo.EstimatedDepth)
                        .Select(rotatedCubeInfo => rotatedCubeInfo.RotatedCube);
        }

        /// <summary>
        /// Calculates the estimated depth of a RotatedCube.
        /// </summary>
        /// <returns>The estimated depth = Actual Depth of RotatedCube + EstimatedSolutionLength for that RotatedCube.</returns>
        private byte GetEstimatedDepth(RotatedCube rotatedCube)
        {
            return (byte)(rotatedCube.Depth + this.SolutionLengthEstimator.GetMinimumEstimatedSolutionLength(rotatedCube.RubiksCube));
        }

        /// <summary>
        /// Takes an existing RotatedCube and creates a new RotatedCube based on the move that was passed in.
        /// </summary>
        /// <param name="rubiksCube">The cube that we will want to rotate.</param>
        /// <param name="move">The move that we want to perform on the cube.</param>
        /// <returns>A new rotated cube value containing the newly rotated cube and the move that was used to create it.</returns>
        private static RotatedCube GetNewRotatedCube(RotatedCube rotatedCube, Move move)
        {
            return new RotatedCube(
                move, 
                (byte)(rotatedCube.Depth + 1),
                RubiksCubeController.Rotate(rotatedCube.RubiksCube, move)
            );
        }
    }
}
