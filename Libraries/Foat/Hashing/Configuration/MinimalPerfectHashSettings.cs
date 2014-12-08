namespace Foat.Hashing.Configuration
{
    using System.Configuration;
    
    /// <summary>
    /// Settings used by the MinimalPerfectHash class
    /// </summary>
    public class MinimalPerfectHashSettings : ConfigurationSection
    {
        #region Fields

        private const string SectionName = @"Foat.Hashing.ConfigSection/MinimalPerfectHash";

        private const double DefaultMemoryCoefficient = 4;
        private const double DefaultPercentOfFrontLoadedKeys = 0.6;
        private const double DefaultPercentOfFrontLoadedBuckets = 0.3;

        private const string MemoryCoefficientPropertyName = "MemoryCoefficient";
        private const string PercentOfFrontloadedKeysPropertyName = "PercentOfFrontLoadedKeys";
        private const string PercentOfFrontloadedBucketsPropertyName = "PercentOfFrontLoadedBuckets";

        private static readonly MinimalPerfectHashSettings SharedDefault = new MinimalPerfectHashSettings()
            {
                MemoryCoefficient = DefaultMemoryCoefficient,
                PercentOfFrontloadedBuckets = DefaultPercentOfFrontLoadedKeys,
                PercentOfFrontloadedKeys = DefaultPercentOfFrontLoadedBuckets
            };

        private static readonly MinimalPerfectHashSettings SharedCurrent= (MinimalPerfectHashSettings)ConfigurationManager.GetSection(SectionName);

        #endregion
        
        #region Properties

        /// <summary>
        /// Controls the relative number of buckets used by the minimal perfect hassh algorithm.
        /// A setting of 2 is agressively low and the algorithm might have problems finding a minimal perfect hash
        /// A setting of 4 will waste more memory but the algorithm will run faster and have higher chances of finishing
        /// </summary>
        [ConfigurationProperty(MemoryCoefficientPropertyName, DefaultValue = DefaultMemoryCoefficient, IsRequired = false)]
        public double MemoryCoefficient
        {
            get
            {
                return (double)this[MemoryCoefficientPropertyName];
            }
            set
            {
                this[MemoryCoefficientPropertyName] = value;
            }
        }

        /// <summary>
        /// This value controls the number of keys in the entire set that will squeezed into the first few buckets.
        /// A larger value will make it more challenging to match the larger buckets at the begining but will leave
        /// smaller buckets to be dealt with later when it is even harder to find a good match.
        /// </summary>
        [ConfigurationProperty(PercentOfFrontloadedKeysPropertyName, DefaultValue = DefaultPercentOfFrontLoadedKeys, IsRequired = false)]
        public double PercentOfFrontloadedKeys
        {
            get
            {
                return (double)this[PercentOfFrontloadedKeysPropertyName];
            }
            set
            {
                this[PercentOfFrontloadedKeysPropertyName] = value;
            }
        }

        /// <summary>
        /// This value controls the number of buckets that the front loaded keys are squeezed in to. A larger value will
        /// spread the front loaded keys out into more buckets at the start of the algorithm.
        /// </summary>
        [ConfigurationProperty(PercentOfFrontloadedBucketsPropertyName, DefaultValue = DefaultPercentOfFrontLoadedBuckets, IsRequired = false)]
        public double PercentOfFrontloadedBuckets
        {
            get
            {
                return (double)this[PercentOfFrontloadedBucketsPropertyName];
            }
            set
            {
                this[PercentOfFrontloadedBucketsPropertyName] = value;
            }
        }

        #endregion

        #region Static Properties

        public static MinimalPerfectHashSettings Default
        {
            get
            {
                if (SharedDefault == null)
                {
                    return new MinimalPerfectHashSettings();
                }
                else
                {
                    return SharedDefault;
                }
            }
        }

        public static MinimalPerfectHashSettings Current
        {
            get
            {
                if (SharedCurrent == null)
                {
                    return new MinimalPerfectHashSettings();
                }
                else
                {
                    return SharedCurrent;
                }
            }
        }

        #endregion
    }
}
