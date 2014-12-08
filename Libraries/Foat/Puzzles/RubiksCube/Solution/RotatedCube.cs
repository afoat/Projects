namespace Foat.Puzzles.RubiksCube.Solution
{
    using Foat.Puzzles.RubiksCube;

    internal struct RotatedCube
    {
        public RotatedCube(Move? move, byte depth, RubiksCube rubiksCube)
            :this()
        {
            this.Move = move;
            this.Depth = depth;
            this.RubiksCube = rubiksCube;
        }

        public Move? Move { get; private set;}
        public byte Depth { get; private set; }
        public RubiksCube RubiksCube { get; private set; }
    }
}
