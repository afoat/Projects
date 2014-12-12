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

        #region Properties

        private ConcurrentDictionary<TPuzzle, IEnumerable<Move<TPuzzle>>> TaskSolutions;
        private ConcurrentBag<ulong> NumberOfExpandedNodesInTasks;
        private ConcurrentBag<int> TaskResults;

        #endregion

        #region Construction

        public ParallelIDAStar(IHeuristic<TPuzzle> heuristic, TPuzzle solutionInstance) : base(heuristic, solutionInstance)
        {
            this.TaskSolutions = null;
            this.TaskResults = null;
            this.NumberOfExpandedNodesInTasks = null;
        }

        #endregion

        #region Public Methods

        public override IEnumerable<Move<TPuzzle>> FindSolution(TPuzzle puzzleInstance)
        {
            if (puzzleInstance == null)
                throw new ArgumentNullException("puzzleInstance");

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
                return FindSolutionParallel(puzzleInstance, minNumTasks);
            }
        }

        #endregion

        #region Private Methods

        private IEnumerable<Move<TPuzzle>> FindSolutionParallel(TPuzzle puzzleInstance, int minNumTasks)
        {
            try
            {
                long time = 0;

                this.TaskSolutions = new ConcurrentDictionary<TPuzzle, IEnumerable<Move<TPuzzle>>>();

                int maxDepth = this.Heuristic.GetMinimumEstimatedSolutionLength(puzzleInstance);

                while (maxDepth != FoundResult)
                {
                    this.NumberOfExpandedNodesInTasks = new ConcurrentBag<ulong>();
                    this.TaskResults = new ConcurrentBag<int>();
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

                    Queue<PuzzleState<TPuzzle>> taskPuzzleStates;

                    if (NodeLimitedBFS(puzzleInstance, minNumTasks, out taskPuzzleStates))
                    {
                        return base.FindSolution(puzzleInstance);
                    }
                    else
                    {
                        Trace.WriteLine(string.Format(Logging.IDAStarDepthUpdate, maxDepth, time));

                        Task[] tasks = new Task[taskPuzzleStates.Count];
                        TaskSolutions.Clear();

                        for (int i = 0; i < tasks.Length; ++i)
                        {
                            tasks[i] = Task.Factory.StartNew(
                                (puzzleState => TaskResults.Add(StartTask(maxDepth, (PuzzleState<TPuzzle>)puzzleState)))
                                , taskPuzzleStates.Dequeue());
                        }

                        Task.WaitAll(tasks);

                        maxDepth = this.TaskResults.Min();
                    }
                    stopwatch.Stop();
                    time = stopwatch.ElapsedMilliseconds;
                }

                SetTotalNumberOfNodes();

                return TaskSolutions.Values
                                 .Where(solution => solution != null && solution.Count() > 0)
                                 .FirstOrDefault(); // First or default because we might find two solutions at the same depth
            }
            finally
            {
                this.TaskSolutions = null;
                this.NumberOfExpandedNodesInTasks = null;
            }
        }

        private void SetTotalNumberOfNodes()
        {
            this.NumberOfExpandedNodes = 0;
            if (this.NumberOfExpandedNodesInTasks != null)
            {
                foreach (ulong numberOfNodes in this.NumberOfExpandedNodesInTasks)
                {
                    this.NumberOfExpandedNodes += numberOfNodes;
                }
            }
        }

        private bool NodeLimitedBFS(TPuzzle puzzleInstance, int minNumNodes, out Queue<PuzzleState<TPuzzle>> nodes)
        {
            nodes = new Queue<PuzzleState<TPuzzle>>();
            if (!puzzleInstance.Equals(this.SolutionState))
            {
                bool solutionFound = false;
                HashSet<TPuzzle> puzzlesToExpand = new HashSet<TPuzzle>();

                nodes.Enqueue(new PuzzleState<TPuzzle>(0, puzzleInstance));

                while (!solutionFound && nodes.Count < minNumNodes)
                {
                    PuzzleState<TPuzzle> puzzle = nodes.Dequeue();

                    IEnumerable<PuzzleState<TPuzzle>> childPuzzles = GetPuzzleStatesToExamine(puzzle);

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

        private int StartTask(int maxDepth, PuzzleState<TPuzzle> newPuzzleState)
        {
            ulong expandedNodes = 0;
            Stack<Move<TPuzzle>> currentSolution = new Stack<Move<TPuzzle>>();

            int results = this.DepthLimitedDFS(newPuzzleState, maxDepth, currentSolution, ref expandedNodes);
            if (results == FoundResult)
            {
                currentSolution.Push(newPuzzleState.LastMove);
                this.TaskSolutions[newPuzzleState.PuzzleInstance] = currentSolution;
                this.NumberOfExpandedNodesInTasks.Add(expandedNodes);
            }

            return results;
        }

        #endregion
    }
}
