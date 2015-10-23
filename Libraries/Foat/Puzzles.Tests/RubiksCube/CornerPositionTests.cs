using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Foat.Puzzles.RubiksCube;

namespace Foat.Puzzles.Tests.RubiksCube
{
    [TestClass]
    public class CornerPositionTests
    {
        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_RotateTopCW_AllCorners()
        {
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBack, Position.RotateTopCW(Position.BottomBackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBottom, Position.RotateTopCW(Position.BottomBackLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryLeft, Position.RotateTopCW(Position.BottomBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBack, Position.RotateTopCW(Position.BottomBackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBottom, Position.RotateTopCW(Position.BottomBackRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryRight, Position.RotateTopCW(Position.BottomBackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryBottom, Position.RotateTopCW(Position.BottomFrontLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryFront, Position.RotateTopCW(Position.BottomFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryLeft, Position.RotateTopCW(Position.BottomFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryBottom, Position.RotateTopCW(Position.BottomFrontRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryFront, Position.RotateTopCW(Position.BottomFrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryRight, Position.RotateTopCW(Position.BottomFrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryRight, Position.RotateTopCW(Position.TopBackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryBack, Position.RotateTopCW(Position.TopBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryTop, Position.RotateTopCW(Position.TopBackLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryRight, Position.RotateTopCW(Position.TopBackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryFront, Position.RotateTopCW(Position.TopBackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryTop, Position.RotateTopCW(Position.TopBackRightPrimaryTop));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryLeft, Position.RotateTopCW(Position.TopFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryBack, Position.RotateTopCW(Position.TopFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryTop, Position.RotateTopCW(Position.TopFrontLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryLeft, Position.RotateTopCW(Position.TopFrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryFront, Position.RotateTopCW(Position.TopFrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryTop, Position.RotateTopCW(Position.TopFrontRightPrimaryTop));
            Assert.AreEqual<byte>(Position.Unmasked, Position.RotateTopCW(Position.Unmasked));
            Assert.AreEqual<byte>(Position.Masked, Position.RotateTopCW(Position.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_RotateTopCCW_AllCorners()
        {
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBack, Position.RotateTopCCW(Position.BottomBackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBottom, Position.RotateTopCCW(Position.BottomBackLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryLeft, Position.RotateTopCCW(Position.BottomBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBack, Position.RotateTopCCW(Position.BottomBackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBottom, Position.RotateTopCCW(Position.BottomBackRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryRight, Position.RotateTopCCW(Position.BottomBackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryBottom, Position.RotateTopCCW(Position.BottomFrontLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryFront, Position.RotateTopCCW(Position.BottomFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryLeft, Position.RotateTopCCW(Position.BottomFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryBottom, Position.RotateTopCCW(Position.BottomFrontRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryFront, Position.RotateTopCCW(Position.BottomFrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryRight, Position.RotateTopCCW(Position.BottomFrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryLeft, Position.RotateTopCCW(Position.TopBackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryFront, Position.RotateTopCCW(Position.TopBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryTop, Position.RotateTopCCW(Position.TopBackLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryLeft, Position.RotateTopCCW(Position.TopBackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryBack, Position.RotateTopCCW(Position.TopBackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryTop, Position.RotateTopCCW(Position.TopBackRightPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryRight, Position.RotateTopCCW(Position.TopFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryFront, Position.RotateTopCCW(Position.TopFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryTop, Position.RotateTopCCW(Position.TopFrontLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryRight, Position.RotateTopCCW(Position.TopFrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryBack, Position.RotateTopCCW(Position.TopFrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryTop, Position.RotateTopCCW(Position.TopFrontRightPrimaryTop));
            Assert.AreEqual<byte>(Position.Unmasked, Position.RotateTopCCW(Position.Unmasked));
            Assert.AreEqual<byte>(Position.Masked, Position.RotateTopCCW(Position.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_RotateTopHalf_AllCorners()
        {
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBack, Position.RotateTopHalf(Position.BottomBackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBottom, Position.RotateTopHalf(Position.BottomBackLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryLeft, Position.RotateTopHalf(Position.BottomBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBack, Position.RotateTopHalf(Position.BottomBackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBottom, Position.RotateTopHalf(Position.BottomBackRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryRight, Position.RotateTopHalf(Position.BottomBackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryBottom, Position.RotateTopHalf(Position.BottomFrontLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryFront, Position.RotateTopHalf(Position.BottomFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryLeft, Position.RotateTopHalf(Position.BottomFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryBottom, Position.RotateTopHalf(Position.BottomFrontRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryFront, Position.RotateTopHalf(Position.BottomFrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryRight, Position.RotateTopHalf(Position.BottomFrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryFront, Position.RotateTopHalf(Position.TopBackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryRight, Position.RotateTopHalf(Position.TopBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryTop, Position.RotateTopHalf(Position.TopBackLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryFront, Position.RotateTopHalf(Position.TopBackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryLeft, Position.RotateTopHalf(Position.TopBackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryTop, Position.RotateTopHalf(Position.TopBackRightPrimaryTop));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryBack, Position.RotateTopHalf(Position.TopFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryRight, Position.RotateTopHalf(Position.TopFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryTop, Position.RotateTopHalf(Position.TopFrontLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryBack, Position.RotateTopHalf(Position.TopFrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryLeft, Position.RotateTopHalf(Position.TopFrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryTop, Position.RotateTopHalf(Position.TopFrontRightPrimaryTop));
            Assert.AreEqual<byte>(Position.Unmasked, Position.RotateTopHalf(Position.Unmasked));
            Assert.AreEqual<byte>(Position.Masked, Position.RotateTopHalf(Position.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_RotateBottomCW_AllCorners()
        {
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryLeft, Position.RotateBottomCW(Position.BottomBackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryBottom, Position.RotateBottomCW(Position.BottomBackLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryFront, Position.RotateBottomCW(Position.BottomBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryLeft, Position.RotateBottomCW(Position.BottomBackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBottom, Position.RotateBottomCW(Position.BottomBackRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBack, Position.RotateBottomCW(Position.BottomBackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryBottom, Position.RotateBottomCW(Position.BottomFrontLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryRight, Position.RotateBottomCW(Position.BottomFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryFront, Position.RotateBottomCW(Position.BottomFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBottom, Position.RotateBottomCW(Position.BottomFrontRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryRight, Position.RotateBottomCW(Position.BottomFrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBack, Position.RotateBottomCW(Position.BottomFrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryBack, Position.RotateBottomCW(Position.TopBackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryLeft, Position.RotateBottomCW(Position.TopBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryTop, Position.RotateBottomCW(Position.TopBackLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryBack, Position.RotateBottomCW(Position.TopBackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryRight, Position.RotateBottomCW(Position.TopBackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryTop, Position.RotateBottomCW(Position.TopBackRightPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryFront, Position.RotateBottomCW(Position.TopFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryLeft, Position.RotateBottomCW(Position.TopFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryTop, Position.RotateBottomCW(Position.TopFrontLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryFront, Position.RotateBottomCW(Position.TopFrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryRight, Position.RotateBottomCW(Position.TopFrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryTop, Position.RotateBottomCW(Position.TopFrontRightPrimaryTop));
            Assert.AreEqual<byte>(Position.Unmasked, Position.RotateBottomCW(Position.Unmasked));
            Assert.AreEqual<byte>(Position.Masked, Position.RotateBottomCW(Position.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_RotateBottomCCW_AllCorners()
        {
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryRight, Position.RotateBottomCCW(Position.BottomBackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBottom, Position.RotateBottomCCW(Position.BottomBackLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBack, Position.RotateBottomCCW(Position.BottomBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryRight, Position.RotateBottomCCW(Position.BottomBackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryBottom, Position.RotateBottomCCW(Position.BottomBackRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryFront, Position.RotateBottomCCW(Position.BottomBackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBottom, Position.RotateBottomCCW(Position.BottomFrontLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryLeft, Position.RotateBottomCCW(Position.BottomFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBack, Position.RotateBottomCCW(Position.BottomFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryBottom, Position.RotateBottomCCW(Position.BottomFrontRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryLeft, Position.RotateBottomCCW(Position.BottomFrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryFront, Position.RotateBottomCCW(Position.BottomFrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryBack, Position.RotateBottomCCW(Position.TopBackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryLeft, Position.RotateBottomCCW(Position.TopBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryTop, Position.RotateBottomCCW(Position.TopBackLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryBack, Position.RotateBottomCCW(Position.TopBackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryRight, Position.RotateBottomCCW(Position.TopBackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryTop, Position.RotateBottomCCW(Position.TopBackRightPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryFront, Position.RotateBottomCCW(Position.TopFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryLeft, Position.RotateBottomCCW(Position.TopFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryTop, Position.RotateBottomCCW(Position.TopFrontLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryFront, Position.RotateBottomCCW(Position.TopFrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryRight, Position.RotateBottomCCW(Position.TopFrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryTop, Position.RotateBottomCCW(Position.TopFrontRightPrimaryTop));
            Assert.AreEqual<byte>(Position.Unmasked, Position.RotateBottomCCW(Position.Unmasked));
            Assert.AreEqual<byte>(Position.Masked, Position.RotateBottomCCW(Position.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_RotateBottomHalf_AllCorners()
        {
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryFront, Position.RotateBottomHalf(Position.BottomBackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryBottom, Position.RotateBottomHalf(Position.BottomBackLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryRight, Position.RotateBottomHalf(Position.BottomBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryFront, Position.RotateBottomHalf(Position.BottomBackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryBottom, Position.RotateBottomHalf(Position.BottomBackRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryLeft, Position.RotateBottomHalf(Position.BottomBackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBottom, Position.RotateBottomHalf(Position.BottomFrontLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBack, Position.RotateBottomHalf(Position.BottomFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryRight, Position.RotateBottomHalf(Position.BottomFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBottom, Position.RotateBottomHalf(Position.BottomFrontRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBack, Position.RotateBottomHalf(Position.BottomFrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryLeft, Position.RotateBottomHalf(Position.BottomFrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryBack, Position.RotateBottomHalf(Position.TopBackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryLeft, Position.RotateBottomHalf(Position.TopBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryTop, Position.RotateBottomHalf(Position.TopBackLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryBack, Position.RotateBottomHalf(Position.TopBackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryRight, Position.RotateBottomHalf(Position.TopBackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryTop, Position.RotateBottomHalf(Position.TopBackRightPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryFront, Position.RotateBottomHalf(Position.TopFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryLeft, Position.RotateBottomHalf(Position.TopFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryTop, Position.RotateBottomHalf(Position.TopFrontLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryFront, Position.RotateBottomHalf(Position.TopFrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryRight, Position.RotateBottomHalf(Position.TopFrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryTop, Position.RotateBottomHalf(Position.TopFrontRightPrimaryTop));
            Assert.AreEqual<byte>(Position.Unmasked, Position.RotateBottomHalf(Position.Unmasked));
            Assert.AreEqual<byte>(Position.Masked, Position.RotateBottomHalf(Position.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_RotateLeftCW_AllCorners()
        {
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryTop, Position.RotateLeftCW(Position.BottomBackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryBack, Position.RotateLeftCW(Position.BottomBackLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryLeft, Position.RotateLeftCW(Position.BottomBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBack, Position.RotateLeftCW(Position.BottomBackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBottom, Position.RotateLeftCW(Position.BottomBackRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryRight, Position.RotateLeftCW(Position.BottomBackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBack, Position.RotateLeftCW(Position.BottomFrontLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBottom, Position.RotateLeftCW(Position.BottomFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryLeft, Position.RotateLeftCW(Position.BottomFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryBottom, Position.RotateLeftCW(Position.BottomFrontRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryFront, Position.RotateLeftCW(Position.BottomFrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryRight, Position.RotateLeftCW(Position.BottomFrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryTop, Position.RotateLeftCW(Position.TopBackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryLeft, Position.RotateLeftCW(Position.TopBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryFront, Position.RotateLeftCW(Position.TopBackLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryBack, Position.RotateLeftCW(Position.TopBackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryRight, Position.RotateLeftCW(Position.TopBackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryTop, Position.RotateLeftCW(Position.TopBackRightPrimaryTop));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryBottom, Position.RotateLeftCW(Position.TopFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryLeft, Position.RotateLeftCW(Position.TopFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryFront, Position.RotateLeftCW(Position.TopFrontLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryFront, Position.RotateLeftCW(Position.TopFrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryRight, Position.RotateLeftCW(Position.TopFrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryTop, Position.RotateLeftCW(Position.TopFrontRightPrimaryTop));
            Assert.AreEqual<byte>(Position.Unmasked, Position.RotateLeftCW(Position.Unmasked));
            Assert.AreEqual<byte>(Position.Masked, Position.RotateLeftCW(Position.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_RotateLeftCCW_AllCorners()
        {
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryBottom, Position.RotateLeftCCW(Position.BottomBackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryFront, Position.RotateLeftCCW(Position.BottomBackLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryLeft, Position.RotateLeftCCW(Position.BottomBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBack, Position.RotateLeftCCW(Position.BottomBackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBottom, Position.RotateLeftCCW(Position.BottomBackRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryRight, Position.RotateLeftCCW(Position.BottomBackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryFront, Position.RotateLeftCCW(Position.BottomFrontLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryTop, Position.RotateLeftCCW(Position.BottomFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryLeft, Position.RotateLeftCCW(Position.BottomFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryBottom, Position.RotateLeftCCW(Position.BottomFrontRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryFront, Position.RotateLeftCCW(Position.BottomFrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryRight, Position.RotateLeftCCW(Position.BottomFrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBottom, Position.RotateLeftCCW(Position.TopBackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryLeft, Position.RotateLeftCCW(Position.TopBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBack, Position.RotateLeftCCW(Position.TopBackLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryBack, Position.RotateLeftCCW(Position.TopBackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryRight, Position.RotateLeftCCW(Position.TopBackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryTop, Position.RotateLeftCCW(Position.TopBackRightPrimaryTop));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryTop, Position.RotateLeftCCW(Position.TopFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryLeft, Position.RotateLeftCCW(Position.TopFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryBack, Position.RotateLeftCCW(Position.TopFrontLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryFront, Position.RotateLeftCCW(Position.TopFrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryRight, Position.RotateLeftCCW(Position.TopFrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryTop, Position.RotateLeftCCW(Position.TopFrontRightPrimaryTop));
            Assert.AreEqual<byte>(Position.Unmasked, Position.RotateLeftCCW(Position.Unmasked));
            Assert.AreEqual<byte>(Position.Masked, Position.RotateLeftCCW(Position.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_RotateLeftHalf_AllCorners()
        {
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryFront, Position.RotateLeftHalf(Position.BottomBackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryTop, Position.RotateLeftHalf(Position.BottomBackLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryLeft, Position.RotateLeftHalf(Position.BottomBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBack, Position.RotateLeftHalf(Position.BottomBackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBottom, Position.RotateLeftHalf(Position.BottomBackRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryRight, Position.RotateLeftHalf(Position.BottomBackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryTop, Position.RotateLeftHalf(Position.BottomFrontLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryBack, Position.RotateLeftHalf(Position.BottomFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryLeft, Position.RotateLeftHalf(Position.BottomFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryBottom, Position.RotateLeftHalf(Position.BottomFrontRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryFront, Position.RotateLeftHalf(Position.BottomFrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryRight, Position.RotateLeftHalf(Position.BottomFrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryFront, Position.RotateLeftHalf(Position.TopBackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryLeft, Position.RotateLeftHalf(Position.TopBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryBottom, Position.RotateLeftHalf(Position.TopBackLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryBack, Position.RotateLeftHalf(Position.TopBackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryRight, Position.RotateLeftHalf(Position.TopBackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryTop, Position.RotateLeftHalf(Position.TopBackRightPrimaryTop));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBack, Position.RotateLeftHalf(Position.TopFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryLeft, Position.RotateLeftHalf(Position.TopFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBottom, Position.RotateLeftHalf(Position.TopFrontLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryFront, Position.RotateLeftHalf(Position.TopFrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryRight, Position.RotateLeftHalf(Position.TopFrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryTop, Position.RotateLeftHalf(Position.TopFrontRightPrimaryTop));
            Assert.AreEqual<byte>(Position.Unmasked, Position.RotateLeftHalf(Position.Unmasked));
            Assert.AreEqual<byte>(Position.Masked, Position.RotateLeftHalf(Position.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_RotateRightCW_AllCorners()
        {
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBack, Position.RotateRightCW(Position.BottomBackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBottom, Position.RotateRightCW(Position.BottomBackLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryLeft, Position.RotateRightCW(Position.BottomBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryBottom, Position.RotateRightCW(Position.BottomBackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryFront, Position.RotateRightCW(Position.BottomBackRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryRight, Position.RotateRightCW(Position.BottomBackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryBottom, Position.RotateRightCW(Position.BottomFrontLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryFront, Position.RotateRightCW(Position.BottomFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryLeft, Position.RotateRightCW(Position.BottomFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryFront, Position.RotateRightCW(Position.BottomFrontRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryTop, Position.RotateRightCW(Position.BottomFrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryRight, Position.RotateRightCW(Position.BottomFrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryBack, Position.RotateRightCW(Position.TopBackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryLeft, Position.RotateRightCW(Position.TopBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryTop, Position.RotateRightCW(Position.TopBackLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBottom, Position.RotateRightCW(Position.TopBackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryRight, Position.RotateRightCW(Position.TopBackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBack, Position.RotateRightCW(Position.TopBackRightPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryFront, Position.RotateRightCW(Position.TopFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryLeft, Position.RotateRightCW(Position.TopFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryTop, Position.RotateRightCW(Position.TopFrontLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryTop, Position.RotateRightCW(Position.TopFrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryRight, Position.RotateRightCW(Position.TopFrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryBack, Position.RotateRightCW(Position.TopFrontRightPrimaryTop));
            Assert.AreEqual<byte>(Position.Unmasked, Position.RotateRightCW(Position.Unmasked));
            Assert.AreEqual<byte>(Position.Masked, Position.RotateRightCW(Position.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_RotateRightCCW_AllCorners()
        {
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBack, Position.RotateRightCCW(Position.BottomBackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBottom, Position.RotateRightCCW(Position.BottomBackLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryLeft, Position.RotateRightCCW(Position.BottomBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryTop, Position.RotateRightCCW(Position.BottomBackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryBack, Position.RotateRightCCW(Position.BottomBackRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryRight, Position.RotateRightCCW(Position.BottomBackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryBottom, Position.RotateRightCCW(Position.BottomFrontLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryFront, Position.RotateRightCCW(Position.BottomFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryLeft, Position.RotateRightCCW(Position.BottomFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBack, Position.RotateRightCCW(Position.BottomFrontRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBottom, Position.RotateRightCCW(Position.BottomFrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryRight, Position.RotateRightCCW(Position.BottomFrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryBack, Position.RotateRightCCW(Position.TopBackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryLeft, Position.RotateRightCCW(Position.TopBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryTop, Position.RotateRightCCW(Position.TopBackLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryTop, Position.RotateRightCCW(Position.TopBackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryRight, Position.RotateRightCCW(Position.TopBackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryFront, Position.RotateRightCCW(Position.TopBackRightPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryFront, Position.RotateRightCCW(Position.TopFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryLeft, Position.RotateRightCCW(Position.TopFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryTop, Position.RotateRightCCW(Position.TopFrontLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryBottom, Position.RotateRightCCW(Position.TopFrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryRight, Position.RotateRightCCW(Position.TopFrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryFront, Position.RotateRightCCW(Position.TopFrontRightPrimaryTop));
            Assert.AreEqual<byte>(Position.Unmasked, Position.RotateRightCCW(Position.Unmasked));
            Assert.AreEqual<byte>(Position.Masked, Position.RotateRightCCW(Position.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_RotateRightHalf_AllCorners()
        {
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBack, Position.RotateRightHalf(Position.BottomBackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBottom, Position.RotateRightHalf(Position.BottomBackLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryLeft, Position.RotateRightHalf(Position.BottomBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryFront, Position.RotateRightHalf(Position.BottomBackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryTop, Position.RotateRightHalf(Position.BottomBackRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryRight, Position.RotateRightHalf(Position.BottomBackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryBottom, Position.RotateRightHalf(Position.BottomFrontLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryFront, Position.RotateRightHalf(Position.BottomFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryLeft, Position.RotateRightHalf(Position.BottomFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryTop, Position.RotateRightHalf(Position.BottomFrontRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryBack, Position.RotateRightHalf(Position.BottomFrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryRight, Position.RotateRightHalf(Position.BottomFrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryBack, Position.RotateRightHalf(Position.TopBackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryLeft, Position.RotateRightHalf(Position.TopBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryTop, Position.RotateRightHalf(Position.TopBackLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryFront, Position.RotateRightHalf(Position.TopBackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryRight, Position.RotateRightHalf(Position.TopBackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryBottom, Position.RotateRightHalf(Position.TopBackRightPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryFront, Position.RotateRightHalf(Position.TopFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryLeft, Position.RotateRightHalf(Position.TopFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryTop, Position.RotateRightHalf(Position.TopFrontLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBack, Position.RotateRightHalf(Position.TopFrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryRight, Position.RotateRightHalf(Position.TopFrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBottom, Position.RotateRightHalf(Position.TopFrontRightPrimaryTop));
            Assert.AreEqual<byte>(Position.Unmasked, Position.RotateRightHalf(Position.Unmasked));
            Assert.AreEqual<byte>(Position.Masked, Position.RotateRightHalf(Position.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_RotateFrontCW_AllCorners()
        {
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBack, Position.RotateFrontCW(Position.BottomBackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBottom, Position.RotateFrontCW(Position.BottomBackLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryLeft, Position.RotateFrontCW(Position.BottomBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBack, Position.RotateFrontCW(Position.BottomBackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBottom, Position.RotateFrontCW(Position.BottomBackRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryRight, Position.RotateFrontCW(Position.BottomBackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryLeft, Position.RotateFrontCW(Position.BottomFrontLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryFront, Position.RotateFrontCW(Position.BottomFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryTop, Position.RotateFrontCW(Position.BottomFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryLeft, Position.RotateFrontCW(Position.BottomFrontRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryFront, Position.RotateFrontCW(Position.BottomFrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryBottom, Position.RotateFrontCW(Position.BottomFrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryBack, Position.RotateFrontCW(Position.TopBackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryLeft, Position.RotateFrontCW(Position.TopBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryTop, Position.RotateFrontCW(Position.TopBackLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryBack, Position.RotateFrontCW(Position.TopBackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryRight, Position.RotateFrontCW(Position.TopBackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryTop, Position.RotateFrontCW(Position.TopBackRightPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryFront, Position.RotateFrontCW(Position.TopFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryTop, Position.RotateFrontCW(Position.TopFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryRight, Position.RotateFrontCW(Position.TopFrontLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryFront, Position.RotateFrontCW(Position.TopFrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryBottom, Position.RotateFrontCW(Position.TopFrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryRight, Position.RotateFrontCW(Position.TopFrontRightPrimaryTop));
            Assert.AreEqual<byte>(Position.Unmasked, Position.RotateFrontCW(Position.Unmasked));
            Assert.AreEqual<byte>(Position.Masked, Position.RotateFrontCW(Position.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_RotateFrontCCW_AllCorners()
        {
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBack, Position.RotateFrontCCW(Position.BottomBackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBottom, Position.RotateFrontCCW(Position.BottomBackLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryLeft, Position.RotateFrontCCW(Position.BottomBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBack, Position.RotateFrontCCW(Position.BottomBackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBottom, Position.RotateFrontCCW(Position.BottomBackRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryRight, Position.RotateFrontCCW(Position.BottomBackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryRight, Position.RotateFrontCCW(Position.BottomFrontLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryFront, Position.RotateFrontCCW(Position.BottomFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryBottom, Position.RotateFrontCCW(Position.BottomFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryRight, Position.RotateFrontCCW(Position.BottomFrontRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryFront, Position.RotateFrontCCW(Position.BottomFrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryTop, Position.RotateFrontCCW(Position.BottomFrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryBack, Position.RotateFrontCCW(Position.TopBackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryLeft, Position.RotateFrontCCW(Position.TopBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryTop, Position.RotateFrontCCW(Position.TopBackLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryBack, Position.RotateFrontCCW(Position.TopBackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryRight, Position.RotateFrontCCW(Position.TopBackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryTop, Position.RotateFrontCCW(Position.TopBackRightPrimaryTop));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryFront, Position.RotateFrontCCW(Position.TopFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryBottom, Position.RotateFrontCCW(Position.TopFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryLeft, Position.RotateFrontCCW(Position.TopFrontLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryFront, Position.RotateFrontCCW(Position.TopFrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryTop, Position.RotateFrontCCW(Position.TopFrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryLeft, Position.RotateFrontCCW(Position.TopFrontRightPrimaryTop));
            Assert.AreEqual<byte>(Position.Unmasked, Position.RotateFrontCCW(Position.Unmasked));
            Assert.AreEqual<byte>(Position.Masked, Position.RotateFrontCCW(Position.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_RotateFrontHalf_AllCorners()
        {
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBack, Position.RotateFrontHalf(Position.BottomBackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBottom, Position.RotateFrontHalf(Position.BottomBackLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryLeft, Position.RotateFrontHalf(Position.BottomBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBack, Position.RotateFrontHalf(Position.BottomBackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBottom, Position.RotateFrontHalf(Position.BottomBackRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryRight, Position.RotateFrontHalf(Position.BottomBackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryTop, Position.RotateFrontHalf(Position.BottomFrontLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryFront, Position.RotateFrontHalf(Position.BottomFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryRight, Position.RotateFrontHalf(Position.BottomFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryTop, Position.RotateFrontHalf(Position.BottomFrontRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryFront, Position.RotateFrontHalf(Position.BottomFrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryLeft, Position.RotateFrontHalf(Position.BottomFrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryBack, Position.RotateFrontHalf(Position.TopBackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryLeft, Position.RotateFrontHalf(Position.TopBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryTop, Position.RotateFrontHalf(Position.TopBackLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryBack, Position.RotateFrontHalf(Position.TopBackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryRight, Position.RotateFrontHalf(Position.TopBackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryTop, Position.RotateFrontHalf(Position.TopBackRightPrimaryTop));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryFront, Position.RotateFrontHalf(Position.TopFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryRight, Position.RotateFrontHalf(Position.TopFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryBottom, Position.RotateFrontHalf(Position.TopFrontLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryFront, Position.RotateFrontHalf(Position.TopFrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryLeft, Position.RotateFrontHalf(Position.TopFrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryBottom, Position.RotateFrontHalf(Position.TopFrontRightPrimaryTop));
            Assert.AreEqual<byte>(Position.Unmasked, Position.RotateFrontHalf(Position.Unmasked));
            Assert.AreEqual<byte>(Position.Masked, Position.RotateFrontHalf(Position.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_RotateBackCW_AllCorners()
        {
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBack, Position.RotateBackCW(Position.BottomBackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryRight, Position.RotateBackCW(Position.BottomBackLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBottom, Position.RotateBackCW(Position.BottomBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryBack, Position.RotateBackCW(Position.BottomBackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryRight, Position.RotateBackCW(Position.BottomBackRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryTop, Position.RotateBackCW(Position.BottomBackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryBottom, Position.RotateBackCW(Position.BottomFrontLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryFront, Position.RotateBackCW(Position.BottomFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryLeft, Position.RotateBackCW(Position.BottomFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryBottom, Position.RotateBackCW(Position.BottomFrontRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryFront, Position.RotateBackCW(Position.BottomFrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryRight, Position.RotateBackCW(Position.BottomFrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBack, Position.RotateBackCW(Position.TopBackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBottom, Position.RotateBackCW(Position.TopBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryLeft, Position.RotateBackCW(Position.TopBackLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryBack, Position.RotateBackCW(Position.TopBackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryTop, Position.RotateBackCW(Position.TopBackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryLeft, Position.RotateBackCW(Position.TopBackRightPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryFront, Position.RotateBackCW(Position.TopFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryLeft, Position.RotateBackCW(Position.TopFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryTop, Position.RotateBackCW(Position.TopFrontLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryFront, Position.RotateBackCW(Position.TopFrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryRight, Position.RotateBackCW(Position.TopFrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryTop, Position.RotateBackCW(Position.TopFrontRightPrimaryTop));
            Assert.AreEqual<byte>(Position.Unmasked, Position.RotateBackCW(Position.Unmasked));
            Assert.AreEqual<byte>(Position.Masked, Position.RotateBackCW(Position.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_RotateBackCCW_AllCorners()
        {
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryBack, Position.RotateBackCCW(Position.BottomBackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryLeft, Position.RotateBackCCW(Position.BottomBackLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryTop, Position.RotateBackCCW(Position.BottomBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBack, Position.RotateBackCCW(Position.BottomBackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryLeft, Position.RotateBackCCW(Position.BottomBackRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBottom, Position.RotateBackCCW(Position.BottomBackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryBottom, Position.RotateBackCCW(Position.BottomFrontLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryFront, Position.RotateBackCCW(Position.BottomFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryLeft, Position.RotateBackCCW(Position.BottomFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryBottom, Position.RotateBackCCW(Position.BottomFrontRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryFront, Position.RotateBackCCW(Position.BottomFrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryRight, Position.RotateBackCCW(Position.BottomFrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryBack, Position.RotateBackCCW(Position.TopBackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryTop, Position.RotateBackCCW(Position.TopBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryRight, Position.RotateBackCCW(Position.TopBackLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBack, Position.RotateBackCCW(Position.TopBackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBottom, Position.RotateBackCCW(Position.TopBackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryRight, Position.RotateBackCCW(Position.TopBackRightPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryFront, Position.RotateBackCCW(Position.TopFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryLeft, Position.RotateBackCCW(Position.TopFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryTop, Position.RotateBackCCW(Position.TopFrontLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryFront, Position.RotateBackCCW(Position.TopFrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryRight, Position.RotateBackCCW(Position.TopFrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryTop, Position.RotateBackCCW(Position.TopFrontRightPrimaryTop));
            Assert.AreEqual<byte>(Position.Unmasked, Position.RotateBackCCW(Position.Unmasked));
            Assert.AreEqual<byte>(Position.Masked, Position.RotateBackCCW(Position.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_RotateBackHalf_AllCorners()
        {
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryBack, Position.RotateBackHalf(Position.BottomBackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryTop, Position.RotateBackHalf(Position.BottomBackLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryRight, Position.RotateBackHalf(Position.BottomBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryBack, Position.RotateBackHalf(Position.BottomBackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryTop, Position.RotateBackHalf(Position.BottomBackRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryLeft, Position.RotateBackHalf(Position.BottomBackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryBottom, Position.RotateBackHalf(Position.BottomFrontLeftPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryFront, Position.RotateBackHalf(Position.BottomFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryLeft, Position.RotateBackHalf(Position.BottomFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryBottom, Position.RotateBackHalf(Position.BottomFrontRightPrimaryBottom));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryFront, Position.RotateBackHalf(Position.BottomFrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryRight, Position.RotateBackHalf(Position.BottomFrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBack, Position.RotateBackHalf(Position.TopBackLeftPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryRight, Position.RotateBackHalf(Position.TopBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBottom, Position.RotateBackHalf(Position.TopBackLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBack, Position.RotateBackHalf(Position.TopBackRightPrimaryBack));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryLeft, Position.RotateBackHalf(Position.TopBackRightPrimaryRight));
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBottom, Position.RotateBackHalf(Position.TopBackRightPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryFront, Position.RotateBackHalf(Position.TopFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryLeft, Position.RotateBackHalf(Position.TopFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryTop, Position.RotateBackHalf(Position.TopFrontLeftPrimaryTop));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryFront, Position.RotateBackHalf(Position.TopFrontRightPrimaryFront));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryRight, Position.RotateBackHalf(Position.TopFrontRightPrimaryRight));
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryTop, Position.RotateBackHalf(Position.TopFrontRightPrimaryTop));
            Assert.AreEqual<byte>(Position.Unmasked, Position.RotateBackHalf(Position.Unmasked));
            Assert.AreEqual<byte>(Position.Masked, Position.RotateBackHalf(Position.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_Mask_MaskedEdge()
        {
            Assert.AreEqual<byte>(Position.Masked, Position.Mask(Position.TopBackLeftPrimaryLeft, Position.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_Mask_UnmaskedEdge()
        {
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryLeft, Position.Mask(Position.TopBackLeftPrimaryLeft, Position.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        [ExpectedException(typeof(ArgumentException))]
        public void CornerPosition_Mask_BadMask()
        {
            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryLeft, Position.Mask(Position.TopBackLeftPrimaryLeft, Position.TopBackLeftPrimaryLeft));
        }
    }
}
