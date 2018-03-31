using System;
using MainDSA.Quizes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSATests.Quizes
{
    [TestClass]
    public class LoveRectangleTests
    {
        [TestMethod]
        public void TestLoveRectanglesOverLap()
        {
            // Arrange
            LoveRectangle rectangle1 = new LoveRectangle(1, 1, 5, 4);
            LoveRectangle rectangle2 = new LoveRectangle(5, 3, 3, 4);
            RangeOverlap rangeOverlap = new RangeOverlap(3, 1);

            // Act
            LoveRectangle overlapRectangle = rangeOverlap.FindRectangularOverlap(rectangle1, rectangle2);

            // Assert
            Assert.AreEqual(5, overlapRectangle.LeftX, "X Coordinate of Bottom Left Points for over lapped rectangle is wrong.");
            Assert.AreEqual(3, overlapRectangle.BottomY, "Y Coordinate of Bottom Left Points is wrong.");
            Assert.AreEqual(1, overlapRectangle.Width, "Width for over lapped rectangle is wrong");
            Assert.AreEqual(2, overlapRectangle.Height, "Height for over lapped rectangle is wrong.");
            Assert.AreEqual("(5, 3, 1, 2)", overlapRectangle.ToString(), "Display format for over lapped rectangle is wrong.");
        }
    }
}
