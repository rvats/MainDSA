using System;
using MainDSA.Quizes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSATests.Quizes
{
    [TestClass]
    public class MathematicsTests
    {
        [TestMethod]
        public void TestNumberToEnglish()
        {
            var NFibonacci = Mathematics.NthFibonacci(5);
            Assert.AreEqual(5, NFibonacci, "Wrong Value");
        }
    }
}
