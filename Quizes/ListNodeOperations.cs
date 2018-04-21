using MainDSA.DataStructures.Lists;
using System;
using System.Collections.Generic;

namespace MainDSA.Quizes
{
    public class ListNodeOperations
    {
        ListNode headPointer;
        ListNode leftPointer;
        ListNode rightPointer;

        /// <summary
        /// Leetcode: 234.Palindrome Linked List
        /// Cracking The Coding Interview: 2.6 Palindrome: Implement a function to check if a linked list is a palindrome
        /// Approach 1: Reverse and Compare: The time is O(n) and Space is O(N).
        /// Approach 2: Iterative Approach: The time is O(n) and Space is O(1).
        /// Approach 3: Recursive Approach: The time is O(n) and Space is O(1).
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool IsListPalindromeIterative(ListNode head)
        {
            if (head == null || head.Next == null)
                return true;

            //find list center
            ListNode fast = head;
            ListNode slow = head;

            while (fast.Next != null && fast.Next.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
            }

            ListNode secondHead = slow.Next;
            slow.Next = null;

            //reverse second part of the list
            ListNode pointer1 = secondHead;
            ListNode pointer2 = pointer1.Next;

            while (pointer1 != null && pointer2 != null)
            {
                ListNode temp = pointer2.Next;
                pointer2.Next = pointer1;
                pointer1 = pointer2;
                pointer2 = temp;
            }

            secondHead.Next = null;

            //compare two sublists now
            ListNode p = (pointer2 == null ? pointer1 : pointer2);
            ListNode q = head;
            while (p != null)
            {
                if (p.Value != q.Value)
                    return false;

                p = p.Next;
                q = q.Next;

            }

            return true;
        }

        /// <summary>
        /// Leetcode: 234.Palindrome Linked List
        /// Cracking The Coding Interview: 2.6 Palindrome: Implement a function to check if a linked list is a palindrome
        /// Approach 1: Reverse and Compare: The time is O(n) and Space is O(N).
        /// Approach 2: Iterative Approach: The time is O(n) and Space is O(1).
        /// Approach 3: Recursive Approach: The time is O(n) and Space is O(1).
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool IsListPalindromeRecursive(ListNode head)
        {
            leftPointer = head;
            return PalindromeHelper(head);
        }

        /// <summary>
        /// Helper To Determine if a List is Palindrome
        /// </summary>
        /// <param name="right"></param>
        /// <returns></returns>
        private bool PalindromeHelper(ListNode right)
        {
            //stop recursion
            if (right == null)
                return true;
            //if sub-list is not palindrome,  return false
            bool resultSubstring = PalindromeHelper(right.Next);
            if (!resultSubstring) { return resultSubstring; }
            //current left and right
            bool result = (leftPointer.Value == right.Value);
            //move left to next
            leftPointer = leftPointer.Next;
            return result;
        }

        /// <summary>
        /// 25. Reverse Nodes in k-Group
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null || k == 1)
                return head;

            ListNode fake = new ListNode(0);
            fake.Next = head;
            ListNode pre = fake;
            int i = 0;

            ListNode p = head;
            while (p != null)
            {
                i++;
                if (i % k == 0)
                {
                    pre = Reverse(pre, p.Next);
                    p = pre.Next;
                }
                else
                {
                    p = p.Next;
                }
            }

