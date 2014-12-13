namespace Foat.Puzzles.NPuzzle.Solution
{
    using Foat.Puzzles.Solutions;
    using System;

    /// <summary>
    /// A heuristic that calculates the manhattan distance of an NPuzzle.
    /// </summary>
    public class ManhattanDistance : IHeuristic<NPuzzle>
    {
        private byte[] GoalRowIndexes;
        private byte[] GoalColIndexes;

        public void RegisterSolution(NPuzzle puzzleSolution)
        {
            puzzleSolution.FillIndexes(out GoalRowIndexes, out GoalColIndexes);
        }

        public int GetMinimumEstimatedSolutionLength(NPuzzle puzzleInstance)
        {
            unchecked
            {
                int size = puzzleInstance.Size;
                int distance = 0;

                for (int rowIx = 0; rowIx < size; ++rowIx)
                {
                    for (int colIx = 0; colIx < size; ++colIx)
                    {
                        byte value = puzzleInstance.GetValue(colIx, rowIx);
                        if (value != 0)
                        {
                            distance += GetSingleManhattanDistance(colIx, rowIx, GoalColIndexes[value], GoalRowIndexes[value]);
                        }
                    }
                }

                return distance;
            }
        }

        private static int GetSingleManhattanDistance(int colIx, int rowIx, int goalColIx, int goalRowIx)
        {
            unchecked
            {
                return Math.Abs(colIx - goalColIx) + Math.Abs(rowIx - goalRowIx);
            }
        }
    }
}