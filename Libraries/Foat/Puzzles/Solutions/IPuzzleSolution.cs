namespace Foat.Puzzles.Solutions
{
    using System;
    using System.Collections.Generic;

    public interface IPuzzleSolution<TPuzzle>
    {
        IEnumerable<Move<TPuzzle>> FindSolution(TPuzzle puzzleInstance);
        UInt64 GetNumberOfExpandedNodes();
    }
}
