using MainDSA.Quizes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DSATests.Quizes
{
    [TestClass]
    public class ProductsOfAllNumberExceptAtIndex
    {
        public int[] arrayForProducts1;
        public int[] arrayForProducts2;
        public int[] arrayForProducts3;

        [TestInitialize]
        public void CreateTestData()
        {
            arrayForProducts1 = new int[] { 1, 7, 3, 4 };
            arrayForProducts2 = new int[] { 1, 7, 3, 4, -10, -10 };
            arrayForProducts3 = new int[] { 5 };
        }

        [TestMethod]
        public void TestReturnProductOfRemainingNumbersCase1()
        {
            // Arrange 
            CreateTestData();

            // Act
            var productsArray = ArrayExtensions.ReturnProductOfRemainingNumbers(arrayForProducts1);

            // Assert
            Assert.AreEqual(84, productsArray[0], "Different Product Expected");
            Assert.AreEqual(12, productsArray[1], "Different Product Expected");
            Assert.AreEqual(28, productsArray[2], "Different Product Expected");
            Assert.AreEqual(21, productsArray[3], "Different Product Expected");
        }

        [TestMethod]
        public void TestGetProductsOfAllIntsExceptAtIndexCase1()
        {
            // Arrange 
            CreateTestData();

            // Act
            var productsArray = ArrayExtensions.GetProductsOfAllIntsExceptAtIndex(arrayForProducts1);

            // Assert
            Assert.AreEqual(84, productsArray[0], "Different Product Expected");
            Assert.AreEqual(12, productsArray[1], "Different Product Expected");
            Assert.AreEqual(28, productsArray[2], "Different Product Expected");
            Assert.AreEqual(21, productsArray[3], "Different Product Expected");
        }

        [TestMethod]
        public void TestReturnProductOfRemainingNumbersCase2()
        {
            // Arrange 
            CreateTestData();

            // Act
            var productsArray = ArrayExtensions.ReturnProductOfRemainingNumbers(arrayForProducts2);

            // Assert
            Assert.AreEqual(8400, productsArray[0], "Different Product Expected");
            Assert.AreEqual(1200, productsArray[1], "Different Product Expected");
            Assert.AreEqual(2800, productsArray[2], "Different Product Expected");
            Assert.AreEqual(2100, productsArray[3], "Different Product Expected");
            Assert.AreEqual(-840, productsArray[4], "Different Product Expected");
            Assert.AreEqual(-840, productsArray[5], "Different Product Expected");
        }

        [TestMethod]
        public void TestGetProductsOfAllIntsExceptAtIndexCase2()
        {
            // Arrange 
            CreateTestData();

            // Act
            var productsArray = ArrayExtensions.GetProductsOfAllIntsExceptAtIndex(arrayForProducts2);

            // Assert
            Assert.AreEqual(8400, productsArray[0], "Different Product Expected");
            Assert.AreEqual(1200, productsArray[1], "Different Product Expected");
            Assert.AreEqual(2800, productsArray[2], "Different Product Expected");
            Assert.AreEqual(2100, productsArray[3], "Different Product Expected");
            Assert.AreEqual(-840, productsArray[4], "Different Product Expected");
            Assert.AreEqual(-840, productsArray[5], "Different Product Expected");
        }

        [TestMethod]
        public void TestReturnProductOfRemainingNumbersCase3()
        {
            // Arrange 
            CreateTestData();

            // Act
            var productsArray = ArrayExtensions.ReturnProductOfRemainingNumbers(arrayForProducts3);

            // Assert
            Assert.AreEqual(1, productsArray[0], "Different Product Expected");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetProductsOfAllIntsExceptAtIndexCase3()
        {
            // Arrange 
            CreateTestData();

            // Act
            var productsArray = ArrayExtensions.GetProductsOfAllIntsExceptAtIndex(arrayForProducts3);

            // Assert
        }
    }
}
