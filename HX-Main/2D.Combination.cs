namespace System.Linq
{
    using System;

    /// <summary>
    /// Provides extensions methods to 2-dimensional arrays.
    /// </summary>
    public static partial class ExtensionsTo2DArrays
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
        public static TResult[,] Combine<T1, T2, TResult>(this T1[,] source, T2[,] second, Func<T1, T2, TResult> resultSelector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (second == null)
                throw new ArgumentNullException("second");

            if (resultSelector == null)
                throw new ArgumentNullException("resultSelector");

            int width = source.GetLength(0),
                height = source.GetLength(1);

            if (second.GetLength(0) != width)
                throw new ArgumentOutOfRangeException("second", "The width of the second array must match the width of the source array.");

            if (second.GetLength(1) != height)
                throw new ArgumentOutOfRangeException("second", "The height of the second array must match the height of the source array.");

            TResult[,] result = new TResult[width, height];

            for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                result[x, y] = resultSelector(source[x, y], second[x, y]);

            return result;
        }

        /// <summary>
        /// Concatenates the elements of a second array horizontally.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="second">The second array to concatenate.</param>
        /// <returns></returns>
        public static T[,] ConcatHorizontally<T>(this T[,] source, T[,] second)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (second == null)
                throw new ArgumentNullException("second");

            int width = source.GetLength(0),
                height = source.GetLength(1);

            int secondHeight = second.GetLength(1);

            if (height != secondHeight)
                throw new ArgumentException("The height of the second array must match the height of the source array.");

            int secondWidth = second.GetLength(0);

            T[,] result = new T[width + secondWidth, height];

            for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                result[x, y] = source[x, y];

            for (int x = 0; x < secondWidth; x++)
            for (int y = 0; y < height; y++)
                result[secondWidth + x, y] = second[x, y];

            return result;
        }
        /// <summary>
        /// Concatenates the elements of a second array vertically.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="second">The second array to concatenate.</param>
        /// <returns></returns>
        public static T[,] ConcatVertically<T>(this T[,] source, T[,] second)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (second == null)
                throw new ArgumentNullException("second");

            int width = source.GetLength(0),
                height = source.GetLength(1);

            int secondWidth = second.GetLength(0);

            if (width != secondWidth)
                throw new ArgumentOutOfRangeException("second", "The width of the second array must match the width of the source array.");

            int secondHeight = second.GetLength(1);

            T[,] result = new T[width, height + secondHeight];

            for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                result[x, y] = source[x, y];

            for (int x = 0; x < width; x++)
            for (int y = 0; y < secondHeight; y++)
                result[x, secondHeight + y] = second[x, y];

            return result;
        }

        /// <summary>
        /// Combines two 2D arrays (n × m and m × p) into a new one by combining their elements like a matrix multiplication.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="TPartialResult"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="second">The second array to join.</param>
        /// <param name="accumulator">Combines a pair of corresponding elements into a new one. This operation corresponds to the addition in a matrix multiplication.</param>
        /// <param name="resultSelector">Aggregates the partial results computed by the <paramref name="accumulator"/> function into a single one, which is one of the elements of the result array. This operation corresponds to the multiplication in a matrix multiplication.</param>
        /// <returns></returns>
        public static TResult[,] CrossJoin<T1, T2, TPartialResult, TResult>(this T1[,] source, T2[,] second,
            Func<T1, T2, TPartialResult> accumulator,
            Func<TPartialResult[], TResult> resultSelector
        )
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (second == null)
                throw new ArgumentNullException("second");

            if (accumulator == null)
                throw new ArgumentNullException("accumulator");

            if (resultSelector == null)
                throw new ArgumentNullException("resultSelector");

            int firstWidth = source.GetLength(0), firstHeight = source.GetLength(1),
                secondWidth = second.GetLength(0), secondHeight = second.GetLength(1);

            if (firstHeight != secondWidth)
                throw new ArgumentException("The height of the first array must match the width of the second array.");

            TResult[,] result = new TResult[firstWidth, secondHeight];

            for (int x = 0; x < firstWidth; x++)
            for (int y = 0; y < secondHeight; y++)
            {
                TPartialResult[] partialResult = new TPartialResult[secondHeight];

                for (int i = 0; i < secondHeight; i++)
                    partialResult[i] = accumulator(source[x, i], second[i, y]);

                result[x, y] = resultSelector(partialResult);
            }

            return result;
        }
    }
}