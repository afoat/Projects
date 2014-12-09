namespace Foat.Puzzles.Solutions
{
    internal struct PuzzleState<TPuzzle> where TPuzzle : IPuzzle<TPuzzle>
    {

        public int? LastMove { get; private set; }
        public byte Depth { get; private set; }
        public TPuzzle PuzzleInstance { get; private set; }

        public PuzzleState(int? move, byte depth, TPuzzle puzzleInstance)
            :this()
        {
            this.LastMove = move;
            this.Depth = depth;
            this.PuzzleInstance = puzzleInstance;
        }
    }
}
