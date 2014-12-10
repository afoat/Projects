namespace Foat.Puzzles.RubiksCube
{
    using Foat.Puzzles.Solutions;

    public partial class RubiksCube
    {

        private static readonly Move<RubiksCube> TopCW = new Move<RubiksCube>("TopCW", rubiksCube => rubiksCube.RotateTopCW(), rubiksCube => TopMoves);
        private static readonly Move<RubiksCube> TopCCW = new Move<RubiksCube>("TopCCW", rubiksCube => rubiksCube.RotateTopCCW(), rubiksCube => TopMoves);
        private static readonly Move<RubiksCube> TopHalf = new Move<RubiksCube>("TopHalf", rubiksCube => rubiksCube.RotateTopHalf(), rubiksCube => TopMoves);
        private static readonly Move<RubiksCube> BottomCW = new Move<RubiksCube>("BottomCW", rubiksCube => rubiksCube.RotateBottomCW(), rubiksCube => BottomMoves);
        private static readonly Move<RubiksCube> BottomCCW = new Move<RubiksCube>("BottomCCW", rubiksCube => rubiksCube.RotateBottomCCW(), rubiksCube => BottomMoves);
        private static readonly Move<RubiksCube> BottomHalf = new Move<RubiksCube>("BottomHalf", rubiksCube => rubiksCube.RotateBottomHalf(), rubiksCube => BottomMoves);
        private static readonly Move<RubiksCube> LeftCW = new Move<RubiksCube>("LeftCW", rubiksCube => rubiksCube.RotateLeftCW(), rubiksCube => LeftMoves);
        private static readonly Move<RubiksCube> LeftCCW = new Move<RubiksCube>("LeftCCW", rubiksCube => rubiksCube.RotateLeftCCW(), rubiksCube => LeftMoves);
        private static readonly Move<RubiksCube> LeftHalf = new Move<RubiksCube>("LeftHalf", rubiksCube => rubiksCube.RotateLeftHalf(), rubiksCube => LeftMoves);
        private static readonly Move<RubiksCube> RightCW = new Move<RubiksCube>("RightCW", rubiksCube => rubiksCube.RotateRightCW(), rubiksCube => RightMoves);
        private static readonly Move<RubiksCube> RightCCW = new Move<RubiksCube>("RightCCW", rubiksCube => rubiksCube.RotateRightCCW(), rubiksCube => RightMoves);
        private static readonly Move<RubiksCube> RightHalf = new Move<RubiksCube>("RightHalf", rubiksCube => rubiksCube.RotateRightHalf(), rubiksCube => RightMoves);
        private static readonly Move<RubiksCube> FrontCW = new Move<RubiksCube>("FrontCW", rubiksCube => rubiksCube.RotateFrontCW(), rubiksCube => FrontMoves);
        private static readonly Move<RubiksCube> FrontCCW = new Move<RubiksCube>("FrontCCW", rubiksCube => rubiksCube.RotateFrontCCW(), rubiksCube => FrontMoves);
        private static readonly Move<RubiksCube> FrontHalf = new Move<RubiksCube>("FrontHalf", rubiksCube => rubiksCube.RotateFrontHalf(), rubiksCube => FrontMoves);
        private static readonly Move<RubiksCube> BackCW = new Move<RubiksCube>("BackCW", rubiksCube => rubiksCube.RotateBackCW(), rubiksCube => BackMoves);
        private static readonly Move<RubiksCube> BackCCW = new Move<RubiksCube>("BackCCW", rubiksCube => rubiksCube.RotateBackCCW(), rubiksCube => BackMoves);
        private static readonly Move<RubiksCube> BackHalf = new Move<RubiksCube>("BackHalf", rubiksCube => rubiksCube.RotateBackHalf(), rubiksCube => BackMoves);

        private static readonly Move<RubiksCube>[] AllMoves = new Move<RubiksCube>[] {
                    TopCW, TopCCW, TopHalf, 
                    BottomCW, BottomCCW, BottomHalf, 
                    LeftCW, LeftCCW, LeftHalf, 
                    RightCW, RightCCW, RightHalf, 
                    FrontCW, FrontCCW, FrontHalf, 
                    BackCW, BackCCW, BackHalf };

        private static readonly Move<RubiksCube>[] TopMoves = new Move<RubiksCube>[] {
                    BottomCW, BottomCCW, BottomHalf, 
                    LeftCW, LeftCCW, LeftHalf, 
                    RightCW, RightCCW, RightHalf, 
                    FrontCW, FrontCCW, FrontHalf, 
                    BackCW, BackCCW, BackHalf };

        private static readonly Move<RubiksCube>[] BottomMoves = new Move<RubiksCube>[] { 
                    LeftCW, LeftCCW, LeftHalf, 
                    RightCW, RightCCW, RightHalf, 
                    FrontCW, FrontCCW, FrontHalf, 
                    BackCW, BackCCW, BackHalf };

        private static readonly Move<RubiksCube>[] LeftMoves = new Move<RubiksCube>[] { 
                    TopCW, TopCCW, TopHalf, 
                    BottomCW, BottomCCW, BottomHalf, 
                    RightCW, RightCCW, RightHalf, 
                    FrontCW, FrontCCW, FrontHalf, 
                    BackCW, BackCCW, BackHalf };

        private static readonly Move<RubiksCube>[] RightMoves = new Move<RubiksCube>[] { 
                    TopCW, TopCCW, TopHalf, 
                    BottomCW, BottomCCW, BottomHalf, 
                    FrontCW, FrontCCW, FrontHalf, 
                    BackCW, BackCCW, BackHalf };

        private static readonly Move<RubiksCube>[] FrontMoves = new Move<RubiksCube>[] { 
                    TopCW, TopCCW, TopHalf, 
                    BottomCW, BottomCCW, BottomHalf, 
                    LeftCW, LeftCCW, LeftHalf, 
                    RightCW, RightCCW, RightHalf, 
                    BackCW, BackCCW, BackHalf };

        private static readonly Move<RubiksCube>[] BackMoves = new Move<RubiksCube>[] { 
                    TopCW, TopCCW, TopHalf, 
                    BottomCW, BottomCCW, BottomHalf, 
                    LeftCW, LeftCCW, LeftHalf, 
                    RightCW, RightCCW, RightHalf };

    }
}
