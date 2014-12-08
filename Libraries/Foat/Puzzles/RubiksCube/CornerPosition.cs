namespace Foat.Puzzles.RubiksCube
{
    using System;

    internal struct CornerPosition
    {
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

        public static byte RotateTopCW(byte cornerPosition)
        {
            switch (cornerPosition)
            {
                case CornerPosition.TopBackLeftPrimaryTop:
                    return CornerPosition.TopBackRightPrimaryTop;
                case CornerPosition.TopBackLeftPrimaryBack:
                    return CornerPosition.TopBackRightPrimaryRight;
                case CornerPosition.TopBackLeftPrimaryLeft:
                    return CornerPosition.TopBackRightPrimaryBack;
                case CornerPosition.TopBackRightPrimaryTop:
                    return CornerPosition.TopFrontRightPrimaryTop;
                case CornerPosition.TopBackRightPrimaryBack:
                    return CornerPosition.TopFrontRightPrimaryRight;
                case CornerPosition.TopBackRightPrimaryRight:
                    return CornerPosition.TopFrontRightPrimaryFront;
                case CornerPosition.TopFrontRightPrimaryTop:
                    return CornerPosition.TopFrontLeftPrimaryTop;
                case CornerPosition.TopFrontRightPrimaryFront:
                    return CornerPosition.TopFrontLeftPrimaryLeft;
                case CornerPosition.TopFrontRightPrimaryRight:
                    return CornerPosition.TopFrontLeftPrimaryFront;
                case CornerPosition.TopFrontLeftPrimaryTop:
                    return CornerPosition.TopBackLeftPrimaryTop;
                case CornerPosition.TopFrontLeftPrimaryFront:
                    return CornerPosition.TopBackLeftPrimaryLeft;
                case CornerPosition.TopFrontLeftPrimaryLeft:
                    return CornerPosition.TopBackLeftPrimaryBack;
                case CornerPosition.BottomBackLeftPrimaryBottom:
                case CornerPosition.BottomBackLeftPrimaryBack:
                case CornerPosition.BottomBackLeftPrimaryLeft:
                case CornerPosition.BottomBackRightPrimaryBottom:
                case CornerPosition.BottomBackRightPrimaryBack:
                case CornerPosition.BottomBackRightPrimaryRight:
                case CornerPosition.BottomFrontRightPrimaryBottom:
                case CornerPosition.BottomFrontRightPrimaryFront:
                case CornerPosition.BottomFrontRightPrimaryRight:
                case CornerPosition.BottomFrontLeftPrimaryBottom:
                case CornerPosition.BottomFrontLeftPrimaryFront:
                case CornerPosition.BottomFrontLeftPrimaryLeft:
                case CornerPosition.Masked:
                case CornerPosition.Unmasked:
                    return cornerPosition;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static byte RotateTopCCW(byte cornerPosition)
        {
            switch (cornerPosition)
            {
                case CornerPosition.TopBackLeftPrimaryTop:
                    return CornerPosition.TopFrontLeftPrimaryTop;
                case CornerPosition.TopBackLeftPrimaryBack:
                    return CornerPosition.TopFrontLeftPrimaryLeft;
                case CornerPosition.TopBackLeftPrimaryLeft:
                    return CornerPosition.TopFrontLeftPrimaryFront;
                case CornerPosition.TopBackRightPrimaryTop:
                    return CornerPosition.TopBackLeftPrimaryTop;
                case CornerPosition.TopBackRightPrimaryBack:
                    return CornerPosition.TopBackLeftPrimaryLeft;
                case CornerPosition.TopBackRightPrimaryRight:
                    return CornerPosition.TopBackLeftPrimaryBack;
                case CornerPosition.TopFrontRightPrimaryTop:
                    return CornerPosition.TopBackRightPrimaryTop;
                case CornerPosition.TopFrontRightPrimaryFront:
                    return CornerPosition.TopBackRightPrimaryRight;
                case CornerPosition.TopFrontRightPrimaryRight:
                    return CornerPosition.TopBackRightPrimaryBack;
                case CornerPosition.TopFrontLeftPrimaryTop:
                    return CornerPosition.TopFrontRightPrimaryTop;
                case CornerPosition.TopFrontLeftPrimaryFront:
                    return CornerPosition.TopFrontRightPrimaryRight;
                case CornerPosition.TopFrontLeftPrimaryLeft:
                    return CornerPosition.TopFrontRightPrimaryFront;
                case CornerPosition.BottomBackLeftPrimaryBottom:
                case CornerPosition.BottomBackLeftPrimaryBack:
                case CornerPosition.BottomBackLeftPrimaryLeft:
                case CornerPosition.BottomBackRightPrimaryBottom:
                case CornerPosition.BottomBackRightPrimaryBack:
                case CornerPosition.BottomBackRightPrimaryRight:
                case CornerPosition.BottomFrontRightPrimaryBottom:
                case CornerPosition.BottomFrontRightPrimaryFront:
                case CornerPosition.BottomFrontRightPrimaryRight:
                case CornerPosition.BottomFrontLeftPrimaryBottom:
                case CornerPosition.BottomFrontLeftPrimaryFront:
                case CornerPosition.BottomFrontLeftPrimaryLeft:
                case CornerPosition.Masked:
                case CornerPosition.Unmasked:
                    return cornerPosition;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static byte RotateTopHalf(byte cornerPosition)
        {
            switch (cornerPosition)
            {
                case CornerPosition.TopBackLeftPrimaryTop:
                    return CornerPosition.TopFrontRightPrimaryTop;
                case CornerPosition.TopBackLeftPrimaryBack:
                    return CornerPosition.TopFrontRightPrimaryFront;
                case CornerPosition.TopBackLeftPrimaryLeft:
                    return CornerPosition.TopFrontRightPrimaryRight;
                case CornerPosition.TopBackRightPrimaryTop:
                    return CornerPosition.TopFrontLeftPrimaryTop;
                case CornerPosition.TopBackRightPrimaryBack:
                    return CornerPosition.TopFrontLeftPrimaryFront;
                case CornerPosition.TopBackRightPrimaryRight:
                    return CornerPosition.TopFrontLeftPrimaryLeft;
                case CornerPosition.TopFrontRightPrimaryTop:
                    return CornerPosition.TopBackLeftPrimaryTop;
                case CornerPosition.TopFrontRightPrimaryFront:
                    return CornerPosition.TopBackLeftPrimaryBack;
                case CornerPosition.TopFrontRightPrimaryRight:
                    return CornerPosition.TopBackLeftPrimaryLeft;
                case CornerPosition.TopFrontLeftPrimaryTop:
                    return CornerPosition.TopBackRightPrimaryTop;
                case CornerPosition.TopFrontLeftPrimaryFront:
                    return CornerPosition.TopBackRightPrimaryBack;
                case CornerPosition.TopFrontLeftPrimaryLeft:
                    return CornerPosition.TopBackRightPrimaryRight;
                case CornerPosition.BottomBackLeftPrimaryBottom:
                case CornerPosition.BottomBackLeftPrimaryBack:
                case CornerPosition.BottomBackLeftPrimaryLeft:
                case CornerPosition.BottomBackRightPrimaryBottom:
                case CornerPosition.BottomBackRightPrimaryBack:
                case CornerPosition.BottomBackRightPrimaryRight:
                case CornerPosition.BottomFrontRightPrimaryBottom:
                case CornerPosition.BottomFrontRightPrimaryFront:
                case CornerPosition.BottomFrontRightPrimaryRight:
                case CornerPosition.BottomFrontLeftPrimaryBottom:
                case CornerPosition.BottomFrontLeftPrimaryFront:
                case CornerPosition.BottomFrontLeftPrimaryLeft:
                case CornerPosition.Masked:
                case CornerPosition.Unmasked:
                    return cornerPosition;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static byte RotateBottomCW(byte cornerPosition)
        {
            switch (cornerPosition)
            {
                case CornerPosition.TopBackLeftPrimaryTop:
                case CornerPosition.TopBackLeftPrimaryBack:
                case CornerPosition.TopBackLeftPrimaryLeft:
                case CornerPosition.TopBackRightPrimaryTop:
                case CornerPosition.TopBackRightPrimaryBack:
                case CornerPosition.TopBackRightPrimaryRight:
                case CornerPosition.TopFrontRightPrimaryTop:
                case CornerPosition.TopFrontRightPrimaryFront:
                case CornerPosition.TopFrontRightPrimaryRight:
                case CornerPosition.TopFrontLeftPrimaryTop:
                case CornerPosition.TopFrontLeftPrimaryFront:
                case CornerPosition.TopFrontLeftPrimaryLeft:
                case CornerPosition.Masked:
                case CornerPosition.Unmasked:
                    return cornerPosition;
                case CornerPosition.BottomBackLeftPrimaryBottom:
                    return CornerPosition.BottomFrontLeftPrimaryBottom;
                case CornerPosition.BottomBackLeftPrimaryBack:
                    return CornerPosition.BottomFrontLeftPrimaryLeft;
                case CornerPosition.BottomBackLeftPrimaryLeft:
                    return CornerPosition.BottomFrontLeftPrimaryFront;
                case CornerPosition.BottomBackRightPrimaryBottom:
                    return CornerPosition.BottomBackLeftPrimaryBottom;
                case CornerPosition.BottomBackRightPrimaryBack:
                    return CornerPosition.BottomBackLeftPrimaryLeft;
                case CornerPosition.BottomBackRightPrimaryRight:
                    return CornerPosition.BottomBackLeftPrimaryBack;
                case CornerPosition.BottomFrontRightPrimaryBottom:
                    return CornerPosition.BottomBackRightPrimaryBottom;
                case CornerPosition.BottomFrontRightPrimaryFront:
                    return CornerPosition.BottomBackRightPrimaryRight;
                case CornerPosition.BottomFrontRightPrimaryRight:
                    return CornerPosition.BottomBackRightPrimaryBack;
                case CornerPosition.BottomFrontLeftPrimaryBottom:
                    return CornerPosition.BottomFrontRightPrimaryBottom;
                case CornerPosition.BottomFrontLeftPrimaryFront:
                    return CornerPosition.BottomFrontRightPrimaryRight;
                case CornerPosition.BottomFrontLeftPrimaryLeft:
                    return CornerPosition.BottomFrontRightPrimaryFront;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static byte RotateBottomCCW(byte cornerPosition)
        {
            switch (cornerPosition)
            {
                case CornerPosition.TopBackLeftPrimaryTop:
                case CornerPosition.TopBackLeftPrimaryBack:
                case CornerPosition.TopBackLeftPrimaryLeft:
                case CornerPosition.TopBackRightPrimaryTop:
                case CornerPosition.TopBackRightPrimaryBack:
                case CornerPosition.TopBackRightPrimaryRight:
                case CornerPosition.TopFrontRightPrimaryTop:
                case CornerPosition.TopFrontRightPrimaryFront:
                case CornerPosition.TopFrontRightPrimaryRight:
                case CornerPosition.TopFrontLeftPrimaryTop:
                case CornerPosition.TopFrontLeftPrimaryFront:
                case CornerPosition.TopFrontLeftPrimaryLeft:
                case CornerPosition.Masked:
                case CornerPosition.Unmasked:
                    return cornerPosition;
                case CornerPosition.BottomBackLeftPrimaryBottom:
                    return CornerPosition.BottomBackRightPrimaryBottom;
                case CornerPosition.BottomBackLeftPrimaryBack:
                    return CornerPosition.BottomBackRightPrimaryRight;
                case CornerPosition.BottomBackLeftPrimaryLeft:
                    return CornerPosition.BottomBackRightPrimaryBack;
                case CornerPosition.BottomBackRightPrimaryBottom:
                    return CornerPosition.BottomFrontRightPrimaryBottom;
                case CornerPosition.BottomBackRightPrimaryBack:
                    return CornerPosition.BottomFrontRightPrimaryRight;
                case CornerPosition.BottomBackRightPrimaryRight:
                    return CornerPosition.BottomFrontRightPrimaryFront;
                case CornerPosition.BottomFrontRightPrimaryBottom:
                    return CornerPosition.BottomFrontLeftPrimaryBottom;
                case CornerPosition.BottomFrontRightPrimaryFront:
                    return CornerPosition.BottomFrontLeftPrimaryLeft;
                case CornerPosition.BottomFrontRightPrimaryRight:
                    return CornerPosition.BottomFrontLeftPrimaryFront;
                case CornerPosition.BottomFrontLeftPrimaryBottom:
                    return CornerPosition.BottomBackLeftPrimaryBottom;
                case CornerPosition.BottomFrontLeftPrimaryFront:
                    return CornerPosition.BottomBackLeftPrimaryLeft;
                case CornerPosition.BottomFrontLeftPrimaryLeft:
                    return CornerPosition.BottomBackLeftPrimaryBack;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static byte RotateBottomHalf(byte cornerPosition)
        {
            switch (cornerPosition)
            {
                case CornerPosition.TopBackLeftPrimaryTop:
                case CornerPosition.TopBackLeftPrimaryBack:
                case CornerPosition.TopBackLeftPrimaryLeft:
                case CornerPosition.TopBackRightPrimaryTop:
                case CornerPosition.TopBackRightPrimaryBack:
                case CornerPosition.TopBackRightPrimaryRight:
                case CornerPosition.TopFrontRightPrimaryTop:
                case CornerPosition.TopFrontRightPrimaryFront:
                case CornerPosition.TopFrontRightPrimaryRight:
                case CornerPosition.TopFrontLeftPrimaryTop:
                case CornerPosition.TopFrontLeftPrimaryFront:
                case CornerPosition.TopFrontLeftPrimaryLeft:
                case CornerPosition.Masked:
                case CornerPosition.Unmasked:
                    return cornerPosition;
                case CornerPosition.BottomBackLeftPrimaryBottom:
                    return CornerPosition.BottomFrontRightPrimaryBottom;
                case CornerPosition.BottomBackLeftPrimaryBack:
                    return CornerPosition.BottomFrontRightPrimaryFront;
                case CornerPosition.BottomBackLeftPrimaryLeft:
                    return CornerPosition.BottomFrontRightPrimaryRight;
                case CornerPosition.BottomBackRightPrimaryBottom:
                    return CornerPosition.BottomFrontLeftPrimaryBottom;
                case CornerPosition.BottomBackRightPrimaryBack:
                    return CornerPosition.BottomFrontLeftPrimaryFront;
                case CornerPosition.BottomBackRightPrimaryRight:
                    return CornerPosition.BottomFrontLeftPrimaryLeft;
                case CornerPosition.BottomFrontRightPrimaryBottom:
                    return CornerPosition.BottomBackLeftPrimaryBottom;
                case CornerPosition.BottomFrontRightPrimaryFront:
                    return CornerPosition.BottomBackLeftPrimaryBack;
                case CornerPosition.BottomFrontRightPrimaryRight:
                    return CornerPosition.BottomBackLeftPrimaryLeft;
                case CornerPosition.BottomFrontLeftPrimaryBottom:
                    return CornerPosition.BottomBackRightPrimaryBottom;
                case CornerPosition.BottomFrontLeftPrimaryFront:
                    return CornerPosition.BottomBackRightPrimaryBack;
                case CornerPosition.BottomFrontLeftPrimaryLeft:
                    return CornerPosition.BottomBackRightPrimaryRight;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static byte RotateLeftCW(byte cornerPosition)
        {
            switch (cornerPosition)
            {
                case CornerPosition.TopBackLeftPrimaryTop:
                    return CornerPosition.TopFrontLeftPrimaryFront;
                case CornerPosition.TopBackLeftPrimaryBack:
                    return CornerPosition.TopFrontLeftPrimaryTop;
                case CornerPosition.TopBackLeftPrimaryLeft:
                    return CornerPosition.TopFrontLeftPrimaryLeft;
                case CornerPosition.TopFrontLeftPrimaryTop:
                    return CornerPosition.BottomFrontLeftPrimaryFront;
                case CornerPosition.TopFrontLeftPrimaryFront:
                    return CornerPosition.BottomFrontLeftPrimaryBottom;
                case CornerPosition.TopFrontLeftPrimaryLeft:
                    return CornerPosition.BottomFrontLeftPrimaryLeft;
                case CornerPosition.BottomBackLeftPrimaryBottom:
                    return CornerPosition.TopBackLeftPrimaryBack;
                case CornerPosition.BottomBackLeftPrimaryBack:
                    return CornerPosition.TopBackLeftPrimaryTop;
                case CornerPosition.BottomBackLeftPrimaryLeft:
                    return CornerPosition.TopBackLeftPrimaryLeft;
                case CornerPosition.BottomFrontLeftPrimaryBottom:
                    return CornerPosition.BottomBackLeftPrimaryBack;
                case CornerPosition.BottomFrontLeftPrimaryFront:
                    return CornerPosition.BottomBackLeftPrimaryBottom;
                case CornerPosition.BottomFrontLeftPrimaryLeft:
                    return CornerPosition.BottomBackLeftPrimaryLeft;
                case CornerPosition.TopBackRightPrimaryTop:
                case CornerPosition.TopBackRightPrimaryBack:
                case CornerPosition.TopBackRightPrimaryRight:
                case CornerPosition.TopFrontRightPrimaryTop:
                case CornerPosition.TopFrontRightPrimaryFront:
                case CornerPosition.TopFrontRightPrimaryRight:
                case CornerPosition.BottomBackRightPrimaryBottom:
                case CornerPosition.BottomBackRightPrimaryBack:
                case CornerPosition.BottomBackRightPrimaryRight:
                case CornerPosition.BottomFrontRightPrimaryBottom:
                case CornerPosition.BottomFrontRightPrimaryFront:
                case CornerPosition.BottomFrontRightPrimaryRight:
                case CornerPosition.Masked:
                case CornerPosition.Unmasked:
                    return cornerPosition;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static byte RotateLeftCCW(byte cornerPosition)
        {
            switch (cornerPosition)
            {
                case CornerPosition.TopBackLeftPrimaryTop:
                    return CornerPosition.BottomBackLeftPrimaryBack;
                case CornerPosition.TopBackLeftPrimaryBack:
                    return CornerPosition.BottomBackLeftPrimaryBottom;
                case CornerPosition.TopBackLeftPrimaryLeft:
                    return CornerPosition.BottomBackLeftPrimaryLeft;
                case CornerPosition.TopFrontLeftPrimaryTop:
                    return CornerPosition.TopBackLeftPrimaryBack;
                case CornerPosition.TopFrontLeftPrimaryFront:
                    return CornerPosition.TopBackLeftPrimaryTop;
                case CornerPosition.TopFrontLeftPrimaryLeft:
                    return CornerPosition.TopBackLeftPrimaryLeft;
                case CornerPosition.BottomBackLeftPrimaryBottom:
                    return CornerPosition.BottomFrontLeftPrimaryFront;
                case CornerPosition.BottomBackLeftPrimaryBack:
                    return CornerPosition.BottomFrontLeftPrimaryBottom;
                case CornerPosition.BottomBackLeftPrimaryLeft:
                    return CornerPosition.BottomFrontLeftPrimaryLeft;
                case CornerPosition.BottomFrontLeftPrimaryBottom:
                    return CornerPosition.TopFrontLeftPrimaryFront;
                case CornerPosition.BottomFrontLeftPrimaryFront:
                    return CornerPosition.TopFrontLeftPrimaryTop;
                case CornerPosition.BottomFrontLeftPrimaryLeft:
                    return CornerPosition.TopFrontLeftPrimaryLeft;
                case CornerPosition.TopBackRightPrimaryTop:
                case CornerPosition.TopBackRightPrimaryBack:
                case CornerPosition.TopBackRightPrimaryRight:
                case CornerPosition.TopFrontRightPrimaryTop:
                case CornerPosition.TopFrontRightPrimaryFront:
                case CornerPosition.TopFrontRightPrimaryRight:
                case CornerPosition.BottomBackRightPrimaryBottom:
                case CornerPosition.BottomBackRightPrimaryBack:
                case CornerPosition.BottomBackRightPrimaryRight:
                case CornerPosition.BottomFrontRightPrimaryBottom:
                case CornerPosition.BottomFrontRightPrimaryFront:
                case CornerPosition.BottomFrontRightPrimaryRight:
                case CornerPosition.Masked:
                case CornerPosition.Unmasked:
                    return cornerPosition;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static byte RotateLeftHalf(byte cornerPosition)
        {
            switch (cornerPosition)
            {
                case CornerPosition.TopBackLeftPrimaryTop:
                    return CornerPosition.BottomFrontLeftPrimaryBottom;
                case CornerPosition.TopBackLeftPrimaryBack:
                    return CornerPosition.BottomFrontLeftPrimaryFront;
                case CornerPosition.TopBackLeftPrimaryLeft:
                    return CornerPosition.BottomFrontLeftPrimaryLeft;
                case CornerPosition.TopFrontLeftPrimaryTop:
                    return CornerPosition.BottomBackLeftPrimaryBottom;
                case CornerPosition.TopFrontLeftPrimaryFront:
                    return CornerPosition.BottomBackLeftPrimaryBack;
                case CornerPosition.TopFrontLeftPrimaryLeft:
                    return CornerPosition.BottomBackLeftPrimaryLeft;
                case CornerPosition.BottomBackLeftPrimaryBottom:
                    return CornerPosition.TopFrontLeftPrimaryTop;
                case CornerPosition.BottomBackLeftPrimaryBack:
                    return CornerPosition.TopFrontLeftPrimaryFront;
                case CornerPosition.BottomBackLeftPrimaryLeft:
                    return CornerPosition.TopFrontLeftPrimaryLeft;
                case CornerPosition.BottomFrontLeftPrimaryBottom:
                    return CornerPosition.TopBackLeftPrimaryTop;
                case CornerPosition.BottomFrontLeftPrimaryFront:
                    return CornerPosition.TopBackLeftPrimaryBack;
                case CornerPosition.BottomFrontLeftPrimaryLeft:
                    return CornerPosition.TopBackLeftPrimaryLeft;
                case CornerPosition.TopBackRightPrimaryTop:
                case CornerPosition.TopBackRightPrimaryBack:
                case CornerPosition.TopBackRightPrimaryRight:
                case CornerPosition.TopFrontRightPrimaryTop:
                case CornerPosition.TopFrontRightPrimaryFront:
                case CornerPosition.TopFrontRightPrimaryRight:
                case CornerPosition.BottomBackRightPrimaryBottom:
                case CornerPosition.BottomBackRightPrimaryBack:
                case CornerPosition.BottomBackRightPrimaryRight:
                case CornerPosition.BottomFrontRightPrimaryBottom:
                case CornerPosition.BottomFrontRightPrimaryFront:
                case CornerPosition.BottomFrontRightPrimaryRight:
                case CornerPosition.Masked:
                case CornerPosition.Unmasked:
                    return cornerPosition;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static byte RotateRightCW(byte cornerPosition)
        {
            switch (cornerPosition)
            {
                case CornerPosition.TopBackRightPrimaryTop:
                    return CornerPosition.BottomBackRightPrimaryBack;
                case CornerPosition.TopBackRightPrimaryBack:
                    return CornerPosition.BottomBackRightPrimaryBottom;
                case CornerPosition.TopBackRightPrimaryRight:
                    return CornerPosition.BottomBackRightPrimaryRight;
                case CornerPosition.TopFrontRightPrimaryTop:
                    return CornerPosition.TopBackRightPrimaryBack;
                case CornerPosition.TopFrontRightPrimaryFront:
                    return CornerPosition.TopBackRightPrimaryTop;
                case CornerPosition.TopFrontRightPrimaryRight:
                    return CornerPosition.TopBackRightPrimaryRight;
                case CornerPosition.BottomBackRightPrimaryBottom:
                    return CornerPosition.BottomFrontRightPrimaryFront;
                case CornerPosition.BottomBackRightPrimaryBack:
                    return CornerPosition.BottomFrontRightPrimaryBottom;
                case CornerPosition.BottomBackRightPrimaryRight:
                    return CornerPosition.BottomFrontRightPrimaryRight;
                case CornerPosition.BottomFrontRightPrimaryBottom:
                    return CornerPosition.TopFrontRightPrimaryFront;
                case CornerPosition.BottomFrontRightPrimaryFront:
                    return CornerPosition.TopFrontRightPrimaryTop;
                case CornerPosition.BottomFrontRightPrimaryRight:
                    return CornerPosition.TopFrontRightPrimaryRight;
                case CornerPosition.TopBackLeftPrimaryTop:
                case CornerPosition.TopBackLeftPrimaryBack:
                case CornerPosition.TopBackLeftPrimaryLeft:
                case CornerPosition.TopFrontLeftPrimaryTop:
                case CornerPosition.TopFrontLeftPrimaryFront:
                case CornerPosition.TopFrontLeftPrimaryLeft:
                case CornerPosition.BottomBackLeftPrimaryBottom:
                case CornerPosition.BottomBackLeftPrimaryBack:
                case CornerPosition.BottomBackLeftPrimaryLeft:
                case CornerPosition.BottomFrontLeftPrimaryBottom:
                case CornerPosition.BottomFrontLeftPrimaryFront:
                case CornerPosition.BottomFrontLeftPrimaryLeft:
                case CornerPosition.Masked:
                case CornerPosition.Unmasked:
                    return cornerPosition;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static byte RotateRightCCW(byte cornerPosition)
        {
            switch (cornerPosition)
            {
                case CornerPosition.TopBackRightPrimaryTop:
                    return CornerPosition.TopFrontRightPrimaryFront;
                case CornerPosition.TopBackRightPrimaryBack:
                    return CornerPosition.TopFrontRightPrimaryTop;
                case CornerPosition.TopBackRightPrimaryRight:
                    return CornerPosition.TopFrontRightPrimaryRight;
                case CornerPosition.TopFrontRightPrimaryTop:
                    return CornerPosition.BottomFrontRightPrimaryFront;
                case CornerPosition.TopFrontRightPrimaryFront:
                    return CornerPosition.BottomFrontRightPrimaryBottom;
                case CornerPosition.TopFrontRightPrimaryRight:
                    return CornerPosition.BottomFrontRightPrimaryRight;
                case CornerPosition.BottomBackRightPrimaryBottom:
                    return CornerPosition.TopBackRightPrimaryBack;
                case CornerPosition.BottomBackRightPrimaryBack:
                    return CornerPosition.TopBackRightPrimaryTop;
                case CornerPosition.BottomBackRightPrimaryRight:
                    return CornerPosition.TopBackRightPrimaryRight;
                case CornerPosition.BottomFrontRightPrimaryBottom:
                    return CornerPosition.BottomBackRightPrimaryBack;
                case CornerPosition.BottomFrontRightPrimaryFront:
                    return CornerPosition.BottomBackRightPrimaryBottom;
                case CornerPosition.BottomFrontRightPrimaryRight:
                    return CornerPosition.BottomBackRightPrimaryRight;
                case CornerPosition.TopBackLeftPrimaryTop:
                case CornerPosition.TopBackLeftPrimaryBack:
                case CornerPosition.TopBackLeftPrimaryLeft:
                case CornerPosition.TopFrontLeftPrimaryTop:
                case CornerPosition.TopFrontLeftPrimaryFront:
                case CornerPosition.TopFrontLeftPrimaryLeft:
                case CornerPosition.BottomBackLeftPrimaryBottom:
                case CornerPosition.BottomBackLeftPrimaryBack:
                case CornerPosition.BottomBackLeftPrimaryLeft:
                case CornerPosition.BottomFrontLeftPrimaryBottom:
                case CornerPosition.BottomFrontLeftPrimaryFront:
                case CornerPosition.BottomFrontLeftPrimaryLeft:
                case CornerPosition.Masked:
                case CornerPosition.Unmasked:
                    return cornerPosition;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static byte RotateRightHalf(byte cornerPosition)
        {
            switch (cornerPosition)
            {
                case CornerPosition.TopBackRightPrimaryTop:
                    return CornerPosition.BottomFrontRightPrimaryBottom;
                case CornerPosition.TopBackRightPrimaryBack:
                    return CornerPosition.BottomFrontRightPrimaryFront;
                case CornerPosition.TopBackRightPrimaryRight:
                    return CornerPosition.BottomFrontRightPrimaryRight;
                case CornerPosition.TopFrontRightPrimaryTop:
                    return CornerPosition.BottomBackRightPrimaryBottom;
                case CornerPosition.TopFrontRightPrimaryFront:
                    return CornerPosition.BottomBackRightPrimaryBack;
                case CornerPosition.TopFrontRightPrimaryRight:
                    return CornerPosition.BottomBackRightPrimaryRight;
                case CornerPosition.BottomBackRightPrimaryBottom:
                    return CornerPosition.TopFrontRightPrimaryTop;
                case CornerPosition.BottomBackRightPrimaryBack:
                    return CornerPosition.TopFrontRightPrimaryFront;
                case CornerPosition.BottomBackRightPrimaryRight:
                    return CornerPosition.TopFrontRightPrimaryRight;
                case CornerPosition.BottomFrontRightPrimaryBottom:
                    return CornerPosition.TopBackRightPrimaryTop;
                case CornerPosition.BottomFrontRightPrimaryFront:
                    return CornerPosition.TopBackRightPrimaryBack;
                case CornerPosition.BottomFrontRightPrimaryRight:
                    return CornerPosition.TopBackRightPrimaryRight;
                case CornerPosition.TopBackLeftPrimaryTop:
                case CornerPosition.TopBackLeftPrimaryBack:
                case CornerPosition.TopBackLeftPrimaryLeft:
                case CornerPosition.TopFrontLeftPrimaryTop:
                case CornerPosition.TopFrontLeftPrimaryFront:
                case CornerPosition.TopFrontLeftPrimaryLeft:
                case CornerPosition.BottomBackLeftPrimaryBottom:
                case CornerPosition.BottomBackLeftPrimaryBack:
                case CornerPosition.BottomBackLeftPrimaryLeft:
                case CornerPosition.BottomFrontLeftPrimaryBottom:
                case CornerPosition.BottomFrontLeftPrimaryFront:
                case CornerPosition.BottomFrontLeftPrimaryLeft:
                case CornerPosition.Masked:
                case CornerPosition.Unmasked:
                    return cornerPosition;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static byte RotateFrontCW(byte cornerPosition)
        {
            switch (cornerPosition)
            {
                case CornerPosition.TopFrontRightPrimaryTop:
                    return CornerPosition.BottomFrontRightPrimaryRight;
                case CornerPosition.TopFrontRightPrimaryFront:
                    return CornerPosition.BottomFrontRightPrimaryFront;
                case CornerPosition.TopFrontRightPrimaryRight:
                    return CornerPosition.BottomFrontRightPrimaryBottom;
                case CornerPosition.TopFrontLeftPrimaryTop:
                    return CornerPosition.TopFrontRightPrimaryRight;
                case CornerPosition.TopFrontLeftPrimaryFront:
                    return CornerPosition.TopFrontRightPrimaryFront;
                case CornerPosition.TopFrontLeftPrimaryLeft:
                    return CornerPosition.TopFrontRightPrimaryTop;
                case CornerPosition.BottomFrontRightPrimaryBottom:
                    return CornerPosition.BottomFrontLeftPrimaryLeft;
                case CornerPosition.BottomFrontRightPrimaryFront:
                    return CornerPosition.BottomFrontLeftPrimaryFront;
                case CornerPosition.BottomFrontRightPrimaryRight:
                    return CornerPosition.BottomFrontLeftPrimaryBottom;
                case CornerPosition.BottomFrontLeftPrimaryBottom:
                    return CornerPosition.TopFrontLeftPrimaryLeft;
                case CornerPosition.BottomFrontLeftPrimaryFront:
                    return CornerPosition.TopFrontLeftPrimaryFront;
                case CornerPosition.BottomFrontLeftPrimaryLeft:
                    return CornerPosition.TopFrontLeftPrimaryTop;
                case CornerPosition.TopBackLeftPrimaryTop:
                case CornerPosition.TopBackLeftPrimaryBack:
                case CornerPosition.TopBackLeftPrimaryLeft:
                case CornerPosition.TopBackRightPrimaryTop:
                case CornerPosition.TopBackRightPrimaryBack:
                case CornerPosition.TopBackRightPrimaryRight:
                case CornerPosition.BottomBackLeftPrimaryBottom:
                case CornerPosition.BottomBackLeftPrimaryBack:
                case CornerPosition.BottomBackLeftPrimaryLeft:
                case CornerPosition.BottomBackRightPrimaryBottom:
                case CornerPosition.BottomBackRightPrimaryBack:
                case CornerPosition.BottomBackRightPrimaryRight:
                case CornerPosition.Masked:
                case CornerPosition.Unmasked:
                    return cornerPosition;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static byte RotateFrontCCW(byte cornerPosition)
        {
            switch (cornerPosition)
            {
                case CornerPosition.TopFrontRightPrimaryTop:
                    return CornerPosition.TopFrontLeftPrimaryLeft;
                case CornerPosition.TopFrontRightPrimaryFront:
                    return CornerPosition.TopFrontLeftPrimaryFront;
                case CornerPosition.TopFrontRightPrimaryRight:
                    return CornerPosition.TopFrontLeftPrimaryTop;
                case CornerPosition.TopFrontLeftPrimaryTop:
                    return CornerPosition.BottomFrontLeftPrimaryLeft;
                case CornerPosition.TopFrontLeftPrimaryFront:
                    return CornerPosition.BottomFrontLeftPrimaryFront;
                case CornerPosition.TopFrontLeftPrimaryLeft:
                    return CornerPosition.BottomFrontLeftPrimaryBottom;
                case CornerPosition.BottomFrontRightPrimaryBottom:
                    return CornerPosition.TopFrontRightPrimaryRight;
                case CornerPosition.BottomFrontRightPrimaryFront:
                    return CornerPosition.TopFrontRightPrimaryFront;
                case CornerPosition.BottomFrontRightPrimaryRight:
                    return CornerPosition.TopFrontRightPrimaryTop;
                case CornerPosition.BottomFrontLeftPrimaryBottom:
                    return CornerPosition.BottomFrontRightPrimaryRight;
                case CornerPosition.BottomFrontLeftPrimaryFront:
                    return CornerPosition.BottomFrontRightPrimaryFront;
                case CornerPosition.BottomFrontLeftPrimaryLeft:
                    return CornerPosition.BottomFrontRightPrimaryBottom;
                case CornerPosition.TopBackLeftPrimaryTop:
                case CornerPosition.TopBackLeftPrimaryBack:
                case CornerPosition.TopBackLeftPrimaryLeft:
                case CornerPosition.TopBackRightPrimaryTop:
                case CornerPosition.TopBackRightPrimaryBack:
                case CornerPosition.TopBackRightPrimaryRight:
                case CornerPosition.BottomBackLeftPrimaryBottom:
                case CornerPosition.BottomBackLeftPrimaryBack:
                case CornerPosition.BottomBackLeftPrimaryLeft:
                case CornerPosition.BottomBackRightPrimaryBottom:
                case CornerPosition.BottomBackRightPrimaryBack:
                case CornerPosition.BottomBackRightPrimaryRight:
                case CornerPosition.Masked:
                case CornerPosition.Unmasked:
                    return cornerPosition;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static byte RotateFrontHalf(byte cornerPosition)
        {
            switch (cornerPosition)
            {
                case CornerPosition.TopFrontRightPrimaryTop:
                    return CornerPosition.BottomFrontLeftPrimaryBottom;
                case CornerPosition.TopFrontRightPrimaryFront:
                    return CornerPosition.BottomFrontLeftPrimaryFront;
                case CornerPosition.TopFrontRightPrimaryRight:
                    return CornerPosition.BottomFrontLeftPrimaryLeft;
                case CornerPosition.TopFrontLeftPrimaryTop:
                    return CornerPosition.BottomFrontRightPrimaryBottom;
                case CornerPosition.TopFrontLeftPrimaryFront:
                    return CornerPosition.BottomFrontRightPrimaryFront;
                case CornerPosition.TopFrontLeftPrimaryLeft:
                    return CornerPosition.BottomFrontRightPrimaryRight;
                case CornerPosition.BottomFrontRightPrimaryBottom:
                    return CornerPosition.TopFrontLeftPrimaryTop;
                case CornerPosition.BottomFrontRightPrimaryFront:
                    return CornerPosition.TopFrontLeftPrimaryFront;
                case CornerPosition.BottomFrontRightPrimaryRight:
                    return CornerPosition.TopFrontLeftPrimaryLeft;
                case CornerPosition.BottomFrontLeftPrimaryBottom:
                    return CornerPosition.TopFrontRightPrimaryTop;
                case CornerPosition.BottomFrontLeftPrimaryFront:
                    return CornerPosition.TopFrontRightPrimaryFront;
                case CornerPosition.BottomFrontLeftPrimaryLeft:
                    return CornerPosition.TopFrontRightPrimaryRight;
                case CornerPosition.TopBackLeftPrimaryTop:
                case CornerPosition.TopBackLeftPrimaryBack:
                case CornerPosition.TopBackLeftPrimaryLeft:
                case CornerPosition.TopBackRightPrimaryTop:
                case CornerPosition.TopBackRightPrimaryBack:
                case CornerPosition.TopBackRightPrimaryRight:
                case CornerPosition.BottomBackLeftPrimaryBottom:
                case CornerPosition.BottomBackLeftPrimaryBack:
                case CornerPosition.BottomBackLeftPrimaryLeft:
                case CornerPosition.BottomBackRightPrimaryBottom:
                case CornerPosition.BottomBackRightPrimaryBack:
                case CornerPosition.BottomBackRightPrimaryRight:
                case CornerPosition.Masked:
                case CornerPosition.Unmasked:
                    return cornerPosition;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static byte RotateBackCW(byte cornerPosition)
        {
            switch (cornerPosition)
            {
                case CornerPosition.TopFrontRightPrimaryTop:
                case CornerPosition.TopFrontRightPrimaryFront:
                case CornerPosition.TopFrontRightPrimaryRight:
                case CornerPosition.TopFrontLeftPrimaryTop:
                case CornerPosition.TopFrontLeftPrimaryFront:
                case CornerPosition.TopFrontLeftPrimaryLeft:
                case CornerPosition.BottomFrontRightPrimaryBottom:
                case CornerPosition.BottomFrontRightPrimaryFront:
                case CornerPosition.BottomFrontRightPrimaryRight:
                case CornerPosition.BottomFrontLeftPrimaryBottom:
                case CornerPosition.BottomFrontLeftPrimaryFront:
                case CornerPosition.BottomFrontLeftPrimaryLeft:
                case CornerPosition.Masked:
                case CornerPosition.Unmasked:
                    return cornerPosition;
                case CornerPosition.TopBackLeftPrimaryTop:
                    return CornerPosition.BottomBackLeftPrimaryLeft;
                case CornerPosition.TopBackLeftPrimaryBack:
                    return CornerPosition.BottomBackLeftPrimaryBack;
                case CornerPosition.TopBackLeftPrimaryLeft:
                    return CornerPosition.BottomBackLeftPrimaryBottom;
                case CornerPosition.TopBackRightPrimaryTop:
                    return CornerPosition.TopBackLeftPrimaryLeft;
                case CornerPosition.TopBackRightPrimaryBack:
                    return CornerPosition.TopBackLeftPrimaryBack;
                case CornerPosition.TopBackRightPrimaryRight:
                    return CornerPosition.TopBackLeftPrimaryTop;
                case CornerPosition.BottomBackLeftPrimaryBottom:
                    return CornerPosition.BottomBackRightPrimaryRight;
                case CornerPosition.BottomBackLeftPrimaryBack:
                    return CornerPosition.BottomBackRightPrimaryBack;
                case CornerPosition.BottomBackLeftPrimaryLeft:
                    return CornerPosition.BottomBackRightPrimaryBottom;
                case CornerPosition.BottomBackRightPrimaryBottom:
                    return CornerPosition.TopBackRightPrimaryRight;
                case CornerPosition.BottomBackRightPrimaryBack:
                    return CornerPosition.TopBackRightPrimaryBack;
                case CornerPosition.BottomBackRightPrimaryRight:
                    return CornerPosition.TopBackRightPrimaryTop;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        public static byte RotateBackCCW(byte cornerPosition)
        {
            switch (cornerPosition)
            {
                case CornerPosition.TopFrontRightPrimaryTop:
                case CornerPosition.TopFrontRightPrimaryFront:
                case CornerPosition.TopFrontRightPrimaryRight:
                case CornerPosition.TopFrontLeftPrimaryTop:
                case CornerPosition.TopFrontLeftPrimaryFront:
                case CornerPosition.TopFrontLeftPrimaryLeft:
                case CornerPosition.BottomFrontRightPrimaryBottom:
                case CornerPosition.BottomFrontRightPrimaryFront:
                case CornerPosition.BottomFrontRightPrimaryRight:
                case CornerPosition.BottomFrontLeftPrimaryBottom:
                case CornerPosition.BottomFrontLeftPrimaryFront:
                case CornerPosition.BottomFrontLeftPrimaryLeft:
                case CornerPosition.Masked:
                case CornerPosition.Unmasked:
                    return cornerPosition;
                case CornerPosition.TopBackLeftPrimaryTop:
                    return CornerPosition.TopBackRightPrimaryRight;
                case CornerPosition.TopBackLeftPrimaryBack:
                    return CornerPosition.TopBackRightPrimaryBack;
                case CornerPosition.TopBackLeftPrimaryLeft:
                    return CornerPosition.TopBackRightPrimaryTop;
                case CornerPosition.TopBackRightPrimaryTop:
                    return CornerPosition.BottomBackRightPrimaryRight;
                case CornerPosition.TopBackRightPrimaryBack:
                    return CornerPosition.BottomBackRightPrimaryBack;
                case CornerPosition.TopBackRightPrimaryRight:
                    return CornerPosition.BottomBackRightPrimaryBottom;
                case CornerPosition.BottomBackLeftPrimaryBottom:
                    return CornerPosition.TopBackLeftPrimaryLeft;
                case CornerPosition.BottomBackLeftPrimaryBack:
                    return CornerPosition.TopBackLeftPrimaryBack;
                case CornerPosition.BottomBackLeftPrimaryLeft:
                    return CornerPosition.TopBackLeftPrimaryTop;
                case CornerPosition.BottomBackRightPrimaryBottom:
                    return CornerPosition.BottomBackLeftPrimaryLeft;
                case CornerPosition.BottomBackRightPrimaryBack:
                    return CornerPosition.BottomBackLeftPrimaryBack;
                case CornerPosition.BottomBackRightPrimaryRight:
                    return CornerPosition.BottomBackLeftPrimaryBottom;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        public static byte RotateBackHalf(byte cornerPosition)
        {
            switch (cornerPosition)
            {
                case CornerPosition.TopFrontRightPrimaryTop:
                case CornerPosition.TopFrontRightPrimaryFront:
                case CornerPosition.TopFrontRightPrimaryRight:
                case CornerPosition.TopFrontLeftPrimaryTop:
                case CornerPosition.TopFrontLeftPrimaryFront:
                case CornerPosition.TopFrontLeftPrimaryLeft:
                case CornerPosition.BottomFrontRightPrimaryBottom:
                case CornerPosition.BottomFrontRightPrimaryFront:
                case CornerPosition.BottomFrontRightPrimaryRight:
                case CornerPosition.BottomFrontLeftPrimaryBottom:
                case CornerPosition.BottomFrontLeftPrimaryFront:
                case CornerPosition.BottomFrontLeftPrimaryLeft:
                case CornerPosition.Masked:
                case CornerPosition.Unmasked:
                    return cornerPosition;
                case CornerPosition.TopBackLeftPrimaryTop:
                    return CornerPosition.BottomBackRightPrimaryBottom;
                case CornerPosition.TopBackLeftPrimaryBack:
                    return CornerPosition.BottomBackRightPrimaryBack;
                case CornerPosition.TopBackLeftPrimaryLeft:
                    return CornerPosition.BottomBackRightPrimaryRight;
                case CornerPosition.TopBackRightPrimaryTop:
                    return CornerPosition.BottomBackLeftPrimaryBottom;
                case CornerPosition.TopBackRightPrimaryBack:
                    return CornerPosition.BottomBackLeftPrimaryBack;
                case CornerPosition.TopBackRightPrimaryRight:
                    return CornerPosition.BottomBackLeftPrimaryLeft;
                case CornerPosition.BottomBackLeftPrimaryBottom:
                    return CornerPosition.TopBackRightPrimaryTop;
                case CornerPosition.BottomBackLeftPrimaryBack:
                    return CornerPosition.TopBackRightPrimaryBack;
                case CornerPosition.BottomBackLeftPrimaryLeft:
                    return CornerPosition.TopBackRightPrimaryRight;
                case CornerPosition.BottomBackRightPrimaryBottom:
                    return CornerPosition.TopBackLeftPrimaryTop;
                case CornerPosition.BottomBackRightPrimaryBack:
                    return CornerPosition.TopBackLeftPrimaryBack;
                case CornerPosition.BottomBackRightPrimaryRight:
                    return CornerPosition.TopBackLeftPrimaryLeft;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static byte Mask(byte corner, byte mask)
        {
            switch (mask)
            {
                case CornerPosition.Masked:
                    return CornerPosition.Masked;
                case CornerPosition.Unmasked:
                    return corner;
                default:
                    throw new ArgumentException("Invalid mask.");
            }
        }
    }
}
