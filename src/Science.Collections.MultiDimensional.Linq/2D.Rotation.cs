namespace Science.Collections.MultiDimensional.Linq
{
    using System;

    /// <summary>
    /// Provides extensions methods to 2-dimensional arrays.
    /// </summary>
    public static partial class ExtensionsTo2DArrays
    {
        /// <summary>
        /// Rotates the elements of the array clockwise.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T[,] RotateClockwise<T>(this T[,] source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            int width = source.GetLength(0),
                height = source.GetLength(1);

            T[,] result = new T[height, width];

            for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                result[height - y - 1, x] = source[x, y];

            return result;
        }

        /// <summary>
        /// Rotates the elements of the array counterclockwise.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T[,] RotateCounterClockwise<T>(this T[,] source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            int width = source.GetLength(0),
                height = source.GetLength(1);

            T[,] result = new T[height, width];

            for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                result[y, width - x - 1] = source[x, y];

            return result;
        }

        /// <summary>
        /// Flips both dimensions of the array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T[,] FlipDiagonally<T>(this T[,] source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            int width = source.GetLength(0),
                height = source.GetLength(1);

            T[,] result = new T[height, width];

            for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                result[y, x] = source[x, y];

            return result;
        }

        /// <summary>
        /// Flips the elements of the array horizontally.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T[,] FlipHorizontally<T>(this T[,] source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            int width = source.GetLength(0),
                height = source.GetLength(1);

            T[,] result = new T[height, width];

            for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                result[width - x - 1, y] = source[x, y];

            return result;
        }

        /// <summary>
        /// Flips the elements of the array vertically.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T[,] FlipVertically<T>(this T[,] source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            int width = source.GetLength(0),
                height = source.GetLength(1);

            T[,] result = new T[height, width];

            for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                result[x, height - y - 1] = source[x, y];

            return result;
        }
    }
}