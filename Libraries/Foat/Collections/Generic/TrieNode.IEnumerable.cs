namespace Foat.Collections.Generic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal sealed partial class TrieNode<TKey, TValue> : IEnumerable<KeyValuePair<TKey[], TValue>>
        where TKey : IEquatable<TKey>
    {

        public IEnumerator<KeyValuePair<TKey[], TValue>> GetEnumerator()
        {
            if (this.Alphabet != null)
            {
                foreach (TKey keyPart in this.Alphabet.Keys)
                { 
                    Stack<TKey> currentWord = new Stack<TKey>();
                    currentWord.Push(keyPart);

                    foreach (var key in PreOrder(currentWord, this.Alphabet[keyPart]))
                    {
                        yield return key;
                    }
                }
            }

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerable<KeyValuePair<TKey[], TValue>> PreOrder(Stack<TKey> currentWord, TrieNode<TKey, TValue> trieNode)
        {
            if (!trieNode.Value.Equals(default(TValue)))
            {
                yield return new KeyValuePair<TKey[], TValue>(currentWord.Reverse().ToArray(), trieNode.Value);
            }

            if (trieNode.Alphabet != null)
            {
                foreach (TKey keyPart in trieNode.Alphabet.Keys)
                {
                    currentWord.Push(keyPart);

                    foreach (KeyValuePair<TKey[], TValue> keyValuePair in PreOrder(currentWord, trieNode.Alphabet[keyPart]))
                    {
                        yield return keyValuePair;
                    }

                    currentWord.Pop();
                }
            }
        }
    }
}
