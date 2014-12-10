namespace Foat.Puzzles.Solutions
{
    public interface IPuzzle<TPuzzle>
    {
        Move<TPuzzle>[] GetValidMoves();
    }
}
