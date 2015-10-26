namespace Foat.Puzzles.RubiksCube.Solution
{
    using Foat.Collections.Generic.MMF;
    using Foat.Puzzles.Solutions;
    using System;

    public class PuzzleStateQueue : IDisposable
    {
        private ConcurrentMMFQueue Queue;

        public long Count
        {
            get { return this.Queue.Count; }
        }

        public PuzzleStateQueue(int sizeOfPuzzle, int capacity, int cacheCapacity)
        {
            this.Queue = new ConcurrentMMFQueue("puzzleStateQueue", sizeOfPuzzle, capacity, cacheCapacity);
        }

        public bool TryEnqueue(PuzzleState<RubiksCube> puzzleState)
        {
            if (!this.Queue.TryEnqueue(puzzleState.GetBytes()))
                return false;
            else
                return true;
        }

        public bool TryDequeue(out PuzzleState<RubiksCube> puzzle)
        {
            puzzle = null;
            byte[] bytes;

            if (this.Queue.TryDequeue(out bytes))
            {
                puzzle = new PuzzleState<RubiksCube>(bytes);
                return true;
            }

            return false;
        }
        
        bool disposed = false;

        /// <summary>
        /// Disposes the managed memory file and any associated views.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the managed memory file and any associated views.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                if (this.Queue != null)
                {
                    this.Queue.Dispose();
                    this.Queue = null;
                }
            }

            disposed = true;
        }
    }
}
