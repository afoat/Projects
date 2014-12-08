namespace Foat.Puzzles.Tests.RubiksCube
{
    using Foat.Puzzles.RubiksCube;
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RubiksCubeTests
    {
        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void RubiksCube_DefaultConstructor_SolvedCube()
        {
            RubiksCube cube = new RubiksCube();

            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryTop, cube[0]);
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryTop, cube[1]);
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryTop, cube[2]);
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryTop, cube[3]);
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBottom, cube[4]);
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBottom, cube[5]);
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryBottom, cube[6]);

            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryTop, cube[7]);
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryTop, cube[8]);
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryTop, cube[9]);
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryTop, cube[10]);
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryBottom, cube[11]);
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBottom, cube[12]);
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryBottom, cube[13]);
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryBottom, cube[14]);
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryFront, cube[15]);
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryBack, cube[16]);
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryBack, cube[17]);
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryFront, cube[18]);
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void RubiksCube_InitConstructor_RandomCube()
        {
            byte[] data = new byte[19] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
            RubiksCube cube = new RubiksCube(data);

            Assert.AreEqual<byte>(1, cube[0]);
            Assert.AreEqual<byte>(2, cube[1]);
            Assert.AreEqual<byte>(3, cube[2]);
            Assert.AreEqual<byte>(4, cube[3]);
            Assert.AreEqual<byte>(5, cube[4]);
            Assert.AreEqual<byte>(6, cube[5]);
            Assert.AreEqual<byte>(7, cube[6]);

            Assert.AreEqual<byte>(8, cube[7]);
            Assert.AreEqual<byte>(9, cube[8]);
            Assert.AreEqual<byte>(10, cube[9]);
            Assert.AreEqual<byte>(11, cube[10]);
            Assert.AreEqual<byte>(12, cube[11]);
            Assert.AreEqual<byte>(13, cube[12]);
            Assert.AreEqual<byte>(14, cube[13]);
            Assert.AreEqual<byte>(15, cube[14]);
            Assert.AreEqual<byte>(16, cube[15]);
            Assert.AreEqual<byte>(17, cube[16]);
            Assert.AreEqual<byte>(18, cube[17]);
            Assert.AreEqual<byte>(19, cube[18]);
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void RubiksCube_CopyConstructor_SolvedCube()
        {
            RubiksCube cube = new RubiksCube(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 });
            RubiksCube copy = new RubiksCube(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 });

            Assert.IsFalse(object.ReferenceEquals(cube, copy));

            Assert.AreEqual<byte>(1, copy[0]);
            Assert.AreEqual<byte>(2, copy[1]);
            Assert.AreEqual<byte>(3, copy[2]);
            Assert.AreEqual<byte>(4, copy[3]);
            Assert.AreEqual<byte>(5, copy[4]);
            Assert.AreEqual<byte>(6, copy[5]);
            Assert.AreEqual<byte>(7, copy[6]);

            Assert.AreEqual<byte>(8, copy[7]);
            Assert.AreEqual<byte>(9, copy[8]);
            Assert.AreEqual<byte>(10, copy[9]);
            Assert.AreEqual<byte>(11, copy[10]);
            Assert.AreEqual<byte>(12, copy[11]);
            Assert.AreEqual<byte>(13, copy[12]);
            Assert.AreEqual<byte>(14, copy[13]);
            Assert.AreEqual<byte>(15, copy[14]);
            Assert.AreEqual<byte>(16, copy[15]);
            Assert.AreEqual<byte>(17, copy[16]);
            Assert.AreEqual<byte>(18, copy[17]);
            Assert.AreEqual<byte>(19, copy[18]);
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void RubiksCube_ApplyMask_SolvedCube_With_UnmaskedCube()
        {
            RubiksCube cube = new RubiksCube();
            RubiksCube unmasked = new RubiksCube(
                new byte[] { CornerPosition.Unmasked, CornerPosition.Unmasked, CornerPosition.Unmasked, CornerPosition.Unmasked, CornerPosition.Unmasked, CornerPosition.Unmasked, CornerPosition.Unmasked,
                             EdgePosition.Unmasked, EdgePosition.Unmasked, EdgePosition.Unmasked, EdgePosition.Unmasked, EdgePosition.Unmasked, EdgePosition.Unmasked, EdgePosition.Unmasked, EdgePosition.Unmasked, EdgePosition.Unmasked, EdgePosition.Unmasked, EdgePosition.Unmasked, EdgePosition.Unmasked }
                );

            cube.ApplyMask(unmasked);

            Assert.AreEqual<byte>(CornerPosition.TopBackLeftPrimaryTop, cube[0]);
            Assert.AreEqual<byte>(CornerPosition.TopBackRightPrimaryTop, cube[1]);
            Assert.AreEqual<byte>(CornerPosition.TopFrontRightPrimaryTop, cube[2]);
            Assert.AreEqual<byte>(CornerPosition.TopFrontLeftPrimaryTop, cube[3]);
            Assert.AreEqual<byte>(CornerPosition.BottomBackLeftPrimaryBottom, cube[4]);
            Assert.AreEqual<byte>(CornerPosition.BottomBackRightPrimaryBottom, cube[5]);
            Assert.AreEqual<byte>(CornerPosition.BottomFrontRightPrimaryBottom, cube[6]);

            Assert.AreEqual<byte>(EdgePosition.TopLeftPrimaryTop, cube[7]);
            Assert.AreEqual<byte>(EdgePosition.TopBackPrimaryTop, cube[8]);
            Assert.AreEqual<byte>(EdgePosition.TopRightPrimaryTop, cube[9]);
            Assert.AreEqual<byte>(EdgePosition.TopFrontPrimaryTop, cube[10]);
            Assert.AreEqual<byte>(EdgePosition.BottomLeftPrimaryBottom, cube[11]);
            Assert.AreEqual<byte>(EdgePosition.BottomBackPrimaryBottom, cube[12]);
            Assert.AreEqual<byte>(EdgePosition.BottomRightPrimaryBottom, cube[13]);
            Assert.AreEqual<byte>(EdgePosition.BottomFrontPrimaryBottom, cube[14]);
            Assert.AreEqual<byte>(EdgePosition.FrontLeftPrimaryFront, cube[15]);
            Assert.AreEqual<byte>(EdgePosition.BackLeftPrimaryBack, cube[16]);
            Assert.AreEqual<byte>(EdgePosition.BackRightPrimaryBack, cube[17]);
            Assert.AreEqual<byte>(EdgePosition.FrontRightPrimaryFront, cube[18]);
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void RubiksCube_ApplyMask_SolvedCube_With_MaskedCube()
        {
            RubiksCube cube = new RubiksCube();
            RubiksCube masked = new RubiksCube(
                new byte[] { CornerPosition.Masked, CornerPosition.Masked, CornerPosition.Masked, CornerPosition.Masked, CornerPosition.Masked, CornerPosition.Masked, CornerPosition.Masked,
                             EdgePosition.Masked, EdgePosition.Masked, EdgePosition.Masked, EdgePosition.Masked, EdgePosition.Masked, EdgePosition.Masked, EdgePosition.Masked, EdgePosition.Masked, EdgePosition.Masked, EdgePosition.Masked, EdgePosition.Masked, EdgePosition.Masked }
                );

            cube = cube.ApplyMask(masked);

            Assert.IsFalse(object.ReferenceEquals(cube, masked));

            Assert.AreEqual<byte>(CornerPosition.Masked, cube[0]);
            Assert.AreEqual<byte>(CornerPosition.Masked, cube[1]);
            Assert.AreEqual<byte>(CornerPosition.Masked, cube[2]);
            Assert.AreEqual<byte>(CornerPosition.Masked, cube[3]);
            Assert.AreEqual<byte>(CornerPosition.Masked, cube[4]);
            Assert.AreEqual<byte>(CornerPosition.Masked, cube[5]);
            Assert.AreEqual<byte>(CornerPosition.Masked, cube[6]);

            Assert.AreEqual<byte>(EdgePosition.Masked, cube[7]);
            Assert.AreEqual<byte>(EdgePosition.Masked, cube[8]);
            Assert.AreEqual<byte>(EdgePosition.Masked, cube[9]);
            Assert.AreEqual<byte>(EdgePosition.Masked, cube[10]);
            Assert.AreEqual<byte>(EdgePosition.Masked, cube[11]);
            Assert.AreEqual<byte>(EdgePosition.Masked, cube[12]);
            Assert.AreEqual<byte>(EdgePosition.Masked, cube[13]);
            Assert.AreEqual<byte>(EdgePosition.Masked, cube[14]);
            Assert.AreEqual<byte>(EdgePosition.Masked, cube[15]);
            Assert.AreEqual<byte>(EdgePosition.Masked, cube[16]);
            Assert.AreEqual<byte>(EdgePosition.Masked, cube[17]);
            Assert.AreEqual<byte>(EdgePosition.Masked, cube[18]);
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        [ExpectedException(typeof(ArgumentException))]
        public void RubiksCube_ApplyMask_SolvedCube_With_BadMask()
        {
            RubiksCube cube = new RubiksCube();
            RubiksCube masked = new RubiksCube(
                new byte[] { CornerPosition.TopBackLeftPrimaryLeft, CornerPosition.Masked, CornerPosition.Masked, CornerPosition.Masked, CornerPosition.Masked, CornerPosition.Masked, CornerPosition.Masked,
                             EdgePosition.Masked, EdgePosition.Masked, EdgePosition.Masked, EdgePosition.Masked, EdgePosition.Masked, EdgePosition.Masked, EdgePosition.Masked, EdgePosition.Masked, EdgePosition.Masked, EdgePosition.Masked, EdgePosition.Masked, EdgePosition.Masked }
                );

            cube.ApplyMask(masked);
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void RubiksCube_ModifyEdges_SolvedCube_ChangeAll()
        {
            RubiksCube cube = new RubiksCube();

            const byte value = 27;

            byte[] data = new byte[19];
            cube.ModifyEdgesIntoNewData(data, edge => value);

            Assert.AreEqual<byte>(0, data[0]);
            Assert.AreEqual<byte>(0, data[1]);
            Assert.AreEqual<byte>(0, data[2]);
            Assert.AreEqual<byte>(0, data[3]);
            Assert.AreEqual<byte>(0, data[4]);
            Assert.AreEqual<byte>(0, data[5]);
            Assert.AreEqual<byte>(0, data[6]);

            Assert.AreEqual<byte>(value, data[7]);
            Assert.AreEqual<byte>(value, data[8]);
            Assert.AreEqual<byte>(value, data[9]);
            Assert.AreEqual<byte>(value, data[10]);
            Assert.AreEqual<byte>(value, data[11]);
            Assert.AreEqual<byte>(value, data[12]);
            Assert.AreEqual<byte>(value, data[13]);
            Assert.AreEqual<byte>(value, data[14]);
            Assert.AreEqual<byte>(value, data[15]);
            Assert.AreEqual<byte>(value, data[16]);
            Assert.AreEqual<byte>(value, data[17]);
            Assert.AreEqual<byte>(value, data[18]);
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void RubiksCube_ModifyCorners_SolvedCube_ChangeAll()
        {
            RubiksCube cube = new RubiksCube();

            const byte value = 24;

            byte[] data = new byte[19];
            cube.ModifyCornersIntoNewData(data, edge => value);

            Assert.AreEqual<byte>(value, data[0]);
            Assert.AreEqual<byte>(value, data[1]);
            Assert.AreEqual<byte>(value, data[2]);
            Assert.AreEqual<byte>(value, data[3]);
            Assert.AreEqual<byte>(value, data[4]);
            Assert.AreEqual<byte>(value, data[5]);
            Assert.AreEqual<byte>(value, data[6]);

            Assert.AreEqual<byte>(0, data[7]);
            Assert.AreEqual<byte>(0, data[8]);
            Assert.AreEqual<byte>(0, data[9]);
            Assert.AreEqual<byte>(0, data[10]);
            Assert.AreEqual<byte>(0, data[11]);
            Assert.AreEqual<byte>(0, data[12]);
            Assert.AreEqual<byte>(0, data[13]);
            Assert.AreEqual<byte>(0, data[14]);
            Assert.AreEqual<byte>(0, data[15]);
            Assert.AreEqual<byte>(0, data[16]);
            Assert.AreEqual<byte>(0, data[17]);
            Assert.AreEqual<byte>(0, data[18]);
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void RubiksCube_EqualTo_SomethingElse_ExpectFalse()
        {
            RubiksCube cube1 = new RubiksCube(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 });
            RubiksCube cube2 = new RubiksCube(new byte[] { 7, 7, 5, 4, 3, 2, 1, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8 });
            Assert.IsFalse(cube1.Equals(cube2));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void RubiksCube_EqualTo_Identical_ExpectTrue()
        {
            RubiksCube cube1 = new RubiksCube(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 });
            RubiksCube cube2 = new RubiksCube(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 });
            Assert.IsTrue(cube1.Equals(cube2));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void RubiksCube_EqualTo_Null()
        {
            RubiksCube cube = new RubiksCube();
            Assert.IsFalse(cube.Equals(null));
        }
    }

}
