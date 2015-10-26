namespace Foat.Collections.Generic
{
    using Foat.Hashing;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The DataTrieAlphabetIndexTable can generate a minimal perfect hash for a set of
    /// bytes (the alphabet) and store it so that the letters in the alphabet can be easily
    /// mapped to the indexes 0 ... Alphabet.Length and back.
    /// </summary>
    internal class DataTrieAlphabetIndexTable
    {
        /// <summary>
        /// Maps an index back to the original byte/letter that it's associated with
        /// </summary>
        private byte[] ReverseIndex;

        /// <summary>
        /// Maps a byte/letter to an index
        /// </summary>
        private Dictionary<byte, int> Index;

        /// <summary>
        /// The number of letters in the alphabet
        /// </summary>
        public int Count { get { return this.ReverseIndex.Length; } }

        /// <summary>
        /// Constructs an  instance of the DataTrieAlphabetIndexTable class
        /// </summary>
        /// <param name="alphabet">The letters in this specific alphabet. Since this is a data trie the letters are always bytes</param>
        public DataTrieAlphabetIndexTable(IEnumerable<byte> alphabet)
        {
            int alphabetSize = alphabet.Count();
            this.Index = new Dictionary<byte, int>(alphabetSize);
            this.ReverseIndex = new byte[alphabetSize];

            ReadInAlphabet(alphabet);
        }

        /// <summary>
        /// Reads in an alphabet, generates a minimal perfect hash for it and uses the MPH
        /// to initialize the index and reverse index.
        /// </summary>
        /// <param name="alphabet">The alphabet we want to index</param>
        private void ReadInAlphabet(IEnumerable<byte> alphabet)
        {
            MinimalPerfectHash<FnvHash> mph = new MinimalPerfectHash<FnvHash>();
            mph.Generate(this.ToByteArray(alphabet));
            foreach (byte b in alphabet)
            {
                int index = mph.GetHashCode(new byte[] { b });
                this.ReverseIndex[index] = b;
                this.Index[b] = index;
            }
        }
        
        /// <summary>
        /// An enumerator that converts our bytes to byte arrays since the MPH works on byte arrays
        /// instead of individual bytes.
        /// </summary>
        /// <param name="alphabet">The alphabet enumeration that you want to convert to a byte array enumeration</param>
        /// <returns></returns>
        private IEnumerable<byte[]> ToByteArray(IEnumerable<byte> alphabet)
        {
            foreach (byte b in alphabet)
            {
                yield return new byte[] { b };
            }
        }

        /// <summary>
        /// Given a letter in the alphabet returns the index in the range of 0 ... this.Count - 1.
        /// 
        /// Throws an ArgumentOutOfRangeException if the letter does not exist in the alphabet.
        /// </summary>
        /// <param name="letter">The letter to get the index for.</param>
        /// <returns>Returns the index for the given letter.</returns>
        public int GetIndex(byte letter)
        {
            if (!this.Index.Keys.Contains(letter))
                throw new ArgumentOutOfRangeException("Does not exist in alphabet.", "letter");

            return this.Index[letter];
        }

        /// <summary>
        /// Given an index returns the byte/letter that it is associated with.
        /// </summary>
        /// <param name="i">The index we want to convert to a byte/letter</param>
        /// <returns>The byte/letter of the alphabet corresponding to the passed index.</returns>
        public byte GetLetterFromIndex(int i)
        {
            if (i < 0 || i >= this.ReverseIndex.Length)
                throw new IndexOutOfRangeException();

            return this.ReverseIndex[i];
        }
    }
}
