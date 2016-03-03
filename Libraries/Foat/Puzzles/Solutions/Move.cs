namespace Foat.Puzzles.Solutions
{
    using System;

    /// <summary>
    /// A move represents an action that can be taken on a puzzle.
    /// </summary>
    public sealed class Move<TPuzzle> where TPuzzle : IPuzzle<TPuzzle>, IEquatable<TPuzzle>
    {
        public readonly byte Id;

        /// <summary>
        /// The name of the move in a more human readable format.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Given a puzzle, this lambda expression returns a new copy of the puzzle that has this move applied to it.
        /// </summary>
        public Func<TPuzzle, TPuzzle> MovePuzzle { get; private set; }

        public byte[] GetBytes()
        {
            return BitConverter.GetBytes(this.Id);
        }

        /// <summary>
        /// This lambda expression returns all of the valid moves based on what the current move is.
        /// </summary>
        public Func<TPuzzle, Move<TPuzzle>[]> GetValidNextMoves { get; private set; }

        public Move<TPuzzle> OppositeMove { get; set; }

        /// <summary>
        /// Constructs a new move.
        /// </summary>
        /// <param name="name">The name of the move.</param>
        /// <param name="movePuzzleFunction">Lambda expression that returns a new copy of the puzzle that has this move applied to it.</param>
        /// <param name="validMovesAfterFunction">Lambda expression that returns an array of moves that are valid to perform after this move.</param>
        internal Move(byte id, string name, Func<TPuzzle, TPuzzle> movePuzzleFunction, Func<TPuzzle, Move<TPuzzle>[]> validMovesAfterFunction)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Cannot be null or empty.", "name");
            }

            this.Id = id;
            this.Name = name;
            this.MovePuzzle = movePuzzleFunction;
            this.GetValidNextMoves = validMovesAfterFunction;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
