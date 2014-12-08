namespace Foat.Puzzles.RubiksCube.Solution.ShortestPath
{
    using System;
    using System.Collections.Generic;

    internal sealed class IDAStarResult
    {
        public byte Depth { get; private set; }
        public IEnumerable<Move> Solution { get; private set; }

        public bool HasSolution
        {
            get { return (this.Solution != null); }
        }

        public IDAStarResult(byte depth)
        {
            this.Depth = depth;
            this.Solution = null;
        }

        public IDAStarResult(IEnumerable<Move> solution)
        {
            if (solution == null)
                throw new ArgumentNullException();

            this.Depth = 0;
            this.Solution = solution;
        }
    }
}
