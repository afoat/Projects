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
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBack, CornerPosition.RotateTopCW(CornerPosition.BottomBackLeftPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBottom, CornerPosition.RotateTopCW(CornerPosition.BottomBackLeftPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryLeft, CornerPosition.RotateTopCW(CornerPosition.BottomBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBack, CornerPosition.RotateTopCW(CornerPosition.BottomBackRightPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBottom, CornerPosition.RotateTopCW(CornerPosition.BottomBackRightPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryRight, CornerPosition.RotateTopCW(CornerPosition.BottomBackRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryBottom, CornerPosition.RotateTopCW(CornerPosition.BottomFrontLeftPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryFront, CornerPosition.RotateTopCW(CornerPosition.BottomFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryLeft, CornerPosition.RotateTopCW(CornerPosition.BottomFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryBottom, CornerPosition.RotateTopCW(CornerPosition.BottomFrontRightPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryFront, CornerPosition.RotateTopCW(CornerPosition.BottomFrontRightPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryRight, CornerPosition.RotateTopCW(CornerPosition.BottomFrontRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryRight, CornerPosition.RotateTopCW(CornerPosition.TopBackLeftPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryBack, CornerPosition.RotateTopCW(CornerPosition.TopBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryTop, CornerPosition.RotateTopCW(CornerPosition.TopBackLeftPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryRight, CornerPosition.RotateTopCW(CornerPosition.TopBackRightPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryFront, CornerPosition.RotateTopCW(CornerPosition.TopBackRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryTop, CornerPosition.RotateTopCW(CornerPosition.TopBackRightPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryLeft, CornerPosition.RotateTopCW(CornerPosition.TopFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryBack, CornerPosition.RotateTopCW(CornerPosition.TopFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryTop, CornerPosition.RotateTopCW(CornerPosition.TopFrontLeftPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryLeft, CornerPosition.RotateTopCW(CornerPosition.TopFrontRightPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryFront, CornerPosition.RotateTopCW(CornerPosition.TopFrontRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryTop, CornerPosition.RotateTopCW(CornerPosition.TopFrontRightPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.Unmasked, CornerPosition.RotateTopCW(CornerPosition.Unmasked));
            Assert.AreEqual<byte>(CornerPosition.Masked, CornerPosition.RotateTopCW(CornerPosition.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_RotateTopCCW_AllCorners()
        {
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBack, CornerPosition.RotateTopCCW(CornerPosition.BottomBackLeftPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBottom, CornerPosition.RotateTopCCW(CornerPosition.BottomBackLeftPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryLeft, CornerPosition.RotateTopCCW(CornerPosition.BottomBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBack, CornerPosition.RotateTopCCW(CornerPosition.BottomBackRightPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBottom, CornerPosition.RotateTopCCW(CornerPosition.BottomBackRightPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryRight, CornerPosition.RotateTopCCW(CornerPosition.BottomBackRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryBottom, CornerPosition.RotateTopCCW(CornerPosition.BottomFrontLeftPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryFront, CornerPosition.RotateTopCCW(CornerPosition.BottomFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryLeft, CornerPosition.RotateTopCCW(CornerPosition.BottomFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryBottom, CornerPosition.RotateTopCCW(CornerPosition.BottomFrontRightPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryFront, CornerPosition.RotateTopCCW(CornerPosition.BottomFrontRightPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryRight, CornerPosition.RotateTopCCW(CornerPosition.BottomFrontRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryLeft, CornerPosition.RotateTopCCW(CornerPosition.TopBackLeftPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryFront, CornerPosition.RotateTopCCW(CornerPosition.TopBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryTop, CornerPosition.RotateTopCCW(CornerPosition.TopBackLeftPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryLeft, CornerPosition.RotateTopCCW(CornerPosition.TopBackRightPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryBack, CornerPosition.RotateTopCCW(CornerPosition.TopBackRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryTop, CornerPosition.RotateTopCCW(CornerPosition.TopBackRightPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryRight, CornerPosition.RotateTopCCW(CornerPosition.TopFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryFront, CornerPosition.RotateTopCCW(CornerPosition.TopFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryTop, CornerPosition.RotateTopCCW(CornerPosition.TopFrontLeftPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryRight, CornerPosition.RotateTopCCW(CornerPosition.TopFrontRightPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryBack, CornerPosition.RotateTopCCW(CornerPosition.TopFrontRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryTop, CornerPosition.RotateTopCCW(CornerPosition.TopFrontRightPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.Unmasked, CornerPosition.RotateTopCCW(CornerPosition.Unmasked));
            Assert.AreEqual<byte>(CornerPosition.Masked, CornerPosition.RotateTopCCW(CornerPosition.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_RotateTopHalf_AllCorners()
        {
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBack, CornerPosition.RotateTopHalf(CornerPosition.BottomBackLeftPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBottom, CornerPosition.RotateTopHalf(CornerPosition.BottomBackLeftPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryLeft, CornerPosition.RotateTopHalf(CornerPosition.BottomBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBack, CornerPosition.RotateTopHalf(CornerPosition.BottomBackRightPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBottom, CornerPosition.RotateTopHalf(CornerPosition.BottomBackRightPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryRight, CornerPosition.RotateTopHalf(CornerPosition.BottomBackRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryBottom, CornerPosition.RotateTopHalf(CornerPosition.BottomFrontLeftPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryFront, CornerPosition.RotateTopHalf(CornerPosition.BottomFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryLeft, CornerPosition.RotateTopHalf(CornerPosition.BottomFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryBottom, CornerPosition.RotateTopHalf(CornerPosition.BottomFrontRightPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryFront, CornerPosition.RotateTopHalf(CornerPosition.BottomFrontRightPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryRight, CornerPosition.RotateTopHalf(CornerPosition.BottomFrontRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryFront, CornerPosition.RotateTopHalf(CornerPosition.TopBackLeftPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryRight, CornerPosition.RotateTopHalf(CornerPosition.TopBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryTop, CornerPosition.RotateTopHalf(CornerPosition.TopBackLeftPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryFront, CornerPosition.RotateTopHalf(CornerPosition.TopBackRightPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryLeft, CornerPosition.RotateTopHalf(CornerPosition.TopBackRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryTop, CornerPosition.RotateTopHalf(CornerPosition.TopBackRightPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryBack, CornerPosition.RotateTopHalf(CornerPosition.TopFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryRight, CornerPosition.RotateTopHalf(CornerPosition.TopFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryTop, CornerPosition.RotateTopHalf(CornerPosition.TopFrontLeftPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryBack, CornerPosition.RotateTopHalf(CornerPosition.TopFrontRightPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryLeft, CornerPosition.RotateTopHalf(CornerPosition.TopFrontRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryTop, CornerPosition.RotateTopHalf(CornerPosition.TopFrontRightPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.Unmasked, CornerPosition.RotateTopHalf(CornerPosition.Unmasked));
            Assert.AreEqual<byte>(CornerPosition.Masked, CornerPosition.RotateTopHalf(CornerPosition.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_RotateBottomCW_AllCorners()
        {
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryLeft, CornerPosition.RotateBottomCW(CornerPosition.BottomBackLeftPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryBottom, CornerPosition.RotateBottomCW(CornerPosition.BottomBackLeftPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryFront, CornerPosition.RotateBottomCW(CornerPosition.BottomBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryLeft, CornerPosition.RotateBottomCW(CornerPosition.BottomBackRightPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBottom, CornerPosition.RotateBottomCW(CornerPosition.BottomBackRightPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBack, CornerPosition.RotateBottomCW(CornerPosition.BottomBackRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryBottom, CornerPosition.RotateBottomCW(CornerPosition.BottomFrontLeftPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryRight, CornerPosition.RotateBottomCW(CornerPosition.BottomFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryFront, CornerPosition.RotateBottomCW(CornerPosition.BottomFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBottom, CornerPosition.RotateBottomCW(CornerPosition.BottomFrontRightPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryRight, CornerPosition.RotateBottomCW(CornerPosition.BottomFrontRightPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBack, CornerPosition.RotateBottomCW(CornerPosition.BottomFrontRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryBack, CornerPosition.RotateBottomCW(CornerPosition.TopBackLeftPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryLeft, CornerPosition.RotateBottomCW(CornerPosition.TopBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryTop, CornerPosition.RotateBottomCW(CornerPosition.TopBackLeftPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryBack, CornerPosition.RotateBottomCW(CornerPosition.TopBackRightPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryRight, CornerPosition.RotateBottomCW(CornerPosition.TopBackRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryTop, CornerPosition.RotateBottomCW(CornerPosition.TopBackRightPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryFront, CornerPosition.RotateBottomCW(CornerPosition.TopFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryLeft, CornerPosition.RotateBottomCW(CornerPosition.TopFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryTop, CornerPosition.RotateBottomCW(CornerPosition.TopFrontLeftPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryFront, CornerPosition.RotateBottomCW(CornerPosition.TopFrontRightPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryRight, CornerPosition.RotateBottomCW(CornerPosition.TopFrontRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryTop, CornerPosition.RotateBottomCW(CornerPosition.TopFrontRightPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.Unmasked, CornerPosition.RotateBottomCW(CornerPosition.Unmasked));
            Assert.AreEqual<byte>(CornerPosition.Masked, CornerPosition.RotateBottomCW(CornerPosition.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_RotateBottomCCW_AllCorners()
        {
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryRight, CornerPosition.RotateBottomCCW(CornerPosition.BottomBackLeftPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBottom, CornerPosition.RotateBottomCCW(CornerPosition.BottomBackLeftPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBack, CornerPosition.RotateBottomCCW(CornerPosition.BottomBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryRight, CornerPosition.RotateBottomCCW(CornerPosition.BottomBackRightPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryBottom, CornerPosition.RotateBottomCCW(CornerPosition.BottomBackRightPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryFront, CornerPosition.RotateBottomCCW(CornerPosition.BottomBackRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBottom, CornerPosition.RotateBottomCCW(CornerPosition.BottomFrontLeftPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryLeft, CornerPosition.RotateBottomCCW(CornerPosition.BottomFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBack, CornerPosition.RotateBottomCCW(CornerPosition.BottomFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryBottom, CornerPosition.RotateBottomCCW(CornerPosition.BottomFrontRightPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryLeft, CornerPosition.RotateBottomCCW(CornerPosition.BottomFrontRightPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryFront, CornerPosition.RotateBottomCCW(CornerPosition.BottomFrontRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryBack, CornerPosition.RotateBottomCCW(CornerPosition.TopBackLeftPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryLeft, CornerPosition.RotateBottomCCW(CornerPosition.TopBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryTop, CornerPosition.RotateBottomCCW(CornerPosition.TopBackLeftPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryBack, CornerPosition.RotateBottomCCW(CornerPosition.TopBackRightPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryRight, CornerPosition.RotateBottomCCW(CornerPosition.TopBackRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryTop, CornerPosition.RotateBottomCCW(CornerPosition.TopBackRightPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryFront, CornerPosition.RotateBottomCCW(CornerPosition.TopFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryLeft, CornerPosition.RotateBottomCCW(CornerPosition.TopFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryTop, CornerPosition.RotateBottomCCW(CornerPosition.TopFrontLeftPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryFront, CornerPosition.RotateBottomCCW(CornerPosition.TopFrontRightPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryRight, CornerPosition.RotateBottomCCW(CornerPosition.TopFrontRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryTop, CornerPosition.RotateBottomCCW(CornerPosition.TopFrontRightPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.Unmasked, CornerPosition.RotateBottomCCW(CornerPosition.Unmasked));
            Assert.AreEqual<byte>(CornerPosition.Masked, CornerPosition.RotateBottomCCW(CornerPosition.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_RotateBottomHalf_AllCorners()
        {
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryFront, CornerPosition.RotateBottomHalf(CornerPosition.BottomBackLeftPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryBottom, CornerPosition.RotateBottomHalf(CornerPosition.BottomBackLeftPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryRight, CornerPosition.RotateBottomHalf(CornerPosition.BottomBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryFront, CornerPosition.RotateBottomHalf(CornerPosition.BottomBackRightPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryBottom, CornerPosition.RotateBottomHalf(CornerPosition.BottomBackRightPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryLeft, CornerPosition.RotateBottomHalf(CornerPosition.BottomBackRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBottom, CornerPosition.RotateBottomHalf(CornerPosition.BottomFrontLeftPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBack, CornerPosition.RotateBottomHalf(CornerPosition.BottomFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryRight, CornerPosition.RotateBottomHalf(CornerPosition.BottomFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBottom, CornerPosition.RotateBottomHalf(CornerPosition.BottomFrontRightPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBack, CornerPosition.RotateBottomHalf(CornerPosition.BottomFrontRightPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryLeft, CornerPosition.RotateBottomHalf(CornerPosition.BottomFrontRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryBack, CornerPosition.RotateBottomHalf(CornerPosition.TopBackLeftPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryLeft, CornerPosition.RotateBottomHalf(CornerPosition.TopBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryTop, CornerPosition.RotateBottomHalf(CornerPosition.TopBackLeftPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryBack, CornerPosition.RotateBottomHalf(CornerPosition.TopBackRightPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryRight, CornerPosition.RotateBottomHalf(CornerPosition.TopBackRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryTop, CornerPosition.RotateBottomHalf(CornerPosition.TopBackRightPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryFront, CornerPosition.RotateBottomHalf(CornerPosition.TopFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryLeft, CornerPosition.RotateBottomHalf(CornerPosition.TopFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryTop, CornerPosition.RotateBottomHalf(CornerPosition.TopFrontLeftPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryFront, CornerPosition.RotateBottomHalf(CornerPosition.TopFrontRightPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryRight, CornerPosition.RotateBottomHalf(CornerPosition.TopFrontRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryTop, CornerPosition.RotateBottomHalf(CornerPosition.TopFrontRightPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.Unmasked, CornerPosition.RotateBottomHalf(CornerPosition.Unmasked));
            Assert.AreEqual<byte>(CornerPosition.Masked, CornerPosition.RotateBottomHalf(CornerPosition.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_RotateLeftCW_AllCorners()
        {
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryTop, CornerPosition.RotateLeftCW(CornerPosition.BottomBackLeftPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryBack, CornerPosition.RotateLeftCW(CornerPosition.BottomBackLeftPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryLeft, CornerPosition.RotateLeftCW(CornerPosition.BottomBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBack, CornerPosition.RotateLeftCW(CornerPosition.BottomBackRightPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBottom, CornerPosition.RotateLeftCW(CornerPosition.BottomBackRightPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryRight, CornerPosition.RotateLeftCW(CornerPosition.BottomBackRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBack, CornerPosition.RotateLeftCW(CornerPosition.BottomFrontLeftPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBottom, CornerPosition.RotateLeftCW(CornerPosition.BottomFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryLeft, CornerPosition.RotateLeftCW(CornerPosition.BottomFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryBottom, CornerPosition.RotateLeftCW(CornerPosition.BottomFrontRightPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryFront, CornerPosition.RotateLeftCW(CornerPosition.BottomFrontRightPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryRight, CornerPosition.RotateLeftCW(CornerPosition.BottomFrontRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryTop, CornerPosition.RotateLeftCW(CornerPosition.TopBackLeftPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryLeft, CornerPosition.RotateLeftCW(CornerPosition.TopBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryFront, CornerPosition.RotateLeftCW(CornerPosition.TopBackLeftPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryBack, CornerPosition.RotateLeftCW(CornerPosition.TopBackRightPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryRight, CornerPosition.RotateLeftCW(CornerPosition.TopBackRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryTop, CornerPosition.RotateLeftCW(CornerPosition.TopBackRightPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryBottom, CornerPosition.RotateLeftCW(CornerPosition.TopFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryLeft, CornerPosition.RotateLeftCW(CornerPosition.TopFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryFront, CornerPosition.RotateLeftCW(CornerPosition.TopFrontLeftPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryFront, CornerPosition.RotateLeftCW(CornerPosition.TopFrontRightPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryRight, CornerPosition.RotateLeftCW(CornerPosition.TopFrontRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryTop, CornerPosition.RotateLeftCW(CornerPosition.TopFrontRightPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.Unmasked, CornerPosition.RotateLeftCW(CornerPosition.Unmasked));
            Assert.AreEqual<byte>(CornerPosition.Masked, CornerPosition.RotateLeftCW(CornerPosition.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_RotateLeftCCW_AllCorners()
        {
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryBottom, CornerPosition.RotateLeftCCW(CornerPosition.BottomBackLeftPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryFront, CornerPosition.RotateLeftCCW(CornerPosition.BottomBackLeftPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryLeft, CornerPosition.RotateLeftCCW(CornerPosition.BottomBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBack, CornerPosition.RotateLeftCCW(CornerPosition.BottomBackRightPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBottom, CornerPosition.RotateLeftCCW(CornerPosition.BottomBackRightPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryRight, CornerPosition.RotateLeftCCW(CornerPosition.BottomBackRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryFront, CornerPosition.RotateLeftCCW(CornerPosition.BottomFrontLeftPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryTop, CornerPosition.RotateLeftCCW(CornerPosition.BottomFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryLeft, CornerPosition.RotateLeftCCW(CornerPosition.BottomFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryBottom, CornerPosition.RotateLeftCCW(CornerPosition.BottomFrontRightPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryFront, CornerPosition.RotateLeftCCW(CornerPosition.BottomFrontRightPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryRight, CornerPosition.RotateLeftCCW(CornerPosition.BottomFrontRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBottom, CornerPosition.RotateLeftCCW(CornerPosition.TopBackLeftPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryLeft, CornerPosition.RotateLeftCCW(CornerPosition.TopBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBack, CornerPosition.RotateLeftCCW(CornerPosition.TopBackLeftPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryBack, CornerPosition.RotateLeftCCW(CornerPosition.TopBackRightPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryRight, CornerPosition.RotateLeftCCW(CornerPosition.TopBackRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryTop, CornerPosition.RotateLeftCCW(CornerPosition.TopBackRightPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryTop, CornerPosition.RotateLeftCCW(CornerPosition.TopFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryLeft, CornerPosition.RotateLeftCCW(CornerPosition.TopFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryBack, CornerPosition.RotateLeftCCW(CornerPosition.TopFrontLeftPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryFront, CornerPosition.RotateLeftCCW(CornerPosition.TopFrontRightPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryRight, CornerPosition.RotateLeftCCW(CornerPosition.TopFrontRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryTop, CornerPosition.RotateLeftCCW(CornerPosition.TopFrontRightPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.Unmasked, CornerPosition.RotateLeftCCW(CornerPosition.Unmasked));
            Assert.AreEqual<byte>(CornerPosition.Masked, CornerPosition.RotateLeftCCW(CornerPosition.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_RotateLeftHalf_AllCorners()
        {
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryFront, CornerPosition.RotateLeftHalf(CornerPosition.BottomBackLeftPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryTop, CornerPosition.RotateLeftHalf(CornerPosition.BottomBackLeftPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryLeft, CornerPosition.RotateLeftHalf(CornerPosition.BottomBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBack, CornerPosition.RotateLeftHalf(CornerPosition.BottomBackRightPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBottom, CornerPosition.RotateLeftHalf(CornerPosition.BottomBackRightPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryRight, CornerPosition.RotateLeftHalf(CornerPosition.BottomBackRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryTop, CornerPosition.RotateLeftHalf(CornerPosition.BottomFrontLeftPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryBack, CornerPosition.RotateLeftHalf(CornerPosition.BottomFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryLeft, CornerPosition.RotateLeftHalf(CornerPosition.BottomFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryBottom, CornerPosition.RotateLeftHalf(CornerPosition.BottomFrontRightPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryFront, CornerPosition.RotateLeftHalf(CornerPosition.BottomFrontRightPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryRight, CornerPosition.RotateLeftHalf(CornerPosition.BottomFrontRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryFront, CornerPosition.RotateLeftHalf(CornerPosition.TopBackLeftPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryLeft, CornerPosition.RotateLeftHalf(CornerPosition.TopBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryBottom, CornerPosition.RotateLeftHalf(CornerPosition.TopBackLeftPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryBack, CornerPosition.RotateLeftHalf(CornerPosition.TopBackRightPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryRight, CornerPosition.RotateLeftHalf(CornerPosition.TopBackRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryTop, CornerPosition.RotateLeftHalf(CornerPosition.TopBackRightPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBack, CornerPosition.RotateLeftHalf(CornerPosition.TopFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryLeft, CornerPosition.RotateLeftHalf(CornerPosition.TopFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBottom, CornerPosition.RotateLeftHalf(CornerPosition.TopFrontLeftPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryFront, CornerPosition.RotateLeftHalf(CornerPosition.TopFrontRightPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryRight, CornerPosition.RotateLeftHalf(CornerPosition.TopFrontRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryTop, CornerPosition.RotateLeftHalf(CornerPosition.TopFrontRightPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.Unmasked, CornerPosition.RotateLeftHalf(CornerPosition.Unmasked));
            Assert.AreEqual<byte>(CornerPosition.Masked, CornerPosition.RotateLeftHalf(CornerPosition.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_RotateRightCW_AllCorners()
        {
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBack, CornerPosition.RotateRightCW(CornerPosition.BottomBackLeftPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBottom, CornerPosition.RotateRightCW(CornerPosition.BottomBackLeftPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryLeft, CornerPosition.RotateRightCW(CornerPosition.BottomBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryBottom, CornerPosition.RotateRightCW(CornerPosition.BottomBackRightPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryFront, CornerPosition.RotateRightCW(CornerPosition.BottomBackRightPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryRight, CornerPosition.RotateRightCW(CornerPosition.BottomBackRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryBottom, CornerPosition.RotateRightCW(CornerPosition.BottomFrontLeftPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryFront, CornerPosition.RotateRightCW(CornerPosition.BottomFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryLeft, CornerPosition.RotateRightCW(CornerPosition.BottomFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryFront, CornerPosition.RotateRightCW(CornerPosition.BottomFrontRightPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryTop, CornerPosition.RotateRightCW(CornerPosition.BottomFrontRightPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryRight, CornerPosition.RotateRightCW(CornerPosition.BottomFrontRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryBack, CornerPosition.RotateRightCW(CornerPosition.TopBackLeftPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryLeft, CornerPosition.RotateRightCW(CornerPosition.TopBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryTop, CornerPosition.RotateRightCW(CornerPosition.TopBackLeftPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBottom, CornerPosition.RotateRightCW(CornerPosition.TopBackRightPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryRight, CornerPosition.RotateRightCW(CornerPosition.TopBackRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBack, CornerPosition.RotateRightCW(CornerPosition.TopBackRightPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryFront, CornerPosition.RotateRightCW(CornerPosition.TopFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryLeft, CornerPosition.RotateRightCW(CornerPosition.TopFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryTop, CornerPosition.RotateRightCW(CornerPosition.TopFrontLeftPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryTop, CornerPosition.RotateRightCW(CornerPosition.TopFrontRightPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryRight, CornerPosition.RotateRightCW(CornerPosition.TopFrontRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryBack, CornerPosition.RotateRightCW(CornerPosition.TopFrontRightPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.Unmasked, CornerPosition.RotateRightCW(CornerPosition.Unmasked));
            Assert.AreEqual<byte>(CornerPosition.Masked, CornerPosition.RotateRightCW(CornerPosition.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_RotateRightCCW_AllCorners()
        {
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBack, CornerPosition.RotateRightCCW(CornerPosition.BottomBackLeftPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBottom, CornerPosition.RotateRightCCW(CornerPosition.BottomBackLeftPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryLeft, CornerPosition.RotateRightCCW(CornerPosition.BottomBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryTop, CornerPosition.RotateRightCCW(CornerPosition.BottomBackRightPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryBack, CornerPosition.RotateRightCCW(CornerPosition.BottomBackRightPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryRight, CornerPosition.RotateRightCCW(CornerPosition.BottomBackRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryBottom, CornerPosition.RotateRightCCW(CornerPosition.BottomFrontLeftPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryFront, CornerPosition.RotateRightCCW(CornerPosition.BottomFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryLeft, CornerPosition.RotateRightCCW(CornerPosition.BottomFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBack, CornerPosition.RotateRightCCW(CornerPosition.BottomFrontRightPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBottom, CornerPosition.RotateRightCCW(CornerPosition.BottomFrontRightPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryRight, CornerPosition.RotateRightCCW(CornerPosition.BottomFrontRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryBack, CornerPosition.RotateRightCCW(CornerPosition.TopBackLeftPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryLeft, CornerPosition.RotateRightCCW(CornerPosition.TopBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryTop, CornerPosition.RotateRightCCW(CornerPosition.TopBackLeftPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryTop, CornerPosition.RotateRightCCW(CornerPosition.TopBackRightPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryRight, CornerPosition.RotateRightCCW(CornerPosition.TopBackRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryFront, CornerPosition.RotateRightCCW(CornerPosition.TopBackRightPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryFront, CornerPosition.RotateRightCCW(CornerPosition.TopFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryLeft, CornerPosition.RotateRightCCW(CornerPosition.TopFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryTop, CornerPosition.RotateRightCCW(CornerPosition.TopFrontLeftPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryBottom, CornerPosition.RotateRightCCW(CornerPosition.TopFrontRightPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryRight, CornerPosition.RotateRightCCW(CornerPosition.TopFrontRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryFront, CornerPosition.RotateRightCCW(CornerPosition.TopFrontRightPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.Unmasked, CornerPosition.RotateRightCCW(CornerPosition.Unmasked));
            Assert.AreEqual<byte>(CornerPosition.Masked, CornerPosition.RotateRightCCW(CornerPosition.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_RotateRightHalf_AllCorners()
        {
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBack, CornerPosition.RotateRightHalf(CornerPosition.BottomBackLeftPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBottom, CornerPosition.RotateRightHalf(CornerPosition.BottomBackLeftPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryLeft, CornerPosition.RotateRightHalf(CornerPosition.BottomBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryFront, CornerPosition.RotateRightHalf(CornerPosition.BottomBackRightPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryTop, CornerPosition.RotateRightHalf(CornerPosition.BottomBackRightPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryRight, CornerPosition.RotateRightHalf(CornerPosition.BottomBackRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryBottom, CornerPosition.RotateRightHalf(CornerPosition.BottomFrontLeftPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryFront, CornerPosition.RotateRightHalf(CornerPosition.BottomFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryLeft, CornerPosition.RotateRightHalf(CornerPosition.BottomFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryTop, CornerPosition.RotateRightHalf(CornerPosition.BottomFrontRightPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryBack, CornerPosition.RotateRightHalf(CornerPosition.BottomFrontRightPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryRight, CornerPosition.RotateRightHalf(CornerPosition.BottomFrontRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryBack, CornerPosition.RotateRightHalf(CornerPosition.TopBackLeftPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryLeft, CornerPosition.RotateRightHalf(CornerPosition.TopBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryTop, CornerPosition.RotateRightHalf(CornerPosition.TopBackLeftPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryFront, CornerPosition.RotateRightHalf(CornerPosition.TopBackRightPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryRight, CornerPosition.RotateRightHalf(CornerPosition.TopBackRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryBottom, CornerPosition.RotateRightHalf(CornerPosition.TopBackRightPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryFront, CornerPosition.RotateRightHalf(CornerPosition.TopFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryLeft, CornerPosition.RotateRightHalf(CornerPosition.TopFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryTop, CornerPosition.RotateRightHalf(CornerPosition.TopFrontLeftPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBack, CornerPosition.RotateRightHalf(CornerPosition.TopFrontRightPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryRight, CornerPosition.RotateRightHalf(CornerPosition.TopFrontRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBottom, CornerPosition.RotateRightHalf(CornerPosition.TopFrontRightPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.Unmasked, CornerPosition.RotateRightHalf(CornerPosition.Unmasked));
            Assert.AreEqual<byte>(CornerPosition.Masked, CornerPosition.RotateRightHalf(CornerPosition.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_RotateFrontCW_AllCorners()
        {
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBack, CornerPosition.RotateFrontCW(CornerPosition.BottomBackLeftPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBottom, CornerPosition.RotateFrontCW(CornerPosition.BottomBackLeftPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryLeft, CornerPosition.RotateFrontCW(CornerPosition.BottomBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBack, CornerPosition.RotateFrontCW(CornerPosition.BottomBackRightPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBottom, CornerPosition.RotateFrontCW(CornerPosition.BottomBackRightPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryRight, CornerPosition.RotateFrontCW(CornerPosition.BottomBackRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryLeft, CornerPosition.RotateFrontCW(CornerPosition.BottomFrontLeftPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryFront, CornerPosition.RotateFrontCW(CornerPosition.BottomFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryTop, CornerPosition.RotateFrontCW(CornerPosition.BottomFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryLeft, CornerPosition.RotateFrontCW(CornerPosition.BottomFrontRightPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryFront, CornerPosition.RotateFrontCW(CornerPosition.BottomFrontRightPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryBottom, CornerPosition.RotateFrontCW(CornerPosition.BottomFrontRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryBack, CornerPosition.RotateFrontCW(CornerPosition.TopBackLeftPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryLeft, CornerPosition.RotateFrontCW(CornerPosition.TopBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryTop, CornerPosition.RotateFrontCW(CornerPosition.TopBackLeftPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryBack, CornerPosition.RotateFrontCW(CornerPosition.TopBackRightPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryRight, CornerPosition.RotateFrontCW(CornerPosition.TopBackRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryTop, CornerPosition.RotateFrontCW(CornerPosition.TopBackRightPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryFront, CornerPosition.RotateFrontCW(CornerPosition.TopFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryTop, CornerPosition.RotateFrontCW(CornerPosition.TopFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryRight, CornerPosition.RotateFrontCW(CornerPosition.TopFrontLeftPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryFront, CornerPosition.RotateFrontCW(CornerPosition.TopFrontRightPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryBottom, CornerPosition.RotateFrontCW(CornerPosition.TopFrontRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryRight, CornerPosition.RotateFrontCW(CornerPosition.TopFrontRightPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.Unmasked, CornerPosition.RotateFrontCW(CornerPosition.Unmasked));
            Assert.AreEqual<byte>(CornerPosition.Masked, CornerPosition.RotateFrontCW(CornerPosition.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_RotateFrontCCW_AllCorners()
        {
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBack, CornerPosition.RotateFrontCCW(CornerPosition.BottomBackLeftPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBottom, CornerPosition.RotateFrontCCW(CornerPosition.BottomBackLeftPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryLeft, CornerPosition.RotateFrontCCW(CornerPosition.BottomBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBack, CornerPosition.RotateFrontCCW(CornerPosition.BottomBackRightPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBottom, CornerPosition.RotateFrontCCW(CornerPosition.BottomBackRightPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryRight, CornerPosition.RotateFrontCCW(CornerPosition.BottomBackRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryRight, CornerPosition.RotateFrontCCW(CornerPosition.BottomFrontLeftPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryFront, CornerPosition.RotateFrontCCW(CornerPosition.BottomFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryBottom, CornerPosition.RotateFrontCCW(CornerPosition.BottomFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryRight, CornerPosition.RotateFrontCCW(CornerPosition.BottomFrontRightPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryFront, CornerPosition.RotateFrontCCW(CornerPosition.BottomFrontRightPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryTop, CornerPosition.RotateFrontCCW(CornerPosition.BottomFrontRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryBack, CornerPosition.RotateFrontCCW(CornerPosition.TopBackLeftPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryLeft, CornerPosition.RotateFrontCCW(CornerPosition.TopBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryTop, CornerPosition.RotateFrontCCW(CornerPosition.TopBackLeftPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryBack, CornerPosition.RotateFrontCCW(CornerPosition.TopBackRightPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryRight, CornerPosition.RotateFrontCCW(CornerPosition.TopBackRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryTop, CornerPosition.RotateFrontCCW(CornerPosition.TopBackRightPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryFront, CornerPosition.RotateFrontCCW(CornerPosition.TopFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryBottom, CornerPosition.RotateFrontCCW(CornerPosition.TopFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryLeft, CornerPosition.RotateFrontCCW(CornerPosition.TopFrontLeftPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryFront, CornerPosition.RotateFrontCCW(CornerPosition.TopFrontRightPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryTop, CornerPosition.RotateFrontCCW(CornerPosition.TopFrontRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryLeft, CornerPosition.RotateFrontCCW(CornerPosition.TopFrontRightPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.Unmasked, CornerPosition.RotateFrontCCW(CornerPosition.Unmasked));
            Assert.AreEqual<byte>(CornerPosition.Masked, CornerPosition.RotateFrontCCW(CornerPosition.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_RotateFrontHalf_AllCorners()
        {
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBack, CornerPosition.RotateFrontHalf(CornerPosition.BottomBackLeftPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBottom, CornerPosition.RotateFrontHalf(CornerPosition.BottomBackLeftPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryLeft, CornerPosition.RotateFrontHalf(CornerPosition.BottomBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBack, CornerPosition.RotateFrontHalf(CornerPosition.BottomBackRightPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBottom, CornerPosition.RotateFrontHalf(CornerPosition.BottomBackRightPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryRight, CornerPosition.RotateFrontHalf(CornerPosition.BottomBackRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryTop, CornerPosition.RotateFrontHalf(CornerPosition.BottomFrontLeftPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryFront, CornerPosition.RotateFrontHalf(CornerPosition.BottomFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryRight, CornerPosition.RotateFrontHalf(CornerPosition.BottomFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryTop, CornerPosition.RotateFrontHalf(CornerPosition.BottomFrontRightPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryFront, CornerPosition.RotateFrontHalf(CornerPosition.BottomFrontRightPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryLeft, CornerPosition.RotateFrontHalf(CornerPosition.BottomFrontRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryBack, CornerPosition.RotateFrontHalf(CornerPosition.TopBackLeftPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryLeft, CornerPosition.RotateFrontHalf(CornerPosition.TopBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryTop, CornerPosition.RotateFrontHalf(CornerPosition.TopBackLeftPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryBack, CornerPosition.RotateFrontHalf(CornerPosition.TopBackRightPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryRight, CornerPosition.RotateFrontHalf(CornerPosition.TopBackRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryTop, CornerPosition.RotateFrontHalf(CornerPosition.TopBackRightPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryFront, CornerPosition.RotateFrontHalf(CornerPosition.TopFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryRight, CornerPosition.RotateFrontHalf(CornerPosition.TopFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryBottom, CornerPosition.RotateFrontHalf(CornerPosition.TopFrontLeftPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryFront, CornerPosition.RotateFrontHalf(CornerPosition.TopFrontRightPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryLeft, CornerPosition.RotateFrontHalf(CornerPosition.TopFrontRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryBottom, CornerPosition.RotateFrontHalf(CornerPosition.TopFrontRightPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.Unmasked, CornerPosition.RotateFrontHalf(CornerPosition.Unmasked));
            Assert.AreEqual<byte>(CornerPosition.Masked, CornerPosition.RotateFrontHalf(CornerPosition.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_RotateBackCW_AllCorners()
        {
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBack, CornerPosition.RotateBackCW(CornerPosition.BottomBackLeftPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryRight, CornerPosition.RotateBackCW(CornerPosition.BottomBackLeftPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBottom, CornerPosition.RotateBackCW(CornerPosition.BottomBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryBack, CornerPosition.RotateBackCW(CornerPosition.BottomBackRightPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryRight, CornerPosition.RotateBackCW(CornerPosition.BottomBackRightPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryTop, CornerPosition.RotateBackCW(CornerPosition.BottomBackRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryBottom, CornerPosition.RotateBackCW(CornerPosition.BottomFrontLeftPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryFront, CornerPosition.RotateBackCW(CornerPosition.BottomFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryLeft, CornerPosition.RotateBackCW(CornerPosition.BottomFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryBottom, CornerPosition.RotateBackCW(CornerPosition.BottomFrontRightPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryFront, CornerPosition.RotateBackCW(CornerPosition.BottomFrontRightPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryRight, CornerPosition.RotateBackCW(CornerPosition.BottomFrontRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBack, CornerPosition.RotateBackCW(CornerPosition.TopBackLeftPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBottom, CornerPosition.RotateBackCW(CornerPosition.TopBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryLeft, CornerPosition.RotateBackCW(CornerPosition.TopBackLeftPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryBack, CornerPosition.RotateBackCW(CornerPosition.TopBackRightPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryTop, CornerPosition.RotateBackCW(CornerPosition.TopBackRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryLeft, CornerPosition.RotateBackCW(CornerPosition.TopBackRightPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryFront, CornerPosition.RotateBackCW(CornerPosition.TopFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryLeft, CornerPosition.RotateBackCW(CornerPosition.TopFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryTop, CornerPosition.RotateBackCW(CornerPosition.TopFrontLeftPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryFront, CornerPosition.RotateBackCW(CornerPosition.TopFrontRightPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryRight, CornerPosition.RotateBackCW(CornerPosition.TopFrontRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryTop, CornerPosition.RotateBackCW(CornerPosition.TopFrontRightPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.Unmasked, CornerPosition.RotateBackCW(CornerPosition.Unmasked));
            Assert.AreEqual<byte>(CornerPosition.Masked, CornerPosition.RotateBackCW(CornerPosition.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_RotateBackCCW_AllCorners()
        {
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryBack, CornerPosition.RotateBackCCW(CornerPosition.BottomBackLeftPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryLeft, CornerPosition.RotateBackCCW(CornerPosition.BottomBackLeftPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryTop, CornerPosition.RotateBackCCW(CornerPosition.BottomBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBack, CornerPosition.RotateBackCCW(CornerPosition.BottomBackRightPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryLeft, CornerPosition.RotateBackCCW(CornerPosition.BottomBackRightPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBottom, CornerPosition.RotateBackCCW(CornerPosition.BottomBackRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryBottom, CornerPosition.RotateBackCCW(CornerPosition.BottomFrontLeftPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryFront, CornerPosition.RotateBackCCW(CornerPosition.BottomFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryLeft, CornerPosition.RotateBackCCW(CornerPosition.BottomFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryBottom, CornerPosition.RotateBackCCW(CornerPosition.BottomFrontRightPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryFront, CornerPosition.RotateBackCCW(CornerPosition.BottomFrontRightPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryRight, CornerPosition.RotateBackCCW(CornerPosition.BottomFrontRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryBack, CornerPosition.RotateBackCCW(CornerPosition.TopBackLeftPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryTop, CornerPosition.RotateBackCCW(CornerPosition.TopBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryRight, CornerPosition.RotateBackCCW(CornerPosition.TopBackLeftPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBack, CornerPosition.RotateBackCCW(CornerPosition.TopBackRightPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBottom, CornerPosition.RotateBackCCW(CornerPosition.TopBackRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryRight, CornerPosition.RotateBackCCW(CornerPosition.TopBackRightPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryFront, CornerPosition.RotateBackCCW(CornerPosition.TopFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryLeft, CornerPosition.RotateBackCCW(CornerPosition.TopFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryTop, CornerPosition.RotateBackCCW(CornerPosition.TopFrontLeftPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryFront, CornerPosition.RotateBackCCW(CornerPosition.TopFrontRightPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryRight, CornerPosition.RotateBackCCW(CornerPosition.TopFrontRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryTop, CornerPosition.RotateBackCCW(CornerPosition.TopFrontRightPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.Unmasked, CornerPosition.RotateBackCCW(CornerPosition.Unmasked));
            Assert.AreEqual<byte>(CornerPosition.Masked, CornerPosition.RotateBackCCW(CornerPosition.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_RotateBackHalf_AllCorners()
        {
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryBack, CornerPosition.RotateBackHalf(CornerPosition.BottomBackLeftPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryTop, CornerPosition.RotateBackHalf(CornerPosition.BottomBackLeftPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryRight, CornerPosition.RotateBackHalf(CornerPosition.BottomBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryBack, CornerPosition.RotateBackHalf(CornerPosition.BottomBackRightPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryTop, CornerPosition.RotateBackHalf(CornerPosition.BottomBackRightPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryLeft, CornerPosition.RotateBackHalf(CornerPosition.BottomBackRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryBottom, CornerPosition.RotateBackHalf(CornerPosition.BottomFrontLeftPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryFront, CornerPosition.RotateBackHalf(CornerPosition.BottomFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontLeftPrimaryLeft, CornerPosition.RotateBackHalf(CornerPosition.BottomFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryBottom, CornerPosition.RotateBackHalf(CornerPosition.BottomFrontRightPrimaryBottom));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryFront, CornerPosition.RotateBackHalf(CornerPosition.BottomFrontRightPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryRight, CornerPosition.RotateBackHalf(CornerPosition.BottomFrontRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBack, CornerPosition.RotateBackHalf(CornerPosition.TopBackLeftPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryRight, CornerPosition.RotateBackHalf(CornerPosition.TopBackLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBottom, CornerPosition.RotateBackHalf(CornerPosition.TopBackLeftPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBack, CornerPosition.RotateBackHalf(CornerPosition.TopBackRightPrimaryBack));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryLeft, CornerPosition.RotateBackHalf(CornerPosition.TopBackRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBottom, CornerPosition.RotateBackHalf(CornerPosition.TopBackRightPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryFront, CornerPosition.RotateBackHalf(CornerPosition.TopFrontLeftPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryLeft, CornerPosition.RotateBackHalf(CornerPosition.TopFrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryTop, CornerPosition.RotateBackHalf(CornerPosition.TopFrontLeftPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryFront, CornerPosition.RotateBackHalf(CornerPosition.TopFrontRightPrimaryFront));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryRight, CornerPosition.RotateBackHalf(CornerPosition.TopFrontRightPrimaryRight));
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryTop, CornerPosition.RotateBackHalf(CornerPosition.TopFrontRightPrimaryTop));
            Assert.AreEqual<byte>(CornerPosition.Unmasked, CornerPosition.RotateBackHalf(CornerPosition.Unmasked));
            Assert.AreEqual<byte>(CornerPosition.Masked, CornerPosition.RotateBackHalf(CornerPosition.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_Mask_MaskedEdge()
        {
            Assert.AreEqual<byte>(CornerPosition.Masked, CornerPosition.Mask(CornerPosition.TopBackLeftPrimaryLeft, CornerPosition.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void CornerPosition_Mask_UnmaskedEdge()
        {
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryLeft, CornerPosition.Mask(CornerPosition.TopBackLeftPrimaryLeft, CornerPosition.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        [ExpectedException(typeof(ArgumentException))]
        public void CornerPosition_Mask_BadMask()
        {
            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryLeft, CornerPosition.Mask(CornerPosition.TopBackLeftPrimaryLeft, CornerPosition.TopBackLeftPrimaryLeft));
        }
    }
}
