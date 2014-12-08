namespace Foat.Hashing
{
    using System.Collections.Generic;
    using System.Linq;

    internal static class ArrayOfListsExtensions
    {
        /// <summary>
        /// Takes an array of lists and converts it into an array of arrays
        /// </summary>
        /// <typeparam name="T">The type of data stored in the array of lists</typeparam>
        /// <param name="arrayOfLists">The array of lists that will be converted</param>
        /// <returns>Returns a new array where each element is an array of type T</returns>
        public static T[][] ToArrayOfArrays<T>(this List<T>[] arrayOfLists)
        {
            return arrayOfLists.Select(subArray =>
                {
                    if (subArray == null)
                        return new T[0];
                    else
                        return subArray.ToArray();
                }
            ).ToArray();
        }
    }
}
