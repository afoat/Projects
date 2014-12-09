namespace Foat.Puzzles.Solutions
{
    public interface IPuzzle<TPuzzle>
    {
        Move<TPuzzle> GetMove(int moveId);
        Move<TPuzzle>[] GetValidMoves();
    }
}