            return fake.Next;
        }

        /*
         * 0->1->2->3->4->5->6
         * |           |   
         * pre        next
         *
         * after calling pre = reverse(pre, next)
         * 
         * 0->3->2->1->4->5->6
         *          |  |
         *          pre next 
         */

        /// <summary>
        /// 25. Reverse Nodes in k-Group
        /// </summary>
        /// <param name="pre"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public ListNode Reverse(ListNode pre, ListNode next)
        {
            ListNode last = pre.Next;
            ListNode curr = last.Next;

            while (curr != next)
            {
                last.Next = curr.Next;
                curr.Next = pre.Next;
                pre.Next = curr;
                curr = last.Next;
            }

            return last;
        }

        /// <summary>
        /// Merging Two List in a sorted manner
        /// </summary>
        /// <param name="headList1"></param>
        /// <param name="headList2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists(ListNode headList1, ListNode headList2)
        {
            ListNode head = new ListNode(0);
            ListNode pointer = head;

            while (headList1 != null || headList2 != null)
            {
                if (headList1 != null && headList2 != null)
                {
                    if (headList1.Value < headList2.Value)
                    {
                        pointer.Next = headList1;
                        headList1 = headList1.Next;
                    }
                    else
                    {
                        pointer.Next = headList2;
                        headList2 = headList2.Next;
                    }
                    pointer = pointer.Next;
                }
                else if (headList1 == null)
                {
                    pointer.Next = headList2;
                    break;
                }
                else if (headList2 == null)
                {
                    pointer.Next = headList1;
                    break;
                }
            }

            return head.Next;
        }

        public ListNode MergeKLists(ListNode[] lists)
        {
            return MergeKListsHelper(lists, 0, lists.Length - 1);
        }

        private ListNode MergeKListsHelper(ListNode[] lists, int low, int high)
        {
            if (low > high) return null;
            if (low == high) return lists[low];

            var mid = (high - low) / 2 + low;
            var left = MergeKListsHelper(lists, low, mid);
            var right = MergeKListsHelper(lists, mid + 1, high);

            return Merge2List(left, right);
        }

        private ListNode Merge2List(ListNode left, ListNode right)
        {
            if (left == null) return right;
            if (right == null) return left;
            var fakehead = new ListNode(-1);
            var start = fakehead;
            while (left != null && right != null)
            {
                if (left.Value < right.Value)
                {
                    start.Next = left;
                    start = start.Next;

                    left = left.Next;
                }
                else
                {
                    start.Next = right;
                    start = start.Next;

                    right = right.Next;
                }
            }

            if (left != null)
            {
                start.Next = left;
            }
            if (right != null)
            {
                start.Next = right;
            }

            return fakehead.Next;
        }

        /// <summary>
        /// Reverse a List Iteratively
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Reverse a List Recursively
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseListRecursively(ListNode head)
        {
            if (head == null || head.Next == null) return head;
            ListNode previous = ReverseListRecursively(head.Next);
            head.Next.Next = head;
            head.Next = null;
            return previous;
        }

        /// <summary>
        /// Get Length Of Linked list
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Leet Code: 2. Add Two Numbers
        /// Cracking The Coding Interview: 2.5 Sum Of Lists
        /// </summary>
        /// <param name="headList1"></param>
        /// <param name="headList2"></param>
        /// <returns></returns>
        public ListNode AddTwoNumbers(ListNode headList1, ListNode headList2)
        {
            ListNode result = new ListNode(0);
            ListNode pointer1 = headList1, pointer2 = headList2, current = result;
            int carry = 0;
            int sum = 0;
            while (pointer1 != null || pointer2 != null)
            {
                int pointer1Value = 0;
                int pointer2Value = 0;
                if (pointer1 != null)
                {
                    pointer1Value = pointer1.Value;
                    pointer1 = pointer1.Next;
                }
                if (pointer2 != null)
                {
                    pointer2Value = pointer2.Value;
                    pointer2 = pointer2.Next;
                }
                sum = carry + pointer1Value + pointer2Value;
                carry = sum / 10;

                current.Next = new ListNode(sum % 10);
                current = current.Next;
            }
            if (carry > 0)
            {
                current.Next = new ListNode(carry);
            }
            return result.Next;
        }

        public class Result
        {
            public ListNode Tail;
            public int Size;
            public Result(ListNode tail, int size)
            {
                Tail = tail;
                Size = size;
            }
        }

        public Result GetTailAndSize(ListNode head)
        {
            if (head == null) { return null; }

            int size = 1;
            ListNode current = head;
            while (current.Next != null)
            {
                current = current.Next;
                size++;
            }
            return new Result(current, size);
        }

        public ListNode GetKthNode(ListNode head, int k)
        {
            ListNode current = head;
            while (k > 0 && current != null)
            {
                current = current.Next;
                k--;
            }
            return current;
        }

        /// <summary>
        /// Leet Code Info: 160. Intersection of Two Linked Lists
        /// Cracking The Coding Interview: 2.7 Intersection Node: Given Two Singly Linked Lists Determine if they intersect
        /// headA: 3 => 1 => 5 => 9 => 7 => 2 => 1
        /// headB:           4 => 6 => 7 => 2 => 1
        /// Output: Node with Value 7
        /// Run Through Each List to get length and the tail node
        ///     If the tails are not equal by reference then return null as there cannot be a intersection
        /// Set two pointers to the start of each linked list.
        /// On the longer linked list, advance its pointer by the difference of length
        /// Now Traverse on each Linked List until the pointers are the same.
        /// </summary>
        /// <param name="headA"></param>
        /// <param name="headB"></param>
        /// <returns></returns>
        public ListNode GetIntersectionNodeUsingNewDataStructure(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null) { return null; }

            // Get Tail And Sizes
            Result result1 = GetTailAndSize(headA);
            Result result2 = GetTailAndSize(headB);

            // If different tail nodes, then there's no interaction
            if (result1.Tail != result2.Tail) { return null; }

            // Set Pointers to the start of each List
            ListNode shorter = (result1.Size < result2.Size) ? headA : headB;
            ListNode longer = (result1.Size < result2.Size) ? headB : headA;

            // Advance The pointer for the longer list by the difference in Lengths
            longer = GetKthNode(longer, Math.Abs(result1.Size - result2.Size));

            while (shorter != longer)
            {
                shorter = shorter.Next;
                longer = longer.Next;
            }

            // You can return either
            return longer;
        }

        /// <summary>
        /// Leet Code Info: 160. Intersection of Two Linked Lists
        /// Cracking The Coding Interview: 2.7 Intersection Node: Given Two Singly Linked Lists Determine if they intersect
        /// headA: 3 => 1 => 5 => 9 => 7 => 2 => 1
        /// headB:           4 => 6 => 7 => 2 => 1
        /// Output: Node with Value 7
        /// Run Through Each List to get length and the tail node
        ///     If the tails are not equal by reference then return null as there cannot be a intersection
        /// Set two pointers to the start of each linked list.
        /// On the longer linked list, advance its pointer by the difference of length
        /// Now Traverse on each Linked List until the pointers are the same.
        /// </summary>
        /// <param name="headA"></param>
        /// <param name="headB"></param>
        /// <returns></returns>
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
                pointer1 = pointer1.Next;
                pointer2 = pointer2.Next;
            }

            return null;
        }

        /// <summary>
        /// LeetCode Information: 141. Linked List Cycle
        /// Cracking The Coding Interview: Loop Detection
        /// Part 1: Detect If List Had A Loop
        /// Part 2: When do they Collide
        /// Part 3: How do you find the start of the loop?
        /// Part 4: Putting it all together
        /// Algorithm: 
        /// Create Two Pointers fast and slow
        /// Move fast pointer two step at a time and slow pointer one step at a time
        /// When they collide its result ( return true if they collide as its indicate cycle.)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
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

        /// <summary>
        /// LeetCode Information: 142. Linked List Cycle II
        /// Cracking The Coding Interview: Loop Detection
        /// Part 1: Detect If List Had A Loop
        /// Part 2: When do they Collide
        /// Part 3: How do you find the start of the loop?
        /// Part 4: Putting it all together
        /// Algorithm: 
        /// Create Two Pointers fast and slow
        /// Move fast pointer two step at a time and slow pointer one step at a time
        /// When they collide, move slow pointer to head of list, keep fast pointer where it is
        /// Move slow and fast 1 step at a time where they meet is the collision point
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DetectCycle(ListNode head)
        {
            ListNode fast = head;
            ListNode slow = head;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;

                if (slow == fast)
                    break;
            }

            // Error Check: No meeting point and therefore no loop
            if (fast == null || fast.Next == null) { return null; }

            // Move Slow to head and start moving both at same pace they meet at the start of cycle
            slow = head;
            while (slow != fast)
            {
                slow = slow.Next;
                fast = fast.Next;
            }
            // return either slow or fast
            return fast;
        }

        /// <summary>
        /// 2.1 Remove Duplicates: Write code to remove duplicates from an unsorted linked list
        /// O(N) Time Use Buffer to keep track of Data
        /// O(N) Space
        /// </summary>
        /// <param name="head"></param>
        public void RemoveDuplicatesUsingBuffer(ListNode head)
        {
            HashSet<int> setListNode = new HashSet<int>();
            ListNode previous = null;
            while (head != null)
            {
                if (setListNode.Contains(head.Value))
                {
                    previous.Next = head.Next;
                }
                else
                {
                    setListNode.Add(head.Value);
                    previous = head;
                }
                head = head.Next;
            }
        }

        /// <summary>
        /// 2.1 Remove Duplicates: Write code to remove duplicates from an unsorted linked list
        /// O(N^2) Time - No Buffer 
        /// O(1) Space
        /// </summary>
        /// <param name="head"></param>
        public void RemoveDuplicatesWithoutBuffer(ListNode head)
        {
            ListNode current = head;
            while (current != null)
            {
                /* Remove All Next Nodes With Duplicate Values */
                ListNode runner = current;
                while (runner.Next != null)
                {
                    if (runner.Next.Value == current.Value)
                    {
                        runner.Next = runner.Next.Next;
                    }
                    else
                    {
                        runner = runner.Next;
                    }
                }
                current = current.Next;
            }
        }

        /// <summary>
        /// 2.2 Return kth to last node: Implement an algorithm to find the kth to last element of a singly linked list
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode KthToLastNode(ListNode head, int k)
        {
            ListNode pointer1 = head;
            ListNode pointer2 = head;

            // Move pointer1 k nodes into the List
            for (int i = 0; i < k; i++)
            {
                if (pointer1 == null) { return null; }
                pointer1 = pointer1.Next;
            }

            // Now move both pointer at the same time when pointer1 reached end (length) pointer2 will be at kthfromlast = length - k
            while (pointer1 != null)
            {
                pointer1 = pointer1.Next;
                pointer2 = pointer2.Next;
            }

            return pointer2;
        }

        /// <summary>
        /// Similar to one above 2.2 Return kth to last node: This time you are removing the node
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 2.3 Delete Middle Node
        /// Assumption: If duplicate data exist then it will delete first node from head which equals value
        /// </summary>
        /// <param name="value"></param>
        public bool DeleteNodeFromMiddleOfList(ListNode head, int value)
        {
            ListNode current = head;
            ListNode previous = head;
            while (current == null || current.Value != value)
            {
                previous = current;
                current = current.Next;
            }
            if (previous.Next != null)
            {
                previous.Next = current.Next;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 2.3 Delete Middle Node Without Access to Head Node. Direct Node is given.
        /// Assumption: If duplicate data exist then it will delete first node from head which equals value
        /// </summary>
        /// <param name="value"></param>
        public bool DeleteNodeFromMiddleOfList(ListNode node)
        {
            if (node == null || node.Next == null)
            {
                return false;
            }
            ListNode next = node.Next;
            node.Value = next.Value;
            node.Next = next.Next;
            return true;
        }

        /// <summary>
        /// 2.4 Partition: Write An Algorithm to create a list which creates a partition between values of Node less than supplied targetValue
        /// </summary>
        /// <param name="head"></param>
        /// <param name="targetValue"></param>
        /// <returns></returns>
        public ListNode Partition(ListNode head, int targetValue)
        {
            ListNode start = head;
            ListNode end = head;

            while (head != null)
            {
                ListNode next = head.Next;
                if (head.Value < targetValue)
                {
                    head.Next = start;
                    start = head;
                }
                else
                {
                    end.Next = head;
                    end = head;
                }
                head = next;
            }
            end.Next = null;
            return start;
        }
    }
}
