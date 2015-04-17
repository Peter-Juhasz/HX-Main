namespace System.Linq
{
    using System;

    /// <summary>
    /// Provides extensions methods to 2-dimensional arrays.
    /// </summary>
    public static partial class ExtensionsTo2DArrays
    {
        /// <summary>
        /// Splits an array into subarrays by a specified group width and height.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="groupWidth">The width of the subarrays.</param>
        /// <param name="groupHeight">The height of the subarrays.</param>
        /// <returns></returns>
        public static T[,][,] Split<T>(this T[,] source, int groupWidth, int groupHeight)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (groupWidth <= 0)
                throw new ArgumentOutOfRangeException("groupWidth");

            if (groupHeight <= 0)
                throw new ArgumentOutOfRangeException("groupHeight");

            int width = source.GetLength(0),
                height = source.GetLength(1);

            if (width % groupWidth != 0)
                throw new ArgumentException("Width of the source array must be an integer multiple of group width.");

            if (height % groupHeight != 0)
                throw new ArgumentException("Height of the source array must be an integer multiple of group height.");

            T[,][,] result = new T[width / groupWidth, height / groupHeight][,];

            for (int x = 0; x < width; x += groupWidth)
            for (int y = 0; y < height; y += groupHeight)
            {
                int gx = x / groupWidth,
                    gy = y / groupHeight;

                result[gx, gy] = source.Crop(x, y, groupWidth, groupHeight);
            }

            return result;
        }
    }
}
