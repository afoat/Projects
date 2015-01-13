namespace Foat.Puzzles.Solutions.PatternDatabase
{
    using Foat.Puzzles.Solutions.FrontierSearch;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PatternDatabase<TPuzzle>
        where TPuzzle : IPuzzle<TPuzzle>, IEquatable<TPuzzle> 
    {
        private TPuzzle StateMask;
        private Dictionary<TPuzzle, byte> PatternDictionary;

        public PatternDatabase(TPuzzle stateMask)
        {
            if (stateMask == null)
            {
                throw new ArgumentNullException("stateMask");
            }

            this.StateMask = stateMask;
        }

        public void Generate(TPuzzle initialState)
        {
            FrontierSearch<TPuzzle> frontierSearch = new FrontierSearch<TPuzzle>();
            frontierSearch.NodeExpanded += DoNodeExpanded;

            try
            {
                this.PatternDictionary = new Dictionary<TPuzzle, byte>();

                TPuzzle maskedInitialState = initialState.ApplyMask(this.StateMask);
                frontierSearch.ExpandFrontier(maskedInitialState);

                Console.WriteLine("Done");
            }
            finally
            {
                frontierSearch.NodeExpanded -= DoNodeExpanded;
            }
        }

        void DoNodeExpanded(object sender, FrontierNodeFoundEventArgs<TPuzzle> e)
        {
            //this.PatternDictionary.Add(e.FrontierNodeState, e.Depth);
        }
    }
}
