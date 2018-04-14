using MainDSA.Algorithms.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSATests.Algorithms
{
    [TestClass]
    public class BinarySearchTests
    {
        [TestMethod]
        public void TestNextGreatestLetter1()
        {
            char[] letters = new char[] { 'c', 'f', 'j' };
            char target = 'a';

            BinarySearch binarySearch = new BinarySearch();
            var result = binarySearch.NextGreatestLetter(letters, target);

            Assert.AreEqual('c', result);
        }
    }
}
