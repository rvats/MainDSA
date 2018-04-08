using System;
using MainDSA.Quizes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSATests.Quizes
{
    [TestClass]
    public class PuzzleTests
    {
        [TestMethod]
        public void TestNumberToWords()
        {
            var puzzle = new Puzzles();
            var numberInEnglish = puzzle.NumberToWords(987654321);
            Assert.AreEqual("Nine Hundred Eighty Seven Million Six Hundred Fifty Four Thousand Three Hundred Twenty One", numberInEnglish, "Wrong Value");
            puzzle = new Puzzles();
            numberInEnglish = puzzle.NumberToWords(123467890);
            Assert.AreEqual("One Hundred Twenty Three Million Four Hundred Sixty Seven Thousand Eight Hundred Ninety", numberInEnglish, "Wrong Value");
        }
    }
}
