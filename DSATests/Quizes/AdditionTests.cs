using System.Collections.Generic;
using MainDSA.Quizes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSATests.Quizes
{
    [TestClass]
    public class AdditionTests
    {
        public int[] testDataSet1;

        [TestInitialize]
        public void CreateTestData()
        {
            testDataSet1 = new int[] { -2, -1, 0, 1, 2 };
        }

        [TestMethod]
        public void TestGetListOf3WhoseSumIsTargetCase1()
        {
            // Arrange 
            CreateTestData();

            // Act
            Addition add = new Addition();
            var resultData = add.GetListOf3WhoseSumIsTarget(testDataSet1, 0);
            var expectedData = new List<int>() { -1, 0, 1 };
            bool result = true;
            for (int i = 0; i < resultData[1].Count; i++)
            {
                if (expectedData[i] != resultData[1][i])
                {
                    result = false; break;
                }
            }

            Assert.AreEqual(true, result, "Result should contain the expected data.");
        }
    }
}
