﻿namespace Science.Collections.MultiDimensional.Linq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Provides extensions methods to 2-dimensional arrays.
    /// </summary>
    public static partial class ExtensionsTo2DArrays
    {
        /// <summary>
        /// Returns the elements of an array at specified positions as an enumerable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate">Filters elements based on their location in the array.</param>
        /// <returns></returns>
        public static IEnumerable<T> AsEnumerable<T>(this T[,] source, Func<int, int, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (predicate == null)
                throw new ArgumentNullException("predicate");

            int width = source.GetLength(0),
                height = source.GetLength(1);

            for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                if (predicate(x, y))
                    yield return source[x, y];
        }
        /// <summary>
        /// Returns the array as an enumerable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<T> AsEnumerable<T>(this T[,] source)
        {
            return source.AsEnumerable((_1, _2) => true);
        }

        /// <summary>
        /// Converts a two dimensional array into a single dimensional one.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T[] To1DArray<T>(this T[,] source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            int width = source.GetLength(0),
                height = source.GetLength(1);

            T[] result = new T[width * height];

            for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                result[x * height + y] = source[x, y];

            return result;
        }

        /// <summary>
        /// Converts a single dimensional array to a two dimensional by splitting it to rows containing a given number of elements.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="rowSize">The size of a column in the result array.</param>
        /// <returns></returns>
        public static T[,] To2DArray<T>(this T[] source, int rowSize)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (rowSize <= 0)
                throw new ArgumentOutOfRangeException("rowSize");

            T[,] result = new T[source.Length / rowSize, rowSize];

            for (int i = 0; i < source.Length; i++)
                result[i % rowSize, i / rowSize] = source[i];

            return result;
        }

        /// <summary>
        /// Converts a multidimensional array to a jagged array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T[][] ToJaggedArray<T>(this T[,] source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            int width = source.GetLength(0),
                height = source.GetLength(1);

            T[][] result = new T[width][];

            for (int x = 0; x < width; x++)
            {
                result[x] = new T[height];

                for (int y = 0; y < height; y++)
                    result[x][y] = source[x, y];
            }

            return result;
        }

        /// <summary>
        /// Converts a jagged array to a multidimensional array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T[,] To2DArray<T>(this T[][] source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            T[,] result = new T[source.Length, source.Max(a => a.Length)];

            for (int x = 0; x < source.Length; x++)
            for (int y = 0; y < source[x].Length; y++)
                result[x, y] = source[x][y];

            return result;
        }

        /// <summary>
        /// Enumerates the columns of a two dimensional array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<T[]> AsColumns<T>(this T[,] source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            int width = source.GetLength(0),
                height = source.GetLength(1);

            for (int y = 0; y < height; y++)
            {
                T[] column = new T[height];

                for (int x = 0; x < width; x++)
                    column[x] = source[x, y];

                yield return column;
            }
        }

        /// <summary>
        /// Enumerates the rows of a two dimensional array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<T[]> AsRows<T>(this T[,] source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            int width = source.GetLength(0),
                height = source.GetLength(1);

            for (int x = 0; x < width; x++)
            {
                T[] row = new T[height];

                for (int y = 0; y < height; y++)
                    row[y] = source[x, y];

                yield return row;
            }
        }
    }
}

