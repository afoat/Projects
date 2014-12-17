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
                int distance = 0;
                int size = puzzleInstance.Dimension;

                for (int rowIx = 0; rowIx < size; ++rowIx)
                {
                    for (int colIx = 0; colIx < size; ++colIx)
                    {
                        byte value = puzzleInstance.GetValue(rowIx, colIx);
                        if (value != 0)
                        {
                            distance += Math.Abs(colIx - GoalColIndexes[value]) + Math.Abs(rowIx - GoalRowIndexes[value]);
                        }
                    }
                }

                return distance;
            }
        }
    }
}