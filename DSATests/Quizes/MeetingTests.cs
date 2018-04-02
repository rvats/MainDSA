using System.Collections.Generic;
using MainDSA.Quizes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSATests.Quizes
{
    [TestClass]
    public class MeetingTests
    {

        private List<Meeting> allMeetings = new List<Meeting>();

        private void CreateMeetingData()
        {
            allMeetings.Add(new Meeting(0, 1));
            allMeetings.Add(new Meeting(3, 5));
            allMeetings.Add(new Meeting(4, 8));
            allMeetings.Add(new Meeting(10, 12));
            allMeetings.Add(new Meeting(9, 10));
        }

        [TestMethod]
        public void TestMergeMeetings()
        {
            // Arrange
            CreateMeetingData();

            // Act
            var mergeMeetings = Meeting.MergeRanges(allMeetings);

            // Assert
            Assert.AreEqual(3, mergeMeetings.Count, "Count Of Merged Meetings For Sample Data is wrong.");
            Assert.AreEqual("(0, 1)", mergeMeetings[0].ToString(), "Merged Meeting Data For Sample Data is wrong.");
            Assert.AreEqual("(3, 8)", mergeMeetings[1].ToString(), "Merged Meeting Data For Sample Data is wrong.");
            Assert.AreEqual("(9, 12)", mergeMeetings[2].ToString(), "Merged Meeting Data For Sample Data is wrong.");
        }
    }
}