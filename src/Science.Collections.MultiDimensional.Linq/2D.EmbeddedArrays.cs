namespace Science.Collections.MultiDimensional.Linq
{
    using System;
    using System.Linq;

    /// <summary>
    /// Provides extensions methods to 2-dimensional arrays.
    /// </summary>
    public static partial class ExtensionsTo2DArrays
    {
        /// <summary>
        /// Maps a new array to each element and flattens the embedded arrays.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector">Projects each element into a 2D array.</param>
        /// <returns></returns>
        public static T[,] Expand<T>(this T[,] source, Func<T, T[,]> selector)
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
        public static T[,] Collapse<T>(this T[,][,] source, Func<T[,], T> selector)
        {
            return source.Map(selector);
        }

        /// <summary>
        /// Constructs a single array from the elements of the embedded arrays.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T[,] Flatten<T>(this T[,][,] source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            int width = source.GetLength(0),
                height = source.GetLength(1);

            int resultWidth = source.AsColumns().Sum(c => c.Max(e => e.GetLength(0))),
                resultHeight = source.AsRows().Sum(c => c.Max(e => e.GetLength(1)));

            T[,] result = new T[resultWidth, resultHeight];

            int offsetX = 0, offsetY = 0;
            int maxWidth = 0;

            for (int x = 0; x < width; x++)
            {
                offsetY = 0;
                maxWidth = 0;

                for (int y = 0; y < height; y++)
                {
                    int subWidth = source[x, y].GetLength(0), subHeight = source[x, y].GetLength(1);

                    for (int i = 0; i < subWidth; i++)
                    for (int j = 0; j < subHeight; j++)
                        result[offsetX + i, offsetY + j] = source[x, y][i, j];

                    offsetY += subHeight;

                    if (subWidth > maxWidth)
                        maxWidth = subWidth;
                }

                offsetX += maxWidth;
            }

            return result;
        }
    }
}