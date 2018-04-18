using MainDSA.Quizes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSATests.Quizes
{
    [TestClass]
    public class ArrayExtensionsTests
    {
        private int[] numbers;
        [TestMethod]
        public void TestTwoSum()
        {
            // Arrange [2, 7, 11, 15]
            numbers = new int[] { 2, 7, 11, 15 };
            // Act
            var count = ArrayExtensions.TwoSum(numbers,26);
            // Assert
            Assert.AreEqual(2, count[0], "Wrong Result");
            Assert.AreEqual(3, count[1], "Wrong Result");
        }

        [TestMethod]
        public void TestFindLengthOfLCIS()
        {
            // Arrange
            numbers = new int[] { 1, 3, 5, 4, 7 };
            // Act
            var count = ArrayExtensions.FindLengthOfLCIS(numbers);
            // Assert
            Assert.AreEqual(3, count, "Wrong Count");
        }

        [TestMethod]
        public void TestMinimumSubArrayLength1()
        {
            // Arrange
            numbers = new int[] { 2, 3, 1, 2, 4, 3 };
            // Act
            var count = ArrayExtensions.MinimumSubArrayLengthNonContiguous(7, numbers);
            // Assert
            Assert.AreEqual(2, count, "Wrong Count");
        }

        [TestMethod]
        public void TestMinimumSubArrayLength21()
        {
            // Arrange
            numbers = new int[] { 2, 3, 1, 2, 4, 3 };
            // Act
            var count = ArrayExtensions.MinimumSubArrayLengthContiguous(7, numbers);
            // Assert
            Assert.AreEqual(2, count, "Wrong Count");
        }

        [TestMethod]
        public void TestMinimumSubArrayLength2()
        {
            // Arrange
            numbers = new int[] { 12, 28, 83, 4, 25, 26, 25, 2, 25, 25, 25, 12 };
            // Act
            var count = ArrayExtensions.MinimumSubArrayLengthNonContiguous(213, numbers);
            // Assert
            Assert.AreEqual(7, count, "Wrong Count");
        }

        [TestMethod]
        public void TestMinimumSubArrayLength22()
        {
            // Arrange
            numbers = new int[] { 12, 28, 83, 4, 25, 26, 25, 2, 25, 25, 25, 12 };
            // Act
            var count = ArrayExtensions.MinimumSubArrayLengthContiguous(213, numbers);
            // Assert
            Assert.AreEqual(8, count, "Wrong Count");
        }
    }
}
