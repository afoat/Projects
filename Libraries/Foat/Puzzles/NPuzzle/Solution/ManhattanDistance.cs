namespace Foat.Puzzles.NPuzzle.Solution
{
    using Foat.Puzzles.Solutions;
    using System;

    public class ManhattanDistance : IHeuristic<NPuzzle>
    {
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
                        if (puzzleInstance.GetValue(colIx, rowIx) != 0)
                        {
                            int goalColIx;
                            int goalRowIx;

                            byte value = puzzleInstance.GetValue(colIx, rowIx);
                            GetGoalStateIndexForTileValue(value, size, out goalColIx, out goalRowIx);
                            distance += GetSingleManhattanDistance(colIx, rowIx, goalColIx, goalRowIx);
                        }
                    }
                }

                return distance;
            }
        }

        protected static void GetGoalStateIndexForTileValue(byte value, int n, out int goalColIx, out int goalRowIx)
        {
            unchecked
            {
                goalColIx = (value - 1) % n;
                goalRowIx = (value - 1) / n;
            }
        }

        private static int GetSingleManhattanDistance(int actualX, int actualY, int goalX, int goalY)
        {
            unchecked
            {
                return Math.Abs(actualX - goalX) + Math.Abs(actualY - goalY);
            }
        }
    }
}