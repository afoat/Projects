namespace Foat.Puzzles.Solutions
{
    using Foat.Puzzles.RubiksCube.Solution;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Contains a puzzle and some information relevant to the current state of the puzzle.
    /// </summary>
    public class PuzzleState<TPuzzle> where TPuzzle : IPuzzle<TPuzzle>, IEquatable<TPuzzle>
    {
        /// <summary>
        /// The most recent move that was most recently applied in order to arrive at this puzzle.
        /// </summary>
        public Move<TPuzzle> LastMove { get; private set; }

        /// <summary>
        /// The number of moves that have been applied to this puzzle state since we started looking for a solution.
        /// </summary>
        public byte Depth { get; private set; }

        /// <summary>
        /// The instance of the puzzle that applies to this state information.
        /// </summary>
        public TPuzzle PuzzleInstance { get; private set; }

        private int StaticNumberOfBytesInPuzzleState
        {
            get
            {
                return 1  // Depth
                     + 1; // Last Move ID
            }
        }
                
        public PuzzleState(byte depth, TPuzzle puzzleInstance)
        {
            this.LastMove = null;
            this.Depth = depth;
            this.PuzzleInstance = puzzleInstance;
        }

        public PuzzleState(byte[] puzzleState)
        {
            if (puzzleState == null)
                throw new ArgumentNullException("puzzleState");
            
            if (puzzleState.Length < 5)
                throw new ArgumentException("bytes array isnt long enough to make a PuzzleState", "puzzleState");

            this.Depth = puzzleState[0];

            this.LastMove = GetLastMoveFromPuzzleState(puzzleState);
            
            byte[] puzzleBytes = new byte[puzzleState.Length - StaticNumberOfBytesInPuzzleState];
            Array.Copy(puzzleState, StaticNumberOfBytesInPuzzleState, puzzleBytes, 0, puzzleState.Length - StaticNumberOfBytesInPuzzleState);
            this.PuzzleInstance = PuzzleFactory<TPuzzle>.PuzzleFromBytes(puzzleBytes);
        }

        public PuzzleState(Move<TPuzzle> move, byte depth, TPuzzle puzzleInstance)
        {
            this.LastMove = move;
            this.Depth = depth;
            this.PuzzleInstance = puzzleInstance;
        }

        public int GetNumBytes()
        {
            return StaticNumberOfBytesInPuzzleState
                 + this.PuzzleInstance.GetNumBytes();
        }

        public byte[] GetBytes()
        {
            int curByte = 0;
            byte[] bytes = new byte[this.GetNumBytes()];

            bytes[curByte++] = this.Depth;
            bytes[curByte++] = GetLastMoveId();
            
            foreach (byte b in this.PuzzleInstance.GetBytes())
            {
                bytes[curByte++] = b;
            }

            return bytes;
        }

        private byte GetLastMoveId()
        {
            byte lastMoveId;
            if (this.LastMove == null)
                lastMoveId = byte.MaxValue;
            else
                lastMoveId = this.LastMove.Id;
            return lastMoveId;
        }

        private static Move<TPuzzle> GetLastMoveFromPuzzleState(byte[] puzzleState)
        {
            byte moveId = puzzleState[1];
            Move<TPuzzle> lastMove;
            if (moveId == byte.MaxValue)
                lastMove = null;
            else
                lastMove = PuzzleFactory<TPuzzle>.FindMove(moveId);
            return lastMove;
        }
    }
}
