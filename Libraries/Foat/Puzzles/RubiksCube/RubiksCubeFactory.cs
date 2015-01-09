namespace Foat.Puzzles.RubiksCube
{
    public static class RubiksCubeFactory
    {
        public static RubiksCube CreateCornersOnlyCube()
        {
            return new RubiksCube(
                new byte[19]
                {
                    CornerPosition.Unmasked,
                    CornerPosition.Unmasked,
                    CornerPosition.Unmasked,
                    CornerPosition.Unmasked,
                    CornerPosition.Unmasked,
                    CornerPosition.Unmasked,
                    CornerPosition.Unmasked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                }
                );
        }

        public static RubiksCube CreateEdgeGroup1MaskCube()
        {
            return new RubiksCube(
                new byte[19]
                {
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                }
                );
        }

        public static RubiksCube CreateEdgeGroup2MaskCube()
        {
            return new RubiksCube(
                new byte[19]
                {
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                }
                );
        }

        public static RubiksCube CreateEdgeGroup3MaskCube()
        {
            return new RubiksCube(
                new byte[19]
                {
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Unmasked,
                    EdgePosition.Masked,
                    EdgePosition.Unmasked,
                    EdgePosition.Masked,
                    EdgePosition.Unmasked,
                    EdgePosition.Masked,
                    EdgePosition.Unmasked,
                    EdgePosition.Masked,
                    EdgePosition.Unmasked,
                    EdgePosition.Masked,
                    EdgePosition.Unmasked,
                }
                );
        }

        public static RubiksCube CreateEdgeGroup4MaskCube()
        {
            return new RubiksCube(
                new byte[19]
                {
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    EdgePosition.Unmasked,
                    EdgePosition.Masked,
                    EdgePosition.Unmasked,
                    EdgePosition.Masked,
                    EdgePosition.Unmasked,
                    EdgePosition.Masked,
                    EdgePosition.Unmasked,
                    EdgePosition.Masked,
                    EdgePosition.Unmasked,
                    EdgePosition.Masked,
                    EdgePosition.Unmasked,
                    EdgePosition.Masked,
                }
                );
        }

        public static RubiksCube CreateEdgeGroup5MaskCube()
        {
            return new RubiksCube(
                new byte[19]
                {
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                }
                );
        }

        public static RubiksCube CreateEdgeGroup6MaskCube()
        {
            return new RubiksCube(
                new byte[19]
                {
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                }
                );
        }

        public static RubiksCube CreateEdgeGroup7MaskCube()
        {
            return new RubiksCube(
                new byte[19]
                {
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                }
                );
        }

        public static RubiksCube CreateHybridGroup1MaskCube()
        {
            return new RubiksCube(
                new byte[19]
                {
                    CornerPosition.Unmasked,
                    CornerPosition.Unmasked,
                    CornerPosition.Unmasked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                }
                );
        }

        public static RubiksCube CreateHybridGroup2MaskCube()
        {
            return new RubiksCube(
                new byte[19]
                {
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Unmasked,
                    CornerPosition.Unmasked,
                    CornerPosition.Unmasked,
                    CornerPosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                }
                );
        }

        public static RubiksCube CreateHybridGroup3MaskCube()
        {
            return new RubiksCube(
                new byte[19]
                {
                    CornerPosition.Unmasked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Unmasked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Unmasked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                }
                );
        }

        public static RubiksCube CreateHybridGroup4MaskCube()
        {
            return new RubiksCube(
                new byte[19]
                {
                    CornerPosition.Masked,
                    CornerPosition.Unmasked,
                    CornerPosition.Masked,
                    CornerPosition.Masked,
                    CornerPosition.Unmasked,
                    CornerPosition.Unmasked,
                    CornerPosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                }
                );
        }

        public static RubiksCube Create7Corners1EdgeGroupA()
        {
            return new RubiksCube(
                new byte[19]
                {
                    CornerPosition.Unmasked,
                    CornerPosition.Unmasked,
                    CornerPosition.Unmasked,
                    CornerPosition.Unmasked,
                    CornerPosition.Unmasked,
                    CornerPosition.Unmasked,
                    CornerPosition.Masked,
                    EdgePosition.Unmasked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                    EdgePosition.Masked,
                }
                );
        }

        public static RubiksCube CreateUnmaskedCube()
        {
            return new RubiksCube(
                new byte[19]
                {
                    CornerPosition.Unmasked,
                    CornerPosition.Unmasked,
                    CornerPosition.Unmasked,
                    CornerPosition.Unmasked,
                    CornerPosition.Unmasked,
                    CornerPosition.Unmasked,
                    CornerPosition.Unmasked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                    EdgePosition.Unmasked,
                }
                );
        }
    }
}
