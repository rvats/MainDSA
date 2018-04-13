using MainDSA.Quizes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSATests.Quizes
{
    [TestClass]
    public class MathematicsTests
    {
        [Ignore]
        [TestMethod]
        public void TestSparseMatrixMultiply1()
        {
            int[][] A = { new int[] { 1, 0, 0 }, new int[] { 1, 0, 3 } };
            int[][] B = { new int[] { 7, 0, 0 }, new int[] { 0, 0, 0 }, new int[] { 0, 0, 1 } };

            var result = Mathematics.Multiply(A, B);

            Assert.AreEqual(result, result);
        }

        [TestMethod]
        public void TestSparseMatrixMultiply2()
        {
            int[,] A = { { 1, 0, 0 }, { -1, 0, 3 } }; // Input
            int[,] B = { { 7, 0, 0 }, { 0, 0, 0 }, { 0, 0, 1 } }; // Input
            int[,] C = { { 7, 0, 0 }, { -7, 0, 3 } }; // Expected Output
            var result = Mathematics.Multiply(A, B);

            Assert.AreEqual(C.Length, result.Length, "Wrong Result");
            Assert.AreEqual(C[0, 0], result[0, 0], "Wrong Result");
            Assert.AreEqual(C[0, 1], result[0, 1], "Wrong Result");
            Assert.AreEqual(C[0, 2], result[0, 2], "Wrong Result");
            Assert.AreEqual(C[1, 0], result[1, 0], "Wrong Result");
            Assert.AreEqual(C[1, 1], result[1, 1], "Wrong Result");
            Assert.AreEqual(C[1, 2], result[1, 2], "Wrong Result");
        }

        [TestMethod]
        public void TestNthFibonacciNumber()
        {
            var NFibonacci = Mathematics.NthFibonacci(5);
            Assert.AreEqual(5, NFibonacci, "Wrong Value");
        }
    }
}
