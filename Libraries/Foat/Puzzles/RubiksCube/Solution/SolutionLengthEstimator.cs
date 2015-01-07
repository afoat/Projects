namespace Foat.Puzzles.RubiksCube.Solution
{
    using Foat.Puzzles.RubiksCube;
    using Foat.Puzzles.Solutions;
    using Foat.Puzzles.Solutions.Heuristics;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    /// <summary>
    /// The SolutionLengthEstimator uses one or more PatternSets in order to estimate the minimum number of moves
    /// required to solve a Rubiks Cube in any given state. Using more patttern sets generally yields more accurate
    /// results.
    /// </summary>
    public sealed class SolutionLengthEstimator : IHeuristic<RubiksCube>
    {
        /// <summary>
        /// A collection of PatternSets used to estimate the minimum solution distance of a Rubiks Cube.
        /// </summary>
        private IEnumerable<PatternSet> PatternSets { get; set; }

        /// <summary>
        /// Creates a SolutionLengthEstimator
        /// </summary>
        /// <param name="patternSetFilePaths">Contains a list of pattern set file names to be read in and used by the SolutionLengthEstimator. Each element in the collection can be either relative or absolute, but they must contain both the path and the filename. </param>
        public SolutionLengthEstimator(IEnumerable<string> patternSetFilePaths)
        {
            if (patternSetFilePaths == null)
                throw new ArgumentNullException("patternSetFilePaths");

            int numberOfPatterns = patternSetFilePaths.Count();
            if (numberOfPatterns <= 0)
                throw new ArgumentException("No pattern sets found.");

            List<PatternSet> patternSets = new List<PatternSet>(numberOfPatterns);

            XmlSerializer serializer = new XmlSerializer(typeof(PatternSet));
            foreach (string fileName in patternSetFilePaths)
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    PatternSet patternSet = (PatternSet)serializer.Deserialize(reader);
                    patternSets.Add(patternSet);
                }
            }

            this.PatternSets = patternSets;
        }

        /// <summary>
        /// Returns the minimum number of moves to solve the given cube. Note that the value 
        /// returned by this method is a lower bound, the true solution may in fact be longer.
        /// </summary>
        /// <param name="rubiksCube">The rubiks cube that we would like to estimate</param>
        /// <returns></returns>
        public int GetMinimumEstimatedSolutionLength(RubiksCube rubiksCube)
        {
            if (rubiksCube == null)
                throw new ArgumentNullException("rubiksCube");
            
            return this.PatternSets
                       .Select(patternSet => patternSet.GetEstimatedSolutionLength(rubiksCube))
                       .Max();
        }

        public void RegisterSolution(RubiksCube puzzleSolution)
        {
        }
    }
}
