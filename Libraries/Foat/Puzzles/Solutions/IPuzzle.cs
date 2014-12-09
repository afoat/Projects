namespace Foat.Puzzles.Solutions
{
    public interface IPuzzle<TPuzzle>
    {
        TPuzzle PerformMove(int moveId);
        int[] GetValidMovesBasedOnPreviousMove(int? previousMove);
        int[] GetValidMovesBasedOnPreviousMove();
    }
}
