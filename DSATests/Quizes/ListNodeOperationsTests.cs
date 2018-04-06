using System;
using MainDSA.DataStructures.Lists;
using MainDSA.Quizes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSATests.Quizes
{
    [TestClass]
    public class ListNodeOperationsTests
    {
        public ListNode head1;
        public ListNode head2;
        [TestInitialize]
        public void CreateTestData()
        {
            // Create Head
            head1 = new ListNode(2);
            
            // Create Next Node
            ListNode next1 = new ListNode(4);
            head1.Next = next1;

            // Create End Node
            ListNode end1 = new ListNode(5);
            next1.Next = end1;

            // Create Head
            head2 = new ListNode(5);

            // Create Next Node
            ListNode next2 = new ListNode(6);
            head2.Next = next2;

            // Create End Node
            ListNode end2 = new ListNode(4);
            next2.Next = end2;
        }

        [TestMethod]
        public void TestReverseListIteratively1()
        {
            // Arrange
            CreateTestData();

            // Act
            var listNodeOperations = new ListNodeOperations();
            var reverseHead = listNodeOperations.ReverseListIteratively(head1);

            // Assert
            Assert.AreEqual(5, reverseHead.Value, "Wrong Value");
            Assert.AreEqual(4, reverseHead.Next.Value, "Wrong Value");
            Assert.AreEqual(2, reverseHead.Next.Next.Value, "Wrong Value");
        }
        
        [TestMethod]
        public void TestReverseListRecursively1()
        {
            // Arrange
            CreateTestData();

            // Act
            var listNodeOperations = new ListNodeOperations();
            var reverseHead = listNodeOperations.ReverseListRecursively(head2);

            // Assert
            Assert.AreEqual(4, reverseHead.Value, "Wrong Value");
            Assert.AreEqual(6, reverseHead.Next.Value, "Wrong Value");
            Assert.AreEqual(5, reverseHead.Next.Next.Value, "Wrong Value");
        }

        [TestMethod]
        public void TestAddTwoNumbers1()
        {
            // Arrange
            CreateTestData();

            // Act
            var listNodeOperations = new ListNodeOperations();
            var reverseHead = listNodeOperations.AddTwoNumbers(head1, head2);

            // Assert
            Assert.AreEqual(7, reverseHead.Value, "Wrong Value");
            Assert.AreEqual(0, reverseHead.Next.Value, "Wrong Value");
            Assert.AreEqual(0, reverseHead.Next.Next.Value, "Wrong Value");
            Assert.AreEqual(1, reverseHead.Next.Next.Next.Value, "Wrong Value");
        }
    }
}
