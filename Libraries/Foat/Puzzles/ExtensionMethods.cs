namespace Foat.Puzzles
{
    using System.Collections.Generic;
    using System.Linq;

    internal static class ExtensionMethods
    {
        internal static Stack<T> ShallowCopy<T>(this Stack<T> stackToCopy)
        {
            return new Stack<T>(stackToCopy.Reverse().ToArray());
        }
    }
}
