using System;
using MainDSA.Algorithms.Encryption;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSATests.Algorithms
{
    [TestClass]
    public class CompressionTests
    {
        [TestMethod]
        public void TestCompress()
        {
            Compression compression = new Compression();
            var result = compression.Compress(new char[] { 'a', 'a', 'a', 'b'});
            Assert.AreEqual('a', result[0]);
            Assert.AreEqual(3, result[1]);
        }
    }
}
