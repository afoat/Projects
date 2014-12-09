namespace Foat.Puzzles.Solutions
{
    using System.Collections.Generic;

    public interface IPuzzleSolution<TPuzzle>
    {
        IEnumerable<Move<TPuzzle>> FindSolution(TPuzzle puzzleInstance);
    }
}
