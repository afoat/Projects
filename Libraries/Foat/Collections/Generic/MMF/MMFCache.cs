namespace Foat.Collections.Generic.MMF
{
    using System;
    using System.IO.MemoryMappedFiles;

    /// <summary>
    /// A helper class that helps keep track of a MemoryMappedViewStream ... where it starts where
    /// it ends. It provides methods to read and write from the stream.
    /// </summary>
    internal class MMFCache : IDisposable
    {
        private readonly int BytesPerItem;
        private readonly int ItemCacheCapactity;
        private readonly long TotalCachedBytes;

        /// <summary>
        /// The item based index within the MemoryMappedFile where the MMFCache starts
        /// </summary>
        internal int StartIndex { get; private set; }

        /// <summary>
        /// The item based index within the MemoryMappedFile where the MMFCache ends
        /// </summary>
        internal int EndIndex { get; private set; }

        /// <summary>
        /// The memory mapped file that is used to manage the queue
        /// </summary>
        internal MemoryMappedFile MemoryMappedFile { get; private set; }

        /// <summary>
        /// The chunk of the queue that we are currently reading from or writing to
        /// </summary>
        private MemoryMappedViewStream MemoryMappedView;

        /// <summary>
        /// Constructs an instance of the MMFCache
        /// </summary>
        /// <param name="bytesPerItem">The number of bytes each item in the cache will have</param>
        /// <param name="itemCacheCapacity">The number of items that the cache will contain</param>
        /// <param name="startIndex">The item based index within the MemoryMappedFile where the MMFCache starts</param>
        /// <param name="memoryMappedFile">The MemoryMappedFile that we are reading to and writing from</param>
        /// <param name="memoryMappedFileAccess">The access parameters that we will use to open the MemoryMappedViewStream</param>
        public MMFCache(int bytesPerItem, int itemCacheCapacity, int startIndex, MemoryMappedFile memoryMappedFile, MemoryMappedFileAccess memoryMappedFileAccess)
        {
            this.StartIndex = startIndex;
            this.EndIndex = startIndex + itemCacheCapacity;
            this.BytesPerItem = bytesPerItem;
            this.ItemCacheCapactity = itemCacheCapacity;
            this.TotalCachedBytes = bytesPerItem * itemCacheCapacity;

            this.MemoryMappedFile = memoryMappedFile;
            this.MemoryMappedView = this.MemoryMappedFile.CreateViewStream(this.StartIndex*this.BytesPerItem, this.TotalCachedBytes, memoryMappedFileAccess);
        }

        /// <summary>
        /// Writes a byte array to the current MemoryMappedView
        /// </summary>
        /// <param name="item">The bytes that will be written to the MemoryMappedView</param>
        public void Write(byte[] item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            if (item.Length != this.BytesPerItem)
                throw new ArgumentException("Item must be {0:N0} bytes long.", "item");

            this.MemoryMappedView.Write(item, 0, this.BytesPerItem);
        }

        /// <summary>
        /// Returns an array of bytes that were previously enqueued
        /// </summary>
        /// <returns>An array of bytes that were previously queued</returns>
        public byte[] Read()
        {
            byte[] bytes = new byte[this.BytesPerItem];

            this.MemoryMappedView.Read(bytes, 0, this.BytesPerItem);

            return bytes;
        }

        #region IDisposable

        bool disposed = false;
        /// <summary>
        /// Releases the ManagedMemoryViewStream maintained by thre MMFCache
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the ManagedMemoryViewStream maintained by thre MMFCache
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                if (this.MemoryMappedView != null)
                {
                    this.MemoryMappedView.Flush();
                    this.MemoryMappedView.Dispose();
                    this.MemoryMappedView = null;
                }
            }

            disposed = true;
        }

        #endregion

    }
}
