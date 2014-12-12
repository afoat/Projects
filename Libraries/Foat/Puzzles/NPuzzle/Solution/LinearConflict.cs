namespace Foat.Puzzles.NPuzzle.Solution
{
    using Foat.Puzzles.Solutions;

    public class LinearConflict : IHeuristic<NPuzzle>
    {
        private ManhattanDistance ManhattanDistance { get; set; }

        public LinearConflict()
        {
            this.ManhattanDistance = new ManhattanDistance();
        }

        public int GetMinimumEstimatedSolutionLength(NPuzzle puzzleInstance)
        {
            return this.ManhattanDistance.GetMinimumEstimatedSolutionLength(puzzleInstance)
                 + this.CalculateRowLinearConflicts(puzzleInstance)
                 + this.CalculateColumnLinearConflicts(puzzleInstance);
        }

        private int CalculateRowLinearConflicts(NPuzzle puzzleInstance)
        {
            unchecked
            {
                int size = puzzleInstance.Size;
                int linearConflict = 0;
                for (int rowIx = 0; rowIx < size; rowIx++)
                {
                    for (int curColIx = 0; curColIx < size; curColIx++)
                    {
                        byte curValue = puzzleInstance.GetValue(curColIx, rowIx);

                        if (curValue != 0 && (curValue - 1) / size == rowIx)
                        {
                            for (int compareColIx = curColIx + 1; compareColIx < size; compareColIx++)
                            {
                                byte compareValue = puzzleInstance.GetValue(compareColIx, rowIx);
                                if (compareValue != 0 && (compareValue - 1) / size == rowIx && compareValue < curValue)
                                {
                                    linearConflict += 2;
                                }
                            }
                        }
                    }
                }

                return linearConflict;
            }
        }

        private int CalculateColumnLinearConflicts(NPuzzle puzzleInstance)
        {
            unchecked
            {
                int linearConflict = 0;
                int size = puzzleInstance.Size;
                for (int colIx = 0; colIx < size; colIx++)
                {
                    for (int curRowIx = 0; curRowIx < size; curRowIx++)
                    {
                        byte curValue = puzzleInstance.GetValue(colIx, curRowIx);

                        if (curValue != 0 && (curValue - 1) % size == colIx)
                        {
                            for (int compareRowIx = curRowIx + 1; compareRowIx < size; compareRowIx++)
                            {
                                byte compareValue = puzzleInstance.GetValue(colIx, compareRowIx);
                                if (compareValue != 0 && (compareValue - 1) % size == colIx && compareValue < curValue)
                                {
                                    linearConflict += 2;
                                }
                            }
                        }
                    }
                }

                return linearConflict;
            }
        }
    }
}
