namespace Foat.Collections.Generic.MMF
{
    using System;
    using System.IO.MemoryMappedFiles;

    public class ConcurrentMMFQueue : IDisposable
    {
        
        private object Locker = new object();
        private MemoryMappedFile MemoryMappedFile;

        private MMFCache HeadCache;
        private MMFCache TailCache;
        
        private readonly int BytesPerItem;

        private readonly int ItemCapacity;
        private readonly long TotalBytes;
        private readonly int ItemCacheCapacity;

        private int HeadItemIndex;
        private int TailItemIndex;

        public long Count { get; private set; }

        public ConcurrentMMFQueue(string name, int bytesPerItem, int itemCapacity, int itemCacheCapacity)
        {
            if (name == null)
                throw new ArgumentNullException("name");

            if (bytesPerItem <= 0)
                throw new ArgumentException("Must be positive.", "bytesPerItem");

            if (itemCapacity <= 0)
                throw new ArgumentException("Must be positive.", "itemCapacity");

            if (itemCacheCapacity <= 0)
                throw new ArgumentException("Must be positive.", "itemCacheCapacity");

            this.BytesPerItem = bytesPerItem;
            this.ItemCapacity = itemCapacity;
            this.TotalBytes = itemCapacity * bytesPerItem;

            this.ItemCacheCapacity = itemCacheCapacity;

            this.HeadItemIndex = 0;
            this.TailItemIndex = 0;

            this.Count = 0;

            this.MemoryMappedFile = MemoryMappedFile.CreateNew(name, this.TotalBytes, MemoryMappedFileAccess.ReadWrite);

            this.HeadCache = new MMFCache(this.BytesPerItem, this.ItemCacheCapacity, this.HeadItemIndex, this.MemoryMappedFile, MemoryMappedFileAccess.Read);
            this.TailCache = new MMFCache(this.BytesPerItem, this.ItemCacheCapacity, this.TailItemIndex, this.MemoryMappedFile, MemoryMappedFileAccess.Write);
        }

        public bool TryEnqueue(byte[] item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            if (item.Length != this.BytesPerItem)
                throw new ArgumentException(string.Format("Item must be {0} bytes long.", this.BytesPerItem), "item");

            lock (Locker)
            {
                if (this.Count == this.ItemCapacity)
                    return false;

                this.TailCache.Write(item);
                this.Count++;

                int nextTailItemIndex = (this.TailItemIndex + 1) % this.ItemCapacity;
                if (nextTailItemIndex == this.TailCache.EndIndex || nextTailItemIndex == 0)
                {
                    this.TailCache.Dispose();
                    this.TailCache = new MMFCache(this.BytesPerItem, this.ItemCacheCapacity, nextTailItemIndex, this.MemoryMappedFile, MemoryMappedFileAccess.Write);
                }

                this.TailItemIndex = nextTailItemIndex;
            }

            return true;
        }

        public bool TryDequeue(out byte[] item)
        {
            lock(Locker)
            {
                if (this.Count == 0)
                {
                    item = null;
                    return false;
                }
                
                item = this.HeadCache.Read();

                this.Count--;

                int nextHeadItemIndex = (this.HeadItemIndex + 1) % this.ItemCapacity;
                if (nextHeadItemIndex == this.HeadCache.EndIndex || nextHeadItemIndex == 0)
                {
                    this.HeadCache.Dispose();
                    this.HeadCache = new MMFCache(this.BytesPerItem, this.ItemCacheCapacity, nextHeadItemIndex, this.MemoryMappedFile, MemoryMappedFileAccess.Read);
                }

                this.HeadItemIndex = (this.HeadItemIndex + 1) % this.ItemCapacity;
            }

            return true;
        }

        bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                if (this.MemoryMappedFile != null)
                {
                    this.MemoryMappedFile.Dispose();
                    this.MemoryMappedFile = null;
                }

                if (this.HeadCache != null)
                {
                    this.HeadCache.Dispose();
                    this.HeadCache = null;
                }

                if (this.TailCache != null)
                {
                    this.TailCache.Dispose();
                    this.TailCache = null;
                }
            }

            disposed = true;
        }
    }
}
