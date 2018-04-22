using MainDSA.Quizes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSATests.Quizes
{
    [TestClass]
    public class ArrayExtensionsTests
    {
        private int[] numbers;

        [TestMethod]
        public void TestSetMatrixRowColumZero()
        {
            // Arrange
            var matrix = new int[][] {
                new int[] { 1, 1, 1, 1 },
                new int[] { 2, 2, 0, 2 },
                new int[] { 3, 3, 3, 3 },
                new int[] { 4, 0, 4, 4 },
                new int[] { 5, 5, 5, 5 }
            };
            // Act
            ArrayExtensions.SetMatrixRowColumZero(matrix);
            // Assert
            var zeroRowColumnMatrix = new int[][] {
                new int[] { 1, 0, 0, 1 },
                new int[] { 0, 0, 0, 0 },
                new int[] { 3, 0, 0, 3 },
                new int[] { 0, 0, 0, 0 },
                new int[] { 5, 0, 0, 5 }
            };

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(zeroRowColumnMatrix[i][j], matrix[i][j], "Zero Row Column in Matrix not set properly.");
                }
            }

            // Arrange
            matrix = new int[][] {
                new int[] { 1, 1, 1, 1 },
                new int[] { 2, 2, 2, 2 },
                new int[] { 0, 3, 3, 0 },
                new int[] { 4, 4, 4, 4 },
                new int[] { 5, 5, 5, 5 }
            };
            // Act
            ArrayExtensions.SetMatrixRowColumZero(matrix);
            // Assert
            zeroRowColumnMatrix = new int[][] {
                new int[] { 0, 1, 1, 0 },
                new int[] { 0, 2, 2, 0 },
                new int[] { 0, 0, 0, 0 },
                new int[] { 0, 4, 4, 0 },
                new int[] { 0, 5, 5, 0 }
            };

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(zeroRowColumnMatrix[i][j], matrix[i][j], "Zero Row Column in Matrix not set properly.");
                }
            }
        }

        [TestMethod]
        public void TestRotateMatrix()
        {
            // Arrange
            var matrix = new int[][] {
                new int[] { 1, 1, 1, 1 },
                new int[] { 2, 2, 2, 2 },
                new int[] { 3, 3, 3, 3 },
                new int[] { 4, 4, 4, 4 }
            };
            // Act
            var result = ArrayExtensions.RotateMatrix(matrix);
            // Assert
            var rotatedMatrix = new int[][] {
                new int[] { 4, 3, 2, 1 },
                new int[] { 4, 3, 2, 1 },
                new int[] { 4, 3, 2, 1 },
                new int[] { 4, 3, 2, 1 }
            };
            Assert.AreEqual(true, result, "Matrix could not be rotated.");
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(rotatedMatrix[i][j], matrix[i][j], "Matrix could not be rotated.");
                }
            }
        }

        [TestMethod]
        public void TestShortestToChar()
        {
            // Arrange 
            // Input: S = "loveleetcode", C = 'e'
            // Output: [3, 2, 1, 0, 1, 0, 0, 1, 2, 2, 1, 0]
            // Act
            var distanceArray = ArrayExtensions.ShortestToChar("loveleetcode", 'e');
            // Assert
            Assert.AreEqual(3, distanceArray[0], "Wrong Result");
            Assert.AreEqual(2, distanceArray[1], "Wrong Result");
            Assert.AreEqual(1, distanceArray[2], "Wrong Result");
            Assert.AreEqual(0, distanceArray[3], "Wrong Result");
            Assert.AreEqual(1, distanceArray[4], "Wrong Result");
            Assert.AreEqual(0, distanceArray[5], "Wrong Result");
            Assert.AreEqual(0, distanceArray[6], "Wrong Result");
            Assert.AreEqual(1, distanceArray[7], "Wrong Result");
            Assert.AreEqual(2, distanceArray[8], "Wrong Result");
            Assert.AreEqual(2, distanceArray[9], "Wrong Result");
            Assert.AreEqual(1, distanceArray[10], "Wrong Result");
            Assert.AreEqual(0, distanceArray[11], "Wrong Result");
        }

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
