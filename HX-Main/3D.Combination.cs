namespace System.Linq
{
    using System;

    public static partial class ExtensionsTo3DArrays
    {
        /// <summary>
        /// Merges two arrays by using the specified predicate function.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="second">The second array to merge.</param>
        /// <param name="resultSelector">A function that specifies how to merge the elements from the two arrays.</param>
        /// <returns></returns>
        public static TResult[,,] Combine<T1, T2, TResult>(this T1[,,] source, T2[,,] second, Func<T1, T2, TResult> resultSelector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (second == null)
                throw new ArgumentNullException("second");

            if (resultSelector == null)
                throw new ArgumentNullException("resultSelector");

            int width = source.GetLength(0),
                height = source.GetLength(1),
                depth = source.GetLength(2);

            if (second.GetLength(0) != width)
                throw new ArgumentOutOfRangeException("second", "The width of the second array must match the width of the source array.");

            if (second.GetLength(1) != height)
                throw new ArgumentOutOfRangeException("second", "The height of the second array must match the height of the source array.");

            if (second.GetLength(2) != depth)
                throw new ArgumentOutOfRangeException("second", "The depth of the second array must match the depth of the source array.");

            TResult[,,] result = new TResult[width, height, depth];

            for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            for (int z = 0; z < depth; z++)
                result[x, y, z] = resultSelector(source[x, y, z], second[x, y, z]);

            return result;
        }

        /// <summary>
        /// Concatenates the elements of a second array in the X dimension.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="second">The second array to concatenate.</param>
        /// <returns></returns>
        public static T[,,] ConcatX<T>(this T[,,] source, T[,,] second)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (second == null)
                throw new ArgumentNullException("second");

            int width = source.GetLength(0),
                height = source.GetLength(1),
                depth = source.GetLength(2);

            if (height != second.GetLength(1))
                throw new ArgumentOutOfRangeException("second", "The height of the second array must match the height of the source array.");

            if (depth != second.GetLength(2))
                throw new ArgumentOutOfRangeException("second", "The depth of the second array must match the depth of the source array.");

            int secondWidth = second.GetLength(0);

            T[,,] result = new T[width + secondWidth, height, depth];

            for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            for (int z = 0; z < depth; z++)
                result[x, y, z] = source[x, y, z];

            for (int x = 0; x < secondWidth; x++)
            for (int y = 0; y < height; y++)
            for (int z = 0; z < depth; z++)
                result[secondWidth + x, y, z] = second[x, y, z];

            return result;
        }
        /// <summary>
        /// Concatenates the elements of a second array in the Y dimension.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="second">The second array to concatenate.</param>
        /// <returns></returns>
        public static T[,,] ConcatY<T>(this T[,,] source, T[,,] second)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (second == null)
                throw new ArgumentNullException("second");

            int width = source.GetLength(0),
                height = source.GetLength(1),
                depth = source.GetLength(2);

            if (width != second.GetLength(0))
                throw new ArgumentOutOfRangeException("second", "The width of the second array must match the width of the source array.");

            if (depth != second.GetLength(2))
                throw new ArgumentOutOfRangeException("second", "The depth of the second array must match the depth of the source array.");

            int secondHeight = second.GetLength(1);

            T[,,] result = new T[width, height + secondHeight, depth];

            for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            for (int z = 0; z < depth; z++)
                result[x, y, z] = source[x, y, z];

            for (int x = 0; x < width; x++)
            for (int y = 0; y < secondHeight; y++)
            for (int z = 0; z < depth; z++)
                result[x, secondHeight + y, z] = second[x, y, z];

            return result;
        }
        /// <summary>
        /// Concatenates the elements of a second array in the Z dimension.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="second">The second array to concatenate.</param>
        /// <returns></returns>
        public static T[,,] ConcatZ<T>(this T[,,] source, T[,,] second)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (second == null)
                throw new ArgumentNullException("second");

            int width = source.GetLength(0),
                height = source.GetLength(1),
                depth = source.GetLength(2);

            if (width != second.GetLength(0))
                throw new ArgumentOutOfRangeException("second", "The width of the second array must match the width of the source array.");

            if (height != second.GetLength(1))
                throw new ArgumentOutOfRangeException("second", "The height of the second array must match the height of the source array.");

            int secondDepth = second.GetLength(2);

            T[,,] result = new T[width, height, depth + secondDepth];

            for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            for (int z = 0; z < depth; z++)
                result[x, y, z] = source[x, y, z];

            for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            for (int z = 0; z < secondDepth; z++)
                result[x, y, secondDepth + z] = second[x, y, z];

            return result;
        }
    }
}