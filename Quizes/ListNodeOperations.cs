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
    }
}
