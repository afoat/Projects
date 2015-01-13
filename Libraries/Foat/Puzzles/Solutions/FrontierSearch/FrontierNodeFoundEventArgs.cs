namespace Foat.Puzzles.Solutions.FrontierSearch
{
    using System;

    public class FrontierNodeFoundEventArgs<TPuzzle> : EventArgs where TPuzzle : IPuzzle<TPuzzle>, IEquatable<TPuzzle>
    {
        public TPuzzle FrontierNodeState { get; set; }
        public byte Depth { get; set; }
    }
}
