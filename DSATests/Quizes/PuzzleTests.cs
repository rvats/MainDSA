using MainDSA.Quizes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSATests.Quizes
{
    [TestClass]
    public class PuzzleTests
    {
        [TestMethod]
        public void TestLetterCombinations()
        {
            var puzzle = new Puzzles();
            var combinations = puzzle.LetterCombinations("23");
            Assert.AreEqual("ad", combinations[0], "Wrong Value");
            Assert.AreEqual("ae", combinations[1], "Wrong Value");
            Assert.AreEqual("af", combinations[2], "Wrong Value");
            Assert.AreEqual("bd", combinations[3], "Wrong Value");
            Assert.AreEqual("be", combinations[4], "Wrong Value");
            Assert.AreEqual("bf", combinations[5], "Wrong Value");
            Assert.AreEqual("cd", combinations[6], "Wrong Value");
            Assert.AreEqual("ce", combinations[7], "Wrong Value");
            Assert.AreEqual("cf", combinations[8], "Wrong Value");
            combinations = puzzle.LetterCombinations("999");
            Assert.AreEqual(64, combinations.Count, "Wrong Value");
            Assert.AreEqual("www", combinations[0], "Wrong Value");
            Assert.AreEqual("wxw", combinations[4], "Wrong Value");
            Assert.AreEqual("xww", combinations[16], "Wrong Value");
            Assert.AreEqual("yww", combinations[32], "Wrong Value");
            Assert.AreEqual("zww", combinations[48], "Wrong Value");
            Assert.AreEqual("zwz", combinations[63], "Wrong Value");
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
    }
}
