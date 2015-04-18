namespace System.Linq
{
    using System;

    public static partial class ExtensionsTo3DArrays
    {
        /// <summary>
        /// Maps a new array to each element and flattens the embedded arrays.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector">Projects each element into a 2D array.</param>
        /// <returns></returns>
        public static T[,,] Expand<T>(this T[,,] source, Func<T, T[,,]> selector)
        {
            return source.Map(selector).Flatten();
        }

        /// <summary>
        /// Maps a single element to each embedded array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector">A map function.</param>
        /// <returns></returns>
        public static T[,,] Collapse<T>(this T[,,][,,] source, Func<T[,,], T> selector)
        {
            return source.Map(selector);
        }


        /// <summary>
        /// Constructs a single array from the elements of the embedded arrays.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T[,,] Flatten<T>(this T[,,][,,] source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            int width = source.GetLength(0),
                height = source.GetLength(1),
                depth = source.GetLength(2);

            throw new NotImplementedException();
        }
    }
}