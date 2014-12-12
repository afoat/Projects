namespace Foat.Puzzles.NPuzzle
{
    using Foat.Puzzles.Solutions;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public sealed partial class NPuzzle : IPuzzle<NPuzzle>, IEquatable<NPuzzle>
    {
        public int Size
        {
            get { return this.Board.GetLength(0); }
        }

        private byte[,] Board { get; set; }

        private byte BlankSpaceCol { get; set; }

        private byte BlankSpaceRow { get; set; }

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

            InitializeBoard();
        }

        private NPuzzle(byte[,] newBoard, byte blankCol, byte blankRow)
        {
            this.Board = newBoard;
            this.BlankSpaceCol = blankCol;
            this.BlankSpaceRow = blankRow;
        }

        private void InitializeBoard()
        {
            byte current = 1;

            for (int rowIx = 0; rowIx < this.Size; ++rowIx)
            {
                for (int colIx = 0; colIx < this.Size; ++colIx)
                {
                    this.Board[rowIx, colIx] = current++;
                }
            }

            this.BlankSpaceCol = (byte)(this.Size - 1);
            this.BlankSpaceRow = BlankSpaceCol;

            this.Board[this.BlankSpaceCol, this.BlankSpaceRow] = 0;
        }

        public byte GetValue(int colIx, int rowIx)
        {
            return this.Board[rowIx, colIx];
        }

        public Move<NPuzzle>[] GetValidMoves()
        {
            List<Move<NPuzzle>> moves = new List<Move<NPuzzle>>(4);

            if (this.BlankSpaceCol == 0)
            {
                if (this.BlankSpaceRow == 0)
                {
                    return UpLeft;
                }
                else if (this.BlankSpaceRow == this.Size - 1)
                {
                    return DownLeft;
                }
                else
                {
                    return UpDownLeft;
                }
            }
            else if (this.BlankSpaceCol == this.Size-1)
            {
                if (this.BlankSpaceRow == 0)
                {
                    return UpRight;
                }
                else if (this.BlankSpaceRow == this.Size - 1)
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
                else if (this.BlankSpaceRow == this.Size - 1)
                {
                    return DownLeftRight;
                }
                else
                {
                    return AllMoves;
                }
            }
        }


        private Move<NPuzzle>[] GetValidMovesAfterUp()
        {
            int nMinusOne = this.Size - 1;

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

        private Move<NPuzzle>[] GetValidMovesAfterDown()
        {
            if (this.BlankSpaceRow == 0)
            {
                if (this.BlankSpaceCol == 0)
                {
                    return LeftOnly;
                }
                else if (this.BlankSpaceCol == this.Size - 1)
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
                else if (this.BlankSpaceCol == this.Size - 1)
                {
                    return DownRight;
                }
                else
                {
                    return DownLeftRight;
                }
            }
        }

        private Move<NPuzzle>[] GetValidMovesAfterLeft()
        {
            int nMinusOne = this.Size - 1;

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

        private Move<NPuzzle>[] GetValidMovesAfterRight()
        {
            if (this.BlankSpaceCol == 0)
            {
                if (this.BlankSpaceRow == 0)
                {
                    return UpOnly;
                }
                else if (this.BlankSpaceRow == this.Size - 1)
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
                else if (this.BlankSpaceRow == this.Size - 1)
                {
                    return DownRight;
                }
                else
                {
                    return UpDownRight;
                }
            }
        }

        public NPuzzle SlideUp()
        {
            byte swapY = (byte)(this.BlankSpaceRow + 1);
            if (swapY >= this.Size)
            {
                throw new InvalidOperationException("Cannot slide up when the empty space is at the bottom.");
            }

            return SlideVertically(swapY);
        }

        public NPuzzle SlideDown()
        {
            byte swapY = (byte)(this.BlankSpaceRow - 1);
            if (swapY < 0)
            {
                throw new InvalidOperationException("Cannot slide down when the empty space is at the top.");
            }

            return SlideVertically(swapY);
        }

        public NPuzzle SlideLeft()
        {
            byte swapX = (byte)(this.BlankSpaceCol + 1);
            if (swapX >= this.Size)
            {
                throw new InvalidOperationException("Cannot slide up when the empty space is at the bottom.");
            }

            return SlideHorizontally(swapX);
        }

        public NPuzzle SlideRight()
        {
            byte swapX = (byte)(this.BlankSpaceCol - 1);
            if (swapX < 0)
            {
                throw new InvalidOperationException("Cannot slide up when the empty space is at the bottom.");
            }

            return SlideHorizontally(swapX);
        }

        private NPuzzle SlideVertically(byte swapRow)
        {
            byte[,] newBoard = (byte[,])this.Board.Clone();

            byte swapValue = newBoard[swapRow, this.BlankSpaceCol];
            newBoard[swapRow, this.BlankSpaceCol] = 0;
            newBoard[this.BlankSpaceRow, this.BlankSpaceCol] = swapValue;

            return new NPuzzle(newBoard, this.BlankSpaceCol, swapRow);
        }

        private NPuzzle SlideHorizontally(byte swapCol)
        {
            byte[,] newBoard = (byte[,])this.Board.Clone();

            byte swapValue = newBoard[this.BlankSpaceRow, swapCol];
            newBoard[this.BlankSpaceRow, swapCol] = 0;
            newBoard[this.BlankSpaceRow, this.BlankSpaceCol] = swapValue;

            return new NPuzzle(newBoard, swapCol, this.BlankSpaceRow);
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
            if (otherPuzzle == null || otherPuzzle.Size != this.Size)
            {
                return false;
            }
            else
            {
                for (int rowIx = 0; rowIx < this.Size; ++rowIx)
                {
                    for (int colIx = 0; colIx < this.Size; ++colIx)
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

            for (int rowIx = 0; rowIx < this.Size; rowIx++)
            {
                for (int colIx = 0; colIx < this.Size; colIx++)
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
