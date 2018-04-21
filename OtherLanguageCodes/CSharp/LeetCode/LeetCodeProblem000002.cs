/***********************************************************************************************************
Author: Rahul Vats (https://github.com/rvats/MainDSA)
2. Add Two Numbers
https://leetcode.com/problems/add-two-numbers/description/
You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.

You may assume the two numbers do not contain any leading zero, except the number 0 itself.

Example

Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
Output: 7 -> 0 -> 8
Explanation: 342 + 465 = 807.
***********************************************************************************************************/
using System;

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
        /// Leet Code: 2. Add Two Numbers
        /// Cracking The Coding Interview: 2.5 Sum Of Lists
        /// The Strategy here is to use two pointers and then iterate through the two lists.
        /// Remember The number can be of different lengths :-)
        /// </summary>
        /// <param name="headList1"></param>
        /// <param name="headList2"></param>
        /// <returns>HeadNode for the result List</returns>
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

        /// <summary>
        /// Helper Method To Display The Result
        /// </summary>
        /// <param name="result"></param>
        /// <param name="counter"></param>
        public void DisplayResult(ListNode result, int counter)
        {
            Console.WriteLine("Test Case: {0}", counter);
            while (result != null)
            {
                Console.Write(result.val);
                result = result.next;
            }
            Console.WriteLine();
            Console.WriteLine("================================================");
        }
    }
}