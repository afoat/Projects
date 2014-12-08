namespace Foat.Puzzles.RubiksCube.Solution.ShortestPath
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    public sealed class ParallelIDAStar : IDAStar
    {
        public ParallelIDAStar(SolutionLengthEstimator solutionLengthEstimator) : base(solutionLengthEstimator) {}

        public override IEnumerable<Move> FindSolution(RubiksCube rubiksCube)
        {
            if (rubiksCube == null)
                throw new ArgumentNullException("rubiksCube");
            
            // Each thread will store its results in the ConcurrentDictionary
            // The key used is the RubiksCube resulting from one turn
            // The result is a KeyValuePair where the key is the heuristic  value for the new rubiks cube and the value is the solution queue
            ConcurrentDictionary<RubiksCube, IEnumerable<Move>> workerInfo = new ConcurrentDictionary<RubiksCube, IEnumerable<Move>>();

            Move[] moves = RubiksCubeController.GetValidMovesBasedOnPreviousMove(null).ToArray();

            byte maxDepth = this.SolutionLengthEstimator.GetMinimumEstimatedSolutionLength(rubiksCube);
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
                            RubiksCube newCube = RubiksCubeController.Rotate(rubiksCube, moves[index]);
                            RotatedCube rotatedCube = new RotatedCube(moves[index], 1, newCube);
                            Stack<Move> currentSolution = new Stack<Move>(MaxSolutionDepth);

                            if (this.DepthLimitedDFS(rotatedCube, maxDepth, currentSolution))
                            {
                                currentSolution.Push(moves[index]);
                                workerInfo[newCube] = currentSolution;
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
