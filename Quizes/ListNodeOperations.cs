using MainDSA.DataStructures.Lists;
using System;

namespace MainDSA.Quizes
{
    public class ListNodeOperations
    {
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode head = new ListNode(0);
            ListNode p = head;

            while (l1 != null || l2 != null)
            {
                if (l1 != null && l2 != null)
                {
                    if (l1.Value < l2.Value)
                    {
                        p.Next = l1;
                        l1 = l1.Next;
                    }
                    else
                    {
                        p.Next = l2;
                        l2 = l2.Next;
                    }
                    p = p.Next;
                }
                else if (l1 == null)
                {
                    p.Next = l2;
                    break;
                }
                else if (l2 == null)
                {
                    p.Next = l1;
                    break;
                }
            }

            return head.Next;
        }

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

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            int length = GetLength(head);
            int nodeToRemove = length - n;
            if (nodeToRemove < 0)
            {
                throw new ArgumentException("The Node Doesn't Exist");
            }
            if (nodeToRemove == 0)
            {
                head = head.Next;
            }
            else
            {
                ListNode previous = null;
                ListNode current = head;
                while (nodeToRemove > 0)
                {
                    nodeToRemove--;
                    previous = current;
                    current = current.Next;
                    if (nodeToRemove == 0)
                    {
                        previous.Next = current.Next;
                    }
                    
                }
            }
            return head;
        }

        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            ListNode pointer1 = headA, pointer2 = headB;
            if (headA == null || headB == null)
            {
                return null;
            }
            int diff = 0;
            int lengthA = GetLength(headA);
            int lengthB = GetLength(headB);
            if (lengthA > lengthB)
            {
                diff = lengthA - lengthB;
                int i = 0;
                while (i < diff)
                {
                    pointer1 = pointer1.Next;
                    i++;
                }
            }
            else
            {
                diff = lengthB - lengthA;
                int i = 0;
                while (i < diff)
                {
                    pointer2 = pointer2.Next;
                    i++;
                }
            }

            while (pointer1 != null && pointer2 != null)
            {
                if (pointer1 == pointer2)
                {
                    return pointer2;
                }
                else
                {

                }
                pointer1 = pointer1.Next;
                pointer2 = pointer2.Next;
            }

            return null;
        }

        public bool HasCycle(ListNode head)
        {
            ListNode fast = head;
            ListNode slow = head;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;

                if (slow == fast)
                    return true;
            }

            return false;
        }
    }
}
