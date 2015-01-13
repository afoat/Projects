namespace Foat.Puzzles.NPuzzle
{
    using Foat.Puzzles.Solutions;

    public sealed partial class NPuzzle
    {
        // Since the puzzle moves never really change I have defined them once below.
        // This will speed up the NPuzzle and any searches done on it since we aren't
        // constantly allocating new memory for moves.

        private static readonly Move<NPuzzle> Up = new Move<NPuzzle>(0, "Up", nPuzzle => nPuzzle.SlideUp(), nPuzzle => nPuzzle.GetValidMovesAfterUp());
        private static readonly Move<NPuzzle> Down = new Move<NPuzzle>(1, "Down", nPuzzle => nPuzzle.SlideDown(), nPuzzle => nPuzzle.GetValidMovesAfterDown());
        private static readonly Move<NPuzzle> Left = new Move<NPuzzle>(2, "Left", nPuzzle => nPuzzle.SlideLeft(), nPuzzle => nPuzzle.GetValidMovesAfterLeft());
        private static readonly Move<NPuzzle> Right = new Move<NPuzzle>(3, "Right", nPuzzle => nPuzzle.SlideRight(), nPuzzle => nPuzzle.GetValidMovesAfterRight());


        static NPuzzle()
        {
            Up.OppositeMove = Down;
            Down.OppositeMove = Up;
            Left.OppositeMove = Right;
            Right.OppositeMove = Left;
        }

        private static readonly Move<NPuzzle>[] AllMoves = new Move<NPuzzle>[] { Up, Down, Left, Right };

        private static readonly Move<NPuzzle>[] UpOnly = new Move<NPuzzle>[] { Up };
        private static readonly Move<NPuzzle>[] DownOnly = new Move<NPuzzle>[] { Down };
        private static readonly Move<NPuzzle>[] LeftOnly = new Move<NPuzzle>[] { Left };
        private static readonly Move<NPuzzle>[] RightOnly = new Move<NPuzzle>[] { Right };

        private static readonly Move<NPuzzle>[] UpDown = new Move<NPuzzle>[] { Up, Down };
        private static readonly Move<NPuzzle>[] UpLeft = new Move<NPuzzle>[] { Up, Left };
        private static readonly Move<NPuzzle>[] UpRight = new Move<NPuzzle>[] { Up, Right };
        private static readonly Move<NPuzzle>[] DownLeft = new Move<NPuzzle>[] { Down, Left };
        private static readonly Move<NPuzzle>[] DownRight = new Move<NPuzzle>[] { Down, Right };
        private static readonly Move<NPuzzle>[] LeftRight = new Move<NPuzzle>[] { Left, Right };

        private static readonly Move<NPuzzle>[] UpDownLeft = new Move<NPuzzle>[] { Up, Down, Left };
        private static readonly Move<NPuzzle>[] UpDownRight = new Move<NPuzzle>[] { Up, Down, Right };
        private static readonly Move<NPuzzle>[] UpLeftRight = new Move<NPuzzle>[] { Up, Left, Right };
        private static readonly Move<NPuzzle>[] DownLeftRight = new Move<NPuzzle>[] { Down, Left, Right };
    }
}
