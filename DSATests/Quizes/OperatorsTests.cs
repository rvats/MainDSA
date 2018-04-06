using MainDSA.Quizes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSATests.Quizes
{
    [TestClass]
    public class OperatorsTests
    {
        // "123", 6 -> ["1+2+3", "1*2*3"] 
        // "232", 8 -> ["2*3+2", "2+3*2"]
        // "105", 5 -> ["1*0+5","10-5"]
        // "00", 0 -> ["0+0", "0-0", "0*0"]
        // "3456237490", 9191 -> []
        [TestMethod]
        public void TestAddOperators1()
        {
            // Arrange
            Operators operators = new Operators();
            // Act
            var expressions = operators.AddOperators("123", 6);
            // Assert
            Assert.AreEqual(2, expressions.Count, "Wrong Expression Count");
            Assert.AreEqual("1+2+3", expressions[0], "Wrong Expression");
            Assert.AreEqual("1*2*3", expressions[1], "Wrong Expression");
        }

        [TestMethod]
        public void TestAddOperators2()
        {
            // Arrange
            Operators operators = new Operators();
            // Act
            var expressions = operators.AddOperators("232", 8);
            // Assert
            Assert.AreEqual(2, expressions.Count, "Wrong Expression Count");
            Assert.AreEqual("2+3*2", expressions[0], "Wrong Expression");
            Assert.AreEqual("2*3+2", expressions[1], "Wrong Expression");
        }

        [TestMethod]
        public void TestAddOperators3()
        {
            // Arrange
            Operators operators = new Operators();
            // Act
            var expressions = operators.AddOperators("105", 5);
            // Assert
            Assert.AreEqual(2, expressions.Count, "Wrong Expression Count");
            Assert.AreEqual("1*0+5", expressions[0], "Wrong Expression");
            Assert.AreEqual("10-5", expressions[1], "Wrong Expression");
        }

        [TestMethod]
        public void TestAddOperators4()
        {
            // Arrange
            Operators operators = new Operators();
            // Act
            var expressions = operators.AddOperators("00", 0);
            // Assert
            Assert.AreEqual(3, expressions.Count, "Wrong Expression Count");
            Assert.AreEqual("0+0", expressions[0], "Wrong Expression");
            Assert.AreEqual("0-0", expressions[1], "Wrong Expression");
            Assert.AreEqual("0*0", expressions[2], "Wrong Expression");
        }

        [TestMethod]
        public void TestAddOperators5()
        {
            // Arrange
            Operators operators = new Operators();
            // Act
            var expressions = operators.AddOperators("3456237490", 9191);
            // Assert
            Assert.AreEqual(0, expressions.Count, "Wrong Expression Count");

        }
    }
}
