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

        private byte?[,] Board { get; set; }

        private byte BlankSpaceX { get; set; }

        private byte BlankSpaceY { get; set; }

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

            this.Board = new byte?[n, n];

            InitializeBoard();
        }

        private NPuzzle(byte?[,] newBoard, byte blankX, byte blankY)
        {
            this.Board = newBoard;
            this.BlankSpaceX = blankX;
            this.BlankSpaceY = blankY;
        }

        private void InitializeBoard()
        {
            byte current = 0;

            for (int i = 0; i < this.Size; ++i)
            {
                for (int j = 0; j < this.Size; ++j)
                {
                    this.Board[i, j] = current++;
                }
            }

            this.BlankSpaceX = 0;
            this.BlankSpaceY = 0;

            this.Board[this.BlankSpaceX, this.BlankSpaceY] = null;
        }

        public byte? GetValue(int x, int y)
        {
            return this.Board[y, x];
        }

        public Move<NPuzzle>[] GetValidMoves()
        {
            List<Move<NPuzzle>> moves = new List<Move<NPuzzle>>(4);

            if (this.BlankSpaceX == 0)
            {
                if (this.BlankSpaceY == 0)
                {
                    return UpLeft;
                }
                else if (this.BlankSpaceY == this.Size - 1)
                {
                    return DownLeft;
                }
                else
                {
                    return UpDownLeft;
                }
            }
            else if (this.BlankSpaceX == this.Size-1)
            {
                if (this.BlankSpaceY == 0)
                {
                    return UpRight;
                }
                else if (this.BlankSpaceY == this.Size - 1)
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
                if (this.BlankSpaceY == 0)
                {
                    return UpLeftRight;
                }
                else if (this.BlankSpaceY == this.Size - 1)
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

            if (this.BlankSpaceY == nMinusOne)
            {
                if (this.BlankSpaceX == 0)
                {
                    return LeftOnly;
                }
                else if (this.BlankSpaceX == nMinusOne)
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
                if (this.BlankSpaceX == 0)
                {
                    return UpLeft;
                }
                else if (this.BlankSpaceX == nMinusOne)
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
            if (this.BlankSpaceY == 0)
            {
                if (this.BlankSpaceX == 0)
                {
                    return LeftOnly;
                }
                else if (this.BlankSpaceX == this.Size - 1)
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
                if (this.BlankSpaceX == 0)
                {
                    return DownLeft;
                }
                else if (this.BlankSpaceX == this.Size - 1)
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

            if (this.BlankSpaceX == nMinusOne)
            {
                if (this.BlankSpaceY == 0)
                {
                    return UpOnly;
                }
                else if (this.BlankSpaceY == nMinusOne)
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
                if (this.BlankSpaceY == 0)
                {
                    return UpLeft;
                }
                else if (this.BlankSpaceY == nMinusOne)
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
            if (this.BlankSpaceX == 0)
            {
                if (this.BlankSpaceY == 0)
                {
                    return UpOnly;
                }
                else if (this.BlankSpaceY == this.Size - 1)
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
                if (this.BlankSpaceY == 0)
                {
                    return UpRight;
                }
                else if (this.BlankSpaceY == this.Size - 1)
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
            byte swapY = (byte)(this.BlankSpaceY + 1);
            if (swapY >= this.Size)
            {
                throw new InvalidOperationException("Cannot slide up when the empty space is at the bottom.");
            }

            return SlideVertically(swapY);
        }

        public NPuzzle SlideDown()
        {
            byte swapY = (byte)(this.BlankSpaceY - 1);
            if (swapY < 0)
            {
                throw new InvalidOperationException("Cannot slide down when the empty space is at the top.");
            }

            return SlideVertically(swapY);
        }

        public NPuzzle SlideLeft()
        {
            byte swapX = (byte)(this.BlankSpaceX + 1);
            if (swapX >= this.Size)
            {
                throw new InvalidOperationException("Cannot slide up when the empty space is at the bottom.");
            }

            return SlideHorizontally(swapX);
        }

        public NPuzzle SlideRight()
        {
            byte swapX = (byte)(this.BlankSpaceX - 1);
            if (swapX < 0)
            {
                throw new InvalidOperationException("Cannot slide up when the empty space is at the bottom.");
            }

            return SlideHorizontally(swapX);
        }

        private NPuzzle SlideVertically(byte swapY)
        {
            byte?[,] newBoard = (byte?[,])this.Board.Clone();

            byte? swapValue = newBoard[swapY, this.BlankSpaceX];
            newBoard[swapY, this.BlankSpaceX] = null;
            newBoard[this.BlankSpaceY, this.BlankSpaceX] = swapValue;

            return new NPuzzle(newBoard, this.BlankSpaceX, swapY);
        }

        private NPuzzle SlideHorizontally(byte swapX)
        {
            byte?[,] newBoard = (byte?[,])this.Board.Clone();

            byte? swapValue = newBoard[this.BlankSpaceY, swapX];
            newBoard[this.BlankSpaceY, swapX] = null;
            newBoard[this.BlankSpaceY, this.BlankSpaceX] = swapValue;

            return new NPuzzle(newBoard, swapX, this.BlankSpaceY);
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
                for (int y = 0; y < this.Size; ++y)
                {
                    for (int x = 0; x < this.Size; ++x)
                    {
                        if (this.Board[y, x] != otherPuzzle.Board[y,x])
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

            for (int y = 0; y < this.Size; y++)
            {
                for (int x = 0; x < this.Size; x++)
                {
                    byte? value = this.Board[y, x];
                    if (value.HasValue)
                    {
                        sb.Append(value);
                    }
                    else
                    {
                        sb.Append("X");
                    }
                    sb.Append(" ");
                }

                sb.Append("\n");
            }

            return sb.ToString();
        }

        #endregion
    }
}
