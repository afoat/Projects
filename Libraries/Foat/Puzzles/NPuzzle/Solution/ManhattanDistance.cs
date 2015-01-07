namespace Foat.Puzzles.NPuzzle.Solution
{
    using Foat.Puzzles.Solutions;
    using Foat.Puzzles.Solutions.Heuristics;
    using System;

    /// <summary>
    /// A heuristic that calculates the manhattan distance of an NPuzzle.
    /// </summary>
    public class ManhattanDistance : IHeuristic<NPuzzle>
    {
        protected byte[] GoalRowIndexes;
        protected byte[] GoalColIndexes;

        public void RegisterSolution(NPuzzle puzzleSolution)
        {
            int size = puzzleSolution.Dimension;

            GoalRowIndexes = new byte[size * size];
            GoalColIndexes = new byte[GoalRowIndexes.Length];

            int value;
            for (byte colIx = 0; colIx < size; colIx++)
            {
                for (byte rowIx = 0; rowIx < size; rowIx++)
                {
                    value = puzzleSolution.GetValue(rowIx, colIx);
                    GoalRowIndexes[value] = rowIx;
                    GoalColIndexes[value] = colIx;
                }
            }
        }

        public virtual int GetMinimumEstimatedSolutionLength(NPuzzle puzzleInstance)
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