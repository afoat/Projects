namespace Foat.Puzzles.Solutions
{
    using Foat.Puzzles.Solutions;
using System;

    internal static class PuzzleFactory<TPuzzle> where TPuzzle : IPuzzle<TPuzzle>, IEquatable<TPuzzle>
    {
        internal static Func<byte[], TPuzzle> PuzzleFromBytes { get; set; }
        internal static Func<byte, Move<TPuzzle>> FindMove { get; set; }
    }
}
