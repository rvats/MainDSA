using MainDSA.Quizes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSATests.Quizes
{
    [TestClass]
    public class PuzzleTests
    {
        /// <summary>
        /// This is a valid test case for Phone Digit To Letter Translations
        /// </summary>
        [TestMethod]
        public void TestLetterFromPhoneDigitCombinations1()
        {
            var puzzle = new Puzzles();
            var combinations = puzzle.LetterCombinations("23");
            Assert.AreEqual(9, combinations.Count, "Wrong Value");
            Assert.IsTrue(combinations.Contains("ad"));
            Assert.IsTrue(combinations.Contains("ad"));
            Assert.IsTrue(combinations.Contains("ae"));
            Assert.IsTrue(combinations.Contains("af"));
            Assert.IsTrue(combinations.Contains("bd"));
            Assert.IsTrue(combinations.Contains("be"));
            Assert.IsTrue(combinations.Contains("bf"));
            Assert.IsTrue(combinations.Contains("cd"));
            Assert.IsTrue(combinations.Contains("ce"));
            Assert.IsTrue(combinations.Contains("cf"));
        }

        /// <summary>
        /// Valid Code As 999 does translate to xxx
        /// </summary>
        [TestMethod]
        public void TestLetterFromPhoneDigitCombinations2()
        {
            var puzzle = new Puzzles();
            var combinations = puzzle.LetterCombinations("999");
            Assert.AreEqual(64, combinations.Count, "Wrong Value");
            Assert.IsTrue(combinations.Contains("www"));
            Assert.IsTrue(combinations.Contains("wxw"));
            Assert.IsTrue(combinations.Contains("xww"));
            Assert.IsTrue(combinations.Contains("yww"));
            Assert.IsTrue(combinations.Contains("zww"));
            Assert.IsTrue(combinations.Contains("zwz"));
            Assert.IsTrue(combinations.Contains("xxx"));
        }

        [TestMethod]
        public void TestNumberToWords()
        {
            var puzzle = new Puzzles();
            var numberInEnglish = puzzle.NumberToWords(987654321);
            Assert.AreEqual("Nine Hundred Eighty Seven Million Six Hundred Fifty Four Thousand Three Hundred Twenty One", numberInEnglish, "Wrong Value");
            puzzle = new Puzzles();
            numberInEnglish = puzzle.NumberToWords(1234567890);
            Assert.AreEqual("One Billion Two Hundred Thirty Four Million Five Hundred Sixty Seven Thousand Eight Hundred Ninety", numberInEnglish, "Wrong Value");
        }

        [TestMethod]
        public void TestWallsAndGates()
        {
            int[,] rooms = new int[,] { { 2147483647, -1, 0, 2147483647 }, { 2147483647, 2147483647, 2147483647, -1 },{2147483647, -1, 2147483647, -1},{0, -1, 2147483647, 2147483647} };
            var puzzle = new Puzzles();
            puzzle.WallsAndGates(rooms);
            Assert.AreEqual(rooms,rooms);
        }
    }
}
