using MainDSA.DataStructures.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSATests.DataStructures
{
    [TestClass]
    public class BinarySearchTests
    {
        /// <summary>
        /// 
        /// </summary>
        public int[] dataSet1;
        public BinarySearch binarySearch;

        [TestInitialize]
        public void BinarySearchTestsData()
        {
            dataSet1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            binarySearch = new BinarySearch(dataSet1);
        }

        [TestMethod]
        public void IsBinarySearchWorking()
        {
            // Arrange 
            BinarySearchTestsData();
            // Act
            var index = binarySearch.FindIndex(1);
            // Assert
            Assert.AreEqual(0, index, "Wrong Index For the searched number");
        }
    }
}
