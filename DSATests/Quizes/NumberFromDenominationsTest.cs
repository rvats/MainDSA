using MainDSA.Quizes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSATests.Quizes
{
    [TestClass]
    public class NumberFromDenominationsTest
    {
        private int[] changeDenominations;

        [TestMethod]
        public void TestNumberFromDenominations1()
        {
            // Arrange
            changeDenominations = new int[] { 1, 2, 3 };
            // Act
            var count = ArrayExtensions.ChangePossibilitiesBottomUp(1, changeDenominations);
            // Assert
            Assert.AreEqual(1, count, "Wrong Count");
        }

        [TestMethod]
        public void TestNumberFromDenominations2()
        {
            // Arrange
            changeDenominations = new int[] { 1, 2, 3 };
            // Act
            var count = ArrayExtensions.ChangePossibilitiesBottomUp(2, changeDenominations);
            // Assert
            Assert.AreEqual(2, count, "Wrong Count");
        }

        [TestMethod]
        public void TestNumberFromDenominations3()
        {
            // Arrange
            changeDenominations = new int[] { 1, 2, 3 };
            // Act
            var count = ArrayExtensions.ChangePossibilitiesBottomUp(3, changeDenominations);
            // Assert
            Assert.AreEqual(3, count, "Wrong Count");
        }

        [TestMethod]
        public void TestNumberFromDenominations4()
        {
            // Arrange
            changeDenominations = new int[] { 1, 2, 3 };
            // Act
            var count = ArrayExtensions.ChangePossibilitiesBottomUp(4, changeDenominations);
            // Assert
            Assert.AreEqual(4, count, "Wrong Count");
        }

        [TestMethod]
        public void TestNumberFromDenominations5()
        {
            // Arrange
            changeDenominations = new int[] { 1, 2, 3 };
            // Act
            var count = ArrayExtensions.ChangePossibilitiesBottomUp(5, changeDenominations);
            // Assert
            Assert.AreEqual(5, count, "Wrong Count");
        }

        [TestMethod]
        public void TestNumberFromDenominations6()
        {
            // Arrange
            changeDenominations = new int[] { 1, 2, 3 };
            // Act
            var count = ArrayExtensions.ChangePossibilitiesBottomUp(6, changeDenominations);
            // Assert
            Assert.AreEqual(7, count, "Wrong Count");
        }
    }
}
