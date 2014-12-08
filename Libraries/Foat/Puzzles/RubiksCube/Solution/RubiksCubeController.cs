namespace Foat.Puzzles.RubiksCube.Solution
{
    using Foat.Puzzles.RubiksCube;
    using System;
    using System.Collections.Generic;

    public static class RubiksCubeController
    {
        public static IEnumerable<Move> GetValidMovesBasedOnPreviousMove(Move? move)
        {
            switch (move)
            {
                case null:
                    return AllMoves;
                case Move.TopCCW:
                case Move.TopCW:
                case Move.TopHalf:
                    return TopMoves;
                case Move.BottomHalf:
                case Move.BottomCW:
                case Move.BottomCCW:
                    return BottomMoves;
                case Move.LeftCCW:
                case Move.LeftCW:
                case Move.LeftHalf:
                    return LeftMoves;
                case Move.RightCCW:
                case Move.RightCW:
                case Move.RightHalf:
                    return RightMoves;
                case Move.FrontCCW:
                case Move.FrontCW:
                case Move.FrontHalf:
                    return FrontMoves;
                case Move.BackCW:
                case Move.BackCCW:
                case Move.BackHalf:
                    return BackMoves;
                default:
                    throw new ArgumentException();
            }
        }
        
        public static RubiksCube Rotate(RubiksCube cube, Move moveToPerform)
        {
            switch (moveToPerform)
            {
                case Move.TopCW:
                    return cube.RotateTopCW();
                case Move.TopCCW:
                    return cube.RotateTopCCW();
                case Move.TopHalf:
                    return cube.RotateTopHalf();
                case Move.BottomCW:
                    return cube.RotateBottomCW();
                case Move.BottomCCW:
                    return cube.RotateBottomCCW();
                case Move.BottomHalf:
                    return cube.RotateBottomHalf();
                case Move.LeftCW:
                    return cube.RotateLeftCW();
                case Move.LeftCCW:
                    return cube.RotateLeftCCW();
                case Move.LeftHalf:
                    return cube.RotateLeftHalf();
                case Move.RightCW:
                    return cube.RotateRightCW();
                case Move.RightCCW:
                    return cube.RotateRightCCW();
                case Move.RightHalf:
                    return cube.RotateRightHalf();
                case Move.FrontCW:
                    return cube.RotateFrontCW();
                case Move.FrontCCW:
                    return cube.RotateFrontCCW();
                case Move.FrontHalf:
                    return cube.RotateFrontHalf();
                case Move.BackCW:
                    return cube.RotateBackCW();
                case Move.BackCCW:
                    return cube.RotateBackCCW();
                case Move.BackHalf:
                    return cube.RotateBackHalf();
                default:
                    throw new ArgumentException();
            }
        }

        private static readonly Move[] AllMoves = new Move[] {
                    Move.TopCW, Move.TopCCW, Move.TopHalf, 
                    Move.BottomCW, Move.BottomCCW, Move.BottomHalf, 
                    Move.LeftCW, Move.LeftCCW, Move.LeftHalf, 
                    Move.RightCW, Move.RightCCW, Move.RightHalf, 
                    Move.FrontCW, Move.FrontCCW, Move.FrontHalf, 
                    Move.BackCW, Move.BackCCW, Move.BackHalf };

        private static readonly Move[] TopMoves = new Move[] {
                    Move.BottomCW, Move.BottomCCW, Move.BottomHalf, 
                    Move.LeftCW, Move.LeftCCW, Move.LeftHalf, 
                    Move.RightCW, Move.RightCCW, Move.RightHalf, 
                    Move.FrontCW, Move.FrontCCW, Move.FrontHalf, 
                    Move.BackCW, Move.BackCCW, Move.BackHalf };

        private static readonly Move[] BottomMoves = new Move[] { 
                    Move.LeftCW, Move.LeftCCW, Move.LeftHalf, 
                    Move.RightCW, Move.RightCCW, Move.RightHalf, 
                    Move.FrontCW, Move.FrontCCW, Move.FrontHalf, 
                    Move.BackCW, Move.BackCCW, Move.BackHalf };

        private static readonly Move[] LeftMoves = new Move[] { 
                    Move.TopCW, Move.TopCCW, Move.TopHalf, 
                    Move.BottomCW, Move.BottomCCW, Move.BottomHalf, 
                    Move.RightCW, Move.RightCCW, Move.RightHalf, 
                    Move.FrontCW, Move.FrontCCW, Move.FrontHalf, 
                    Move.BackCW, Move.BackCCW, Move.BackHalf };

        private static readonly Move[] RightMoves = new Move[] { 
                    Move.TopCW, Move.TopCCW, Move.TopHalf, 
                    Move.BottomCW, Move.BottomCCW, Move.BottomHalf, 
                    Move.FrontCW, Move.FrontCCW, Move.FrontHalf, 
                    Move.BackCW, Move.BackCCW, Move.BackHalf };

        private static readonly Move[] FrontMoves = new Move[] { 
                    Move.TopCW, Move.TopCCW, Move.TopHalf, 
                    Move.BottomCW, Move.BottomCCW, Move.BottomHalf, 
                    Move.LeftCW, Move.LeftCCW, Move.LeftHalf, 
                    Move.RightCW, Move.RightCCW, Move.RightHalf, 
                    Move.BackCW, Move.BackCCW, Move.BackHalf };

        private static readonly Move[] BackMoves = new Move[] { 
                    Move.TopCW, Move.TopCCW, Move.TopHalf, 
                    Move.BottomCW, Move.BottomCCW, Move.BottomHalf, 
                    Move.LeftCW, Move.LeftCCW, Move.LeftHalf, 
                    Move.RightCW, Move.RightCCW, Move.RightHalf };
    }
}
