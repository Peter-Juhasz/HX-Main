namespace Science.Collections.MultiDimensional.Linq
{
    using System;

    public static partial class ExtensionsTo3DArrays
    {
        /// <summary>
        /// Projects each element of an array into a new form.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns></returns>
        public static TResult[,,] Map<T, TResult>(this T[,,] source, Func<T, TResult> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (selector == null)
                throw new ArgumentNullException("selector");

            int width = source.GetLength(0),
                height = source.GetLength(1),
                depth = source.GetLength(2);

            TResult[,,] result = new TResult[width, height, depth];

            for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            for (int z = 0; z < depth; z++)
                result[x, y, z] = selector(source[x, y, z]);

            return result;
        }
        /// <summary>
        /// Projects each element of an array into a new form.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns></returns>
        public static TResult[,,] Map<T, TResult>(this T[,,] source, Func<T[,,], int, int, int, TResult> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (selector == null)
                throw new ArgumentNullException("selector");

            int width = source.GetLength(0),
                height = source.GetLength(1),
                depth = source.GetLength(2);

            TResult[,,] result = new TResult[width, height, depth];

            for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            for (int z = 0; z < depth; z++)
                result[x, y, z] = selector(source, x, y, z);

            return result;
        }

        /// <summary>
        /// Replaces every element that matches a predicate to another one.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate">A predicate function used to match elements.</param>
        /// <param name="replacement">The element to replace matched elements.</param>
        /// <returns></returns>
        public static T[,,] Replace<T>(this T[,,] source, Func<T, bool> predicate, T replacement)
        {
            return source.Map(e => predicate(e) ? replacement : e);
        }
        /// <summary>
        /// Replaces each occurrences of an element to another one.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="subject">The element to be replaced.</param>
        /// <param name="replacement">The element to replace matched elements.</param>
        /// <returns></returns>
        public static T[,,] Replace<T>(this T[,,] source, T subject, T replacement) where T : IComparable<T>
        {
            return source.Replace(e => e.Equals(subject), replacement);
        }

        /// <summary>
        /// Replaces each element that does not match a specified predicate with the default element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate">A predicate function used to filter the elements.</param>
        /// <returns></returns>
        public static T[,,] Where<T>(this T[,,] source, Func<T, bool> predicate)
        {
            return source.Map(e => predicate(e) ? e : default(T));
        }
    }
}