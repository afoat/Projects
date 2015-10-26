namespace TrieTestConsole
{
    using Foat;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Data : IData
    {
        public Data(byte[] bytes)
        {
            this.Bytes = bytes;
        }
        public byte[] GetBytes()
        {
            return this.Bytes;
        }

        public byte[] Bytes { get; private set; }

        public override string ToString()
        {
            bool first = true;
            StringBuilder sb = new StringBuilder();
            foreach (byte b in Bytes)
            {
                if (first)
                    sb.Append(string.Format("{0}", b));
                else
                    sb.Append(string.Format(", {0}", b));

                first = false;
            }

            return sb.ToString();
        }
    }
}
