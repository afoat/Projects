namespace MinimalPerfectHashConsole
{
    using Foat.Hashing;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Runtime.Serialization;

    public static class Program
    {
        private const string OutputFileName = "MinimalPerfectHash.xml";

        static void Main()
        {
            int n = 100000;

            HashSet<IHashKey> keys = new HashSet<IHashKey>();
            Random rnd = new Random();

            Trace.WriteLine(string.Format(CultureInfo.InvariantCulture, ConsoleOutput.GeneratingKeys, n));
            while (keys.Count < n )
            {
                IntHashKey next = new IntHashKey(rnd.Next());
                if (!keys.Contains(next))
                {
                    keys.Add(next);
                }
            }

            MinimalPerfectHash<FnvHash> mph = new MinimalPerfectHash<FnvHash>();
            mph.Generate(keys);

            if (CheckMinimalPerfectHash(n, keys, mph))
            {
                Trace.WriteLine(string.Format(CultureInfo.InvariantCulture, ConsoleOutput.VerifiedMPH, mph.Stats.NumberOfKeys - 1));

                Trace.WriteLine(string.Format(CultureInfo.InvariantCulture, ConsoleOutput.DoneGeneratingMPH, mph.Stats.GenerationTime.TotalMilliseconds));
                Trace.WriteLine(string.Format(CultureInfo.InvariantCulture, ConsoleOutput.MPHFilledBucketStats, mph.Stats.NumberOfKeys, mph.Stats.NumberOfFilledBuckets, mph.Stats.NumberOfBuckets - mph.Stats.NumberOfFilledBuckets));
                Trace.WriteLine(string.Format(CultureInfo.InvariantCulture, ConsoleOutput.MPHFrontLoadedStats, mph.Stats.NumberOfFrontloadedKeys, mph.Stats.NumberOfFrontloadedBuckets));
            }
            else
            {
                Trace.WriteLine(ConsoleOutput.MPHInvalidHash);
            }

            SerializeMPH(mph);
        }

        private static void SerializeMPH(MinimalPerfectHash<FnvHash> mph)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(OutputFileName))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(MinimalPerfectHash<FnvHash>));
                serializer.WriteObject(file.BaseStream, mph);
            }
        }

        private static bool CheckMinimalPerfectHash(int n, HashSet<IHashKey> keys, MinimalPerfectHash<FnvHash> mph)
        {
            bool results = true;
            try
            {
                bool[] foundIndex = new bool[n];

                foreach (IHashKey key in keys)
                {
                    foundIndex[mph.GetHashCode(key)] = true;
                }

                for (int i = 0; i < foundIndex.Length; ++i)
                {
                    if (!foundIndex[i])
                    {
                        throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Missing index {0:N0}", i));
                    }
                }
            }
            catch (InvalidOperationException)
            {
                results = false;
            }

            return results;
        }
    }
}
