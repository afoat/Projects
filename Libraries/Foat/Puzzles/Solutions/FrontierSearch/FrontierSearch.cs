namespace Foat.Puzzles.Solutions.FrontierSearch
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    public class FrontierSearch<TPuzzle>
        where TPuzzle : IPuzzle<TPuzzle>, IEquatable<TPuzzle> 
    {
        public long NumberOfExpandedNodes { get; protected set; }

        public FrontierSearch()
        {
        }

        public void ExpandFrontier(TPuzzle puzzleInstance)
        {
            this.NumberOfExpandedNodes = 0;
            Dictionary<TPuzzle, FrontierNode<TPuzzle>> openNodeHash = new Dictionary<TPuzzle, FrontierNode<TPuzzle>>(10000000);
            Queue<FrontierNode<TPuzzle>> openNodes = new Queue<FrontierNode<TPuzzle>>();
            FrontierNode<TPuzzle> initialNode = new FrontierNode<TPuzzle>(puzzleInstance);
            openNodes.Enqueue(initialNode);
            openNodeHash.Add(puzzleInstance, initialNode);
            
            while (openNodes.Count > 0)
            {
                FrontierNode<TPuzzle> node = openNodes.Dequeue();

                foreach (FrontierNode<TPuzzle> childNode in node.ExpandChildNodes())
                {
                    FrontierNode<TPuzzle> originalNode;

                    TPuzzle childState = childNode.GetState();

                    if (!openNodeHash.TryGetValue(childState, out originalNode))
                    {
                        openNodeHash.Add(childState, childNode);
                        openNodes.Enqueue(childNode);
                    }
                    else
                    {
                        originalNode.MergeValidMoves(childNode);
                    }
                }


                TPuzzle nodeState = node.GetState();
                openNodeHash.Remove(nodeState);
                DoNodeExpanded(nodeState, node.Depth);
                ++this.NumberOfExpandedNodes;

                if (this.NumberOfExpandedNodes % 100000 == 0)
                {
                    Console.WriteLine(string.Format("Expanded {0} nodes. Last depth was {1}. Queue Contains {2}.", this.NumberOfExpandedNodes, node.Depth, openNodes.Count.ToString("N0")));
                }
            }

            Console.WriteLine(string.Format("Expanded {0} nodes.", this.NumberOfExpandedNodes));
        }


        public event FrontierNodeEventHandler<TPuzzle> NodeExpanded;
        protected void DoNodeExpanded(TPuzzle state, byte depth)
        {
            if (this.NodeExpanded != null)
            {
                this.NodeExpanded(this, new FrontierNodeFoundEventArgs<TPuzzle>() { FrontierNodeState = state, Depth = depth });
            }
        }
    }
}
