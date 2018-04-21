using MainDSA.DataStructures.Lists;
using MainDSA.Quizes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSATests.Quizes
{
    [TestClass]
    public class ListNodeOperationsTests
    {
        private ListNodeOperations listNodeOperations;
        private ListNode head1;
        private ListNode head2;
        private ListNode head3;
        private ListNode end1;
        private ListNode end2;

        private ListNode duplicate;

        [TestInitialize]
        public void CreateTestData()
        {
            listNodeOperations = new ListNodeOperations();
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

        public void CreateListWithDuplicateData()
        {
            duplicate = new ListNode(5);
            duplicate.Next = new ListNode(3);
            duplicate.Next.Next = new ListNode(3);
            duplicate.Next.Next.Next = new ListNode(4);
            duplicate.Next.Next.Next.Next = new ListNode(1);
            duplicate.Next.Next.Next.Next.Next = new ListNode(1);
            duplicate.Next.Next.Next.Next.Next.Next = new ListNode(3);
            duplicate.Next.Next.Next.Next.Next.Next.Next = new ListNode(2);
        }

        [TestMethod]
        public void TestRemoveDuplicatesUsingBuffer()
        {
            // Arrange
            CreateListWithDuplicateData();

            // Act
            listNodeOperations.RemoveDuplicatesUsingBuffer(duplicate);

            // Assert
            Assert.AreEqual(5, duplicate.Value, "Wrong Value");
            Assert.AreEqual(3, duplicate.Next.Value, "Wrong Value");
            Assert.AreEqual(4, duplicate.Next.Next.Value, "Wrong Value");
            Assert.AreEqual(1, duplicate.Next.Next.Next.Value, "Wrong Value");
            Assert.AreEqual(2, duplicate.Next.Next.Next.Next.Value, "Wrong Value");
        }

        [TestMethod]
        public void TestRemoveDuplicatesWithoutBuffer()
        {
            // Arrange
            CreateListWithDuplicateData();

            // Act
            listNodeOperations.RemoveDuplicatesWithoutBuffer(duplicate);

            // Assert
            Assert.AreEqual(5, duplicate.Value, "Wrong Value");
            Assert.AreEqual(3, duplicate.Next.Value, "Wrong Value");
            Assert.AreEqual(4, duplicate.Next.Next.Value, "Wrong Value");
            Assert.AreEqual(1, duplicate.Next.Next.Next.Value, "Wrong Value");
            Assert.AreEqual(2, duplicate.Next.Next.Next.Next.Value, "Wrong Value");
        }

        [TestMethod]
        public void TestKthToLastNode()
        {
            // Arrange
            CreateListWithDuplicateData();

            // Act
            var node = listNodeOperations.KthToLastNode(duplicate, 2);

            // Assert
            Assert.AreEqual(3, node.Value, "Wrong Value");
            Assert.AreEqual(2, node.Next.Value, "Wrong Value");
        }

        [TestMethod]
        public void TestDeleteNodeFromMiddleOfList()
        {
            // Arrange
            CreateListWithDuplicateData();
            // Check for Original Count of Nodes As 8 could be added here

            // Act
            var result = listNodeOperations.DeleteNodeFromMiddleOfList(duplicate, 3);

            // Assert
            // Assert for Count of Nodes As 7 could be added here
            Assert.AreEqual(true, result, "Wrong Value");
            Assert.AreEqual(5, duplicate.Value, "Wrong Value");
            Assert.AreEqual(3, duplicate.Next.Value, "Wrong Value");
            Assert.AreEqual(4, duplicate.Next.Next.Value, "Wrong Value");

            // Act
            listNodeOperations.DeleteNodeFromMiddleOfList(duplicate, 3);

            // Assert
            // Assert for Count of Nodes As 6 could be added here
            Assert.AreEqual(true, result, "Wrong Value");
            Assert.AreEqual(5, duplicate.Value, "Wrong Value");
            Assert.AreEqual(4, duplicate.Next.Value, "Wrong Value");
            Assert.AreEqual(1, duplicate.Next.Next.Value, "Wrong Value");

            // Arrange
            var nodeToDelete = duplicate.Next.Next;
            // Act
            listNodeOperations.DeleteNodeFromMiddleOfList(nodeToDelete);
            // Assert
            // Assert for Count of Nodes As 5 could be added here
            Assert.AreEqual(true, result, "Wrong Value");
            Assert.AreEqual(5, duplicate.Value, "Wrong Value");
            Assert.AreEqual(4, duplicate.Next.Value, "Wrong Value");
            Assert.AreEqual(1, duplicate.Next.Next.Value, "Wrong Value");

        }

        /// <summary>
        /// Original List: 5 => 3 => 3 => 4 => 1 => 1 => 3 => 2
        /// New List Regardless of the order First 6 Node Values less than 4
        /// </summary>
        [TestMethod]
        public void TestPartition()
        {
            // Arrange
            CreateListWithDuplicateData();

            // Act
            var node = listNodeOperations.Partition(duplicate, 4);

            // Assert
            Assert.AreEqual(true, node.Value < 4, "Wrong Value"); // First Node
            Assert.AreEqual(true, node.Next.Value < 4, "Wrong Value"); // Second Node
            Assert.AreEqual(true, node.Next.Next.Value < 4, "Wrong Value"); // Third Node
            Assert.AreEqual(true, node.Next.Next.Next.Value < 4, "Wrong Value"); // Fourth Node
            Assert.AreEqual(true, node.Next.Next.Next.Next.Value < 4, "Wrong Value"); // Fifth Node
            Assert.AreEqual(true, node.Next.Next.Next.Next.Next.Value < 4, "Wrong Value"); // Sixth Node
        }

        [TestMethod]
        public void TestReverseListIteratively1()
        {
            // Arrange

            // Act
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

            // Act
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

            // Act
            var head = listNodeOperations.AddTwoNumbers(head1, head2);

            // Assert
            Assert.AreEqual(7, head.Value, "Wrong Value");
            Assert.AreEqual(0, head.Next.Value, "Wrong Value");
            Assert.AreEqual(0, head.Next.Next.Value, "Wrong Value");
            Assert.AreEqual(1, head.Next.Next.Next.Value, "Wrong Value");
        }

        [TestMethod]
        public void TestAddTwoNumbers2()
        {
            // Arrange
            var number1 = new ListNode(1);
            var number2 = new ListNode(9);
            // Act
            var sum = listNodeOperations.AddTwoNumbers(number1, number2);
            // Assert
            Assert.AreEqual(0, sum.Value, "Wrong Value");
            Assert.AreEqual(1, sum.Next.Value, "Wrong Value");

            // Arrange
            number1 = new ListNode(1);
            number1.Next = new ListNode(9);
            number1.Next.Next = new ListNode(9);
            number2 = new ListNode(9);
            // Act
            sum = listNodeOperations.AddTwoNumbers(number1, number2);
            // Assert
            Assert.AreEqual(0, sum.Value, "Wrong Value");
            Assert.AreEqual(0, sum.Next.Value, "Wrong Value");
            Assert.AreEqual(0, sum.Next.Next.Value, "Wrong Value");
            Assert.AreEqual(1, sum.Next.Next.Next.Value, "Wrong Value");
        }

        [TestMethod]
        public void TestRemoveNthFromEnd1()
        {
            // Arrange

            // Act
            var head = listNodeOperations.AddTwoNumbers(head1, head2);
            var nodeToRemove = listNodeOperations.KthToLastNode(head, 2);
            listNodeOperations.RemoveNthFromEnd(head, 2);

            // Assert
            Assert.AreEqual(0, nodeToRemove.Value, "Wrong Value");
            Assert.AreEqual(7, head.Value, "Wrong Value");
            Assert.AreEqual(0, head.Next.Value, "Wrong Value");
            Assert.AreEqual(1, head.Next.Next.Value, "Wrong Value");
        }

        [TestMethod]
        public void TestGetIntersectionNode1()
        {
            // Arrange
            CreateIntersectionData();

            // Act
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
            var head = listNodeOperations.GetIntersectionNode(headA, headB);

            // Assert
            Assert.AreEqual(null, head, "Wrong Value");
        }

        [TestMethod]
        public void TestHasCycle()
        {
            // Arrange
            end1.Next = head1;

            // Act
            var result1 = listNodeOperations.HasCycle(head1);
            var result2 = listNodeOperations.HasCycle(head2);

            // Assert
            Assert.AreEqual(true, result1, "Wrong Result");
            Assert.AreEqual(false, result2, "Wrong Result");
        }
    }
}
