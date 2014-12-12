namespace Foat.Puzzles.Solutions.IDAStar
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Provides functions used to enumerate the child states of a puzzle instance.
    /// </summary>
    /// <typeparam name="TPuzzle"></typeparam>
    internal static class PuzzleStateExpander<TPuzzle> where TPuzzle : IPuzzle<TPuzzle>, IEquatable<TPuzzle>
    {

        /// <summary>
        /// Each puzzle has N moves that can be applied to it. This method will retrive a list of puzzle states
        /// resulting from applying each move to the puzzle. The puzzles returned are ordered such that the
        /// one with the shortest estimated solution is first. Any puzzle state with an estimated solution
        /// distance that is too large will not be returned.
        /// </summary>
        /// <param name="puzzleInstance">The puzzle that we will be examining.</param>
        /// <param name="maxDepth">The maximum estimated solution length that we are willing to accept.</param>
        internal static IEnumerable<PuzzleState<TPuzzle>> GetPuzzleStatesToExamine(PuzzleState<TPuzzle> puzzleInstance, int maxDepth)
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
            return moves.Select(move => new PuzzleState<TPuzzle>(move, (byte)(puzzleInstance.Depth + 1), move.MovePuzzle(puzzleInstance.PuzzleInstance)));
        }

        /// <summary>
        /// Each puzzle has N moves that can be applied to it. This method will retrive a list of puzzle states
        /// resulting from applying each move to the puzzle. The puzzles returned are ordered such that the
        /// one with the shortest estimated solution is first. Any puzzle state with an estimated solution
        /// distance that is too large will not be returned.
        /// </summary>
        /// <param name="puzzleInstance">The puzzle that we will be examining.</param>
        internal static IEnumerable<PuzzleState<TPuzzle>> GetPuzzleStatesToExamine(PuzzleState<TPuzzle> puzzleInstance)
        {
            return GetPuzzleStatesToExamine(puzzleInstance, int.MaxValue);
        }
    }
}
