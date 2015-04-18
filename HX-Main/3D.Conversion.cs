namespace System.Linq
{
    using System;
    using System.Collections.Generic;

    public static partial class ExtensionsTo3DArrays
    {
        /// <summary>
        /// Returns the elements of an array at specified positions as an enumerable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate">Filters elements based on their location in the array.</param>
        /// <returns></returns>
        public static IEnumerable<T> AsEnumerable<T>(this T[,,] source, Func<int, int, int, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (predicate == null)
                throw new ArgumentNullException("predicate");

            int width = source.GetLength(0),
                height = source.GetLength(1),
                depth = source.GetLength(2);

            for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            for (int z = 0; z < depth; z++)
                if (predicate(x, y, z))
                    yield return source[x, y, z];
        }
        /// <summary>
        /// Returns the array as an enumerable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<T> AsEnumerable<T>(this T[,,] source)
        {
            return source.AsEnumerable((_1, _2, _3) => true);
        }
    }
}