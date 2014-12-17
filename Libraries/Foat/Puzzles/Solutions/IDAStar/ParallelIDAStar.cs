namespace Foat.Puzzles.Solutions.IDAStar
{
    using Foat.Puzzles;
    using Foat.Puzzles.Configuration;
    using Foat.Puzzles.Solutions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// A parallel version of the IDAStar algorithm. Set the number of desired threads in App.Config or Web.Config.
    /// 
    /// If the number of threads is set to 1 it will revert back to the basic IDAStar algorithm.
    /// </summary>
    public sealed class ParallelIDAStar<TPuzzle> : IDAStar<TPuzzle> where TPuzzle : IPuzzle<TPuzzle>, IEquatable<TPuzzle>
    {

        #region Construction

        public ParallelIDAStar(IHeuristic<TPuzzle> heuristic, TPuzzle solutionInstance) : base(heuristic, solutionInstance)
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Splits the solution tree into at least N parts where N is the number of threads set in App.Config or Web.Config.
        /// 
        /// Each sub-tree is handed off to a new thread so that they can split up the work concurrently.
        /// 
        /// We use at least N threads instead of exactly N threads because we cannot half expand a node. If we have found 2 nodes so far
        /// and we are looking for a third, if the next node expanded has 2 children we will end up with 4 nodes instead of 3.
        /// </summary>
        /// <param name="puzzleInstance">The randomized instance of the puzzle that we want to find a solution for.</param>
        public override IEnumerable<Move<TPuzzle>> Solve(TPuzzle puzzleInstance)
        {
            if (puzzleInstance == null)
                throw new ArgumentNullException("puzzleInstance");

            int minNumTasks = ParallelIDAStarSettings.Current.MinNumberOfTasks;

            if (minNumTasks <= 1)
            {
                return base.Solve(puzzleInstance);
            }
            else
            {
                return FindSolutionParallel(puzzleInstance, minNumTasks);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// This function does the actual work of splitting the solution tree up and creating the tasks.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Move<TPuzzle>> FindSolutionParallel(TPuzzle puzzleInstance, int minNumTasks)
        {
            int maxDepth = this.Heuristic.GetMinimumEstimatedSolutionLength(puzzleInstance);

            IDAStarTask<TPuzzle>[] taskInfo = null;

            while (maxDepth != 0)
            {
                // If a solution was found while doing the BFS it is just
                // easier for now to do a single threaded IDA* search for it
                // This can likely be improved.
                if (NodeLimitedBFS(puzzleInstance, minNumTasks, out taskInfo))
                {
                    return base.Solve(puzzleInstance);
                }
                else
                {
                    Task[] tasks = new Task[taskInfo.Length];
                    for (int i = 0; i < tasks.Length; ++i)
                    {
                        tasks[i] = Task.Factory.StartNew(
                            (taskState => 
                                {
                                    IDAStarTask<TPuzzle> idaStarTask = (IDAStarTask<TPuzzle>)taskState;
                                    this.StartSearch(maxDepth, idaStarTask);
                                })
                            , taskInfo[i]);
                    }

                    Task.WaitAll(tasks);

                    maxDepth = taskInfo.Select(info => info.NextMaxDepth).Min();
                }
            }

            return GetFinalSolution(taskInfo);
        }

        /// <summary>
        /// Parses the results of all of the different tasks looking for a solution. Also sets the total number of expanded nodes
        /// across all tasks on the final iteration of the algorithm.
        /// </summary>
        private IEnumerable<Move<TPuzzle>> GetFinalSolution(IDAStarTask<TPuzzle>[] taskInfo)
        {
            IDAStarTask<TPuzzle> solutionTask = null;
            if (taskInfo != null)
            {
                solutionTask = taskInfo.Where(info => info.SolutionFound).FirstOrDefault();
            }

            if (solutionTask != null)
            {
                this.NumberOfExpandedNodes = taskInfo.Sum(info => info.NumberOfExpandedNodes);
                return solutionTask.Solution;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Does a breadth first search on the puzzle solution tree until at least minNumNodes have been found.
        /// </summary>
        /// <param name="puzzleInstance">The randomized puzzle that we want a solution for.</param>
        /// <param name="minNumNodes">The minimum number of tasks that we will be using during this search.</param>
        /// <param name="taskInfo">Returns a task info object for each of the nodes found.</param>
        /// <returns></returns>
        private bool NodeLimitedBFS(TPuzzle puzzleInstance, int minNumNodes, out IDAStarTask<TPuzzle>[] taskInfo)
        {
            Queue<IDAStarTask<TPuzzle>>  idaTasksToExpand = new Queue<IDAStarTask<TPuzzle>>();
            if (!puzzleInstance.Equals(this.SolutionState))
            {
                HashSet<TPuzzle> expandedPuzzles = new HashSet<TPuzzle>();

                idaTasksToExpand.Enqueue(new IDAStarTask<TPuzzle>(new PuzzleState<TPuzzle>(0, puzzleInstance)));

                while (idaTasksToExpand.Count < minNumNodes)
                {
                    IDAStarTask<TPuzzle> idaTask = idaTasksToExpand.Dequeue();

                    IEnumerable<PuzzleState<TPuzzle>> childPuzzles = PuzzleStateExpander<TPuzzle>.GetPuzzleStatesToExamine(idaTask.MixedPuzzleState);

                    foreach (PuzzleState<TPuzzle> childPuzzleState in childPuzzles)
                    {
                        if (!expandedPuzzles.Contains(childPuzzleState.PuzzleInstance))
                        {
                            expandedPuzzles.Add(childPuzzleState.PuzzleInstance);

                            IDAStarTask<TPuzzle> newTask = new IDAStarTask<TPuzzle>(
                                new PuzzleState<TPuzzle>(
                                    childPuzzleState.LastMove,
                                    (byte)(idaTask.MixedPuzzleState.Depth + 1), 
                                    childPuzzleState.PuzzleInstance
                            ));

                            // Shallow copy is ok here since moves are immutable and cannot be modified.
                            newTask.Solution = idaTask.Solution.ShallowCopy();
                            newTask.Solution.Push(newTask.MixedPuzzleState.LastMove);

                            idaTasksToExpand.Enqueue(newTask);

                            if (childPuzzleState.PuzzleInstance.Equals(this.SolutionState))
                            {
                                taskInfo = null;
                                return true;
                            }
                        }
                    }
                }
            }
            else
            {
                taskInfo = null;
                return true;
            }

            taskInfo = idaTasksToExpand.ToArray();
            return false;
        }

        /// <summary>
        /// Starts a depth limited search for a task.
        /// </summary>
        private void StartSearch(int maxDepth, IDAStarTask<TPuzzle> idaStarTask)
        {
            DepthLimitedAStar<TPuzzle> depthLimitedSearch = new DepthLimitedAStar<TPuzzle>(this.Heuristic, this.SolutionState);
            idaStarTask.NextMaxDepth = depthLimitedSearch.DepthLimitedDFS(idaStarTask.MixedPuzzleState, maxDepth);
            idaStarTask.NumberOfExpandedNodes = depthLimitedSearch.NumberOfExpandedNodes;

            if (depthLimitedSearch.Solution != null)
            {
                idaStarTask.SolutionFound = true;

                foreach (Move<TPuzzle> move in idaStarTask.Solution)
                {
                    depthLimitedSearch.Solution.Push(move);
                }

                idaStarTask.Solution = depthLimitedSearch.Solution;
            }
        }

        #endregion
    }
}
