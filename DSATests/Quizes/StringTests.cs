using MainDSA.Quizes;
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
        public void TestStringCompress()
        {
            var resultString = String.Compress("locol");
            var resultLength = String.CompressProspectLength("locol");
            Assert.AreEqual("locol", resultString, "Result Not As Expected");
            Assert.AreEqual(10, resultLength, "Result Not As Expected");

            resultString = String.Compress("aaaaa");
            resultLength = String.CompressProspectLength("aaaaa");
            Assert.AreEqual("a5", resultString, "Result Not As Expected");
            Assert.AreEqual(2, resultLength, "Result Not As Expected");

            resultString = String.Compress("aabbccdd");
            resultLength = String.CompressProspectLength("aabbccdd");
            Assert.AreEqual("aabbccdd", resultString, "Result Not As Expected");
            Assert.AreEqual(8, resultLength, "Result Not As Expected");

            resultString = String.Compress("aabccccccccccddd");
            resultLength = String.CompressProspectLength("aabccccccccccddd");
            Assert.AreEqual("a2b1c10d3", resultString, "Result Not As Expected");
            Assert.AreEqual(9, resultLength, "Result Not As Expected");
        }

        [TestMethod]
        public void TestIsPermutationOfPalindrome()
        {
            var result = String.IsPermutationOfPalindrome("locol");
            Assert.AreEqual(true, result, "Result Not As Expected");
            result = String.IsPermutationOfPalindrome("lccoo");
            Assert.AreEqual(true, result, "Result Not As Expected");
            result = String.IsPermutationOfPalindrome("local");
            Assert.AreEqual(false, result, "Result Not As Expected");
            result = String.IsPermutationOfPalindrome("tactcoa");
            Assert.AreEqual(true, result, "Result Not As Expected");
            result = String.IsPermutationOfPalindrome("lcal");
            Assert.AreEqual(false, result, "Result Not As Expected");
        }

        [TestMethod]
        public void TestCheckIfStringsArePermutationOfEachOther()
        {
            var result = String.CheckIfStringsArePermutationOfEachOther("tool","loot");
            Assert.AreEqual(true, result, "Result Not As Expected");
        }

        [Ignore]
        [TestMethod]
        public void TestLongestPalindrome()
        {
            var result = String.LongestPalindrome("babad");
            Assert.AreEqual("bab", result, "Result Not As Expected");
        }

        [Ignore]
        [TestMethod]
        public void TestMinWindowCase1()
        {
            // Arrange
            // Act
            var result = String.MinWindow("abcdebdde", "bde");

            // Assert
            Assert.AreEqual("bcde", result, "Result Not As Expected");

            // Arrange
            // Act
            result = String.MinWindow("ADOBECODEBANC","ABC");
            // Assert
            Assert.AreEqual("BANC", result, "Result Not As Expected");
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

        [TestMethod]
        public void TestIsNumberMultipleCases()
        {
            var number = "6";
            // Act
            var result = String.IsNumber(number);
            // Assert
            Assert.AreEqual(true, result, "Result Not As Expected");

            number = "-6";
            // Act
            result = String.IsNumber(number);
            // Assert
            Assert.AreEqual(true, result, "Result Not As Expected");

            number = "-abc";
            // Act
            result = String.IsNumber(number);
            // Assert
            Assert.AreEqual(false, result, "Result Not As Expected");

            number = "-6e";
            // Act
            result = String.IsNumber(number);
            // Assert
            Assert.AreEqual(false, result, "Result Not As Expected");

            number = "6e6.5";
            // Act
            result = String.IsNumber(number);
            // Assert
            Assert.AreEqual(false, result, "Result Not As Expected");

            number = "-6e6.5";
            // Act
            result = String.IsNumber(number);
            // Assert
            Assert.AreEqual(false, result, "Result Not As Expected");
        }
    }
}
