using MainDSA.Quizes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSATests.Quizes
{
    [TestClass]
    public class StringTests
    {
        public string testDataSet1;
        public string testDataSet2;

        [TestInitialize]
        public void CreateTestData()
        {
            testDataSet1 = "A man, a plan, a canal: Panama";
            testDataSet2 = "race a car";
        }

        [TestMethod]
        public void TestIsPalindromeUsingRegexCase1()
        {
            // Arrange
            CreateTestData();

            // Act
            var result = String.IsPalindromeUsingRegex(testDataSet1);

            // Assert
            Assert.AreEqual(true, result, "Result Not As Expected");
        }

        [TestMethod]
        public void TestIsPalindromeUsingRegexCase2()
        {
            // Arrange
            CreateTestData();

            // Act
            var result = String.IsPalindromeUsingRegex(testDataSet2);

            // Assert
            Assert.AreEqual(false, result, "Result Not As Expected");
        }

        [TestMethod]
        public void TestIsPalindromeWithoutUsingRegexCase1()
        {
            // Arrange
            CreateTestData();

            // Act
            var result = String.IsPalindromeWithoutUsingRegex(testDataSet1);

            // Assert
            Assert.AreEqual(true, result, "Result Not As Expected");
        }

        [TestMethod]
        public void TestIsPalindromeWithoutUsingRegexCase2()
        {
            // Arrange
            CreateTestData();

            // Act
            var result = String.IsPalindromeWithoutUsingRegex(testDataSet2);

            // Assert
            Assert.AreEqual(false, result, "Result Not As Expected");
        }
    }
}
