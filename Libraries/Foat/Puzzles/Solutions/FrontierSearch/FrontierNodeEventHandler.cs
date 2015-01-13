namespace Foat.Puzzles.Solutions.FrontierSearch
{
    using System;

    public delegate void FrontierNodeEventHandler<TPuzzle>(object sender, FrontierNodeFoundEventArgs<TPuzzle> e) where TPuzzle : IPuzzle<TPuzzle>, IEquatable<TPuzzle>;
}
