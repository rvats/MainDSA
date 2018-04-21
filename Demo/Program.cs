/********************************************************************************************
Aim: This is a demo application which I will be using to keep practising all the questions and 
exercise the concepts and application via a demo app.
Author: Rahul Vats
Current: Add Two List Where the list stores a digit in one node of a number in reverse order
History:
********************************************************************************************/
using MainDSA.DataStructures.Lists;
using System;

namespace Demo
{
    /// <summary>
    /// C# - Bitwise Operators
    /// </summary>
    class Program
    {
        static ListNode head1;
        static ListNode head2;
        static void SetUpData()
        {
            head1 = new ListNode(1);
            head2 = new ListNode(9);
        }

        static void Main(string[] args)
        {
            SetUpData();
            var head = AddTwoNumbers(head1,head2);
            while (head != null)
            {
                Console.WriteLine("Result is displayed in Reverse Order");
                Console.Write(head.Value);
                head = head.Next;
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Revision Of AddTwoNumbers Algorithm
        /// </summary>
        /// <param name="headList1"></param>
        /// <param name="headList2"></param>
        /// <returns></returns>
        static ListNode AddTwoNumbers(ListNode headList1, ListNode headList2)
        {
            ListNode result = new ListNode(0);
            ListNode pointer1 = headList1, pointer2 = headList2, current = result;
            int carry = 0;
            while (pointer1 != null || pointer2 != null)
            {
                int pointer1Value = (pointer1 != null) ? pointer1.Value : 0;
                int pointer2Value = (pointer2 != null) ? pointer2.Value : 0;
                int sum = carry + pointer1Value + pointer2Value;
                carry = sum / 10;
                current.Next = new ListNode(sum % 10);
                current = current.Next;
                if (pointer1 != null) { pointer1 = pointer1.Next; }
                if (pointer2 != null) { pointer2 = pointer2.Next; }
            }
            if (carry > 0)
            {
                current.Next = new ListNode(carry);
            }
            return result.Next;
        }
    }
}