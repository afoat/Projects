namespace Foat.Puzzles.RubiksCube.Solution
{

    public enum Move : byte
    {
        TopCW = 0,
        TopCCW = 1,
        TopHalf = 2,
        BottomCW = 3,
        BottomCCW = 4,
        BottomHalf = 5,
        LeftCW = 6,
        LeftCCW = 7,
        LeftHalf = 8,
        RightCW = 9,
        RightCCW = 10,
        RightHalf = 11,
        FrontCW = 12,
        FrontCCW = 13,
        FrontHalf = 14,
        BackCW = 15,
        BackCCW = 16,
        BackHalf = 17,
        MaxMove = 18
    }
}
