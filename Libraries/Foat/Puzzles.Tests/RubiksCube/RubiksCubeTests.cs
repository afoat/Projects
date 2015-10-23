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

            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryTop, cube[0]);
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryTop, cube[1]);
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryTop, cube[2]);
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryTop, cube[3]);
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBottom, cube[4]);
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBottom, cube[5]);
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryBottom, cube[6]);

            Assert.AreEqual<byte>(Position.TopLeftPrimaryTop, cube[7]);
            Assert.AreEqual<byte>(Position.TopBackPrimaryTop, cube[8]);
            Assert.AreEqual<byte>(Position.TopRightPrimaryTop, cube[9]);
            Assert.AreEqual<byte>(Position.TopFrontPrimaryTop, cube[10]);
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryBottom, cube[11]);
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBottom, cube[12]);
            Assert.AreEqual<byte>(Position.BottomRightPrimaryBottom, cube[13]);
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryBottom, cube[14]);
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryFront, cube[15]);
            Assert.AreEqual<byte>(Position.BackLeftPrimaryBack, cube[16]);
            Assert.AreEqual<byte>(Position.BackRightPrimaryBack, cube[17]);
            Assert.AreEqual<byte>(Position.FrontRightPrimaryFront, cube[18]);
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void RubiksCube_InitConstructor_RandomCube()
        {
            byte[] data = new byte[19] 
            { 
                Position.BottomBackLeftPrimaryBack, 
                Position.BottomBackLeftPrimaryBottom, 
                Position.BottomBackLeftPrimaryLeft, 
                Position.BottomBackRightPrimaryBack, 
                Position.BottomBackRightPrimaryBottom, 
                Position.BottomBackRightPrimaryRight, 
                Position.BottomFrontLeftPrimaryBottom, 
                Position.BackLeftPrimaryBack, 
                Position.BackLeftPrimaryLeft, 
                Position.BackRightPrimaryBack, 
                Position.BackRightPrimaryRight, 
                Position.BottomBackPrimaryBack, 
                Position.BottomBackPrimaryBottom, 
                Position.BottomFrontPrimaryBottom, 
                Position.BottomFrontPrimaryFront, 
                Position.BottomLeftPrimaryBottom, 
                Position.BottomLeftPrimaryLeft, 
                Position.BottomRightPrimaryBottom, 
                Position.BottomRightPrimaryRight
            };
            RubiksCube cube = new RubiksCube(data);

            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBack, cube[0]);
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBottom, cube[1]);
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryLeft, cube[2]);
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBack, cube[3]);
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBottom, cube[4]);
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryRight, cube[5]);
            Assert.AreEqual<byte>(Position.BottomFrontLeftPrimaryBottom, cube[6]);

            Assert.AreEqual<byte>(Position.BackLeftPrimaryBack, cube[7]);
            Assert.AreEqual<byte>(Position.BackLeftPrimaryLeft, cube[8]);
            Assert.AreEqual<byte>(Position.BackRightPrimaryBack, cube[9]);
            Assert.AreEqual<byte>(Position.BackRightPrimaryRight, cube[10]);
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBack, cube[11]);
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBottom, cube[12]);
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryBottom, cube[13]);
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryFront, cube[14]);
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryBottom, cube[15]);
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryLeft, cube[16]);
            Assert.AreEqual<byte>(Position.BottomRightPrimaryBottom, cube[17]);
            Assert.AreEqual<byte>(Position.BottomRightPrimaryRight, cube[18]);
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RubiksCube_InitConstructor_NullBytes()
        {
            RubiksCube cube = new RubiksCube((byte[])null);
        }
        
        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        [ExpectedException(typeof(ArgumentException))]
        public void RubiksCube_InitConstructor_BytesTooLong()
        {
            byte[] data = new byte[20] 
            { 
                Position.BottomBackLeftPrimaryBack, 
                Position.BottomBackLeftPrimaryBottom, 
                Position.BottomBackLeftPrimaryLeft, 
                Position.BottomBackRightPrimaryBack, 
                Position.BottomBackRightPrimaryBottom, 
                Position.BottomBackRightPrimaryRight, 
                Position.BottomFrontLeftPrimaryBottom, 
                Position.BackLeftPrimaryBack, 
                Position.BackLeftPrimaryLeft, 
                Position.BackRightPrimaryBack, 
                Position.BackRightPrimaryRight, 
                Position.BottomBackPrimaryBack, 
                Position.BottomBackPrimaryBottom, 
                Position.BottomFrontPrimaryBottom, 
                Position.BottomFrontPrimaryFront, 
                Position.BottomLeftPrimaryBottom, 
                Position.BottomLeftPrimaryLeft, 
                Position.BottomRightPrimaryBottom, 
                Position.BottomRightPrimaryRight,
                Position.BottomRightPrimaryRight
            };
            RubiksCube cube = new RubiksCube(data);
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
                new byte[] { Position.Unmasked, Position.Unmasked, Position.Unmasked, Position.Unmasked, Position.Unmasked, Position.Unmasked, Position.Unmasked,
                             Position.Unmasked, Position.Unmasked, Position.Unmasked, Position.Unmasked, Position.Unmasked, Position.Unmasked, Position.Unmasked, Position.Unmasked, Position.Unmasked, Position.Unmasked, Position.Unmasked, Position.Unmasked }
                );

            cube.ApplyMask(unmasked);

            Assert.AreEqual<byte>(Position.TopBackLeftPrimaryTop, cube[0]);
            Assert.AreEqual<byte>(Position.TopBackRightPrimaryTop, cube[1]);
            Assert.AreEqual<byte>(Position.TopFrontRightPrimaryTop, cube[2]);
            Assert.AreEqual<byte>(Position.TopFrontLeftPrimaryTop, cube[3]);
            Assert.AreEqual<byte>(Position.BottomBackLeftPrimaryBottom, cube[4]);
            Assert.AreEqual<byte>(Position.BottomBackRightPrimaryBottom, cube[5]);
            Assert.AreEqual<byte>(Position.BottomFrontRightPrimaryBottom, cube[6]);

            Assert.AreEqual<byte>(Position.TopLeftPrimaryTop, cube[7]);
            Assert.AreEqual<byte>(Position.TopBackPrimaryTop, cube[8]);
            Assert.AreEqual<byte>(Position.TopRightPrimaryTop, cube[9]);
            Assert.AreEqual<byte>(Position.TopFrontPrimaryTop, cube[10]);
            Assert.AreEqual<byte>(Position.BottomLeftPrimaryBottom, cube[11]);
            Assert.AreEqual<byte>(Position.BottomBackPrimaryBottom, cube[12]);
            Assert.AreEqual<byte>(Position.BottomRightPrimaryBottom, cube[13]);
            Assert.AreEqual<byte>(Position.BottomFrontPrimaryBottom, cube[14]);
            Assert.AreEqual<byte>(Position.FrontLeftPrimaryFront, cube[15]);
            Assert.AreEqual<byte>(Position.BackLeftPrimaryBack, cube[16]);
            Assert.AreEqual<byte>(Position.BackRightPrimaryBack, cube[17]);
            Assert.AreEqual<byte>(Position.FrontRightPrimaryFront, cube[18]);
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void RubiksCube_ApplyMask_SolvedCube_With_MaskedCube()
        {
            RubiksCube cube = new RubiksCube();
            RubiksCube masked = new RubiksCube(
                new byte[] { Position.Masked, Position.Masked, Position.Masked, Position.Masked, Position.Masked, Position.Masked, Position.Masked,
                             Position.Masked, Position.Masked, Position.Masked, Position.Masked, Position.Masked, Position.Masked, Position.Masked, Position.Masked, Position.Masked, Position.Masked, Position.Masked, Position.Masked }
                );

            cube = cube.ApplyMask(masked);

            Assert.AreEqual<int>(0, cube.GetBytes().Length);
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        [ExpectedException(typeof(ArgumentException))]
        public void RubiksCube_ApplyMask_SolvedCube_With_BadMask()
        {
            RubiksCube cube = new RubiksCube();
            RubiksCube masked = new RubiksCube(
                new byte[] { Position.TopBackLeftPrimaryLeft, Position.Masked, Position.Masked, Position.Masked, Position.Masked, Position.Masked, Position.Masked,
                             Position.Masked, Position.Masked, Position.Masked, Position.Masked, Position.Masked, Position.Masked, Position.Masked, Position.Masked, Position.Masked, Position.Masked, Position.Masked, Position.Masked }
                );

            cube.ApplyMask(masked);
        }
        
        [TestMethod]
        [TestCategory(@"Foat\Puzzles\RubiksCube")]
        public void RubiksCube_SolvedCube_ChangeAll()
        {
            RubiksCube cube = new RubiksCube();

            const byte value = 24;

            byte[] data = new byte[19];
            cube.ModifyPositionsIntoNewData(data, edge => value);

            Assert.AreEqual<byte>(value, data[0]);
            Assert.AreEqual<byte>(value, data[1]);
            Assert.AreEqual<byte>(value, data[2]);
            Assert.AreEqual<byte>(value, data[3]);
            Assert.AreEqual<byte>(value, data[4]);
            Assert.AreEqual<byte>(value, data[5]);
            Assert.AreEqual<byte>(value, data[6]);

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
