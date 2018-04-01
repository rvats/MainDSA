using MainDSA.Quizes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StocksTests
{
    [TestClass]
    public class StocksTests
    {
        /// <summary>
        /// 
        /// </summary>
        public int[] stockPricesYesterdayCase1;
        public int[] stockPricesYesterdayCase2;
        public int[] stockPricesYesterdayCase3;
        public int[] stockPricesYesterdayCase4;

        [TestInitialize]
        public void StocksData()
        {
            stockPricesYesterdayCase1 = new int[] { 10, 7, 5, 8, 11, 9 };
            stockPricesYesterdayCase2 = new int[] { 5, 4, 3, 2, 1 };
            stockPricesYesterdayCase3 = new int[] { 10 };
            stockPricesYesterdayCase4 = new int[] { 100, 200, 150, 50, 10, 90, 50, 100, 200, 300, 400, 50, 10, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000, 900, 300, 100, 50, 25, 30, 20, 10 };
        }

        [TestMethod]
        public void TestGetMaxProfitCase1()
        {
            // Arrange
            StocksData();

            // Act
            var maxProfit = Stocks.GetMaxProfit(stockPricesYesterdayCase1);

            // Assert
            Assert.AreEqual(6, maxProfit, "Incorrect Profit is being returned");
        }

        [TestMethod]
        public void TestGetMaxProfitAlternateCase1()
        {
            // Arrange
            StocksData();

            // Act
            var maxProfit = Stocks.GetMaxProfitAlternate(stockPricesYesterdayCase1);

            // Assert
            Assert.AreEqual(6, maxProfit, "Incorrect Profit is being returned");
        }

        [TestMethod]
        public void TestGetMaxProfitCase2()
        {
            // Arrange
            StocksData();

            // Act
            var maxProfit = Stocks.GetMaxProfit(stockPricesYesterdayCase2);

            // Assert - This approach returns negative profit
            Assert.AreEqual(-1, maxProfit, "Incorrect Profit is being returned");
        }

        [TestMethod]
        public void TestGetMaxProfitAlternateCase2()
        {
            // Arrange
            StocksData();

            // Act
            var maxProfit = Stocks.GetMaxProfitAlternate(stockPricesYesterdayCase2);

            // Assert - This returns negative profit
            Assert.AreEqual(0, maxProfit, "Incorrect Profit is being returned");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetMaxProfitCase3()
        {
            // Arrange
            StocksData();

            // Act
            var maxProfit = Stocks.GetMaxProfit(stockPricesYesterdayCase3);

            // Assert            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetMaxProfitAlternateCase3()
        {
            // Arrange
            StocksData();

            // Act
            var maxProfit = Stocks.GetMaxProfitAlternate(stockPricesYesterdayCase3);

            // Assert
        }

        [TestMethod]
        public void TestGetMaxProfitCase4()
        {
            // Arrange
            StocksData();

            // Act
            var maxProfit = Stocks.GetMaxProfit(stockPricesYesterdayCase4);

            // Assert
            Assert.AreEqual(990, maxProfit, "Incorrect Profit is being returned");
        }

        [TestMethod]
        public void TestGetMaxProfitAlternateCase4()
        {
            // Arrange
            StocksData();

            // Act
            var maxProfit = Stocks.GetMaxProfitAlternate(stockPricesYesterdayCase4);

            // Assert
            Assert.AreEqual(990, maxProfit, "Incorrect Profit is being returned");
        }
    }
}
