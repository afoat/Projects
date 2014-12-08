namespace MinimalPerfectHashConsole
{
    using Foat.Hashing;
    using System;

    public class IntHashKey : IHashKey
    {
        private byte[] Value;

        public IntHashKey(int value)
        {
            Value = new byte[]
            {
                (byte)(value >> 24),
                (byte)(value >> 16),
                (byte)(value >> 8),
                (byte)value
            };
        }

        public byte[] GetBytes()
        {
            return Value;
        }
        
        static IHashFunction32Bit HashAlgorithm = new FnvHash();

        public override int GetHashCode()
        {
            return HashAlgorithm.ComputeHash(this.GetBytes());
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else if (obj.GetType() != this.GetType())
                return false;
            else
                return this.Equals(obj as IntHashKey);
        }

        public bool Equals(IntHashKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            return (this.Value[0] == key.Value[0]
                && this.Value[1] == key.Value[1]
                && this.Value[2] == key.Value[2]
                && this.Value[3] == key.Value[3]);
        }
    }
}
