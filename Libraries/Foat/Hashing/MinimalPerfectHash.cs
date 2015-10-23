/* ********************************************************************************************
 * I had lots of help with this implementation from these two resources.
 * 
 * http://stevehanov.ca/blog/index.php?id=119
 * http://cmph.sourceforge.net/papers/fch92.pdf
 * ********************************************************************************************/
namespace Foat.Hashing
{
    using Foat.Hashing.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.Serialization;

    /// <summary>
    /// This is a minimal perfect hash function that can map N keys onto the integers 0 .. N - 1.
    /// 
    /// A perfect hash function is one in which no collisions occur. N keys are mapped to N integers.
    /// A minimal perfect hash function maps N keys onto N consecutive integers. In this case 0 .. N - 1
    /// 
    /// This class has settings that can be overridden either in app/web.config or in the constructor of the class.
    /// 
    /// HashFunctionType:            The hash function that is used to generate the minimal perfect hash
    /// MemoryCoefficient:           Controls the number of buckets used. A smaller number makes for a more memory efficient hash
    ///                              function, but the time to generate the function will increase dramatically. I find a value of
    ///                              4 strikes a good balance.
    /// PercentOfFrontLoadedKeys:    This class has an easier time finding a minimal perfect hash when the buckets at the start have
    ///                              more keys in them. This setting determines approximately the % of keys to be placed in the front
    ///                              loaded buckets defined in the next setting.
    /// PercentOfFrontLoadedBuckets: This setting determines the number of final buckets that will be front loaded. When combined with the
    ///                              previous setting, the two will make sure that PercentOfFrontLoadedKeys is loaded into the first PercentOfFrontLoadedBuckets
    ///                              
    /// 
    /// Example:
    /// 
    /// MemoryCoefficient = 5
    /// PercentOfFrontLoadedKeys = 0.6
    /// PercentOfFrontLoadedBuckets 0.3
    /// 
    /// MemoryCoefficient 5 will force the number of buckets to be 5 * N / Log2(N)
    /// 
    /// The other settings will mean that about 60% of all keys will be fit into the first 30% of the buckets. 
    /// The remaining 40% of the keys will be spread into the final 70% of the buckets making sure that buckets
    /// at the start will have more keys than the ones at the end.
    /// 
    /// </summary>
    [DataContract]
    public sealed class MinimalPerfectHash <THashFunction> where THashFunction: IHashFunction32Bit, new()
    {
        #region Fields

        [DataMember]
        internal int[] Buckets;

        [DataMember]
        internal int FrontLoadedKeyCutoff;

        [DataMember]
        internal int NumberOfFrontLoadedBuckets;

        [DataMember]
        internal int NumberOfSparseBuckets;

        [DataMember]
        internal double MemoryCoefficient;

        [DataMember]
        internal double PercentOfFrontLoadedKeys;

        [DataMember]
        internal double PercentOfFrontLoadedBuckets;

        [IgnoreDataMember]
        private static THashFunction SharedHashFunction;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs a MinimalPerfectHash using the default settings defined in the app/web.Config and the
        /// MinimalPerfectHashSettings class
        /// </summary>
        public MinimalPerfectHash()
        {
            ParseMinimalPerfectHashSettings(MinimalPerfectHashSettings.Current);
        }

        /// <summary>
        /// Creates a MinimalPerfectHash that overrides the default settings.
        /// </summary>
        /// <param name="memoryCoefficient">Controls the number of buckets that the keys are sorted into. Smaller values will slow the algorithm down and possibly make it impossible to find a minimal perfect hash. Larger values will be faster but will waste more space.</param>
        /// <param name="percentOfFrontloadedKeys">Controls the approximate number of keys that are front loaded into the starting buckets. A larger value will make the algorithm do more work for the first buckets and less work for the buckets that come later.</param>
        /// <param name="percentOfFrontloadedBuckets">Controls the number of buckets that are front loaded with percentOfFrontloadedKeys keys. So we are able to specify what percent of keys is squished into what percent of buckets.</param>
        public MinimalPerfectHash(double memoryCoefficient, double percentOfFrontloadedKeys, double percentOfFrontloadedBuckets)
        {
            ParseMinimalPerfectHashSettings(
                MinimalPerfectHashSettings.Current,
                memoryCoefficient, 
                percentOfFrontloadedKeys, 
                percentOfFrontloadedBuckets
                );
        }

