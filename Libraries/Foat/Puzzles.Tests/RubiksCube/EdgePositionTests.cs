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
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryBack, EdgePosition.RotateTopCW(EdgePosition.BackLeftPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryLeft, EdgePosition.RotateTopCW(EdgePosition.BackLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryBack, EdgePosition.RotateTopCW(EdgePosition.BackRightPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryRight, EdgePosition.RotateTopCW(EdgePosition.BackRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBack, EdgePosition.RotateTopCW(EdgePosition.BottomBackPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBottom, EdgePosition.RotateTopCW(EdgePosition.BottomBackPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryBottom, EdgePosition.RotateTopCW(EdgePosition.BottomFrontPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryFront, EdgePosition.RotateTopCW(EdgePosition.BottomFrontPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryBottom, EdgePosition.RotateTopCW(EdgePosition.BottomLeftPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryLeft, EdgePosition.RotateTopCW(EdgePosition.BottomLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryBottom, EdgePosition.RotateTopCW(EdgePosition.BottomRightPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryRight, EdgePosition.RotateTopCW(EdgePosition.BottomRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryFront, EdgePosition.RotateTopCW(EdgePosition.FrontLeftPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryLeft, EdgePosition.RotateTopCW(EdgePosition.FrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryFront, EdgePosition.RotateTopCW(EdgePosition.FrontRightPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryRight, EdgePosition.RotateTopCW(EdgePosition.FrontRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryRight, EdgePosition.RotateTopCW(EdgePosition.TopBackPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryTop, EdgePosition.RotateTopCW(EdgePosition.TopBackPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryLeft, EdgePosition.RotateTopCW(EdgePosition.TopFrontPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryTop, EdgePosition.RotateTopCW(EdgePosition.TopFrontPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryBack, EdgePosition.RotateTopCW(EdgePosition.TopLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryTop, EdgePosition.RotateTopCW(EdgePosition.TopLeftPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryFront, EdgePosition.RotateTopCW(EdgePosition.TopRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryTop, EdgePosition.RotateTopCW(EdgePosition.TopRightPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.Masked, EdgePosition.RotateTopCW(EdgePosition.Masked));
            Assert.AreEqual<byte>(EdgePosition.Unmasked, EdgePosition.RotateTopCW(EdgePosition.Unmasked));
        }
        
        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_RotateTopCCW_AllEdges()
        {
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryBack, EdgePosition.RotateTopCCW(EdgePosition.BackLeftPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryLeft, EdgePosition.RotateTopCCW(EdgePosition.BackLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryBack, EdgePosition.RotateTopCCW(EdgePosition.BackRightPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryRight, EdgePosition.RotateTopCCW(EdgePosition.BackRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBack, EdgePosition.RotateTopCCW(EdgePosition.BottomBackPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBottom, EdgePosition.RotateTopCCW(EdgePosition.BottomBackPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryBottom, EdgePosition.RotateTopCCW(EdgePosition.BottomFrontPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryFront, EdgePosition.RotateTopCCW(EdgePosition.BottomFrontPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryBottom, EdgePosition.RotateTopCCW(EdgePosition.BottomLeftPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryLeft, EdgePosition.RotateTopCCW(EdgePosition.BottomLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryBottom, EdgePosition.RotateTopCCW(EdgePosition.BottomRightPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryRight, EdgePosition.RotateTopCCW(EdgePosition.BottomRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryFront, EdgePosition.RotateTopCCW(EdgePosition.FrontLeftPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryLeft, EdgePosition.RotateTopCCW(EdgePosition.FrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryFront, EdgePosition.RotateTopCCW(EdgePosition.FrontRightPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryRight, EdgePosition.RotateTopCCW(EdgePosition.FrontRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryLeft, EdgePosition.RotateTopCCW(EdgePosition.TopBackPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryTop, EdgePosition.RotateTopCCW(EdgePosition.TopBackPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryRight, EdgePosition.RotateTopCCW(EdgePosition.TopFrontPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryTop, EdgePosition.RotateTopCCW(EdgePosition.TopFrontPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryFront, EdgePosition.RotateTopCCW(EdgePosition.TopLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryTop, EdgePosition.RotateTopCCW(EdgePosition.TopLeftPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryBack, EdgePosition.RotateTopCCW(EdgePosition.TopRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryTop, EdgePosition.RotateTopCCW(EdgePosition.TopRightPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.Masked, EdgePosition.RotateTopCCW(EdgePosition.Masked));
            Assert.AreEqual<byte>(EdgePosition.Unmasked, EdgePosition.RotateTopCCW(EdgePosition.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_RotateTopHalf_AllEdges()
        {
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryBack, EdgePosition.RotateTopHalf(EdgePosition.BackLeftPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryLeft, EdgePosition.RotateTopHalf(EdgePosition.BackLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryBack, EdgePosition.RotateTopHalf(EdgePosition.BackRightPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryRight, EdgePosition.RotateTopHalf(EdgePosition.BackRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBack, EdgePosition.RotateTopHalf(EdgePosition.BottomBackPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBottom, EdgePosition.RotateTopHalf(EdgePosition.BottomBackPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryBottom, EdgePosition.RotateTopHalf(EdgePosition.BottomFrontPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryFront, EdgePosition.RotateTopHalf(EdgePosition.BottomFrontPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryBottom, EdgePosition.RotateTopHalf(EdgePosition.BottomLeftPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryLeft, EdgePosition.RotateTopHalf(EdgePosition.BottomLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryBottom, EdgePosition.RotateTopHalf(EdgePosition.BottomRightPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryRight, EdgePosition.RotateTopHalf(EdgePosition.BottomRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryFront, EdgePosition.RotateTopHalf(EdgePosition.FrontLeftPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryLeft, EdgePosition.RotateTopHalf(EdgePosition.FrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryFront, EdgePosition.RotateTopHalf(EdgePosition.FrontRightPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryRight, EdgePosition.RotateTopHalf(EdgePosition.FrontRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryFront, EdgePosition.RotateTopHalf(EdgePosition.TopBackPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryTop, EdgePosition.RotateTopHalf(EdgePosition.TopBackPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryBack, EdgePosition.RotateTopHalf(EdgePosition.TopFrontPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryTop, EdgePosition.RotateTopHalf(EdgePosition.TopFrontPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryRight, EdgePosition.RotateTopHalf(EdgePosition.TopLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryTop, EdgePosition.RotateTopHalf(EdgePosition.TopLeftPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryLeft, EdgePosition.RotateTopHalf(EdgePosition.TopRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryTop, EdgePosition.RotateTopHalf(EdgePosition.TopRightPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.Masked, EdgePosition.RotateTopHalf(EdgePosition.Masked));
            Assert.AreEqual<byte>(EdgePosition.Unmasked, EdgePosition.RotateTopHalf(EdgePosition.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_RotateBottomCW_AllEdges()
        {
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryBack, EdgePosition.RotateBottomCW(EdgePosition.BackLeftPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryLeft, EdgePosition.RotateBottomCW(EdgePosition.BackLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryBack, EdgePosition.RotateBottomCW(EdgePosition.BackRightPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryRight, EdgePosition.RotateBottomCW(EdgePosition.BackRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryLeft, EdgePosition.RotateBottomCW(EdgePosition.BottomBackPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryBottom, EdgePosition.RotateBottomCW(EdgePosition.BottomBackPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryBottom, EdgePosition.RotateBottomCW(EdgePosition.BottomFrontPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryRight, EdgePosition.RotateBottomCW(EdgePosition.BottomFrontPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryBottom, EdgePosition.RotateBottomCW(EdgePosition.BottomLeftPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryFront, EdgePosition.RotateBottomCW(EdgePosition.BottomLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBottom, EdgePosition.RotateBottomCW(EdgePosition.BottomRightPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBack, EdgePosition.RotateBottomCW(EdgePosition.BottomRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryFront, EdgePosition.RotateBottomCW(EdgePosition.FrontLeftPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryLeft, EdgePosition.RotateBottomCW(EdgePosition.FrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryFront, EdgePosition.RotateBottomCW(EdgePosition.FrontRightPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryRight, EdgePosition.RotateBottomCW(EdgePosition.FrontRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryBack, EdgePosition.RotateBottomCW(EdgePosition.TopBackPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryTop, EdgePosition.RotateBottomCW(EdgePosition.TopBackPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryFront, EdgePosition.RotateBottomCW(EdgePosition.TopFrontPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryTop, EdgePosition.RotateBottomCW(EdgePosition.TopFrontPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryLeft, EdgePosition.RotateBottomCW(EdgePosition.TopLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryTop, EdgePosition.RotateBottomCW(EdgePosition.TopLeftPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryRight, EdgePosition.RotateBottomCW(EdgePosition.TopRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryTop, EdgePosition.RotateBottomCW(EdgePosition.TopRightPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.Masked, EdgePosition.RotateBottomCW(EdgePosition.Masked));
            Assert.AreEqual<byte>(EdgePosition.Unmasked, EdgePosition.RotateBottomCW(EdgePosition.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_RotateBottomCCW_AllEdges()
        {
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryBack, EdgePosition.RotateBottomCCW(EdgePosition.BackLeftPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryLeft, EdgePosition.RotateBottomCCW(EdgePosition.BackLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryBack, EdgePosition.RotateBottomCCW(EdgePosition.BackRightPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryRight, EdgePosition.RotateBottomCCW(EdgePosition.BackRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryRight, EdgePosition.RotateBottomCCW(EdgePosition.BottomBackPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryBottom, EdgePosition.RotateBottomCCW(EdgePosition.BottomBackPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryBottom, EdgePosition.RotateBottomCCW(EdgePosition.BottomFrontPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryLeft, EdgePosition.RotateBottomCCW(EdgePosition.BottomFrontPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBottom, EdgePosition.RotateBottomCCW(EdgePosition.BottomLeftPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBack, EdgePosition.RotateBottomCCW(EdgePosition.BottomLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryBottom, EdgePosition.RotateBottomCCW(EdgePosition.BottomRightPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryFront, EdgePosition.RotateBottomCCW(EdgePosition.BottomRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryFront, EdgePosition.RotateBottomCCW(EdgePosition.FrontLeftPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryLeft, EdgePosition.RotateBottomCCW(EdgePosition.FrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryFront, EdgePosition.RotateBottomCCW(EdgePosition.FrontRightPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryRight, EdgePosition.RotateBottomCCW(EdgePosition.FrontRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryBack, EdgePosition.RotateBottomCCW(EdgePosition.TopBackPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryTop, EdgePosition.RotateBottomCCW(EdgePosition.TopBackPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryFront, EdgePosition.RotateBottomCCW(EdgePosition.TopFrontPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryTop, EdgePosition.RotateBottomCCW(EdgePosition.TopFrontPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryLeft, EdgePosition.RotateBottomCCW(EdgePosition.TopLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryTop, EdgePosition.RotateBottomCCW(EdgePosition.TopLeftPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryRight, EdgePosition.RotateBottomCCW(EdgePosition.TopRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryTop, EdgePosition.RotateBottomCCW(EdgePosition.TopRightPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.Masked, EdgePosition.RotateBottomCCW(EdgePosition.Masked));
            Assert.AreEqual<byte>(EdgePosition.Unmasked, EdgePosition.RotateBottomCCW(EdgePosition.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_RotateBottomHalf_AllEdges()
        {
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryBack, EdgePosition.RotateBottomHalf(EdgePosition.BackLeftPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryLeft, EdgePosition.RotateBottomHalf(EdgePosition.BackLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryBack, EdgePosition.RotateBottomHalf(EdgePosition.BackRightPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryRight, EdgePosition.RotateBottomHalf(EdgePosition.BackRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryFront, EdgePosition.RotateBottomHalf(EdgePosition.BottomBackPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryBottom, EdgePosition.RotateBottomHalf(EdgePosition.BottomBackPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBottom, EdgePosition.RotateBottomHalf(EdgePosition.BottomFrontPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBack, EdgePosition.RotateBottomHalf(EdgePosition.BottomFrontPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryBottom, EdgePosition.RotateBottomHalf(EdgePosition.BottomLeftPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryRight, EdgePosition.RotateBottomHalf(EdgePosition.BottomLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryBottom, EdgePosition.RotateBottomHalf(EdgePosition.BottomRightPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryLeft, EdgePosition.RotateBottomHalf(EdgePosition.BottomRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryFront, EdgePosition.RotateBottomHalf(EdgePosition.FrontLeftPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryLeft, EdgePosition.RotateBottomHalf(EdgePosition.FrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryFront, EdgePosition.RotateBottomHalf(EdgePosition.FrontRightPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryRight, EdgePosition.RotateBottomHalf(EdgePosition.FrontRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryBack, EdgePosition.RotateBottomHalf(EdgePosition.TopBackPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryTop, EdgePosition.RotateBottomHalf(EdgePosition.TopBackPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryFront, EdgePosition.RotateBottomHalf(EdgePosition.TopFrontPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryTop, EdgePosition.RotateBottomHalf(EdgePosition.TopFrontPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryLeft, EdgePosition.RotateBottomHalf(EdgePosition.TopLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryTop, EdgePosition.RotateBottomHalf(EdgePosition.TopLeftPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryRight, EdgePosition.RotateBottomHalf(EdgePosition.TopRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryTop, EdgePosition.RotateBottomHalf(EdgePosition.TopRightPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.Masked, EdgePosition.RotateBottomHalf(EdgePosition.Masked));
            Assert.AreEqual<byte>(EdgePosition.Unmasked, EdgePosition.RotateBottomHalf(EdgePosition.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_RotateLeftCW_AllEdges()
        {
            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryTop, EdgePosition.RotateLeftCW(EdgePosition.BackLeftPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryLeft, EdgePosition.RotateLeftCW(EdgePosition.BackLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryBack, EdgePosition.RotateLeftCW(EdgePosition.BackRightPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryRight, EdgePosition.RotateLeftCW(EdgePosition.BackRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBack, EdgePosition.RotateLeftCW(EdgePosition.BottomBackPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBottom, EdgePosition.RotateLeftCW(EdgePosition.BottomBackPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryBottom, EdgePosition.RotateLeftCW(EdgePosition.BottomFrontPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryFront, EdgePosition.RotateLeftCW(EdgePosition.BottomFrontPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryBack, EdgePosition.RotateLeftCW(EdgePosition.BottomLeftPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryLeft, EdgePosition.RotateLeftCW(EdgePosition.BottomLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryBottom, EdgePosition.RotateLeftCW(EdgePosition.BottomRightPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryRight, EdgePosition.RotateLeftCW(EdgePosition.BottomRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryBottom, EdgePosition.RotateLeftCW(EdgePosition.FrontLeftPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryLeft, EdgePosition.RotateLeftCW(EdgePosition.FrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryFront, EdgePosition.RotateLeftCW(EdgePosition.FrontRightPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryRight, EdgePosition.RotateLeftCW(EdgePosition.FrontRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryBack, EdgePosition.RotateLeftCW(EdgePosition.TopBackPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryTop, EdgePosition.RotateLeftCW(EdgePosition.TopBackPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryFront, EdgePosition.RotateLeftCW(EdgePosition.TopFrontPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryTop, EdgePosition.RotateLeftCW(EdgePosition.TopFrontPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryLeft, EdgePosition.RotateLeftCW(EdgePosition.TopLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryFront, EdgePosition.RotateLeftCW(EdgePosition.TopLeftPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryRight, EdgePosition.RotateLeftCW(EdgePosition.TopRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryTop, EdgePosition.RotateLeftCW(EdgePosition.TopRightPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.Masked, EdgePosition.RotateLeftCW(EdgePosition.Masked));
            Assert.AreEqual<byte>(EdgePosition.Unmasked, EdgePosition.RotateLeftCW(EdgePosition.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_RotateLeftCCW_AllEdges()
        {
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryBottom, EdgePosition.RotateLeftCCW(EdgePosition.BackLeftPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryLeft, EdgePosition.RotateLeftCCW(EdgePosition.BackLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryBack, EdgePosition.RotateLeftCCW(EdgePosition.BackRightPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryRight, EdgePosition.RotateLeftCCW(EdgePosition.BackRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBack, EdgePosition.RotateLeftCCW(EdgePosition.BottomBackPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBottom, EdgePosition.RotateLeftCCW(EdgePosition.BottomBackPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryBottom, EdgePosition.RotateLeftCCW(EdgePosition.BottomFrontPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryFront, EdgePosition.RotateLeftCCW(EdgePosition.BottomFrontPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryFront, EdgePosition.RotateLeftCCW(EdgePosition.BottomLeftPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryLeft, EdgePosition.RotateLeftCCW(EdgePosition.BottomLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryBottom, EdgePosition.RotateLeftCCW(EdgePosition.BottomRightPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryRight, EdgePosition.RotateLeftCCW(EdgePosition.BottomRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryTop, EdgePosition.RotateLeftCCW(EdgePosition.FrontLeftPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryLeft, EdgePosition.RotateLeftCCW(EdgePosition.FrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryFront, EdgePosition.RotateLeftCCW(EdgePosition.FrontRightPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryRight, EdgePosition.RotateLeftCCW(EdgePosition.FrontRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryBack, EdgePosition.RotateLeftCCW(EdgePosition.TopBackPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryTop, EdgePosition.RotateLeftCCW(EdgePosition.TopBackPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryFront, EdgePosition.RotateLeftCCW(EdgePosition.TopFrontPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryTop, EdgePosition.RotateLeftCCW(EdgePosition.TopFrontPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryLeft, EdgePosition.RotateLeftCCW(EdgePosition.TopLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryBack, EdgePosition.RotateLeftCCW(EdgePosition.TopLeftPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryRight, EdgePosition.RotateLeftCCW(EdgePosition.TopRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryTop, EdgePosition.RotateLeftCCW(EdgePosition.TopRightPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.Masked, EdgePosition.RotateLeftCCW(EdgePosition.Masked));
            Assert.AreEqual<byte>(EdgePosition.Unmasked, EdgePosition.RotateLeftCCW(EdgePosition.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_RotateLeftHalf_AllEdges()
        {
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryFront, EdgePosition.RotateLeftHalf(EdgePosition.BackLeftPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryLeft, EdgePosition.RotateLeftHalf(EdgePosition.BackLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryBack, EdgePosition.RotateLeftHalf(EdgePosition.BackRightPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryRight, EdgePosition.RotateLeftHalf(EdgePosition.BackRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBack, EdgePosition.RotateLeftHalf(EdgePosition.BottomBackPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBottom, EdgePosition.RotateLeftHalf(EdgePosition.BottomBackPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryBottom, EdgePosition.RotateLeftHalf(EdgePosition.BottomFrontPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryFront, EdgePosition.RotateLeftHalf(EdgePosition.BottomFrontPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryTop, EdgePosition.RotateLeftHalf(EdgePosition.BottomLeftPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryLeft, EdgePosition.RotateLeftHalf(EdgePosition.BottomLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryBottom, EdgePosition.RotateLeftHalf(EdgePosition.BottomRightPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryRight, EdgePosition.RotateLeftHalf(EdgePosition.BottomRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryBack, EdgePosition.RotateLeftHalf(EdgePosition.FrontLeftPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryLeft, EdgePosition.RotateLeftHalf(EdgePosition.FrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryFront, EdgePosition.RotateLeftHalf(EdgePosition.FrontRightPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryRight, EdgePosition.RotateLeftHalf(EdgePosition.FrontRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryBack, EdgePosition.RotateLeftHalf(EdgePosition.TopBackPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryTop, EdgePosition.RotateLeftHalf(EdgePosition.TopBackPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryFront, EdgePosition.RotateLeftHalf(EdgePosition.TopFrontPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryTop, EdgePosition.RotateLeftHalf(EdgePosition.TopFrontPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryLeft, EdgePosition.RotateLeftHalf(EdgePosition.TopLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryBottom, EdgePosition.RotateLeftHalf(EdgePosition.TopLeftPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryRight, EdgePosition.RotateLeftHalf(EdgePosition.TopRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryTop, EdgePosition.RotateLeftHalf(EdgePosition.TopRightPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.Masked, EdgePosition.RotateLeftHalf(EdgePosition.Masked));
            Assert.AreEqual<byte>(EdgePosition.Unmasked, EdgePosition.RotateLeftHalf(EdgePosition.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_RotateRightCW_AllEdges()
        {
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryBack, EdgePosition.RotateRightCW(EdgePosition.BackLeftPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryLeft, EdgePosition.RotateRightCW(EdgePosition.BackLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryBottom, EdgePosition.RotateRightCW(EdgePosition.BackRightPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryRight, EdgePosition.RotateRightCW(EdgePosition.BackRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBack, EdgePosition.RotateRightCW(EdgePosition.BottomBackPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBottom, EdgePosition.RotateRightCW(EdgePosition.BottomBackPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryBottom, EdgePosition.RotateRightCW(EdgePosition.BottomFrontPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryFront, EdgePosition.RotateRightCW(EdgePosition.BottomFrontPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryBottom, EdgePosition.RotateRightCW(EdgePosition.BottomLeftPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryLeft, EdgePosition.RotateRightCW(EdgePosition.BottomLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryFront, EdgePosition.RotateRightCW(EdgePosition.BottomRightPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryRight, EdgePosition.RotateRightCW(EdgePosition.BottomRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryFront, EdgePosition.RotateRightCW(EdgePosition.FrontLeftPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryLeft, EdgePosition.RotateRightCW(EdgePosition.FrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryTop, EdgePosition.RotateRightCW(EdgePosition.FrontRightPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryRight, EdgePosition.RotateRightCW(EdgePosition.FrontRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryBack, EdgePosition.RotateRightCW(EdgePosition.TopBackPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryTop, EdgePosition.RotateRightCW(EdgePosition.TopBackPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryFront, EdgePosition.RotateRightCW(EdgePosition.TopFrontPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryTop, EdgePosition.RotateRightCW(EdgePosition.TopFrontPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryLeft, EdgePosition.RotateRightCW(EdgePosition.TopLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryTop, EdgePosition.RotateRightCW(EdgePosition.TopLeftPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryRight, EdgePosition.RotateRightCW(EdgePosition.TopRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryBack, EdgePosition.RotateRightCW(EdgePosition.TopRightPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.Masked, EdgePosition.RotateRightCW(EdgePosition.Masked));
            Assert.AreEqual<byte>(EdgePosition.Unmasked, EdgePosition.RotateRightCW(EdgePosition.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_RotateRightCCW_AllEdges()
        {
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryBack, EdgePosition.RotateRightCCW(EdgePosition.BackLeftPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryLeft, EdgePosition.RotateRightCCW(EdgePosition.BackLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryTop, EdgePosition.RotateRightCCW(EdgePosition.BackRightPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryRight, EdgePosition.RotateRightCCW(EdgePosition.BackRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBack, EdgePosition.RotateRightCCW(EdgePosition.BottomBackPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBottom, EdgePosition.RotateRightCCW(EdgePosition.BottomBackPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryBottom, EdgePosition.RotateRightCCW(EdgePosition.BottomFrontPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryFront, EdgePosition.RotateRightCCW(EdgePosition.BottomFrontPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryBottom, EdgePosition.RotateRightCCW(EdgePosition.BottomLeftPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryLeft, EdgePosition.RotateRightCCW(EdgePosition.BottomLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryBack, EdgePosition.RotateRightCCW(EdgePosition.BottomRightPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryRight, EdgePosition.RotateRightCCW(EdgePosition.BottomRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryFront, EdgePosition.RotateRightCCW(EdgePosition.FrontLeftPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryLeft, EdgePosition.RotateRightCCW(EdgePosition.FrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryBottom, EdgePosition.RotateRightCCW(EdgePosition.FrontRightPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryRight, EdgePosition.RotateRightCCW(EdgePosition.FrontRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryBack, EdgePosition.RotateRightCCW(EdgePosition.TopBackPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryTop, EdgePosition.RotateRightCCW(EdgePosition.TopBackPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryFront, EdgePosition.RotateRightCCW(EdgePosition.TopFrontPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryTop, EdgePosition.RotateRightCCW(EdgePosition.TopFrontPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryLeft, EdgePosition.RotateRightCCW(EdgePosition.TopLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryTop, EdgePosition.RotateRightCCW(EdgePosition.TopLeftPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryRight, EdgePosition.RotateRightCCW(EdgePosition.TopRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryFront, EdgePosition.RotateRightCCW(EdgePosition.TopRightPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.Masked, EdgePosition.RotateRightCCW(EdgePosition.Masked));
            Assert.AreEqual<byte>(EdgePosition.Unmasked, EdgePosition.RotateRightCCW(EdgePosition.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_RotateRightHalf_AllEdges()
        {
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryBack, EdgePosition.RotateRightHalf(EdgePosition.BackLeftPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryLeft, EdgePosition.RotateRightHalf(EdgePosition.BackLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryFront, EdgePosition.RotateRightHalf(EdgePosition.BackRightPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryRight, EdgePosition.RotateRightHalf(EdgePosition.BackRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBack, EdgePosition.RotateRightHalf(EdgePosition.BottomBackPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBottom, EdgePosition.RotateRightHalf(EdgePosition.BottomBackPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryBottom, EdgePosition.RotateRightHalf(EdgePosition.BottomFrontPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryFront, EdgePosition.RotateRightHalf(EdgePosition.BottomFrontPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryBottom, EdgePosition.RotateRightHalf(EdgePosition.BottomLeftPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryLeft, EdgePosition.RotateRightHalf(EdgePosition.BottomLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryTop, EdgePosition.RotateRightHalf(EdgePosition.BottomRightPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryRight, EdgePosition.RotateRightHalf(EdgePosition.BottomRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryFront, EdgePosition.RotateRightHalf(EdgePosition.FrontLeftPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryLeft, EdgePosition.RotateRightHalf(EdgePosition.FrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryBack, EdgePosition.RotateRightHalf(EdgePosition.FrontRightPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryRight, EdgePosition.RotateRightHalf(EdgePosition.FrontRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryBack, EdgePosition.RotateRightHalf(EdgePosition.TopBackPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryTop, EdgePosition.RotateRightHalf(EdgePosition.TopBackPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryFront, EdgePosition.RotateRightHalf(EdgePosition.TopFrontPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryTop, EdgePosition.RotateRightHalf(EdgePosition.TopFrontPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryLeft, EdgePosition.RotateRightHalf(EdgePosition.TopLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryTop, EdgePosition.RotateRightHalf(EdgePosition.TopLeftPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryRight, EdgePosition.RotateRightHalf(EdgePosition.TopRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryBottom, EdgePosition.RotateRightHalf(EdgePosition.TopRightPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.Masked, EdgePosition.RotateRightHalf(EdgePosition.Masked));
            Assert.AreEqual<byte>(EdgePosition.Unmasked, EdgePosition.RotateRightHalf(EdgePosition.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_RotateFrontCW_AllEdges()
        {
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryBack, EdgePosition.RotateFrontCW(EdgePosition.BackLeftPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryLeft, EdgePosition.RotateFrontCW(EdgePosition.BackLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryBack, EdgePosition.RotateFrontCW(EdgePosition.BackRightPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryRight, EdgePosition.RotateFrontCW(EdgePosition.BackRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBack, EdgePosition.RotateFrontCW(EdgePosition.BottomBackPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBottom, EdgePosition.RotateFrontCW(EdgePosition.BottomBackPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryLeft, EdgePosition.RotateFrontCW(EdgePosition.BottomFrontPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryFront, EdgePosition.RotateFrontCW(EdgePosition.BottomFrontPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryBottom, EdgePosition.RotateFrontCW(EdgePosition.BottomLeftPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryLeft, EdgePosition.RotateFrontCW(EdgePosition.BottomLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryBottom, EdgePosition.RotateFrontCW(EdgePosition.BottomRightPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryRight, EdgePosition.RotateFrontCW(EdgePosition.BottomRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryFront, EdgePosition.RotateFrontCW(EdgePosition.FrontLeftPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryTop, EdgePosition.RotateFrontCW(EdgePosition.FrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryFront, EdgePosition.RotateFrontCW(EdgePosition.FrontRightPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryBottom, EdgePosition.RotateFrontCW(EdgePosition.FrontRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryBack, EdgePosition.RotateFrontCW(EdgePosition.TopBackPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryTop, EdgePosition.RotateFrontCW(EdgePosition.TopBackPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryFront, EdgePosition.RotateFrontCW(EdgePosition.TopFrontPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryRight, EdgePosition.RotateFrontCW(EdgePosition.TopFrontPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryLeft, EdgePosition.RotateFrontCW(EdgePosition.TopLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryTop, EdgePosition.RotateFrontCW(EdgePosition.TopLeftPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryRight, EdgePosition.RotateFrontCW(EdgePosition.TopRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryTop, EdgePosition.RotateFrontCW(EdgePosition.TopRightPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.Masked, EdgePosition.RotateFrontCW(EdgePosition.Masked));
            Assert.AreEqual<byte>(EdgePosition.Unmasked, EdgePosition.RotateFrontCW(EdgePosition.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_RotateFrontCCW_AllEdges()
        {
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryBack, EdgePosition.RotateFrontCCW(EdgePosition.BackLeftPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryLeft, EdgePosition.RotateFrontCCW(EdgePosition.BackLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryBack, EdgePosition.RotateFrontCCW(EdgePosition.BackRightPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryRight, EdgePosition.RotateFrontCCW(EdgePosition.BackRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBack, EdgePosition.RotateFrontCCW(EdgePosition.BottomBackPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBottom, EdgePosition.RotateFrontCCW(EdgePosition.BottomBackPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryRight, EdgePosition.RotateFrontCCW(EdgePosition.BottomFrontPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryFront, EdgePosition.RotateFrontCCW(EdgePosition.BottomFrontPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryBottom, EdgePosition.RotateFrontCCW(EdgePosition.BottomLeftPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryLeft, EdgePosition.RotateFrontCCW(EdgePosition.BottomLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryBottom, EdgePosition.RotateFrontCCW(EdgePosition.BottomRightPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryRight, EdgePosition.RotateFrontCCW(EdgePosition.BottomRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryFront, EdgePosition.RotateFrontCCW(EdgePosition.FrontLeftPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryBottom, EdgePosition.RotateFrontCCW(EdgePosition.FrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryFront, EdgePosition.RotateFrontCCW(EdgePosition.FrontRightPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryTop, EdgePosition.RotateFrontCCW(EdgePosition.FrontRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryBack, EdgePosition.RotateFrontCCW(EdgePosition.TopBackPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryTop, EdgePosition.RotateFrontCCW(EdgePosition.TopBackPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryFront, EdgePosition.RotateFrontCCW(EdgePosition.TopFrontPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryLeft, EdgePosition.RotateFrontCCW(EdgePosition.TopFrontPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryLeft, EdgePosition.RotateFrontCCW(EdgePosition.TopLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryTop, EdgePosition.RotateFrontCCW(EdgePosition.TopLeftPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryRight, EdgePosition.RotateFrontCCW(EdgePosition.TopRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryTop, EdgePosition.RotateFrontCCW(EdgePosition.TopRightPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.Masked, EdgePosition.RotateFrontCCW(EdgePosition.Masked));
            Assert.AreEqual<byte>(EdgePosition.Unmasked, EdgePosition.RotateFrontCCW(EdgePosition.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_RotateFrontHalf_AllEdges()
        {
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryBack, EdgePosition.RotateFrontHalf(EdgePosition.BackLeftPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryLeft, EdgePosition.RotateFrontHalf(EdgePosition.BackLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryBack, EdgePosition.RotateFrontHalf(EdgePosition.BackRightPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryRight, EdgePosition.RotateFrontHalf(EdgePosition.BackRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBack, EdgePosition.RotateFrontHalf(EdgePosition.BottomBackPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBottom, EdgePosition.RotateFrontHalf(EdgePosition.BottomBackPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryTop, EdgePosition.RotateFrontHalf(EdgePosition.BottomFrontPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryFront, EdgePosition.RotateFrontHalf(EdgePosition.BottomFrontPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryBottom, EdgePosition.RotateFrontHalf(EdgePosition.BottomLeftPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryLeft, EdgePosition.RotateFrontHalf(EdgePosition.BottomLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryBottom, EdgePosition.RotateFrontHalf(EdgePosition.BottomRightPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryRight, EdgePosition.RotateFrontHalf(EdgePosition.BottomRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryFront, EdgePosition.RotateFrontHalf(EdgePosition.FrontLeftPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryRight, EdgePosition.RotateFrontHalf(EdgePosition.FrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryFront, EdgePosition.RotateFrontHalf(EdgePosition.FrontRightPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryLeft, EdgePosition.RotateFrontHalf(EdgePosition.FrontRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryBack, EdgePosition.RotateFrontHalf(EdgePosition.TopBackPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryTop, EdgePosition.RotateFrontHalf(EdgePosition.TopBackPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryFront, EdgePosition.RotateFrontHalf(EdgePosition.TopFrontPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryBottom, EdgePosition.RotateFrontHalf(EdgePosition.TopFrontPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryLeft, EdgePosition.RotateFrontHalf(EdgePosition.TopLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryTop, EdgePosition.RotateFrontHalf(EdgePosition.TopLeftPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryRight, EdgePosition.RotateFrontHalf(EdgePosition.TopRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryTop, EdgePosition.RotateFrontHalf(EdgePosition.TopRightPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.Masked, EdgePosition.RotateFrontHalf(EdgePosition.Masked));
            Assert.AreEqual<byte>(EdgePosition.Unmasked, EdgePosition.RotateFrontHalf(EdgePosition.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_RotateBackCW_AllEdges()
        {
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBack, EdgePosition.RotateBackCW(EdgePosition.BackLeftPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBottom, EdgePosition.RotateBackCW(EdgePosition.BackLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryBack, EdgePosition.RotateBackCW(EdgePosition.BackRightPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryTop, EdgePosition.RotateBackCW(EdgePosition.BackRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryBack, EdgePosition.RotateBackCW(EdgePosition.BottomBackPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryRight, EdgePosition.RotateBackCW(EdgePosition.BottomBackPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryBottom, EdgePosition.RotateBackCW(EdgePosition.BottomFrontPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryFront, EdgePosition.RotateBackCW(EdgePosition.BottomFrontPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryBottom, EdgePosition.RotateBackCW(EdgePosition.BottomLeftPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryLeft, EdgePosition.RotateBackCW(EdgePosition.BottomLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryBottom, EdgePosition.RotateBackCW(EdgePosition.BottomRightPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryRight, EdgePosition.RotateBackCW(EdgePosition.BottomRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryFront, EdgePosition.RotateBackCW(EdgePosition.FrontLeftPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryLeft, EdgePosition.RotateBackCW(EdgePosition.FrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryFront, EdgePosition.RotateBackCW(EdgePosition.FrontRightPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryRight, EdgePosition.RotateBackCW(EdgePosition.FrontRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryBack, EdgePosition.RotateBackCW(EdgePosition.TopBackPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryLeft, EdgePosition.RotateBackCW(EdgePosition.TopBackPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryFront, EdgePosition.RotateBackCW(EdgePosition.TopFrontPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryTop, EdgePosition.RotateBackCW(EdgePosition.TopFrontPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryLeft, EdgePosition.RotateBackCW(EdgePosition.TopLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryTop, EdgePosition.RotateBackCW(EdgePosition.TopLeftPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryRight, EdgePosition.RotateBackCW(EdgePosition.TopRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryTop, EdgePosition.RotateBackCW(EdgePosition.TopRightPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.Masked, EdgePosition.RotateBackCW(EdgePosition.Masked));
            Assert.AreEqual<byte>(EdgePosition.Unmasked, EdgePosition.RotateBackCW(EdgePosition.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_RotateBackCCW_AllEdges()
        {
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryBack, EdgePosition.RotateBackCCW(EdgePosition.BackLeftPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryTop, EdgePosition.RotateBackCCW(EdgePosition.BackLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBack, EdgePosition.RotateBackCCW(EdgePosition.BackRightPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBottom, EdgePosition.RotateBackCCW(EdgePosition.BackRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryBack, EdgePosition.RotateBackCCW(EdgePosition.BottomBackPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryLeft, EdgePosition.RotateBackCCW(EdgePosition.BottomBackPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryBottom, EdgePosition.RotateBackCCW(EdgePosition.BottomFrontPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryFront, EdgePosition.RotateBackCCW(EdgePosition.BottomFrontPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryBottom, EdgePosition.RotateBackCCW(EdgePosition.BottomLeftPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryLeft, EdgePosition.RotateBackCCW(EdgePosition.BottomLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryBottom, EdgePosition.RotateBackCCW(EdgePosition.BottomRightPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryRight, EdgePosition.RotateBackCCW(EdgePosition.BottomRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryFront, EdgePosition.RotateBackCCW(EdgePosition.FrontLeftPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryLeft, EdgePosition.RotateBackCCW(EdgePosition.FrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryFront, EdgePosition.RotateBackCCW(EdgePosition.FrontRightPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryRight, EdgePosition.RotateBackCCW(EdgePosition.FrontRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryBack, EdgePosition.RotateBackCCW(EdgePosition.TopBackPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryRight, EdgePosition.RotateBackCCW(EdgePosition.TopBackPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryFront, EdgePosition.RotateBackCCW(EdgePosition.TopFrontPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryTop, EdgePosition.RotateBackCCW(EdgePosition.TopFrontPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryLeft, EdgePosition.RotateBackCCW(EdgePosition.TopLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryTop, EdgePosition.RotateBackCCW(EdgePosition.TopLeftPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryRight, EdgePosition.RotateBackCCW(EdgePosition.TopRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryTop, EdgePosition.RotateBackCCW(EdgePosition.TopRightPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.Masked, EdgePosition.RotateBackCCW(EdgePosition.Masked));
            Assert.AreEqual<byte>(EdgePosition.Unmasked, EdgePosition.RotateBackCCW(EdgePosition.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_RotateBackHalf_AllEdges()
        {
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryBack, EdgePosition.RotateBackHalf(EdgePosition.BackLeftPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryRight, EdgePosition.RotateBackHalf(EdgePosition.BackLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryBack, EdgePosition.RotateBackHalf(EdgePosition.BackRightPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryLeft, EdgePosition.RotateBackHalf(EdgePosition.BackRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryBack, EdgePosition.RotateBackHalf(EdgePosition.BottomBackPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryTop, EdgePosition.RotateBackHalf(EdgePosition.BottomBackPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryBottom, EdgePosition.RotateBackHalf(EdgePosition.BottomFrontPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryFront, EdgePosition.RotateBackHalf(EdgePosition.BottomFrontPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryBottom, EdgePosition.RotateBackHalf(EdgePosition.BottomLeftPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryLeft, EdgePosition.RotateBackHalf(EdgePosition.BottomLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryBottom, EdgePosition.RotateBackHalf(EdgePosition.BottomRightPrimaryBottom));
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryRight, EdgePosition.RotateBackHalf(EdgePosition.BottomRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryFront, EdgePosition.RotateBackHalf(EdgePosition.FrontLeftPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryLeft, EdgePosition.RotateBackHalf(EdgePosition.FrontLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryFront, EdgePosition.RotateBackHalf(EdgePosition.FrontRightPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryRight, EdgePosition.RotateBackHalf(EdgePosition.FrontRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBack, EdgePosition.RotateBackHalf(EdgePosition.TopBackPrimaryBack));
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBottom, EdgePosition.RotateBackHalf(EdgePosition.TopBackPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryFront, EdgePosition.RotateBackHalf(EdgePosition.TopFrontPrimaryFront));
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryTop, EdgePosition.RotateBackHalf(EdgePosition.TopFrontPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryLeft, EdgePosition.RotateBackHalf(EdgePosition.TopLeftPrimaryLeft));
            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryTop, EdgePosition.RotateBackHalf(EdgePosition.TopLeftPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryRight, EdgePosition.RotateBackHalf(EdgePosition.TopRightPrimaryRight));
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryTop, EdgePosition.RotateBackHalf(EdgePosition.TopRightPrimaryTop));
            Assert.AreEqual<byte>(EdgePosition.Masked, EdgePosition.RotateBackHalf(EdgePosition.Masked));
            Assert.AreEqual<byte>(EdgePosition.Unmasked, EdgePosition.RotateBackHalf(EdgePosition.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_Mask_MaskedEdge()
        {
            Assert.AreEqual<byte>(EdgePosition.Masked, EdgePosition.Mask(EdgePosition.TopBackPrimaryBack, EdgePosition.Masked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void EdgePosition_Mask_UnmaskedEdge()
        {
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryBack, EdgePosition.Mask(EdgePosition.TopBackPrimaryBack, EdgePosition.Unmasked));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        [ExpectedException(typeof(ArgumentException))]
        public void EdgePosition_Mask_BadMask()
        {
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryBack, EdgePosition.Mask(EdgePosition.TopBackPrimaryBack, EdgePosition.TopBackPrimaryBack));
        }
    }
}
