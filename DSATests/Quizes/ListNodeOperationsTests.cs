using System;
using MainDSA.DataStructures.Lists;
using MainDSA.Quizes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSATests.Quizes
{
    [TestClass]
    public class ListNodeOperationsTests
    {
        public ListNode head;
        [TestInitialize]
        public void CreateTestData()
        {
            // Create Head
            head = new ListNode(0);
            
            // Create Next Node
            ListNode next1 = new ListNode(1);
            head.Next = next1;

            // Create Next Node
            ListNode next2 = new ListNode(2);
            next1.Next = next2;

            // Create End Node
            ListNode end = new ListNode(3);
            next2.Next = end;
        }

        [TestMethod]
        public void TestReverseListIteratively1()
        {
            // Arrange
            CreateTestData();

            // Act
            var listNodeOperations = new ListNodeOperations();
            var reverseHead = listNodeOperations.ReverseListIteratively(head);

            // Assert
            Assert.AreEqual(3, reverseHead.Value, "Wrong Value");
            Assert.AreEqual(2, reverseHead.Next.Value, "Wrong Value");
            Assert.AreEqual(1, reverseHead.Next.Next.Value, "Wrong Value");
            Assert.AreEqual(0, reverseHead.Next.Next.Next.Value, "Wrong Value");
        }
        
        [TestMethod]
        public void TestReverseListRecursively1()
        {
            // Arrange
            CreateTestData();

            // Act
            var listNodeOperations = new ListNodeOperations();
            var reverseHead = listNodeOperations.ReverseListRecursively(head);

            // Assert
            Assert.AreEqual(3, reverseHead.Value, "Wrong Value");
            Assert.AreEqual(2, reverseHead.Next.Value, "Wrong Value");
            Assert.AreEqual(1, reverseHead.Next.Next.Value, "Wrong Value");
            Assert.AreEqual(0, reverseHead.Next.Next.Next.Value, "Wrong Value");
        }
    }
}
