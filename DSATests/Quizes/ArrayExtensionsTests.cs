using MainDSA.Quizes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSATests.Quizes
{
    [TestClass]
    public class ArrayExtensionsTests
    {
        private int[] numbers;

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
