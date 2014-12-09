namespace Foat.Puzzles.Solutions
{
    using System.Collections.Generic;

    public interface IPuzzleSolution<TPuzzle>
    {
        IEnumerable<int> FindSolution(TPuzzle puzzleInstance);
    }
}
