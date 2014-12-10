namespace Foat.Puzzles.NPuzzle.Solution
{
    using Foat.Puzzles.Solutions;
    using System;

    public class ManhattanDistance : IHeuristic<NPuzzle>
    {
        public int GetMinimumEstimatedSolutionLength(NPuzzle puzzleInstance)
        {
            int distance = 0;

            for (int y = 0; y < puzzleInstance.N; ++y)
            {
                for (int x = 0; x < puzzleInstance.N; ++x)
                {
                    if (puzzleInstance.GetValue(x, y) != null)
                    {
                        int xGoal;
                        int yGoal;

                        byte? value = puzzleInstance.GetValue(x, y);
                        GetGoalStateIndexForSquareValue(value, puzzleInstance.N, out xGoal, out yGoal);
                        distance += GetSingleManhattanDistance(x, y, xGoal, yGoal);
                    }
                }
            }

            return distance;
        }

        private static void GetGoalStateIndexForSquareValue(byte? value, int n, out int xGoal, out int yGoal)
        {
            if (value.HasValue)
            {
                xGoal = value.Value % n;
                yGoal = value.Value / n;
            }
            else
            {
                xGoal = n - 1;
                yGoal = xGoal;
            }
        }

        private static int GetSingleManhattanDistance(int actualX, int actualY, int goalX, int goalY)
        {
            return Math.Abs(actualX - goalX) + Math.Abs(actualY - goalY);
        }
    }
}