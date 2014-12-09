namespace Foat.Puzzles.Solutions
{
    public interface IHeuristic<TPuzzle>
    {
        int GetMinimumEstimatedSolutionLength(TPuzzle puzzleInstance);
    }
}
