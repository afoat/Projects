namespace NPuzzleSolver
{
    using Foat.Puzzles.NPuzzle;
    using Foat.Puzzles.NPuzzle.Solution;
    using Foat.Puzzles.Solutions;
    using Foat.Puzzles.Solutions.Heuristics;
    using Foat.Puzzles.Solutions.IDAStar;
    using System;
    using System.Diagnostics;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            IHeuristic<NPuzzle> heuristic = new LinearConflict();

            NPuzzle newPuzzle = new NPuzzle(4);
            IPuzzleSolution<NPuzzle> solutionGenerator = new ParallelIDAStar<NPuzzle>(heuristic, newPuzzle);
            solutionGenerator.StatusUpdate += DoStatusUpdate;

            Random rnd = new Random(3);
            string inputFromUser = "";

            do
            {
                NPuzzle puzzle = newPuzzle;
                Move<NPuzzle> lastMove = null;
                int timesMoved = 0;

                Console.WriteLine("Mixing puzzle");
                for (int i = 0; i < 10000; ++i)
                {
                    Move<NPuzzle>[] validMoves;

                    if (lastMove == null)
                    {
                        validMoves = puzzle.GetValidMoves();
                    }
                    else
                    {
                        validMoves = lastMove.GetValidNextMoves(puzzle);
                    }

                    int numberOfMoves = validMoves.Length;
                    int moveId = rnd.Next(numberOfMoves);
                    Move<NPuzzle> move = validMoves[moveId];
                    lastMove = move;

                    puzzle = move.MovePuzzle(puzzle);
                    timesMoved++;
                }

                Console.WriteLine(string.Format("Made {0} moves.\n", timesMoved));
                Console.WriteLine(puzzle.ToString());

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                var solution = solutionGenerator.Solve(puzzle);
                stopwatch.Stop();

                if (solution == null)
                {
                    Console.WriteLine("\nNo Solution Found.");
                }
                else
                {
                    Console.WriteLine("\nSolution Found.");
                    foreach (Move<NPuzzle> move in solution)
                    {
                        Console.Write(move.ToString());
                        Console.Write(" ");
                    }

                    Console.WriteLine(string.Format("\n\nElapsed Time in ms: {0}", stopwatch.ElapsedMilliseconds));
                    Console.WriteLine(string.Format("Expanded {0} nodes. Found a solution that is {1} moves long.", solutionGenerator.NumberOfExpandedNodes, solution.Count()));
                }

                Console.WriteLine("Press Q to quit, anything else to try another one.");

                inputFromUser = Console.ReadKey(true).KeyChar.ToString().ToLower();
            } while (!inputFromUser.Equals("q"));
        }

        static void DoStatusUpdate(object sender, PuzzleSolutionEventArgs e)
        {
            Console.WriteLine(string.Format("Finished searching for a solution of length {0}. Expanded {1} nodes so far.", e.SearchDepth, e.NumberOfExpandedNodes));
        }
    }
}
