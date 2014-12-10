namespace Foat.Puzzles.Solutions.IDAStar
{
    using Foat.Puzzles.Configuration;
    using Foat.Puzzles.Solutions;
    using System;
    using System.Collections;
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
            int minNumTasks = ParallelIDAStarSettings.Current.MinNumberOfTasks;

            if (minNumTasks < 1)
            {
                throw new InvalidOperationException("Must have at least one IDAStar task.");
            }
            else if (minNumTasks == 1)
            {
                return base.FindSolution(puzzleInstance);
            }
            else
            {

                if (puzzleInstance == null)
                    throw new ArgumentNullException("puzzleInstance");
                
                ConcurrentDictionary<TPuzzle, IEnumerable<Move<TPuzzle>>> workerInfo = new ConcurrentDictionary<TPuzzle, IEnumerable<Move<TPuzzle>>>();
                ConcurrentDictionary<TPuzzle, ulong> numberOfMoves = new ConcurrentDictionary<TPuzzle, ulong>();

                int maxDepth = this.Heuristic.GetMinimumEstimatedSolutionLength(puzzleInstance);
                bool found = false;
                long time = 0;
                while (!found)
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    Queue<PuzzleState<TPuzzle>> nodes = new Queue<PuzzleState<TPuzzle>>();

                    if (NodeLimitedBFS(puzzleInstance, minNumTasks, nodes))
                    {
                        return base.FindSolution(puzzleInstance);
                    }
                    else
                    {
                        Trace.WriteLine(string.Format("Searching to a maximum depth of - {0:N0}. Last Depth Took: {1} ms", maxDepth, time));

                        Task[] tasks = new Task[nodes.Count];
                        workerInfo.Clear();

                        for (int i = 0; i < tasks.Length; ++i)
                        {
                            PuzzleState<TPuzzle> puzzleState = nodes.Dequeue();
                            tasks[i] = Task.Factory.StartNew((state =>
                            {
                                ulong expandedNodes = 0;
                                PuzzleState<TPuzzle> newPuzzleState = (PuzzleState<TPuzzle>)state;
                                Stack<Move<TPuzzle>> currentSolution = new Stack<Move<TPuzzle>>();

                                if (this.DepthLimitedDFS(puzzleState, maxDepth, currentSolution, ref expandedNodes))
                                {
                                    currentSolution.Push(newPuzzleState.LastMove);
                                    workerInfo[newPuzzleState.PuzzleInstance] = currentSolution;
                                    numberOfMoves[newPuzzleState.PuzzleInstance] = expandedNodes;
                                    found = true;
                                }

                            }), puzzleState);
                        }

                        Task.WaitAll(tasks);
                        ++maxDepth;
                    }
                    stopwatch.Stop();
                    time = stopwatch.ElapsedMilliseconds;
                }
                
                this.NumberOfExpandedNodes = 0;
                foreach (ulong value in numberOfMoves.Values)
                {
                    this.NumberOfExpandedNodes += value;
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

                    IEnumerable<PuzzleState<TPuzzle>> childPuzzles = GetPuzzleStatesToExamine(puzzle, int.MaxValue);

                    foreach (PuzzleState<TPuzzle> puzzleState in childPuzzles)
                    {
                        if (!puzzlesToExpand.Contains(puzzleState.PuzzleInstance))
                        {
                            puzzlesToExpand.Add(puzzleState.PuzzleInstance);
                            nodes.Enqueue(new PuzzleState<TPuzzle>(puzzleState.LastMove, (byte)(puzzle.Depth + 1), puzzleState.PuzzleInstance));

                            if (puzzleState.PuzzleInstance.Equals(this.SolutionState))
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
