namespace Foat.Puzzles.Solutions
{
    using System;

    public class PuzzleSolutionEventArgs : EventArgs
    {
        public int SearchDepth { get; set; }
        public long NumberOfExpandedNodes { get; set; } 
    }
}
