namespace RubuksCubePatternDatabaseGenerator
{
    using Foat.Collections;
    using Foat.Puzzles.RubiksCube;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<RubiksCube> patternMasks = GetPatternsMasks();
            foreach (RubiksCube patternMask in patternMasks)
            {
                PatternDatabase<RubiksCube> patternDatabase = new PatternDatabase<RubiksCube>(patternMask);
                patternDatabase.Generate(new RubiksCube());
            }
        }

        private static IEnumerable<RubiksCube> GetPatternsMasks()
        {
            RubiksCube[] cubePatterns = new RubiksCube[] {
                RubiksCubeFactory.CreateEdgeGroup1MaskCube(),
            };

            return cubePatterns;
        }
    }
}
