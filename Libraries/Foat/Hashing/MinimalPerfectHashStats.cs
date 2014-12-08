namespace Foat.Hashing
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public sealed class MinimalPerfectHashStats
    {
        public MinimalPerfectHashStats() {  }
        
        [DataMember]
        public int NumberOfKeys { get; internal set; }

        [DataMember]
        public int NumberOfFrontloadedKeys { get; internal set; }

        [DataMember]
        public int NumberOfBuckets { get; internal set; }

        [DataMember]
        public int NumberOfFilledBuckets { get; internal set; }

        [DataMember]
        public int NumberOfFrontloadedBuckets { get; internal set; }

        [DataMember]
        public TimeSpan GenerationTime { get; internal set; }
    }
}
