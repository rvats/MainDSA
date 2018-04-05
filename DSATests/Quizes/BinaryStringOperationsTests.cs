using System;
using MainDSA.Quizes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSATests.Quizes
{
    [TestClass]
    public class BinaryStringOperationsTests
    {
        public string[] testDataSet1;
        public string[] testDataSet2;

        [TestInitialize]
        public void CreateTestData()
        {
            testDataSet1 = new string[] { "10000", "1" };
            testDataSet2 = new string[] { "", "" };
        }

        [TestMethod]
        public void TestAddBinaryCase1()
        {
            // Arrange
            CreateTestData();

            // Act
            var result = BinaryStringOperations.AddBinary(testDataSet1[0], testDataSet1[1]);

            // Act
            Assert.AreEqual("10001", result, "Different Value Expected");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddBinaryCase2()
        {
            // Arrange
            CreateTestData();

            // Act
            var result = BinaryStringOperations.AddBinary(testDataSet2[0], testDataSet2[1]);

            // Act
        }
    }
}
