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
    }
}
