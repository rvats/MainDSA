using MainDSA.Quizes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DSATests.Quizes
{
    [TestClass]
    public class HighestProductFrom3NumbersInArrayTests
    {
        public int[] arrayForProducts1;
        public int[] arrayForProducts2;
        public int[] arrayForProducts3;

        [TestInitialize]
        public void CreateTestData()
        {
            arrayForProducts1 = new int[] { 1, 7, 3, 4, 10, 10, 8 };
            arrayForProducts2 = new int[] { 1, 7, 3, 4, -10, -10, -8 };
            arrayForProducts3 = new int[] { 5 };
        }

        [TestMethod]
        public void TestHighestProductOf3Case1()
        {
            // Arrange 
            CreateTestData();

            // Act
            var productsArray = ArrayExtensions.HighestProductOf3(arrayForProducts1);

            // Assert
            Assert.AreEqual(800, productsArray, "Different Product Expected");   
        }

        [TestMethod]
        public void TestHighestProductOf3Case2()
        {
            // Arrange 
            CreateTestData();

            // Act
            var productsArray = ArrayExtensions.HighestProductOf3(arrayForProducts2);

            // Assert
            Assert.AreEqual(700, productsArray, "Different Product Expected");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestHighestProductOf3Case3()
        {
            // Arrange 
            CreateTestData();

            // Act
            var productsArray = ArrayExtensions.HighestProductOf3(arrayForProducts3);

            // Assert
        }
    }
}
