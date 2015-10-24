namespace Foat.Collections.Generic.MMF
{
    using System;
    using System.IO.MemoryMappedFiles;

    internal class MMFCache : IDisposable
    {
        private readonly int BytesPerItem;
        private readonly int ItemCacheCapactity;
        private readonly long TotalCachedBytes;

        internal int StartIndex { get; private set; }
        internal int EndIndex { get; private set; }
        internal MemoryMappedFile MemoryMappedFile { get; private set; }
        private MemoryMappedViewStream MemoryMappedView;
        
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

        public void Write(byte[] item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            if (item.Length != this.BytesPerItem)
                throw new ArgumentException("Item must be {0:N0} bytes long.", "item");

            this.MemoryMappedView.Write(item, 0, this.BytesPerItem);
        }

        public byte[] Read()
        {
            byte[] bytes = new byte[this.BytesPerItem];

            this.MemoryMappedView.Read(bytes, 0, this.BytesPerItem);

            return bytes;
        }

        #region IDisposable

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
