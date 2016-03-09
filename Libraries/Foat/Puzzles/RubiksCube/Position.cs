namespace Foat.Puzzles.RubiksCube
{
    using System;

    public struct Position
    {

        #region Position Constants

        // Corner Positions
        internal const byte TopBackLeftPrimaryTop = 0;
        internal const byte TopBackLeftPrimaryBack = 1;
        internal const byte TopBackLeftPrimaryLeft = 2;
        internal const byte TopBackRightPrimaryTop = 3;
        internal const byte TopBackRightPrimaryBack = 4;
        internal const byte TopBackRightPrimaryRight = 5;
        internal const byte TopFrontLeftPrimaryTop = 6;
        internal const byte TopFrontLeftPrimaryFront = 7;
        internal const byte TopFrontLeftPrimaryLeft = 8;
        internal const byte TopFrontRightPrimaryTop = 9;
        internal const byte TopFrontRightPrimaryFront = 10;
        internal const byte TopFrontRightPrimaryRight = 11;
        internal const byte BottomBackLeftPrimaryBottom = 12;
        internal const byte BottomBackLeftPrimaryBack = 13;
        internal const byte BottomBackLeftPrimaryLeft = 14;
        internal const byte BottomBackRightPrimaryBottom = 15;
        internal const byte BottomBackRightPrimaryBack = 16;
        internal const byte BottomBackRightPrimaryRight = 17;
        internal const byte BottomFrontLeftPrimaryBottom = 18;
        internal const byte BottomFrontLeftPrimaryFront = 19;
        internal const byte BottomFrontLeftPrimaryLeft = 20;
        internal const byte BottomFrontRightPrimaryBottom = 21;
        internal const byte BottomFrontRightPrimaryFront = 22;
        internal const byte BottomFrontRightPrimaryRight = 23;
        internal const byte Unmasked = 24;
        internal const byte Masked = 25;

        // Edge Positions
        internal const byte TopFrontPrimaryTop = 26;
        internal const byte TopFrontPrimaryFront = 27;
        internal const byte TopLeftPrimaryTop = 28;
        internal const byte TopLeftPrimaryLeft = 29;
        internal const byte TopBackPrimaryTop = 30;
        internal const byte TopBackPrimaryBack = 31;
        internal const byte TopRightPrimaryTop = 32;
        internal const byte TopRightPrimaryRight = 33;
        internal const byte BottomFrontPrimaryBottom = 34;
        internal const byte BottomFrontPrimaryFront = 35;
        internal const byte BottomLeftPrimaryBottom = 36;
        internal const byte BottomLeftPrimaryLeft = 37;
        internal const byte BottomBackPrimaryBottom = 38;
        internal const byte BottomBackPrimaryBack = 39;
        internal const byte BottomRightPrimaryBottom = 40;
        internal const byte BottomRightPrimaryRight = 41;
        internal const byte FrontLeftPrimaryFront = 42;
        internal const byte FrontLeftPrimaryLeft = 43;
        internal const byte BackLeftPrimaryBack = 44;
        internal const byte BackLeftPrimaryLeft = 45;
        internal const byte BackRightPrimaryBack = 46;
        internal const byte BackRightPrimaryRight = 47;
        internal const byte FrontRightPrimaryFront = 48;
        internal const byte FrontRightPrimaryRight = 49;

        internal const byte NumPositions = 50;

        #endregion

        #region Move Lookup Tables

        private static byte[] _LookupRotateTopCW = new byte[] {
                TopBackRightPrimaryTop, TopBackRightPrimaryRight, TopBackRightPrimaryBack, TopFrontRightPrimaryTop, TopFrontRightPrimaryRight, TopFrontRightPrimaryFront, TopBackLeftPrimaryTop, TopBackLeftPrimaryLeft, TopBackLeftPrimaryBack, TopFrontLeftPrimaryTop, TopFrontLeftPrimaryLeft, TopFrontLeftPrimaryFront, BottomBackLeftPrimaryBottom, BottomBackLeftPrimaryBack, BottomBackLeftPrimaryLeft, BottomBackRightPrimaryBottom, BottomBackRightPrimaryBack, BottomBackRightPrimaryRight, BottomFrontLeftPrimaryBottom, BottomFrontLeftPrimaryFront, BottomFrontLeftPrimaryLeft, BottomFrontRightPrimaryBottom, BottomFrontRightPrimaryFront, BottomFrontRightPrimaryRight, Unmasked, Masked, TopLeftPrimaryTop, TopLeftPrimaryLeft, TopBackPrimaryTop, TopBackPrimaryBack, TopRightPrimaryTop, TopRightPrimaryRight, TopFrontPrimaryTop, TopFrontPrimaryFront, BottomFrontPrimaryBottom, BottomFrontPrimaryFront, BottomLeftPrimaryBottom, BottomLeftPrimaryLeft, BottomBackPrimaryBottom, BottomBackPrimaryBack, BottomRightPrimaryBottom, BottomRightPrimaryRight, FrontLeftPrimaryFront, FrontLeftPrimaryLeft, BackLeftPrimaryBack, BackLeftPrimaryLeft, BackRightPrimaryBack, BackRightPrimaryRight, FrontRightPrimaryFront, FrontRightPrimaryRight
        };

        private static byte[] _LookupRotateTopCCW = new byte[] {
                TopFrontLeftPrimaryTop, TopFrontLeftPrimaryLeft, TopFrontLeftPrimaryFront, TopBackLeftPrimaryTop, TopBackLeftPrimaryLeft, TopBackLeftPrimaryBack, TopFrontRightPrimaryTop, TopFrontRightPrimaryRight, TopFrontRightPrimaryFront, TopBackRightPrimaryTop, TopBackRightPrimaryRight, TopBackRightPrimaryBack, BottomBackLeftPrimaryBottom, BottomBackLeftPrimaryBack, BottomBackLeftPrimaryLeft, BottomBackRightPrimaryBottom, BottomBackRightPrimaryBack, BottomBackRightPrimaryRight, BottomFrontLeftPrimaryBottom, BottomFrontLeftPrimaryFront, BottomFrontLeftPrimaryLeft, BottomFrontRightPrimaryBottom, BottomFrontRightPrimaryFront, BottomFrontRightPrimaryRight, Unmasked, Masked, TopRightPrimaryTop, TopRightPrimaryRight, TopFrontPrimaryTop, TopFrontPrimaryFront, TopLeftPrimaryTop, TopLeftPrimaryLeft, TopBackPrimaryTop, TopBackPrimaryBack, BottomFrontPrimaryBottom, BottomFrontPrimaryFront, BottomLeftPrimaryBottom, BottomLeftPrimaryLeft, BottomBackPrimaryBottom, BottomBackPrimaryBack, BottomRightPrimaryBottom, BottomRightPrimaryRight, FrontLeftPrimaryFront, FrontLeftPrimaryLeft, BackLeftPrimaryBack, BackLeftPrimaryLeft, BackRightPrimaryBack, BackRightPrimaryRight, FrontRightPrimaryFront, FrontRightPrimaryRight
        };

        private static byte[] _LookupRotateTopHalf = new byte[] {
                TopFrontRightPrimaryTop, TopFrontRightPrimaryFront, TopFrontRightPrimaryRight, TopFrontLeftPrimaryTop, TopFrontLeftPrimaryFront, TopFrontLeftPrimaryLeft, TopBackRightPrimaryTop, TopBackRightPrimaryBack, TopBackRightPrimaryRight, TopBackLeftPrimaryTop, TopBackLeftPrimaryBack, TopBackLeftPrimaryLeft, BottomBackLeftPrimaryBottom, BottomBackLeftPrimaryBack, BottomBackLeftPrimaryLeft, BottomBackRightPrimaryBottom, BottomBackRightPrimaryBack, BottomBackRightPrimaryRight, BottomFrontLeftPrimaryBottom, BottomFrontLeftPrimaryFront, BottomFrontLeftPrimaryLeft, BottomFrontRightPrimaryBottom, BottomFrontRightPrimaryFront, BottomFrontRightPrimaryRight, Unmasked, Masked, TopBackPrimaryTop, TopBackPrimaryBack, TopRightPrimaryTop, TopRightPrimaryRight, TopFrontPrimaryTop, TopFrontPrimaryFront, TopLeftPrimaryTop, TopLeftPrimaryLeft, BottomFrontPrimaryBottom, BottomFrontPrimaryFront, BottomLeftPrimaryBottom, BottomLeftPrimaryLeft, BottomBackPrimaryBottom, BottomBackPrimaryBack, BottomRightPrimaryBottom, BottomRightPrimaryRight, FrontLeftPrimaryFront, FrontLeftPrimaryLeft, BackLeftPrimaryBack, BackLeftPrimaryLeft, BackRightPrimaryBack, BackRightPrimaryRight, FrontRightPrimaryFront, FrontRightPrimaryRight
        };

        private static byte[] _LookupRotateBottomCW = new byte[] {
                TopBackLeftPrimaryTop, TopBackLeftPrimaryBack, TopBackLeftPrimaryLeft, TopBackRightPrimaryTop, TopBackRightPrimaryBack, TopBackRightPrimaryRight, TopFrontLeftPrimaryTop, TopFrontLeftPrimaryFront, TopFrontLeftPrimaryLeft, TopFrontRightPrimaryTop, TopFrontRightPrimaryFront, TopFrontRightPrimaryRight, BottomFrontLeftPrimaryBottom, BottomFrontLeftPrimaryLeft, BottomFrontLeftPrimaryFront, BottomBackLeftPrimaryBottom, BottomBackLeftPrimaryLeft, BottomBackLeftPrimaryBack, BottomFrontRightPrimaryBottom, BottomFrontRightPrimaryRight, BottomFrontRightPrimaryFront, BottomBackRightPrimaryBottom, BottomBackRightPrimaryRight, BottomBackRightPrimaryBack, Unmasked, Masked, TopFrontPrimaryTop, TopFrontPrimaryFront, TopLeftPrimaryTop, TopLeftPrimaryLeft, TopBackPrimaryTop, TopBackPrimaryBack, TopRightPrimaryTop, TopRightPrimaryRight, BottomRightPrimaryBottom, BottomRightPrimaryRight, BottomFrontPrimaryBottom, BottomFrontPrimaryFront, BottomLeftPrimaryBottom, BottomLeftPrimaryLeft, BottomBackPrimaryBottom, BottomBackPrimaryBack, FrontLeftPrimaryFront, FrontLeftPrimaryLeft, BackLeftPrimaryBack, BackLeftPrimaryLeft, BackRightPrimaryBack, BackRightPrimaryRight, FrontRightPrimaryFront, FrontRightPrimaryRight
        };

        private static byte[] _LookupRotateBottomCCW = new byte[] {
                TopBackLeftPrimaryTop, TopBackLeftPrimaryBack, TopBackLeftPrimaryLeft, TopBackRightPrimaryTop, TopBackRightPrimaryBack, TopBackRightPrimaryRight, TopFrontLeftPrimaryTop, TopFrontLeftPrimaryFront, TopFrontLeftPrimaryLeft, TopFrontRightPrimaryTop, TopFrontRightPrimaryFront, TopFrontRightPrimaryRight, BottomBackRightPrimaryBottom, BottomBackRightPrimaryRight, BottomBackRightPrimaryBack, BottomFrontRightPrimaryBottom, BottomFrontRightPrimaryRight, BottomFrontRightPrimaryFront, BottomBackLeftPrimaryBottom, BottomBackLeftPrimaryLeft, BottomBackLeftPrimaryBack, BottomFrontLeftPrimaryBottom, BottomFrontLeftPrimaryLeft, BottomFrontLeftPrimaryFront, Unmasked, Masked, TopFrontPrimaryTop, TopFrontPrimaryFront, TopLeftPrimaryTop, TopLeftPrimaryLeft, TopBackPrimaryTop, TopBackPrimaryBack, TopRightPrimaryTop, TopRightPrimaryRight, BottomLeftPrimaryBottom, BottomLeftPrimaryLeft, BottomBackPrimaryBottom, BottomBackPrimaryBack, BottomRightPrimaryBottom, BottomRightPrimaryRight, BottomFrontPrimaryBottom, BottomFrontPrimaryFront, FrontLeftPrimaryFront, FrontLeftPrimaryLeft, BackLeftPrimaryBack, BackLeftPrimaryLeft, BackRightPrimaryBack, BackRightPrimaryRight, FrontRightPrimaryFront, FrontRightPrimaryRight
        };

        private static byte[] _LookupRotateBottomHalf = new byte[] {
                TopBackLeftPrimaryTop, TopBackLeftPrimaryBack, TopBackLeftPrimaryLeft, TopBackRightPrimaryTop, TopBackRightPrimaryBack, TopBackRightPrimaryRight, TopFrontLeftPrimaryTop, TopFrontLeftPrimaryFront, TopFrontLeftPrimaryLeft, TopFrontRightPrimaryTop, TopFrontRightPrimaryFront, TopFrontRightPrimaryRight, BottomFrontRightPrimaryBottom, BottomFrontRightPrimaryFront, BottomFrontRightPrimaryRight, BottomFrontLeftPrimaryBottom, BottomFrontLeftPrimaryFront, BottomFrontLeftPrimaryLeft, BottomBackRightPrimaryBottom, BottomBackRightPrimaryBack, BottomBackRightPrimaryRight, BottomBackLeftPrimaryBottom, BottomBackLeftPrimaryBack, BottomBackLeftPrimaryLeft, Unmasked, Masked, TopFrontPrimaryTop, TopFrontPrimaryFront, TopLeftPrimaryTop, TopLeftPrimaryLeft, TopBackPrimaryTop, TopBackPrimaryBack, TopRightPrimaryTop, TopRightPrimaryRight, BottomBackPrimaryBottom, BottomBackPrimaryBack, BottomRightPrimaryBottom, BottomRightPrimaryRight, BottomFrontPrimaryBottom, BottomFrontPrimaryFront, BottomLeftPrimaryBottom, BottomLeftPrimaryLeft, FrontLeftPrimaryFront, FrontLeftPrimaryLeft, BackLeftPrimaryBack, BackLeftPrimaryLeft, BackRightPrimaryBack, BackRightPrimaryRight, FrontRightPrimaryFront, FrontRightPrimaryRight
        };

        private static byte[] _LookupRotateLeftCW = new byte[] {
                TopFrontLeftPrimaryFront, TopFrontLeftPrimaryTop, TopFrontLeftPrimaryLeft, TopBackRightPrimaryTop, TopBackRightPrimaryBack, TopBackRightPrimaryRight, BottomFrontLeftPrimaryFront, BottomFrontLeftPrimaryBottom, BottomFrontLeftPrimaryLeft, TopFrontRightPrimaryTop, TopFrontRightPrimaryFront, TopFrontRightPrimaryRight, TopBackLeftPrimaryBack, TopBackLeftPrimaryTop, TopBackLeftPrimaryLeft, BottomBackRightPrimaryBottom, BottomBackRightPrimaryBack, BottomBackRightPrimaryRight, BottomBackLeftPrimaryBack, BottomBackLeftPrimaryBottom, BottomBackLeftPrimaryLeft, BottomFrontRightPrimaryBottom, BottomFrontRightPrimaryFront, BottomFrontRightPrimaryRight, Unmasked, Masked, TopFrontPrimaryTop, TopFrontPrimaryFront, FrontLeftPrimaryFront, FrontLeftPrimaryLeft, TopBackPrimaryTop, TopBackPrimaryBack, TopRightPrimaryTop, TopRightPrimaryRight, BottomFrontPrimaryBottom, BottomFrontPrimaryFront, BackLeftPrimaryBack, BackLeftPrimaryLeft, BottomBackPrimaryBottom, BottomBackPrimaryBack, BottomRightPrimaryBottom, BottomRightPrimaryRight, BottomLeftPrimaryBottom, BottomLeftPrimaryLeft, TopLeftPrimaryTop, TopLeftPrimaryLeft, BackRightPrimaryBack, BackRightPrimaryRight, FrontRightPrimaryFront, FrontRightPrimaryRight
        };

        private static byte[] _LookupRotateLeftCCW = new byte[] {
                BottomBackLeftPrimaryBack, BottomBackLeftPrimaryBottom, BottomBackLeftPrimaryLeft, TopBackRightPrimaryTop, TopBackRightPrimaryBack, TopBackRightPrimaryRight, TopBackLeftPrimaryBack, TopBackLeftPrimaryTop, TopBackLeftPrimaryLeft, TopFrontRightPrimaryTop, TopFrontRightPrimaryFront, TopFrontRightPrimaryRight, BottomFrontLeftPrimaryFront, BottomFrontLeftPrimaryBottom, BottomFrontLeftPrimaryLeft, BottomBackRightPrimaryBottom, BottomBackRightPrimaryBack, BottomBackRightPrimaryRight, TopFrontLeftPrimaryFront, TopFrontLeftPrimaryTop, TopFrontLeftPrimaryLeft, BottomFrontRightPrimaryBottom, BottomFrontRightPrimaryFront, BottomFrontRightPrimaryRight, Unmasked, Masked, TopFrontPrimaryTop, TopFrontPrimaryFront, BackLeftPrimaryBack, BackLeftPrimaryLeft, TopBackPrimaryTop, TopBackPrimaryBack, TopRightPrimaryTop, TopRightPrimaryRight, BottomFrontPrimaryBottom, BottomFrontPrimaryFront, FrontLeftPrimaryFront, FrontLeftPrimaryLeft, BottomBackPrimaryBottom, BottomBackPrimaryBack, BottomRightPrimaryBottom, BottomRightPrimaryRight, TopLeftPrimaryTop, TopLeftPrimaryLeft, BottomLeftPrimaryBottom, BottomLeftPrimaryLeft, BackRightPrimaryBack, BackRightPrimaryRight, FrontRightPrimaryFront, FrontRightPrimaryRight
        };

        private static byte[] _LookupRotateLeftHalf = new byte[] {
                BottomFrontLeftPrimaryBottom, BottomFrontLeftPrimaryFront, BottomFrontLeftPrimaryLeft, TopBackRightPrimaryTop, TopBackRightPrimaryBack, TopBackRightPrimaryRight, BottomBackLeftPrimaryBottom, BottomBackLeftPrimaryBack, BottomBackLeftPrimaryLeft, TopFrontRightPrimaryTop, TopFrontRightPrimaryFront, TopFrontRightPrimaryRight, TopFrontLeftPrimaryTop, TopFrontLeftPrimaryFront, TopFrontLeftPrimaryLeft, BottomBackRightPrimaryBottom, BottomBackRightPrimaryBack, BottomBackRightPrimaryRight, TopBackLeftPrimaryTop, TopBackLeftPrimaryBack, TopBackLeftPrimaryLeft, BottomFrontRightPrimaryBottom, BottomFrontRightPrimaryFront, BottomFrontRightPrimaryRight, Unmasked, Masked, TopFrontPrimaryTop, TopFrontPrimaryFront, BottomLeftPrimaryBottom, BottomLeftPrimaryLeft, TopBackPrimaryTop, TopBackPrimaryBack, TopRightPrimaryTop, TopRightPrimaryRight, BottomFrontPrimaryBottom, BottomFrontPrimaryFront, TopLeftPrimaryTop, TopLeftPrimaryLeft, BottomBackPrimaryBottom, BottomBackPrimaryBack, BottomRightPrimaryBottom, BottomRightPrimaryRight, BackLeftPrimaryBack, BackLeftPrimaryLeft, FrontLeftPrimaryFront, FrontLeftPrimaryLeft, BackRightPrimaryBack, BackRightPrimaryRight, FrontRightPrimaryFront, FrontRightPrimaryRight
        };

        private static byte[] _LookupRotateRightCW = new byte[] {
                TopBackLeftPrimaryTop, TopBackLeftPrimaryBack, TopBackLeftPrimaryLeft, BottomBackRightPrimaryBack, BottomBackRightPrimaryBottom, BottomBackRightPrimaryRight, TopFrontLeftPrimaryTop, TopFrontLeftPrimaryFront, TopFrontLeftPrimaryLeft, TopBackRightPrimaryBack, TopBackRightPrimaryTop, TopBackRightPrimaryRight, BottomBackLeftPrimaryBottom, BottomBackLeftPrimaryBack, BottomBackLeftPrimaryLeft, BottomFrontRightPrimaryFront, BottomFrontRightPrimaryBottom, BottomFrontRightPrimaryRight, BottomFrontLeftPrimaryBottom, BottomFrontLeftPrimaryFront, BottomFrontLeftPrimaryLeft, TopFrontRightPrimaryFront, TopFrontRightPrimaryTop, TopFrontRightPrimaryRight, Unmasked, Masked, TopFrontPrimaryTop, TopFrontPrimaryFront, TopLeftPrimaryTop, TopLeftPrimaryLeft, TopBackPrimaryTop, TopBackPrimaryBack, BackRightPrimaryBack, BackRightPrimaryRight, BottomFrontPrimaryBottom, BottomFrontPrimaryFront, BottomLeftPrimaryBottom, BottomLeftPrimaryLeft, BottomBackPrimaryBottom, BottomBackPrimaryBack, FrontRightPrimaryFront, FrontRightPrimaryRight, FrontLeftPrimaryFront, FrontLeftPrimaryLeft, BackLeftPrimaryBack, BackLeftPrimaryLeft, BottomRightPrimaryBottom, BottomRightPrimaryRight, TopRightPrimaryTop, TopRightPrimaryRight
        };

        private static byte[] _LookupRotateRightCCW = new byte[] {
                TopBackLeftPrimaryTop, TopBackLeftPrimaryBack, TopBackLeftPrimaryLeft, TopFrontRightPrimaryFront, TopFrontRightPrimaryTop, TopFrontRightPrimaryRight, TopFrontLeftPrimaryTop, TopFrontLeftPrimaryFront, TopFrontLeftPrimaryLeft, BottomFrontRightPrimaryFront, BottomFrontRightPrimaryBottom, BottomFrontRightPrimaryRight, BottomBackLeftPrimaryBottom, BottomBackLeftPrimaryBack, BottomBackLeftPrimaryLeft, TopBackRightPrimaryBack, TopBackRightPrimaryTop, TopBackRightPrimaryRight, BottomFrontLeftPrimaryBottom, BottomFrontLeftPrimaryFront, BottomFrontLeftPrimaryLeft, BottomBackRightPrimaryBack, BottomBackRightPrimaryBottom, BottomBackRightPrimaryRight, Unmasked, Masked, TopFrontPrimaryTop, TopFrontPrimaryFront, TopLeftPrimaryTop, TopLeftPrimaryLeft, TopBackPrimaryTop, TopBackPrimaryBack, FrontRightPrimaryFront, FrontRightPrimaryRight, BottomFrontPrimaryBottom, BottomFrontPrimaryFront, BottomLeftPrimaryBottom, BottomLeftPrimaryLeft, BottomBackPrimaryBottom, BottomBackPrimaryBack, BackRightPrimaryBack, BackRightPrimaryRight, FrontLeftPrimaryFront, FrontLeftPrimaryLeft, BackLeftPrimaryBack, BackLeftPrimaryLeft, TopRightPrimaryTop, TopRightPrimaryRight, BottomRightPrimaryBottom, BottomRightPrimaryRight
        };

        private static byte[] _LookupRotateRightHalf = new byte[] {
                TopBackLeftPrimaryTop, TopBackLeftPrimaryBack, TopBackLeftPrimaryLeft, BottomFrontRightPrimaryBottom, BottomFrontRightPrimaryFront, BottomFrontRightPrimaryRight, TopFrontLeftPrimaryTop, TopFrontLeftPrimaryFront, TopFrontLeftPrimaryLeft, BottomBackRightPrimaryBottom, BottomBackRightPrimaryBack, BottomBackRightPrimaryRight, BottomBackLeftPrimaryBottom, BottomBackLeftPrimaryBack, BottomBackLeftPrimaryLeft, TopFrontRightPrimaryTop, TopFrontRightPrimaryFront, TopFrontRightPrimaryRight, BottomFrontLeftPrimaryBottom, BottomFrontLeftPrimaryFront, BottomFrontLeftPrimaryLeft, TopBackRightPrimaryTop, TopBackRightPrimaryBack, TopBackRightPrimaryRight, Unmasked, Masked, TopFrontPrimaryTop, TopFrontPrimaryFront, TopLeftPrimaryTop, TopLeftPrimaryLeft, TopBackPrimaryTop, TopBackPrimaryBack, BottomRightPrimaryBottom, BottomRightPrimaryRight, BottomFrontPrimaryBottom, BottomFrontPrimaryFront, BottomLeftPrimaryBottom, BottomLeftPrimaryLeft, BottomBackPrimaryBottom, BottomBackPrimaryBack, TopRightPrimaryTop, TopRightPrimaryRight, FrontLeftPrimaryFront, FrontLeftPrimaryLeft, BackLeftPrimaryBack, BackLeftPrimaryLeft, FrontRightPrimaryFront, FrontRightPrimaryRight, BackRightPrimaryBack, BackRightPrimaryRight
        };

        private static byte[] _LookupRotateFrontCW = new byte[] {
                TopBackLeftPrimaryTop, TopBackLeftPrimaryBack, TopBackLeftPrimaryLeft, TopBackRightPrimaryTop, TopBackRightPrimaryBack, TopBackRightPrimaryRight, TopFrontRightPrimaryRight, TopFrontRightPrimaryFront, TopFrontRightPrimaryTop, BottomFrontRightPrimaryRight, BottomFrontRightPrimaryFront, BottomFrontRightPrimaryBottom, BottomBackLeftPrimaryBottom, BottomBackLeftPrimaryBack, BottomBackLeftPrimaryLeft, BottomBackRightPrimaryBottom, BottomBackRightPrimaryBack, BottomBackRightPrimaryRight, TopFrontLeftPrimaryLeft, TopFrontLeftPrimaryFront, TopFrontLeftPrimaryTop, BottomFrontLeftPrimaryLeft, BottomFrontLeftPrimaryFront, BottomFrontLeftPrimaryBottom, Unmasked, Masked, FrontRightPrimaryRight, FrontRightPrimaryFront, TopLeftPrimaryTop, TopLeftPrimaryLeft, TopBackPrimaryTop, TopBackPrimaryBack, TopRightPrimaryTop, TopRightPrimaryRight, FrontLeftPrimaryLeft, FrontLeftPrimaryFront, BottomLeftPrimaryBottom, BottomLeftPrimaryLeft, BottomBackPrimaryBottom, BottomBackPrimaryBack, BottomRightPrimaryBottom, BottomRightPrimaryRight, TopFrontPrimaryFront, TopFrontPrimaryTop, BackLeftPrimaryBack, BackLeftPrimaryLeft, BackRightPrimaryBack, BackRightPrimaryRight, BottomFrontPrimaryFront, BottomFrontPrimaryBottom
        };

        private static byte[] _LookupRotateFrontCCW = new byte[] {
                TopBackLeftPrimaryTop, TopBackLeftPrimaryBack, TopBackLeftPrimaryLeft, TopBackRightPrimaryTop, TopBackRightPrimaryBack, TopBackRightPrimaryRight, BottomFrontLeftPrimaryLeft, BottomFrontLeftPrimaryFront, BottomFrontLeftPrimaryBottom, TopFrontLeftPrimaryLeft, TopFrontLeftPrimaryFront, TopFrontLeftPrimaryTop, BottomBackLeftPrimaryBottom, BottomBackLeftPrimaryBack, BottomBackLeftPrimaryLeft, BottomBackRightPrimaryBottom, BottomBackRightPrimaryBack, BottomBackRightPrimaryRight, BottomFrontRightPrimaryRight, BottomFrontRightPrimaryFront, BottomFrontRightPrimaryBottom, TopFrontRightPrimaryRight, TopFrontRightPrimaryFront, TopFrontRightPrimaryTop, Unmasked, Masked, FrontLeftPrimaryLeft, FrontLeftPrimaryFront, TopLeftPrimaryTop, TopLeftPrimaryLeft, TopBackPrimaryTop, TopBackPrimaryBack, TopRightPrimaryTop, TopRightPrimaryRight, FrontRightPrimaryRight, FrontRightPrimaryFront, BottomLeftPrimaryBottom, BottomLeftPrimaryLeft, BottomBackPrimaryBottom, BottomBackPrimaryBack, BottomRightPrimaryBottom, BottomRightPrimaryRight, BottomFrontPrimaryFront, BottomFrontPrimaryBottom, BackLeftPrimaryBack, BackLeftPrimaryLeft, BackRightPrimaryBack, BackRightPrimaryRight, TopFrontPrimaryFront, TopFrontPrimaryTop
        };

        private static byte[] _LookupRotateFrontHalf = new byte[] {
                TopBackLeftPrimaryTop, TopBackLeftPrimaryBack, TopBackLeftPrimaryLeft, TopBackRightPrimaryTop, TopBackRightPrimaryBack, TopBackRightPrimaryRight, BottomFrontRightPrimaryBottom, BottomFrontRightPrimaryFront, BottomFrontRightPrimaryRight, BottomFrontLeftPrimaryBottom, BottomFrontLeftPrimaryFront, BottomFrontLeftPrimaryLeft, BottomBackLeftPrimaryBottom, BottomBackLeftPrimaryBack, BottomBackLeftPrimaryLeft, BottomBackRightPrimaryBottom, BottomBackRightPrimaryBack, BottomBackRightPrimaryRight, TopFrontRightPrimaryTop, TopFrontRightPrimaryFront, TopFrontRightPrimaryRight, TopFrontLeftPrimaryTop, TopFrontLeftPrimaryFront, TopFrontLeftPrimaryLeft, Unmasked, Masked, BottomFrontPrimaryBottom, BottomFrontPrimaryFront, TopLeftPrimaryTop, TopLeftPrimaryLeft, TopBackPrimaryTop, TopBackPrimaryBack, TopRightPrimaryTop, TopRightPrimaryRight, TopFrontPrimaryTop, TopFrontPrimaryFront, BottomLeftPrimaryBottom, BottomLeftPrimaryLeft, BottomBackPrimaryBottom, BottomBackPrimaryBack, BottomRightPrimaryBottom, BottomRightPrimaryRight, FrontRightPrimaryFront, FrontRightPrimaryRight, BackLeftPrimaryBack, BackLeftPrimaryLeft, BackRightPrimaryBack, BackRightPrimaryRight, FrontLeftPrimaryFront, FrontLeftPrimaryLeft
        };

        private static byte[] _LookupRotateBackCW = new byte[] {
                BottomBackLeftPrimaryLeft, BottomBackLeftPrimaryBack, BottomBackLeftPrimaryBottom, TopBackLeftPrimaryLeft, TopBackLeftPrimaryBack, TopBackLeftPrimaryTop, TopFrontLeftPrimaryTop, TopFrontLeftPrimaryFront, TopFrontLeftPrimaryLeft, TopFrontRightPrimaryTop, TopFrontRightPrimaryFront, TopFrontRightPrimaryRight, BottomBackRightPrimaryRight, BottomBackRightPrimaryBack, BottomBackRightPrimaryBottom, TopBackRightPrimaryRight, TopBackRightPrimaryBack, TopBackRightPrimaryTop, BottomFrontLeftPrimaryBottom, BottomFrontLeftPrimaryFront, BottomFrontLeftPrimaryLeft, BottomFrontRightPrimaryBottom, BottomFrontRightPrimaryFront, BottomFrontRightPrimaryRight, Unmasked, Masked, TopFrontPrimaryTop, TopFrontPrimaryFront, TopLeftPrimaryTop, TopLeftPrimaryLeft, BackLeftPrimaryLeft, BackLeftPrimaryBack, TopRightPrimaryTop, TopRightPrimaryRight, BottomFrontPrimaryBottom, BottomFrontPrimaryFront, BottomLeftPrimaryBottom, BottomLeftPrimaryLeft, BackRightPrimaryRight, BackRightPrimaryBack, BottomRightPrimaryBottom, BottomRightPrimaryRight, FrontLeftPrimaryFront, FrontLeftPrimaryLeft, BottomBackPrimaryBack, BottomBackPrimaryBottom, TopBackPrimaryBack, TopBackPrimaryTop, FrontRightPrimaryFront, FrontRightPrimaryRight
        };

        private static byte[] _LookupRotateBackCCW = new byte[] {
                TopBackRightPrimaryRight, TopBackRightPrimaryBack, TopBackRightPrimaryTop, BottomBackRightPrimaryRight, BottomBackRightPrimaryBack, BottomBackRightPrimaryBottom, TopFrontLeftPrimaryTop, TopFrontLeftPrimaryFront, TopFrontLeftPrimaryLeft, TopFrontRightPrimaryTop, TopFrontRightPrimaryFront, TopFrontRightPrimaryRight, TopBackLeftPrimaryLeft, TopBackLeftPrimaryBack, TopBackLeftPrimaryTop, BottomBackLeftPrimaryLeft, BottomBackLeftPrimaryBack, BottomBackLeftPrimaryBottom, BottomFrontLeftPrimaryBottom, BottomFrontLeftPrimaryFront, BottomFrontLeftPrimaryLeft, BottomFrontRightPrimaryBottom, BottomFrontRightPrimaryFront, BottomFrontRightPrimaryRight, Unmasked, Masked, TopFrontPrimaryTop, TopFrontPrimaryFront, TopLeftPrimaryTop, TopLeftPrimaryLeft, BackRightPrimaryRight, BackRightPrimaryBack, TopRightPrimaryTop, TopRightPrimaryRight, BottomFrontPrimaryBottom, BottomFrontPrimaryFront, BottomLeftPrimaryBottom, BottomLeftPrimaryLeft, BackLeftPrimaryLeft, BackLeftPrimaryBack, BottomRightPrimaryBottom, BottomRightPrimaryRight, FrontLeftPrimaryFront, FrontLeftPrimaryLeft, TopBackPrimaryBack, TopBackPrimaryTop, BottomBackPrimaryBack, BottomBackPrimaryBottom, FrontRightPrimaryFront, FrontRightPrimaryRight
        };

        private static byte[] _LookupRotateBackHalf = new byte[] {
                BottomBackRightPrimaryBottom, BottomBackRightPrimaryBack, BottomBackRightPrimaryRight, BottomBackLeftPrimaryBottom, BottomBackLeftPrimaryBack, BottomBackLeftPrimaryLeft, TopFrontLeftPrimaryTop, TopFrontLeftPrimaryFront, TopFrontLeftPrimaryLeft, TopFrontRightPrimaryTop, TopFrontRightPrimaryFront, TopFrontRightPrimaryRight, TopBackRightPrimaryTop, TopBackRightPrimaryBack, TopBackRightPrimaryRight, TopBackLeftPrimaryTop, TopBackLeftPrimaryBack, TopBackLeftPrimaryLeft, BottomFrontLeftPrimaryBottom, BottomFrontLeftPrimaryFront, BottomFrontLeftPrimaryLeft, BottomFrontRightPrimaryBottom, BottomFrontRightPrimaryFront, BottomFrontRightPrimaryRight, Unmasked, Masked, TopFrontPrimaryTop, TopFrontPrimaryFront, TopLeftPrimaryTop, TopLeftPrimaryLeft, BottomBackPrimaryBottom, BottomBackPrimaryBack, TopRightPrimaryTop, TopRightPrimaryRight, BottomFrontPrimaryBottom, BottomFrontPrimaryFront, BottomLeftPrimaryBottom, BottomLeftPrimaryLeft, TopBackPrimaryTop, TopBackPrimaryBack, BottomRightPrimaryBottom, BottomRightPrimaryRight, FrontLeftPrimaryFront, FrontLeftPrimaryLeft, BackRightPrimaryBack, BackRightPrimaryRight, BackLeftPrimaryBack, BackLeftPrimaryLeft, FrontRightPrimaryFront, FrontRightPrimaryRight
        };

        #endregion

        #region Rotation Functions

        public static byte RotateTopCW(byte cornerPosition)
        {
            return _LookupRotateTopCW[cornerPosition];
        }

        public static byte RotateTopCCW(byte cornerPosition)
        {
            return _LookupRotateTopCCW[cornerPosition];
        }

        public static byte RotateTopHalf(byte cornerPosition)
        {
            return _LookupRotateTopHalf[cornerPosition];
        }

        public static byte RotateBottomCW(byte cornerPosition)
        {
            return _LookupRotateBottomCW[cornerPosition];
        }

        public static byte RotateBottomCCW(byte cornerPosition)
        {
            return _LookupRotateBottomCCW[cornerPosition];
        }

        public static byte RotateBottomHalf(byte cornerPosition)
        {
            return _LookupRotateBottomHalf[cornerPosition];
        }

        public static byte RotateLeftCW(byte cornerPosition)
        {
            return _LookupRotateLeftCW[cornerPosition];
        }

        public static byte RotateLeftCCW(byte cornerPosition)
        {
            return _LookupRotateLeftCCW[cornerPosition];
        }

        public static byte RotateLeftHalf(byte cornerPosition)
        {
            return _LookupRotateLeftHalf[cornerPosition];
        }

        public static byte RotateRightCW(byte cornerPosition)
        {
            return _LookupRotateRightCW[cornerPosition];
        }

        public static byte RotateRightCCW(byte cornerPosition)
        {
            return _LookupRotateRightCCW[cornerPosition];
        }

        public static byte RotateRightHalf(byte cornerPosition)
        {
            return _LookupRotateRightHalf[cornerPosition];
        }

        public static byte RotateFrontCW(byte cornerPosition)
        {
            return _LookupRotateFrontCW[cornerPosition];
        }

        public static byte RotateFrontCCW(byte cornerPosition)
        {
            return _LookupRotateFrontCCW[cornerPosition];
        }

        public static byte RotateFrontHalf(byte cornerPosition)
        {
            return _LookupRotateFrontHalf[cornerPosition];
        }

        public static byte RotateBackCW(byte cornerPosition)
        {
            return _LookupRotateBackCW[cornerPosition];
        }


        public static byte RotateBackCCW(byte cornerPosition)
        {
            return _LookupRotateBackCCW[cornerPosition];
        }


        public static byte RotateBackHalf(byte cornerPosition)
        {
            return _LookupRotateBackHalf[cornerPosition];
        }

        #endregion

        #region Helper Functions

        public static bool IsValidPosition(byte b)
        {
            return b >= TopBackLeftPrimaryTop && b <= FrontRightPrimaryRight;
        }

        #endregion
    }
}
