namespace Foat.Puzzles.NPuzzle
{
    using Foat.Puzzles.Solutions;
    using System;
    using System.Text;

    /// <summary>
    /// The NPuzzle can be used to create an instance of the popular 8-Puzzle and 15-Puzzle sliding tile games.
    /// These puzzles are a 3x3 and 4x4 grid of numbered tiles. One space is left empty so that the tiles
    /// can be slid around to re-order them. Once randomized, the goal is to return the puzzle into the original
    /// state. For example, a solved 8-Puzzle looks like this. Note that in memory the empty spot is denoted by a 0.
    /// 
    /// 1 2 3
    /// 4 5 5
    /// 7 8
    /// 
    /// This class supports grids of up to 15x15 but seriously. Even a 5x5 24-Puzzle is VERY hard for the algorithm to solve.
    /// </summary>
    public sealed partial class NPuzzle : IPuzzle<NPuzzle>, IEquatable<NPuzzle>
    {
        #region Static Methods

        /// <summary>
        /// Checks whether or not a 2-dimensional byte array would be considered a valid and solvable NPuzzle.
        /// 
        /// A valid puzzle:
        /// 
        /// - Is not null
        /// - It's width must equal its height (must be square)
        /// - It must be between 2x2 and 15x15 inclusive
        /// - In an NxN puzzle, the board must contain every digit from 0 ... ((N * N)^2) - 1 exactly once.
        ///   e.g. a 3x3 board needs every digit from 0 ... 8
        /// - If all of those checks pass then the puzzle is valid only if the numbers are ordered such that it is
        ///   possible to solve the puzzle by only making valid moves.
        /// </summary>
        /// <param name="board">A 2D Array representation of a potential NPuzzle.</param>
        /// <returns>True if the 2D array represents a valid NPuzzle, false otherwise.</returns>
        public static bool IsPuzzleValid(byte[,] board)
        {
            bool validAndSolvable = false;
            if  (IsPuzzleCorrectDimension(board))
            {
                int dimension = board.GetLength(0);

                if (NPuzzle.ContainsOnlyValidTiles(board))
                {
                    int numberOfInversions = CountInversions(board);
                    int rowIxOfZero = GetRowIxOfZero(board);
                    validAndSolvable = IsPuzzleSolvable(board.GetLength(0), rowIxOfZero, numberOfInversions);
                }
            }

            return validAndSolvable;
        }

        /// <summary>
        /// Returns true of the board is square and between 2x2 and 15x15 inclusive.
        /// </summary>
        private static bool IsPuzzleCorrectDimension(byte[,] board)
        {
            bool isCorrectDimension = true;
            if (board == null)
            {
                isCorrectDimension =  false;
            }
            else if (board.GetLength(0) < 2 || board.GetLength(0) > 15)
            {
                isCorrectDimension = false;
            }
            else if (board.GetLength(0) != board.GetLength(1))
            {
                isCorrectDimension = false;
            }

            return isCorrectDimension;
        }

