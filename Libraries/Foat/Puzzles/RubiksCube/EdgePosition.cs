namespace Foat.Puzzles.RubiksCube
{
    using System;

    internal struct EdgePosition
    {
        internal const byte TopFrontPrimaryTop = 0;
        internal const byte TopFrontPrimaryFront = 1;
        internal const byte TopLeftPrimaryTop = 2;
        internal const byte TopLeftPrimaryLeft = 3;
        internal const byte TopBackPrimaryTop = 4;
        internal const byte TopBackPrimaryBack = 5;
        internal const byte TopRightPrimaryTop = 6;
        internal const byte TopRightPrimaryRight = 7;
        internal const byte BottomFrontPrimaryBottom = 8;
        internal const byte BottomFrontPrimaryFront = 9;
        internal const byte BottomLeftPrimaryBottom = 10;
        internal const byte BottomLeftPrimaryLeft = 11;
        internal const byte BottomBackPrimaryBottom = 12;
        internal const byte BottomBackPrimaryBack = 13;
        internal const byte BottomRightPrimaryBottom = 14;
        internal const byte BottomRightPrimaryRight = 15;
        internal const byte FrontLeftPrimaryFront = 16;
        internal const byte FrontLeftPrimaryLeft = 17;
        internal const byte BackLeftPrimaryBack = 18;
        internal const byte BackLeftPrimaryLeft = 19;
        internal const byte BackRightPrimaryBack = 20;
        internal const byte BackRightPrimaryRight = 21;
        internal const byte FrontRightPrimaryFront = 22;
        internal const byte FrontRightPrimaryRight = 23;
        internal const byte Unmasked = 24;
        internal const byte Masked = 25;

        public static byte RotateTopCW(byte edgePosition)
        {
            switch (edgePosition)
            {
                case EdgePosition.TopFrontPrimaryTop:
                    return EdgePosition.TopLeftPrimaryTop;
                case EdgePosition.TopFrontPrimaryFront:
                    return EdgePosition.TopLeftPrimaryLeft;
                case EdgePosition.TopLeftPrimaryTop:
                    return EdgePosition.TopBackPrimaryTop;
                case EdgePosition.TopLeftPrimaryLeft:
                    return EdgePosition.TopBackPrimaryBack;
                case EdgePosition.TopBackPrimaryTop:
                    return EdgePosition.TopRightPrimaryTop;
                case EdgePosition.TopBackPrimaryBack:
                    return EdgePosition.TopRightPrimaryRight;
                case EdgePosition.TopRightPrimaryTop:
                    return EdgePosition.TopFrontPrimaryTop;
                case EdgePosition.TopRightPrimaryRight:
                    return EdgePosition.TopFrontPrimaryFront;
                default:
                    return edgePosition;
            }
        }

        public static byte RotateTopCCW(byte edgePosition)
        {
            switch (edgePosition)
            {
                case EdgePosition.TopFrontPrimaryTop:
                    return EdgePosition.TopRightPrimaryTop;
                case EdgePosition.TopFrontPrimaryFront:
                    return EdgePosition.TopRightPrimaryRight;
                case EdgePosition.TopLeftPrimaryTop:
                    return EdgePosition.TopFrontPrimaryTop;
                case EdgePosition.TopLeftPrimaryLeft:
                    return EdgePosition.TopFrontPrimaryFront;
                case EdgePosition.TopBackPrimaryTop:
                    return EdgePosition.TopLeftPrimaryTop;
                case EdgePosition.TopBackPrimaryBack:
                    return EdgePosition.TopLeftPrimaryLeft;
                case EdgePosition.TopRightPrimaryTop:
                    return EdgePosition.TopBackPrimaryTop;
                case EdgePosition.TopRightPrimaryRight:
                    return EdgePosition.TopBackPrimaryBack;
                default:
                    return edgePosition;
            }
        }

        public static byte RotateTopHalf(byte edgePosition)
        {
            switch (edgePosition)
            {
                case EdgePosition.TopFrontPrimaryTop:
                    return EdgePosition.TopBackPrimaryTop;
                case EdgePosition.TopFrontPrimaryFront:
                    return EdgePosition.TopBackPrimaryBack;
                case EdgePosition.TopLeftPrimaryTop:
                    return EdgePosition.TopRightPrimaryTop;
                case EdgePosition.TopLeftPrimaryLeft:
                    return EdgePosition.TopRightPrimaryRight;
                case EdgePosition.TopBackPrimaryTop:
                    return EdgePosition.TopFrontPrimaryTop;
                case EdgePosition.TopBackPrimaryBack:
                    return EdgePosition.TopFrontPrimaryFront;
                case EdgePosition.TopRightPrimaryTop:
                    return EdgePosition.TopLeftPrimaryTop;
                case EdgePosition.TopRightPrimaryRight:
                    return EdgePosition.TopLeftPrimaryLeft;
                default:
                    return edgePosition;
            }
        }
        public static byte RotateBottomCW(byte edgePosition)
        {
            switch (edgePosition)
            {
                case EdgePosition.BottomFrontPrimaryBottom:
                    return EdgePosition.BottomRightPrimaryBottom;
                case EdgePosition.BottomFrontPrimaryFront:
                    return EdgePosition.BottomRightPrimaryRight;
                case EdgePosition.BottomLeftPrimaryBottom:
                    return EdgePosition.BottomFrontPrimaryBottom;
                case EdgePosition.BottomLeftPrimaryLeft:
                    return EdgePosition.BottomFrontPrimaryFront;
                case EdgePosition.BottomBackPrimaryBottom:
                    return EdgePosition.BottomLeftPrimaryBottom;
                case EdgePosition.BottomBackPrimaryBack:
                    return EdgePosition.BottomLeftPrimaryLeft;
                case EdgePosition.BottomRightPrimaryBottom:
                    return EdgePosition.BottomBackPrimaryBottom;
                case EdgePosition.BottomRightPrimaryRight:
                    return EdgePosition.BottomBackPrimaryBack;
                default:
                    return edgePosition;
            }
        }

        public static byte RotateBottomCCW(byte edgePosition)
        {
            switch (edgePosition)
            {
                case EdgePosition.BottomFrontPrimaryBottom:
                    return EdgePosition.BottomLeftPrimaryBottom;
                case EdgePosition.BottomFrontPrimaryFront:
                    return EdgePosition.BottomLeftPrimaryLeft;
                case EdgePosition.BottomLeftPrimaryBottom:
                    return EdgePosition.BottomBackPrimaryBottom;
                case EdgePosition.BottomLeftPrimaryLeft:
                    return EdgePosition.BottomBackPrimaryBack;
                case EdgePosition.BottomBackPrimaryBottom:
                    return EdgePosition.BottomRightPrimaryBottom;
                case EdgePosition.BottomBackPrimaryBack:
                    return EdgePosition.BottomRightPrimaryRight;
                case EdgePosition.BottomRightPrimaryBottom:
                    return EdgePosition.BottomFrontPrimaryBottom;
                case EdgePosition.BottomRightPrimaryRight:
                    return EdgePosition.BottomFrontPrimaryFront;
                default:
                    return edgePosition;
            }
        }

        public static byte RotateBottomHalf(byte edgePosition)
        {
            switch (edgePosition)
            {
                case EdgePosition.BottomFrontPrimaryBottom:
                    return EdgePosition.BottomBackPrimaryBottom;
                case EdgePosition.BottomFrontPrimaryFront:
                    return EdgePosition.BottomBackPrimaryBack;
                case EdgePosition.BottomLeftPrimaryBottom:
                    return EdgePosition.BottomRightPrimaryBottom;
                case EdgePosition.BottomLeftPrimaryLeft:
                    return EdgePosition.BottomRightPrimaryRight;
                case EdgePosition.BottomBackPrimaryBottom:
                    return EdgePosition.BottomFrontPrimaryBottom;
                case EdgePosition.BottomBackPrimaryBack:
                    return EdgePosition.BottomFrontPrimaryFront;
                case EdgePosition.BottomRightPrimaryBottom:
                    return EdgePosition.BottomLeftPrimaryBottom;
                case EdgePosition.BottomRightPrimaryRight:
                    return EdgePosition.BottomLeftPrimaryLeft;
                default:
                    return edgePosition;
            }
        }


        public static byte RotateLeftCW(byte edgePosition)
        {
            switch (edgePosition)
            {
                case EdgePosition.TopLeftPrimaryTop:
                    return EdgePosition.FrontLeftPrimaryFront;
                case EdgePosition.TopLeftPrimaryLeft:
                    return EdgePosition.FrontLeftPrimaryLeft;
                case EdgePosition.BottomLeftPrimaryBottom:
                    return EdgePosition.BackLeftPrimaryBack;
                case EdgePosition.BottomLeftPrimaryLeft:
                    return EdgePosition.BackLeftPrimaryLeft;
                case EdgePosition.FrontLeftPrimaryFront:
                    return EdgePosition.BottomLeftPrimaryBottom;
                case EdgePosition.FrontLeftPrimaryLeft:
                    return EdgePosition.BottomLeftPrimaryLeft;
                case EdgePosition.BackLeftPrimaryBack:
                    return EdgePosition.TopLeftPrimaryTop;
                case EdgePosition.BackLeftPrimaryLeft:
                    return EdgePosition.TopLeftPrimaryLeft;
                default:
                    return edgePosition;
            }
        }

        public static byte RotateLeftCCW(byte edgePosition)
        {
            switch (edgePosition)
            {
                case EdgePosition.TopLeftPrimaryTop:
                    return EdgePosition.BackLeftPrimaryBack;
                case EdgePosition.TopLeftPrimaryLeft:
                    return EdgePosition.BackLeftPrimaryLeft;
                case EdgePosition.BottomLeftPrimaryBottom:
                    return EdgePosition.FrontLeftPrimaryFront;
                case EdgePosition.BottomLeftPrimaryLeft:
                    return EdgePosition.FrontLeftPrimaryLeft;
                case EdgePosition.FrontLeftPrimaryFront:
                    return EdgePosition.TopLeftPrimaryTop;
                case EdgePosition.FrontLeftPrimaryLeft:
                    return EdgePosition.TopLeftPrimaryLeft;
                case EdgePosition.BackLeftPrimaryBack:
                    return EdgePosition.BottomLeftPrimaryBottom;
                case EdgePosition.BackLeftPrimaryLeft:
                    return EdgePosition.BottomLeftPrimaryLeft;
                default:
                    return edgePosition;
            }
        }

        public static byte RotateLeftHalf(byte edgePosition)
        {
            switch (edgePosition)
            {
                case EdgePosition.TopLeftPrimaryTop:
                    return EdgePosition.BottomLeftPrimaryBottom;
                case EdgePosition.TopLeftPrimaryLeft:
                    return EdgePosition.BottomLeftPrimaryLeft;
                case EdgePosition.BottomLeftPrimaryBottom:
                    return EdgePosition.TopLeftPrimaryTop;
                case EdgePosition.BottomLeftPrimaryLeft:
                    return EdgePosition.TopLeftPrimaryLeft;
                case EdgePosition.FrontLeftPrimaryFront:
                    return EdgePosition.BackLeftPrimaryBack;
                case EdgePosition.FrontLeftPrimaryLeft:
                    return EdgePosition.BackLeftPrimaryLeft;
                case EdgePosition.BackLeftPrimaryBack:
                    return EdgePosition.FrontLeftPrimaryFront;
                case EdgePosition.BackLeftPrimaryLeft:
                    return EdgePosition.FrontLeftPrimaryLeft;
                default:
                    return edgePosition;
            }
        }

        public static byte RotateRightCW(byte edgePosition)
        {
            switch (edgePosition)
            {
                case EdgePosition.TopRightPrimaryTop:
                    return EdgePosition.BackRightPrimaryBack;
                case EdgePosition.TopRightPrimaryRight:
                    return EdgePosition.BackRightPrimaryRight;
                case EdgePosition.BottomRightPrimaryBottom:
                    return EdgePosition.FrontRightPrimaryFront;
                case EdgePosition.BottomRightPrimaryRight:
                    return EdgePosition.FrontRightPrimaryRight;
                case EdgePosition.BackRightPrimaryBack:
                    return EdgePosition.BottomRightPrimaryBottom;
                case EdgePosition.BackRightPrimaryRight:
                    return EdgePosition.BottomRightPrimaryRight;
                case EdgePosition.FrontRightPrimaryFront:
                    return EdgePosition.TopRightPrimaryTop;
                case EdgePosition.FrontRightPrimaryRight:
                    return EdgePosition.TopRightPrimaryRight;
                default:
                    return edgePosition;
            }
        }

        public static byte RotateRightCCW(byte edgePosition)
        {
            switch (edgePosition)
            {
                case EdgePosition.TopRightPrimaryTop:
                    return EdgePosition.FrontRightPrimaryFront;
                case EdgePosition.TopRightPrimaryRight:
                    return EdgePosition.FrontRightPrimaryRight;
                case EdgePosition.BottomRightPrimaryBottom:
                    return EdgePosition.BackRightPrimaryBack;
                case EdgePosition.BottomRightPrimaryRight:
                    return EdgePosition.BackRightPrimaryRight;
                case EdgePosition.BackRightPrimaryBack:
                    return EdgePosition.TopRightPrimaryTop;
                case EdgePosition.BackRightPrimaryRight:
                    return EdgePosition.TopRightPrimaryRight;
                case EdgePosition.FrontRightPrimaryFront:
                    return EdgePosition.BottomRightPrimaryBottom;
                case EdgePosition.FrontRightPrimaryRight:
                    return EdgePosition.BottomRightPrimaryRight;
                default:
                    return edgePosition;
            }
        }

        public static byte RotateRightHalf(byte edgePosition)
        {
            switch (edgePosition)
            {
                case EdgePosition.TopRightPrimaryTop:
                    return EdgePosition.BottomRightPrimaryBottom;
                case EdgePosition.TopRightPrimaryRight:
                    return EdgePosition.BottomRightPrimaryRight;
                case EdgePosition.BottomRightPrimaryBottom:
                    return EdgePosition.TopRightPrimaryTop;
                case EdgePosition.BottomRightPrimaryRight:
                    return EdgePosition.TopRightPrimaryRight;
                case EdgePosition.BackRightPrimaryBack:
                    return EdgePosition.FrontRightPrimaryFront;
                case EdgePosition.BackRightPrimaryRight:
                    return EdgePosition.FrontRightPrimaryRight;
                case EdgePosition.FrontRightPrimaryFront:
                    return EdgePosition.BackRightPrimaryBack;
                case EdgePosition.FrontRightPrimaryRight:
                    return EdgePosition.BackRightPrimaryRight;
                default:
                    return edgePosition;
            }
        }

        public static byte RotateFrontCW(byte edgePosition)
        {
            switch (edgePosition)
            {
                case EdgePosition.TopFrontPrimaryTop:
                    return EdgePosition.FrontRightPrimaryRight;
                case EdgePosition.TopFrontPrimaryFront:
                    return EdgePosition.FrontRightPrimaryFront;
                case EdgePosition.BottomFrontPrimaryBottom:
                    return EdgePosition.FrontLeftPrimaryLeft;
                case EdgePosition.BottomFrontPrimaryFront:
                    return EdgePosition.FrontLeftPrimaryFront;
                case EdgePosition.FrontLeftPrimaryFront:
                    return EdgePosition.TopFrontPrimaryFront;
                case EdgePosition.FrontLeftPrimaryLeft:
                    return EdgePosition.TopFrontPrimaryTop;
                case EdgePosition.FrontRightPrimaryFront:
                    return EdgePosition.BottomFrontPrimaryFront;
                case EdgePosition.FrontRightPrimaryRight:
                    return EdgePosition.BottomFrontPrimaryBottom;
                default:
                    return edgePosition;
            }
        }

        public static byte RotateFrontCCW(byte edgePosition)
        {
            switch (edgePosition)
            {
                case EdgePosition.TopFrontPrimaryTop:
                    return EdgePosition.FrontLeftPrimaryLeft;
                case EdgePosition.TopFrontPrimaryFront:
                    return EdgePosition.FrontLeftPrimaryFront;
                case EdgePosition.BottomFrontPrimaryBottom:
                    return EdgePosition.FrontRightPrimaryRight;
                case EdgePosition.BottomFrontPrimaryFront:
                    return EdgePosition.FrontRightPrimaryFront;
                case EdgePosition.FrontLeftPrimaryFront:
                    return EdgePosition.BottomFrontPrimaryFront;
                case EdgePosition.FrontLeftPrimaryLeft:
                    return EdgePosition.BottomFrontPrimaryBottom;
                case EdgePosition.FrontRightPrimaryFront:
                    return EdgePosition.TopFrontPrimaryFront;
                case EdgePosition.FrontRightPrimaryRight:
                    return EdgePosition.TopFrontPrimaryTop;
                default:
                    return edgePosition;
            }
        }

        public static byte RotateFrontHalf(byte edgePosition)
        {
            switch (edgePosition)
            {
                case EdgePosition.TopFrontPrimaryTop:
                    return EdgePosition.BottomFrontPrimaryBottom;
                case EdgePosition.TopFrontPrimaryFront:
                    return EdgePosition.BottomFrontPrimaryFront;
                case EdgePosition.BottomFrontPrimaryBottom:
                    return EdgePosition.TopFrontPrimaryTop;
                case EdgePosition.BottomFrontPrimaryFront:
                    return EdgePosition.TopFrontPrimaryFront;
                case EdgePosition.FrontLeftPrimaryFront:
                    return EdgePosition.FrontRightPrimaryFront;
                case EdgePosition.FrontLeftPrimaryLeft:
                    return EdgePosition.FrontRightPrimaryRight;
                case EdgePosition.FrontRightPrimaryFront:
                    return EdgePosition.FrontLeftPrimaryFront;
                case EdgePosition.FrontRightPrimaryRight:
                    return EdgePosition.FrontLeftPrimaryLeft;
                default:
                    return edgePosition;
            }
        }


        public static byte RotateBackCW(byte edgePosition)
        {
            switch (edgePosition)
            {
                case EdgePosition.TopBackPrimaryTop:
                    return EdgePosition.BackLeftPrimaryLeft;
                case EdgePosition.TopBackPrimaryBack:
                    return EdgePosition.BackLeftPrimaryBack;
                case EdgePosition.BottomBackPrimaryBottom:
                    return EdgePosition.BackRightPrimaryRight;
                case EdgePosition.BottomBackPrimaryBack:
                    return EdgePosition.BackRightPrimaryBack;
                case EdgePosition.BackLeftPrimaryBack:
                    return EdgePosition.BottomBackPrimaryBack;
                case EdgePosition.BackLeftPrimaryLeft:
                    return EdgePosition.BottomBackPrimaryBottom;
                case EdgePosition.BackRightPrimaryBack:
                    return EdgePosition.TopBackPrimaryBack;
                case EdgePosition.BackRightPrimaryRight:
                    return EdgePosition.TopBackPrimaryTop;
                default:
                    return edgePosition;
            }
        }

        public static byte RotateBackCCW(byte edgePosition)
        {
            switch (edgePosition)
            {
                case EdgePosition.TopBackPrimaryTop:
                    return EdgePosition.BackRightPrimaryRight;
                case EdgePosition.TopBackPrimaryBack:
                    return EdgePosition.BackRightPrimaryBack;
                case EdgePosition.BottomBackPrimaryBottom:
                    return EdgePosition.BackLeftPrimaryLeft;
                case EdgePosition.BottomBackPrimaryBack:
                    return EdgePosition.BackLeftPrimaryBack;
                case EdgePosition.BackLeftPrimaryBack:
                    return EdgePosition.TopBackPrimaryBack;
                case EdgePosition.BackLeftPrimaryLeft:
                    return EdgePosition.TopBackPrimaryTop;
                case EdgePosition.BackRightPrimaryBack:
                    return EdgePosition.BottomBackPrimaryBack;
                case EdgePosition.BackRightPrimaryRight:
                    return EdgePosition.BottomBackPrimaryBottom;
                default:
                    return edgePosition;
            }
        }

        public static byte RotateBackHalf(byte edgePosition)
        {
            switch (edgePosition)
            {
                case EdgePosition.TopBackPrimaryTop:
                    return EdgePosition.BottomBackPrimaryBottom;
                case EdgePosition.TopBackPrimaryBack:
                    return EdgePosition.BottomBackPrimaryBack;
                case EdgePosition.BottomBackPrimaryBottom:
                    return EdgePosition.TopBackPrimaryTop;
                case EdgePosition.BottomBackPrimaryBack:
                    return EdgePosition.TopBackPrimaryBack;
                case EdgePosition.BackLeftPrimaryBack:
                    return EdgePosition.BackRightPrimaryBack;
                case EdgePosition.BackLeftPrimaryLeft:
                    return EdgePosition.BackRightPrimaryRight;
                case EdgePosition.BackRightPrimaryBack:
                    return EdgePosition.BackLeftPrimaryBack;
                case EdgePosition.BackRightPrimaryRight:
                    return EdgePosition.BackLeftPrimaryLeft;
                default:
                    return edgePosition;
            }
        }

        public static byte Mask(byte edge, byte mask)
        {
            switch (mask)
            {
                case EdgePosition.Masked:
                    return EdgePosition.Masked;
                case EdgePosition.Unmasked:
                    return edge;
                default:
                    throw new ArgumentException("Invalid mask.");
            }
        }
    }
}
