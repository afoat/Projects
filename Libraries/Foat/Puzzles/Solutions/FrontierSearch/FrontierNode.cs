namespace Foat.Puzzles.Solutions.FrontierSearch
{
    using Foat.Collections;
    using System;
    using System.Collections.Generic;

    public class FrontierNode<TPuzzle>
        where TPuzzle : IPuzzle<TPuzzle>, IEquatable<TPuzzle>
    {
        private static Move<TPuzzle>[] Moves;

        private BitMask ValidMoves;

        private TPuzzle State;

        public byte Depth { get; private set; }

        public IEnumerable<FrontierNode<TPuzzle>> ChildNodes
        {
            get
            {
                int numberOfMoves = Moves.Length;
                if (numberOfMoves > 0)
                {
                    byte depthPlusOne = (byte)(this.Depth + 1);

                    foreach (Move<TPuzzle> move in Moves)
                    {
                        if (this.ValidMoves.IsBitSet(move.Id))
                        {
                            FrontierNode<TPuzzle> childNode = new FrontierNode<TPuzzle>(depthPlusOne, move.MovePuzzle(this.State));
                            childNode.ValidMoves.SetBit(move.OppositeMove.Id, false);

                            yield return childNode;
                        }
                    }
                }
            }
        }

        public IEnumerable<FrontierNode<TPuzzle>> ExpandChildNodes()
        {
            List<FrontierNode<TPuzzle>> childNodes = null;

            int numberOfMoves = Moves.Length;
            if (numberOfMoves > 0)
            {
                childNodes = new List<FrontierNode<TPuzzle>>(Moves.Length);
                byte depthPlusOne = (byte)(this.Depth + 1);

                foreach (Move<TPuzzle> move in Moves)
                {
                    if (this.ValidMoves.IsBitSet(move.Id))
                    {
                        FrontierNode<TPuzzle> childNode = new FrontierNode<TPuzzle>(depthPlusOne, move.MovePuzzle(this.State));
                        childNode.ValidMoves.SetBit(move.OppositeMove.Id, false);

                        childNodes.Add(childNode);
                    }
                }
            }

            return childNodes;
        }

        public FrontierNode(TPuzzle state) 
        {
            if (state == null)
            {
                throw new ArgumentNullException("state");
            }

            if (Moves == null)
                Moves = state.GetAllMoves();

            this.Depth = 0;
            this.State = state;
            this.ValidMoves = new BitMask();
            this.ValidMoves.SetAll(true);
        }

        private FrontierNode(byte depth, TPuzzle state)
        {
            if (state == null)
            {
                throw new ArgumentNullException("state");
            }

            this.Depth = depth;
            this.State = state;

            this.ValidMoves = new BitMask();
            this.ValidMoves.SetAll(true);
        }

        public void MergeValidMoves(FrontierNode<TPuzzle> nodeToMerge)
        {
            this.ValidMoves &= nodeToMerge.ValidMoves;
        }

        public TPuzzle GetState()
        {
            return this.State;
        }

        #region Object Overrides

        public override int GetHashCode()
        {
            return this.State.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.Equals((FrontierNode<TPuzzle>)obj);
        }

        public bool Equals(FrontierNode<TPuzzle> other)
        {
            return this.State.Equals(other.State);
        }

        #endregion
    }
}
