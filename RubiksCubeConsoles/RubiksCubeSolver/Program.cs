namespace RubiksCubeSolver
{
    using Foat.Puzzles.RubiksCube;
    using Foat.Puzzles.RubiksCube.Solution;
    using Foat.Puzzles.Solutions;
    using Foat.Puzzles.Solutions.IDAStar;
    using RubiksCubeSolver.Configuration;
    using System;
    using System.Diagnostics;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            if (!Directory.Exists(RubiksCubeSolverSettings.Current.PatternSetPath))
            {
                Trace.WriteLine(string.Format("Pattern Set Path Not Found: {0}", RubiksCubeSolverSettings.Current.PatternSetPath));
                return;
            }

            Trace.WriteLine("Getting Pattern Sets From Disk");
            
            SolutionLengthEstimator soltutionEstimator = new SolutionLengthEstimator(GetPatternSetFilenames());

            IPuzzleSolution<RubiksCube> solutionGenerator = new ParallelIDAStar<RubiksCube>(soltutionEstimator, new RubiksCube());

            Random rnd = new Random();
            string inputFromUser;

            RubiksCube newCube = new RubiksCube();
            Move<RubiksCube>[] moves = newCube.GetValidMoves();

            do
            {
                RubiksCube cube = newCube;

                for (int i = 0; i < 100; ++i)
                {
                    int moveId = rnd.Next(moves.Length);
                    Move<RubiksCube> move = moves[moveId];

                    Trace.WriteLine(string.Format("Mixing with move {0}.", move.ToString()));

                    cube = move.MovePuzzle(cube);
                }

                var solution = solutionGenerator.FindSolution(cube);

                if (solution == null)
                {
                    Console.WriteLine("No Solution Found.");
                }
                else
                {
                    foreach (Move<RubiksCube> move in solution)
                    {
                        Trace.WriteLine(move.ToString());
                    }
                }

                Console.WriteLine("Press Q to quit, anything else to try another one.");

                inputFromUser = Console.ReadKey(true).KeyChar.ToString().ToLower();
            } while (!inputFromUser.Equals("q"));

        }

        /// <summary>
        /// Reads in the names of all of the files in the pattern set folder.
        /// </summary>
        /// <returns></returns>
        private static string[] GetPatternSetFilenames()
        {
            return Directory.GetFiles(RubiksCubeSolverSettings.Current.PatternSetPath);
        }
    }
}
