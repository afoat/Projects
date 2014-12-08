namespace Foat.Hashing.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using Foat.Hashing.Configuration;

    [TestClass]
    public class MinimalPerfectHashTests
    {
        [TestMethod]
        [TestCategory(@"Foat\Hashing\MinimalPerfectHash")]
        public void CompareBucketsByLengthDescendingAEqualToB()
        {
            IHashKey[] a = new IHashKey[10];
            IHashKey[] b = new IHashKey[10];

            Assert.AreEqual<int>(0, MinimalPerfectHash<FnvHash>.CompareBucketsByLengthDesc(a, b));
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\MinimalPerfectHash")]
        public void CompareBucketsByLengthDescendingALargerThanB()
        {
            IHashKey[] a = new IHashKey[20];
            IHashKey[] b = new IHashKey[10];

            Assert.AreEqual<int>(-1, MinimalPerfectHash<FnvHash>.CompareBucketsByLengthDesc(a, b));
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\MinimalPerfectHash")]
        public void CompareBucketsByLengthDescendingASmallerThanB()
        {
            IHashKey[] a = new IHashKey[10];
            IHashKey[] b = new IHashKey[20];

            Assert.AreEqual<int>(1, MinimalPerfectHash<FnvHash>.CompareBucketsByLengthDesc(a, b));
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\MinimalPerfectHash")]
        public void CalculateNumberOfBuckets0()
        {
            Assert.AreEqual<int>(0, MinimalPerfectHash<FnvHash>.CalculateNumberOfBuckets(0, 3));
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\MinimalPerfectHash")]
        public void CalculateNumberOfBuckets1()
        {
            Assert.AreEqual<int>(0, MinimalPerfectHash<FnvHash>.CalculateNumberOfBuckets(1, 3));
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\MinimalPerfectHash")]
        public void CalculateNumberOfBuckets2()
        {
            Assert.AreEqual<int>(6, MinimalPerfectHash<FnvHash>.CalculateNumberOfBuckets(2, 3));
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\MinimalPerfectHash")]
        public void CalculateNumberOfBuckets100MemoryMultiplier2()
        {
            Assert.AreEqual<int>(30, MinimalPerfectHash<FnvHash>.CalculateNumberOfBuckets(100, 2));
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\MinimalPerfectHash")]
        public void CalculateNumberOfBuckets100MemoryMultiplier3()
        {
            Assert.AreEqual<int>(45, MinimalPerfectHash<FnvHash>.CalculateNumberOfBuckets(100, 3));
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\MinimalPerfectHash")]
        public void CalculateNumberOfBuckets100MemoryMultiplier4()
        {
            Assert.AreEqual<int>(60, MinimalPerfectHash<FnvHash>.CalculateNumberOfBuckets(100, 4));
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\MinimalPerfectHash")]
        public void ParseMinimalPerfectHashSettingsNoOverrides()
        {
            MinimalPerfectHashSettings settings = new MinimalPerfectHashSettings()
            {
                MemoryCoefficient = 3.1,
                PercentOfFrontloadedKeys = .45,
                PercentOfFrontloadedBuckets = .22
            };

            var mph = new MinimalPerfectHash<FnvHash>();
            mph.ParseMinimalPerfectHashSettings(settings);

            Assert.AreEqual<double>(settings.MemoryCoefficient, mph.MemoryCoefficient);
            Assert.AreEqual<double>(settings.PercentOfFrontloadedBuckets, mph.PercentOfFrontLoadedBuckets);
            Assert.AreEqual<double>(settings.PercentOfFrontloadedKeys, mph.PercentOfFrontLoadedKeys);
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\MinimalPerfectHash")]
        public void ParseMinimalPerfectHashSettingsOverrideHashFunction()
        {
            MinimalPerfectHashSettings settings = new MinimalPerfectHashSettings()
            {
                MemoryCoefficient = 3.1,
                PercentOfFrontloadedKeys = .45,
                PercentOfFrontloadedBuckets = .22
            };

            var mph = new MinimalPerfectHash<FnvHash>();
            mph.ParseMinimalPerfectHashSettings(settings);

            Assert.AreEqual<double>(settings.MemoryCoefficient, mph.MemoryCoefficient);
            Assert.AreEqual<double>(settings.PercentOfFrontloadedBuckets, mph.PercentOfFrontLoadedBuckets);
            Assert.AreEqual<double>(settings.PercentOfFrontloadedKeys, mph.PercentOfFrontLoadedKeys);
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\MinimalPerfectHash")]
        public void ParseMinimalPerfectHashSettingsOverrideMemoryCoefficient()
        {
            MinimalPerfectHashSettings settings = new MinimalPerfectHashSettings()
            {
                MemoryCoefficient = 3.1,
                PercentOfFrontloadedKeys = .45,
                PercentOfFrontloadedBuckets = .22
            };

            var mph = new MinimalPerfectHash<FnvHash>();
            mph.ParseMinimalPerfectHashSettings(settings, memoryCoefficient: 4.3);

            Assert.AreEqual<double>(4.3, mph.MemoryCoefficient);
            Assert.AreEqual<double>(settings.PercentOfFrontloadedBuckets, mph.PercentOfFrontLoadedBuckets);
            Assert.AreEqual<double>(settings.PercentOfFrontloadedKeys, mph.PercentOfFrontLoadedKeys);
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\MinimalPerfectHash")]
        public void ParseMinimalPerfectHashSettingsOverridePercentKeys()
        {
            MinimalPerfectHashSettings settings = new MinimalPerfectHashSettings()
            {
                MemoryCoefficient = 3.1,
                PercentOfFrontloadedKeys = .45,
                PercentOfFrontloadedBuckets = .22
            };

            var mph = new MinimalPerfectHash<FnvHash>();
            mph.ParseMinimalPerfectHashSettings(settings, percentOfFrontLoadedKeys: .35);

            Assert.AreEqual<double>(settings.MemoryCoefficient, mph.MemoryCoefficient);
            Assert.AreEqual<double>(settings.PercentOfFrontloadedBuckets, mph.PercentOfFrontLoadedBuckets);
            Assert.AreEqual<double>(.35, mph.PercentOfFrontLoadedKeys);
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\MinimalPerfectHash")]
        public void ParseMinimalPerfectHashSettingsOverridePercentBuckets()
        {
            MinimalPerfectHashSettings settings = new MinimalPerfectHashSettings()
            {
                MemoryCoefficient = 3.1,
                PercentOfFrontloadedKeys = .45,
                PercentOfFrontloadedBuckets = .22
            };

            var mph = new MinimalPerfectHash<FnvHash>();
            mph.ParseMinimalPerfectHashSettings(settings, percentOfFrontLoadedBuckets: 0.35);

            Assert.AreEqual<double>(settings.MemoryCoefficient, mph.MemoryCoefficient);
            Assert.AreEqual<double>(.35, mph.PercentOfFrontLoadedBuckets);
            Assert.AreEqual<double>(settings.PercentOfFrontloadedKeys, mph.PercentOfFrontLoadedKeys);
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\MinimalPerfectHash")]
        public void Initialize100Keys()
        {
            IntHashKey[] keys = new IntHashKey[100];

            var mph = new MinimalPerfectHash<FnvHash>(3, 0.6, 0.3);
            mph.Initialize(keys);

            Assert.AreEqual<int>(keys.Length, mph.Count);
            Assert.AreEqual<int>(60, mph.FrontLoadedKeyCutoff);
            Assert.AreEqual<int>(45, mph.Buckets.Length);
            Assert.AreEqual<int>(13, mph.NumberOfFrontLoadedBuckets);
            Assert.AreEqual<int>(32, mph.NumberOfSparseBuckets);
            Assert.AreEqual<int>(keys.Length, mph.Stats.NumberOfKeys);
            Assert.AreEqual<int>(45, mph.Stats.NumberOfBuckets);
            Assert.AreEqual<int>(13, mph.Stats.NumberOfFrontloadedBuckets);
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\MinimalPerfectHash")]
        public void GetBucketIndexForKeyFrontloadedKey()
        {

            IntHashKey[] keys = new IntHashKey[100];

            var mph = new MinimalPerfectHash<FnvHash>(3, 0.6, 0.3);
            mph.Initialize(keys);

            Assert.AreEqual<int>(2, mph.GetBucketIndexForKey(new IntHashKey(3)));
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\MinimalPerfectHash")]
        public void GetBucketIndexForKeyNotFrontloadedKey()
        {
            IntHashKey[] keys = new IntHashKey[100];

            var mph = new MinimalPerfectHash<FnvHash>(3, 0.6, 0.3);
            mph.Initialize(keys);

            Assert.AreEqual<int>(28, mph.GetBucketIndexForKey(new IntHashKey(2)));
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\MinimalPerfectHash")]
        public void ComputeHashForKeyPassed()
        {
            IntHashKey[] keys = new IntHashKey[100];

            var mph = new MinimalPerfectHash<FnvHash>(3, 0.6, 0.3);
            mph.Initialize(keys);

            Assert.AreEqual<int>(58, mph.ComputeHashForKey(new IntHashKey(2), 12));
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\MinimalPerfectHash")]
        public void MinimalPerfectHashTestHash15SparseIntegers()
        {
            IEnumerable<IHashKey> valuesToHash = new List<IHashKey>(15)
            {
                new IntHashKey(5),
                new IntHashKey(72),
                new IntHashKey(63),
                new IntHashKey(12),
                new IntHashKey(34),
                new IntHashKey(67),
                new IntHashKey(23),
                new IntHashKey(46),
                new IntHashKey(58),
                new IntHashKey(3),
                new IntHashKey(81),
                new IntHashKey(87),
                new IntHashKey(91),
                new IntHashKey(101),
                new IntHashKey(99),
            };

            MinimalPerfectHash<FnvHash> mph = new MinimalPerfectHash<FnvHash>(2.5, 0.6, 0.3);
            mph.Generate(valuesToHash);

            Assert.AreEqual<int>(15, mph.Count);
            Assert.AreEqual<int>(9, mph.Buckets.Length);
            Assert.AreEqual<int>(0, mph.Buckets[0]);
            Assert.AreEqual<int>(7, mph.Buckets[1]);
            Assert.AreEqual<int>(0, mph.Buckets[2]);
            Assert.AreEqual<int>(-2, mph.Buckets[3]);
            Assert.AreEqual<int>(0, mph.Buckets[4]);
            Assert.AreEqual<int>(0, mph.Buckets[5]);
            Assert.AreEqual<int>(7, mph.Buckets[6]);
            Assert.AreEqual<int>(-3, mph.Buckets[7]);
            Assert.AreEqual<int>(-13, mph.Buckets[8]);
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\MinimalPerfectHash")]
        public void FindUnusedIndexesEntireRangeUnused()
        {
            MinimalPerfectHash<FnvHash> mph = new MinimalPerfectHash<FnvHash>(3, 0.6, 0.3);
            mph.Initialize(new IntHashKey[10]);
            HashSet<int> hashSet = new HashSet<int>();
            Queue<int> unused = mph.FindUnusedIndexes(hashSet);

            Assert.AreEqual<int>(0, unused.Dequeue());
            Assert.AreEqual<int>(1, unused.Dequeue());
            Assert.AreEqual<int>(2, unused.Dequeue());
            Assert.AreEqual<int>(3, unused.Dequeue());
            Assert.AreEqual<int>(4, unused.Dequeue());
            Assert.AreEqual<int>(5, unused.Dequeue());
            Assert.AreEqual<int>(6, unused.Dequeue());
            Assert.AreEqual<int>(7, unused.Dequeue());
            Assert.AreEqual<int>(8, unused.Dequeue());
            Assert.AreEqual<int>(9, unused.Dequeue());
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\MinimalPerfectHash")]
        public void FindUnusedIndexesStartOfRangeUnused()
        {
            MinimalPerfectHash<FnvHash> mph = new MinimalPerfectHash<FnvHash>();
            mph.Initialize(new IntHashKey[10]);
            HashSet<int> hashSet = new HashSet<int>();
            hashSet.Add(4);
            hashSet.Add(5);
            hashSet.Add(6);
            hashSet.Add(7);
            hashSet.Add(8);
            hashSet.Add(9);
            Queue<int> unused = mph.FindUnusedIndexes(hashSet);

            Assert.AreEqual<int>(0, unused.Dequeue());
            Assert.AreEqual<int>(1, unused.Dequeue());
            Assert.AreEqual<int>(2, unused.Dequeue());
            Assert.AreEqual<int>(3, unused.Dequeue());
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\MinimalPerfectHash")]
        public void FindUnusedIndexesEndOfRangeUnused()
        {
            MinimalPerfectHash<FnvHash> mph = new MinimalPerfectHash<FnvHash>(3, 0.6, 0.3);
            mph.Initialize(new IntHashKey[10]);
            HashSet<int> hashSet = new HashSet<int>();
            hashSet.Add(0);
            hashSet.Add(1);
            hashSet.Add(2);
            hashSet.Add(3);
            hashSet.Add(4);
            hashSet.Add(5);
            Queue<int> unused = mph.FindUnusedIndexes(hashSet);

            Assert.AreEqual<int>(6, unused.Dequeue());
            Assert.AreEqual<int>(7, unused.Dequeue());
            Assert.AreEqual<int>(8, unused.Dequeue());
            Assert.AreEqual<int>(9, unused.Dequeue());
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\MinimalPerfectHash")]
        public void FindUnusedIndexesMiddleOfRangeUnused()
        {
            MinimalPerfectHash<FnvHash> mph = new MinimalPerfectHash<FnvHash>(3, 0.6, 0.3);
            mph.Initialize(new IntHashKey[10]);
            HashSet<int> hashSet = new HashSet<int>();
            hashSet.Add(0);
            hashSet.Add(1);
            hashSet.Add(2);
            hashSet.Add(3);
            hashSet.Add(7);
            hashSet.Add(8);
            hashSet.Add(9);

            Queue<int> unused = mph.FindUnusedIndexes(hashSet);

            Assert.AreEqual<int>(4, unused.Dequeue());
            Assert.AreEqual<int>(5, unused.Dequeue());
            Assert.AreEqual<int>(6, unused.Dequeue());
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\MinimalPerfectHash")]
        public void SortKeyBucketsInDescendingOrderUnsorted()
        {
            IHashKey[][] bucketArray = new IHashKey[][]
            {
                new IHashKey[0],
                new IHashKey[1],
                new IHashKey[2],
                new IHashKey[3]
            };

            MinimalPerfectHash<FnvHash>.SortKeyBucketsInDescendingOrder(bucketArray);

            Assert.AreEqual<int>(3, bucketArray[0].Length);
            Assert.AreEqual<int>(2, bucketArray[1].Length);
            Assert.AreEqual<int>(1, bucketArray[2].Length);
            Assert.AreEqual<int>(0, bucketArray[3].Length);
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\MinimalPerfectHash")]
        public void SortKeyBucketsInDescendingOrderAlreadySorted()
        {
            IHashKey[][] bucketArray = new IHashKey[][]
            {
                new IHashKey[3],
                new IHashKey[2],
                new IHashKey[1],
                new IHashKey[0]
            };

            MinimalPerfectHash<FnvHash>.SortKeyBucketsInDescendingOrder(bucketArray);

            Assert.AreEqual<int>(3, bucketArray[0].Length);
            Assert.AreEqual<int>(2, bucketArray[1].Length);
            Assert.AreEqual<int>(1, bucketArray[2].Length);
            Assert.AreEqual<int>(0, bucketArray[3].Length);
        }
        
        [TestMethod]
        [TestCategory(@"Foat\Hashing\MinimalPerfectHash")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GenerateException()
        {
            MinimalPerfectHash<FnvHash> mph = new MinimalPerfectHash<FnvHash>();
            mph.Generate(null);
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\MinimalPerfectHash")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetHashCodeNullException()
        {
            MinimalPerfectHash<FnvHash> mph = new MinimalPerfectHash<FnvHash>();
            mph.GetHashCode(null);
        }

        [TestMethod]
        [TestCategory(@"Foat\Hashing\MinimalPerfectHash")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetHashCodeInvalidOperationException()
        {
            MinimalPerfectHash<FnvHash> mph = new MinimalPerfectHash<FnvHash>();
            mph.GetHashCode(new IntHashKey(10));
        }
    }
}
