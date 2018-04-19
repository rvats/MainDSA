﻿using System;

namespace Demo
{
    class Program
    {
        private static int counter = 0;

        static void Main(string[] args)
        {
            // =========================================================================
            // Create Head1
            var head1 = new ListNode(2);
            // Create Next1 Node
            ListNode next1 = new ListNode(4);
            head1.next = next1;
            // Create End1 Node
            var end1 = new ListNode(5);
            next1.next = end1;
            // =========================================================================

            // =========================================================================
            // Create Head2
            var head2 = new ListNode(5);
            // Create Next2 Node
            ListNode next2 = new ListNode(6);
            head2.next = next2;
            // Create End2 Node
            var end2 = new ListNode(4);
            next2.next = end2;
            // =========================================================================

            Solution s = new Solution();
            var result = s.AddTwoNumbers(head1, head2);
            // 542 + 465 = 1007 but the display will be 7001
            s.DisplayResult(result, ++counter);
        }
    }

    /**
    * Definition for singly-linked list.
    **/
    /// <summary>
    /// 2. Add Two Numbers Prerequisites - The List Node Structure
    /// </summary>
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    /// <summary>
    /// 2. Add Two Numbers
    /// </summary>
    public class Solution
    {
        /// <summary>
        /// The Strategy here is to use two pointers and then iterate through the two lists.
        /// Remember The number can be of different lengths :-)
        /// </summary>
        /// <param name="headList1"></param>
        /// <param name="headList2"></param>
        /// <returns></returns>
        public ListNode AddTwoNumbers(ListNode headList1, ListNode headList2)
        {

            ListNode headPointer = new ListNode(0);
            ListNode pointer1 = headList1, pointer2 = headList2, current = headPointer;
            int carry = 0;
            while (pointer1 != null || pointer2 != null)
            {
                int x = (pointer1 != null) ? pointer1.val : 0;
                int y = (pointer2 != null) ? pointer2.val : 0;
                int sum = carry + x + y;
                carry = sum / 10;
                current.next = new ListNode(sum % 10);
                current = current.next;
                if (pointer1 != null) pointer1 = pointer1.next;
                if (pointer2 != null) pointer2 = pointer2.next;
            }
            if (carry > 0)
            {
                current.next = new ListNode(carry);
            }
            return headPointer.next;
        }

        /// <summary>
        /// Helper Method To Display The Result
        /// </summary>
        /// <param name="result"></param>
        /// <param name="counter"></param>
        public void DisplayResult(ListNode result, int counter)
        {
            Console.WriteLine("Test Case: {0}", counter);
            while(result!=null)
            {
                Console.Write(result.val);
                result = result.next;
            }
            Console.WriteLine();
            Console.WriteLine("================================================");
        }
    }
}
