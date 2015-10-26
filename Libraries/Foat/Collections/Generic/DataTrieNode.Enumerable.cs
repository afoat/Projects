namespace Foat.Collections.Generic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal sealed partial class DataTrieNode<TValue>
    {
        /// <summary>
        /// This Enumerator takes in an alphabet index so that the letter indexes can be converted back 
        /// to their original bytes.
        /// </summary>
        /// <param name="alphabetIndexTable"></param>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<byte[], TValue>> GetEnumerator(DataTrieAlphabetIndexTable alphabetIndexTable)
        {
            if (this.Data != null)
            {
                for (int i = 0; i < this.Data.Length; ++i)
                {
                    if (this.Data[i] != null)
                    {
                        byte letter = alphabetIndexTable.GetLetterFromIndex(i);
                        Stack<byte> currentWord = new Stack<byte>();
                        currentWord.Push(letter);

                        foreach (var key in GetEnumerator(currentWord, this.Data[i], alphabetIndexTable))
                        {
                            yield return key;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// This is the recursive portion of the enumerator that essentially does a pre-order traversal.
        /// </summary>
        /// <param name="currentWord">Stores the word so far</param>
        /// <param name="trieNode">The current node we are examening</param>
        /// <param name="alphabetIndexTable">The alphabet index</param>
        private IEnumerable<KeyValuePair<byte[], TValue>> GetEnumerator(Stack<byte> currentWord, DataTrieNode<TValue> trieNode, DataTrieAlphabetIndexTable alphabetIndexTable)
        {
            if (!trieNode.Value.Equals(default(TValue)))
            {
                yield return new KeyValuePair<byte[], TValue>(currentWord.Reverse().ToArray(), trieNode.Value);
            }

            if (trieNode.Data != null)
            {
                for (int i = 0; i < this.Data.Length; ++i)
                {
                    if (trieNode.Data[i] != null)
                    {
                        byte letter = alphabetIndexTable.GetLetterFromIndex(i);
                        currentWord.Push(letter);

                        foreach (KeyValuePair<byte[], TValue> keyValuePair in GetEnumerator(currentWord, trieNode.Data[i], alphabetIndexTable))
                        {
                            yield return keyValuePair;
                        }

                        currentWord.Pop();
                    }
                }
            }
        }
    }
}
