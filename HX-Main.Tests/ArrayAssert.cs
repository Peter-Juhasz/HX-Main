namespace HXMain.Testing
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    public static class ArrayAssert
    {
        /// <summary>
        /// Verifies that two specified arrays are equal. The assertion fails if they are not equal.
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        public static void AreEqual(Array expected, Array actual)
        {
            if (expected == null)
                throw new ArgumentNullException("expected");

            if (actual == null)
                Assert.Fail("Actual array is null.");

            if (expected.Rank != actual.Rank)
                Assert.Fail("The rank of the expected and actual arrays are not equal.");

            // check dimensions
            for (int i = 0; i < expected.Rank; i++)
            {
                if (actual.GetLength(i) != expected.GetLength(i))
                    Assert.Fail("The dimension lengths of the expected and actual arrays are not equal.");
            }

            // check equality of elements
            int[] cursor = new int[expected.Rank];
            cursor[expected.Rank - 1] = 0;

            while (cursor[0] < expected.GetLength(0))
            {
                // check equality
                if (!actual.GetValue(cursor).Equals(expected.GetValue(cursor)))
                    throw new AssertFailedException("Elements of the actual array are not equal to the elements of the expected array.");

                // advance cursor
                cursor[expected.Rank - 1]++;

                for (int i = expected.Rank - 1; i > 0; i--)
                {
                    if (cursor[i] >= expected.GetLength(i))
                    {
                        cursor[i - 1]++;
                        cursor[i] = 0;
                    }
                }
            }
        }
    }
}