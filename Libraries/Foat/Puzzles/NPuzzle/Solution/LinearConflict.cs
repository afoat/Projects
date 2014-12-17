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
        private byte[] GoalRowIndexes;
        private byte[] GoalColIndexes;

        private ManhattanDistance ManhattanDistance { get; set; }

        public LinearConflict()
        {
            this.ManhattanDistance = new ManhattanDistance();
        }

        /// <summary>
        /// Registers the puzzle solution with the heuristic so that it can generate any needed data.
        /// </summary>
        public void RegisterSolution(NPuzzle puzzleSolution)
        {
            this.ManhattanDistance.RegisterSolution(puzzleSolution);
            puzzleSolution.FillIndexes(out GoalRowIndexes, out GoalColIndexes);
        }

        /// <summary>
        /// Returns the manhattan distance + 2 x Number Of Linear Conflicts
        /// </summary>
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
                int size = puzzleInstance.Dimension;
                int linearConflict = 0;
                for (int rowIx = 0; rowIx < size; rowIx++)
                {
                    for (int curColIx = 0; curColIx < size; curColIx++)
                    {
                        byte curValue = puzzleInstance.GetValue(rowIx, curColIx);

                        if (GoalRowIndexes[curValue] == rowIx && curValue != 0)
                        {
                            for (int compareColIx = curColIx + 1; compareColIx < size; compareColIx++)
                            {
                                byte compareValue = puzzleInstance.GetValue(rowIx, compareColIx);
                                if (GoalRowIndexes[compareValue] == rowIx && compareValue < curValue && compareValue != 0)
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
                int size = puzzleInstance.Dimension;
                for (int colIx = 0; colIx < size; colIx++)
                {
                    for (int curRowIx = 0; curRowIx < size; curRowIx++)
                    {
                        byte curValue = puzzleInstance.GetValue(curRowIx, colIx);

                        if (curValue != 0 && GoalColIndexes[curValue] == colIx)
                        {
                            for (int compareRowIx = curRowIx + 1; compareRowIx < size; compareRowIx++)
                            {
                                byte compareValue = puzzleInstance.GetValue(compareRowIx, colIx);
                                if (GoalColIndexes[compareValue] == colIx && compareValue < curValue && compareValue != 0)
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
