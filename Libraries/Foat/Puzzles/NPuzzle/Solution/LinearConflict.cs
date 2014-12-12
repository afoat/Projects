namespace Foat.Puzzles.NPuzzle.Solution
{
    using Foat.Puzzles.Solutions;

    /// <summary>
    /// Improves on the manhattan distance by taking into account cases that contain linear conflicts.
    /// 
    /// A linear conflict occust in an NPuzzle when there are multiple tiles in the right row but in incorrect order.
    /// In these cases the conflicting tile must be moved out of the row so that it's position can be swapped with the
    /// other conflicting tile. Since you have to move the out then back into the row we can add 2 to the manhattan distance
    /// for each linear conflict detected.
    /// 
    /// 1 3 2
    /// 4 5 6
    /// 7 8 X  has one linear conflict (3-2)
    /// 
    /// 3 2 1
    /// 4 5 6
    /// 7 8 X has three linear conflicts in the same line (3,2) (3,1) (2,1)
    /// 
    /// Linear conflicts can occur in either the columns or the rows.
    /// </summary>
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

        /// <summary>
        /// Calculates the linear conflicts in the rows of the puzzleInstance.
        /// </summary>
        private int CalculateRowLinearConflicts(NPuzzle puzzleInstance)
        {
            unchecked
            {
                int size = puzzleInstance.Size;
                int linearConflict = 0;
                for (int rowIx = 0; rowIx < size; rowIx++)
                {
                    int minRow = size * rowIx + 1;
                    int maxRow = minRow + size - 1;

                    for (int curColIx = 0; curColIx < size; curColIx++)
                    {
                        byte curValue = puzzleInstance.GetValue(curColIx, rowIx);

                        if (curValue != 0 && curValue >= minRow && curValue <= maxRow)
                        {
                            for (int compareColIx = curColIx + 1; compareColIx < size; compareColIx++)
                            {
                                byte compareValue = puzzleInstance.GetValue(compareColIx, rowIx);
                                if (compareValue != 0 && compareValue >= minRow && compareValue <= maxRow && compareValue < curValue)
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

        /// <summary>
        /// Calculates the linear conflicts in the columns of the puzzleInstance.
        /// </summary>
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
