using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Foat.Puzzles.RubiksCube;

namespace Foat.Puzzles.Tests.RubiksCube
{
    [TestClass]
    public class EdgePositionTests
    {
        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_RotateTopCW_AllEdges()
        {
            Assert.AreEqual<byte>(Position.BackLeftPrimaryBack, Position.RotateTopCW(Position.BackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.BackLeftPrimaryLeft, Position.RotateTopCW(Position.BackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BackRightPrimaryBack, Position.RotateTopCW(Position.BackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.BackRightPrimaryRight, Position.RotateTopCW(Position.BackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBack, Position.RotateTopCW(Position.BottomBackPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBottom, Position.RotateTopCW(Position.BottomBackPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryBottom, Position.RotateTopCW(Position.BottomFrontPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryFront, Position.RotateTopCW(Position.BottomFrontPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryBottom, Position.RotateTopCW(Position.BottomLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryLeft, Position.RotateTopCW(Position.BottomLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomRightPrimaryBottom, Position.RotateTopCW(Position.BottomRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomRightPrimaryRight, Position.RotateTopCW(Position.BottomRightPrimaryRight));
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryFront, Position.RotateTopCW(Position.FrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryLeft, Position.RotateTopCW(Position.FrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.FrontRightPrimaryFront, Position.RotateTopCW(Position.FrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.FrontRightPrimaryRight, Position.RotateTopCW(Position.FrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopRightPrimaryRight, Position.RotateTopCW(Position.TopBackPrimaryBack));
            Assert.AreEqual<byte>(Position.TopRightPrimaryTop, Position.RotateTopCW(Position.TopBackPrimaryTop));
            Assert.AreEqual<byte>(Position.TopLeftPrimaryLeft, Position.RotateTopCW(Position.TopFrontPrimaryFront));
            Assert.AreEqual<byte>(Position.TopLeftPrimaryTop, Position.RotateTopCW(Position.TopFrontPrimaryTop));
            Assert.AreEqual<byte>(Position.TopBackPrimaryBack, Position.RotateTopCW(Position.TopLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopBackPrimaryTop, Position.RotateTopCW(Position.TopLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontPrimaryFront, Position.RotateTopCW(Position.TopRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopFrontPrimaryTop, Position.RotateTopCW(Position.TopRightPrimaryTop));
            Assert.AreEqual<byte>(Position.Masked, Position.RotateTopCW(Position.Masked));
            Assert.AreEqual<byte>(Position.Unmasked, Position.RotateTopCW(Position.Unmasked));
        }
        
        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_RotateTopCCW_AllEdges()
        {
            Assert.AreEqual<byte>(Position.BackLeftPrimaryBack, Position.RotateTopCCW(Position.BackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.BackLeftPrimaryLeft, Position.RotateTopCCW(Position.BackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BackRightPrimaryBack, Position.RotateTopCCW(Position.BackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.BackRightPrimaryRight, Position.RotateTopCCW(Position.BackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBack, Position.RotateTopCCW(Position.BottomBackPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBottom, Position.RotateTopCCW(Position.BottomBackPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryBottom, Position.RotateTopCCW(Position.BottomFrontPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryFront, Position.RotateTopCCW(Position.BottomFrontPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryBottom, Position.RotateTopCCW(Position.BottomLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryLeft, Position.RotateTopCCW(Position.BottomLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomRightPrimaryBottom, Position.RotateTopCCW(Position.BottomRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomRightPrimaryRight, Position.RotateTopCCW(Position.BottomRightPrimaryRight));
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryFront, Position.RotateTopCCW(Position.FrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryLeft, Position.RotateTopCCW(Position.FrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.FrontRightPrimaryFront, Position.RotateTopCCW(Position.FrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.FrontRightPrimaryRight, Position.RotateTopCCW(Position.FrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopLeftPrimaryLeft, Position.RotateTopCCW(Position.TopBackPrimaryBack));
            Assert.AreEqual<byte>(Position.TopLeftPrimaryTop, Position.RotateTopCCW(Position.TopBackPrimaryTop));
            Assert.AreEqual<byte>(Position.TopRightPrimaryRight, Position.RotateTopCCW(Position.TopFrontPrimaryFront));
            Assert.AreEqual<byte>(Position.TopRightPrimaryTop, Position.RotateTopCCW(Position.TopFrontPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontPrimaryFront, Position.RotateTopCCW(Position.TopLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopFrontPrimaryTop, Position.RotateTopCCW(Position.TopLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopBackPrimaryBack, Position.RotateTopCCW(Position.TopRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackPrimaryTop, Position.RotateTopCCW(Position.TopRightPrimaryTop));
            Assert.AreEqual<byte>(Position.Masked, Position.RotateTopCCW(Position.Masked));
            Assert.AreEqual<byte>(Position.Unmasked, Position.RotateTopCCW(Position.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_RotateTopHalf_AllEdges()
        {
            Assert.AreEqual<byte>(Position.BackLeftPrimaryBack, Position.RotateTopHalf(Position.BackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.BackLeftPrimaryLeft, Position.RotateTopHalf(Position.BackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BackRightPrimaryBack, Position.RotateTopHalf(Position.BackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.BackRightPrimaryRight, Position.RotateTopHalf(Position.BackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBack, Position.RotateTopHalf(Position.BottomBackPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBottom, Position.RotateTopHalf(Position.BottomBackPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryBottom, Position.RotateTopHalf(Position.BottomFrontPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryFront, Position.RotateTopHalf(Position.BottomFrontPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryBottom, Position.RotateTopHalf(Position.BottomLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryLeft, Position.RotateTopHalf(Position.BottomLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomRightPrimaryBottom, Position.RotateTopHalf(Position.BottomRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomRightPrimaryRight, Position.RotateTopHalf(Position.BottomRightPrimaryRight));
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryFront, Position.RotateTopHalf(Position.FrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryLeft, Position.RotateTopHalf(Position.FrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.FrontRightPrimaryFront, Position.RotateTopHalf(Position.FrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.FrontRightPrimaryRight, Position.RotateTopHalf(Position.FrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopFrontPrimaryFront, Position.RotateTopHalf(Position.TopBackPrimaryBack));
            Assert.AreEqual<byte>(Position.TopFrontPrimaryTop, Position.RotateTopHalf(Position.TopBackPrimaryTop));
            Assert.AreEqual<byte>(Position.TopBackPrimaryBack, Position.RotateTopHalf(Position.TopFrontPrimaryFront));
            Assert.AreEqual<byte>(Position.TopBackPrimaryTop, Position.RotateTopHalf(Position.TopFrontPrimaryTop));
            Assert.AreEqual<byte>(Position.TopRightPrimaryRight, Position.RotateTopHalf(Position.TopLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopRightPrimaryTop, Position.RotateTopHalf(Position.TopLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopLeftPrimaryLeft, Position.RotateTopHalf(Position.TopRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopLeftPrimaryTop, Position.RotateTopHalf(Position.TopRightPrimaryTop));
            Assert.AreEqual<byte>(Position.Masked, Position.RotateTopHalf(Position.Masked));
            Assert.AreEqual<byte>(Position.Unmasked, Position.RotateTopHalf(Position.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_RotateBottomCW_AllEdges()
        {
            Assert.AreEqual<byte>(Position.BackLeftPrimaryBack, Position.RotateBottomCW(Position.BackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.BackLeftPrimaryLeft, Position.RotateBottomCW(Position.BackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BackRightPrimaryBack, Position.RotateBottomCW(Position.BackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.BackRightPrimaryRight, Position.RotateBottomCW(Position.BackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryLeft, Position.RotateBottomCW(Position.BottomBackPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryBottom, Position.RotateBottomCW(Position.BottomBackPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomRightPrimaryBottom, Position.RotateBottomCW(Position.BottomFrontPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomRightPrimaryRight, Position.RotateBottomCW(Position.BottomFrontPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryBottom, Position.RotateBottomCW(Position.BottomLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryFront, Position.RotateBottomCW(Position.BottomLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBottom, Position.RotateBottomCW(Position.BottomRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBack, Position.RotateBottomCW(Position.BottomRightPrimaryRight));
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryFront, Position.RotateBottomCW(Position.FrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryLeft, Position.RotateBottomCW(Position.FrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.FrontRightPrimaryFront, Position.RotateBottomCW(Position.FrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.FrontRightPrimaryRight, Position.RotateBottomCW(Position.FrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackPrimaryBack, Position.RotateBottomCW(Position.TopBackPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackPrimaryTop, Position.RotateBottomCW(Position.TopBackPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontPrimaryFront, Position.RotateBottomCW(Position.TopFrontPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontPrimaryTop, Position.RotateBottomCW(Position.TopFrontPrimaryTop));
            Assert.AreEqual<byte>(Position.TopLeftPrimaryLeft, Position.RotateBottomCW(Position.TopLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopLeftPrimaryTop, Position.RotateBottomCW(Position.TopLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopRightPrimaryRight, Position.RotateBottomCW(Position.TopRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopRightPrimaryTop, Position.RotateBottomCW(Position.TopRightPrimaryTop));
            Assert.AreEqual<byte>(Position.Masked, Position.RotateBottomCW(Position.Masked));
            Assert.AreEqual<byte>(Position.Unmasked, Position.RotateBottomCW(Position.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_RotateBottomCCW_AllEdges()
        {
            Assert.AreEqual<byte>(Position.BackLeftPrimaryBack, Position.RotateBottomCCW(Position.BackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.BackLeftPrimaryLeft, Position.RotateBottomCCW(Position.BackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BackRightPrimaryBack, Position.RotateBottomCCW(Position.BackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.BackRightPrimaryRight, Position.RotateBottomCCW(Position.BackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomRightPrimaryRight, Position.RotateBottomCCW(Position.BottomBackPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomRightPrimaryBottom, Position.RotateBottomCCW(Position.BottomBackPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryBottom, Position.RotateBottomCCW(Position.BottomFrontPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryLeft, Position.RotateBottomCCW(Position.BottomFrontPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBottom, Position.RotateBottomCCW(Position.BottomLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBack, Position.RotateBottomCCW(Position.BottomLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryBottom, Position.RotateBottomCCW(Position.BottomRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryFront, Position.RotateBottomCCW(Position.BottomRightPrimaryRight));
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryFront, Position.RotateBottomCCW(Position.FrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryLeft, Position.RotateBottomCCW(Position.FrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.FrontRightPrimaryFront, Position.RotateBottomCCW(Position.FrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.FrontRightPrimaryRight, Position.RotateBottomCCW(Position.FrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackPrimaryBack, Position.RotateBottomCCW(Position.TopBackPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackPrimaryTop, Position.RotateBottomCCW(Position.TopBackPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontPrimaryFront, Position.RotateBottomCCW(Position.TopFrontPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontPrimaryTop, Position.RotateBottomCCW(Position.TopFrontPrimaryTop));
            Assert.AreEqual<byte>(Position.TopLeftPrimaryLeft, Position.RotateBottomCCW(Position.TopLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopLeftPrimaryTop, Position.RotateBottomCCW(Position.TopLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopRightPrimaryRight, Position.RotateBottomCCW(Position.TopRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopRightPrimaryTop, Position.RotateBottomCCW(Position.TopRightPrimaryTop));
            Assert.AreEqual<byte>(Position.Masked, Position.RotateBottomCCW(Position.Masked));
            Assert.AreEqual<byte>(Position.Unmasked, Position.RotateBottomCCW(Position.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_RotateBottomHalf_AllEdges()
        {
            Assert.AreEqual<byte>(Position.BackLeftPrimaryBack, Position.RotateBottomHalf(Position.BackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.BackLeftPrimaryLeft, Position.RotateBottomHalf(Position.BackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BackRightPrimaryBack, Position.RotateBottomHalf(Position.BackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.BackRightPrimaryRight, Position.RotateBottomHalf(Position.BackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryFront, Position.RotateBottomHalf(Position.BottomBackPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryBottom, Position.RotateBottomHalf(Position.BottomBackPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBottom, Position.RotateBottomHalf(Position.BottomFrontPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBack, Position.RotateBottomHalf(Position.BottomFrontPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomRightPrimaryBottom, Position.RotateBottomHalf(Position.BottomLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomRightPrimaryRight, Position.RotateBottomHalf(Position.BottomLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryBottom, Position.RotateBottomHalf(Position.BottomRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryLeft, Position.RotateBottomHalf(Position.BottomRightPrimaryRight));
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryFront, Position.RotateBottomHalf(Position.FrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryLeft, Position.RotateBottomHalf(Position.FrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.FrontRightPrimaryFront, Position.RotateBottomHalf(Position.FrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.FrontRightPrimaryRight, Position.RotateBottomHalf(Position.FrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackPrimaryBack, Position.RotateBottomHalf(Position.TopBackPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackPrimaryTop, Position.RotateBottomHalf(Position.TopBackPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontPrimaryFront, Position.RotateBottomHalf(Position.TopFrontPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontPrimaryTop, Position.RotateBottomHalf(Position.TopFrontPrimaryTop));
            Assert.AreEqual<byte>(Position.TopLeftPrimaryLeft, Position.RotateBottomHalf(Position.TopLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopLeftPrimaryTop, Position.RotateBottomHalf(Position.TopLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopRightPrimaryRight, Position.RotateBottomHalf(Position.TopRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopRightPrimaryTop, Position.RotateBottomHalf(Position.TopRightPrimaryTop));
            Assert.AreEqual<byte>(Position.Masked, Position.RotateBottomHalf(Position.Masked));
            Assert.AreEqual<byte>(Position.Unmasked, Position.RotateBottomHalf(Position.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_RotateLeftCW_AllEdges()
        {
            Assert.AreEqual<byte>(Position.TopLeftPrimaryTop, Position.RotateLeftCW(Position.BackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.TopLeftPrimaryLeft, Position.RotateLeftCW(Position.BackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BackRightPrimaryBack, Position.RotateLeftCW(Position.BackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.BackRightPrimaryRight, Position.RotateLeftCW(Position.BackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBack, Position.RotateLeftCW(Position.BottomBackPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBottom, Position.RotateLeftCW(Position.BottomBackPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryBottom, Position.RotateLeftCW(Position.BottomFrontPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryFront, Position.RotateLeftCW(Position.BottomFrontPrimaryFront));
            Assert.AreEqual<byte>(Position.BackLeftPrimaryBack, Position.RotateLeftCW(Position.BottomLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BackLeftPrimaryLeft, Position.RotateLeftCW(Position.BottomLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomRightPrimaryBottom, Position.RotateLeftCW(Position.BottomRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomRightPrimaryRight, Position.RotateLeftCW(Position.BottomRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryBottom, Position.RotateLeftCW(Position.FrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryLeft, Position.RotateLeftCW(Position.FrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.FrontRightPrimaryFront, Position.RotateLeftCW(Position.FrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.FrontRightPrimaryRight, Position.RotateLeftCW(Position.FrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackPrimaryBack, Position.RotateLeftCW(Position.TopBackPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackPrimaryTop, Position.RotateLeftCW(Position.TopBackPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontPrimaryFront, Position.RotateLeftCW(Position.TopFrontPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontPrimaryTop, Position.RotateLeftCW(Position.TopFrontPrimaryTop));
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryLeft, Position.RotateLeftCW(Position.TopLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryFront, Position.RotateLeftCW(Position.TopLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopRightPrimaryRight, Position.RotateLeftCW(Position.TopRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopRightPrimaryTop, Position.RotateLeftCW(Position.TopRightPrimaryTop));
            Assert.AreEqual<byte>(Position.Masked, Position.RotateLeftCW(Position.Masked));
            Assert.AreEqual<byte>(Position.Unmasked, Position.RotateLeftCW(Position.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_RotateLeftCCW_AllEdges()
        {
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryBottom, Position.RotateLeftCCW(Position.BackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryLeft, Position.RotateLeftCCW(Position.BackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BackRightPrimaryBack, Position.RotateLeftCCW(Position.BackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.BackRightPrimaryRight, Position.RotateLeftCCW(Position.BackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBack, Position.RotateLeftCCW(Position.BottomBackPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBottom, Position.RotateLeftCCW(Position.BottomBackPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryBottom, Position.RotateLeftCCW(Position.BottomFrontPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryFront, Position.RotateLeftCCW(Position.BottomFrontPrimaryFront));
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryFront, Position.RotateLeftCCW(Position.BottomLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryLeft, Position.RotateLeftCCW(Position.BottomLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomRightPrimaryBottom, Position.RotateLeftCCW(Position.BottomRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomRightPrimaryRight, Position.RotateLeftCCW(Position.BottomRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopLeftPrimaryTop, Position.RotateLeftCCW(Position.FrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.TopLeftPrimaryLeft, Position.RotateLeftCCW(Position.FrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.FrontRightPrimaryFront, Position.RotateLeftCCW(Position.FrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.FrontRightPrimaryRight, Position.RotateLeftCCW(Position.FrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackPrimaryBack, Position.RotateLeftCCW(Position.TopBackPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackPrimaryTop, Position.RotateLeftCCW(Position.TopBackPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontPrimaryFront, Position.RotateLeftCCW(Position.TopFrontPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontPrimaryTop, Position.RotateLeftCCW(Position.TopFrontPrimaryTop));
            Assert.AreEqual<byte>(Position.BackLeftPrimaryLeft, Position.RotateLeftCCW(Position.TopLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BackLeftPrimaryBack, Position.RotateLeftCCW(Position.TopLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopRightPrimaryRight, Position.RotateLeftCCW(Position.TopRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopRightPrimaryTop, Position.RotateLeftCCW(Position.TopRightPrimaryTop));
            Assert.AreEqual<byte>(Position.Masked, Position.RotateLeftCCW(Position.Masked));
            Assert.AreEqual<byte>(Position.Unmasked, Position.RotateLeftCCW(Position.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_RotateLeftHalf_AllEdges()
        {
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryFront, Position.RotateLeftHalf(Position.BackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryLeft, Position.RotateLeftHalf(Position.BackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BackRightPrimaryBack, Position.RotateLeftHalf(Position.BackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.BackRightPrimaryRight, Position.RotateLeftHalf(Position.BackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBack, Position.RotateLeftHalf(Position.BottomBackPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBottom, Position.RotateLeftHalf(Position.BottomBackPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryBottom, Position.RotateLeftHalf(Position.BottomFrontPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryFront, Position.RotateLeftHalf(Position.BottomFrontPrimaryFront));
            Assert.AreEqual<byte>(Position.TopLeftPrimaryTop, Position.RotateLeftHalf(Position.BottomLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.TopLeftPrimaryLeft, Position.RotateLeftHalf(Position.BottomLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomRightPrimaryBottom, Position.RotateLeftHalf(Position.BottomRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomRightPrimaryRight, Position.RotateLeftHalf(Position.BottomRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BackLeftPrimaryBack, Position.RotateLeftHalf(Position.FrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.BackLeftPrimaryLeft, Position.RotateLeftHalf(Position.FrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.FrontRightPrimaryFront, Position.RotateLeftHalf(Position.FrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.FrontRightPrimaryRight, Position.RotateLeftHalf(Position.FrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackPrimaryBack, Position.RotateLeftHalf(Position.TopBackPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackPrimaryTop, Position.RotateLeftHalf(Position.TopBackPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontPrimaryFront, Position.RotateLeftHalf(Position.TopFrontPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontPrimaryTop, Position.RotateLeftHalf(Position.TopFrontPrimaryTop));
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryLeft, Position.RotateLeftHalf(Position.TopLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryBottom, Position.RotateLeftHalf(Position.TopLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopRightPrimaryRight, Position.RotateLeftHalf(Position.TopRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopRightPrimaryTop, Position.RotateLeftHalf(Position.TopRightPrimaryTop));
            Assert.AreEqual<byte>(Position.Masked, Position.RotateLeftHalf(Position.Masked));
            Assert.AreEqual<byte>(Position.Unmasked, Position.RotateLeftHalf(Position.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_RotateRightCW_AllEdges()
        {
            Assert.AreEqual<byte>(Position.BackLeftPrimaryBack, Position.RotateRightCW(Position.BackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.BackLeftPrimaryLeft, Position.RotateRightCW(Position.BackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomRightPrimaryBottom, Position.RotateRightCW(Position.BackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomRightPrimaryRight, Position.RotateRightCW(Position.BackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBack, Position.RotateRightCW(Position.BottomBackPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBottom, Position.RotateRightCW(Position.BottomBackPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryBottom, Position.RotateRightCW(Position.BottomFrontPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryFront, Position.RotateRightCW(Position.BottomFrontPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryBottom, Position.RotateRightCW(Position.BottomLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryLeft, Position.RotateRightCW(Position.BottomLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.FrontRightPrimaryFront, Position.RotateRightCW(Position.BottomRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.FrontRightPrimaryRight, Position.RotateRightCW(Position.BottomRightPrimaryRight));
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryFront, Position.RotateRightCW(Position.FrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryLeft, Position.RotateRightCW(Position.FrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopRightPrimaryTop, Position.RotateRightCW(Position.FrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.TopRightPrimaryRight, Position.RotateRightCW(Position.FrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackPrimaryBack, Position.RotateRightCW(Position.TopBackPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackPrimaryTop, Position.RotateRightCW(Position.TopBackPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontPrimaryFront, Position.RotateRightCW(Position.TopFrontPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontPrimaryTop, Position.RotateRightCW(Position.TopFrontPrimaryTop));
            Assert.AreEqual<byte>(Position.TopLeftPrimaryLeft, Position.RotateRightCW(Position.TopLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopLeftPrimaryTop, Position.RotateRightCW(Position.TopLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.BackRightPrimaryRight, Position.RotateRightCW(Position.TopRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BackRightPrimaryBack, Position.RotateRightCW(Position.TopRightPrimaryTop));
            Assert.AreEqual<byte>(Position.Masked, Position.RotateRightCW(Position.Masked));
            Assert.AreEqual<byte>(Position.Unmasked, Position.RotateRightCW(Position.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_RotateRightCCW_AllEdges()
        {
            Assert.AreEqual<byte>(Position.BackLeftPrimaryBack, Position.RotateRightCCW(Position.BackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.BackLeftPrimaryLeft, Position.RotateRightCCW(Position.BackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopRightPrimaryTop, Position.RotateRightCCW(Position.BackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.TopRightPrimaryRight, Position.RotateRightCCW(Position.BackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBack, Position.RotateRightCCW(Position.BottomBackPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBottom, Position.RotateRightCCW(Position.BottomBackPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryBottom, Position.RotateRightCCW(Position.BottomFrontPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryFront, Position.RotateRightCCW(Position.BottomFrontPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryBottom, Position.RotateRightCCW(Position.BottomLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryLeft, Position.RotateRightCCW(Position.BottomLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BackRightPrimaryBack, Position.RotateRightCCW(Position.BottomRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BackRightPrimaryRight, Position.RotateRightCCW(Position.BottomRightPrimaryRight));
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryFront, Position.RotateRightCCW(Position.FrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryLeft, Position.RotateRightCCW(Position.FrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomRightPrimaryBottom, Position.RotateRightCCW(Position.FrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomRightPrimaryRight, Position.RotateRightCCW(Position.FrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackPrimaryBack, Position.RotateRightCCW(Position.TopBackPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackPrimaryTop, Position.RotateRightCCW(Position.TopBackPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontPrimaryFront, Position.RotateRightCCW(Position.TopFrontPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontPrimaryTop, Position.RotateRightCCW(Position.TopFrontPrimaryTop));
            Assert.AreEqual<byte>(Position.TopLeftPrimaryLeft, Position.RotateRightCCW(Position.TopLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopLeftPrimaryTop, Position.RotateRightCCW(Position.TopLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.FrontRightPrimaryRight, Position.RotateRightCCW(Position.TopRightPrimaryRight));
            Assert.AreEqual<byte>(Position.FrontRightPrimaryFront, Position.RotateRightCCW(Position.TopRightPrimaryTop));
            Assert.AreEqual<byte>(Position.Masked, Position.RotateRightCCW(Position.Masked));
            Assert.AreEqual<byte>(Position.Unmasked, Position.RotateRightCCW(Position.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_RotateRightHalf_AllEdges()
        {
            Assert.AreEqual<byte>(Position.BackLeftPrimaryBack, Position.RotateRightHalf(Position.BackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.BackLeftPrimaryLeft, Position.RotateRightHalf(Position.BackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.FrontRightPrimaryFront, Position.RotateRightHalf(Position.BackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.FrontRightPrimaryRight, Position.RotateRightHalf(Position.BackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBack, Position.RotateRightHalf(Position.BottomBackPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBottom, Position.RotateRightHalf(Position.BottomBackPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryBottom, Position.RotateRightHalf(Position.BottomFrontPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryFront, Position.RotateRightHalf(Position.BottomFrontPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryBottom, Position.RotateRightHalf(Position.BottomLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryLeft, Position.RotateRightHalf(Position.BottomLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopRightPrimaryTop, Position.RotateRightHalf(Position.BottomRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.TopRightPrimaryRight, Position.RotateRightHalf(Position.BottomRightPrimaryRight));
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryFront, Position.RotateRightHalf(Position.FrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryLeft, Position.RotateRightHalf(Position.FrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BackRightPrimaryBack, Position.RotateRightHalf(Position.FrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.BackRightPrimaryRight, Position.RotateRightHalf(Position.FrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackPrimaryBack, Position.RotateRightHalf(Position.TopBackPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackPrimaryTop, Position.RotateRightHalf(Position.TopBackPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontPrimaryFront, Position.RotateRightHalf(Position.TopFrontPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontPrimaryTop, Position.RotateRightHalf(Position.TopFrontPrimaryTop));
            Assert.AreEqual<byte>(Position.TopLeftPrimaryLeft, Position.RotateRightHalf(Position.TopLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopLeftPrimaryTop, Position.RotateRightHalf(Position.TopLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.BottomRightPrimaryRight, Position.RotateRightHalf(Position.TopRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomRightPrimaryBottom, Position.RotateRightHalf(Position.TopRightPrimaryTop));
            Assert.AreEqual<byte>(Position.Masked, Position.RotateRightHalf(Position.Masked));
            Assert.AreEqual<byte>(Position.Unmasked, Position.RotateRightHalf(Position.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_RotateFrontCW_AllEdges()
        {
            Assert.AreEqual<byte>(Position.BackLeftPrimaryBack, Position.RotateFrontCW(Position.BackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.BackLeftPrimaryLeft, Position.RotateFrontCW(Position.BackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BackRightPrimaryBack, Position.RotateFrontCW(Position.BackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.BackRightPrimaryRight, Position.RotateFrontCW(Position.BackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBack, Position.RotateFrontCW(Position.BottomBackPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBottom, Position.RotateFrontCW(Position.BottomBackPrimaryBottom));
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryLeft, Position.RotateFrontCW(Position.BottomFrontPrimaryBottom));
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryFront, Position.RotateFrontCW(Position.BottomFrontPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryBottom, Position.RotateFrontCW(Position.BottomLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryLeft, Position.RotateFrontCW(Position.BottomLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomRightPrimaryBottom, Position.RotateFrontCW(Position.BottomRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomRightPrimaryRight, Position.RotateFrontCW(Position.BottomRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopFrontPrimaryFront, Position.RotateFrontCW(Position.FrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontPrimaryTop, Position.RotateFrontCW(Position.FrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryFront, Position.RotateFrontCW(Position.FrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryBottom, Position.RotateFrontCW(Position.FrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackPrimaryBack, Position.RotateFrontCW(Position.TopBackPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackPrimaryTop, Position.RotateFrontCW(Position.TopBackPrimaryTop));
            Assert.AreEqual<byte>(Position.FrontRightPrimaryFront, Position.RotateFrontCW(Position.TopFrontPrimaryFront));
            Assert.AreEqual<byte>(Position.FrontRightPrimaryRight, Position.RotateFrontCW(Position.TopFrontPrimaryTop));
            Assert.AreEqual<byte>(Position.TopLeftPrimaryLeft, Position.RotateFrontCW(Position.TopLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopLeftPrimaryTop, Position.RotateFrontCW(Position.TopLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopRightPrimaryRight, Position.RotateFrontCW(Position.TopRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopRightPrimaryTop, Position.RotateFrontCW(Position.TopRightPrimaryTop));
            Assert.AreEqual<byte>(Position.Masked, Position.RotateFrontCW(Position.Masked));
            Assert.AreEqual<byte>(Position.Unmasked, Position.RotateFrontCW(Position.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_RotateFrontCCW_AllEdges()
        {
            Assert.AreEqual<byte>(Position.BackLeftPrimaryBack, Position.RotateFrontCCW(Position.BackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.BackLeftPrimaryLeft, Position.RotateFrontCCW(Position.BackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BackRightPrimaryBack, Position.RotateFrontCCW(Position.BackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.BackRightPrimaryRight, Position.RotateFrontCCW(Position.BackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBack, Position.RotateFrontCCW(Position.BottomBackPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBottom, Position.RotateFrontCCW(Position.BottomBackPrimaryBottom));
            Assert.AreEqual<byte>(Position.FrontRightPrimaryRight, Position.RotateFrontCCW(Position.BottomFrontPrimaryBottom));
            Assert.AreEqual<byte>(Position.FrontRightPrimaryFront, Position.RotateFrontCCW(Position.BottomFrontPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryBottom, Position.RotateFrontCCW(Position.BottomLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryLeft, Position.RotateFrontCCW(Position.BottomLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomRightPrimaryBottom, Position.RotateFrontCCW(Position.BottomRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomRightPrimaryRight, Position.RotateFrontCCW(Position.BottomRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryFront, Position.RotateFrontCCW(Position.FrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryBottom, Position.RotateFrontCCW(Position.FrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopFrontPrimaryFront, Position.RotateFrontCCW(Position.FrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontPrimaryTop, Position.RotateFrontCCW(Position.FrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackPrimaryBack, Position.RotateFrontCCW(Position.TopBackPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackPrimaryTop, Position.RotateFrontCCW(Position.TopBackPrimaryTop));
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryFront, Position.RotateFrontCCW(Position.TopFrontPrimaryFront));
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryLeft, Position.RotateFrontCCW(Position.TopFrontPrimaryTop));
            Assert.AreEqual<byte>(Position.TopLeftPrimaryLeft, Position.RotateFrontCCW(Position.TopLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopLeftPrimaryTop, Position.RotateFrontCCW(Position.TopLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopRightPrimaryRight, Position.RotateFrontCCW(Position.TopRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopRightPrimaryTop, Position.RotateFrontCCW(Position.TopRightPrimaryTop));
            Assert.AreEqual<byte>(Position.Masked, Position.RotateFrontCCW(Position.Masked));
            Assert.AreEqual<byte>(Position.Unmasked, Position.RotateFrontCCW(Position.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_RotateFrontHalf_AllEdges()
        {
            Assert.AreEqual<byte>(Position.BackLeftPrimaryBack, Position.RotateFrontHalf(Position.BackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.BackLeftPrimaryLeft, Position.RotateFrontHalf(Position.BackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BackRightPrimaryBack, Position.RotateFrontHalf(Position.BackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.BackRightPrimaryRight, Position.RotateFrontHalf(Position.BackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBack, Position.RotateFrontHalf(Position.BottomBackPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBottom, Position.RotateFrontHalf(Position.BottomBackPrimaryBottom));
            Assert.AreEqual<byte>(Position.TopFrontPrimaryTop, Position.RotateFrontHalf(Position.BottomFrontPrimaryBottom));
            Assert.AreEqual<byte>(Position.TopFrontPrimaryFront, Position.RotateFrontHalf(Position.BottomFrontPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryBottom, Position.RotateFrontHalf(Position.BottomLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryLeft, Position.RotateFrontHalf(Position.BottomLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomRightPrimaryBottom, Position.RotateFrontHalf(Position.BottomRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomRightPrimaryRight, Position.RotateFrontHalf(Position.BottomRightPrimaryRight));
            Assert.AreEqual<byte>(Position.FrontRightPrimaryFront, Position.RotateFrontHalf(Position.FrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.FrontRightPrimaryRight, Position.RotateFrontHalf(Position.FrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryFront, Position.RotateFrontHalf(Position.FrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryLeft, Position.RotateFrontHalf(Position.FrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackPrimaryBack, Position.RotateFrontHalf(Position.TopBackPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackPrimaryTop, Position.RotateFrontHalf(Position.TopBackPrimaryTop));
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryFront, Position.RotateFrontHalf(Position.TopFrontPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryBottom, Position.RotateFrontHalf(Position.TopFrontPrimaryTop));
            Assert.AreEqual<byte>(Position.TopLeftPrimaryLeft, Position.RotateFrontHalf(Position.TopLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopLeftPrimaryTop, Position.RotateFrontHalf(Position.TopLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopRightPrimaryRight, Position.RotateFrontHalf(Position.TopRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopRightPrimaryTop, Position.RotateFrontHalf(Position.TopRightPrimaryTop));
            Assert.AreEqual<byte>(Position.Masked, Position.RotateFrontHalf(Position.Masked));
            Assert.AreEqual<byte>(Position.Unmasked, Position.RotateFrontHalf(Position.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_RotateBackCW_AllEdges()
        {
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBack, Position.RotateBackCW(Position.BackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBottom, Position.RotateBackCW(Position.BackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopBackPrimaryBack, Position.RotateBackCW(Position.BackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackPrimaryTop, Position.RotateBackCW(Position.BackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BackRightPrimaryBack, Position.RotateBackCW(Position.BottomBackPrimaryBack));
            Assert.AreEqual<byte>(Position.BackRightPrimaryRight, Position.RotateBackCW(Position.BottomBackPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryBottom, Position.RotateBackCW(Position.BottomFrontPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryFront, Position.RotateBackCW(Position.BottomFrontPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryBottom, Position.RotateBackCW(Position.BottomLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryLeft, Position.RotateBackCW(Position.BottomLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomRightPrimaryBottom, Position.RotateBackCW(Position.BottomRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomRightPrimaryRight, Position.RotateBackCW(Position.BottomRightPrimaryRight));
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryFront, Position.RotateBackCW(Position.FrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryLeft, Position.RotateBackCW(Position.FrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.FrontRightPrimaryFront, Position.RotateBackCW(Position.FrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.FrontRightPrimaryRight, Position.RotateBackCW(Position.FrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BackLeftPrimaryBack, Position.RotateBackCW(Position.TopBackPrimaryBack));
            Assert.AreEqual<byte>(Position.BackLeftPrimaryLeft, Position.RotateBackCW(Position.TopBackPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontPrimaryFront, Position.RotateBackCW(Position.TopFrontPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontPrimaryTop, Position.RotateBackCW(Position.TopFrontPrimaryTop));
            Assert.AreEqual<byte>(Position.TopLeftPrimaryLeft, Position.RotateBackCW(Position.TopLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopLeftPrimaryTop, Position.RotateBackCW(Position.TopLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopRightPrimaryRight, Position.RotateBackCW(Position.TopRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopRightPrimaryTop, Position.RotateBackCW(Position.TopRightPrimaryTop));
            Assert.AreEqual<byte>(Position.Masked, Position.RotateBackCW(Position.Masked));
            Assert.AreEqual<byte>(Position.Unmasked, Position.RotateBackCW(Position.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_RotateBackCCW_AllEdges()
        {
            Assert.AreEqual<byte>(Position.TopBackPrimaryBack, Position.RotateBackCCW(Position.BackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackPrimaryTop, Position.RotateBackCCW(Position.BackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBack, Position.RotateBackCCW(Position.BackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBottom, Position.RotateBackCCW(Position.BackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BackLeftPrimaryBack, Position.RotateBackCCW(Position.BottomBackPrimaryBack));
            Assert.AreEqual<byte>(Position.BackLeftPrimaryLeft, Position.RotateBackCCW(Position.BottomBackPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryBottom, Position.RotateBackCCW(Position.BottomFrontPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryFront, Position.RotateBackCCW(Position.BottomFrontPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryBottom, Position.RotateBackCCW(Position.BottomLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryLeft, Position.RotateBackCCW(Position.BottomLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomRightPrimaryBottom, Position.RotateBackCCW(Position.BottomRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomRightPrimaryRight, Position.RotateBackCCW(Position.BottomRightPrimaryRight));
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryFront, Position.RotateBackCCW(Position.FrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryLeft, Position.RotateBackCCW(Position.FrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.FrontRightPrimaryFront, Position.RotateBackCCW(Position.FrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.FrontRightPrimaryRight, Position.RotateBackCCW(Position.FrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BackRightPrimaryBack, Position.RotateBackCCW(Position.TopBackPrimaryBack));
            Assert.AreEqual<byte>(Position.BackRightPrimaryRight, Position.RotateBackCCW(Position.TopBackPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontPrimaryFront, Position.RotateBackCCW(Position.TopFrontPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontPrimaryTop, Position.RotateBackCCW(Position.TopFrontPrimaryTop));
            Assert.AreEqual<byte>(Position.TopLeftPrimaryLeft, Position.RotateBackCCW(Position.TopLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopLeftPrimaryTop, Position.RotateBackCCW(Position.TopLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopRightPrimaryRight, Position.RotateBackCCW(Position.TopRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopRightPrimaryTop, Position.RotateBackCCW(Position.TopRightPrimaryTop));
            Assert.AreEqual<byte>(Position.Masked, Position.RotateBackCCW(Position.Masked));
            Assert.AreEqual<byte>(Position.Unmasked, Position.RotateBackCCW(Position.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_RotateBackHalf_AllEdges()
        {
            Assert.AreEqual<byte>(Position.BackRightPrimaryBack, Position.RotateBackHalf(Position.BackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.BackRightPrimaryRight, Position.RotateBackHalf(Position.BackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BackLeftPrimaryBack, Position.RotateBackHalf(Position.BackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.BackLeftPrimaryLeft, Position.RotateBackHalf(Position.BackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackPrimaryBack, Position.RotateBackHalf(Position.BottomBackPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackPrimaryTop, Position.RotateBackHalf(Position.BottomBackPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryBottom, Position.RotateBackHalf(Position.BottomFrontPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryFront, Position.RotateBackHalf(Position.BottomFrontPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryBottom, Position.RotateBackHalf(Position.BottomLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryLeft, Position.RotateBackHalf(Position.BottomLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomRightPrimaryBottom, Position.RotateBackHalf(Position.BottomRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomRightPrimaryRight, Position.RotateBackHalf(Position.BottomRightPrimaryRight));
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryFront, Position.RotateBackHalf(Position.FrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryLeft, Position.RotateBackHalf(Position.FrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.FrontRightPrimaryFront, Position.RotateBackHalf(Position.FrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.FrontRightPrimaryRight, Position.RotateBackHalf(Position.FrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBack, Position.RotateBackHalf(Position.TopBackPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBottom, Position.RotateBackHalf(Position.TopBackPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontPrimaryFront, Position.RotateBackHalf(Position.TopFrontPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontPrimaryTop, Position.RotateBackHalf(Position.TopFrontPrimaryTop));
            Assert.AreEqual<byte>(Position.TopLeftPrimaryLeft, Position.RotateBackHalf(Position.TopLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopLeftPrimaryTop, Position.RotateBackHalf(Position.TopLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopRightPrimaryRight, Position.RotateBackHalf(Position.TopRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopRightPrimaryTop, Position.RotateBackHalf(Position.TopRightPrimaryTop));
            Assert.AreEqual<byte>(Position.Masked, Position.RotateBackHalf(Position.Masked));
            Assert.AreEqual<byte>(Position.Unmasked, Position.RotateBackHalf(Position.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_Mask_MaskedEdge()
        {
            Assert.AreEqual<byte>(Position.Masked, Position.Mask(Position.TopBackPrimaryBack, Position.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_Mask_UnmaskedEdge()
        {
            Assert.AreEqual<byte>(Position.TopBackPrimaryBack, Position.Mask(Position.TopBackPrimaryBack, Position.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        [ExpectedException(typeof(ArgumentException))]
        public void EdgePosition_Mask_BadMask()
        {
            Assert.AreEqual<byte>(Position.TopBackPrimaryBack, Position.Mask(Position.TopBackPrimaryBack, Position.TopBackPrimaryBack));
        }
    }
}
