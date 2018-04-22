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
            var result = ~bitwiseOperations.UpdateBits(1024, 19, 2, 6);
            Assert.AreEqual(1100, result, "Wrong Value");
        }
    }
}
