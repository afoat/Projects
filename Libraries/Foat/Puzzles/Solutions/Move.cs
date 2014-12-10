namespace Foat.Puzzles.Solutions
{
    using System;

    public sealed class Move<TPuzzle>
    {
        /// <summary>
        /// The name of the move in a more human readable format.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// This function returns a copy of the puzzle that is passed in with the current move applied to it.
        /// </summary>
        public Func<TPuzzle, TPuzzle> MovePuzzle { get; private set; }

        /// <summary>
        /// The function returns all of the valid moves based on what the current move is.
        /// </summary>
        public Func<TPuzzle, Move<TPuzzle>[]> GetValidNextMoves { get; private set; }

        internal Move(string name, Func<TPuzzle, TPuzzle> movePuzzleFunction, Func<TPuzzle, Move<TPuzzle>[]> validMovesAfterFunction)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Cannot be null or empty.", "name");
            }

            this.Name = name;
            this.MovePuzzle = movePuzzleFunction;
            this.GetValidNextMoves = validMovesAfterFunction;
        }

        internal Move()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
