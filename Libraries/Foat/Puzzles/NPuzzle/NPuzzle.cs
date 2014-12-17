namespace Foat.Puzzles.NPuzzle
{
    using Foat.Puzzles.Solutions;
    using System;
    using System.Text;

    /// <summary>
    /// The NPuzzle can be used to create an instance of the popular 8-Puzzle and 15-Puzzle sliding tile games.
    /// These puzzles are a 3x3 and 4x4 grid respect, of numbered tiles. One space is left empty so that the tiles
    /// can be re-ordered. Once randomized the goal is to return the puzzle into the original state such as
    /// 
    /// 1 2 3
    /// 4 5 5
    /// 7 8
    /// 
    /// in the case of the 8 puzzle. This class supports grids of up to 15x15 but seriously. Even a 5x5 24-Puzzle is
    /// VERY hard for the algorithm to solve.
    /// </summary>
    public sealed partial class NPuzzle : IPuzzle<NPuzzle>, IEquatable<NPuzzle>
    {
        /// <summary>
        /// The length of one side of the square grid.
        /// </summary>
        public int Dimension { get; private set; }

        private byte[,] Board;

        private byte BlankSpaceCol;

        private byte BlankSpaceRow;

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

        private NPuzzle(byte[,] newBoard, byte blankCol, byte blankRow)
        {
            this.Board = newBoard;
            this.BlankSpaceCol = blankCol;
            this.BlankSpaceRow = blankRow;
            this.Dimension = newBoard.GetLength(0);
        }

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

        public byte GetValue(int rowIx, int colIx)
        {
            return this.Board[rowIx, colIx];
        }

        /// <summary>
        /// This method will always return the moves that are valid on any particular NPuzzle instance.
        /// 
        /// This doesnt take into account the previous moves on the puzzle though so we will need to be smarted than this
        /// when performing an IDA* search.
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
            byte swapRowIx = (byte)(this.BlankSpaceRow - 1);
            if (swapRowIx < 0)
            {
                throw new InvalidOperationException("Cannot slide down when the empty space is at the top.");
            }

            return SlideVertically(swapRowIx);
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
            byte swapColIx = (byte)(this.BlankSpaceCol - 1);
            if (swapColIx < 0)
            {
                throw new InvalidOperationException("Cannot slide up when the empty space is at the bottom.");
            }

            return SlideHorizontally(swapColIx);
        }

        /// <summary>
        /// Using the values on the board as indexes into the arrays, this function fills the arrays with the
        /// index of each board value in the goal state. This allows us to take a value and really quickly
        /// determine where it should be.
        /// </summary>
        public void FillIndexes(out byte[] goalRowIndexes, out byte[] goalColIndexes)
        {
            int size = this.Dimension;

            goalRowIndexes = new byte[size*size];
            goalColIndexes = new byte[goalRowIndexes.Length];

            int value;
            for (byte colIx = 0; colIx < size; colIx++)
            {
                for (byte rowIx = 0; rowIx < size; rowIx++)
                {
                    value = this.Board[rowIx, colIx];
                    goalRowIndexes[value] = rowIx;
                    goalColIndexes[value] = colIx;
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
