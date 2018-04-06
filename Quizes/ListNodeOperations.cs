using MainDSA.DataStructures.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainDSA.Quizes
{
    public class ListNodeOperations
    {
        public ListNode ReverseListIteratively(ListNode head)
        {
            ListNode previousNode = null;
            ListNode currentNode = head;
            while (currentNode != null)
            {
                ListNode tempNode = currentNode.Next;
                currentNode.Next = previousNode;
                previousNode = currentNode;
                currentNode = tempNode;
            }
            return previousNode;
        }

        public ListNode ReverseListRecursively(ListNode head)
        {
            if (head == null || head.Next == null) return head;
            ListNode previous = ReverseListRecursively(head.Next);
            head.Next.Next = head;
            head.Next = null;
            return previous;
        }

        public int GetLength(ListNode head)
        {
            int length = 0;
            while (head != null)
            {
                head = head.Next;
                length++;
            }
            return length;
        }

        public ListNode AddTwoNumbers(ListNode headList1, ListNode headList2)
        {
            ListNode dummyHead = new ListNode(0);
            ListNode pointer1 = headList1, pointer2 = headList2, current = dummyHead;
            int carry = 0;
            while (pointer1 != null || pointer2 != null)
            {
                int x = (pointer1 != null) ? pointer1.Value : 0;
                int y = (pointer2 != null) ? pointer2.Value : 0;
                int sum = carry + x + y;
                carry = sum / 10;
                current.Next = new ListNode(sum % 10);
                current = current.Next;
                if (pointer1 != null) pointer1 = pointer1.Next;
                if (pointer2 != null) pointer2 = pointer2.Next;
            }
            if (carry > 0)
            {
                current.Next = new ListNode(carry);
            }
            return dummyHead.Next;
        }
    }
}
