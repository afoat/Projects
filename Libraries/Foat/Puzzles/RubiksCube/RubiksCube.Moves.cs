namespace Foat.Puzzles.RubiksCube
{
    using Foat.Puzzles.Solutions;

    public partial class RubiksCube
    {

        #region Static

        private static readonly Move<RubiksCube> TopCW = new Move<RubiksCube>("TopCW", rubiksCube => rubiksCube.RotateTopCW(), ()=>TopMoves);
        private static readonly Move<RubiksCube> TopCCW = new Move<RubiksCube>("TopCCW", rubiksCube => rubiksCube.RotateTopCCW(), () => TopMoves);
        private static readonly Move<RubiksCube> TopHalf = new Move<RubiksCube>("TopHalf", rubiksCube => rubiksCube.RotateTopHalf(), () => TopMoves);
        private static readonly Move<RubiksCube> BottomCW = new Move<RubiksCube>("BottomCW", rubiksCube => rubiksCube.RotateBottomCW(), () => BottomMoves);
        private static readonly Move<RubiksCube> BottomCCW = new Move<RubiksCube>("BottomCCW", rubiksCube => rubiksCube.RotateBottomCCW(), () => BottomMoves);
        private static readonly Move<RubiksCube> BottomHalf = new Move<RubiksCube>("BottomHalf", rubiksCube => rubiksCube.RotateBottomHalf(), () => BottomMoves);
        private static readonly Move<RubiksCube> LeftCW = new Move<RubiksCube>("LeftCW", rubiksCube => rubiksCube.RotateLeftCW(), () => LeftMoves);
        private static readonly Move<RubiksCube> LeftCCW = new Move<RubiksCube>("LeftCCW", rubiksCube => rubiksCube.RotateLeftCCW(), () => LeftMoves);
        private static readonly Move<RubiksCube> LeftHalf = new Move<RubiksCube>("LeftHalf", rubiksCube => rubiksCube.RotateLeftHalf(), () => LeftMoves);
        private static readonly Move<RubiksCube> RightCW = new Move<RubiksCube>("RightCW", rubiksCube => rubiksCube.RotateRightCW(), () => RightMoves);
        private static readonly Move<RubiksCube> RightCCW = new Move<RubiksCube>("RightCCW", rubiksCube => rubiksCube.RotateRightCCW(), () => RightMoves);
        private static readonly Move<RubiksCube> RightHalf = new Move<RubiksCube>("RightHalf", rubiksCube => rubiksCube.RotateRightHalf(), () => RightMoves);
        private static readonly Move<RubiksCube> FrontCW = new Move<RubiksCube>("FrontCW", rubiksCube => rubiksCube.RotateFrontCW(), () => FrontMoves);
        private static readonly Move<RubiksCube> FrontCCW = new Move<RubiksCube>("FrontCCW", rubiksCube => rubiksCube.RotateFrontCCW(), () => FrontMoves);
        private static readonly Move<RubiksCube> FrontHalf = new Move<RubiksCube>("FrontHalf", rubiksCube => rubiksCube.RotateFrontHalf(), () => FrontMoves);
        private static readonly Move<RubiksCube> BackCW = new Move<RubiksCube>("BackCW", rubiksCube => rubiksCube.RotateBackCW(), () => BackMoves);
        private static readonly Move<RubiksCube> BackCCW = new Move<RubiksCube>("BackCCW", rubiksCube => rubiksCube.RotateBackCCW(), () => BackMoves);
        private static readonly Move<RubiksCube> BackHalf = new Move<RubiksCube>("BackHalf", rubiksCube => rubiksCube.RotateBackHalf(), () => BackMoves);

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

        #endregion
    }
}