        #endregion

        #region Properties

        public int Count
        {
            get
            {
                if (this.Stats == null)
                {
                    return 0;
                }
                else
                {
                    return this.Stats.NumberOfKeys;
                }
            }
        }
        public bool IsGenerated
        {
            get { return (this.Stats != null); }
        }

        internal static THashFunction HashFunction
        {
            get
            {
                if (SharedHashFunction == null)
                {
                    SharedHashFunction = new THashFunction();
                }

                return SharedHashFunction;
            }
        }

        /// <summary>
        /// Returns some stats that are created when we generate the minimal perfect hash.
        /// 
        /// Useful for determining the quality of the hash in terms of wasted memory, bits per
        /// key etc ...
        /// </summary>
        /// <returns></returns>
        [DataMember]
        public MinimalPerfectHashStats Stats { get; internal set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Generates the minimal perfect hash for the set of keys that were passed in.
        /// </summary>
        /// <param name="keys">The keys to hash</param>
        /// <returns></returns>
        public void Generate(IEnumerable<byte[]> keys)
        {
            if (keys == null)
            {
                throw new ArgumentNullException(ExceptionMessages.keys);
            }

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            this.Initialize(keys);

            //Step 1 - Splits N Keys into Approximately C * N / Log2(N) Buckets
            //with several keys in each bucket
            byte[][][] keyBuckets = SplitItemsIntoKeyBuckets(keys);

            //Step 2 - Sorts the buckets so the most full buckets are at the beginning.
            SortKeyBucketsInDescendingOrder(keyBuckets);

            //Step 3 - Find the perfect hash for all keys in all buckets starting with the largest bucket (the first)
            this.FindPerfectHash(keyBuckets);
            
            stopwatch.Stop();

            this.Stats.GenerationTime = stopwatch.Elapsed;
        }

        /// <summary>
        /// Once the minimal perfect hash has been generated, this method can be used to get the hash
        /// code for a key that exists in the MPH.
        /// </summary>
        /// <param name="key">The key to lookup</param>
        /// <returns>Returns the index in the range of 0 ... N - 1 that represents the key where N = number of keys in minimal perfect hash.</returns>
        public int GetHashCode(byte[] key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(ExceptionMessages.key);
            }

            if (!this.IsGenerated)
            {
                throw new InvalidOperationException(ExceptionMessages.NotGenerated);
            }

            int hash = this.Buckets[this.GetBucketIndexForBytes(key)];
            if (hash < 0)
            {
                return -(hash + 1);
            }
            else
            {
                return this.ComputeHashForKey(key, hash);
            }
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Compares two byte[] arrays for the purpose of sorting them by length in descending order
        /// </summary>
        /// <param name="a">First array to be compared</param>
        /// <param name="b">Second array to be compared</param>
        /// <returns></returns>
        internal static int CompareBucketsByLengthDesc(byte[][] a, byte[][] b)
        {
            return b.Length.CompareTo(a.Length);
        }

        /// <summary>
        /// Returns the number of buckets that we will be using
        /// </summary>
        /// <param name="count">the total number of keys we are bucketing</param>
        /// <param name="memoryCoefficient">a value that controls roughly how memory efficient the algorithm is</param>
        /// <returns></returns>
        internal static int CalculateNumberOfBuckets(int count, double memoryCoefficient)
        {
            if (count <= 1)
                return 0;
            else
                return (int)(memoryCoefficient * count / Math.Log(count, 2));
        }

        /// <summary>
        /// Sorts the buckets in decending order of length
        /// </summary>
        /// <param name="keyBuckets"></param>
        internal static void SortKeyBucketsInDescendingOrder(byte[][][] keyBuckets)
        {
            Trace.WriteLine(Logging.MPHStartingSort);
            Array.Sort<byte[][]>(keyBuckets, CompareBucketsByLengthDesc);
        }

        #endregion

        #region Internal Methods

        /// <summary>
        /// Parses the MinimalPerfectHashSettings class and reads the settings into the appropriate class properties.
        /// Any values passed into this method will override what is found in the settings.
        /// </summary>
        /// <param name="hashFunction">The hash function to be used bt the MinimalPerfectHash</param>
        /// <param name="memoryCoefficient">Controls the realtive size of the hash function in memory</param>
        /// <param name="percentOfFrontLoadedKeys">Controls the % of keys that are front loaded</param>
        /// <param name="percentOfFrontLoadedBuckets">Controls the % of buckets that front loaded keys will squeeze into</param>
        internal void ParseMinimalPerfectHashSettings(MinimalPerfectHashSettings settings, double? memoryCoefficient = null, double? percentOfFrontLoadedKeys = null, double? percentOfFrontLoadedBuckets = null)
        {
            if (memoryCoefficient.HasValue)
                this.MemoryCoefficient = memoryCoefficient.Value;
            else
                this.MemoryCoefficient = settings.MemoryCoefficient;

            if (percentOfFrontLoadedKeys.HasValue)
                this.PercentOfFrontLoadedKeys = percentOfFrontLoadedKeys.Value;
            else
                this.PercentOfFrontLoadedKeys = settings.PercentOfFrontloadedKeys;

            if (percentOfFrontLoadedBuckets.HasValue)
                this.PercentOfFrontLoadedBuckets = percentOfFrontLoadedBuckets.Value;
            else
                this.PercentOfFrontLoadedBuckets = settings.PercentOfFrontloadedBuckets;
        }

        /// <summary>
        /// Inititalizes some values that are needed in order to generate the minimal perfect hash
        /// and also to lookup values once the hash is generated.
        /// </summary>
        /// <param name="keys">The keys we are going to hash</param>
        /// <param name="stats">The statistics object</param>
        internal void Initialize(IEnumerable<byte[]> keys)
        {
            this.Stats = new MinimalPerfectHashStats();
            this.Stats.NumberOfKeys = keys.Count();

            this.FrontLoadedKeyCutoff = (int)(PercentOfFrontLoadedKeys * this.Count);

            this.Buckets = new int[CalculateNumberOfBuckets(this.Count, this.MemoryCoefficient)];
            this.NumberOfFrontLoadedBuckets = (int)(this.Buckets.Length * PercentOfFrontLoadedBuckets);
            this.NumberOfSparseBuckets = this.Buckets.Length - this.NumberOfFrontLoadedBuckets;

            this.Stats.NumberOfKeys = this.Count;
            this.Stats.NumberOfBuckets = this.Buckets.Length;
            this.Stats.NumberOfFrontloadedBuckets = this.NumberOfFrontLoadedBuckets;

            Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, Logging.MPHGenStart, this.Count));
            Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, Logging.MPHFrontLoadCutoff, this.FrontLoadedKeyCutoff));
            Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, Logging.MPHNumberOfBucketsWithFrontLoad, this.Stats.NumberOfBuckets, this.Stats.NumberOfFrontloadedBuckets));
        }

        /// <summary>
        /// Finds the bucket index used by the given key
        /// </summary>
        /// <param name="key">The key to lookup in the MPH</param>
        /// <returns>The index of the bucket that contains the hash code for this key</returns>
        internal int GetBucketIndexForBytes(byte[] key)
        {
            int fullHash = HashFunction.ComputeHash(key);
            int firstProjection = Math.Abs(fullHash % this.Count);

            if (firstProjection < this.FrontLoadedKeyCutoff)
            {
                fullHash = fullHash % this.NumberOfFrontLoadedBuckets;
            }
            else
            {
                fullHash = this.NumberOfFrontLoadedBuckets + (fullHash % this.NumberOfSparseBuckets);
            }

            return Math.Abs(fullHash);
        }

        /// <summary>
        /// Given a key and a starting hash it computes a new hash for the key. This can be used to see if a given hash 
        /// value maps the key to a unique index (during generation or can be used later to lookup the index when using 
        /// the correct value for hash.
        /// </summary>
        /// <param name="key">The key we want to hash</param>
        /// <param name="hash">The starting point for the hash</param>
        /// <returns></returns>
        internal int ComputeHashForKey(byte[] key, int hash)
        {
            return (int)(((uint)HashFunction.ComputeHash(hash, key)) % this.Count);
        }

        /// <summary>
        /// Sorts the keys into a smaller number of buckets. This algorithm uses a two step process:
        /// 
        /// 1) The 32 Bit Hash of the key is projected onto a smaller bit space of this.Count keys long (with collisions)
        /// 2) The first (PercentOfFrontLoadedKeys) of these new keys are projected into the first (PercentOfFrontLoadedBuckets) of the final set of buckets
        /// 3) The remaining keys that arent front loaded are spread into the remaining buckets
        /// 
        /// This ensures that there will be buckets with more keys at the start of the list of buckets
        /// when it will be easier to match a larger set of keys. At the end when most of the indexes
        /// are taken up we will be matching smaller buckets and will have an easier time of it.
        /// </summary>
        /// <param name="keys">The set of keys that will be split up.</param>
        /// <returns>An array of arrays where the first array are the buckets and the sub-arrays are the nodes in the buckets.</returns>
        internal byte[][][] SplitItemsIntoKeyBuckets(IEnumerable<byte[]> keys)
        {
            Trace.WriteLine(Logging.MPHStartingSplit);

            List<byte[]>[] keyBuckets = new List<byte[]>[this.Buckets.Length];

            foreach (byte[] bytes in keys)
            {
                int index = this.GetBucketIndexForBytes(bytes);
                this.CreateListOfKeysInBucketIfNecessary(keyBuckets, index);
                keyBuckets[index].Add(bytes);

                this.UpdateStats(index);
            }

            return keyBuckets.ToArrayOfArrays();
        }

        /// <summary>
        /// Makes sure that the bucket pointed to by ID exists and is initialized.
        /// </summary>
        /// <param name="buckets">The array of buckets</param>
        /// <param name="index">The index of the bucket we want to initialize within buckets</param>
        internal void CreateListOfKeysInBucketIfNecessary(List<byte[]>[] buckets, int index)
        {
            if (buckets[index] == null)
            {
                ++this.Stats.NumberOfFilledBuckets;
                buckets[index] = new List<byte[]>();
            }
        }

        /// <summary>
        /// Keeps track of some statistics so we can find out how efficient any particular MPH is.
        /// </summary>
        /// <param name="index">A final mapped index</param>
        /// <param name="stats">The stats object</param>
        internal void UpdateStats(int index)
        {
            if (index < this.NumberOfFrontLoadedBuckets)
            {
                ++this.Stats.NumberOfFrontloadedKeys;
            }
        }

        /// <summary>
        /// Finds the minimal perfect hash of the sorted key bucket.
        /// </summary>
        /// <param name="sortedKeyBuckets"></param>
        internal void FindPerfectHash(byte[][][] sortedKeyBuckets)
        {
            int firstSingleBucketIndex;
            HashSet<int> indexesFound;

            HashBucketsWithMultipleKeys(sortedKeyBuckets,  out firstSingleBucketIndex, out indexesFound);
            HashBucketsWithOneKey(sortedKeyBuckets, firstSingleBucketIndex, indexesFound);
        }

        /// <summary>
        /// Loops through the key buckets and finds a hash for all of the buckets that have more than one key
        /// </summary>
        /// <param name="keyBuckets">key bickets to hash</param>
        /// <param name="bucketIndex">Output paramater pointing to the first bucket with less than 2 keys</param>
        /// <param name="finalIndexes">Hashset of indexes we have found so far</param>
        internal void HashBucketsWithMultipleKeys(byte[][][] keyBuckets, out int bucketIndex, out HashSet<int> finalIndexes)
        {
            Trace.WriteLine(Logging.MPHHashingBucketsWithMultipleKeys);

            finalIndexes = new HashSet<int>();
            HashSet<int> currentBucketIndexes = new HashSet<int>();

            bucketIndex = 0;
            for (; bucketIndex < keyBuckets.Length && keyBuckets[bucketIndex].Length > 1; ++bucketIndex)
            {
                currentBucketIndexes.Clear();

                int hash = GetHashCodeForBucket(keyBuckets, bucketIndex, currentBucketIndexes, finalIndexes);

                this.Buckets[this.GetBucketIndexForBytes(keyBuckets[bucketIndex][0])] = (int)hash;

                foreach (var index in currentBucketIndexes)
                {
                    finalIndexes.Add(index);
                }

                if (bucketIndex % 1000 == 0 || bucketIndex == this.NumberOfFrontLoadedBuckets-1 || bucketIndex == this.NumberOfFrontLoadedBuckets)
                {
                    Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, Logging.MPHHashBucketUpdate, bucketIndex, this.Buckets.Length, keyBuckets[bucketIndex].Length, hash));
                }
            }
        }

        /// <summary>
        /// Loops through various hash seeds in order to find one that matches the currentBucket with no collisions
        /// with any key hashed so far and also no collisions within the current bucket
        /// </summary>
        /// <param name="buckets">All of the buckets</param>
        /// <param name="currentBucket">The current bucket we are looking at</param>
        /// <param name="currentBucketIndexes">Hashset used to keep track of the indexes in the current bucket</param>
        /// <param name="finalIndexes">Hashset used to keep track of the indexes used by all buckets so far</param>
        /// <returns></returns>
        private int GetHashCodeForBucket(byte[][][] buckets, int currentBucket, HashSet<int> currentBucketIndexes, HashSet<int> finalIndexes)
        {
            int numHashedKeys = 0;
            int hash = 0;

            while (numHashedKeys < buckets[currentBucket].Length)
            {
                int index = ComputeHashForKey(buckets[currentBucket][numHashedKeys], hash);

                if (!currentBucketIndexes.Contains(index) && !finalIndexes.Contains(index))
                {
                    currentBucketIndexes.Add(index);
                    ++numHashedKeys;
                }
                else
                {
                    if (hash == int.MaxValue)
                    {
                        throw new OverflowException(ExceptionMessages.CannotFindMPH);
                    }

                    currentBucketIndexes.Clear();
                    numHashedKeys = 0;
                    ++hash;
                }
            }
            return hash;
        }

        /// <summary>
        /// Loops through all of the remaining buckets with only 1 key and puts those keys directly into the bucket as a negative value
        /// to indicate that they don't need hashing.
        /// </summary>
        /// <param name="keyBuckets">All of the bucketed keys</param>
        /// <param name="firstSingleBucketIndex">index of first bucket that has less than 2 keys</param>
        /// <param name="finalIndexesFound">hashset that keeps track of all indexes in use by all buckets so far</param>
        internal void HashBucketsWithOneKey(byte[][][] keyBuckets, int firstSingleBucketIndex, HashSet<int> finalIndexesFound)
        {
            Trace.WriteLine(Logging.MPHHashingSingleBuckets);

            Queue<int> freeIndexes = FindUnusedIndexes(finalIndexesFound);

            for (int i = firstSingleBucketIndex; i < keyBuckets.Length && keyBuckets[i].Length == 1; ++i)
            {
                int nextFreeSpot = freeIndexes.Dequeue();
                this.Buckets[this.GetBucketIndexForBytes(keyBuckets[i][0])] = (-nextFreeSpot) - 1;
            }
        }

        /// <summary>
        /// Returns a queue containing all of the indexes that have not had a key mapped to them yet.
        /// </summary>
        /// <param name="finalKeys"></param>
        /// <returns></returns>
        internal Queue<int> FindUnusedIndexes(HashSet<int> finalKeys)
        {
            Queue<int> freeIndexes = new Queue<int>();
            for (int i = 0; i < this.Count; ++i)
            {
                if (!finalKeys.Contains(i))
                    freeIndexes.Enqueue(i);
            }
            return freeIndexes;
        }

        #endregion
    }
}
