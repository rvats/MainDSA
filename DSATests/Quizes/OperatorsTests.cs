using System;
using MainDSA.Quizes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSATests.Quizes
{
    [TestClass]
    public class OperatorsTests
    {
        [TestMethod]
        public void TestAddOperators1()
        {
            // Arrange and Act
            var expressions = Operators.AddOperators("123", 6);
            // Assert
            Assert.AreEqual(2, expressions.Count, "Wrong Expression Count");
            Assert.AreEqual("1+2+3", expressions[0], "Wrong Expression");
            Assert.AreEqual("1*2*3", expressions[1], "Wrong Expression");
        }
    }
}
