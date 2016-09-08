namespace RubiksCubePatternSetGenerator
{
    using Foat.Puzzles.RubiksCube;
    using Foat.Puzzles.RubiksCube.Solution;
    using RubiksCubePatternSetGenerator.Configuration;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;

    public class Program
    {
        static void Main(string[] args)
        {
            if (!Directory.Exists(RubiksCubePatternSetGeneratorSettings.Current.PatternSetPath))
            {
                Trace.WriteLine(string.Format("Pattern Set Path Not Found: {0}", RubiksCubePatternSetGeneratorSettings.Current.PatternSetPath));
                return;
            }

            IEnumerable<Pattern> patternCollection = GetPatternsToGenerate();
            
            foreach (Pattern pattern in patternCollection)
            {
                Trace.WriteLine(string.Format("Generating pattern {0}.", pattern.Name));
                PatternSet patternSet = PatternSetGenerator.Generate(pattern, RubiksCubePatternSetGeneratorSettings.Current.NumberOfPatternGeneratingThreads);
                patternSet.Save(RubiksCubePatternSetGeneratorSettings.Current.PatternSetPath);
            }
        }

        private static IEnumerable<Pattern> GetPatternsToGenerate()
        {
            Pattern[] patterns = new Pattern[] {
                new Pattern("EdgeGroup1",   42577920, RubiksCubeFactory.CreateEdgeGroup1MaskCube()),
                new Pattern("EdgeGroup2",   42577920, RubiksCubeFactory.CreateEdgeGroup2MaskCube()),
                new Pattern("EdgeGroup3",   42577920, RubiksCubeFactory.CreateEdgeGroup3MaskCube()),
                new Pattern("EdgeGroup4",   42577920, RubiksCubeFactory.CreateEdgeGroup4MaskCube()),
                new Pattern("EdgeGroup5",   42577920, RubiksCubeFactory.CreateEdgeGroup5MaskCube()),
                new Pattern("EdgeGroup6",   42577920, RubiksCubeFactory.CreateEdgeGroup6MaskCube()),
                new Pattern("EdgeGroup7",   42577920, RubiksCubeFactory.CreateEdgeGroup7MaskCube()),
                new Pattern("CornersOnly",  88179840, RubiksCubeFactory.CreateCornersOnlyCube()),
                // What follows wont generate on a computer with 8GB ram
                //new Pattern("HybridGroup1", 95800320, RubiksCubeFactory.CreateHybridGroup1MaskCube()),
                //new Pattern("HybridGroup2", 95800320, RubiksCubeFactory.CreateHybridGroup2MaskCube()),
                //new Pattern("HybridGroup3", 95800320, RubiksCubeFactory.CreateHybridGroup3MaskCube()),
                //new Pattern("HybridGroup4", 95800320, RubiksCubeFactory.CreateHybridGroup4MaskCube()),
                // What follows wont generate on a computer with 32GB ram (it might now - cant currently test this myself)
                //new Pattern("7Corners1Edge-A",   352719360, RubiksCubeFactory.Create7Corners1EdgeGroupA()),
            };

            return patterns;
        }
    }
}
