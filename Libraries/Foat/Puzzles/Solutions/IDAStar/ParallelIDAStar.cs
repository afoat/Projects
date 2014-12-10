namespace Foat.Puzzles.Solutions.IDAStar
{
    using Foat.Puzzles.Configuration;
    using Foat.Puzzles.Solutions;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    public sealed class ParallelIDAStar<TPuzzle> : IDAStar<TPuzzle> where TPuzzle : IPuzzle<TPuzzle>, IEquatable<TPuzzle>
    {
        public ParallelIDAStar(IHeuristic<TPuzzle> heuristic, TPuzzle solutionInstance) : base(heuristic, solutionInstance) { }

        public override IEnumerable<Move<TPuzzle>> FindSolution(TPuzzle puzzleInstance)
        {
            int numTasks = ParallelIDAStarSettings.Current.NumTasks;
            if (numTasks < 1)
            {
                throw new InvalidOperationException("Must have at least one IDAStar task.");
            }
            else if (numTasks == 1)
            {
                return base.FindSolution(puzzleInstance);
            }
            else
            {

                if (puzzleInstance == null)
                    throw new ArgumentNullException("puzzleInstance");


                ConcurrentDictionary<TPuzzle, IEnumerable<Move<TPuzzle>>> workerInfo = new ConcurrentDictionary<TPuzzle, IEnumerable<Move<TPuzzle>>>();

                int maxDepth = this.Heuristic.GetMinimumEstimatedSolutionLength(puzzleInstance);
                bool found = false;
                while (!found)
                {
                    Queue<PuzzleState<TPuzzle>> nodes = new Queue<PuzzleState<TPuzzle>>();

                    if (NodeLimitedBFS(puzzleInstance, numTasks, nodes))
                    {
                        return base.FindSolution(puzzleInstance);
                    }
                    else
                    {
                        Trace.WriteLine(string.Format("IDA* - Bound = {0:N0}", maxDepth));

                        Task[] tasks = new Task[nodes.Count];
                        workerInfo.Clear();

                        for (int i = 0; i < tasks.Length; ++i)
                        {
                            PuzzleState<TPuzzle> puzzleState = nodes.Dequeue();
                            tasks[i] = Task.Factory.StartNew((state =>
                            {
                                PuzzleState<TPuzzle> newPuzzleState = (PuzzleState<TPuzzle>)state;
                                Stack<Move<TPuzzle>> currentSolution = new Stack<Move<TPuzzle>>();

                                if (this.DepthLimitedDFS(puzzleState, maxDepth, currentSolution))
                                {
                                    currentSolution.Push(newPuzzleState.LastMove);
                                    workerInfo[newPuzzleState.PuzzleInstance] = currentSolution;
                                    found = true;
                                }

                            }), puzzleState);
                        }

                        Task.WaitAll(tasks);
                        ++maxDepth;
                    }
                }

                return workerInfo.Values
                                 .Where(solution => solution != null && solution.Count() > 0)
                                 .FirstOrDefault(); // First or default because we might find two solutions at the same depth
            }
        }

        private bool NodeLimitedBFS(TPuzzle puzzleInstance, int minNumNodes, Queue<PuzzleState<TPuzzle>> nodes)
        {
            nodes.Clear();

            if (!puzzleInstance.Equals(this.SolutionState))
            {
                HashSet<TPuzzle> puzzlesToExpand = new HashSet<TPuzzle>();
                bool solutionFound = false;
                nodes.Enqueue(new PuzzleState<TPuzzle>(0, puzzleInstance));
                while (!solutionFound && nodes.Count < minNumNodes)
                {
                    PuzzleState<TPuzzle> puzzle = nodes.Dequeue();

                    Move<TPuzzle>[] moves;
                    if (puzzle.LastMove == null)
                    {
                        moves = puzzle.PuzzleInstance.GetValidMoves();
                    }
                    else
                    {
                        moves = puzzle.LastMove.GetValidNextMoves(puzzle.PuzzleInstance);
                    }

                    foreach (Move<TPuzzle> move in moves)
                    {
                        TPuzzle newPuzzle = move.MovePuzzle(puzzle.PuzzleInstance);
                        if (!puzzlesToExpand.Contains(newPuzzle))
                        {
                            puzzlesToExpand.Add(newPuzzle);
                            nodes.Enqueue(new PuzzleState<TPuzzle>(move, (byte)(puzzle.Depth + 1), newPuzzle));

                            if (newPuzzle.Equals(this.SolutionState))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            else
            {
                return true;
            }

            return false;
        }
    }
}
