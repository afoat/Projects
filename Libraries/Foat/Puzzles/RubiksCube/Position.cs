namespace Foat.Puzzles.RubiksCube
{
    using System;

    internal struct Position
    {
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



        public static byte RotateTopCW(byte cornerPosition)
        {
            switch (cornerPosition)
            {
                case Position.TopBackLeftPrimaryTop:
                    return Position.TopBackRightPrimaryTop;
                case Position.TopBackLeftPrimaryBack:
                    return Position.TopBackRightPrimaryRight;
                case Position.TopBackLeftPrimaryLeft:
                    return Position.TopBackRightPrimaryBack;
                case Position.TopBackRightPrimaryTop:
                    return Position.TopFrontRightPrimaryTop;
                case Position.TopBackRightPrimaryBack:
                    return Position.TopFrontRightPrimaryRight;
                case Position.TopBackRightPrimaryRight:
                    return Position.TopFrontRightPrimaryFront;
                case Position.TopFrontRightPrimaryTop:
                    return Position.TopFrontLeftPrimaryTop;
                case Position.TopFrontRightPrimaryFront:
                    return Position.TopFrontLeftPrimaryLeft;
                case Position.TopFrontRightPrimaryRight:
                    return Position.TopFrontLeftPrimaryFront;
                case Position.TopFrontLeftPrimaryTop:
                    return Position.TopBackLeftPrimaryTop;
                case Position.TopFrontLeftPrimaryFront:
                    return Position.TopBackLeftPrimaryLeft;
                case Position.TopFrontLeftPrimaryLeft:
                    return Position.TopBackLeftPrimaryBack;
                case Position.TopFrontPrimaryTop:
                    return Position.TopLeftPrimaryTop;
                case Position.TopFrontPrimaryFront:
                    return Position.TopLeftPrimaryLeft;
                case Position.TopLeftPrimaryTop:
                    return Position.TopBackPrimaryTop;
                case Position.TopLeftPrimaryLeft:
                    return Position.TopBackPrimaryBack;
                case Position.TopBackPrimaryTop:
                    return Position.TopRightPrimaryTop;
                case Position.TopBackPrimaryBack:
                    return Position.TopRightPrimaryRight;
                case Position.TopRightPrimaryTop:
                    return Position.TopFrontPrimaryTop;
                case Position.TopRightPrimaryRight:
                    return Position.TopFrontPrimaryFront;
                default:
                    return cornerPosition;
            }
        }

        public static byte RotateTopCCW(byte cornerPosition)
        {
            switch (cornerPosition)
            {
                case Position.TopBackLeftPrimaryTop:
                    return Position.TopFrontLeftPrimaryTop;
                case Position.TopBackLeftPrimaryBack:
                    return Position.TopFrontLeftPrimaryLeft;
                case Position.TopBackLeftPrimaryLeft:
                    return Position.TopFrontLeftPrimaryFront;
                case Position.TopBackRightPrimaryTop:
                    return Position.TopBackLeftPrimaryTop;
                case Position.TopBackRightPrimaryBack:
                    return Position.TopBackLeftPrimaryLeft;
                case Position.TopBackRightPrimaryRight:
                    return Position.TopBackLeftPrimaryBack;
                case Position.TopFrontRightPrimaryTop:
                    return Position.TopBackRightPrimaryTop;
                case Position.TopFrontRightPrimaryFront:
                    return Position.TopBackRightPrimaryRight;
                case Position.TopFrontRightPrimaryRight:
                    return Position.TopBackRightPrimaryBack;
                case Position.TopFrontLeftPrimaryTop:
                    return Position.TopFrontRightPrimaryTop;
                case Position.TopFrontLeftPrimaryFront:
                    return Position.TopFrontRightPrimaryRight;
                case Position.TopFrontLeftPrimaryLeft:
                    return Position.TopFrontRightPrimaryFront;
                case Position.TopFrontPrimaryTop:
                    return Position.TopRightPrimaryTop;
                case Position.TopFrontPrimaryFront:
                    return Position.TopRightPrimaryRight;
                case Position.TopLeftPrimaryTop:
                    return Position.TopFrontPrimaryTop;
                case Position.TopLeftPrimaryLeft:
                    return Position.TopFrontPrimaryFront;
                case Position.TopBackPrimaryTop:
                    return Position.TopLeftPrimaryTop;
                case Position.TopBackPrimaryBack:
                    return Position.TopLeftPrimaryLeft;
                case Position.TopRightPrimaryTop:
                    return Position.TopBackPrimaryTop;
                case Position.TopRightPrimaryRight:
                    return Position.TopBackPrimaryBack;
                default:
                    return cornerPosition;
            }
        }

        public static byte RotateTopHalf(byte cornerPosition)
        {
            switch (cornerPosition)
            {
                case Position.TopBackLeftPrimaryTop:
                    return Position.TopFrontRightPrimaryTop;
                case Position.TopBackLeftPrimaryBack:
                    return Position.TopFrontRightPrimaryFront;
                case Position.TopBackLeftPrimaryLeft:
                    return Position.TopFrontRightPrimaryRight;
                case Position.TopBackRightPrimaryTop:
                    return Position.TopFrontLeftPrimaryTop;
                case Position.TopBackRightPrimaryBack:
                    return Position.TopFrontLeftPrimaryFront;
                case Position.TopBackRightPrimaryRight:
                    return Position.TopFrontLeftPrimaryLeft;
                case Position.TopFrontRightPrimaryTop:
                    return Position.TopBackLeftPrimaryTop;
                case Position.TopFrontRightPrimaryFront:
                    return Position.TopBackLeftPrimaryBack;
                case Position.TopFrontRightPrimaryRight:
                    return Position.TopBackLeftPrimaryLeft;
                case Position.TopFrontLeftPrimaryTop:
                    return Position.TopBackRightPrimaryTop;
                case Position.TopFrontLeftPrimaryFront:
                    return Position.TopBackRightPrimaryBack;
                case Position.TopFrontLeftPrimaryLeft:
                    return Position.TopBackRightPrimaryRight;
                case Position.TopFrontPrimaryTop:
                    return Position.TopBackPrimaryTop;
                case Position.TopFrontPrimaryFront:
                    return Position.TopBackPrimaryBack;
                case Position.TopLeftPrimaryTop:
                    return Position.TopRightPrimaryTop;
                case Position.TopLeftPrimaryLeft:
                    return Position.TopRightPrimaryRight;
                case Position.TopBackPrimaryTop:
                    return Position.TopFrontPrimaryTop;
                case Position.TopBackPrimaryBack:
                    return Position.TopFrontPrimaryFront;
                case Position.TopRightPrimaryTop:
                    return Position.TopLeftPrimaryTop;
                case Position.TopRightPrimaryRight:
                    return Position.TopLeftPrimaryLeft;
                default:
                    return cornerPosition;
            }
        }

        public static byte RotateBottomCW(byte cornerPosition)
        {
            switch (cornerPosition)
            {
                case Position.BottomBackLeftPrimaryBottom:
                    return Position.BottomFrontLeftPrimaryBottom;
                case Position.BottomBackLeftPrimaryBack:
                    return Position.BottomFrontLeftPrimaryLeft;
                case Position.BottomBackLeftPrimaryLeft:
                    return Position.BottomFrontLeftPrimaryFront;
                case Position.BottomBackRightPrimaryBottom:
                    return Position.BottomBackLeftPrimaryBottom;
                case Position.BottomBackRightPrimaryBack:
                    return Position.BottomBackLeftPrimaryLeft;
                case Position.BottomBackRightPrimaryRight:
                    return Position.BottomBackLeftPrimaryBack;
                case Position.BottomFrontRightPrimaryBottom:
                    return Position.BottomBackRightPrimaryBottom;
                case Position.BottomFrontRightPrimaryFront:
                    return Position.BottomBackRightPrimaryRight;
                case Position.BottomFrontRightPrimaryRight:
                    return Position.BottomBackRightPrimaryBack;
                case Position.BottomFrontLeftPrimaryBottom:
                    return Position.BottomFrontRightPrimaryBottom;
                case Position.BottomFrontLeftPrimaryFront:
                    return Position.BottomFrontRightPrimaryRight;
                case Position.BottomFrontLeftPrimaryLeft:
                    return Position.BottomFrontRightPrimaryFront;
                case Position.BottomFrontPrimaryBottom:
                    return Position.BottomRightPrimaryBottom;
                case Position.BottomFrontPrimaryFront:
                    return Position.BottomRightPrimaryRight;
                case Position.BottomLeftPrimaryBottom:
                    return Position.BottomFrontPrimaryBottom;
                case Position.BottomLeftPrimaryLeft:
                    return Position.BottomFrontPrimaryFront;
                case Position.BottomBackPrimaryBottom:
                    return Position.BottomLeftPrimaryBottom;
                case Position.BottomBackPrimaryBack:
                    return Position.BottomLeftPrimaryLeft;
                case Position.BottomRightPrimaryBottom:
                    return Position.BottomBackPrimaryBottom;
                case Position.BottomRightPrimaryRight:
                    return Position.BottomBackPrimaryBack;
                default:
                    return cornerPosition;
            }
        }

        public static byte RotateBottomCCW(byte cornerPosition)
        {
            switch (cornerPosition)
            {
                case Position.BottomBackLeftPrimaryBottom:
                    return Position.BottomBackRightPrimaryBottom;
                case Position.BottomBackLeftPrimaryBack:
                    return Position.BottomBackRightPrimaryRight;
                case Position.BottomBackLeftPrimaryLeft:
                    return Position.BottomBackRightPrimaryBack;
                case Position.BottomBackRightPrimaryBottom:
                    return Position.BottomFrontRightPrimaryBottom;
                case Position.BottomBackRightPrimaryBack:
                    return Position.BottomFrontRightPrimaryRight;
                case Position.BottomBackRightPrimaryRight:
                    return Position.BottomFrontRightPrimaryFront;
                case Position.BottomFrontRightPrimaryBottom:
                    return Position.BottomFrontLeftPrimaryBottom;
                case Position.BottomFrontRightPrimaryFront:
                    return Position.BottomFrontLeftPrimaryLeft;
                case Position.BottomFrontRightPrimaryRight:
                    return Position.BottomFrontLeftPrimaryFront;
                case Position.BottomFrontLeftPrimaryBottom:
                    return Position.BottomBackLeftPrimaryBottom;
                case Position.BottomFrontLeftPrimaryFront:
                    return Position.BottomBackLeftPrimaryLeft;
                case Position.BottomFrontLeftPrimaryLeft:
                    return Position.BottomBackLeftPrimaryBack;
                case Position.BottomFrontPrimaryBottom:
                    return Position.BottomLeftPrimaryBottom;
                case Position.BottomFrontPrimaryFront:
                    return Position.BottomLeftPrimaryLeft;
                case Position.BottomLeftPrimaryBottom:
                    return Position.BottomBackPrimaryBottom;
                case Position.BottomLeftPrimaryLeft:
                    return Position.BottomBackPrimaryBack;
                case Position.BottomBackPrimaryBottom:
                    return Position.BottomRightPrimaryBottom;
                case Position.BottomBackPrimaryBack:
                    return Position.BottomRightPrimaryRight;
                case Position.BottomRightPrimaryBottom:
                    return Position.BottomFrontPrimaryBottom;
                case Position.BottomRightPrimaryRight:
                    return Position.BottomFrontPrimaryFront;
                default:
                    return cornerPosition;
            }
        }

        public static byte RotateBottomHalf(byte cornerPosition)
        {
            switch (cornerPosition)
            {
                case Position.BottomBackLeftPrimaryBottom:
                    return Position.BottomFrontRightPrimaryBottom;
                case Position.BottomBackLeftPrimaryBack:
                    return Position.BottomFrontRightPrimaryFront;
                case Position.BottomBackLeftPrimaryLeft:
                    return Position.BottomFrontRightPrimaryRight;
                case Position.BottomBackRightPrimaryBottom:
                    return Position.BottomFrontLeftPrimaryBottom;
                case Position.BottomBackRightPrimaryBack:
                    return Position.BottomFrontLeftPrimaryFront;
                case Position.BottomBackRightPrimaryRight:
                    return Position.BottomFrontLeftPrimaryLeft;
                case Position.BottomFrontRightPrimaryBottom:
                    return Position.BottomBackLeftPrimaryBottom;
                case Position.BottomFrontRightPrimaryFront:
                    return Position.BottomBackLeftPrimaryBack;
                case Position.BottomFrontRightPrimaryRight:
                    return Position.BottomBackLeftPrimaryLeft;
                case Position.BottomFrontLeftPrimaryBottom:
                    return Position.BottomBackRightPrimaryBottom;
                case Position.BottomFrontLeftPrimaryFront:
                    return Position.BottomBackRightPrimaryBack;
                case Position.BottomFrontLeftPrimaryLeft:
                    return Position.BottomBackRightPrimaryRight;
                case Position.BottomFrontPrimaryBottom:
                    return Position.BottomBackPrimaryBottom;
                case Position.BottomFrontPrimaryFront:
                    return Position.BottomBackPrimaryBack;
                case Position.BottomLeftPrimaryBottom:
                    return Position.BottomRightPrimaryBottom;
                case Position.BottomLeftPrimaryLeft:
                    return Position.BottomRightPrimaryRight;
                case Position.BottomBackPrimaryBottom:
                    return Position.BottomFrontPrimaryBottom;
                case Position.BottomBackPrimaryBack:
                    return Position.BottomFrontPrimaryFront;
                case Position.BottomRightPrimaryBottom:
                    return Position.BottomLeftPrimaryBottom;
                case Position.BottomRightPrimaryRight:
                    return Position.BottomLeftPrimaryLeft;
                default:
                    return cornerPosition;
            }
        }

        public static byte RotateLeftCW(byte cornerPosition)
        {
            switch (cornerPosition)
            {
                case Position.TopBackLeftPrimaryTop:
                    return Position.TopFrontLeftPrimaryFront;
                case Position.TopBackLeftPrimaryBack:
                    return Position.TopFrontLeftPrimaryTop;
                case Position.TopBackLeftPrimaryLeft:
                    return Position.TopFrontLeftPrimaryLeft;
                case Position.TopFrontLeftPrimaryTop:
                    return Position.BottomFrontLeftPrimaryFront;
                case Position.TopFrontLeftPrimaryFront:
                    return Position.BottomFrontLeftPrimaryBottom;
                case Position.TopFrontLeftPrimaryLeft:
                    return Position.BottomFrontLeftPrimaryLeft;
                case Position.BottomBackLeftPrimaryBottom:
                    return Position.TopBackLeftPrimaryBack;
                case Position.BottomBackLeftPrimaryBack:
                    return Position.TopBackLeftPrimaryTop;
                case Position.BottomBackLeftPrimaryLeft:
                    return Position.TopBackLeftPrimaryLeft;
                case Position.BottomFrontLeftPrimaryBottom:
                    return Position.BottomBackLeftPrimaryBack;
                case Position.BottomFrontLeftPrimaryFront:
                    return Position.BottomBackLeftPrimaryBottom;
                case Position.BottomFrontLeftPrimaryLeft:
                    return Position.BottomBackLeftPrimaryLeft;
                case Position.TopLeftPrimaryTop:
                    return Position.FrontLeftPrimaryFront;
                case Position.TopLeftPrimaryLeft:
                    return Position.FrontLeftPrimaryLeft;
                case Position.BottomLeftPrimaryBottom:
                    return Position.BackLeftPrimaryBack;
                case Position.BottomLeftPrimaryLeft:
                    return Position.BackLeftPrimaryLeft;
                case Position.FrontLeftPrimaryFront:
                    return Position.BottomLeftPrimaryBottom;
                case Position.FrontLeftPrimaryLeft:
                    return Position.BottomLeftPrimaryLeft;
                case Position.BackLeftPrimaryBack:
                    return Position.TopLeftPrimaryTop;
                case Position.BackLeftPrimaryLeft:
                    return Position.TopLeftPrimaryLeft;
                default:
                    return cornerPosition;
            }
        }

        public static byte RotateLeftCCW(byte cornerPosition)
        {
            switch (cornerPosition)
            {
                case Position.TopBackLeftPrimaryTop:
                    return Position.BottomBackLeftPrimaryBack;
                case Position.TopBackLeftPrimaryBack:
                    return Position.BottomBackLeftPrimaryBottom;
                case Position.TopBackLeftPrimaryLeft:
                    return Position.BottomBackLeftPrimaryLeft;
                case Position.TopFrontLeftPrimaryTop:
                    return Position.TopBackLeftPrimaryBack;
                case Position.TopFrontLeftPrimaryFront:
                    return Position.TopBackLeftPrimaryTop;
                case Position.TopFrontLeftPrimaryLeft:
                    return Position.TopBackLeftPrimaryLeft;
                case Position.BottomBackLeftPrimaryBottom:
                    return Position.BottomFrontLeftPrimaryFront;
                case Position.BottomBackLeftPrimaryBack:
                    return Position.BottomFrontLeftPrimaryBottom;
                case Position.BottomBackLeftPrimaryLeft:
                    return Position.BottomFrontLeftPrimaryLeft;
                case Position.BottomFrontLeftPrimaryBottom:
                    return Position.TopFrontLeftPrimaryFront;
                case Position.BottomFrontLeftPrimaryFront:
                    return Position.TopFrontLeftPrimaryTop;
                case Position.BottomFrontLeftPrimaryLeft:
                    return Position.TopFrontLeftPrimaryLeft;
                case Position.TopLeftPrimaryTop:
                    return Position.BackLeftPrimaryBack;
                case Position.TopLeftPrimaryLeft:
                    return Position.BackLeftPrimaryLeft;
                case Position.BottomLeftPrimaryBottom:
                    return Position.FrontLeftPrimaryFront;
                case Position.BottomLeftPrimaryLeft:
                    return Position.FrontLeftPrimaryLeft;
                case Position.FrontLeftPrimaryFront:
                    return Position.TopLeftPrimaryTop;
                case Position.FrontLeftPrimaryLeft:
                    return Position.TopLeftPrimaryLeft;
                case Position.BackLeftPrimaryBack:
                    return Position.BottomLeftPrimaryBottom;
                case Position.BackLeftPrimaryLeft:
                    return Position.BottomLeftPrimaryLeft;
                default:
                    return cornerPosition;
            }
        }

        public static byte RotateLeftHalf(byte cornerPosition)
        {
            switch (cornerPosition)
            {
                case Position.TopBackLeftPrimaryTop:
                    return Position.BottomFrontLeftPrimaryBottom;
                case Position.TopBackLeftPrimaryBack:
                    return Position.BottomFrontLeftPrimaryFront;
                case Position.TopBackLeftPrimaryLeft:
                    return Position.BottomFrontLeftPrimaryLeft;
                case Position.TopFrontLeftPrimaryTop:
                    return Position.BottomBackLeftPrimaryBottom;
                case Position.TopFrontLeftPrimaryFront:
                    return Position.BottomBackLeftPrimaryBack;
                case Position.TopFrontLeftPrimaryLeft:
                    return Position.BottomBackLeftPrimaryLeft;
                case Position.BottomBackLeftPrimaryBottom:
                    return Position.TopFrontLeftPrimaryTop;
                case Position.BottomBackLeftPrimaryBack:
                    return Position.TopFrontLeftPrimaryFront;
                case Position.BottomBackLeftPrimaryLeft:
                    return Position.TopFrontLeftPrimaryLeft;
                case Position.BottomFrontLeftPrimaryBottom:
                    return Position.TopBackLeftPrimaryTop;
                case Position.BottomFrontLeftPrimaryFront:
                    return Position.TopBackLeftPrimaryBack;
                case Position.BottomFrontLeftPrimaryLeft:
                    return Position.TopBackLeftPrimaryLeft;
                case Position.TopLeftPrimaryTop:
                    return Position.BottomLeftPrimaryBottom;
                case Position.TopLeftPrimaryLeft:
                    return Position.BottomLeftPrimaryLeft;
                case Position.BottomLeftPrimaryBottom:
                    return Position.TopLeftPrimaryTop;
                case Position.BottomLeftPrimaryLeft:
                    return Position.TopLeftPrimaryLeft;
                case Position.FrontLeftPrimaryFront:
                    return Position.BackLeftPrimaryBack;
                case Position.FrontLeftPrimaryLeft:
                    return Position.BackLeftPrimaryLeft;
                case Position.BackLeftPrimaryBack:
                    return Position.FrontLeftPrimaryFront;
                case Position.BackLeftPrimaryLeft:
                    return Position.FrontLeftPrimaryLeft;
                default:
                    return cornerPosition;
            }
        }

        public static byte RotateRightCW(byte cornerPosition)
        {
            switch (cornerPosition)
            {
                case Position.TopBackRightPrimaryTop:
                    return Position.BottomBackRightPrimaryBack;
                case Position.TopBackRightPrimaryBack:
                    return Position.BottomBackRightPrimaryBottom;
                case Position.TopBackRightPrimaryRight:
                    return Position.BottomBackRightPrimaryRight;
                case Position.TopFrontRightPrimaryTop:
                    return Position.TopBackRightPrimaryBack;
                case Position.TopFrontRightPrimaryFront:
                    return Position.TopBackRightPrimaryTop;
                case Position.TopFrontRightPrimaryRight:
                    return Position.TopBackRightPrimaryRight;
                case Position.BottomBackRightPrimaryBottom:
                    return Position.BottomFrontRightPrimaryFront;
                case Position.BottomBackRightPrimaryBack:
                    return Position.BottomFrontRightPrimaryBottom;
                case Position.BottomBackRightPrimaryRight:
                    return Position.BottomFrontRightPrimaryRight;
                case Position.BottomFrontRightPrimaryBottom:
                    return Position.TopFrontRightPrimaryFront;
                case Position.BottomFrontRightPrimaryFront:
                    return Position.TopFrontRightPrimaryTop;
                case Position.BottomFrontRightPrimaryRight:
                    return Position.TopFrontRightPrimaryRight;
                case Position.TopRightPrimaryTop:
                    return Position.BackRightPrimaryBack;
                case Position.TopRightPrimaryRight:
                    return Position.BackRightPrimaryRight;
                case Position.BottomRightPrimaryBottom:
                    return Position.FrontRightPrimaryFront;
                case Position.BottomRightPrimaryRight:
                    return Position.FrontRightPrimaryRight;
                case Position.BackRightPrimaryBack:
                    return Position.BottomRightPrimaryBottom;
                case Position.BackRightPrimaryRight:
                    return Position.BottomRightPrimaryRight;
                case Position.FrontRightPrimaryFront:
                    return Position.TopRightPrimaryTop;
                case Position.FrontRightPrimaryRight:
                    return Position.TopRightPrimaryRight;
                default:
                    return cornerPosition;
            }
        }

        public static byte RotateRightCCW(byte cornerPosition)
        {
            switch (cornerPosition)
            {
                case Position.TopBackRightPrimaryTop:
                    return Position.TopFrontRightPrimaryFront;
                case Position.TopBackRightPrimaryBack:
                    return Position.TopFrontRightPrimaryTop;
                case Position.TopBackRightPrimaryRight:
                    return Position.TopFrontRightPrimaryRight;
                case Position.TopFrontRightPrimaryTop:
                    return Position.BottomFrontRightPrimaryFront;
                case Position.TopFrontRightPrimaryFront:
                    return Position.BottomFrontRightPrimaryBottom;
                case Position.TopFrontRightPrimaryRight:
                    return Position.BottomFrontRightPrimaryRight;
                case Position.BottomBackRightPrimaryBottom:
                    return Position.TopBackRightPrimaryBack;
                case Position.BottomBackRightPrimaryBack:
                    return Position.TopBackRightPrimaryTop;
                case Position.BottomBackRightPrimaryRight:
                    return Position.TopBackRightPrimaryRight;
                case Position.BottomFrontRightPrimaryBottom:
                    return Position.BottomBackRightPrimaryBack;
                case Position.BottomFrontRightPrimaryFront:
                    return Position.BottomBackRightPrimaryBottom;
                case Position.BottomFrontRightPrimaryRight:
                    return Position.BottomBackRightPrimaryRight;
                case Position.TopRightPrimaryTop:
                    return Position.FrontRightPrimaryFront;
                case Position.TopRightPrimaryRight:
                    return Position.FrontRightPrimaryRight;
                case Position.BottomRightPrimaryBottom:
                    return Position.BackRightPrimaryBack;
                case Position.BottomRightPrimaryRight:
                    return Position.BackRightPrimaryRight;
                case Position.BackRightPrimaryBack:
                    return Position.TopRightPrimaryTop;
                case Position.BackRightPrimaryRight:
                    return Position.TopRightPrimaryRight;
                case Position.FrontRightPrimaryFront:
                    return Position.BottomRightPrimaryBottom;
                case Position.FrontRightPrimaryRight:
                    return Position.BottomRightPrimaryRight;
                default:
                    return cornerPosition;
            }
        }

        public static byte RotateRightHalf(byte cornerPosition)
        {
            switch (cornerPosition)
            {
                case Position.TopBackRightPrimaryTop:
                    return Position.BottomFrontRightPrimaryBottom;
                case Position.TopBackRightPrimaryBack:
                    return Position.BottomFrontRightPrimaryFront;
                case Position.TopBackRightPrimaryRight:
                    return Position.BottomFrontRightPrimaryRight;
                case Position.TopFrontRightPrimaryTop:
                    return Position.BottomBackRightPrimaryBottom;
                case Position.TopFrontRightPrimaryFront:
                    return Position.BottomBackRightPrimaryBack;
                case Position.TopFrontRightPrimaryRight:
                    return Position.BottomBackRightPrimaryRight;
                case Position.BottomBackRightPrimaryBottom:
                    return Position.TopFrontRightPrimaryTop;
                case Position.BottomBackRightPrimaryBack:
                    return Position.TopFrontRightPrimaryFront;
                case Position.BottomBackRightPrimaryRight:
                    return Position.TopFrontRightPrimaryRight;
                case Position.BottomFrontRightPrimaryBottom:
                    return Position.TopBackRightPrimaryTop;
                case Position.BottomFrontRightPrimaryFront:
                    return Position.TopBackRightPrimaryBack;
                case Position.BottomFrontRightPrimaryRight:
                    return Position.TopBackRightPrimaryRight;
                case Position.TopRightPrimaryTop:
                    return Position.BottomRightPrimaryBottom;
                case Position.TopRightPrimaryRight:
                    return Position.BottomRightPrimaryRight;
                case Position.BottomRightPrimaryBottom:
                    return Position.TopRightPrimaryTop;
                case Position.BottomRightPrimaryRight:
                    return Position.TopRightPrimaryRight;
                case Position.BackRightPrimaryBack:
                    return Position.FrontRightPrimaryFront;
                case Position.BackRightPrimaryRight:
                    return Position.FrontRightPrimaryRight;
                case Position.FrontRightPrimaryFront:
                    return Position.BackRightPrimaryBack;
                case Position.FrontRightPrimaryRight:
                    return Position.BackRightPrimaryRight;
                default:
                    return cornerPosition;
            }
        }

        public static byte RotateFrontCW(byte cornerPosition)
        {
            switch (cornerPosition)
            {
                case Position.TopFrontRightPrimaryTop:
                    return Position.BottomFrontRightPrimaryRight;
                case Position.TopFrontRightPrimaryFront:
                    return Position.BottomFrontRightPrimaryFront;
                case Position.TopFrontRightPrimaryRight:
                    return Position.BottomFrontRightPrimaryBottom;
                case Position.TopFrontLeftPrimaryTop:
                    return Position.TopFrontRightPrimaryRight;
                case Position.TopFrontLeftPrimaryFront:
                    return Position.TopFrontRightPrimaryFront;
                case Position.TopFrontLeftPrimaryLeft:
                    return Position.TopFrontRightPrimaryTop;
                case Position.BottomFrontRightPrimaryBottom:
                    return Position.BottomFrontLeftPrimaryLeft;
                case Position.BottomFrontRightPrimaryFront:
                    return Position.BottomFrontLeftPrimaryFront;
                case Position.BottomFrontRightPrimaryRight:
                    return Position.BottomFrontLeftPrimaryBottom;
                case Position.BottomFrontLeftPrimaryBottom:
                    return Position.TopFrontLeftPrimaryLeft;
                case Position.BottomFrontLeftPrimaryFront:
                    return Position.TopFrontLeftPrimaryFront;
                case Position.BottomFrontLeftPrimaryLeft:
                    return Position.TopFrontLeftPrimaryTop;
                case Position.TopFrontPrimaryTop:
                    return Position.FrontRightPrimaryRight;
                case Position.TopFrontPrimaryFront:
                    return Position.FrontRightPrimaryFront;
                case Position.BottomFrontPrimaryBottom:
                    return Position.FrontLeftPrimaryLeft;
                case Position.BottomFrontPrimaryFront:
                    return Position.FrontLeftPrimaryFront;
                case Position.FrontLeftPrimaryFront:
                    return Position.TopFrontPrimaryFront;
                case Position.FrontLeftPrimaryLeft:
                    return Position.TopFrontPrimaryTop;
                case Position.FrontRightPrimaryFront:
                    return Position.BottomFrontPrimaryFront;
                case Position.FrontRightPrimaryRight:
                    return Position.BottomFrontPrimaryBottom;
                default:
                    return cornerPosition;
            }
        }

        public static byte RotateFrontCCW(byte cornerPosition)
        {
            switch (cornerPosition)
            {
                case Position.TopFrontRightPrimaryTop:
                    return Position.TopFrontLeftPrimaryLeft;
                case Position.TopFrontRightPrimaryFront:
                    return Position.TopFrontLeftPrimaryFront;
                case Position.TopFrontRightPrimaryRight:
                    return Position.TopFrontLeftPrimaryTop;
                case Position.TopFrontLeftPrimaryTop:
                    return Position.BottomFrontLeftPrimaryLeft;
                case Position.TopFrontLeftPrimaryFront:
                    return Position.BottomFrontLeftPrimaryFront;
                case Position.TopFrontLeftPrimaryLeft:
                    return Position.BottomFrontLeftPrimaryBottom;
                case Position.BottomFrontRightPrimaryBottom:
                    return Position.TopFrontRightPrimaryRight;
                case Position.BottomFrontRightPrimaryFront:
                    return Position.TopFrontRightPrimaryFront;
                case Position.BottomFrontRightPrimaryRight:
                    return Position.TopFrontRightPrimaryTop;
                case Position.BottomFrontLeftPrimaryBottom:
                    return Position.BottomFrontRightPrimaryRight;
                case Position.BottomFrontLeftPrimaryFront:
                    return Position.BottomFrontRightPrimaryFront;
                case Position.BottomFrontLeftPrimaryLeft:
                    return Position.BottomFrontRightPrimaryBottom;
                case Position.TopFrontPrimaryTop:
                    return Position.FrontLeftPrimaryLeft;
                case Position.TopFrontPrimaryFront:
                    return Position.FrontLeftPrimaryFront;
                case Position.BottomFrontPrimaryBottom:
                    return Position.FrontRightPrimaryRight;
                case Position.BottomFrontPrimaryFront:
                    return Position.FrontRightPrimaryFront;
                case Position.FrontLeftPrimaryFront:
                    return Position.BottomFrontPrimaryFront;
                case Position.FrontLeftPrimaryLeft:
                    return Position.BottomFrontPrimaryBottom;
                case Position.FrontRightPrimaryFront:
                    return Position.TopFrontPrimaryFront;
                case Position.FrontRightPrimaryRight:
                    return Position.TopFrontPrimaryTop;
                default:
                    return cornerPosition;
            }
        }

        public static byte RotateFrontHalf(byte cornerPosition)
        {
            switch (cornerPosition)
            {
                case Position.TopFrontRightPrimaryTop:
                    return Position.BottomFrontLeftPrimaryBottom;
                case Position.TopFrontRightPrimaryFront:
                    return Position.BottomFrontLeftPrimaryFront;
                case Position.TopFrontRightPrimaryRight:
                    return Position.BottomFrontLeftPrimaryLeft;
                case Position.TopFrontLeftPrimaryTop:
                    return Position.BottomFrontRightPrimaryBottom;
                case Position.TopFrontLeftPrimaryFront:
                    return Position.BottomFrontRightPrimaryFront;
                case Position.TopFrontLeftPrimaryLeft:
                    return Position.BottomFrontRightPrimaryRight;
                case Position.BottomFrontRightPrimaryBottom:
                    return Position.TopFrontLeftPrimaryTop;
                case Position.BottomFrontRightPrimaryFront:
                    return Position.TopFrontLeftPrimaryFront;
                case Position.BottomFrontRightPrimaryRight:
                    return Position.TopFrontLeftPrimaryLeft;
                case Position.BottomFrontLeftPrimaryBottom:
                    return Position.TopFrontRightPrimaryTop;
                case Position.BottomFrontLeftPrimaryFront:
                    return Position.TopFrontRightPrimaryFront;
                case Position.BottomFrontLeftPrimaryLeft:
                    return Position.TopFrontRightPrimaryRight;
                case Position.TopFrontPrimaryTop:
                    return Position.BottomFrontPrimaryBottom;
                case Position.TopFrontPrimaryFront:
                    return Position.BottomFrontPrimaryFront;
                case Position.BottomFrontPrimaryBottom:
                    return Position.TopFrontPrimaryTop;
                case Position.BottomFrontPrimaryFront:
                    return Position.TopFrontPrimaryFront;
                case Position.FrontLeftPrimaryFront:
                    return Position.FrontRightPrimaryFront;
                case Position.FrontLeftPrimaryLeft:
                    return Position.FrontRightPrimaryRight;
                case Position.FrontRightPrimaryFront:
                    return Position.FrontLeftPrimaryFront;
                case Position.FrontRightPrimaryRight:
                    return Position.FrontLeftPrimaryLeft;
                default:
                    return cornerPosition;
            }
        }

        public static byte RotateBackCW(byte cornerPosition)
        {
            switch (cornerPosition)
            {
                case Position.TopBackLeftPrimaryTop:
                    return Position.BottomBackLeftPrimaryLeft;
                case Position.TopBackLeftPrimaryBack:
                    return Position.BottomBackLeftPrimaryBack;
                case Position.TopBackLeftPrimaryLeft:
                    return Position.BottomBackLeftPrimaryBottom;
                case Position.TopBackRightPrimaryTop:
                    return Position.TopBackLeftPrimaryLeft;
                case Position.TopBackRightPrimaryBack:
                    return Position.TopBackLeftPrimaryBack;
                case Position.TopBackRightPrimaryRight:
                    return Position.TopBackLeftPrimaryTop;
                case Position.BottomBackLeftPrimaryBottom:
                    return Position.BottomBackRightPrimaryRight;
                case Position.BottomBackLeftPrimaryBack:
                    return Position.BottomBackRightPrimaryBack;
                case Position.BottomBackLeftPrimaryLeft:
                    return Position.BottomBackRightPrimaryBottom;
                case Position.BottomBackRightPrimaryBottom:
                    return Position.TopBackRightPrimaryRight;
                case Position.BottomBackRightPrimaryBack:
                    return Position.TopBackRightPrimaryBack;
                case Position.BottomBackRightPrimaryRight:
                    return Position.TopBackRightPrimaryTop;
                case Position.TopBackPrimaryTop:
                    return Position.BackLeftPrimaryLeft;
                case Position.TopBackPrimaryBack:
                    return Position.BackLeftPrimaryBack;
                case Position.BottomBackPrimaryBottom:
                    return Position.BackRightPrimaryRight;
                case Position.BottomBackPrimaryBack:
                    return Position.BackRightPrimaryBack;
                case Position.BackLeftPrimaryBack:
                    return Position.BottomBackPrimaryBack;
                case Position.BackLeftPrimaryLeft:
                    return Position.BottomBackPrimaryBottom;
                case Position.BackRightPrimaryBack:
                    return Position.TopBackPrimaryBack;
                case Position.BackRightPrimaryRight:
                    return Position.TopBackPrimaryTop;
                default:
                    return cornerPosition;
            }
        }


        public static byte RotateBackCCW(byte cornerPosition)
        {
            switch (cornerPosition)
            {
                case Position.TopBackLeftPrimaryTop:
                    return Position.TopBackRightPrimaryRight;
                case Position.TopBackLeftPrimaryBack:
                    return Position.TopBackRightPrimaryBack;
                case Position.TopBackLeftPrimaryLeft:
                    return Position.TopBackRightPrimaryTop;
                case Position.TopBackRightPrimaryTop:
                    return Position.BottomBackRightPrimaryRight;
                case Position.TopBackRightPrimaryBack:
                    return Position.BottomBackRightPrimaryBack;
                case Position.TopBackRightPrimaryRight:
                    return Position.BottomBackRightPrimaryBottom;
                case Position.BottomBackLeftPrimaryBottom:
                    return Position.TopBackLeftPrimaryLeft;
                case Position.BottomBackLeftPrimaryBack:
                    return Position.TopBackLeftPrimaryBack;
                case Position.BottomBackLeftPrimaryLeft:
                    return Position.TopBackLeftPrimaryTop;
                case Position.BottomBackRightPrimaryBottom:
                    return Position.BottomBackLeftPrimaryLeft;
                case Position.BottomBackRightPrimaryBack:
                    return Position.BottomBackLeftPrimaryBack;
                case Position.BottomBackRightPrimaryRight:
                    return Position.BottomBackLeftPrimaryBottom;
                case Position.TopBackPrimaryTop:
                    return Position.BackRightPrimaryRight;
                case Position.TopBackPrimaryBack:
                    return Position.BackRightPrimaryBack;
                case Position.BottomBackPrimaryBottom:
                    return Position.BackLeftPrimaryLeft;
                case Position.BottomBackPrimaryBack:
                    return Position.BackLeftPrimaryBack;
                case Position.BackLeftPrimaryBack:
                    return Position.TopBackPrimaryBack;
                case Position.BackLeftPrimaryLeft:
                    return Position.TopBackPrimaryTop;
                case Position.BackRightPrimaryBack:
                    return Position.BottomBackPrimaryBack;
                case Position.BackRightPrimaryRight:
                    return Position.BottomBackPrimaryBottom;
                default:
                    return cornerPosition;
            }
        }


        public static byte RotateBackHalf(byte cornerPosition)
        {
            switch (cornerPosition)
            {
                case Position.TopBackLeftPrimaryTop:
                    return Position.BottomBackRightPrimaryBottom;
                case Position.TopBackLeftPrimaryBack:
                    return Position.BottomBackRightPrimaryBack;
                case Position.TopBackLeftPrimaryLeft:
                    return Position.BottomBackRightPrimaryRight;
                case Position.TopBackRightPrimaryTop:
                    return Position.BottomBackLeftPrimaryBottom;
                case Position.TopBackRightPrimaryBack:
                    return Position.BottomBackLeftPrimaryBack;
                case Position.TopBackRightPrimaryRight:
                    return Position.BottomBackLeftPrimaryLeft;
                case Position.BottomBackLeftPrimaryBottom:
                    return Position.TopBackRightPrimaryTop;
                case Position.BottomBackLeftPrimaryBack:
                    return Position.TopBackRightPrimaryBack;
                case Position.BottomBackLeftPrimaryLeft:
                    return Position.TopBackRightPrimaryRight;
                case Position.BottomBackRightPrimaryBottom:
                    return Position.TopBackLeftPrimaryTop;
                case Position.BottomBackRightPrimaryBack:
                    return Position.TopBackLeftPrimaryBack;
                case Position.BottomBackRightPrimaryRight:
                    return Position.TopBackLeftPrimaryLeft;
                case Position.TopBackPrimaryTop:
                    return Position.BottomBackPrimaryBottom;
                case Position.TopBackPrimaryBack:
                    return Position.BottomBackPrimaryBack;
                case Position.BottomBackPrimaryBottom:
                    return Position.TopBackPrimaryTop;
                case Position.BottomBackPrimaryBack:
                    return Position.TopBackPrimaryBack;
                case Position.BackLeftPrimaryBack:
                    return Position.BackRightPrimaryBack;
                case Position.BackLeftPrimaryLeft:
                    return Position.BackRightPrimaryRight;
                case Position.BackRightPrimaryBack:
                    return Position.BackLeftPrimaryBack;
                case Position.BackRightPrimaryRight:
                    return Position.BackLeftPrimaryLeft;
                default:
                    return cornerPosition;
            }
        }

        public static byte Mask(byte facelet, byte mask)
        {
            switch (mask)
            {
                case Position.Masked:
                    return Position.Masked;
                case Position.Unmasked:
                    return facelet;
                default:
                    throw new ArgumentException("Invalid mask.");
            }
        }

        public static bool IsValidCornerPosition(byte b)
        {
            return b >= TopBackLeftPrimaryTop && b <= FrontRightPrimaryRight;
        }
    }
}
