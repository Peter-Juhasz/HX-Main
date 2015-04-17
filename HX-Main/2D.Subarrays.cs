namespace System.Linq
{
    using System;

    /// <summary>
    /// Provides extensions methods to 2-dimensional arrays.
    /// </summary>
    public static partial class ExtensionsTo2DArrays
    {
        /// <summary>
        /// Retrieves a subarray of this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width">The width of the subarray to crop.</param>
        /// <param name="height">The height of the subarray to crop.</param>
        /// <returns></returns>
        public static T[,] Crop<T>(this T[,] source, int x, int y, int width, int height)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (x <= 0)
                throw new ArgumentOutOfRangeException("x");

            if (y <= 0)
                throw new ArgumentOutOfRangeException("y");
            
            int sourceWidth = source.GetLength(0),
                sourceHeight = source.GetLength(1);

            if (x > width - 2)
                throw new ArgumentOutOfRangeException("x");

            if (y > height - 2)
                throw new ArgumentOutOfRangeException("y");

            if (x + width > sourceWidth - 1)
                throw new ArgumentOutOfRangeException("width");

            if (y + height > sourceHeight - 1)
                throw new ArgumentOutOfRangeException("height");

            T[,] result = new T[width, height];

            for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++)
                result[i, j] = source[x + i, y + j];

            return result;
        }

        /// <summary>
        /// Resizes an array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="newWidth">The new width of the array.</param>
        /// <param name="newHeight">The new height of the array.</param>
        /// <param name="paddingElement">The padding element used to fill up out of bounds locations.</param>
        /// <returns></returns>
        public static T[,] Resize<T>(this T[,] source, int newWidth, int newHeight, T paddingElement = default(T))
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (newWidth <= 0)
                throw new ArgumentOutOfRangeException("newWidth");

            if (newHeight <= 0)
                throw new ArgumentOutOfRangeException("newHeight");

            int width = source.GetLength(0),
                height = source.GetLength(1);

            T[,] result = new T[newWidth, newHeight];

            for (int x = 0; x < newWidth; x++)
            for (int y = 0; y < newHeight; y++)
                result[x, y] = (x < width && y < height) ? source[x, y] : paddingElement;

            return result;
        }

        /// <summary>
        /// Returns the minor matrix of the array specified by a column and a row index.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="x">The column index to skip.</param>
        /// <param name="y">The row index to skip.</param>
        /// <returns></returns>
        public static T[,] MinorMatrix<T>(this T[,] source, int x, int y)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            int width = source.GetLength(0),
                height = source.GetLength(1);

            if (x < 0 || x >= width)
                throw new ArgumentOutOfRangeException("x");

            if (y < 0 || y >= height)
                throw new ArgumentOutOfRangeException("y");

            T[,] result = new T[width - 1, height - 1];

            for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++)
            {
                if (i == x || j == y)
                    continue;

                result[i - (i > x ? 1 : 0), j - (j > y ? 1 : 0)] = source[i, j];
            }

            return result;
        }
    }
}

