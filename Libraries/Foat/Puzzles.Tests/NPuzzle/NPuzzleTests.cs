namespace Foat.Puzzles.Tests.NPuzzle
{
    using Foat.Puzzles.NPuzzle;
    using Foat.Puzzles.Solutions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;

    [TestClass]
    public class NPuzzleTests
    {
        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void IsPuzzleSolvable_NullException()
        {
            Assert.IsFalse(NPuzzle.IsPuzzleValid(null));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void IsPuzzleSolvable_NotSquare_TooWide()
        {
            Assert.IsFalse(NPuzzle.IsPuzzleValid(new byte[,] { { 1, 2, 3},
                                                               { 4, 5, 0} }));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void IsPuzzleSolvable_NotSquare_TooTall()
        {
            Assert.IsFalse(NPuzzle.IsPuzzleValid(new byte[,] { { 1, 2},
                                                               { 3, 4},
                                                               { 5, 0} }));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void IsPuzzleSolvable_DimensionTooSmall()
        {
            Assert.IsFalse(NPuzzle.IsPuzzleValid(new byte[,] { { 1 } }));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void IsPuzzleSolvable_TooLargeException()
        {
            Assert.IsFalse(NPuzzle.IsPuzzleValid(new byte[,] { 
                                                { 01, 02, 03, 04, 05, 06, 07, 08, 09, 10, 11, 12, 13, 14, 15, 16 },
                                                { 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 },
                                                { 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48 },
                                                { 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64 },
                                                { 01, 02, 03, 04, 05, 06, 07, 08, 09, 10, 11, 12, 13, 14, 15, 16 },
                                                { 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 },
                                                { 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48 },
                                                { 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64 },
                                                { 01, 02, 03, 04, 05, 06, 07, 08, 09, 10, 11, 12, 13, 14, 15, 16 },
                                                { 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 },
                                                { 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48 },
                                                { 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64 },
                                                { 01, 02, 03, 04, 05, 06, 07, 08, 09, 10, 11, 12, 13, 14, 15, 16 },
                                                { 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 },
                                                { 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48 },
                                                { 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64 } 
            }));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void IsPuzzleSolvable_Invalid_NumberTooLarge()
        {
            Assert.IsFalse(NPuzzle.IsPuzzleValid(new byte[,] { { 1, 2, 3 },
                                                               { 4, 5, 6 },
                                                               { 7, 8, 9 } }));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void IsPuzzleSolvable_Invalid_DuplicateNumber()
        {
            Assert.IsFalse(NPuzzle.IsPuzzleValid(new byte[,] { { 1, 2, 3 },
                                                               { 4, 5, 5 },
                                                               { 7, 8, 0 } }));
        }

        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        [ExpectedException(typeof(ArgumentException))]
        public void IsPuzzleSolvable_Invalid_MissingNumber()
        {
            Assert.IsFalse(NPuzzle.IsPuzzleValid(new byte[,] { { 1, 2, 3 },
                                                               { 4, 5, 0 },
                                                               { 7, 8, 0 } }));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void IsPuzzleSolvable_Valid_N2()
        {
            Assert.IsTrue(NPuzzle.IsPuzzleValid(new byte[,] { { 1, 2 },
                                                              { 3, 0 } }));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void IsPuzzleSolvable_Valid_N3()
        {
            Assert.IsTrue(NPuzzle.IsPuzzleValid(new byte[,] { { 1, 2, 3 },
                                                              { 4, 5, 6 },
                                                              { 7, 8, 0 } }));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void IsPuzzleSolvable_N3_InvalidOrder()
        {
            Assert.IsFalse(NPuzzle.IsPuzzleValid(new byte[,] { { 2, 1, 3 }, 
                                                               { 4, 5, 6 },
                                                               { 7, 8, 0 } }));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void IsPuzzleSolvable_N4_0_On_Even_Row_InvalidOrder()
        {
            Assert.IsFalse(NPuzzle.IsPuzzleValid(new byte[,] { {2 , 1 , 3 , 4 },
                                                               {5 , 6 , 7 , 8 },
                                                               {9 , 10, 11, 12},
                                                               {13, 14, 15, 0 } }));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void IsPuzzleSolvable_N4_0_On_Odd_Row_InvalidOrder()
        {
            Assert.IsFalse(NPuzzle.IsPuzzleValid(new byte[,] { {2 , 1 , 3 , 4 },
                                                               {5 , 6 , 7 , 8 },
                                                               {9 , 10, 11, 0},
                                                               {13, 14, 15, 12} }));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        [ExpectedException(typeof(ArgumentException))]
        public void DimensionConstruction_TooSmallException()
        {
            NPuzzle puzzle = new NPuzzle(1);
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        [ExpectedException(typeof(ArgumentException))]
        public void DimensionConstruction_TooLargeException()
        {
            NPuzzle puzzle = new NPuzzle(16);
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void DimensionConstruction_N3()
        {
            NPuzzle puzzle = new NPuzzle(3);

            Assert.AreEqual<int>(1, puzzle.GetValue(0, 0));
            Assert.AreEqual<int>(2, puzzle.GetValue(0, 1));
            Assert.AreEqual<int>(3, puzzle.GetValue(0, 2));
            Assert.AreEqual<int>(4, puzzle.GetValue(1, 0));
            Assert.AreEqual<int>(5, puzzle.GetValue(1, 1));
            Assert.AreEqual<int>(6, puzzle.GetValue(1, 2));
            Assert.AreEqual<int>(7, puzzle.GetValue(2, 0));
            Assert.AreEqual<int>(8, puzzle.GetValue(2, 1));
            Assert.AreEqual<int>(0, puzzle.GetValue(2, 2));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void DimensionConstruction_N4()
        {
            NPuzzle puzzle = new NPuzzle(4);

            Assert.AreEqual<int>(1, puzzle.GetValue(0, 0));
            Assert.AreEqual<int>(2, puzzle.GetValue(0, 1));
            Assert.AreEqual<int>(3, puzzle.GetValue(0, 2));
            Assert.AreEqual<int>(4, puzzle.GetValue(0, 3));
            Assert.AreEqual<int>(5, puzzle.GetValue(1, 0));
            Assert.AreEqual<int>(6, puzzle.GetValue(1, 1));
            Assert.AreEqual<int>(7, puzzle.GetValue(1, 2));
            Assert.AreEqual<int>(8, puzzle.GetValue(1, 3));
            Assert.AreEqual<int>(9, puzzle.GetValue(2, 0));
            Assert.AreEqual<int>(10, puzzle.GetValue(2, 1));
            Assert.AreEqual<int>(11, puzzle.GetValue(2, 2));
            Assert.AreEqual<int>(12, puzzle.GetValue(2, 3));
            Assert.AreEqual<int>(13, puzzle.GetValue(3, 0));
            Assert.AreEqual<int>(14, puzzle.GetValue(3, 1));
            Assert.AreEqual<int>(15, puzzle.GetValue(3, 2));
            Assert.AreEqual<int>(0, puzzle.GetValue(3, 3));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InitializationConstruction_NullException()
        {
            NPuzzle puzzle = new NPuzzle(null);
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        [ExpectedException(typeof(ArgumentException))]
        public void InitializationConstruction_NotSquareException_TooWide()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { { 1, 2, 3},
                                                       { 4, 5, 0} });
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        [ExpectedException(typeof(ArgumentException))]
        public void InitializationConstruction_NotSquareException_TooTall()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { { 1, 2},
                                                       { 3, 4},
                                                       { 5, 0} });
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        [ExpectedException(typeof(ArgumentException))]
        public void InitializationConstruction_TooSmallException()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { { 1 } });
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        [ExpectedException(typeof(ArgumentException))]
        public void InitializationConstruction_TooLargeException()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { { 01, 02, 03, 04, 05, 06, 07, 08, 09, 10, 11, 12, 13, 14, 15, 16 },
                                                       { 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 },
                                                       { 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48 },
                                                       { 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64 },
                                                       { 01, 02, 03, 04, 05, 06, 07, 08, 09, 10, 11, 12, 13, 14, 15, 16 },
                                                       { 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 },
                                                       { 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48 },
                                                       { 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64 },
                                                       { 01, 02, 03, 04, 05, 06, 07, 08, 09, 10, 11, 12, 13, 14, 15, 16 },
                                                       { 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 },
                                                       { 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48 },
                                                       { 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64 },
                                                       { 01, 02, 03, 04, 05, 06, 07, 08, 09, 10, 11, 12, 13, 14, 15, 16 },
                                                       { 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 },
                                                       { 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48 },
                                                       { 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64 } } );
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        [ExpectedException(typeof(ArgumentException))]
        public void InitializationConstruction_InvalidNumberTooLargeException()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { { 1, 2, 3 },
                                                       { 4, 5, 6 },
                                                       { 7, 8, 9 } });
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        [ExpectedException(typeof(ArgumentException))]
        public void InitializationConstruction_DuplicateNumberException()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { { 1, 2, 3 },
                                                       { 4, 5, 5 },
                                                       { 7, 8, 0 } });
        }

        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        [ExpectedException(typeof(ArgumentException))]
        public void InitializationConstruction_MissingNumberException()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { { 1, 2, 3 },
                                                       { 4, 5, 0 },
                                                       { 7, 8, 0 } });
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void InitializationConstruction_N2()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { { 1, 2 },
                                                      { 3, 0 } });

            Assert.AreEqual<int>(1, puzzle.GetValue(0, 0));
            Assert.AreEqual<int>(2, puzzle.GetValue(0, 1));
            Assert.AreEqual<int>(3, puzzle.GetValue(1, 0));
            Assert.AreEqual<int>(0, puzzle.GetValue(1, 1));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void InitializationConstruction_N3()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { { 1, 2, 3 },
                                                       { 4, 5, 6 },
                                                       { 7, 8, 0 } } );

            Assert.AreEqual<int>(1, puzzle.GetValue(0, 0));
            Assert.AreEqual<int>(2, puzzle.GetValue(0, 1));
            Assert.AreEqual<int>(3, puzzle.GetValue(0, 2));
            Assert.AreEqual<int>(4, puzzle.GetValue(1, 0));
            Assert.AreEqual<int>(5, puzzle.GetValue(1, 1));
            Assert.AreEqual<int>(6, puzzle.GetValue(1, 2));
            Assert.AreEqual<int>(7, puzzle.GetValue(2, 0));
            Assert.AreEqual<int>(8, puzzle.GetValue(2, 1));
            Assert.AreEqual<int>(0, puzzle.GetValue(2, 2));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        [ExpectedException(typeof(ArgumentException))]
        public void InitializationConstruction_N3_UnsolvableException()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { { 2, 1, 3 }, 
                                                       { 4, 5, 6 },
                                                       { 7, 8, 0 } });
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        [ExpectedException(typeof(ArgumentException))]
        public void InitializationConstruction_N4_UnsolvableException1()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {2, 1, 3, 4},
                                                       {5, 6, 7, 8},
                                                       {9, 10, 11, 12},
                                                       {13, 14, 15, 0 } });
        }
        
        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void GetValidMoves_EmptyMiddle()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {1, 2, 3},
                                                       {4, 0, 5}, 
                                                       {6, 7, 8} });

            Move<NPuzzle>[] moves = puzzle.GetValidMoves();

            Assert.AreEqual(4, moves.Length);
            Assert.IsTrue(moves.Any(move => move.Name == "Up"));
            Assert.IsTrue(moves.Any(move => move.Name == "Down"));
            Assert.IsTrue(moves.Any(move => move.Name == "Left"));
            Assert.IsTrue(moves.Any(move => move.Name == "Right"));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void GetValidMoves_EmptyTopLeft()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {0, 1, 2},
                                                       {3, 4, 5}, 
                                                       {6, 7, 8 }});

            Move<NPuzzle>[] moves = puzzle.GetValidMoves();

            Assert.AreEqual(2, moves.Length);
            Assert.IsTrue(moves.Any(move => move.Name == "Up"));
            Assert.IsTrue(moves.Any(move => move.Name == "Left"));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void GetValidMoves_EmptyTopRight()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {1, 3, 0},
                                                       {4, 2, 5}, 
                                                       {6, 7, 8} });

            Move<NPuzzle>[] moves = puzzle.GetValidMoves();

            Assert.AreEqual(2, moves.Length);
            Assert.IsTrue(moves.Any(move => move.Name == "Up"));
            Assert.IsTrue(moves.Any(move => move.Name == "Right"));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void GetValidMoves_EmptyBottomRight()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {1, 3, 5},
                                                       {4, 2, 8}, 
                                                       {6, 7, 0} });

            Move<NPuzzle>[] moves = puzzle.GetValidMoves();

            Assert.AreEqual(2, moves.Length);
            Assert.IsTrue(moves.Any(move => move.Name == "Down"));
            Assert.IsTrue(moves.Any(move => move.Name == "Right"));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void GetValidMoves_EmptyBottomLeft()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {1, 3, 5},
                                                       {4, 2, 8}, 
                                                       {0, 6, 7} });

            Move<NPuzzle>[] moves = puzzle.GetValidMoves();

            Assert.AreEqual(2, moves.Length);
            Assert.IsTrue(moves.Any(move => move.Name == "Down"));
            Assert.IsTrue(moves.Any(move => move.Name == "Left"));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void GetValidMoves_EmptyTopMiddle()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {1, 0, 2},
                                                       {3, 4, 5}, 
                                                       {6, 7, 8} });

            Move<NPuzzle>[] moves = puzzle.GetValidMoves();

            Assert.AreEqual(3, moves.Length);
            Assert.IsTrue(moves.Any(move => move.Name == "Up"));
            Assert.IsTrue(moves.Any(move => move.Name == "Right"));
            Assert.IsTrue(moves.Any(move => move.Name == "Left"));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void GetValidMoves_EmptyMiddleRight()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {1, 2, 3},
                                                       {4, 5, 0}, 
                                                       {6, 7, 8} });

            Move<NPuzzle>[] moves = puzzle.GetValidMoves();

            Assert.AreEqual(3, moves.Length);
            Assert.IsTrue(moves.Any(move => move.Name == "Up"));
            Assert.IsTrue(moves.Any(move => move.Name == "Down"));
            Assert.IsTrue(moves.Any(move => move.Name == "Right"));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void GetValidMoves_EmptyMiddleLeft()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {1, 2, 3},
                                                       {0, 4, 5}, 
                                                       {6, 7, 8} });

            Move<NPuzzle>[] moves = puzzle.GetValidMoves();

            Assert.AreEqual(3, moves.Length);
            Assert.IsTrue(moves.Any(move => move.Name == "Up"));
            Assert.IsTrue(moves.Any(move => move.Name == "Down"));
            Assert.IsTrue(moves.Any(move => move.Name == "Left"));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void GetValidMoves_EmptyBottomMiddle()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {1, 2, 3},
                                                       {4, 5, 6}, 
                                                       {7, 0, 8} });

            Move<NPuzzle>[] moves = puzzle.GetValidMoves();

            Assert.AreEqual(3, moves.Length);
            Assert.IsTrue(moves.Any(move => move.Name == "Down"));
            Assert.IsTrue(moves.Any(move => move.Name == "Right"));
            Assert.IsTrue(moves.Any(move => move.Name == "Left"));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SlideUp_Exception1()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {1, 2, 3},
                                                       {4, 5, 6}, 
                                                       {7, 8, 0} });

            puzzle.SlideUp();
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SlideUp_Exception2()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {1, 2, 3},
                                                       {8, 5, 6}, 
                                                       {4, 0, 7} });

            puzzle.SlideUp();
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SlideUp_Exception3()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {1, 2, 3},
                                                       {8, 5, 6}, 
                                                       {0, 4, 7} });

            puzzle.SlideUp();
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void SlideUp_FromBottomRight()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {1, 2, 3},
                                                       {4, 5, 0}, 
                                                       {6, 7, 8} });

            NPuzzle newPuzzle = puzzle.SlideUp();

            Assert.AreEqual(8, newPuzzle.GetValue(1, 2));
            Assert.AreEqual(0, newPuzzle.GetValue(2, 2));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void SlideUp_FromBottomMiddle()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {1, 2, 3},
                                                       {4, 0, 5}, 
                                                       {6, 7, 8} });

            NPuzzle newPuzzle = puzzle.SlideUp();

            Assert.AreEqual(7, newPuzzle.GetValue(1, 1));
            Assert.AreEqual(0, newPuzzle.GetValue(2, 1));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void SlideUp_FromBottomLeft()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {1, 2, 3},
                                                       {0, 4, 5}, 
                                                       {6, 7, 8} });

            NPuzzle newPuzzle = puzzle.SlideUp();

            Assert.AreEqual(6, newPuzzle.GetValue(1, 0));
            Assert.AreEqual(0, newPuzzle.GetValue(2, 0));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void SlideUp_FromMiddleRight()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {1, 2, 0},
                                                       {4, 5, 3}, 
                                                       {6, 7, 8} });

            NPuzzle newPuzzle = puzzle.SlideUp();

            Assert.AreEqual(3, newPuzzle.GetValue(0, 2));
            Assert.AreEqual(0, newPuzzle.GetValue(1, 2));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void SlideUp_FromMiddle()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {1, 2, 0},
                                                       {4, 5, 3}, 
                                                       {6, 7, 8} });

            NPuzzle newPuzzle = puzzle.SlideUp();

            Assert.AreEqual(3, newPuzzle.GetValue(0, 2));
            Assert.AreEqual(0, newPuzzle.GetValue(1, 2));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void SlideUp_FromMiddleLeft()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {0, 1, 2},
                                                       {3, 4, 5}, 
                                                       {6, 7, 8} });

            NPuzzle newPuzzle = puzzle.SlideUp();

            Assert.AreEqual(3, newPuzzle.GetValue(0, 0));
            Assert.AreEqual(0, newPuzzle.GetValue(1, 0));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SlideDown_Exception1()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {0, 1, 2},
                                                       {3, 4, 5}, 
                                                       {6, 7, 8} });

            puzzle.SlideDown();
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SlideDown_Exception2()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {1, 0, 2},
                                                       {3, 4, 5}, 
                                                       {6, 7, 8} });

            puzzle.SlideDown();
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SlideDown_Exception3()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {1, 2, 0},
                                                       {3, 4, 5}, 
                                                       {6, 7, 8} });

            puzzle.SlideDown();
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void SlideDown_FromTopRight()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {1, 2, 3},
                                                       {4, 5, 0}, 
                                                       {6, 7, 8} });

            NPuzzle newPuzzle = puzzle.SlideDown();

            Assert.AreEqual(0, newPuzzle.GetValue(0, 2));
            Assert.AreEqual(3, newPuzzle.GetValue(1, 2));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void SlideDown_FromTopMiddle()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {1, 2, 3},
                                                       {4, 0, 5}, 
                                                       {6, 7, 8} });

            NPuzzle newPuzzle = puzzle.SlideDown();

            Assert.AreEqual(0, newPuzzle.GetValue(0, 1));
            Assert.AreEqual(2, newPuzzle.GetValue(1, 1));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void SlideDown_FromTopLeft()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {1, 2, 3},
                                                       {0, 4, 5}, 
                                                       {6, 7, 8} });

            NPuzzle newPuzzle = puzzle.SlideDown();

            Assert.AreEqual(0, newPuzzle.GetValue(0, 0));
            Assert.AreEqual(1, newPuzzle.GetValue(1, 0));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void SlideDown_FromMiddleRight()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {1, 2, 3},
                                                       {4, 5, 6}, 
                                                       {7, 8, 0} });

            NPuzzle newPuzzle = puzzle.SlideDown();

            Assert.AreEqual(6, newPuzzle.GetValue(2, 2));
            Assert.AreEqual(0, newPuzzle.GetValue(1, 2));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void SlideDown_FromMiddle()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {1, 2, 3},
                                                       {4, 5, 6}, 
                                                       {7, 0, 8} });

            NPuzzle newPuzzle = puzzle.SlideDown();

            Assert.AreEqual(0, newPuzzle.GetValue(1, 1));
            Assert.AreEqual(5, newPuzzle.GetValue(2, 1));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void SlideDown_FromMiddleLeft()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {1, 2, 3},
                                                       {4, 5, 6}, 
                                                       {0, 7, 8} });

            NPuzzle newPuzzle = puzzle.SlideDown();

            Assert.AreEqual(4, newPuzzle.GetValue(2, 0));
            Assert.AreEqual(0, newPuzzle.GetValue(1, 0));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SlideLeft_Exception1()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {1, 2, 0},
                                                       {3, 4, 5}, 
                                                       {6, 7, 8} });

            puzzle.SlideLeft();
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SlideLeft_Exception2()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {1, 2, 5},
                                                       {3, 4, 0}, 
                                                       {6, 7, 8} });

            puzzle.SlideLeft();
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SlideLeft_Exception3()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {1, 2, 5},
                                                       {3, 4, 8}, 
                                                       {6, 7, 0} });

            puzzle.SlideLeft();
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void SlideLeft_FromTopMiddle()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {0, 1, 2},
                                                       {3, 4, 5}, 
                                                       {6, 7, 8} });

            NPuzzle newPuzzle = puzzle.SlideLeft();

            Assert.AreEqual(1, newPuzzle.GetValue(0, 0));
            Assert.AreEqual(0, newPuzzle.GetValue(0, 1));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void SlideLeft_FromMiddle()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {3, 1, 2},
                                                       {0, 4, 5}, 
                                                       {6, 7, 8} });

            NPuzzle newPuzzle = puzzle.SlideLeft();

            Assert.AreEqual(4, newPuzzle.GetValue(1, 0));
            Assert.AreEqual(0, newPuzzle.GetValue(1, 1));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void SlideLeft_FromBottomMiddle()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {3, 1, 2},
                                                       {6, 4, 5}, 
                                                       {0, 7, 8} });

            NPuzzle newPuzzle = puzzle.SlideLeft();

            Assert.AreEqual(7, newPuzzle.GetValue(2, 0));
            Assert.AreEqual(0, newPuzzle.GetValue(2, 1));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void SlideLeft_FromTopRight()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {1, 0, 2},
                                                       {3, 4, 5},
                                                       {6, 7, 8} });

            NPuzzle newPuzzle = puzzle.SlideLeft();

            Assert.AreEqual(2, newPuzzle.GetValue(0, 1));
            Assert.AreEqual(0, newPuzzle.GetValue(0, 2));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void SlideLeft_FromMiddleRight()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {1, 4, 2},
                                                       {3, 0, 5},
                                                       {6, 7, 8} });

            NPuzzle newPuzzle = puzzle.SlideLeft();

            Assert.AreEqual(5, newPuzzle.GetValue(1, 1));
            Assert.AreEqual(0, newPuzzle.GetValue(1, 2));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void SlideLeft_FromBottomRight()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {1, 4, 2},
                                                       {3, 7, 5},
                                                       {6, 0, 8} });

            NPuzzle newPuzzle = puzzle.SlideLeft();

            Assert.AreEqual(8, newPuzzle.GetValue(2, 1));
            Assert.AreEqual(0, newPuzzle.GetValue(2, 2));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SlideRight_Exception1()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {0, 1, 2},
                                                       {3, 4, 5}, 
                                                       {6, 7, 8} });

            puzzle.SlideRight();
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SlideRight_Exception2()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {3, 1, 2},
                                                       {0, 4, 5}, 
                                                       {6, 7, 8} });

            puzzle.SlideRight();
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SlideRight_Exception3()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {3, 1, 2},
                                                       {6, 4, 5}, 
                                                       {0, 7, 8} });

            puzzle.SlideRight();
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void SlideRight_FromTopLeft()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {1, 0, 2},
                                                       {3, 4, 5}, 
                                                       {6, 7, 8} });

            NPuzzle newPuzzle = puzzle.SlideRight();

            Assert.AreEqual(0, newPuzzle.GetValue(0, 0));
            Assert.AreEqual(1, newPuzzle.GetValue(0, 1));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void SlideRight_FromMiddleLeft()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {1, 4, 2},
                                                       {3, 0, 5}, 
                                                       {6, 7, 8} });

            NPuzzle newPuzzle = puzzle.SlideRight();

            Assert.AreEqual(0, newPuzzle.GetValue(1, 0));
            Assert.AreEqual(3, newPuzzle.GetValue(1, 1));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void SlideRight_FromBottomLeft()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {1, 4, 2},
                                                       {3, 7, 5}, 
                                                       {6, 0, 8} });

            NPuzzle newPuzzle = puzzle.SlideRight();

            Assert.AreEqual(0, newPuzzle.GetValue(2, 0));
            Assert.AreEqual(6, newPuzzle.GetValue(2, 1));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void SlideRight_FromTopMiddle()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {1, 2, 0},
                                                       {3, 4, 5}, 
                                                       {6, 7, 8} });

            NPuzzle newPuzzle = puzzle.SlideRight();

            Assert.AreEqual(0, newPuzzle.GetValue(0, 1));
            Assert.AreEqual(2, newPuzzle.GetValue(0, 2));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void SlideRight_FromMiddle()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {1, 2, 5},
                                                       {3, 4, 0}, 
                                                       {6, 7, 8} });

            NPuzzle newPuzzle = puzzle.SlideRight();

            Assert.AreEqual(0, newPuzzle.GetValue(1, 1));
            Assert.AreEqual(4, newPuzzle.GetValue(1, 2));
        }

        [TestMethod]
        [TestCategory(@"Foat\Puzzles\NPuzzle")]
        public void SlideRight_FromBottomMiddle()
        {
            NPuzzle puzzle = new NPuzzle(new byte[,] { {1, 2, 5},
                                                       {3, 4, 8},
                                                       {6, 7, 0} });

            NPuzzle newPuzzle = puzzle.SlideRight();

            Assert.AreEqual(0, newPuzzle.GetValue(2, 1));
            Assert.AreEqual(7, newPuzzle.GetValue(2, 2));
        }
    }
}
