namespace RubiksCubePatternSetGenerator
{
    using Foat.Puzzles.RubiksCube;
    using Foat.Puzzles.RubiksCube.Solution.ShortestPath;
    using RubiksCubePatternSetGenerator.Configuration;
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

            PatternCollection patternCollection = GetPatternsToGenerate();
            
            foreach (Pattern pattern in patternCollection)
            {
                Trace.WriteLine(string.Format("Generating pattern {0}.", pattern.Name));
                PatternSet patternSet = PatternSetGenerator.Generate(pattern, RubiksCubePatternSetGeneratorSettings.Current.NumberOfPatternGeneratingThreads);
                patternSet.Save(RubiksCubePatternSetGeneratorSettings.Current.PatternSetPath);
            }
        }

        private static PatternCollection GetPatternsToGenerate()
        {
            Pattern[] patterns = new Pattern[] {
                new Pattern("EdgeGroup1",   42577920, 10, RubiksCubeFactory.CreateEdgeGroup1MaskCube()),
                new Pattern("EdgeGroup2",   42577920, 10, RubiksCubeFactory.CreateEdgeGroup2MaskCube()),
                new Pattern("EdgeGroup3",   42577920, 10, RubiksCubeFactory.CreateEdgeGroup3MaskCube()),
                new Pattern("EdgeGroup4",   42577920, 10, RubiksCubeFactory.CreateEdgeGroup4MaskCube()),
                new Pattern("EdgeGroup5",   42577920, 10, RubiksCubeFactory.CreateEdgeGroup5MaskCube()),
                new Pattern("EdgeGroup6",   42577920, 10, RubiksCubeFactory.CreateEdgeGroup6MaskCube()),
                new Pattern("EdgeGroup7",   42577920, 10, RubiksCubeFactory.CreateEdgeGroup7MaskCube()),
                new Pattern("CornersOnly",  88179840, 11, RubiksCubeFactory.CreateCornersOnlyCube()),
                new Pattern("HybridGroup1", 95800320, 11, RubiksCubeFactory.CreateHybridGroup1MaskCube()),
                new Pattern("HybridGroup2", 95800320, 11, RubiksCubeFactory.CreateHybridGroup2MaskCube()),
                new Pattern("HybridGroup3", 95800320, 11, RubiksCubeFactory.CreateHybridGroup3MaskCube()),
                new Pattern("HybridGroup4", 95800320, 11, RubiksCubeFactory.CreateHybridGroup4MaskCube()),
            };

            return new PatternCollection(patterns);
        }
    }
}
