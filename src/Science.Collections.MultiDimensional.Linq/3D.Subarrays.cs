namespace Science.Collections.MultiDimensional.Linq
{
    using System;

    public static partial class ExtensionsTo3DArrays
    {
        /// <summary>
        /// Retrieves a subarray of this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="width">The width of the subarray to crop.</param>
        /// <param name="height">The height of the subarray to crop.</param>
        /// <param name="depth">The depth of the subarray to crop.</param>
        /// <returns></returns>
        public static T[,,] Crop<T>(this T[,,] source,
            int x, int y, int z,
            int width, int height, int depth
        )
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (x <= 0)
                throw new ArgumentOutOfRangeException("x");

            if (y <= 0)
                throw new ArgumentOutOfRangeException("y");

            if (z <= 0)
                throw new ArgumentOutOfRangeException("z");

            int sourceWidth = source.GetLength(0),
                sourceHeight = source.GetLength(1),
                sourceDepth = source.GetLength(2);

            if (x > width - 2)
                throw new ArgumentOutOfRangeException("x");

            if (y > height - 2)
                throw new ArgumentOutOfRangeException("y");

            if (z > depth - 2)
                throw new ArgumentOutOfRangeException("z");

            if (x + width > sourceWidth - 1)
                throw new ArgumentOutOfRangeException("width");

            if (y + height > sourceHeight - 1)
                throw new ArgumentOutOfRangeException("height");

            if (z + depth > sourceDepth - 1)
                throw new ArgumentOutOfRangeException("depth");

            T[,,] result = new T[width, height, depth];

            for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++)
            for (int k = 0; k < depth; k++)
                result[i, j, k] = source[x + i, y + j, z + k];

            return result;
        }

        /// <summary>
        /// Resizes an array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="newWidth">The new width of the array.</param>
        /// <param name="newHeight">The new height of the array.</param>
        /// <param name="newDepth">The new depth of the array.</param>
        /// <param name="paddingElement">The padding element used to fill up out of bounds locations.</param>
        /// <returns></returns>
        public static T[,,] Resize<T>(this T[,,] source, int newWidth, int newHeight, int newDepth, T paddingElement = default(T))
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (newWidth <= 0)
                throw new ArgumentOutOfRangeException("newWidth");

            if (newHeight <= 0)
                throw new ArgumentOutOfRangeException("newHeight");

            if (newDepth <= 0)
                throw new ArgumentOutOfRangeException("newDepth");

            int width = source.GetLength(0),
                height = source.GetLength(1),
                depth = source.GetLength(2);

            T[,,] result = new T[newWidth, newHeight, newDepth];

            for (int x = 0; x < newWidth; x++)
            for (int y = 0; y < newHeight; y++)
            for (int z = 0; z < newDepth; z++)
                result[x, y, z] = (x < width && y < height && z < depth) ? source[x, y, z] : paddingElement;

            return result;
        }
    }
}
