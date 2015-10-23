namespace Foat.Puzzles.RubiksCube
{
    public static class RubiksCubeFactory
    {
        public static RubiksCube CreateCornersOnlyCube()
        {
            return new RubiksCube(
                new byte[19]
                {
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                }
                );
        }

        public static RubiksCube CreateEdgeGroup1MaskCube()
        {
            return new RubiksCube(
                new byte[19]
                {
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                }
                );
        }

        public static RubiksCube CreateEdgeGroup2MaskCube()
        {
            return new RubiksCube(
                new byte[19]
                {
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                }
                );
        }

        public static RubiksCube CreateEdgeGroup3MaskCube()
        {
            return new RubiksCube(
                new byte[19]
                {
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Unmasked,
                    Position.Masked,
                    Position.Unmasked,
                    Position.Masked,
                    Position.Unmasked,
                    Position.Masked,
                    Position.Unmasked,
                    Position.Masked,
                    Position.Unmasked,
                    Position.Masked,
                    Position.Unmasked,
                }
                );
        }

        public static RubiksCube CreateEdgeGroup4MaskCube()
        {
            return new RubiksCube(
                new byte[19]
                {
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Unmasked,
                    Position.Masked,
                    Position.Unmasked,
                    Position.Masked,
                    Position.Unmasked,
                    Position.Masked,
                    Position.Unmasked,
                    Position.Masked,
                    Position.Unmasked,
                    Position.Masked,
                    Position.Unmasked,
                    Position.Masked,
                }
                );
        }

        public static RubiksCube CreateEdgeGroup5MaskCube()
        {
            return new RubiksCube(
                new byte[19]
                {
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Masked,
                    Position.Masked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Masked,
                    Position.Masked,
                    Position.Unmasked,
                    Position.Unmasked,
                }
                );
        }

        public static RubiksCube CreateEdgeGroup6MaskCube()
        {
            return new RubiksCube(
                new byte[19]
                {
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Masked,
                    Position.Masked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Masked,
                    Position.Masked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Masked,
                    Position.Masked,
                }
                );
        }

        public static RubiksCube CreateEdgeGroup7MaskCube()
        {
            return new RubiksCube(
                new byte[19]
                {
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Masked,
                    Position.Masked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Masked,
                    Position.Masked,
                    Position.Unmasked,
                    Position.Unmasked,
                }
                );
        }

        public static RubiksCube CreateHybridGroup1MaskCube()
        {
            return new RubiksCube(
                new byte[19]
                {
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                }
                );
        }

        public static RubiksCube CreateHybridGroup2MaskCube()
        {
            return new RubiksCube(
                new byte[19]
                {
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                }
                );
        }

        public static RubiksCube CreateHybridGroup3MaskCube()
        {
            return new RubiksCube(
                new byte[19]
                {
                    Position.Unmasked,
                    Position.Masked,
                    Position.Masked,
                    Position.Unmasked,
                    Position.Masked,
                    Position.Masked,
                    Position.Unmasked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                }
                );
        }

        public static RubiksCube CreateHybridGroup4MaskCube()
        {
            return new RubiksCube(
                new byte[19]
                {
                    Position.Masked,
                    Position.Unmasked,
                    Position.Masked,
                    Position.Masked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                }
                );
        }

        public static RubiksCube Create7Corners1EdgeGroupA()
        {
            return new RubiksCube(
                new byte[19]
                {
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Masked,
                    Position.Unmasked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                    Position.Masked,
                }
                );
        }

        public static RubiksCube CreateUnmaskedCube()
        {
            return new RubiksCube(
                new byte[19]
                {
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                    Position.Unmasked,
                }
                );
        }
    }
}
