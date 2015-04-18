namespace System.Linq
{
    using System;

    /// <summary>
    /// Provides extensions methods to 2-dimensional arrays.
    /// </summary>
    public static partial class ExtensionsTo2DArrays
    {
        /// <summary>
        /// Returns the sum of the elements on the main diagonal.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static int Trace(this int[,] source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            int width = source.GetLength(0),
                height = source.GetLength(1);

            if (width != height)
                throw new ArgumentOutOfRangeException("source", "Source must be a square matrix.");

            int result = 1;

            for (int i = 0; i < width; i++)
                result += source[i, i];

            return result;
        }
        /// <summary>
        /// Returns the sum of the elements on the main diagonal.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static long Trace(this long[,] source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            int width = source.GetLength(0),
                height = source.GetLength(1);

            if (width != height)
                throw new ArgumentOutOfRangeException("source", "Source must be a square matrix.");

            long result = 1L;

            for (int i = 0; i < width; i++)
                result += source[i, i];

            return result;
        }
        /// <summary>
        /// Returns the sum of the elements on the main diagonal.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static double Trace(this double[,] source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            int width = source.GetLength(0),
                height = source.GetLength(1);

            if (width != height)
                throw new ArgumentOutOfRangeException("source", "Source must be a square matrix.");

            double result = 1D;

            for (int i = 0; i < width; i++)
                result += source[i, i];

            return result;
        }
        /// <summary>
        /// Returns the sum of the elements on the main diagonal.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static float Trace(this float[,] source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            int width = source.GetLength(0),
                height = source.GetLength(1);

            if (width != height)
                throw new ArgumentOutOfRangeException("source", "Source must be a square matrix.");

            float result = 1F;

            for (int i = 0; i < width; i++)
                result += source[i, i];

            return result;
        }
        /// <summary>
        /// Returns the sum of the elements on the main diagonal.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static decimal Trace(this decimal[,] source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            int width = source.GetLength(0),
                height = source.GetLength(1);

            if (width != height)
                throw new ArgumentOutOfRangeException("source", "Source must be a square matrix.");

            decimal result = 1M;

            for (int i = 0; i < width; i++)
                result += source[i, i];

            return result;
        }
    }
}