        /// <summary>
        /// Checks to make sure that no tile is too large for the dimensions of this board
        /// and that the board contains exactly one copy of every required digit.
        /// 
        /// e.g. a 3x3 puzzle would be invalid if it contained any number larger than an 8.
        ///      a 3x3 puzzle would also be invalid if it contained no 6 and 2 copies of the number 5.
        /// 
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        private static bool ContainsOnlyValidTiles(byte[,] board)
        {
            bool isValid = true;

            int dimension = board.GetLength(0);
            int numberOfTiles = dimension * dimension;
            byte[] valueChecker = new byte[numberOfTiles];

            for (int rowIx = 0; rowIx < dimension; rowIx++)
            {
                for (int colIx = 0; colIx < dimension; colIx++)
                {
                    byte value = board[rowIx, colIx];
                    if (value >= numberOfTiles)
                    {
                        isValid = false;
                        break;
                    }

                    ++valueChecker[value];
                }
            }

            if (isValid)
            {
                for (int i = 0; i < valueChecker.Length; ++i)
                {
                    byte numberOfValues = valueChecker[i];
                    if (numberOfValues != 1)
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            return isValid;
        }

        /// <summary>
        /// Counts the number of inversions on the board. This number can be combined with the dimensions of the board
        /// to figure out if it is solvable or not.
        /// </summary>
        private static int CountInversions(byte[,] board)
        {
            int dimension = board.GetLength(0);
            int numberOfInversions = 0;
            for (int i = 0; i < board.Length; ++i)
            {
                byte value1 = board[i / dimension, i % dimension];
                for (int j = i + 1; j < board.Length; ++j)
                {
                    byte value2 = board[j / dimension, (j % dimension)];
                    if (value1 != 0 && value2 != 0 && value1 > value2)
                    {
                        ++numberOfInversions;
                    }
                }
            }

            return numberOfInversions;
        }

        /// <summary>
        /// Returns the index of the row that contains the 0 or blank space.
        /// </summary>
        private static int GetRowIxOfZero(byte[,] board)
        {
            int zeroIx = -1;
            int dimension = board.GetLength(0);
            for (int rowIx = 0; rowIx < dimension; rowIx++)
            {
                for (int colIx = 0; colIx < dimension; colIx++)
                {
                    if (board[rowIx, colIx] == 0)
                    {
                        zeroIx = rowIx;
                        break;
                    }

                }
            }

            if (zeroIx < 0)
            {
                throw new ArgumentException("Board must contain a tile with value of 0.", "board");
            }

            return zeroIx;
        }

        /// <summary>
        /// Based on the number of inversions, the location of the blank space and the dimensions of the board,
        /// this method checks to see if the board is solvable.
        /// </summary>
        /// <returns></returns>
        private static bool IsPuzzleSolvable(int dimension, int rowIxOfZero, int numberOfInversions)
        {
            bool solvable = true;
            if (dimension % 2 == 1)
            {
                if (numberOfInversions % 2 == 1)
                {
                    solvable = false;
                }
            }
            else
            {
                if (rowIxOfZero % 2 == 0)
                {
                    if (numberOfInversions % 2 == 0)
                    {
                        solvable = false;
                    }
                }
                else
                {
                    if (numberOfInversions % 2 == 1)
                    {
                        solvable = false;
                    }
                }
            }

            return solvable;
        }
        
        #endregion

        #region Properties

        /// <summary>
        /// The length of one side of the square grid.
        /// </summary>
        public int Dimension { get; private set; }

        private byte[,] Board;

        private byte BlankSpaceCol;

        private byte BlankSpaceRow;

        #endregion

        #region Construction

        public NPuzzle(byte n)
        {
            if (n < 2)
            {
                throw new ArgumentException("Size of the n-puzzle must be at least 2.");
            }

            if (n > 15)
            {
                throw new ArgumentException("Size of the n-puzzle must be at most 15.");
            }

            this.Board = new byte[n, n];
            this.Dimension = n;

            InitializeBoard();
        }

        public NPuzzle(byte[,] board)
        {
            if (board == null)
            {
                throw new ArgumentNullException("board");
            }

            if (!NPuzzle.IsPuzzleValid(board))
            {
                throw new ArgumentException("Invalid or unsolvable NPuzzle.");
            }
            else
            {
                InitializeBoard(board);
            }
        }

        private NPuzzle(byte[,] newBoard, byte blankCol, byte blankRow)
        {
            this.Board = newBoard;
            this.BlankSpaceCol = blankCol;
            this.BlankSpaceRow = blankRow;
            this.Dimension = newBoard.GetLength(0);
        }

        #endregion

        #region Public Methods

        public byte GetValue(int rowIx, int colIx)
        {
            return this.Board[rowIx, colIx];
        }

        /// <summary>
        /// This method will always return the moves that are valid on any particular NPuzzle instance.
        /// 
        /// This doesnt take into account the previous moves on the puzzle though so we will need to be smarter than this
        /// when performing an IDA* search, if we want it to go faster.
        /// </summary>
        /// <returns></returns>
        public Move<NPuzzle>[] GetValidMoves()
        {
            if (this.BlankSpaceCol == 0)
            {
                if (this.BlankSpaceRow == 0)
                {
                    return UpLeft;
                }
                else if (this.BlankSpaceRow == this.Dimension - 1)
                {
                    return DownLeft;
                }
                else
                {
                    return UpDownLeft;
                }
            }
            else if (this.BlankSpaceCol == this.Dimension-1)
            {
                if (this.BlankSpaceRow == 0)
                {
                    return UpRight;
                }
                else if (this.BlankSpaceRow == this.Dimension - 1)
                {
                    return DownRight;
                }
                else
                {
                    return UpDownRight;
                }
            }
            else
            {
                if (this.BlankSpaceRow == 0)
                {
                    return UpLeftRight;
                }
                else if (this.BlankSpaceRow == this.Dimension - 1)
                {
                    return DownLeftRight;
                }
                else
                {
                    return AllMoves;
                }
            }
        }


        /// <summary>
        /// Slides a tile up into the blank space if possible.
        /// </summary>
        public NPuzzle SlideUp()
        {
            byte swapRowIx = (byte)(this.BlankSpaceRow + 1);
            if (swapRowIx >= this.Dimension)
            {
                throw new InvalidOperationException("Cannot slide up when the empty space is at the bottom.");
            }

            return SlideVertically(swapRowIx);
        }


        /// <summary>
        /// Slides a tile down into the blank space if possible.
        /// </summary>
        public NPuzzle SlideDown()
        {
            if (this.BlankSpaceRow == 0)
            {
                throw new InvalidOperationException("Cannot slide down when the empty space is at the top.");
            }

            return SlideVertically((byte)(this.BlankSpaceRow - 1));
        }

        /// <summary>
        /// Slides a tile left into the blank space if possible.
        /// </summary>
        public NPuzzle SlideLeft()
        {
            byte swapColIx = (byte)(this.BlankSpaceCol + 1);
            if (swapColIx >= this.Dimension)
            {
                throw new InvalidOperationException("Cannot slide up when the empty space is at the bottom.");
            }

            return SlideHorizontally(swapColIx);
        }


        /// <summary>
        /// Slides a tile right into the blank space if possible.
        /// </summary>
        public NPuzzle SlideRight()
        {
            if (this.BlankSpaceCol == 0)
            {
                throw new InvalidOperationException("Cannot slide up when the empty space is at the bottom.");
            }

            return SlideHorizontally((byte)(this.BlankSpaceCol - 1));
        }

        #endregion

        #region Private Methods

        private void InitializeBoard()
        {
            byte current = 1;

            for (int rowIx = 0; rowIx < this.Dimension; ++rowIx)
            {
                for (int colIx = 0; colIx < this.Dimension; ++colIx)
                {
                    this.Board[rowIx, colIx] = current++;
                }
            }

            this.BlankSpaceCol = (byte)(this.Dimension - 1);
            this.BlankSpaceRow = BlankSpaceCol;

            this.Board[this.BlankSpaceRow, this.BlankSpaceCol] = 0;
        }

        private void InitializeBoard(byte[,] board)
        {
            this.Dimension = board.GetLength(0);
            this.Board = new byte[board.GetLength(0), board.GetLength(1)];

            for (byte rowIx = 0; rowIx < this.Dimension; ++rowIx)
            {
                for (byte colIx = 0; colIx < this.Dimension; ++colIx)
                {
                    if (board[rowIx, colIx] == 0)
                    {
                        this.BlankSpaceRow = rowIx;
                        this.BlankSpaceCol = colIx;
                    }

                    this.Board[rowIx, colIx] = board[rowIx, colIx];
                }
            }
        }

        /// <summary>
        /// Returns the moves that are valid on this instance of the puzzle assuming that a tile was just slid UP.
        /// </summary>
        private Move<NPuzzle>[] GetValidMovesAfterUp()
        {
            int nMinusOne = this.Dimension - 1;

            if (this.BlankSpaceRow == nMinusOne)
            {
                if (this.BlankSpaceCol == 0)
                {
                    return LeftOnly;
                }
                else if (this.BlankSpaceCol == nMinusOne)
                {
                    return RightOnly;
                }
                else
                {
                    return LeftRight;
                }
            }
            else
            {
                if (this.BlankSpaceCol == 0)
                {
                    return UpLeft;
                }
                else if (this.BlankSpaceCol == nMinusOne)
                {
                    return UpRight;
                }
                else
                {
                    return UpLeftRight;
                }
            }
        }


        /// <summary>
        /// Returns the moves that are valid on this instance of the puzzle assuming that a tile was just slid DOWN.
        /// </summary>
        private Move<NPuzzle>[] GetValidMovesAfterDown()
        {
            if (this.BlankSpaceRow == 0)
            {
                if (this.BlankSpaceCol == 0)
                {
                    return LeftOnly;
                }
                else if (this.BlankSpaceCol == this.Dimension - 1)
                {
                    return RightOnly;
                }
                else
                {
                    return LeftRight;
                }
            }
            else
            {
                if (this.BlankSpaceCol == 0)
                {
                    return DownLeft;
                }
                else if (this.BlankSpaceCol == this.Dimension - 1)
                {
                    return DownRight;
                }
                else
                {
                    return DownLeftRight;
                }
            }
        }


        /// <summary>
        /// Returns the moves that are valid on this instance of the puzzle assuming that a tile was just slid LEFT.
        /// </summary>
        private Move<NPuzzle>[] GetValidMovesAfterLeft()
        {
            int nMinusOne = this.Dimension - 1;

            if (this.BlankSpaceCol == nMinusOne)
            {
                if (this.BlankSpaceRow == 0)
                {
                    return UpOnly;
                }
                else if (this.BlankSpaceRow == nMinusOne)
                {
                    return DownOnly;
                }
                else
                {
                    return UpDown;
                }
            }
            else
            {
                if (this.BlankSpaceRow == 0)
                {
                    return UpLeft;
                }
                else if (this.BlankSpaceRow == nMinusOne)
                {
                    return DownLeft;
                }
                else
                {
                    return UpDownLeft;
                }
            }
        }


        /// <summary>
        /// Returns the moves that are valid on this instance of the puzzle assuming that a tile was just slid RIGHT.
        /// </summary>
        private Move<NPuzzle>[] GetValidMovesAfterRight()
        {
            if (this.BlankSpaceCol == 0)
            {
                if (this.BlankSpaceRow == 0)
                {
                    return UpOnly;
                }
                else if (this.BlankSpaceRow == this.Dimension - 1)
                {
                    return DownOnly;
                }
                else
                {
                    return UpDown;
                }
            }
            else
            {
                if (this.BlankSpaceRow == 0)
                {
                    return UpRight;
                }
                else if (this.BlankSpaceRow == this.Dimension - 1)
                {
                    return DownRight;
                }
                else
                {
                    return UpDownRight;
                }
            }
        }
        
        private NPuzzle SlideVertically(byte swapRow)
        {
            byte[,] newBoard = CloneBoard();

            byte swapValue = newBoard[swapRow, this.BlankSpaceCol];
            newBoard[swapRow, this.BlankSpaceCol] = 0;
            newBoard[this.BlankSpaceRow, this.BlankSpaceCol] = swapValue;

            return new NPuzzle(newBoard, this.BlankSpaceCol, swapRow);
        }

        private NPuzzle SlideHorizontally(byte swapCol)
        {
            byte[,] newBoard = CloneBoard();

            byte swapValue = newBoard[this.BlankSpaceRow, swapCol];
            newBoard[this.BlankSpaceRow, swapCol] = 0;
            newBoard[this.BlankSpaceRow, this.BlankSpaceCol] = swapValue;

            return new NPuzzle(newBoard, swapCol, this.BlankSpaceRow);
        }

        private byte[,] CloneBoard()
        {
            int size = this.Dimension;
            byte[,] newBoard = new byte[size, size];
            for (int rowIx = 0; rowIx < size; ++rowIx)
            {
                for (int colIx = 0; colIx < size; ++colIx)
                {
                    newBoard[rowIx, colIx] = this.Board[rowIx, colIx];
                }
            }
            return newBoard;
        }

        #endregion

        #region Object Overrides

        public override int GetHashCode()
        {
            return this.Board.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as NPuzzle);
        }

        public bool Equals(NPuzzle otherPuzzle)
        {
            if (otherPuzzle == null || otherPuzzle.Dimension != this.Dimension)
            {
                return false;
            }
            else
            {
                int dimension = this.Dimension;
                for (int rowIx = 0; rowIx < dimension; ++rowIx)
                {
                    for (int colIx = 0; colIx < dimension; ++colIx)
                    {
                        if (this.Board[rowIx, colIx] != otherPuzzle.Board[rowIx,colIx])
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int rowIx = 0; rowIx < this.Dimension; rowIx++)
            {
                for (int colIx = 0; colIx < this.Dimension; colIx++)
                {
                    sb.Append(this.Board[rowIx, colIx].ToString("00"));
                    sb.Append(" ");
                }

                sb.Append("\n");
            }

            return sb.ToString();
        }

        #endregion
    }
}
