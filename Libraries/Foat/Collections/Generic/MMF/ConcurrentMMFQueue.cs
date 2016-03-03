namespace Foat.Collections.Generic.MMF
{
    using System;
    using System.IO.MemoryMappedFiles;

    /// <summary>
    /// This is a memory mapped file based queue that can store huge numbers of items since its cached on disk.
    /// This version cannot be persisted (yet).
    /// </summary>
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

        /// <summary>
        /// Creates a new instance of the ConcurrentMMFQueue class.
        /// </summary>
        /// <param name="name">The name of the queue to be used. Two processes using ConcurrentMMFQueues
        /// with the same name will share the same queue.</param>
        /// <param name="bytesPerItem">The queue can deal with bytes in chucks you can read the bytes for
        /// one item all at the same time.</param>
        /// <param name="itemCapacity">The number of items that the queue will store.</param>
        /// <param name="itemCacheCapacity">The number of items that the memory mapped view stream cach will contain.</param>
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
            this.TotalBytes = (long)itemCapacity * (long)bytesPerItem;

            this.ItemCacheCapacity = itemCacheCapacity;

            this.HeadItemIndex = 0;
            this.TailItemIndex = 0;

            this.Count = 0;

            this.MemoryMappedFile = MemoryMappedFile.CreateNew(name, this.TotalBytes, MemoryMappedFileAccess.ReadWrite);

            this.HeadCache = GetNewMMFCache(this.HeadItemIndex, MemoryMappedFileAccess.Read);
            this.TailCache = GetNewMMFCache(this.TailItemIndex, MemoryMappedFileAccess.Write);
        }

        /// <summary>
        /// Returns a new MMFCache
        /// </summary>
        /// <param name="startIndex">The index within the MMF that we will be starting this cache at.</param>
        /// <param name="fileAccess">Indicates permissions with which to open the MMF.</param>
        /// <returns>A new MMFCache</returns>
        private MMFCache GetNewMMFCache(int startIndex, MemoryMappedFileAccess fileAccess)
        {
            int cacheCapacity = GetCacheCapacity(startIndex);

            return new MMFCache(this.BytesPerItem, cacheCapacity, startIndex, this.MemoryMappedFile, fileAccess);
        }

        /// <summary>
        /// Calculates the actual capacity that the cache can be based on it's starting index within the MMF.
        /// Useful for cases where a full sized cache would run past the end of the MMF.
        /// </summary>
        /// <param name="startIndex">The index within the MMF that we will be starting this cache at.</param>
        /// <returns></returns>
        private int GetCacheCapacity(int startIndex)
        {
            int cacheCapacity;
            if (startIndex + this.ItemCacheCapacity + 1 > this.ItemCapacity)
            {
                cacheCapacity = this.ItemCapacity - startIndex;
            }
            else
            {
                cacheCapacity = this.ItemCacheCapacity;
            }
            return cacheCapacity;
        }

        /// <summary>
        /// This method attempts to enqueue the bytes that represent an item onto the queue.
        /// </summary>
        /// <param name="item">the bytes for the item that you want to queue.</param>
        /// <returns>Returns true if the item was successfully enqueued, false if the queue is full.</returns>
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
                    this.TailCache = GetNewMMFCache(nextTailItemIndex, MemoryMappedFileAccess.Write);
                }

                this.TailItemIndex = nextTailItemIndex;
            }

            return true;
        }

        /// <summary>
        /// This method attempts to dequeue the bytes of an item.
        /// </summary>
        /// <param name="item">An output parameter that will contain the bytes of the item being dequeued.</param>
        /// <returns>True if an item was successfully dequeued. False if the queue is empty.</returns>
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
                    this.HeadCache = GetNewMMFCache(nextHeadItemIndex, MemoryMappedFileAccess.Read);
                }

                this.HeadItemIndex = (this.HeadItemIndex + 1) % this.ItemCapacity;
            }

            return true;
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
