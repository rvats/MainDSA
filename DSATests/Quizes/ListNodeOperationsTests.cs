using MainDSA.DataStructures.Lists;
using MainDSA.Quizes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSATests.Quizes
{
    [TestClass]
    public class ListNodeOperationsTests
    {
        private ListNode head1;
        private ListNode head2;
        private ListNode head3;
        private ListNode end1;
        private ListNode end2;

        [TestInitialize]
        public void CreateTestData()
        {
            // =========================================================================
            // Create Head1
            head1 = new ListNode(2);
            // Create Next1 Node
            ListNode next1 = new ListNode(4);
            head1.Next = next1;
            // Create End1 Node
            end1 = new ListNode(5);
            next1.Next = end1;
            // =========================================================================

            // =========================================================================
            // Create Head2
            head2 = new ListNode(5);
            // Create Next2 Node
            ListNode next2 = new ListNode(6);
            head2.Next = next2;
            // Create End2 Node
            end2 = new ListNode(4);
            next2.Next = end2;
            // =========================================================================
        }

        public void CreateIntersectionData()
        {
            // =========================================================================
            // Create Head2
            head3 = new ListNode(100);
            // Create Next2 Node
            ListNode next3 = new ListNode(101);
            head3.Next = next3;
            // Create End2 Node
            ListNode end3 = new ListNode(102);
            next3.Next = end3;
            // =========================================================================

            // Creating Intersection
            end1.Next = head3;
            end2.Next = head3;
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
            var head = listNodeOperations.AddTwoNumbers(head1, head2);

            // Assert
            Assert.AreEqual(7, head.Value, "Wrong Value");
            Assert.AreEqual(0, head.Next.Value, "Wrong Value");
            Assert.AreEqual(0, head.Next.Next.Value, "Wrong Value");
            Assert.AreEqual(1, head.Next.Next.Next.Value, "Wrong Value");
        }

        [TestMethod]
        public void TestRemoveNthFromEnd1()
        {
            // Arrange
            CreateTestData();

            // Act
            var listNodeOperations = new ListNodeOperations();
            var head = listNodeOperations.AddTwoNumbers(head1, head2);
            listNodeOperations.RemoveNthFromEnd(head, 2);

            // Assert
            Assert.AreEqual(7, head.Value, "Wrong Value");
            Assert.AreEqual(0, head.Next.Value, "Wrong Value");
            Assert.AreEqual(1, head.Next.Next.Value, "Wrong Value");
        }

        [TestMethod]
        public void TestGetIntersectionNode1()
        {
            // Arrange
            CreateTestData();
            CreateIntersectionData();

            // Act
            var listNodeOperations = new ListNodeOperations();
            var head = listNodeOperations.GetIntersectionNode(head1, head2);

            // Assert
            Assert.AreEqual(100, head.Value, "Wrong Value");
            Assert.AreEqual(101, head.Next.Value, "Wrong Value");
            Assert.AreEqual(102, head.Next.Next.Value, "Wrong Value");
        }

        [TestMethod]
        public void TestGetIntersectionNode2()
        {
            // Arrange
            ListNode headA = new ListNode(1);
            headA.Next = new ListNode(3);
            headA.Next.Next = new ListNode(5);
            headA.Next.Next.Next = new ListNode(7);
            headA.Next.Next.Next.Next = new ListNode(9);
            headA.Next.Next.Next.Next.Next = new ListNode(11);
            headA.Next.Next.Next.Next.Next.Next = new ListNode(13);
            headA.Next.Next.Next.Next.Next.Next.Next = new ListNode(15);
            headA.Next.Next.Next.Next.Next.Next.Next.Next = new ListNode(17);
            headA.Next.Next.Next.Next.Next.Next.Next.Next.Next = new ListNode(19);
            headA.Next.Next.Next.Next.Next.Next.Next.Next.Next.Next = new ListNode(21);

            ListNode headB = new ListNode(2);

            // Act
            var listNodeOperations = new ListNodeOperations();
            var head = listNodeOperations.GetIntersectionNode(headA, headB);

            // Assert
            Assert.AreEqual(null, head, "Wrong Value");
        }

        [TestMethod]
        public void TestHasCycle()
        {
            // Arrange
            CreateTestData();
            end1.Next = head1;

            // Act
            var listNodeOperations = new ListNodeOperations();
            var result1 = listNodeOperations.HasCycle(head1);
            var result2 = listNodeOperations.HasCycle(head2);

            // Assert
            Assert.AreEqual(true, result1, "Wrong Result");
            Assert.AreEqual(false, result2, "Wrong Result");
        }
    }
}
