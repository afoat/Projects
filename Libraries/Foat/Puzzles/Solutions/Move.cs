namespace Foat.Puzzles.Solutions
{
    using System;

    public sealed class Move<TPuzzle>
    {
        public string Name { get; private set; }
        public Func<TPuzzle, TPuzzle> MovePuzzle { get; private set; }
        public Func<Move<TPuzzle>[]> GetValidNextMoves { get; private set; }

        internal Move(string name, Func<TPuzzle, TPuzzle> movePuzzleFunction, Func<Move<TPuzzle>[]> validMovesAfterFunction)
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
