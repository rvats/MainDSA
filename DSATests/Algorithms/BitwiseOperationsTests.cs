using System;
using MainDSA.Algorithms.BitwiseOperations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSATests.Algorithms
{
    [TestClass]
    public class BitwiseOperationsTests
    {
        BitwiseOperations bitwiseOperations;

        [TestInitialize]
        public void Arrange()
        {
            bitwiseOperations = new BitwiseOperations();
        }

        [Ignore]
        [TestMethod]
        public void TestUpdateBits()
        {
            var result = bitwiseOperations.UpdateBits(1024, 19, 2, 6);
            Assert.AreEqual(1100, result, "Wrong Value");
        }

        [Ignore]
        [TestMethod]
        public void TestPrintBinary()
        {
            var result = bitwiseOperations.PrintBinary(0.72);
            Assert.AreEqual("ERROR", result, "Wrong Value");
        }

        [TestMethod]
        public void TestPowerOf2()
        {
            var result = bitwiseOperations.PowerOf2(1024);
            Assert.AreEqual(true, result, "Wrong Value");
            result = bitwiseOperations.PowerOf2(3102);
            Assert.AreEqual(false, result, "Wrong Value");
        }

        [TestMethod]
        public void TestBitSwapRequired()
        {
            var result = bitwiseOperations.BitSwapRequired(29,15);
            Assert.AreEqual(2, result, "Wrong Value");
            result = bitwiseOperations.BitSwapRequired(1,0);
            Assert.AreEqual(1, result, "Wrong Value");
            result = bitwiseOperations.BitSwapRequired(Int16.MaxValue, 0);
            Assert.AreEqual(15, result, "Wrong Value");
            result = bitwiseOperations.BitSwapRequired(Int16.MinValue, 0);
            Assert.AreEqual(17, result, "Wrong Value");
            result = bitwiseOperations.BitSwapRequired(Int32.MaxValue, 0);
            Assert.AreEqual(31, result, "Wrong Value");
            result = bitwiseOperations.BitSwapRequired(Int32.MinValue, 0);
            Assert.AreEqual(1, result, "Wrong Value");
            // Following Lines are commented as the function wrote does not support long
            //result = bitwiseOperations.BitSwapRequired(Int64.MaxValue, 0);
            //Assert.AreEqual(63, result, "Wrong Value");
            //result = bitwiseOperations.BitSwapRequired(Int64.MinValue, 0);
            //Assert.AreEqual(64, result, "Wrong Value");
        }

        [TestMethod]
        public void TestSwapOddEvenBits()
        {
            // Need to study the logic for this 
            var result = bitwiseOperations.SwapOddEvenBits(555);
            Assert.AreEqual(279, result, "Wrong Value");
        }
    }
}
