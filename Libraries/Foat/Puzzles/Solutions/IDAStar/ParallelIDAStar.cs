namespace Foat.Puzzles.Solutions.IDAStar
{
    using Foat.Puzzles.Solutions;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    public sealed class ParallelIDAStar<TPuzzle> : IDAStar<TPuzzle> where TPuzzle : IPuzzle<TPuzzle>
    {
        public ParallelIDAStar(IHeuristic<TPuzzle> heuristic, TPuzzle solutionInstance) : base(heuristic, solutionInstance) { }

        public override IEnumerable<int> FindSolution(TPuzzle puzzleInstance)
        {
            if (puzzleInstance == null)
                throw new ArgumentNullException("puzzleInstance");
            
            ConcurrentDictionary<IPuzzle<TPuzzle>, IEnumerable<int>> workerInfo = new ConcurrentDictionary<IPuzzle<TPuzzle>, IEnumerable<int>>();

            int[] moves = puzzleInstance.GetValidMovesBasedOnPreviousMove();

            int maxDepth = this.Heuristic.GetMinimumEstimatedSolutionLength(puzzleInstance);
            bool found = false;
            while (!found)
            {
                Trace.WriteLine(string.Format("IDA* - Bound = {0:N0}", maxDepth));

                Task[] tasks = new Task[moves.Length];
                workerInfo.Clear();

                for (int i = 0; i < moves.Length; ++i)
                {
                    tasks[i] = Task.Factory.StartNew((taskIx =>
                        {
                            int index = (int)taskIx;
                            TPuzzle newPuzzle = puzzleInstance.PerformMove((int)moves[index]);
                            PuzzleState<TPuzzle> puzzleState = new PuzzleState<TPuzzle>((int)moves[index], 1, newPuzzle);
                            Stack<int> currentSolution = new Stack<int>();

                            if (this.DepthLimitedDFS(puzzleState, maxDepth, currentSolution))
                            {
                                currentSolution.Push((int)moves[index]);
                                workerInfo[newPuzzle] = currentSolution;
                                found = true;
                            }

                        }), i);
                }

                Task.WaitAll(tasks);
                ++maxDepth;
            }

            return workerInfo.Values
                             .Where(solution => solution != null && solution.Count() > 0)
                             .FirstOrDefault(); // First or default because we might find two solutions at the same depth
        }
    }
}
