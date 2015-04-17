namespace HXMain.Tests
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing;

    [TestClass]
    public class TestsFor2DExtensions
    {
        #region Conversions
        [TestMethod]
        public void AsEnumerable()
        {
            int[,] candidate = new int[,] {
                { 1, 2, 3, },
                { 4, 5, 6, },
                { 7, 8, 9, },
                { 10, 11, 12, },
            };

            CollectionAssert.AreEqual(Enumerable.Range(1, 12).ToArray(), candidate.AsEnumerable().ToArray());
        }

        [TestMethod]
        public void To1DArray()
        {
            int[,] candidate = new int[,] {
                { 1, 2, 3, },
                { 4, 5, 6, },
                { 7, 8, 9, },
                { 10, 11, 12, },
            };

            CollectionAssert.AreEqual(Enumerable.Range(1, 12).ToArray(), candidate.To1DArray());
        }
        #endregion

        [TestMethod]
        public void Map()
        {
            int[,] candidate = new int[,] {
                { 1, 5, 9, },
                { 2, 6, 10, },
                { 3, 7, 11, },
                { 4, 8, 12, },
            };

            int[,] expected = new int[,] {
                { 2, 10, 18, },
                { 4, 12, 20, },
                { 6, 14, 22, },
                { 8, 16, 24, },
            };

            ArrayAssert.AreEqual(expected, candidate.Map(e => 2 * e));
        }
    }
}


