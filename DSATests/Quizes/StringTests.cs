﻿using MainDSA.Quizes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSATests.Quizes
{
    [TestClass]
    public class StringTests
    {
        public string testDataSetForPalindromeChecksWithoutRemovingCharacters1;
        public string testDataSetForPalindromeChecksWithoutRemovingCharacters2;
        public string testDataSetForPalindromeChecksRemovingAtMax1Character1;
        public string testDataSetForPalindromeChecksRemovingAtMax1Character2;

        [TestInitialize]
        public void CreateTestData()
        {
            testDataSetForPalindromeChecksWithoutRemovingCharacters1 = "A man, a plan, a canal: Panama";
            testDataSetForPalindromeChecksWithoutRemovingCharacters2 = "race a car";
            testDataSetForPalindromeChecksRemovingAtMax1Character1 = "aabebcaa";
            testDataSetForPalindromeChecksRemovingAtMax1Character2 = "aacebeaa";
        }

        [TestMethod]
        public void TestIsPalindromeRemovingAtMax1CharacterCase1()
        {
            // Arrange
            CreateTestData();

            // Act
            var result = String.PossiblePalindromeByRemovingOneChar(testDataSetForPalindromeChecksRemovingAtMax1Character1);

            // Assert
            Assert.AreEqual(5, result, "Result Not As Expected");
        }

        [TestMethod]
        public void TestIsPalindromeRemovingAtMax1CharacterCase2()
        {
            // Arrange
            CreateTestData();

            // Act
            var result = String.PossiblePalindromeByRemovingOneChar(testDataSetForPalindromeChecksRemovingAtMax1Character2);

            // Assert
            Assert.AreEqual(2, result, "Result Not As Expected");
        }

        [TestMethod]
        public void TestIsPalindromeUsingRegexCase1()
        {
            // Arrange
            CreateTestData();

            // Act
            var result = String.IsPalindromeUsingRegex(testDataSetForPalindromeChecksWithoutRemovingCharacters1);

            // Assert
            Assert.AreEqual(true, result, "Result Not As Expected");
        }

        [TestMethod]
        public void TestIsPalindromeUsingRegexCase2()
        {
            // Arrange
            CreateTestData();

            // Act
            var result = String.IsPalindromeUsingRegex(testDataSetForPalindromeChecksWithoutRemovingCharacters2);

            // Assert
            Assert.AreEqual(false, result, "Result Not As Expected");
        }

        [TestMethod]
        public void TestIsPalindromeWithoutUsingRegexCase1()
        {
            // Arrange
            CreateTestData();

            // Act
            var result = String.IsPalindromeWithoutUsingRegex(testDataSetForPalindromeChecksWithoutRemovingCharacters1);

            // Assert
            Assert.AreEqual(true, result, "Result Not As Expected");
        }

        [TestMethod]
        public void TestIsPalindromeWithoutUsingRegexCase2()
        {
            // Arrange
            CreateTestData();

            // Act
            var result = String.IsPalindromeWithoutUsingRegex(testDataSetForPalindromeChecksWithoutRemovingCharacters2);

            // Assert
            Assert.AreEqual(false, result, "Result Not As Expected");
        }
    }
}
