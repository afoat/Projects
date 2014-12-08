namespace RubiksCubeSolver
{
    using Foat.Puzzles.RubiksCube;
    using Foat.Puzzles.RubiksCube.Solution;
    using Foat.Puzzles.RubiksCube.Solution.ShortestPath;
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

            IRubiksCubeSolutionGenerator solutionGenerator = new ParallelIDAStar(soltutionEstimator);

            Random rnd = new Random();
            string inputFromUser;

            do
            {
                RubiksCube cube = new RubiksCube();
                for (int i = 0; i < 100; ++i)
                {
                    Move move = (Move)rnd.Next((int)Move.MaxMove);

                    Trace.WriteLine(string.Format("Mixing with move {0}.", move.ToString()));

                    cube = RubiksCubeController.Rotate(cube, move);
                }

                var solution = solutionGenerator.FindSolution(cube);

                if (solution == null)
                {
                    Console.WriteLine("No Solution Found.");
                }
                else
                {
                    foreach (Move move in solution)
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
