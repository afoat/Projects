namespace Foat.Puzzles.RubiksCube
{
    using Foat.Puzzles.Solutions;

    public partial class RubiksCube
    {
        private static readonly Move<RubiksCube> TopCW = new Move<RubiksCube>(0, "TopCW", rubiksCube => rubiksCube.RotateTopCW(), rubiksCube => TopMoves);
        private static readonly Move<RubiksCube> TopCCW = new Move<RubiksCube>(1, "TopCCW", rubiksCube => rubiksCube.RotateTopCCW(), rubiksCube => TopMoves);
        private static readonly Move<RubiksCube> TopHalf = new Move<RubiksCube>(2, "TopHalf", rubiksCube => rubiksCube.RotateTopHalf(), rubiksCube => TopMoves);
        private static readonly Move<RubiksCube> BottomCW = new Move<RubiksCube>(3, "BottomCW", rubiksCube => rubiksCube.RotateBottomCW(), rubiksCube => BottomMoves);
        private static readonly Move<RubiksCube> BottomCCW = new Move<RubiksCube>(4, "BottomCCW", rubiksCube => rubiksCube.RotateBottomCCW(), rubiksCube => BottomMoves);
        private static readonly Move<RubiksCube> BottomHalf = new Move<RubiksCube>(5, "BottomHalf", rubiksCube => rubiksCube.RotateBottomHalf(), rubiksCube => BottomMoves);
        private static readonly Move<RubiksCube> LeftCW = new Move<RubiksCube>(6, "LeftCW", rubiksCube => rubiksCube.RotateLeftCW(), rubiksCube => LeftMoves);
        private static readonly Move<RubiksCube> LeftCCW = new Move<RubiksCube>(7, "LeftCCW", rubiksCube => rubiksCube.RotateLeftCCW(), rubiksCube => LeftMoves);
        private static readonly Move<RubiksCube> LeftHalf = new Move<RubiksCube>(8, "LeftHalf", rubiksCube => rubiksCube.RotateLeftHalf(), rubiksCube => LeftMoves);
        private static readonly Move<RubiksCube> RightCW = new Move<RubiksCube>(9, "RightCW", rubiksCube => rubiksCube.RotateRightCW(), rubiksCube => RightMoves);
        private static readonly Move<RubiksCube> RightCCW = new Move<RubiksCube>(10, "RightCCW", rubiksCube => rubiksCube.RotateRightCCW(), rubiksCube => RightMoves);
        private static readonly Move<RubiksCube> RightHalf = new Move<RubiksCube>(11, "RightHalf", rubiksCube => rubiksCube.RotateRightHalf(), rubiksCube => RightMoves);
        private static readonly Move<RubiksCube> FrontCW = new Move<RubiksCube>(12, "FrontCW", rubiksCube => rubiksCube.RotateFrontCW(), rubiksCube => FrontMoves);
        private static readonly Move<RubiksCube> FrontCCW = new Move<RubiksCube>(13, "FrontCCW", rubiksCube => rubiksCube.RotateFrontCCW(), rubiksCube => FrontMoves);
        private static readonly Move<RubiksCube> FrontHalf = new Move<RubiksCube>(14, "FrontHalf", rubiksCube => rubiksCube.RotateFrontHalf(), rubiksCube => FrontMoves);
        private static readonly Move<RubiksCube> BackCW = new Move<RubiksCube>(15, "BackCW", rubiksCube => rubiksCube.RotateBackCW(), rubiksCube => BackMoves);
        private static readonly Move<RubiksCube> BackCCW = new Move<RubiksCube>(16, "BackCCW", rubiksCube => rubiksCube.RotateBackCCW(), rubiksCube => BackMoves);
        private static readonly Move<RubiksCube> BackHalf = new Move<RubiksCube>(17, "BackHalf", rubiksCube => rubiksCube.RotateBackHalf(), rubiksCube => BackMoves);

        static RubiksCube()
        {
            TopCW.OppositeMove = TopCCW;
            TopCCW.OppositeMove = TopCW;
            TopHalf.OppositeMove = TopHalf;
            BottomCW.OppositeMove = BottomCCW;
            BottomCCW.OppositeMove = BottomCW;
            BottomHalf.OppositeMove = BottomHalf;
            LeftCW.OppositeMove = LeftCCW;
            LeftCCW.OppositeMove = LeftCW;
            LeftHalf.OppositeMove = LeftHalf;
            RightCW.OppositeMove = RightCCW;
            RightCCW.OppositeMove = RightCW;
            RightHalf.OppositeMove = RightHalf;
            FrontCW.OppositeMove = FrontCCW;
            FrontCCW.OppositeMove = FrontCW;
            FrontHalf.OppositeMove = FrontHalf;
            BackCW.OppositeMove = BackCCW;
            BackCCW.OppositeMove = BackCW;
            BackHalf.OppositeMove = BackHalf;
        }

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
