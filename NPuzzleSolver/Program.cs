using Foat.Puzzles.NPuzzle;
using Foat.Puzzles.NPuzzle.Solution;
using Foat.Puzzles.Solutions;
using Foat.Puzzles.Solutions.IDAStar;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPuzzleSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            Trace.WriteLine("Getting Pattern Sets From Disk");

            ManhattanDistance heuristic = new ManhattanDistance();

            NPuzzle newPuzzle = new NPuzzle(3);
            IPuzzleSolution<NPuzzle> solutionGenerator = new ParallelIDAStar<NPuzzle>(heuristic, newPuzzle);

            Random rnd = new Random();
            string inputFromUser;

            do
            {
                NPuzzle puzzle = newPuzzle;
                Move<NPuzzle> lastMove = null;

                for (int i = 0; i < 40; ++i)
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
                    
                    Trace.WriteLine(string.Format("Mixing with move {0}.", move.ToString()));

                    puzzle = move.MovePuzzle(puzzle);
                }

                var solution = solutionGenerator.FindSolution(puzzle);

                if (solution == null)
                {
                    Console.WriteLine("No Solution Found.");
                }
                else
                {
                    foreach (Move<NPuzzle> move in solution)
                    {
                        Trace.WriteLine(move.ToString());
                    }
                }

                Console.WriteLine("Press Q to quit, anything else to try another one.");

                inputFromUser = Console.ReadKey(true).KeyChar.ToString().ToLower();
            } while (!inputFromUser.Equals("q"));
        }
    }
}
