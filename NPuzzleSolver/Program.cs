namespace NPuzzleSolver
{
    using Foat.Puzzles.NPuzzle;
    using Foat.Puzzles.NPuzzle.Solution;
    using Foat.Puzzles.Solutions;
    using Foat.Puzzles.Solutions.IDAStar;
    using System;
    using System.Diagnostics;

    class Program
    {
        static void Main(string[] args)
        {
            ManhattanDistance heuristic = new ManhattanDistance();

            NPuzzle newPuzzle = new NPuzzle(3);
            IPuzzleSolution<NPuzzle> solutionGenerator = new ParallelIDAStar<NPuzzle>(heuristic, newPuzzle);

            Random rnd = new Random();
            string inputFromUser;

            do
            {
                NPuzzle puzzle = newPuzzle;
                Move<NPuzzle> lastMove = null;
                int timesMoved = 0;

                Trace.WriteLine("Mixing puzzle");
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

                Trace.WriteLine(string.Format("Made {0} moves.", timesMoved));
                Trace.WriteLine(puzzle.ToString());

                var solution = solutionGenerator.FindSolution(puzzle);

                if (solution == null)
                {
                    Trace.WriteLine("No Solution Found.");
                }
                else
                {
                    foreach (Move<NPuzzle> move in solution)
                    {
                        Trace.WriteLine(move.ToString());
                    }
                }

                Trace.WriteLine("Press Q to quit, anything else to try another one.");

                inputFromUser = Console.ReadKey(true).KeyChar.ToString().ToLower();
            } while (!inputFromUser.Equals("q"));
        }
    }
}
