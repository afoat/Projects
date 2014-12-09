namespace Foat.Puzzles.Solutions
{
    internal class PuzzleState<TPuzzle> where TPuzzle : IPuzzle<TPuzzle>
    {

        public Move<TPuzzle> LastMove { get; private set; }
        public byte Depth { get; private set; }
        public TPuzzle PuzzleInstance { get; private set; }

        public PuzzleState(byte depth, TPuzzle puzzleInstance)
        {
            this.LastMove = null;
            this.Depth = depth;
            this.PuzzleInstance = puzzleInstance;
        }

        public PuzzleState(Move<TPuzzle> move, byte depth, TPuzzle puzzleInstance)
        {
            this.LastMove = move;
            this.Depth = depth;
            this.PuzzleInstance = puzzleInstance;
        }
    }
}
