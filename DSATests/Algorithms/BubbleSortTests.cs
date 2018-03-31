using MainDSA.Algorithms.Sort;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSATests.Algorithms
{
    [TestClass]
    public class BubbleSortTests
    {
        /// <summary>
        /// 
        /// </summary>
        public int[] dataSet1;
        public BubbleSort bubbleSort;

        [TestInitialize]
        public void BubbleSortTestsData()
        {
            dataSet1 = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            bubbleSort = new BubbleSort();
        }

        [TestMethod]
        public void IsBubbleSortWorking()
        {
            // Arrange 
            BubbleSortTestsData();

            // Act
            var numberArray = bubbleSort.Sort(dataSet1);
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
