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

        public override IEnumerable<Move<TPuzzle>> FindSolution(TPuzzle puzzleInstance)
        {
            if (puzzleInstance == null)
                throw new ArgumentNullException("puzzleInstance");

            ConcurrentDictionary<IPuzzle<TPuzzle>, IEnumerable<Move<TPuzzle>>> workerInfo = new ConcurrentDictionary<IPuzzle<TPuzzle>, IEnumerable<Move<TPuzzle>>>();

            Move<TPuzzle>[] moves = puzzleInstance.GetValidMoves();

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
                            TPuzzle newPuzzle = moves[index].MovePuzzle(puzzleInstance);
                            PuzzleState<TPuzzle> puzzleState = new PuzzleState<TPuzzle>(moves[index], 1, newPuzzle);
                            Stack<Move<TPuzzle>> currentSolution = new Stack<Move<TPuzzle>>();

                            if (this.DepthLimitedDFS(puzzleState, maxDepth, currentSolution))
                            {
                                currentSolution.Push(moves[index]);
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
