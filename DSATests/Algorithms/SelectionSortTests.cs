using MainDSA.Algorithms.Sort;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSATests.Algorithms
{
    [TestClass]
    public class SelectionSortTests
    {
        /// <summary>
        /// 
        /// </summary>
        public int[] dataSet1;
        public SelectionSort selectionSort;

        [TestInitialize]
        public void SelectionSortTestsData()
        {
            dataSet1 = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            selectionSort = new SelectionSort();
        }

        [TestMethod]
        public void IsSelectionSortWorking()
        {
            // Arrange 
            SelectionSortTestsData();

            // Act
            var numberArray = selectionSort.Sort(dataSet1);
            int i = 1;
            // Assert
            foreach(var number in numberArray)
            {
                Assert.AreEqual(i, number, "Wrong Number at the Position");
                i++;
            }
        }
    }
}
