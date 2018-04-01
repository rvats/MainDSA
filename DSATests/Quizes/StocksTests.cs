using MainDSA.Quizes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StocksTests
{
    [TestClass]
    public class StocksTests
    {
        /// <summary>
        /// 
        /// </summary>
        public int[] stockPricesYesterday;

        [TestInitialize]
        public void StocksData()
        {
            stockPricesYesterday = new int[] { 10, 7, 5, 8, 11, 9 };
        }

        [TestMethod]
        public void TestGetMaxProfit()
        {
            // Arrange
            StocksData();

            // Act
            var maxProfit = Stocks.GetMaxProfit(stockPricesYesterday);

            // Assert
            Assert.AreEqual(6, maxProfit, "Incorrect Profit is being returned");
        }

        [TestMethod]
        public void TestGetMaxProfitAlternate()
        {
            // Arrange
            StocksData();

            // Act
            var maxProfit = Stocks.GetMaxProfitAlternate(stockPricesYesterday);

            // Assert
            Assert.AreEqual(6, maxProfit, "Incorrect Profit is being returned");
        }
    }
}
