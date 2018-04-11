using MainDSA.Quizes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSATests.Quizes
{
    [TestClass]
    public class MathematicsTests
    {
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

            Assert.AreEqual(C, result,"Wrong Result");
        }

        [TestMethod]
        public void TestNumberToEnglish()
        {
            var NFibonacci = Mathematics.NthFibonacci(5);
            Assert.AreEqual(5, NFibonacci, "Wrong Value");
        }
    }
}
